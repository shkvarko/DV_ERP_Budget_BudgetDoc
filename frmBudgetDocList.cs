using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraEditors;
using System.Threading;
using System.Linq;

namespace ErpBudgetBudgetDoc
{
    public partial class frmBudgetDocList : DevExpress.XtraEditors.XtraForm
    {
        #region ����������, ��������, ���������
        /// <summary>
        /// �������
        /// </summary>
        private UniXP.Common.CProfile m_objProfile;
        private UniXP.Common.MENUITEM m_objMenuItem;
        /// <summary>
        /// ������ �������� ������
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDoc> m_objBudgetDocList;
        /// <summary>
        /// ������ ���������� ������
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDoc> m_objBudjetDocArjList;
        /// <summary>
        /// ������ ��������, �������� �� ����� ���� ���������
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocTypeVariable> m_objDocTypeVariableList;
        /// <summary>
        /// ������ ����� ���������� � ��������� �� ������
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocTypeCondition> m_objBudgetDocTypeTemplateList;
        /// <summary>
        /// ������ ��������, �������� �� ����� ��������
        /// </summary>
        private List<ERP_Budget.Common.CRouteVariable> m_objRouteVariableList;
        /// <summary>
        /// ������ ��������� � ��������� �� ��������������
        /// </summary>
        private List<ERP_Budget.Common.CRouteCondition> m_objRouteTemplateList;
        /// <summary>
        /// ������ �������� ��� ����� ��������� ����������
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocType> m_objBudgetDocTypeList;
        /// <summary>
        /// ������ �������� ��� ��������� ��������� ����������
        /// </summary>
        private List<ERP_Budget.Common.CBudgetDocState> m_objBudgetDocStateList;
        /// <summary>
        /// ������ �� ����������, � ������� ���������� �������
        /// </summary>
        private List<System.Guid> m_DocChangeNoteTypeList;
        /// <summary>
        /// ������ �������
        /// </summary>
        private List<ERP_Budget.Common.CNoteType> m_objNoteTypeList;
        /// <summary>
        /// ������ "������� ������������"
        /// </summary>
        private ERP_Budget.Common.CUser m_objCurrentUser;
        /// <summary>
        /// ������� ����, ��� ����� ��������� �� Outlook
        /// </summary>
        public System.Boolean m_bOutlookMode;
        /// <summary>
        /// ������� ����, ��� ����� ������������ ������� ������ ������
        /// </summary>
        private System.Boolean m_bBlockDblClick;
        /// <summary>
        /// �����, � ������ ���������������� ��������� ���������
        /// </summary>
        private System.Threading.Thread ThreadInitializeVariable;
        public delegate void SendMessageToLogDelegate(System.String strMessage);
        public SendMessageToLogDelegate m_SendMessageToLogDelegate;
        /// <summary>
        /// ������ ������������ ���� ������������ � ���������� ������� "������"
        /// </summary>
        private List<ERP_Budget.Common.CDynamicRight> m_objUserDynamicRightList;

        private const System.String PrefixWork = "A_";
        private const System.String PrefixWorked = "B_";
        private const System.String PrefixNotActive = "C_";
        private const System.String PrefixError = "E_";
        private const System.String strtabWorkName = "�������������� ������";
        private const System.String strtabWorkedName = "������������ ������";
        private const System.String strtabNotActiveName = "����� ������";
        private const System.String strtabErrorName = "������ ������";
        private const System.String strEndRefresh = "������";
        private const System.String strRefreshingDocList = "���� ���������� ������� ������...";
        private const System.String strRefreshingArjDocList = "���� ���������� ������ ������...";
        private const System.Int32 iThreadSleepTime = 2000;
        private const System.Int32 iTimerInterval = 60000;
        private const System.Int32 iCommandTimeout = 600;
        // 2009.06.10 ��������! ������ ��������
        private const System.String strBudgetDocStateReturnMoney = "������ �������";
        private const System.String strBudgetDocTypeReturnMoney = "�������������� ������";
        private const System.String strDots = "...";


        #endregion

        #region �����������
        public frmBudgetDocList(UniXP.Common.CProfile objProfile, UniXP.Common.MENUITEM objMenuItem)
        {
            m_objProfile = objProfile;
            m_objMenuItem = objMenuItem;

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

            InitializeComponent();

            InitializeVariable();
        }
        /// <summary>
        /// ������������� ����������
        /// </summary>
        private void InitializeVariable()
        {
            try
            {
                lblStatusBar.Caption = "";

                m_objCurrentUser = ERP_Budget.Common.CUser.GetUsersInfo(this.m_objProfile);
                m_objCurrentUser.LoadDocEventList(this.m_objProfile);

                m_objBudgetDocList = new List<ERP_Budget.Common.CBudgetDoc>();
                m_objBudjetDocArjList = new List<ERP_Budget.Common.CBudgetDoc>();

                m_DocChangeNoteTypeList = new List<Guid>();

                m_bOutlookMode = false;
                m_IsRefreshBudgetDocList = false;
                m_bBlockDblClick = false;

                m_objRouteTemplateList = null;
                m_objBudgetDocTypeTemplateList = null;
                m_objUserDynamicRightList = null;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "InitializeVariable.\n\n����� ������: " + f.Message, "������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// ������ ������, � ������� ����������� ������� ��� ������ ��������
        /// </summary>
        public void InitializeVariableInThread()
        {
            try
            {
                System.String strErr = System.String.Empty;

                m_objBudgetDocTypeList = ERP_Budget.Common.CBudgetDocType.GetDocTypeListPictures(m_objProfile);
                m_objBudgetDocStateList = ERP_Budget.Common.CBudgetDocState.GetBudgetDocStateListPictures(m_objProfile);
                m_objUserDynamicRightList = ERP_Budget.Common.CDynamicRight.GetDynamicRightsList(m_objProfile, m_objCurrentUser.ulID, ref strErr);
                {
                    if( (m_objUserDynamicRightList != null) && (m_objUserDynamicRightList.Count > 0))
                    {
                        m_objUserDynamicRightList = m_objUserDynamicRightList.Where<ERP_Budget.Common.CDynamicRight>(x => x.IsEnable == true).ToList<ERP_Budget.Common.CDynamicRight>();
                    }
                }

                // ����������, �������� �� ����� ��������
                m_objRouteVariableList = ERP_Budget.Common.CRouteVariable.GetRouteVariableList(m_objProfile);
                if ((m_objRouteVariableList == null) || (m_objRouteVariableList.Count == 0))
                {
                    this.Invoke(m_SendMessageToLogDelegate, new Object[] { "�� ������� ��������� ������ ����������, �������� �� ����� ��������. ���������� � ������������!" });
                }

                // ������ ������� ������ ��������
                m_objRouteTemplateList = ERP_Budget.Common.CRouteCondition.GetRouteConditionList(m_objProfile);
                if ((m_objRouteTemplateList == null) || (m_objRouteTemplateList.Count == 0))
                {
                    this.Invoke(m_SendMessageToLogDelegate, new Object[] { "�� ������� ��������� ������ ������� ������ ��������. ���������� � ������������!" });
                }

                // ������ ����������, �������� �� ����� ���� ���������
                m_objDocTypeVariableList = ERP_Budget.Common.CBudgetDocTypeVariable.GetDocTypeVariableList(m_objProfile);
                if ((m_objDocTypeVariableList == null) || (m_objDocTypeVariableList.Count == 0))
                {
                    this.Invoke(m_SendMessageToLogDelegate, new Object[] { "�� ������� ��������� ������ ����������, �������� �� ����� ���� ���������. ���������� � ������������!" });
                }

                // ������ ������� ������ ���� ��������� 
                m_objBudgetDocTypeTemplateList = ERP_Budget.Common.CBudgetDocTypeCondition.GetDocTypeConditionList(m_objProfile);
                if ((m_objBudgetDocTypeTemplateList == null) || (m_objBudgetDocTypeTemplateList.Count == 0))
                {
                    this.Invoke(m_SendMessageToLogDelegate, new Object[] { "�� ������� ��������� ������� ������ ���� ���������. ���������� � ������������!" });
                }

            }
            catch (System.Exception f)
            {
                    this.Invoke(m_SendMessageToLogDelegate, new Object[] { "InitializeVariableInThread: " + f.Message});
            }

            return;
        }

        private System.Reflection.Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            System.Reflection.Assembly MyAssembly = null;
            System.Reflection.Assembly objExecutingAssemblies = System.Reflection.Assembly.GetExecutingAssembly();

            System.Reflection.AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            System.String strDllName = "";
            foreach (System.Reflection.AssemblyName strAssmbName in arrReferencedAssmbNames)
            {

                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                {
                    strDllName = args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll";
                    break;
                }

            }
            if (strDllName != "")
            {
                System.String strFileFullName = "";
                System.Boolean bError = false;
                foreach (System.String strPath in this.m_objProfile.ResourcePathList)
                {
                    //Load the assembly from the specified path. 
                    strFileFullName = strPath + "\\" + strDllName;
                    if (System.IO.File.Exists(strFileFullName))
                    {
                        try
                        {
                            MyAssembly = System.Reflection.Assembly.LoadFrom(strFileFullName);
                            break;
                        }
                        catch (System.Exception f)
                        {
                            bError = true;
                            DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ����������: " +
                                strFileFullName + "\n\n����� ������: " + f.Message, "������",
                                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                    if (bError) { break; }
                }
            }

            //Return the loaded assembly.
            if (MyAssembly == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("�� ������� ����� ����������: " +
                                strDllName, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);

            }
            return MyAssembly;
        }
        #endregion

        #region ������ ���������
        private void SendMessageToLog(System.String strMessage)
        {
            try
            {
                m_objMenuItem.SimulateNewMessage(strMessage);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "SendMessageToLog.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region ������ ������
        // ������
        private System.Threading.Thread thrRefreshBudgetDocArj;
        private System.Threading.Thread thrRefreshBudgetDocActive;

        public delegate void LoadBudgetDocArjiveDelegate(List<ERP_Budget.Common.CBudgetDoc> objBudgetDocList, System.Int32 iRowCountInList);
        public LoadBudgetDocArjiveDelegate m_LoadBudgetDocArjiveDelegate;

        public delegate void LoadBudgetDocActiveDelegate(List<ERP_Budget.Common.CBudgetDoc> objBudgetDocList, System.Int32 iRowCountInList);
        public LoadBudgetDocActiveDelegate m_LoadBudgetDocActiveDelegate;

        private System.Boolean m_IsRefreshBudgetDocList;

        #region ����� ������ UniXP
        /// <summary>
        /// ����������� ����� ������ �� �� � ���������� � ���� ������ �������� ������ CBudgetDoc
        /// </summary>
        /// <returns>������ �������� ������ CBudgetDoc</returns>
        private List<ERP_Budget.Common.CBudgetDoc> LoadBudgetDocArjivefromDB()
        {
            List<ERP_Budget.Common.CBudgetDoc> objList = new List<ERP_Budget.Common.CBudgetDoc>();

            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                DBConnection = m_objProfile.GetDBSource();
                if (DBConnection == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "GetBudgetDocArjive\n\n����������� ���������� � ����� ������.", "��������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                    return objList;
                }
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = DBConnection;
                cmd.CommandTimeout = 600;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = System.String.Format("[{0}].[dbo].[sp_GetBudgetDocList_Arj]", m_objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ulUniXPID", System.Data.SqlDbType.Int));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateType", System.Data.SqlDbType.Int));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BEGINDATE", System.Data.SqlDbType.DateTime));
                cmd.Parameters["@BEGINDATE"].Value = dtBeginDate.DateTime;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ENDDATE", System.Data.SqlDbType.DateTime));
                cmd.Parameters["@ENDDATE"].Value = dtEndDate.DateTime;
                cmd.Parameters["@ulUniXPID"].Value = this.m_objProfile.m_nSQLUserID;
                cmd.Parameters["@DateType"].Value = (radioGroupDateType.SelectedIndex >= 0) ? radioGroupDateType.SelectedIndex : 0;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();

                if (rs.HasRows)
                {
                    ERP_Budget.Common.CBudgetDoc objBudgetDoc = null;
                    while (rs.Read())
                    {
                        objBudgetDoc = new ERP_Budget.Common.CBudgetDoc();

                        objBudgetDoc.uuidID = (System.Guid)rs["GUID_ID"];
                        objBudgetDoc.Date = (System.DateTime)rs["BUDGETDOC_DATE"];
                        objBudgetDoc.Money = System.Convert.ToDouble(rs["BUDGETDOC_MONEY"]);
                        objBudgetDoc.MoneyAgree = System.Convert.ToDouble(rs["BUDGETDOC_MONEYAGREE"]);
                        if (rs["ACCTRNSUM"] != System.DBNull.Value)
                        {
                            objBudgetDoc.MoneyTrnSum = System.Convert.ToDouble(rs["ACCTRNSUM"]);
                        }
                        if (rs["NOTETYPE"] != System.DBNull.Value)
                        {
                            objBudgetDoc.NoteTypeID = (System.Guid)rs["NOTETYPE"];
                        }
                        if (rs["USERCOMMENT"] != System.DBNull.Value)
                        {
                            objBudgetDoc.UserComment = (System.String)rs["USERCOMMENT"];
                        }
                        objBudgetDoc.Objective = (System.String)rs["BUDGETDOC_OBJECTIVE"];
                        objBudgetDoc.PaymentDate = (System.DateTime)rs["BUDGETDOC_PAYMENTDATE"];
                        objBudgetDoc.Recipient = (System.String)rs["BUDGETDOC_RECIPIENT"];
                        objBudgetDoc.DocBasis = (System.String)rs["BUDGETDOC_DOCBASIS"];
                        if (rs["DATESTATE"] != System.DBNull.Value)
                        {
                            objBudgetDoc.DateState = (System.DateTime)rs["DATESTATE"];
                        }
                        if (rs["BUDGETDOC_DESCRIPTION"] != System.DBNull.Value)
                        {
                            objBudgetDoc.Description = (System.String)rs["BUDGETDOC_DESCRIPTION"];
                        }
                        objBudgetDoc.IsActive = (System.Boolean)rs["BUDGETDOC_ACTIVE"];
                        // ��������� �������������
                        objBudgetDoc.BudgetDep = new ERP_Budget.Common.CBudgetDep((System.Guid)rs["BUDGETDEP_GUID_ID"], (System.String)rs["BUDGETDEP_NAME"]);
                        // ����� �������
                        objBudgetDoc.PaymentType = new ERP_Budget.Common.CPaymentType((System.Guid)rs["PAYMENTTYPE_GUID_ID"], (System.String)rs["PAYMENTTYPE_NAME"]);
                        // ������� ���������
                        if (rs["MEASURE_GUID_ID"] != System.DBNull.Value)
                        {
                            objBudgetDoc.Measure = new ERP_Budget.Common.CMeasure((System.Guid)rs["MEASURE_GUID_ID"], (System.String)rs["MEASURE_NAME"]);
                        }
                        //������ �������
                        ERP_Budget.Common.CBudgetItem objBudgetItem = new ERP_Budget.Common.CBudgetItem();
                        objBudgetItem.uuidID = (System.Guid)rs["BUDGETITEM_GUID_ID"];
                        objBudgetItem.BudgetItemNum = (System.String)rs["BUDGETITEM_NUM"];
                        objBudgetItem.Name = (System.String)rs["BUDGETITEM_NAME"];
                        objBudgetItem.MoneyInBudgetDocCurrency = objBudgetDoc.Money;
                        objBudgetItem.MoneyInBudgetCurrency = objBudgetDoc.MoneyAgree;
                        if (rs["DEBITARTICLE_GUID_ID"] != System.DBNull.Value)
                        {
                            objBudgetItem.DebitArticleID = (System.Guid)rs["DEBITARTICLE_GUID_ID"];
                        }
                        if (rs["BUDGETEXPENSETYPE_GUID"] != System.DBNull.Value)
                        {
                            objBudgetItem.BudgetExpenseType = new ERP_Budget.Common.CBudgetExpenseType((System.Guid)rs["BUDGETEXPENSETYPE_GUID"],
                            (System.String)rs["BUDGETEXPENSETYPE_NAME"], "");
                        }

                        objBudgetDoc.BudgetItem = objBudgetItem;
                        objBudgetDoc.Division = (System.Boolean)rs["DIVISION"];

                        // ������
                        objBudgetDoc.Currency = new ERP_Budget.Common.CCurrency((System.Guid)rs["CURRENCY_GUID_ID"], (System.String)rs["CURRENCY_CODE"], (System.String)rs["CURRENCY_CODE"]);
                        // ��������
                        objBudgetDoc.Company = new ERP_Budget.Common.CCompany((System.Guid)rs["COMPANY_GUID_ID"], (System.String)rs["COMPANY_NAME"], (System.String)rs["COMPANY_ACRONYM"]);
                        // ��������� ���������
                        objBudgetDoc.DocState = new ERP_Budget.Common.CBudgetDocState((System.Guid)rs["BUDGETDOCSTATE_GUID_ID"], (System.String)rs["BUDGETDOCSTATE_NAME"], (System.Int32)rs["BUDGETDOCSTATE_ID"]);
                        // ��� ���������
                        objBudgetDoc.DocType = new ERP_Budget.Common.CBudgetDocType((System.Guid)rs["BUDGETDOCTYPE_GUID_ID"], (System.String)rs["BUDGETDOCTYPE_NAME"]);
                        // ���������
                        objBudgetDoc.OwnerUser = new ERP_Budget.Common.CUser((System.Int32)rs["CREATEDUSER_ID"], (System.Int32)rs["UNIXPUSER_ID"], (System.String)rs["USER_LASTNAME"], (System.String)rs["USER_FIRSTNAME"]);
                        // ������ ���������
                        objBudgetDoc.ViewMode = (ERP_Budget.Common.enumViewMode)((System.Int32)rs["ViewTypeId"]);
                        // ��������
                        objBudgetDoc.ExistsAttach = (System.Boolean)rs["ATTACH"];

                        objList.Add(objBudgetDoc);
                    }
                }
                rs.Dispose();
                cmd.Dispose();
                DBConnection.Close();

            }
            catch (Exception ex)
            {
                DBConnection.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "LoadBudgetDocArjivefromDB\n\n����� ������: " + ex.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return objList;
        }
        /// <summary>
        /// ������ ������, � ������� ����������� ����� ������
        /// </summary>
        public void StartThreadLoadBudgetDocArjive()
        {
            try
            {
                // �������������� ��������
                m_LoadBudgetDocArjiveDelegate = null;
                m_LoadBudgetDocArjiveDelegate = new LoadBudgetDocArjiveDelegate( LoadBudgetDocArjiveInGrid );

                DisplayStatus(strRefreshingArjDocList);
                
                // ������� ������ � ��������� ������
                dsBudgetDoc.Tables["dtDocNotActive"].Rows.Clear();
                dsBudgetDoc.Tables["dtDocError"].Rows.Clear();
                m_objBudjetDocArjList.Clear();

                gridDocNotActive.RefreshDataSource();

                tabPageDocNotActive.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                tabPageDocNotActive.Text = (strtabNotActiveName + strDots );
                tabPageDocNotActive.Refresh();

                // ������ ������
                this.thrRefreshBudgetDocArj = new System.Threading.Thread( LoadBudgetDocArjiveInThread );
                this.thrRefreshBudgetDocArj.Start();

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThreadLoadBudgetDocArjive().\n\n����� ������: " + f.Message, "������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// �����, �������������� � ������ "����� ������"
        /// </summary>
        public void LoadBudgetDocArjiveInThread()
        {
            try
            {
                List<ERP_Budget.Common.CBudgetDoc> objBudgetDocList = LoadBudgetDocArjivefromDB();

                List<ERP_Budget.Common.CBudgetDoc> objAddBudgetDocList = new List<ERP_Budget.Common.CBudgetDoc>();
                if ((objBudgetDocList != null) && (objBudgetDocList.Count > 0))
                {
                    System.Int32 iRecCount = 0;
                    System.Int32 iRecAllCount = 0;
                    foreach (ERP_Budget.Common.CBudgetDoc objBudgetDoc in objBudgetDocList)
                    {
                        objAddBudgetDocList.Add(objBudgetDoc);
                        iRecCount++;
                        iRecAllCount++;

                        if (iRecCount == 1000)
                        {
                            iRecCount = 0;
                            Thread.Sleep(1000);
                            this.Invoke(m_LoadBudgetDocArjiveDelegate, new Object[] { objAddBudgetDocList, iRecAllCount });
                            objAddBudgetDocList.Clear();
                        }

                    }
                    if (iRecCount != 1000)
                    {
                        iRecCount = 0;
                        this.Invoke(m_LoadBudgetDocArjiveDelegate, new Object[] { objAddBudgetDocList, iRecAllCount });
                        objAddBudgetDocList.Clear();
                    }

                }

                objBudgetDocList = null;
                objAddBudgetDocList = null;
                this.Invoke(m_LoadBudgetDocArjiveDelegate, new Object[] { null, 0 });
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadBudgetDocArjiveInThread.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// ��������� � ������� "����� ������" ������, ���������� �� ���������
        /// </summary>
        /// <param name="objBudgetDocList">������ �������� "������"</param>
        /// <param name="iRowCountInList">����� ���������� �������, ���������� �� ��</param>
        private void LoadBudgetDocArjiveInGrid(List<ERP_Budget.Common.CBudgetDoc> objBudgetDocList, System.Int32 iRowCountInList)
        {
            try
            {
                if ((objBudgetDocList != null) && (objBudgetDocList.Count > 0) && ( gridViewDocNotActive.RowCount < iRowCountInList))
                {
                    m_objBudjetDocArjList.AddRange(objBudgetDocList);

                    System.Data.DataRow row = null;
                    System.String strTableName = dsBudgetDoc.Tables["dtDocNotActive"].TableName;
                    System.String strPrx = PrefixNotActive;

                    foreach (ERP_Budget.Common.CBudgetDoc objBudgetDoc in objBudgetDocList)
                    {
                        row = dsBudgetDoc.Tables[strTableName].NewRow();
                        row[strPrx + "BUDGETDOC_GUID_ID"] = objBudgetDoc.uuidID;
                        row[strPrx + "CREATEDUSER_NAME"] = String.Format("{0} {1}", objBudgetDoc.OwnerUser.UserLastName, objBudgetDoc.OwnerUser.UserFirstName);
                        row[strPrx + "DOCDATE"] = objBudgetDoc.Date;
                        row[strPrx + "BUDGETDEP_NAME"] = objBudgetDoc.BudgetDep.Name;
                        row[strPrx + "DOCOBJECTIVE"] = objBudgetDoc.Objective;
                        row[strPrx + "DOCMONEY"] = objBudgetDoc.Money; 
                        row[strPrx + "DOCMONEYAGREE"] = objBudgetDoc.MoneyAgree;
                        row[strPrx + "ACCTRNSUM"] = objBudgetDoc.MoneyTrnSum;
                        row[strPrx + "DEBITARTICLE_NAME"] = objBudgetDoc.BudgetItem.BudgetItemFullName;
                        row[strPrx + "COMPANY_NAME"] = objBudgetDoc.Company.CompanyAcronym; 
                        row[strPrx + "BUDGETDOCSTATE_NAME"] = objBudgetDoc.DocState.Name;
                        row[strPrx + "BUDGETDOCTYPE_NAME"] = objBudgetDoc.DocType.Name;
                        row[strPrx + "IMAGE_ID"] = objBudgetDoc.DocState.OrderNum; 
                        row[strPrx + "IMAGETYPE_ID"] = (objBudgetDoc.DocType.Name == "������") ? 0 : 1; 
                        row[strPrx + "DOCACTIVE"] = objBudgetDoc.IsActive; 
                        row[strPrx + "RECIPIENT"] = objBudgetDoc.Recipient;
                        row[strPrx + "DATESTATE"] = objBudgetDoc.DateState;
                        row[strPrx + "ATTACH"] = objBudgetDoc.ExistsAttach;
                        row[strPrx + "CURRENCY"] = objBudgetDoc.Currency.CurrencyCode;
                        row[strPrx + "NOTETYPE"] = objBudgetDoc.NoteTypeID;
                        row[strPrx + "NOTETYPE_PREV"] = objBudgetDoc.NoteTypeID;
                        row[strPrx + "USERCOMMENT"] = objBudgetDoc.UserComment;
                        row[strPrx + "PAYMENTTYPE_NAME"] = objBudgetDoc.PaymentType.Name;
                        row[strPrx + "BUDGETEXPENSETYPE_NAME"] = ( (objBudgetDoc.BudgetItem.BudgetExpenseType == null) ? "" : objBudgetDoc.BudgetItem.BudgetExpenseType.Name );
                        dsBudgetDoc.Tables[strTableName].Rows.Add(row);
                    }
                    dsBudgetDoc.AcceptChanges();

                    if ( gridDocNotActive.DataSource == null)
                    {
                        gridDocNotActive.DataSource = dsBudgetDoc;
                    }
                    gridDocNotActive.RefreshDataSource();
                }
                else
                {
                    Thread.Sleep(1000);
                    tabPageDocNotActive.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_lock;
                    tabPageDocNotActive.Text = String.Format("{0} ({1})", strtabNotActiveName, dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count);
                    tabPageDocNotActive.Refresh();

                    DisplayStatus(strEndRefresh);

                    gridDocNotActive.Enabled = (dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count > 0);
                    gridDocErr.Enabled = (dsBudgetDoc.Tables["dtDocError"].Rows.Count > 0);
                    tabPageError.PageVisible = (dsBudgetDoc.Tables["dtDocError"].Rows.Count > 0);

                    Cursor = Cursors.Default;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadBudgetDocArjiveInGrid.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        #endregion

        #region �������� ������ ("�� ���������" � "������������")
        /// <summary>
        /// ����������� �������� ������ �� �� � ���������� � ���� ������ �������� ������ CBudgetDoc
        /// </summary>
        /// <returns>������ �������� ������ CBudgetDoc</returns>
        private List<ERP_Budget.Common.CBudgetDoc> LoadBudgetDocActiveFromDB()
        {
            List<ERP_Budget.Common.CBudgetDoc> objList = new List<ERP_Budget.Common.CBudgetDoc>();

            System.Data.SqlClient.SqlConnection DBConnection = null;
            System.Data.SqlClient.SqlCommand cmd = null;
            try
            {
                DBConnection = m_objProfile.GetDBSource();
                if (DBConnection == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "GetBudgetDocArjive\n\n����������� ���������� � ����� ������.", "��������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                    return objList;
                }
                cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = DBConnection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = System.String.Format("[{0}].[dbo].[sp_GetBudgetDocList_Active]", m_objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ulUniXPID", System.Data.SqlDbType.Int));
                cmd.Parameters["@ulUniXPID"].Value = this.m_objProfile.m_nSQLUserID;
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_NUM", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ERROR_MES", System.Data.SqlDbType.NVarChar, 4000));
                cmd.Parameters["@ERROR_MES"].Direction = System.Data.ParameterDirection.Output;

                System.Data.SqlClient.SqlDataReader rs = cmd.ExecuteReader();

                if (rs.HasRows)
                {
                    ERP_Budget.Common.CBudgetDoc objBudgetDoc = null;
                    while (rs.Read())
                    {
                        objBudgetDoc = new ERP_Budget.Common.CBudgetDoc();

                        objBudgetDoc.uuidID = (System.Guid)rs["GUID_ID"];
                        objBudgetDoc.Date = (System.DateTime)rs["BUDGETDOC_DATE"];
                        objBudgetDoc.Money = System.Convert.ToDouble(rs["BUDGETDOC_MONEY"]);
                        objBudgetDoc.MoneyAgree = System.Convert.ToDouble(rs["BUDGETDOC_MONEYAGREE"]);
                        if (rs["ACCTRNSUM"] != System.DBNull.Value)
                        {
                            objBudgetDoc.MoneyTrnSum = System.Convert.ToDouble(rs["ACCTRNSUM"]);
                        }
                        if (rs["NOTETYPE"] != System.DBNull.Value)
                        {
                            objBudgetDoc.NoteTypeID = (System.Guid)rs["NOTETYPE"];
                        }
                        if (rs["USERCOMMENT"] != System.DBNull.Value)
                        {
                            objBudgetDoc.UserComment = (System.String)rs["USERCOMMENT"];
                        }
                        objBudgetDoc.Objective = (System.String)rs["BUDGETDOC_OBJECTIVE"];
                        objBudgetDoc.PaymentDate = (System.DateTime)rs["BUDGETDOC_PAYMENTDATE"];
                        objBudgetDoc.Recipient = (System.String)rs["BUDGETDOC_RECIPIENT"];
                        objBudgetDoc.DocBasis = (System.String)rs["BUDGETDOC_DOCBASIS"];
                        if (rs["DATESTATE"] != System.DBNull.Value)
                        {
                            objBudgetDoc.DateState = (System.DateTime)rs["DATESTATE"];
                        }
                        if (rs["BUDGETDOC_DESCRIPTION"] != System.DBNull.Value)
                        {
                            objBudgetDoc.Description = (System.String)rs["BUDGETDOC_DESCRIPTION"];
                        }
                        objBudgetDoc.IsActive = (System.Boolean)rs["BUDGETDOC_ACTIVE"];
                        // ��������� �������������
                        objBudgetDoc.BudgetDep = new ERP_Budget.Common.CBudgetDep((System.Guid)rs["BUDGETDEP_GUID_ID"], (System.String)rs["BUDGETDEP_NAME"]);
                        // ����� �������
                        objBudgetDoc.PaymentType = new ERP_Budget.Common.CPaymentType((System.Guid)rs["PAYMENTTYPE_GUID_ID"], (System.String)rs["PAYMENTTYPE_NAME"]);
                        // ������� ���������
                        if (rs["MEASURE_GUID_ID"] != System.DBNull.Value)
                        {
                            objBudgetDoc.Measure = new ERP_Budget.Common.CMeasure((System.Guid)rs["MEASURE_GUID_ID"], (System.String)rs["MEASURE_NAME"]);
                        }
                        //������ �������
                        ERP_Budget.Common.CBudgetItem objBudgetItem = new ERP_Budget.Common.CBudgetItem();
                        objBudgetItem.uuidID = (System.Guid)rs["BUDGETITEM_GUID_ID"];
                        objBudgetItem.BudgetItemNum = (System.String)rs["BUDGETITEM_NUM"];
                        objBudgetItem.Name = (System.String)rs["BUDGETITEM_NAME"];
                        objBudgetItem.MoneyInBudgetDocCurrency = objBudgetDoc.Money;
                        objBudgetItem.MoneyInBudgetCurrency = objBudgetDoc.MoneyAgree;
                        if (rs["DEBITARTICLE_GUID_ID"] != System.DBNull.Value)
                        {
                            objBudgetItem.DebitArticleID = (System.Guid)rs["DEBITARTICLE_GUID_ID"];
                        }
                        if (rs["BUDGETEXPENSETYPE_GUID"] != System.DBNull.Value)
                        {
                            objBudgetItem.BudgetExpenseType = new ERP_Budget.Common.CBudgetExpenseType((System.Guid)rs["BUDGETEXPENSETYPE_GUID"],
                            (System.String)rs["BUDGETEXPENSETYPE_NAME"], "");
                        }

                        objBudgetDoc.BudgetItem = objBudgetItem;
                        objBudgetDoc.Division = (System.Boolean)rs["DIVISION"];

                        // ������
                        objBudgetDoc.Currency = new ERP_Budget.Common.CCurrency((System.Guid)rs["CURRENCY_GUID_ID"], (System.String)rs["CURRENCY_CODE"], (System.String)rs["CURRENCY_CODE"]);
                        // ��������
                        objBudgetDoc.Company = new ERP_Budget.Common.CCompany((System.Guid)rs["COMPANY_GUID_ID"], (System.String)rs["COMPANY_NAME"], (System.String)rs["COMPANY_ACRONYM"]);
                        // ��������� ���������
                        objBudgetDoc.DocState = new ERP_Budget.Common.CBudgetDocState((System.Guid)rs["BUDGETDOCSTATE_GUID_ID"], (System.String)rs["BUDGETDOCSTATE_NAME"], (System.Int32)rs["BUDGETDOCSTATE_ID"]);
                        // ��� ���������
                        objBudgetDoc.DocType = new ERP_Budget.Common.CBudgetDocType((System.Guid)rs["BUDGETDOCTYPE_GUID_ID"], (System.String)rs["BUDGETDOCTYPE_NAME"]);
                        // ���������
                        objBudgetDoc.OwnerUser = new ERP_Budget.Common.CUser((System.Int32)rs["CREATEDUSER_ID"], (System.Int32)rs["UNIXPUSER_ID"], (System.String)rs["USER_LASTNAME"], (System.String)rs["USER_FIRSTNAME"]);
                        // ������ ���������
                        objBudgetDoc.ViewMode = (ERP_Budget.Common.enumViewMode)((System.Int32)rs["ViewTypeId"]);
                        // ��������
                        objBudgetDoc.ExistsAttach = (System.Boolean)rs["ATTACH"];

                        objList.Add(objBudgetDoc);
                    }
                }
                rs.Dispose();
                cmd.Dispose();
                DBConnection.Close();

            }
            catch (Exception ex)
            {
                DBConnection.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "LoadBudgetDocActiveFromDB\n\n����� ������: " + ex.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return objList;
        }
        /// <summary>
        /// ������ ������, � ������� ����������� ������ �������� ������
        /// </summary>
        public void StartThreadLoadBudgetDocActive()
        {
            try
            {
                // �������������� ��������
                m_LoadBudgetDocActiveDelegate = null;
                m_LoadBudgetDocActiveDelegate = new LoadBudgetDocActiveDelegate(LoadBudgetDocActiveInGrid);

                DisplayStatus(strRefreshingDocList);

                // ������� ������ � ��������� ������
                dsBudgetDoc.Tables["dtDocWork"].Rows.Clear();
                dsBudgetDoc.Tables["dtDocWorked"].Rows.Clear();

                m_objBudgetDocList.Clear();

                gridDocWork.RefreshDataSource();
                gridDocWorked.RefreshDataSource();

                tabPageDocWork.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                tabPageDocWork.Text = ( strtabWorkName + strDots);
                tabPageDocWork.Refresh();

                tabPageDocWorked.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                tabPageDocWorked.Text = (strtabWorkedName + strDots);
                tabPageDocWorked.Refresh();

                // ������ ������
                this.thrRefreshBudgetDocActive = new System.Threading.Thread(LoadBudgetDocActiveInThread);
                this.thrRefreshBudgetDocActive.Start();

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("StartThreadLoadBudgetDocActive().\n\n����� ������: " + f.Message, "������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// �����, �������������� � ������ "�������� ������"
        /// </summary>
        public void LoadBudgetDocActiveInThread()
        {
            try
            {
                List<ERP_Budget.Common.CBudgetDoc> objBudgetDocList = LoadBudgetDocActiveFromDB();

                List<ERP_Budget.Common.CBudgetDoc> objAddBudgetDocList = new List<ERP_Budget.Common.CBudgetDoc>();
                if ((objBudgetDocList != null) && (objBudgetDocList.Count > 0))
                {
                    System.Int32 iRecCount = 0;
                    System.Int32 iRecAllCount = 0;
                    foreach (ERP_Budget.Common.CBudgetDoc objBudgetDoc in objBudgetDocList)
                    {
                        objAddBudgetDocList.Add(objBudgetDoc);
                        iRecCount++;
                        iRecAllCount++;

                        if (iRecCount == 1000)
                        {
                            iRecCount = 0;
                            Thread.Sleep(1000);
                            this.Invoke(m_LoadBudgetDocActiveDelegate, new Object[] { objAddBudgetDocList, iRecAllCount });
                            objAddBudgetDocList.Clear();
                        }

                    }
                    if (iRecCount != 1000)
                    {
                        iRecCount = 0;
                        this.Invoke(m_LoadBudgetDocActiveDelegate, new Object[] { objAddBudgetDocList, iRecAllCount });
                        objAddBudgetDocList.Clear();
                    }

                }

                objBudgetDocList = null;
                objAddBudgetDocList = null;
                this.Invoke(m_LoadBudgetDocActiveDelegate, new Object[] { null, 0 });
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadBudgetDocActiveInThread.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// ��������� � ������� �������� ������ ������, ���������� �� ���������
        /// </summary>
        /// <param name="objBudgetDocList">������ �������� "������"</param>
        /// <param name="iRowCountInList">����� ���������� �������, ���������� �� ��</param>
        private void LoadBudgetDocActiveInGrid(List<ERP_Budget.Common.CBudgetDoc> objBudgetDocList, System.Int32 iRowCountInList)
        {
            try
            {
                if ((objBudgetDocList != null) && (objBudgetDocList.Count > 0) && ( ( this.gridViewDocWork.RowCount + this.gridViewDocWorked.RowCount ) < iRowCountInList))
                {
                    m_objBudgetDocList.AddRange(objBudgetDocList);

                    System.Data.DataRow row = null;
                    System.String strTableName = "";
                    System.String strPrx = "";

                    foreach (ERP_Budget.Common.CBudgetDoc objBudgetDoc in objBudgetDocList)
                    {

                        switch (objBudgetDoc.ViewMode)
                        {
                            case ERP_Budget.Common.enumViewMode.Work:
                                {
                                    strTableName = dsBudgetDoc.Tables["dtDocWork"].TableName;
                                    strPrx = PrefixWork;
                                    break;
                                }
                            case ERP_Budget.Common.enumViewMode.Worked:
                                {
                                    strTableName = dsBudgetDoc.Tables["dtDocWorked"].TableName;
                                    strPrx = PrefixWorked;
                                    break;
                                }
                            case ERP_Budget.Common.enumViewMode.Arj:
                                {
                                    strTableName = dsBudgetDoc.Tables["dtDocNotActive"].TableName;
                                    strPrx = PrefixNotActive;
                                    break;
                                }
                            case ERP_Budget.Common.enumViewMode.Err:
                                {
                                    strTableName = dsBudgetDoc.Tables["dtDocError"].TableName;
                                    strPrx = PrefixError;
                                    break;
                                }
                            default:
                                {
                                    strTableName = "";
                                    strPrx = "";
                                    break;
                                }
                        }
                        
                        row = dsBudgetDoc.Tables[strTableName].NewRow();
                        row[strPrx + "BUDGETDOC_GUID_ID"] = objBudgetDoc.uuidID;
                        row[strPrx + "CREATEDUSER_NAME"] = String.Format("{0} {1}", objBudgetDoc.OwnerUser.UserLastName, objBudgetDoc.OwnerUser.UserFirstName);
                        row[strPrx + "DOCDATE"] = objBudgetDoc.Date;
                        row[strPrx + "BUDGETDEP_NAME"] = objBudgetDoc.BudgetDep.Name;
                        row[strPrx + "DOCOBJECTIVE"] = objBudgetDoc.Objective;
                        row[strPrx + "DOCMONEY"] = objBudgetDoc.Money;
                        row[strPrx + "DOCMONEYAGREE"] = objBudgetDoc.MoneyAgree;
                        row[strPrx + "ACCTRNSUM"] = objBudgetDoc.MoneyTrnSum;
                        row[strPrx + "DEBITARTICLE_NAME"] = objBudgetDoc.BudgetItem.BudgetItemFullName;
                        row[strPrx + "COMPANY_NAME"] = objBudgetDoc.Company.CompanyAcronym;
                        row[strPrx + "BUDGETDOCSTATE_NAME"] = objBudgetDoc.DocState.Name;
                        row[strPrx + "BUDGETDOCTYPE_NAME"] = objBudgetDoc.DocType.Name;
                        row[strPrx + "IMAGE_ID"] = objBudgetDoc.DocState.OrderNum;
                        row[strPrx + "IMAGETYPE_ID"] = (objBudgetDoc.DocType.Name == "������") ? 0 : 1;
                        row[strPrx + "DOCACTIVE"] = objBudgetDoc.IsActive;
                        row[strPrx + "RECIPIENT"] = objBudgetDoc.Recipient;
                        row[strPrx + "DATESTATE"] = objBudgetDoc.DateState;
                        row[strPrx + "ATTACH"] = objBudgetDoc.ExistsAttach;
                        row[strPrx + "CURRENCY"] = objBudgetDoc.Currency.CurrencyCode;
                        row[strPrx + "NOTETYPE"] = objBudgetDoc.NoteTypeID;
                        row[strPrx + "NOTETYPE_PREV"] = objBudgetDoc.NoteTypeID;
                        row[strPrx + "USERCOMMENT"] = objBudgetDoc.UserComment;
                        row[strPrx + "PAYMENTTYPE_NAME"] = objBudgetDoc.PaymentType.Name;
                        row[strPrx + "BUDGETEXPENSETYPE_NAME"] = ((objBudgetDoc.BudgetItem.BudgetExpenseType == null) ? "" : objBudgetDoc.BudgetItem.BudgetExpenseType.Name);
                        dsBudgetDoc.Tables[strTableName].Rows.Add(row);
                    }
                    dsBudgetDoc.AcceptChanges();

                    if ( gridDocWork.DataSource == null)
                    {
                        gridDocWork.DataSource = dsBudgetDoc;
                    }
                    gridDocWork.RefreshDataSource();

                    if ( gridDocWorked.DataSource == null)
                    {
                        gridDocWorked.DataSource = dsBudgetDoc;
                    }
                    gridDocWorked.RefreshDataSource();
                }
                else
                {
                    Thread.Sleep(1000);

                    tabPageDocWork.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_new;
                    tabPageDocWork.Text = String.Format("{0} ({1})", strtabWorkName, dsBudgetDoc.Tables["dtDocWork"].Rows.Count);
                    tabPageDocWork.Refresh();

                    tabPageDocWorked.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_preferences;
                    tabPageDocWorked.Text = String.Format("{0} ({1})", strtabWorkedName, dsBudgetDoc.Tables["dtDocWorked"].Rows.Count);
                    tabPageDocWorked.Refresh();
                    
                    DisplayStatus(strEndRefresh);

                    gridDocWork.Enabled = (dsBudgetDoc.Tables["dtDocWork"].Rows.Count > 0);
                    gridDocWorked.Enabled = (dsBudgetDoc.Tables["dtDocWorked"].Rows.Count > 0);

                    Cursor = Cursors.Default;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadBudgetDocActiveInGrid.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        #endregion


        /// <summary>
        /// ��������� ������ � ����������� � ��������� ��������� � ����� ������
        /// </summary>
        private void AppendRowInDS(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            try
            {
                if (objBudgetDoc == null) { return; }
                System.String strTableName = "";
                System.String strPrx = "";

                switch (objBudgetDoc.ViewMode)
                {
                    case ERP_Budget.Common.enumViewMode.Work:
                        {
                            strTableName = dsBudgetDoc.Tables["dtDocWork"].TableName;
                            strPrx = PrefixWork;
                            break;
                        }
                    case ERP_Budget.Common.enumViewMode.Worked:
                        {
                            strTableName = dsBudgetDoc.Tables["dtDocWorked"].TableName;
                            strPrx = PrefixWorked;
                            break;
                        }
                    case ERP_Budget.Common.enumViewMode.Arj:
                        {
                            strTableName = dsBudgetDoc.Tables["dtDocNotActive"].TableName;
                            strPrx = PrefixNotActive;
                            break;
                        }
                    case ERP_Budget.Common.enumViewMode.Err:
                        {
                            strTableName = dsBudgetDoc.Tables["dtDocError"].TableName;
                            strPrx = PrefixError;
                            break;
                        }
                    default:
                        {
                            strTableName = "";
                            strPrx = "";
                            break;
                        }
                }
                if (strTableName != "")
                {
                    System.Data.DataRow row = dsBudgetDoc.Tables[strTableName].NewRow();
                    row[strPrx + "BUDGETDOC_GUID_ID"] = objBudgetDoc.uuidID; // BUDGETDOC_GUID_ID
                    row[strPrx + "CREATEDUSER_NAME"] = objBudgetDoc.OwnerUser.UserLastName + " " + objBudgetDoc.OwnerUser.UserFirstName;
                    row[strPrx + "DOCDATE"] = objBudgetDoc.Date;
                    row[strPrx + "BUDGETDEP_NAME"] = objBudgetDoc.BudgetDep.Name;
                    row[strPrx + "DOCOBJECTIVE"] = objBudgetDoc.Objective;
                    row[strPrx + "DOCMONEY"] = objBudgetDoc.Money; // DOCMONEY
                    row[strPrx + "DOCMONEYAGREE"] = objBudgetDoc.MoneyAgree; // DOCMONEYAGREE
                    row[strPrx + "ACCTRNSUM"] = objBudgetDoc.MoneyTrnSum; // ACCTRNSUM
                    row[strPrx + "DEBITARTICLE_NAME"] = objBudgetDoc.BudgetItem.BudgetItemFullName;
                    row[strPrx + "COMPANY_NAME"] = objBudgetDoc.Company.CompanyAcronym; // COMPANY_NAME
                    row[strPrx + "BUDGETDOCSTATE_NAME"] = objBudgetDoc.DocState.Name; // BUDGETDOCSTATE_NAME
                    row[strPrx + "BUDGETDOCTYPE_NAME"] = objBudgetDoc.DocType.Name; // BUDGETDOCTYPE_NAME
                    row[strPrx + "IMAGE_ID"] = objBudgetDoc.DocState.OrderNum; // IMAGE_ID
                    row[strPrx + "IMAGETYPE_ID"] = (objBudgetDoc.DocType.Name == "������") ? 0 : 1; // IMAGETYPE_ID
                    row[strPrx + "DOCACTIVE"] = objBudgetDoc.IsActive; // DOCACTIVE
                    row[strPrx + "RECIPIENT"] = objBudgetDoc.Recipient;
                    row[strPrx + "DATESTATE"] = objBudgetDoc.DateState; // objBudgetDoc.DateState.ToShortDateString() + " " + objBudgetDoc.DateState.ToShortTimeString();
                    row[strPrx + "ATTACH"] = objBudgetDoc.ExistsAttach; // objBudgetDoc.DateState.ToShortDateString() + " " + objBudgetDoc.DateState.ToShortTimeString();
                    row[strPrx + "CURRENCY"] = objBudgetDoc.Currency.CurrencyCode; // objBudgetDoc.DateState.ToShortDateString() + " " + objBudgetDoc.DateState.ToShortTimeString();
                    row[strPrx + "NOTETYPE"] = objBudgetDoc.NoteTypeID;
                    row[strPrx + "NOTETYPE_PREV"] = objBudgetDoc.NoteTypeID;
                    row[strPrx + "USERCOMMENT"] = objBudgetDoc.UserComment;
                    row[strPrx + "PAYMENTTYPE_NAME"] = objBudgetDoc.PaymentType.Name;
                    row[strPrx + "BUDGETEXPENSETYPE_NAME"] = (objBudgetDoc.BudgetItem.BudgetExpenseType == null) ? "" : objBudgetDoc.BudgetItem.BudgetExpenseType.Name;
                    dsBudgetDoc.Tables[strTableName].Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ ���������� ������ � �������.\nAppendRowInDS\n\n����� ������: " + ex.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        /// <summary>
        /// ��������� ������ ������ (��� ������ "Outlook")
        /// </summary>
        /// <returns>true - �������� ����������; false - ������</returns>
        public void LoadBudgetDocListForOutlook()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Refresh();
            System.Boolean bRet = false;
            try
            {
                m_IsRefreshBudgetDocList = true;
                barBtnRefres.Enabled = false;
                btnRefresh.Enabled = false;
                barBtnRefres.Refresh();
                btnRefresh.Refresh();
                // ������� ������ � ��������� ������
                dsBudgetDoc.Tables["dtDocWork"].Rows.Clear();
                dsBudgetDoc.Tables["dtDocWorked"].Rows.Clear();
                dsBudgetDoc.Tables["dtDocNotActive"].Rows.Clear();
                dsBudgetDoc.Tables["dtDocError"].Rows.Clear();
                // ��������� �����
                gridDocWork.Enabled = false;
                gridDocWorked.Enabled = false;
                gridDocNotActive.Enabled = false;
                gridDocErr.Enabled = false;

                // ���������� �������� "��������"
                tabPageDocWork.Text = "���� ���������� ������ ������...";
                tabPageDocWorked.Text = "���� ���������� ������ ������...";
                tabPageDocNotActive.Text = "���� ���������� ������ ������...";

                tabPageDocWork.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                tabPageDocWorked.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                tabPageDocNotActive.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                TabControlDocList.Refresh();
                // ����������� ������ ������
                m_objBudgetDocList.Clear();
                m_objBudjetDocArjList.Clear();
                ERP_Budget.Common.CBudgetDoc.ReloadBudgetDocList(m_objProfile,
                    m_objBudgetDocList, m_objBudjetDocArjList, dtBeginDate.DateTime, (dtEndDate.DateTime.AddDays(1)));
                // ������ ����� ��������� ������ ������

                for (System.Int32 i = 0; i < m_objBudgetDocList.Count; i++)
                {
                    // ��������� ������ � ����� ������
                    AppendRowInDS(m_objBudgetDocList[i]);
                }
                for (System.Int32 i2 = 0; i2 < m_objBudjetDocArjList.Count; i2++)
                {
                    // ��������� ������ � ����� ������
                    AppendRowInDS(m_objBudjetDocArjList[i2]);
                }
                dsBudgetDoc.AcceptChanges();
                bRet = true;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ �������� �������� ������.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
                gridDocWork.Enabled = (dsBudgetDoc.Tables["dtDocWork"].Rows.Count > 0);
                gridDocWorked.Enabled = (dsBudgetDoc.Tables["dtDocWorked"].Rows.Count > 0);
                gridDocNotActive.Enabled = (dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count > 0);
                gridDocErr.Enabled = (dsBudgetDoc.Tables["dtDocError"].Rows.Count > 0);

                tabPageError.PageVisible = (dsBudgetDoc.Tables["dtDocError"].Rows.Count > 0);

                // ���������� �������� � ������������ ���������� ������
                tabPageDocWork.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_new;
                tabPageDocWorked.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_preferences;
                tabPageDocNotActive.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_lock;

                tabPageDocWork.Text = strtabWorkName + " (" + dsBudgetDoc.Tables["dtDocWork"].Rows.Count.ToString() + ")";
                tabPageDocWorked.Text = strtabWorkedName + " (" + dsBudgetDoc.Tables["dtDocWorked"].Rows.Count.ToString() + ")";
                tabPageDocNotActive.Text = strtabNotActiveName + " (" + dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count.ToString() + ")";

                barBtnRefres.Enabled = true;
                btnRefresh.Enabled = true;
                m_IsRefreshBudgetDocList = false;
                if ((bRet == true) && (m_bOutlookMode == true))
                {
                    SaveFindParams();
                }
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return ;
        }

        private void barBtnRefres_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RefreshClick();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ���������� ������ ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void mitemRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshClick();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ���������� ������ ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void RefreshClick()
        {
            try
            {
                if (this.m_bOutlookMode == true)
                {
                    LoadBudgetDocListForOutlook();
                }
                else
                {
                    if (TabControlDocList.TabPages.Count > 0)
                    {
                        if ((TabControlDocList.SelectedTabPage == tabPageDocWork) || (TabControlDocList.SelectedTabPage == tabPageDocWorked))
                        {
                            if ((this.thrRefreshBudgetDocActive != null) && (this.thrRefreshBudgetDocActive.IsAlive)) { return; }
                            //StartThreadRefreshBudgetDocActive();

                            StartThreadLoadBudgetDocActive();

                        }
                        else
                        {
                            if ((TabControlDocList.SelectedTabPage == tabPageDocNotActive) || (TabControlDocList.SelectedTabPage == tabPageError))
                            {
                                if ((this.thrRefreshBudgetDocArj != null) && (this.thrRefreshBudgetDocArj.IsAlive)) { return; }
                                //StartThreadRefreshBudgetDocArj();

                                StartThreadLoadBudgetDocArjive();
                            }
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ���������� ������ ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region ������ ������ (Outlook) � ����������� ������
        // You need this delegate in order to fill the grid from
        // a thread other than the form's thread. See the HandleCallback
        // procedure for more information.
        private delegate void FillGridsDelegate(System.Data.SqlClient.SqlDataReader reader);
        // You need this delegate to update the status bar.
        private delegate void DisplayStatusDelegate(string Text);
        private void DisplayStatus(string strText)
        {
            if (lblStatusBar.Caption == "")
            {
                lblStatusBar.Caption = strText;
            }
            else
            {
                if ((strText != strEndRefresh) && (lblStatusBar.Caption == strEndRefresh))
                {
                    // � statusbar  �������� "������", � Text ����������
                    lblStatusBar.Caption = strText;
                }
                else
                {
                    if (strText == strEndRefresh)
                    {
                        lblStatusBar.Caption = strText;
                    }
                }
            }
        }
        private void FillBudgetDocGrids(SqlDataReader rs)
        {
            if ((rs == null) || (rs.HasRows == false)) { return; }
            System.Boolean bRet = false;
            try
            {
                // ����� ������ ��������
                ERP_Budget.Common.CBudgetDoc objBudgetDoc = null;
                while (rs.Read())
                {
                    objBudgetDoc = new ERP_Budget.Common.CBudgetDoc();

                    objBudgetDoc.uuidID = (System.Guid)rs["GUID_ID"];
                    objBudgetDoc.Date = (System.DateTime)rs["BUDGETDOC_DATE"];
                    objBudgetDoc.Money = System.Convert.ToDouble(rs["BUDGETDOC_MONEY"]);
                    objBudgetDoc.MoneyAgree = System.Convert.ToDouble(rs["BUDGETDOC_MONEYAGREE"]);
                    if (rs["ACCTRNSUM"] != System.DBNull.Value)
                    {
                        objBudgetDoc.MoneyTrnSum = System.Convert.ToDouble(rs["ACCTRNSUM"]);
                    }
                    objBudgetDoc.Objective = (System.String)rs["BUDGETDOC_OBJECTIVE"];
                    objBudgetDoc.PaymentDate = (System.DateTime)rs["BUDGETDOC_PAYMENTDATE"];
                    objBudgetDoc.Recipient = (System.String)rs["BUDGETDOC_RECIPIENT"];
                    objBudgetDoc.DocBasis = (System.String)rs["BUDGETDOC_DOCBASIS"];
                    if (rs["DATESTATE"] != System.DBNull.Value)
                    {
                        objBudgetDoc.DateState = (System.DateTime)rs["DATESTATE"];
                    }
                    if (rs["BUDGETDOC_DESCRIPTION"] != System.DBNull.Value)
                    {
                        objBudgetDoc.Description = (System.String)rs["BUDGETDOC_DESCRIPTION"];
                    }
                    objBudgetDoc.IsActive = (System.Boolean)rs["BUDGETDOC_ACTIVE"];
                    // ��������� �������������
                    objBudgetDoc.BudgetDep = new ERP_Budget.Common.CBudgetDep((System.Guid)rs["BUDGETDEP_GUID_ID"], (System.String)rs["BUDGETDEP_NAME"]);
                    // ����� �������
                    objBudgetDoc.PaymentType = new ERP_Budget.Common.CPaymentType((System.Guid)rs["PAYMENTTYPE_GUID_ID"], (System.String)rs["PAYMENTTYPE_NAME"]);
                    // ������� ���������
                    if (rs["MEASURE_GUID_ID"] != System.DBNull.Value)
                    {
                        objBudgetDoc.Measure = new ERP_Budget.Common.CMeasure((System.Guid)rs["MEASURE_GUID_ID"], (System.String)rs["MEASURE_NAME"]);
                    }
                    //������ �������
                    ERP_Budget.Common.CBudgetItem objBudgetItem = new ERP_Budget.Common.CBudgetItem();
                    objBudgetItem.uuidID = (System.Guid)rs["BUDGETITEM_GUID_ID"];
                    objBudgetItem.BudgetItemNum = (System.String)rs["BUDGETITEM_NUM"];
                    objBudgetItem.Name = (System.String)rs["BUDGETITEM_NAME"];
                    objBudgetItem.MoneyInBudgetDocCurrency = objBudgetDoc.Money;
                    objBudgetItem.MoneyInBudgetCurrency = objBudgetDoc.MoneyAgree;
                    if (rs["DEBITARTICLE_GUID_ID"] != System.DBNull.Value)
                    {
                        objBudgetItem.DebitArticleID = (System.Guid)rs["DEBITARTICLE_GUID_ID"];
                    }
                    objBudgetDoc.BudgetItem = objBudgetItem;

                    // ������
                    objBudgetDoc.Currency = new ERP_Budget.Common.CCurrency((System.Guid)rs["CURRENCY_GUID_ID"], (System.String)rs["CURRENCY_CODE"], (System.String)rs["CURRENCY_CODE"]);
                    // ��������
                    objBudgetDoc.Company = new ERP_Budget.Common.CCompany((System.Guid)rs["COMPANY_GUID_ID"], (System.String)rs["COMPANY_NAME"], (System.String)rs["COMPANY_ACRONYM"]);
                    // ��������� ���������
                    objBudgetDoc.DocState = new ERP_Budget.Common.CBudgetDocState((System.Guid)rs["BUDGETDOCSTATE_GUID_ID"], (System.String)rs["BUDGETDOCSTATE_NAME"], (System.Int32)rs["BUDGETDOCSTATE_ID"]);
                    // ��� ���������
                    objBudgetDoc.DocType = new ERP_Budget.Common.CBudgetDocType((System.Guid)rs["BUDGETDOCTYPE_GUID_ID"], (System.String)rs["BUDGETDOCTYPE_NAME"]);
                    // ���������
                    objBudgetDoc.OwnerUser = new ERP_Budget.Common.CUser((System.Int32)rs["CREATEDUSER_ID"], (System.Int32)rs["UNIXPUSER_ID"], (System.String)rs["USER_LASTNAME"], (System.String)rs["USER_FIRSTNAME"]);
                    // ������ ���������
                    objBudgetDoc.ViewMode = (ERP_Budget.Common.enumViewMode)((System.Int32)rs["ViewTypeId"]);
                    // ��������
                    objBudgetDoc.ExistsAttach = (System.Boolean)rs["ATTACH"];
                    if (objBudgetDoc.IsActive == true)
                    {
                        if (objBudgetDoc.ViewMode != ERP_Budget.Common.enumViewMode.Err)
                        {
                            m_objBudgetDocList.Add(objBudgetDoc);
                        }
                        else
                        {
                            m_objBudjetDocArjList.Add(objBudgetDoc);
                        }
                    }
                    else
                    {
                        m_objBudjetDocArjList.Add(objBudgetDoc);
                    }
                    // �� �������
                    if (rs["NOTETYPE"] != System.DBNull.Value)
                    {
                        objBudgetDoc.NoteTypeID = (System.Guid)rs["NOTETYPE"];
                    }
                    // ����������� ������������
                    if (rs["USERCOMMENT"] != System.DBNull.Value)
                    {
                        objBudgetDoc.UserComment = (System.String)rs["USERCOMMENT"];
                    }
                    // ��������� ������ � ����� ������
                    AppendRowInDS(objBudgetDoc);

                }
                objBudgetDoc = null;
                dsBudgetDoc.AcceptChanges();

                DisplayStatus("������");
                bRet = true;
            }
            catch (Exception ex)
            {
                DisplayStatus(string.Format("Ready (last attempt failed: {0})", ex.Message));
            }
            finally
            {
                // Closing the reader also closes the connection,
                // because this reader was created using the 
                // CommandBehavior.CloseConnection value.
                if (rs != null)
                {
                    rs.Close();
                }
                gridDocWork.Enabled = (dsBudgetDoc.Tables["dtDocWork"].Rows.Count > 0);
                gridDocWorked.Enabled = (dsBudgetDoc.Tables["dtDocWorked"].Rows.Count > 0);
                gridDocNotActive.Enabled = (dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count > 0);
                gridDocErr.Enabled = (dsBudgetDoc.Tables["dtDocError"].Rows.Count > 0);

                tabPageError.PageVisible = (dsBudgetDoc.Tables["dtDocError"].Rows.Count > 0);

                // ���������� �������� � ������������ ���������� ������
                tabPageDocWork.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_new;
                tabPageDocWorked.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_preferences;
                tabPageDocNotActive.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_lock;

                tabPageDocWork.Text = strtabWorkName + " (" + dsBudgetDoc.Tables["dtDocWork"].Rows.Count.ToString() + ")";
                tabPageDocWorked.Text = strtabWorkedName + " (" + dsBudgetDoc.Tables["dtDocWorked"].Rows.Count.ToString() + ")";
                tabPageDocNotActive.Text = strtabNotActiveName + " (" + dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count.ToString() + ")";

                barBtnRefres.Enabled = true;
                btnRefresh.Enabled = true;
                m_IsRefreshBudgetDocList = false;
                if ((bRet == true) && (m_bOutlookMode == true))
                {
                    SaveFindParams();
                }
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void HandleCallback(IAsyncResult result)
        {
            try
            {
                // Retrieve the original command object, passed
                // to this procedure in the AsyncState property
                // of the IAsyncResult parameter.
                System.Data.SqlClient.SqlCommand command = (SqlCommand)result.AsyncState;
                SqlDataReader reader = command.EndExecuteReader(result);
                // You may not interact with the form and its contents
                // from a different thread, and this callback procedure
                // is all but guaranteed to be running from a different thread
                // than the form. Therefore you cannot simply call code that 
                // fills the grid, like this:
                // FillGrid(reader);
                // Instead, you must call the procedure from the form's thread.
                // One simple way to accomplish this is to call the Invoke
                // method of the form, which calls the delegate you supply
                // from the form's thread. 

                FillGridsDelegate del = new FillGridsDelegate(FillBudgetDocGrids);

                DevExpress.XtraEditors.XtraMessageBox.Show("m_bOutlookMode : 8 ", "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                this.Invoke(del, reader);
                // Do not close the reader here, because it is being used in 
                // a separate thread. Instead, have the procedure you have
                // called close the reader once it is done with it.
            }
            catch (Exception ex)
            {
                this.Invoke(new DisplayStatusDelegate(DisplayStatus), "Error: " + ex.Message);
            }
            finally
            {
                m_IsRefreshBudgetDocList = false;
            }
        }
        /// <summary>
        /// ��������� ������ ������ (��� ������ "Outlook")
        /// </summary>
        /// <returns>true - �������� ����������; false - ������</returns>
        public void LoadBudgetDocListAsync()
        {
            if (m_IsRefreshBudgetDocList == true) { return; }
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            DisplayStatus("���� ������ ������ ������, ��������...");

            this.Refresh();
            try
            {
                m_IsRefreshBudgetDocList = true;
                barBtnRefres.Enabled = false;
                btnRefresh.Enabled = false;
                barBtnRefres.Refresh();
                btnRefresh.Refresh();
                // ������� ������ � ��������� ������
                dsBudgetDoc.Tables["dtDocWork"].Rows.Clear();
                dsBudgetDoc.Tables["dtDocWorked"].Rows.Clear();
                dsBudgetDoc.Tables["dtDocNotActive"].Rows.Clear();
                dsBudgetDoc.Tables["dtDocError"].Rows.Clear();
                // ��������� �����
                gridDocWork.Enabled = false;
                gridDocWorked.Enabled = false;
                gridDocNotActive.Enabled = false;
                gridDocErr.Enabled = false;

                // ���������� �������� "��������"
                tabPageDocWork.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                tabPageDocWorked.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                tabPageDocNotActive.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                TabControlDocList.Refresh();
                // ����������� ������ ������
                if (m_objBudgetDocList == null)
                {
                    m_objBudgetDocList = new List<ERP_Budget.Common.CBudgetDoc>();
                }
                if (m_objBudjetDocArjList == null)
                {
                    m_objBudjetDocArjList = new List<ERP_Budget.Common.CBudgetDoc>();
                }
                m_objBudgetDocList.Clear();
                m_objBudjetDocArjList.Clear();

                System.Data.SqlClient.SqlConnection DBConnection = m_objProfile.GetDBSourceAsynch();
                if (DBConnection == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "�� ������� ���������� ���������� � ����� ������.", "��������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandTimeout = iCommandTimeout;
                cmd.Connection = DBConnection;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = System.String.Format("[{0}].[dbo].[sp_GetBudgetDocList]", m_objProfile.GetOptionsDllDBName());
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ulUniXPID", System.Data.SqlDbType.Int));
                if (dtBeginDate.DateTime != null)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BEGINDATE", System.Data.SqlDbType.DateTime));
                    cmd.Parameters["@BEGINDATE"].Value = dtBeginDate.DateTime;
                }
                if (dtEndDate.DateTime != null)
                {
                    cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ENDDATE", System.Data.SqlDbType.DateTime));
                    cmd.Parameters["@ENDDATE"].Value = dtEndDate.DateTime.AddDays(1);
                }
                cmd.Parameters["@ulUniXPID"].Value = m_objProfile.m_nSQLUserID;
                AsyncCallback callback = new AsyncCallback(HandleCallback);
                cmd.BeginExecuteReader(callback, cmd, System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ �������� �������� ������.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }
        #endregion

        #region �������� �����
        private void frmBudgetDocList_Load(object sender, EventArgs e)
        {
            try
            {
                frmBudgetDocList_Load();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ �������� �����.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }
        public void frmBudgetDocList_Load()
        {
            try
            {
                m_objNoteTypeList = ERP_Budget.Common.CNoteType.GetNoteTypeList(m_objProfile);
                if ((m_objNoteTypeList != null) && (m_objNoteTypeList.Count > 0))
                {
                    contextMenuNoteType.Items.Clear();
                    foreach (ERP_Budget.Common.CNoteType objNoteType in m_objNoteTypeList)
                    {
                        System.Windows.Forms.ToolStripMenuItem mitem = new System.Windows.Forms.ToolStripMenuItem() { Text = objNoteType.Name, Image = objNoteType.ImageSmall, Tag = objNoteType };
                        contextMenuNoteType.Items.Add(mitem);
                        mitem.Click += new System.EventHandler(this.mitemNoteType_Click);
                    }
                    contextMenuNoteType.Items.Add(new System.Windows.Forms.ToolStripSeparator());
                    System.Windows.Forms.ToolStripMenuItem mitemClear = new System.Windows.Forms.ToolStripMenuItem() { Text = "������� �������", Name = "mitemClear", Tag = null };
                    mitemClear.Click += new System.EventHandler(this.mitemNoteType_Click);
                    contextMenuNoteType.Items.Add(mitemClear);
                }

                radioGroupDateType.Visible = (m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRInspector) ||
                    m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRAccountant) ||
                    m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRCashier));

                RestoreLayoutFromRegistry();

                LoadFindParams();

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "frmBudgetDocList_Load.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }

        private void frmBudgetDocList_Shown(object sender, EventArgs e)
        {
            try
            {
                // ������������� �������� ��� ������ ��������� � ������
                m_SendMessageToLogDelegate = new SendMessageToLogDelegate(SendMessageToLog);

                // ������ ������ �� �������� ����������, �������� �� ����� ��������
                this.ThreadInitializeVariable = new System.Threading.Thread(InitializeVariableInThread);
                this.ThreadInitializeVariable.Start();

                // ������ ������ "������ �������� ������"
                StartThreadLoadBudgetDocActive();

                // ������ ������ "������ ���������� ������"
                StartThreadLoadBudgetDocArjive();

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "frmBudgetDocList_Shown.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
                this.Refresh();
                TabControlDocList.SelectedTabPage = tabPageDocWork;
                TabControlDocList.Refresh();
            }

            return;
        }

        #endregion

        #region �������� �����
        private void frmBudgetDocList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (timer.Enabled == true) { timer.Stop(); }

                if ((this.thrRefreshBudgetDocActive != null) && (this.thrRefreshBudgetDocActive.IsAlive))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "���� ���������� ������ ������.\n���������, ����������, ��������� ����� ��������.", "��������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                if ((this.thrRefreshBudgetDocArj != null) && (this.thrRefreshBudgetDocArj.IsAlive))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "���� ���������� ������ ������.\n���������, ����������, ����� ��������.", "��������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                SaveLayoutToRegistry();
                SaveFindParams();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ �������� �����.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }
        #endregion

        #region ����� ������
        /// <summary>
        /// ������� ����� ����� ������
        /// </summary>
        private void NewBudgetDoc()
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.Refresh();

                using (frmBudgetDocument objfrmBudgetDocument = new frmBudgetDocument( m_objProfile,
                    m_objRouteVariableList, m_objDocTypeVariableList, m_objCurrentUser, null,
                    m_objRouteTemplateList, m_objBudgetDocTypeTemplateList, m_objUserDynamicRightList))
                {
                    objfrmBudgetDocument.OpenBudgetDoc();

                    DialogResult Ret = objfrmBudgetDocument.ShowDialog();

                    if (Ret == DialogResult.OK)
                    {
                        // ��������� �����  ������ � ������
                        InsertBudgetDocInWorkedList(objfrmBudgetDocument.BudgetDoc);
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ������.\n\n����� ������ : " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return;
        }
        /// <summary>
        /// ��������� ������ � ������ "������������ ������" 
        /// </summary>
        /// <param name="objBudgetDoc">��������� ��������</param>
        private void InsertBudgetDocInWorkedList(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            try
            {
                // ����������������� ������ "��������� ��������"
                if (objBudgetDoc.Init(this.m_objProfile, objBudgetDoc.uuidID) == true)
                {
                    if (objBudgetDoc.IsActive == true)
                    {
                        // ������ �������
                        objBudgetDoc.ViewMode = ERP_Budget.Common.enumViewMode.Worked;
                        // ��������� ������ "������" � ������
                        this.m_objBudgetDocList.Add(objBudgetDoc);
                        // ��������� ������ � ����� ������
                        AppendRowInDS(objBudgetDoc);
                        // �������� �������� ������
                        gridViewDocWorked.RefreshData();
                        // ������������ ���������� ������ �� ��������
                        tabPageDocWorked.Text = strtabWorkedName + " (" + dsBudgetDoc.Tables["dtDocWorked"].Rows.Count.ToString() + ")";
                        tabPageDocWorked.Refresh();
                    }
                    gridDocWorked.Enabled = (dsBudgetDoc.Tables["dtDocWorked"].Rows.Count > 0);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ���������� ������ � ������ \"������������ ������\".\nInsertBudgetDocInWorkedList\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void barBtnNewDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                NewBudgetDoc();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ������.\n\n����� ������ : " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void mitemNewBudgetDoc_Click(object sender, EventArgs e)
        {
            try
            {
                NewBudgetDoc();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ������.\n\n����� ������ : " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }


        #endregion

        #region ������������ ������
        /// <summary>
        /// ������� ������ �� ������ ������������
        /// </summary>
        /// <param name="objBudgetDoc">���������� ������</param>
        private void CopyBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.Refresh();
                // ����������������� �������� ������
                objBudgetDoc.Init(m_objProfile, objBudgetDoc.uuidID);

                using (frmBudgetDocument objfrmBudgetDocument = new frmBudgetDocument(this.m_objProfile,
                    this.m_objRouteVariableList, this.m_objDocTypeVariableList,
                    this.m_objCurrentUser, null,
                    m_objRouteTemplateList, m_objBudgetDocTypeTemplateList, m_objUserDynamicRightList))
                {
                    objfrmBudgetDocument.CopyBudgetDoc(objBudgetDoc);
                    DialogResult dlgRes = System.Windows.Forms.DialogResult.None;

                    try
                    {
                        dlgRes = objfrmBudgetDocument.ShowDialog();
                    }
                    catch
                    {
                    }

                    if (dlgRes == DialogResult.OK)
                    {
                        // ��������� �����  ������ � ������
                        InsertBudgetDocInWorkedList(objfrmBudgetDocument.BudgetDoc);
                    }
                }

            }
            catch (System.Exception f)
            {
                SendMessageToLog("������ ����������� ������. ����� ������: " + f.Message);
                //DevExpress.XtraEditors.XtraMessageBox.Show("������ ����������� ������.\nCopyBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDoc)\n\n����� ������: " + f.Message, "������",
                //   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return;
        }

        private void CopyBudgetDoc()
        {
            try
            {
                // ���������� �����������
                CopyBudgetDoc(GetBudgetDocByID(GetBudgetDocID()));

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ����������� ������.\nCopyBudgetDoc()\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void barBtnCopyDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CopyBudgetDoc();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ����������� ������.\nbarBtnCopyDoc_ItemClick\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void mitemCopyBudgetDoc_Click(object sender, EventArgs e)
        {
            try
            {
                CopyBudgetDoc();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ����������� ������.\nmitemCopyBudgetDoc_Click\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region ������� ������
        /// <summary>
        /// �������������� ������
        /// </summary>
        private void EditBudgetDoc()
        {
            try
            {
                if (m_bBlockDblClick == true) { return; }

                System.Guid uuidBudgetDocID = GetBudgetDocID();
                if (uuidBudgetDocID.CompareTo(System.Guid.Empty) == 0) { return; }

                // ������ ������ ������ � ������
                ERP_Budget.Common.CBudgetDoc objBudgetDoc = GetBudgetDocByID(uuidBudgetDocID);
                if (objBudgetDoc == null) { return; }

                // ������ � ������ �� �����, � ���� ��� �������, �� ��������, 
                // �� ���������� �� �� ��������� �� ����� ���������� ���������� �������
                System.Guid uuidStateId = objBudgetDoc.DocState.uuidID;
                if (objBudgetDoc.IsActive == true)
                {
                    if (objBudgetDoc.Init(this.m_objProfile, objBudgetDoc.uuidID) == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("�� ������� �������� ���������� � ��������� ���������!", "������",
                          System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (uuidStateId.CompareTo(objBudgetDoc.DocState.uuidID) != 0)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("��������� ������ ���� �������� \n�� ������� ���������� ���������� �������.", "����������",
                              System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        }
                    }
                }
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                this.Refresh();
                objBudgetDoc.Init(m_objProfile, objBudgetDoc.uuidID);
                DialogResult Ret = System.Windows.Forms.DialogResult.None;

                using (frmBudgetDocument objfrmBudgetDocument = new frmBudgetDocument(this.m_objProfile,
                    this.m_objRouteVariableList, this.m_objDocTypeVariableList,
                    this.m_objCurrentUser, objBudgetDoc,
                    m_objRouteTemplateList, m_objBudgetDocTypeTemplateList, m_objUserDynamicRightList))
                {
                    objfrmBudgetDocument.OpenBudgetDoc();
                    Ret = objfrmBudgetDocument.ShowDialog();
                }

                if (Ret == DialogResult.OK)
                {
                    // � �������� ������ ���-�� ��������
                    if (objBudgetDoc.Init(this.m_objProfile, objBudgetDoc.uuidID) == true)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView SelectedGridView = GetGridViewBySelectedPage();
                        if (SelectedGridView == gridViewDocWorked)
                        {
                            System.Int32 iRowHndl = gridViewDocWorked.FocusedRowHandle;
                            if (objBudgetDoc.IsActive == true)
                            {
                                // ������ ��-�������� �������, ����� � ����� ���������� �� ��������
                                objBudgetDoc.ViewMode = ERP_Budget.Common.enumViewMode.Worked;
                                gridViewDocWorked.SetRowCellValue(iRowHndl, colB_BUDGETDOCSTATE_NAME, objBudgetDoc.DocState.Name);
                                gridViewDocWorked.SetRowCellValue(iRowHndl, colB_BUDGETDOCSTATE_GUID_ID, objBudgetDoc.DocState.uuidID);
                                gridViewDocWorked.SetRowCellValue(iRowHndl, colB_DOCOBJECTIVE, objBudgetDoc.Objective);
                                gridViewDocWorked.SetRowCellValue(iRowHndl, colC_DOCDATE, objBudgetDoc.Date);
                                gridViewDocWorked.RefreshRow(iRowHndl);
                            }
                            else
                            {
                                // ������ �������� ���� ��������� ���� � ������ �� ����� ����������� � �����
                                objBudgetDoc.ViewMode = ERP_Budget.Common.enumViewMode.Arj;
                                // ���������� �� �� ������ �������� ������ � �������� ������
                                if (this.m_objBudgetDocList.Remove(objBudgetDoc) == false)
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("�� ������� ������� �������� �� ������ �������� ������!\n������� ������� \"��������\".", "��������",
                                      System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    // ������� ������ �� ������� dtDocWorked                                    
                                    gridViewDocWorked.BeginInit();
                                    gridViewDocWorked.DeleteRow(iRowHndl);
                                    gridViewDocWorked.EndInit();
                                    // ��������� ������ � ������ ���������� ������
                                    this.m_objBudjetDocArjList.Add(objBudgetDoc);
                                }
                                // ��������� ������ � ������� dtDocNotActive                                
                                AppendRowInDS(objBudgetDoc);
                                // ������������ ���������� ������ �� ��������
                                tabPageDocWorked.Text = strtabWorkedName + " (" + gridViewDocWorked.RowCount.ToString() + ")";
                                System.Int32 iRowCount = (gridViewDocNotActive.IsVisible == true) ? gridViewDocNotActive.RowCount : dtDocNotActive.Rows.Count;
                                tabPageDocNotActive.Text = strtabNotActiveName + " (" + gridViewDocNotActive.RowCount.ToString() + ")";
                            }
                        }

                        if (SelectedGridView == gridViewDocWork)
                        {
                            System.Int32 iRowHndl = gridViewDocWork.FocusedRowHandle;
                            if (objBudgetDoc.IsActive == true)
                            {
                                // �� ��������� � ������� "�� ���������",
                                // ���� ������ �������� ��� ���������, �� ��� ���� �������,
                                // �� ����� �� ����������� � ������ "������������"

                                if (uuidStateId.CompareTo(objBudgetDoc.DocState.uuidID) != 0)
                                {
                                    objBudgetDoc.ViewMode = ERP_Budget.Common.enumViewMode.Worked;
                                    // ������� ������ �� ������� dtDocWork
                                    gridViewDocWork.BeginInit();
                                    gridViewDocWork.DeleteRow(iRowHndl);
                                    gridViewDocWork.EndInit();
                                    // ��������� ������ � ������� dtDocWorked
                                    AppendRowInDS(objBudgetDoc);
                                    // ������������ ���������� ������ �� ��������
                                    tabPageDocWork.Text = strtabWorkName + " (" + gridViewDocWork.RowCount.ToString() + ")";
                                    System.Int32 iRowCount = (gridViewDocWorked.IsVisible == true) ? gridViewDocWorked.RowCount : dtDocWorked.Rows.Count;
                                    tabPageDocWorked.Text = strtabWorkedName + " (" + iRowCount.ToString() + ")";
                                }


                                //// ������ ��-�������� �������, ����� � ����� ���������� �� ��������
                                //objBudgetDoc.ViewMode = ERP_Budget.Common.enumViewMode.Worked;
                                //gridViewDocWork.SetRowCellValue( iRowHndl, colA_BUDGETDOCSTATE_NAME, objBudgetDoc.DocState.Name );
                                //gridViewDocWork.SetRowCellValue( iRowHndl, colA_DOCOBJECTIVE, objBudgetDoc.Objective );
                                //gridViewDocWork.SetRowCellValue( iRowHndl, colA_DOCDATE, objBudgetDoc.Date );
                                //gridViewDocWork.RefreshRow( iRowHndl );
                            }
                            else
                            {
                                // ������ �������� ���� ��������� ���� � ������ �� ����� ����������� � �����
                                objBudgetDoc.ViewMode = ERP_Budget.Common.enumViewMode.Arj;
                                // ���������� �� �� ������ �������� ������ � �������� ������
                                if (this.m_objBudgetDocList.Remove(objBudgetDoc) == false)
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("�� ������� ������� �������� �� ������ �������� ������!\n������� ������� \"��������\".", "��������",
                                      System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    // ������� ������ �� ������� dtDocWork
                                    gridViewDocWork.BeginInit();
                                    gridViewDocWork.DeleteRow(iRowHndl);
                                    gridViewDocWork.EndInit();
                                    // ��������� ������ � ������ ���������� ������
                                    this.m_objBudjetDocArjList.Add(objBudgetDoc);
                                }
                                // ��������� ������ � ������� dtDocNotActive
                                AppendRowInDS(objBudgetDoc);
                                // ������������ ���������� ������ �� ��������
                                tabPageDocWork.Text = strtabWorkName + " (" + gridViewDocWork.RowCount.ToString() + ")";
                                System.Int32 iRowCount = (gridViewDocNotActive.IsVisible == true) ? gridViewDocNotActive.RowCount : dtDocNotActive.Rows.Count;
                                tabPageDocNotActive.Text = strtabNotActiveName + " (" + iRowCount.ToString() + ")";
                            }
                        }

                    }
                    //RefreshClick();
                }
                //objfrmBudgetDoc.Dispose();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                gridDocWork.Enabled = (dsBudgetDoc.Tables["dtDocWork"].Rows.Count > 0);
                gridDocWorked.Enabled = (dsBudgetDoc.Tables["dtDocWorked"].Rows.Count > 0);
                gridDocNotActive.Enabled = (dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count > 0);
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return;
        }
        /// <summary>
        /// ���������� �������� ����� � ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                EditBudgetDoc();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("gridView_DoubleClick.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void barBtnEditDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                EditBudgetDoc();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("barBtnEditDoc_ItemClick.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// ����� ������ � ������ �� ����������� ��������������
        /// </summary>
        /// <param name="uuidBudgetDocID">�� ������</param>
        /// <returns>������ "������"</returns>
        private ERP_Budget.Common.CBudgetDoc GetBudgetDocByID(System.Guid uuidBudgetDocID)
        {
            ERP_Budget.Common.CBudgetDoc objRet = null;
            try
            {
                if (TabControlDocList.SelectedTabPage == null) { return objRet; }
                if ((TabControlDocList.SelectedTabPage == tabPageDocWork) || (TabControlDocList.SelectedTabPage == tabPageDocWorked))
                {
                    foreach (ERP_Budget.Common.CBudgetDoc objBudgetDoc in this.m_objBudgetDocList)
                    {
                        if (objBudgetDoc.uuidID.CompareTo(uuidBudgetDocID) == 0)
                        {
                            // ����� ����
                            objRet = objBudgetDoc;
                            break;
                        }
                    }
                }
                if ((TabControlDocList.SelectedTabPage == tabPageDocNotActive) || (TabControlDocList.SelectedTabPage == tabPageError))
                {
                    foreach (ERP_Budget.Common.CBudgetDoc objBudgetDoc in this.m_objBudjetDocArjList)
                    {
                        if (objBudgetDoc.uuidID.CompareTo(uuidBudgetDocID) == 0)
                        {
                            // ����� ����
                            objRet = objBudgetDoc;
                            break;
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ������ ������ � ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return objRet;
        }
        /// <summary>
        /// ���������� ���������� ������������� ���������� ������ ��� �������� ��������
        /// </summary>
        /// <returns>���������� ������������� ������</returns>
        private System.Guid GetBudgetDocID()
        {
            System.Guid uuidBudgetDocID = System.Guid.Empty;
            try
            {
                if (TabControlDocList.SelectedTabPage == tabPageDocWork)
                {
                    // �������������� ������
                    if ((gridViewDocWork.RowCount > 0) && (gridViewDocWork.FocusedRowHandle >= 0))
                    {
                        uuidBudgetDocID = (System.Guid)gridViewDocWork.GetRowCellValue(gridViewDocWork.FocusedRowHandle, colA_BUDGETDOC_GUID_ID);
                    }
                }
                if (TabControlDocList.SelectedTabPage == tabPageDocWorked)
                {
                    // ������������ ������
                    if ((gridViewDocWorked.RowCount > 0) && (gridViewDocWorked.FocusedRowHandle >= 0))
                    {
                        uuidBudgetDocID = (System.Guid)gridViewDocWorked.GetRowCellValue(gridViewDocWorked.FocusedRowHandle, colB_BUDGETDOC_GUID_ID);
                    }
                }
                if (TabControlDocList.SelectedTabPage == tabPageDocNotActive)
                {
                    // ����� ������
                    if ((gridViewDocNotActive.RowCount > 0) && (gridViewDocNotActive.FocusedRowHandle >= 0))
                    {
                        uuidBudgetDocID = (System.Guid)gridViewDocNotActive.GetRowCellValue(gridViewDocNotActive.FocusedRowHandle, colC_BUDGETDOC_GUID_ID);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ������ ����������� �������������� ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return uuidBudgetDocID;
        }
        /// <summary>
        /// ���������� ������� �������� ��������
        /// </summary>
        /// <returns>������� �������� ��������</returns>
        private DevExpress.XtraGrid.Views.Grid.GridView GetGridViewBySelectedPage()
        {
            DevExpress.XtraGrid.Views.Grid.GridView objRet = null;
            try
            {
                if (TabControlDocList.SelectedTabPage == tabPageDocWork)
                {
                    // �������������� ������
                    objRet = gridViewDocWork;
                }
                if (TabControlDocList.SelectedTabPage == tabPageDocWorked)
                {
                    // ������������ ������
                    objRet = gridViewDocWorked;
                }
                if (TabControlDocList.SelectedTabPage == tabPageDocNotActive)
                {
                    // ����� ������
                    objRet = gridViewDocNotActive;
                }
                if (TabControlDocList.SelectedTabPage == tabPageError)
                {
                    // ������ ������
                    objRet = gridViewDocErr;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ������ ������� ���������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return objRet;
        }
        #endregion

        #region ��������� ��������
        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridDocNotActive.DataSource == null) { return; }
            try
            {
                if (((e.Column == col�_IMAGE_ID) || (e.Column == colA_IMAGETYPE_ID) ||
                    (e.Column == colB_IMAGETYPE_ID) || (e.Column == colC_IMAGETYPE_ID) ||
                    (e.Column == colE_IMAGETYPE_ID) || (e.Column == colA_ATTACH) ||
                    (e.Column == colB_ATTACH) || (e.Column == colC_ATTACH) ||
                    (e.Column == colA_NOTETYPE) || (e.Column == colB_NOTETYPE) || (e.Column == colC_NOTETYPE) ||
                    (e.Column == colA_COMMENT) || (e.Column == colB_COMMENT) || (e.Column == colC_COMMENT)) == false) { return; }

                System.Drawing.Image img = null;
                // ������ � ������ � ����������� ��������� ���������� ������ ���� ���������
                if ((m_objBudgetDocTypeList == null) || (m_objBudgetDocTypeList.Count == 0) ||
                    (m_objBudgetDocStateList == null) || (m_objBudgetDocStateList.Count == 0) ||
                    (m_objNoteTypeList == null) || (m_objNoteTypeList.Count == 0))
                {
                    return;
                }

                System.String strDocStateField = "";
                System.String strDocTypeField = "";
                System.String strAttachField = "";
                System.String strNoteTypeField = "";
                System.String strCommentField = "";
                // ����� ���������� � ����� ���� �������� ���������� � ���� � ��������� ���������
                if ((DevExpress.XtraGrid.Views.Grid.GridView)sender == gridViewDocWork)
                {
                    // �������������� ������
                    strDocStateField = "A_BUDGETDOCSTATE_NAME";
                    strDocTypeField = "A_BUDGETDOCTYPE_NAME";
                    strAttachField = "A_ATTACH";
                    strNoteTypeField = "A_NOTETYPE";
                    strCommentField = "A_USERCOMMENT";
                }
                if ((DevExpress.XtraGrid.Views.Grid.GridView)sender == gridViewDocWorked)
                {
                    // ������������ ������
                    strDocStateField = "B_BUDGETDOCSTATE_NAME";
                    strDocTypeField = "B_BUDGETDOCTYPE_NAME";
                    strAttachField = "B_ATTACH";
                    strNoteTypeField = "B_NOTETYPE";
                    strCommentField = "B_USERCOMMENT";
                }
                if ((DevExpress.XtraGrid.Views.Grid.GridView)sender == gridViewDocNotActive)
                {
                    // ����� ������
                    strDocStateField = "C_BUDGETDOCSTATE_NAME";
                    strDocTypeField = "C_BUDGETDOCTYPE_NAME";
                    strAttachField = "C_ATTACH";
                    strNoteTypeField = "C_NOTETYPE";
                    strCommentField = "C_USERCOMMENT";
                }
                if ((DevExpress.XtraGrid.Views.Grid.GridView)sender == gridViewDocErr)
                {
                    // ������ ������
                    strDocStateField = "E_BUDGETDOCSTATE_NAME";
                    strDocTypeField = "E_BUDGETDOCTYPE_NAME";
                }


                // ������ �������� ��� ��������� ��������� � ������ ������  
                System.Drawing.Image imgDocState = null;
                System.String strDocStateName =
                   (System.String)((DevExpress.XtraGrid.Views.Grid.GridView)sender).GetRowCellValue(e.RowHandle, strDocStateField);
                foreach (ERP_Budget.Common.CBudgetDocState objBudgetDocState in m_objBudgetDocStateList)
                {
                    if (objBudgetDocState.Name == strDocStateName)
                    {
                        imgDocState = objBudgetDocState.BudgetDocStateDraw.ImageDocStateSmall;
                        break;
                    }
                }

                // ������ �������� ��� ���� ���������� ���������
                System.Drawing.Image imgDocType = null;
                System.String strDocTypeName =
                   (System.String)((DevExpress.XtraGrid.Views.Grid.GridView)sender).GetRowCellValue(e.RowHandle, strDocTypeField);
                foreach (ERP_Budget.Common.CBudgetDocType objBudgetDocType in m_objBudgetDocTypeList)
                {
                    if (objBudgetDocType.Name == strDocTypeName)
                    {
                        imgDocType = objBudgetDocType.BudgetDocTypeDraw.ImageDocTypeSmall;
                        break;
                    }
                }

                // �������� ��� ��������
                System.Drawing.Image imgAttach = null;
                System.Boolean bExistsAttach = (System.Boolean)((DevExpress.XtraGrid.Views.Grid.GridView)sender).GetRowCellValue(e.RowHandle, strAttachField);
                if (bExistsAttach == true)
                {
                    imgAttach = ErpBudgetBudgetDoc.Properties.Resources.paperclip;
                }

                if (e.Column == col�_IMAGE_ID)
                {
                    // ����� ������
                    img = imgDocState;
                }
                if ((e.Column == colA_IMAGETYPE_ID) || (e.Column == colB_IMAGETYPE_ID) ||
                    (e.Column == colC_IMAGETYPE_ID) || (e.Column == colE_IMAGETYPE_ID))
                {
                    img = imgDocType;
                }
                if ((e.Column == colA_ATTACH) || (e.Column == colB_ATTACH) || (e.Column == colC_ATTACH))
                {
                    img = imgAttach;
                }
                // �����������
                if ((e.Column == colA_COMMENT) || (e.Column == colB_COMMENT) || (e.Column == colC_COMMENT))
                {
                    if (((DevExpress.XtraGrid.Views.Grid.GridView)sender).GetRowCellValue(e.RowHandle, strCommentField) != null)
                    {
                        if (((System.String)((DevExpress.XtraGrid.Views.Grid.GridView)sender).GetRowCellValue(e.RowHandle, strCommentField)) != "")
                        {
                            img = ErpBudgetBudgetDoc.Properties.Resources.message;
                        }
                    }
                }
                if ((e.Column == colA_NOTETYPE) || (e.Column == colB_NOTETYPE) || (e.Column == colC_NOTETYPE))
                {
                    // �������� ��� �������
                    img = GetNoteTypeImg((System.Guid)(((DevExpress.XtraGrid.Views.Grid.GridView)sender).GetDataRow(e.RowHandle)[strNoteTypeField]));
                }

                // ���������� ���������
                if (img != null)
                {
                    // 2009.06.10 ��������!
                    // ����� �������� �� ���������, � ������� ��������� "������ �������", � ��� �� "�������������� ������"
                    if ((strDocStateName == strBudgetDocStateReturnMoney) && (strDocTypeName != strBudgetDocTypeReturnMoney) )
                    {
                        Rectangle rImg = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + (e.Bounds.Height - img.Size.Height) / 2, img.Width, img.Height);
                        e.Graphics.FillRectangle(Brushes.BlueViolet, rImg);
                        e.Graphics.DrawImage(img, rImg);
                        Rectangle r = e.Bounds;
                        e.Handled = true;
                    }
                    else
                    {
                        Rectangle rImg = new Rectangle(e.Bounds.X + 3, e.Bounds.Y + (e.Bounds.Height - img.Size.Height) / 2, img.Width, img.Height);
                        e.Graphics.DrawImage(img, rImg);
                        Rectangle r = e.Bounds;
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("gridView_CustomDrawCell\n" + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;

        }
        /// <summary>
        /// ����� �������� ��� ������� � �������� ���������������
        /// </summary>
        /// <param name="uuidNoteType">�� �������</param>
        /// <returns>��������</returns>
        private System.Drawing.Image GetNoteTypeImg(System.Guid uuidNoteType)
        {
            if (uuidNoteType == System.Guid.Empty)
            {
                return ErpBudgetBudgetDoc.Properties.Resources.flag_none;
            }
            if ((m_objNoteTypeList == null) || (m_objNoteTypeList.Count == 0))
            {
                return null;
            }

            System.Drawing.Image imgRet = null;
            try
            {
                foreach (ERP_Budget.Common.CNoteType objNoteType in m_objNoteTypeList)
                {
                    if (objNoteType.uuidID == uuidNoteType)
                    {
                        imgRet = objNoteType.ImageSmall;
                        break;
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("�� ������� ����� �������� ��� �������.\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return imgRet;
        }

        #endregion

        #region ����������� ����
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView SelectedGridView = GetGridViewBySelectedPage();
                if (SelectedGridView == null) { e.Cancel = true; }
                else
                {
                    mitemCopyBudgetDoc.Enabled = (SelectedGridView.RowCount > 0) && (SelectedGridView.FocusedRowHandle >= 0);
                    mitemDeleteBudgetDoc.Enabled = !(SelectedGridView == gridViewDocNotActive); //  ( SelectedGridView.RowCount > 0 ) && ( SelectedGridView.FocusedRowHandle >= 0 );
                    mitemNewBudgetDoc.Enabled = true;
                    mitemRefresh.Enabled = true;
                    mitemTrnList.Enabled = (SelectedGridView.RowCount > 0) && (SelectedGridView.FocusedRowHandle >= 0);
                    mitemExportToExcel.Enabled = (SelectedGridView.RowCount > 0);
                    if ((SelectedGridView == gridViewDocNotActive) && (SelectedGridView.RowCount > 0) && (SelectedGridView.FocusedRowHandle >= 0))
                    {
                        System.Guid uuidBudgetDocID = GetBudgetDocID();
                        if (uuidBudgetDocID.CompareTo(System.Guid.Empty) != 0)
                        {
                            // ������ ������ ������ � ������
                            ERP_Budget.Common.CBudgetDoc objBudgetDoc = GetBudgetDocByID(uuidBudgetDocID);
                            if (objBudgetDoc != null)
                            {
                                if ((m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRAccountant) == true) ||
                                    (m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRCashier) == true))
                                {
                                    mitemChangePaymentDate.Enabled = (objBudgetDoc.DocState.OrderNum == 4);
                                }
                                mitemDePay.Enabled = m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRInspector);
                            }
                        }
                    }
                    else
                    {
                        mitemChangePaymentDate.Enabled = false;
                        mitemDePay.Enabled = false;
                        if ((m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRAccountant) == true) ||
                            (m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRCashier) == true))
                        {
                            mitemChangeCompany.Enabled = true;
                            mitemChangePaymentType.Enabled = true;
                        }
                    }
                    mitemChangeDocType.Enabled = m_objProfile.GetClientsRight().GetState(ERP_Budget.Global.Consts.strDRCreateUndefinedDocument);
                    
                    e.Cancel = false;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void contextMenuComment_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView SelectedGridView = GetGridViewBySelectedPage();
                if (SelectedGridView == null) { e.Cancel = true; }
                else
                {
                    System.Boolean bRowSelected = (SelectedGridView.RowCount > 0) && (SelectedGridView.FocusedRowHandle >= 0);
                    System.String strCommentField = "";
                    if (SelectedGridView == gridViewDocWork)
                    {
                        strCommentField = "A_USERCOMMENT";
                    }
                    if (SelectedGridView == gridViewDocWorked)
                    {
                        strCommentField = "B_USERCOMMENT";
                    }
                    if (SelectedGridView == gridViewDocNotActive)
                    {
                        strCommentField = "C_USERCOMMENT";
                    }
                    if (bRowSelected == true)
                    {
                        if ((SelectedGridView.GetRowCellValue(SelectedGridView.FocusedRowHandle, strCommentField) != null) &&
                            ((System.String)SelectedGridView.GetRowCellValue(SelectedGridView.FocusedRowHandle, strCommentField) != ""))
                        {
                            mitemAddComment.Enabled = true;
                            mitemDeleteComment.Enabled = true;
                        }
                        else
                        {
                            mitemAddComment.Enabled = true;
                            mitemDeleteComment.Enabled = false;
                        }
                    }
                    else
                    {
                        mitemAddComment.Enabled = false;
                        mitemDeleteComment.Enabled = false;
                    }
                    e.Cancel = false;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region ������ ��������
        private void mitemTrnList_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                frmAccTrnList objfrmAccTrnList = new frmAccTrnList(this.m_objProfile, GetBudgetDocByID(GetBudgetDocID()));
                objfrmAccTrnList.ShowDialog();
                objfrmAccTrnList.Dispose();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ������� ��������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return;

        }
        #endregion

        #region ������ ���������
        private void mitemDocStateList_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                frmDocStateHistory objfrmDocStateHistory = new frmDocStateHistory(this.m_objProfile, GetBudgetDocByID(GetBudgetDocID()));
                objfrmDocStateHistory.ShowDialog();
                objfrmDocStateHistory.Dispose();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ������� ���������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            return;

        }
        #endregion

        #region ������������ ������
        private System.Boolean bDePayBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            System.Boolean bRet = false;
            if (objBudgetDoc == null) { return bRet; }
            try
            {
                // ������� ������������ 
                ERP_Budget.Common.CUser objCurrentUser = ERP_Budget.Common.CUser.GetUsersInfo(this.m_objProfile);
                // ������� ������������
                bRet = objBudgetDoc.BackMoneyAfterPaid( this.m_objProfile, objCurrentUser.ulID);
            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ������������� ������ ���������� ���������.\n\n����� ������ : " + e.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bRet;
        }
        private void mitemDePayBudgetDoc_Click(object sender, EventArgs e)
        {
            try
            {
                System.Guid uuidBudgetDocID = GetBudgetDocID();
                if (uuidBudgetDocID.CompareTo(System.Guid.Empty) != 0)
                {
                    // ������ ������ ������ � ������
                    ERP_Budget.Common.CBudgetDoc objBudgetDoc = GetBudgetDocByID(uuidBudgetDocID);
                    if (objBudgetDoc != null)
                    {
                        // ����� ����
                        if (DevExpress.XtraEditors.XtraMessageBox.Show("����������� ������ ������ ���������� ���������.", "�������������",
                               System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                            return;
                        }
                        if (bDePayBudgetDoc(objBudgetDoc) == true)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show( "������ ���������� ��������� ������� ��������.\n��� ����, ��� �� ������� ���������, �������� ����� ������.", "����������",
                               System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information );
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ������������� ������ ���������� ���������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region �������� ������

        /// <summary>
        /// ������� ��������� ��������
        /// </summary>
        /// <param name="objBudgetDoc">��������� ��������</param>
        /// <returns>true - �������� ����������; false - ������</returns>
        private System.Boolean bDeleteBudgetDoc(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            System.Boolean bRet = false;
            if (objBudgetDoc == null) { return bRet; }
            try
            {
                // ������� ������������ 
                ERP_Budget.Common.CUser objCurrentUser = ERP_Budget.Common.CUser.GetUsersInfo(this.m_objProfile);
                if (objCurrentUser.ulID != objBudgetDoc.OwnerUser.ulID)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("�������� ����� ������� ������ ��� ���������.", "��������",
                       System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return bRet;
                }
                // ������ ������� �� ��������
                bRet = objBudgetDoc.Drop(this.m_objProfile, objCurrentUser.ulID);
            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ���������� ���������.\n\n����� ������ : " + e.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bRet;
        }

        private void mitemDeleteBudgetDoc_Click(object sender, EventArgs e)
        {
            try
            {
                System.Guid uuidBudgetDocID = GetBudgetDocID();
                if (uuidBudgetDocID.CompareTo(System.Guid.Empty) != 0)
                {
                    // ������ ������ ������ � ������
                    ERP_Budget.Common.CBudgetDoc objBudgetDoc = GetBudgetDocByID(uuidBudgetDocID);
                    if (objBudgetDoc != null)
                    {
                        // ����� ���� - ��������� �������
                        if (DevExpress.XtraEditors.XtraMessageBox.Show("����������� �������� ���������� ���������.", "�������������",
                               System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                            return;
                        }
                        if (bDeleteBudgetDoc(objBudgetDoc) == true)
                        {
                            // ��������� ������ ������
                            RefreshClick();
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ �������� ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region ��������������
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.m_bOutlookMode == true)
                {
                    if (m_IsRefreshBudgetDocList == false)
                    {
                        // ���������� �������� �� Outlook � � ������ ������ ������ �� �����������
                        timer.Stop();
                        // ��������� ���������� ������ ������
                        LoadBudgetDocListAsync();
                        //bLoadBudgetDocList();
                        // ���������� ������
                        timer.Enabled = true;
                    }
                }
                else
                {
                    if (TabControlDocList.TabPages.Count > 0)
                    {
                        timer.Stop();
                        if ((this.thrRefreshBudgetDocActive == null) || (this.thrRefreshBudgetDocActive.IsAlive == false))
                        {
                            StartThreadLoadBudgetDocActive();
                            //StartThreadRefreshBudgetDocActive();
                        }

                        if ((this.thrRefreshBudgetDocArj == null) || (this.thrRefreshBudgetDocArj.IsAlive == false))
                        {
                            StartThreadLoadBudgetDocArjive();
                            //StartThreadRefreshBudgetDocArj();
                        }
                        // ���������� ������
                        timer.Enabled = true;
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ �������� ������ ������.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }

        private void SetAutoRefreshMode()
        {
            try
            {
                System.Boolean IsAutoRefreshEnabled = (timer.Enabled == true);
                if (IsAutoRefreshEnabled == true)
                {
                    timer.Stop();
                }
                else
                {
                    timer.Interval = iTimerInterval;
                    timer.Start();
                }
                // ������ �������� �� ������
                barBtnAutoRefresh.Hint = (timer.Enabled == true) ? ("�������������� ���������� ������ " + System.String.Format("{0:#### ###}", (timer.Interval / 1000 / 60)) + " ���.") : "�������������� ���������� ���������";
                barBtnAutoRefresh.Glyph = (timer.Enabled == true) ? ErpBudgetBudgetDoc.Properties.Resources.clock_run : ErpBudgetBudgetDoc.Properties.Resources.clock_stop;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ ��������� ������ \"��������������\".\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }

        private void barBtnAutoRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetAutoRefreshMode();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ barBtnAutoRefresh_ItemClick.\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region ��������� ��� ������ � ������
        public void LoadFindParams()
        {
            System.String strReestrPath = (this.m_objProfile.GetRegKeyBase() + "\\Tools\\" + gridViewDocNotActive.Name + "\\FindParams");
            Microsoft.Win32.RegistryKey regProfile = null;
            System.String strBeginDate = "";
            try
            {
                regProfile = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strReestrPath, false);
                if (regProfile == null)
                {
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(strReestrPath);
                }
                else
                {
                    strBeginDate = (System.String)regProfile.GetValue("BeginDate", "");
                    regProfile.Close();
                }
                System.DateTime BeginDate = System.DateTime.Today;
                try
                {
                    BeginDate = System.Convert.ToDateTime(strBeginDate);
                }
                catch
                {
                    BeginDate = new DateTime(System.DateTime.Today.Year, System.DateTime.Today.Month, 1);
                }
                finally
                {
                    dtBeginDate.DateTime = BeginDate;
                    dtEndDate.DateTime = System.DateTime.Today;
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ �������� �������� ��� ������ ������ ������.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }
        private void SaveFindParams()
        {
            System.String strReestrPath = (this.m_objProfile.GetRegKeyBase() + "\\Tools\\" + gridViewDocNotActive.Name + "\\FindParams");
            Microsoft.Win32.RegistryKey regProfile = null;
            try
            {
                regProfile = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strReestrPath, true);
                if (regProfile == null)
                {
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(strReestrPath);
                    regProfile = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strReestrPath, true);
                }
                if (regProfile != null)
                {
                    regProfile.SetValue("BeginDate", dtBeginDate.DateTime.ToShortDateString());
                    regProfile.Close();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ ���������� �������� ��� ������ ������ ������.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }
        #endregion

        #region ��������� �������� ���� ��������
        /// <summary>
        /// ��������� ��������� �������� �� �������
        /// </summary>
        public void RestoreLayoutFromRegistry()
        {
            System.String strReestrPath = this.m_objProfile.GetRegKeyBase();
            strReestrPath += ("\\Tools\\");
            try
            {
                gridViewDocWork.RestoreLayoutFromRegistry(strReestrPath + gridViewDocWork.Name);
                gridViewDocWorked.RestoreLayoutFromRegistry(strReestrPath + gridViewDocWorked.Name);
                gridViewDocNotActive.RestoreLayoutFromRegistry(strReestrPath + gridViewDocNotActive.Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ �������� �������� ������ ������.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }
        /// <summary>
        /// ���������� ��������� �������� � ������
        /// </summary>
        private void SaveLayoutToRegistry()
        {
            System.String strReestrPath = this.m_objProfile.GetRegKeyBase();
            strReestrPath += ("\\Tools\\");
            try
            {
                gridViewDocWork.SaveLayoutToRegistry(strReestrPath + gridViewDocWork.Name);
                gridViewDocWorked.SaveLayoutToRegistry(strReestrPath + gridViewDocWorked.Name);
                gridViewDocNotActive.SaveLayoutToRegistry(strReestrPath + gridViewDocNotActive.Name);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ ������ �������� ������ ������.\n\n����� ������ : " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // ������� ���������� �������
            {
            }

            return;
        }
        #endregion

        #region �������
        private void gridViewDocNotActive_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = gridViewDocNotActive.CalcHitInfo(new Point(e.X, e.Y));
                m_bBlockDblClick = ((e.Button == MouseButtons.Left) && ((hi.Column == colC_NOTETYPE) || (hi.Column == colC_COMMENT)) && (hi.InRow == true));
                if (e.Button == MouseButtons.Right)
                {
                    if (hi.Column == colC_NOTETYPE)
                    {
                        gridDocNotActive.ContextMenuStrip = contextMenuNoteType;
                        //contextMenuNoteType.Show( PointToScreen(new Point(e.X, e.Y)));
                    }
                    else
                    {
                        if (hi.Column == colC_COMMENT)
                        {
                            gridDocNotActive.ContextMenuStrip = contextMenuComment;
                        }
                        else
                        {
                            gridDocNotActive.ContextMenuStrip = contextMenuStrip;
                        }
                        //contextMenuStrip.Show(new Point(e.X, e.Y));
                    }
                }
                else
                {
                    if ((e.Button == MouseButtons.Left) && (hi.Column == colC_NOTETYPE) && (hi.InRow == true))
                    {
                        ChangeNoteType(gridViewDocNotActive, colC_NOTETYPE_ID, colC_NOTETYPE_PREVID,
                            (System.Guid)gridViewDocNotActive.GetRowCellValue(hi.RowHandle, colC_BUDGETDOC_GUID_ID),
                            hi.RowHandle);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ����������� ������������ ����.\n\n����� ������ : " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void gridViewDocWorked_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = gridViewDocWorked.CalcHitInfo(new Point(e.X, e.Y));
                m_bBlockDblClick = ((e.Button == MouseButtons.Left) && ((hi.Column == colB_NOTETYPE) || (hi.Column == colB_COMMENT)) && (hi.InRow == true));
                if (e.Button == MouseButtons.Right)
                {
                    if (hi.Column == colB_NOTETYPE)
                    {
                        gridDocWorked.ContextMenuStrip = contextMenuNoteType;
                    }
                    else
                    {
                        if (hi.Column == colB_COMMENT)
                        {
                            gridDocWorked.ContextMenuStrip = contextMenuComment;
                        }
                        else
                        {
                            gridDocWorked.ContextMenuStrip = contextMenuStrip;
                        }
                    }
                }
                else
                {
                    if ((e.Button == MouseButtons.Left) && (hi.Column == colB_NOTETYPE) && (hi.InRow == true))
                    {
                        ChangeNoteType(gridViewDocWorked, colB_NOTETYPE, colB_NOTETYPE_PREVID,
                            (System.Guid)gridViewDocWorked.GetRowCellValue(hi.RowHandle, colB_BUDGETDOC_GUID_ID),
                            hi.RowHandle);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ����������� ������������ ����.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void gridViewDocWork_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = gridViewDocWork.CalcHitInfo(new Point(e.X, e.Y));
                m_bBlockDblClick = ((e.Button == MouseButtons.Left) && ((hi.Column == colA_NOTETYPE) || (hi.Column == colA_COMMENT)) && (hi.InRow == true));
                if (e.Button == MouseButtons.Right)
                {
                    if (hi.Column == colA_NOTETYPE)
                    {
                        gridDocWork.ContextMenuStrip = contextMenuNoteType;
                    }
                    else
                    {
                        if (hi.Column == colA_COMMENT)
                        {
                            gridDocWork.ContextMenuStrip = contextMenuComment;
                        }
                        else
                        {
                            gridDocWork.ContextMenuStrip = contextMenuStrip;
                        }
                    }
                }
                else
                {
                    if ((e.Button == MouseButtons.Left) && (hi.Column == colA_NOTETYPE) && (hi.InRow == true))
                    {
                        ChangeNoteType(gridViewDocWork, colA_NOTETYPE_ID, colA_NOTETYPE_PREVID,
                            (System.Guid)gridViewDocWork.GetRowCellValue(hi.RowHandle, colA_BUDGETDOC_GUID_ID),
                            hi.RowHandle);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ����������� ������������ ����.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// ���������� ������� ������ ������������ ���� "�������"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mitemNoteType_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.GetType().Name == "ToolStripMenuItem")
                {
                    DevExpress.XtraGrid.Views.Grid.GridView currGridView = GetGridViewBySelectedPage();
                    if ((currGridView != null) && (currGridView.FocusedRowHandle >= 0))
                    {
                        DevExpress.XtraGrid.Columns.GridColumn colNoteTypeID = null;
                        DevExpress.XtraGrid.Columns.GridColumn colNoteTypePrevID = null;
                        DevExpress.XtraGrid.Columns.GridColumn colBudgetDocID = null;

                        if (currGridView == gridViewDocWork)
                        {
                            colNoteTypeID = colA_NOTETYPE_ID;
                            colNoteTypePrevID = colA_NOTETYPE_PREVID;
                            colBudgetDocID = colA_BUDGETDOC_GUID_ID;
                        }
                        if (currGridView == gridViewDocWorked)
                        {
                            colNoteTypeID = colB_NOTETYPE_ID;
                            colNoteTypePrevID = colB_NOTETYPE_PREVID;
                            colBudgetDocID = colB_BUDGETDOC_GUID_ID;
                        }
                        if (currGridView == gridViewDocNotActive)
                        {
                            colNoteTypeID = colC_NOTETYPE_ID;
                            colNoteTypePrevID = colC_NOTETYPE_PREVID;
                            colBudgetDocID = colC_BUDGETDOC_GUID_ID;
                        }

                        System.Guid uuidNewNoteType = (((System.Windows.Forms.ToolStripMenuItem)sender).Tag == null) ? System.Guid.Empty : ((ERP_Budget.Common.CNoteType)((System.Windows.Forms.ToolStripMenuItem)sender).Tag).uuidID;
                        System.Guid uuidBudgetDocID = (System.Guid)currGridView.GetRowCellValue(currGridView.FocusedRowHandle, colBudgetDocID);

                        if (colNoteTypeID != null)
                        {
                            System.Guid uuidNoteType = (System.Guid)currGridView.GetRowCellValue(currGridView.FocusedRowHandle, colNoteTypeID);
                            System.Boolean bRet = (uuidNewNoteType.CompareTo(System.Guid.Empty) == 0) ? ERP_Budget.Common.CNoteType.DeleteNoteFromBudgetDoc(m_objProfile, uuidBudgetDocID) : ERP_Budget.Common.CNoteType.MakeNoteToBudgetDoc(m_objProfile, uuidBudgetDocID, uuidNewNoteType);
                            if (bRet == true)
                            {
                                // ����� �������
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colNoteTypeID, uuidNewNoteType);
                                // ���������� ������ �������
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colNoteTypePrevID, uuidNoteType);
                                currGridView.RefreshRow(currGridView.FocusedRowHandle);
                            }
                        }
                    }

                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ��������� �������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// ������ ������� �������� "�������"
        /// </summary>
        /// <param name="currGridView">��������</param>
        /// <param name="colNoteTypeID">�� �������</param>
        /// <param name="colNoteTypePrevID">����� �� �������</param>
        /// <param name="uuidBudgetDocID">�� ���������� ���������</param>
        /// <param name="iRowHndl">������������� ������</param>
        private void ChangeNoteType(DevExpress.XtraGrid.Views.Grid.GridView currGridView,
            DevExpress.XtraGrid.Columns.GridColumn colNoteTypeID,
            DevExpress.XtraGrid.Columns.GridColumn colNoteTypePrevID,
            System.Guid uuidBudgetDocID, System.Int32 iRowHndl)
        {
            try
            {
                if ((currGridView == null) || (colNoteTypeID == null) || (colNoteTypePrevID == null)) { return; }
                if ((currGridView != null) && (iRowHndl >= 0))
                {

                    System.Guid uuidNoteType = (System.Guid)currGridView.GetRowCellValue(iRowHndl, colNoteTypeID);
                    System.Int32 iIndx = 0;
                    System.Int32 iNextIndx = 0;
                    for (System.Int32 i = 0; i < m_objNoteTypeList.Count; i++)
                    {
                        if (m_objNoteTypeList[i].uuidID == uuidNoteType)
                        {
                            iIndx = i;
                            break;
                        }
                    }
                    if (iIndx != (m_objNoteTypeList.Count - 1))
                    {
                        if (uuidNoteType == System.Guid.Empty)
                        {
                            iNextIndx = 0;
                        }
                        else
                        {
                            iNextIndx = (m_objNoteTypeList.Count - 1);
                        }
                    }
                    else
                    {
                        iNextIndx = 0;
                    }

                    System.Guid uuidNewNoteType = m_objNoteTypeList[iNextIndx].uuidID;
                    // ������ ��������� � �� �  ���� ��� � ������� ������ ��������
                    if (ERP_Budget.Common.CNoteType.MakeNoteToBudgetDoc(m_objProfile, uuidBudgetDocID, uuidNewNoteType) == true)
                    {
                        // ����� �������
                        currGridView.SetRowCellValue(iRowHndl, colNoteTypeID, uuidNewNoteType);
                        // ���������� ������ �������
                        currGridView.SetRowCellValue(iRowHndl, colNoteTypePrevID, uuidNoteType);
                        currGridView.UpdateCurrentRow(); // .RefreshRow(currGridView.FocusedRowHandle);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ����� �������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ������������ ������
        private void gridViewDocWork_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                System.DateTime dtDateState = (System.DateTime)gridViewDocWork.GetRowCellValue(e.RowHandle, colA_DATESTATE);
                System.Boolean bGreat = false;
                if (System.DateTime.Today.Month > dtDateState.Month)
                {
                    bGreat = true;
                }
                else
                {
                    if (System.DateTime.Today.Day > (dtDateState.Day + 1))
                    {
                        bGreat = true;
                    }

                }

                if (bGreat == true)
                {
                    e.Appearance.BackColor = Color.FromArgb(192, 215, 255);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "������ ������� RowCellStyle.\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region �����������
        private void mitemAddComment_Click(object sender, EventArgs e)
        {
            try
            {
                SetUserCommentForBudgetDoc();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "\"������� �����������\".\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// ������������� ����������� ������������ ��� ���������� ���������
        /// </summary>
        private void SetUserCommentForBudgetDoc()
        {
            DevExpress.XtraGrid.Views.Grid.GridView currGridView = GetGridViewBySelectedPage();
            if ((currGridView != null) && (currGridView.FocusedRowHandle >= 0))
            {
                DevExpress.XtraGrid.Columns.GridColumn colComment = null;
                DevExpress.XtraGrid.Columns.GridColumn colBudgetDocID = null;

                if (currGridView == gridViewDocWork)
                {
                    colComment = colA_COMMENT;
                    colBudgetDocID = colA_BUDGETDOC_GUID_ID;
                }
                if (currGridView == gridViewDocWorked)
                {
                    colComment = colB_COMMENT;
                    colBudgetDocID = colB_BUDGETDOC_GUID_ID;
                }
                if (currGridView == gridViewDocNotActive)
                {
                    colComment = colC_COMMENT;
                    colBudgetDocID = colC_BUDGETDOC_GUID_ID;
                }
                if ((colComment != null) && (colBudgetDocID != null))
                {
                    System.String strComment = (currGridView.GetRowCellValue(currGridView.FocusedRowHandle, colComment) == null) ? "" : (System.String)currGridView.GetRowCellValue(currGridView.FocusedRowHandle, colComment);
                    System.Guid uuidBudgetDocID = (System.Guid)currGridView.GetRowCellValue(currGridView.FocusedRowHandle, colBudgetDocID);

                    frmUserComment objfrmUserComment = new frmUserComment(m_objProfile, uuidBudgetDocID, strComment);
                    DialogResult Res = objfrmUserComment.ShowDialog();
                    if (Res == DialogResult.OK)
                    {
                        currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colComment, objfrmUserComment.Comment);
                        currGridView.RefreshRow(currGridView.FocusedRowHandle);
                    }
                    objfrmUserComment.Dispose();
                }
            }
        }
        /// <summary>
        /// ������� ����������� ������������ ��� ���������� ���������
        /// </summary>
        private void DeleteUserCommentForBudgetDoc()
        {
            DevExpress.XtraGrid.Views.Grid.GridView currGridView = GetGridViewBySelectedPage();
            if ((currGridView != null) && (currGridView.FocusedRowHandle >= 0))
            {
                DevExpress.XtraGrid.Columns.GridColumn colComment = null;
                DevExpress.XtraGrid.Columns.GridColumn colBudgetDocID = null;

                if (currGridView == gridViewDocWork)
                {
                    colComment = colA_COMMENT;
                    colBudgetDocID = colA_BUDGETDOC_GUID_ID;
                }
                if (currGridView == gridViewDocWorked)
                {
                    colComment = colB_COMMENT;
                    colBudgetDocID = colB_BUDGETDOC_GUID_ID;
                }
                if (currGridView == gridViewDocNotActive)
                {
                    colComment = colC_COMMENT;
                    colBudgetDocID = colC_BUDGETDOC_GUID_ID;
                }
                if ((colComment != null) && (colBudgetDocID != null))
                {
                    System.Guid uuidBudgetDocID = (System.Guid)currGridView.GetRowCellValue(currGridView.FocusedRowHandle, colBudgetDocID);

                    if (ERP_Budget.Common.CNoteType.DeleteCommentFromBudgetDoc(m_objProfile, uuidBudgetDocID) == true)
                    {
                        currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colComment, "");
                        currGridView.RefreshRow(currGridView.FocusedRowHandle);
                    }
                }
            }
        }
        private void mitemDeleteComment_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteUserCommentForBudgetDoc();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "\"������� �����������\".\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ������� � MS Excel
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            //string name = Application.ProductName;
            string name = "������ ������";
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "������� ������ ������ " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        private void OpenFile(string fileName)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("�� ������ ������� ���� ����?", "������� � MS Excel...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = fileName;
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                    }
                    catch
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(this, "Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ������ OpenFile.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        //<sbExportToHTML>
        private void ExportTo(DevExpress.XtraExport.IExportProvider provider,
            DevExpress.XtraGrid.Views.Grid.GridView objGridView)
        {
            try
            {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;

                this.FindForm().Refresh();

                BaseExportLink link = objGridView.CreateExportLink(provider);
                (link as GridViewExportLink).ExpandAll = false;
                //link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);
                link.ExportTo(true);
                provider.Dispose();
                //link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

                Cursor.Current = currentCursor;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ������ OpenFile.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        private void sbExportToXLS_Click(object sender, System.EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView objGridView = GetGridViewBySelectedPage();

                if ((objGridView == null) || (objGridView.RowCount == 0))
                {
                    return;
                }
                string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
                if (fileName != "")
                {
                    ExportTo(new ExportXlsProvider(fileName), objGridView);
                    OpenFile(fileName);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ������ sbExportToXLS_Click.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region ����� ���� ���������� ���������
        /// <summary>
        /// ����� �������� ���� ���������� ���������
        /// </summary>
        /// <param name="objBudgetDoc"></param>
        private void ChangeBudgetDocType(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            if ((objBudgetDoc == null) || (objBudgetDoc.DocType == null)) { return; }
            Cursor = Cursors.WaitCursor;
            try
            {
                System.String strErr = System.String.Empty;
                List<ERP_Budget.Common.CBudgetDocTypeTransformTypeItem> objPossibleDocTypeList = null;

                if( ( objBudgetDoc.DocType.Init( m_objProfile, objBudgetDoc.DocType.uuidID ) == true ) && 
                    ( objBudgetDoc.DocType.IsCanTransformInOtherType == true ) )
                {
                    objPossibleDocTypeList =
                        ERP_Budget.Common.CBudgetDocTypeDataBaseModel.GetBudgetDocTransformCollection(objBudgetDoc.DocType.uuidID, m_objProfile, null, ref strErr);
                    if ((objPossibleDocTypeList != null) || (objPossibleDocTypeList.Count > 0))
                    {
                        objPossibleDocTypeList = objPossibleDocTypeList.Where<ERP_Budget.Common.CBudgetDocTypeTransformTypeItem>(x => x.CurrentBudgetDocState.uuidID.CompareTo(objBudgetDoc.DocState.uuidID) == 0).ToList<ERP_Budget.Common.CBudgetDocTypeTransformTypeItem>();
                    }
                    if ((objPossibleDocTypeList == null) || (objPossibleDocTypeList.Count == 0))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                        "��� ���������� ��������� ������ �������� ��� ���.", "��������",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (objBudgetDoc.Init(m_objProfile, objBudgetDoc.uuidID) == false)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(
                            "��� ���������� ��������� �� ������� ���������� ��� ��������.\n����������, ����������, � ������������.", "��������",
                            System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            
                            return;
                        }

                        DialogResult objDlgRes = System.Windows.Forms.DialogResult.None;

                        using (frmChangeDocType objfrmChangeDocType =
                            new frmChangeDocType(m_objProfile, objBudgetDoc, objPossibleDocTypeList))
                        {
                            objDlgRes = objfrmChangeDocType.ShowDialog();
                        }

                        if (objDlgRes == DialogResult.OK)
                        {
                            Cursor = Cursors.WaitCursor;

                            objBudgetDoc.Init(m_objProfile, objBudgetDoc.uuidID);

                            DevExpress.XtraGrid.Views.Grid.GridView currGridView = GetGridViewBySelectedPage();
                            if (currGridView == gridViewDocNotActive)
                            {
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_DOCMONEY, objBudgetDoc.Money);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_DOCMONEYAGREE, objBudgetDoc.MoneyAgree);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_BUDGETDOCTYPE_NAME, objBudgetDoc.DocType.Name);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_DEBITARTICLE_NAME, objBudgetDoc.BudgetItem.BudgetItemFullName);
                            }
                            else if (currGridView == gridViewDocWorked)
                            {
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colB_DOCMONEY, objBudgetDoc.Money);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colB_DOCMONEYAGREE, objBudgetDoc.MoneyAgree);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colB_BUDGETDOCTYPE_NAME, objBudgetDoc.DocType.Name);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colB_DEBITARTICLE_NAME, objBudgetDoc.BudgetItem.BudgetItemFullName);
                            }
                            else if (currGridView == gridViewDocWork)
                            {
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colA_DOCMONEY, objBudgetDoc.Money);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colA_DOCMONEYAGREE, objBudgetDoc.MoneyAgree);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colA_BUDGETDOCTYPE_NAME, objBudgetDoc.DocType.Name);
                                currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colA_DEBITARTICLE_NAME, objBudgetDoc.BudgetItem.BudgetItemFullName);
                            }

                            currGridView.RefreshRow(currGridView.FocusedRowHandle);
                            Cursor = Cursors.Default;
                        }

                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "ChangeBudgetDocType.\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally 
            {
                Cursor = Cursors.Default;
            }

            return;
        }

        private void mitemChangeDocType_Click(object sender, EventArgs e)
        {
            try
            {
                System.Guid uuidBudgetDocID = GetBudgetDocID();
                if (uuidBudgetDocID.CompareTo(System.Guid.Empty) != 0)
                {
                    // ������ ������ ������ � ������
                    ERP_Budget.Common.CBudgetDoc objBudgetDoc = GetBudgetDocByID(uuidBudgetDocID);
                    if (objBudgetDoc != null)
                    {
                        ChangeBudgetDocType(objBudgetDoc);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ����� ���� ���������� ���������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region �������������� �������� � ��������� ���������
        /// <summary>
        /// �������������� �������� "��������" � ��������� ���������
        /// </summary>
        /// <param name="objBudgetDoc">��������� ��������</param>
        private void ChangeBudgetDocCompany(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            if (objBudgetDoc == null) { return; }
            try
            {
                using (frmChangeDate objfrmChangeDate = new frmChangeDate(m_objProfile))
                {
                    objfrmChangeDate.OpenForChangeCompany(objBudgetDoc, ERP_Budget.Common.CUser.GetUsersInfo(this.m_objProfile));
                    if (objfrmChangeDate.DialogResult == DialogResult.OK)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView currGridView = GetGridViewBySelectedPage();

                        if (currGridView == gridViewDocNotActive)
                        {
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_COMPANY_GUID_ID, objBudgetDoc.Company.uuidID);
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_COMPANY_NAME, objBudgetDoc.Company.CompanyAcronym);
                        }
                        else if (currGridView == gridViewDocWork)
                        {
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colA_COMPANY_NAME, objBudgetDoc.Company.CompanyAcronym);
                        }
                        else if (currGridView == gridViewDocWorked)
                        {
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colB_COMPANY_GUID_ID, objBudgetDoc.Company.uuidID);
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colB_COMPANY_NAME, objBudgetDoc.Company.CompanyAcronym);
                        }

                        currGridView.RefreshRow(currGridView.FocusedRowHandle);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ��������� �������� � ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;

        }

        private void mitemChangeCompany_Click(object sender, EventArgs e)
        {
            try
            {
                System.Guid uuidBudgetDocID = GetBudgetDocID();
                if (uuidBudgetDocID.CompareTo(System.Guid.Empty) != 0)
                {
                    ChangeBudgetDocCompany( GetBudgetDocByID(uuidBudgetDocID) );
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ��������� �������� � ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region �������������� ����� ������ � ��������� ���������
        /// <summary>
        /// �������������� �������� "����� ������" � ��������� ���������
        /// </summary>
        /// <param name="objBudgetDoc">��������� ��������</param>
        private void ChangeBudgetDocPaymentType(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            if (objBudgetDoc == null) { return; }
            try
            {
                using (frmChangeDate objfrmChangeDate = new frmChangeDate(m_objProfile))
                {
                    objfrmChangeDate.OpenForChangePaymentType(objBudgetDoc, ERP_Budget.Common.CUser.GetUsersInfo(this.m_objProfile));
                    if (objfrmChangeDate.DialogResult == DialogResult.OK)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView currGridView = GetGridViewBySelectedPage();
                        if (currGridView == gridViewDocNotActive)
                        {
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_PAYMENTTYPE_NAME, objBudgetDoc.PaymentType.m_strName);
                            currGridView.RefreshRow(currGridView.FocusedRowHandle);
                        }
                        else if (currGridView == gridViewDocWork)
                        {
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colA_PAYMENTTYPE_NAME, objBudgetDoc.PaymentType.m_strName);
                        }
                        else if (currGridView == gridViewDocWorked)
                        {
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colB_PAYMENTTYPE_NAME, objBudgetDoc.PaymentType.m_strName);
                        }
                        
                        currGridView.RefreshRow(currGridView.FocusedRowHandle);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ��������� ����� ������ � ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;

        }

        private void mitemChangePaymentType_Click(object sender, EventArgs e)
        {
            try
            {
                System.Guid uuidBudgetDocID = GetBudgetDocID();
                if (uuidBudgetDocID.CompareTo(System.Guid.Empty) != 0)
                {
                    ChangeBudgetDocPaymentType(GetBudgetDocByID(uuidBudgetDocID));
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ��������� ����� ������ � ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region �������������� ���� ������ � ��������� ���������
        private void mitemChangeDateBudgetDoc_Click(object sender, EventArgs e)
        {
            try
            {
                System.Guid uuidBudgetDocID = GetBudgetDocID();
                if (uuidBudgetDocID.CompareTo(System.Guid.Empty) != 0)
                {
                    ChangeBudgetDocPaymentDate(GetBudgetDocByID(uuidBudgetDocID));
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ��������� ���� ������ ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// �������������� ���� ������ � ���� ������
        /// </summary>
        /// <param name="objBudgetDoc">������</param>
        private void ChangeBudgetDocDateAndPaymentDate(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            if (objBudgetDoc == null) { return; }
            try
            {
                using (frmChangeDate objfrmChangeDate = new frmChangeDate(m_objProfile))
                {
                    objfrmChangeDate.OpenForChangeBudgetDocDate(objBudgetDoc, ERP_Budget.Common.CUser.GetUsersInfo(this.m_objProfile));
                    if (objfrmChangeDate.DialogResult == DialogResult.OK)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView currGridView = GetGridViewBySelectedPage();
                        if (currGridView == gridViewDocNotActive)
                        {
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_DOCDATE, objBudgetDoc.Date);
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_DATESTATE, objBudgetDoc.PaymentDate);
                            currGridView.RefreshRow(currGridView.FocusedRowHandle);
                        }
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ��������� ���� ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        /// <summary>
        /// �������������� ���� ������ ������
        /// </summary>
        /// <param name="objBudgetDoc">������</param>
        private void ChangeBudgetDocPaymentDate(ERP_Budget.Common.CBudgetDoc objBudgetDoc)
        {
            if (objBudgetDoc == null) { return; }
            try
            {
                using (frmChangeDate objfrmChangeDate = new frmChangeDate(m_objProfile))
                {
                    objfrmChangeDate.OpenForChangePaymentDate(objBudgetDoc, ERP_Budget.Common.CUser.GetUsersInfo(this.m_objProfile));
                    if (objfrmChangeDate.DialogResult == DialogResult.OK)
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView currGridView = GetGridViewBySelectedPage();
                        if (currGridView == gridViewDocNotActive)
                        {
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_DOCDATE, objBudgetDoc.Date);
                            currGridView.SetRowCellValue(currGridView.FocusedRowHandle, colC_DATESTATE, objBudgetDoc.PaymentDate);
                            currGridView.RefreshRow(currGridView.FocusedRowHandle);
                        }
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("������ ��������� ���� ������ ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        public DevExpress.XtraBars.BarManager GetbarManager()
        {
            barStatus.Visible = true;
            barManager.StatusBar = barStatus;
            return barManager;
        }


    }

    public class ViewBudgetDocList : PlugIn.IClassTypeView
    {
        public override void Run(UniXP.Common.MENUITEM objMenuItem, System.String strCaption)
        {
            frmBudgetDocList obj = new frmBudgetDocList(objMenuItem.objProfile, objMenuItem);
            obj.Text = strCaption;
            obj.m_bOutlookMode = false;
            //obj.m_bOutlookMode = true;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }

        public override void InitUserControl(UniXP.Common.MENUITEM objMenuItem,
            System.Windows.Forms.UserControl objUserControl)
        {
            if (objMenuItem.objProfile.GetClientsRight().m_bBlock)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("������������ {0} ������������.\n������ � ������� ������.", objMenuItem.objProfile.m_strLastName), "��������!",
                  System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            else
            {
                frmBudgetDocList obj = new frmBudgetDocList(objMenuItem.objProfile, objMenuItem) { Cursor = System.Windows.Forms.Cursors.WaitCursor };
                objUserControl.Controls.Clear();
                foreach (System.Windows.Forms.Control objControl in obj.Controls)
                {
                    objUserControl.Controls.Add(objControl);
                }
                DevExpress.XtraBars.BarManager barManager = obj.GetbarManager();
                barManager.Form = objUserControl;
                obj.m_bOutlookMode = true;

                //obj.frmBudgetDocList_Load();
                obj.LoadFindParams();

                //obj.LoadBudgetDocListAsync();
                obj.LoadBudgetDocListForOutlook();
                
                obj.RestoreLayoutFromRegistry();

            }

            return;
        }

    }


}