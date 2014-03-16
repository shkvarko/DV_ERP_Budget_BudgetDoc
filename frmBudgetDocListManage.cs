using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErpBudgetBudgetDoc
{
    public partial class frmBudgetDocListManage : DevExpress.XtraEditors.XtraForm
    {
        #region Переменные, Свойства, Константы
        private UniXP.Common.CProfile m_objProfile;
        private const System.String strNodeDate = "Дата";
        private const System.String strNodeDepartament = "Служба";
        private const System.String strNodeCompany = "Компания";
        private const System.String strNodePaymentType = "Вид платежа";
        private const System.String strNodeBudgetItem = "Статья расходов";
        private const System.String strNodeBudgetItemList = "Список подстатей";
        private const System.String strNodeReciep = "Получатель";
        private const System.String strNodeObject = "Цель";
        private const System.String strNodeDocument = "Документальное обоснование";
        private const System.String strNodeDescrpn = "Примечание";
        private const System.String strNodeMoney = "Сумма";
        private const System.String strNodeMoneyBudget = "Сумма, EUR";
        private const System.String strNodeCurrency = "Валюта";
        private const System.String strNodeOwner = "Инициатор";
        private const System.String strNodeID = "УИ";
        #endregion

        #region Конструктор
        public frmBudgetDocListManage( UniXP.Common.CProfile objProfile )
        {
            m_objProfile = objProfile;

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler( MyResolveEventHandler );

            InitializeComponent();
        }


        private System.Reflection.Assembly MyResolveEventHandler( object sender, ResolveEventArgs args )
        {
            System.Reflection.Assembly MyAssembly = null;
            System.Reflection.Assembly objExecutingAssemblies = System.Reflection.Assembly.GetExecutingAssembly();

            System.Reflection.AssemblyName[] arrReferencedAssmbNames=objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            System.String strDllName = "";
            foreach( System.Reflection.AssemblyName strAssmbName in arrReferencedAssmbNames )
            {

                //Check for the assembly names that have raised the "AssemblyResolve" event.
                if( strAssmbName.FullName.Substring( 0, strAssmbName.FullName.IndexOf( "," ) ) == args.Name.Substring( 0, args.Name.IndexOf( "," ) ) )
                {
                    strDllName = args.Name.Substring( 0, args.Name.IndexOf( "," ) ) + ".dll";
                    break;
                }

            }
            if( strDllName != "" )
            {
                System.String strFileFullName = "";
                System.Boolean bError = false;
                foreach( System.String strPath in this.m_objProfile.ResourcePathList )
                {
                    //Load the assembly from the specified path. 
                    strFileFullName = strPath + "\\" + strDllName;
                    if( System.IO.File.Exists( strFileFullName ) )
                    {
                        try
                        {
                            MyAssembly = System.Reflection.Assembly.LoadFrom( strFileFullName );
                            break;
                        }
                        catch( System.Exception f )
                        {
                            bError = true;
                            DevExpress.XtraEditors.XtraMessageBox.Show( "Ошибка загрузки библиотеки: " + 
                                strFileFullName + "\n\nТекст ошибки: " + f.Message, "Ошибка",
                                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
                        }
                    }
                    if( bError ) { break; }
                }
            }

            //Return the loaded assembly.
            return MyAssembly;
        }
        #endregion

        #region Журнал заявок

        /// <summary>
        /// Загружает журнал заявок
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        private void LoadBudgetDocList()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                treelistBudgetDoc.Nodes.Clear();
                System.Guid uuidCompanyID = System.Guid.Empty;
                System.Guid uuidBudgetDepID = System.Guid.Empty;
                System.Guid uuidDebitArticleID = System.Guid.Empty;
                System.Int32 iUserID = 0;
                if (cboxCompany.Text != "")
                {
                    if (cboxCompany.SelectedItem != null)
                    {
                        uuidCompanyID = ((ERP_Budget.Common.CCompany)cboxCompany.SelectedItem).uuidID;
                    }                    
                }
                if (cboxDebitArticle.Text != "")
                {
                    if (cboxDebitArticle.SelectedItem != null)
                    {
                        uuidDebitArticleID = ((ERP_Budget.Common.CDebitArticle)cboxDebitArticle.SelectedItem).uuidID;
                    }
                }
                if (cboxDepartament.Text != "")
                {
                    if (cboxDepartament.SelectedItem != null)
                    {
                        uuidBudgetDepID = ((ERP_Budget.Common.CBudgetDep)cboxDepartament.SelectedItem).uuidID;
                    }
                }
                if (cboxOwnerUser.Text != "")
                {
                    if (cboxOwnerUser.SelectedItem != null)
                    {
                        iUserID = ((ERP_Budget.Common.CUser)cboxOwnerUser.SelectedItem).ulID;
                    }
                }
                List<ERP_Budget.Common.CManagementBudgetDoc> objBudgetDocList = ERP_Budget.Common.CManagementBudgetDoc.GetBudgetDocListManage(m_objProfile,
                    uuidCompanyID, uuidDebitArticleID, uuidBudgetDepID, iUserID, dtDocDateBegin.DateTime, dtDocDateEnd.DateTime);
                if ((objBudgetDocList != null) && (objBudgetDocList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CManagementBudgetDoc objBudgetDoc in objBudgetDocList)
                    {
                        //добавляем узел в дерево
                        DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                            treelistBudgetDoc.AppendNode(new object[] { objBudgetDoc.OwnerUser.UserFullName,
                                objBudgetDoc.Date, objBudgetDoc.BudgetDep.Name, objBudgetDoc.Money, 
                                objBudgetDoc.Currency.CurrencyCode, objBudgetDoc.MoneyAgree,
                                objBudgetDoc.BudgetItem.BudgetItemFullName, objBudgetDoc.Company.CompanyAcronym, objBudgetDoc.DocState.Name }, null);
                        objNode.Tag = objBudgetDoc;
                    }

                }
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                "Ошибка загрузки журналов заявок.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
            finally // очищаем занимаемые ресурсы
            {
                if (treelistBudgetDoc.Nodes.Count > 0)
                {
                    treelistBudgetDoc.FocusedNode = treelistBudgetDoc.Nodes[0];
                    ShowBudgetDocProperties((ERP_Budget.Common.CManagementBudgetDoc)treelistBudgetDoc.FocusedNode.Tag);
                }

                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return ;
        }
        /// <summary>
        /// Обновляет список заявок
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        private void RefreshBudgetDocList()
        {
            try
            {
                // обновляем информацию
                LoadBudgetDocList();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( "Ошибка обновления списка заявок.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
            return ;
        }

        private void barBtnRefres_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                RefreshBudgetDocList();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( "Ошибка обновления списка заявок.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshBudgetDocList();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка обновления списка заявок.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Открытие формы
        private void RefreshComboBoxForSearch()
        {
            try
            {
                dtDocDateBegin.DateTime = System.DateTime.Today;
                dtDocDateEnd.DateTime = System.DateTime.Today;
                cboxDebitArticle.Properties.Items.Clear();
                cboxDepartament.Properties.Items.Clear();
                cboxOwnerUser.Properties.Items.Clear();
                cboxCompany.Properties.Items.Clear();

                // статьи расходов
                List<ERP_Budget.Common.CDebitArticle> objDebitArticleList = ERP_Budget.Common.CDebitArticle.GetDebitArticleList(m_objProfile);
                if ((objDebitArticleList != null) && (objDebitArticleList.Count > 0))
                {
                    cboxDebitArticle.Properties.Items.Add("");
                    foreach (ERP_Budget.Common.CDebitArticle objDebitArticle in objDebitArticleList)
                    {
                        cboxDebitArticle.Properties.Items.Add(objDebitArticle);
                    }
                }

                // службы
                List<ERP_Budget.Common.CBudgetDep> objBudgetDepList = ERP_Budget.Common.CBudgetDep.GetBudgetDepsList(m_objProfile, false);
                if ((objBudgetDepList != null) && (objBudgetDepList.Count > 0))
                {
                    cboxDepartament.Properties.Items.Add("");
                    foreach (ERP_Budget.Common.CBudgetDep objBudgetDep in objBudgetDepList)
                    {
                        cboxDepartament.Properties.Items.Add(objBudgetDep);
                    }
                }

                // пользователи
                List<ERP_Budget.Common.CUser> objUserList = ERP_Budget.Common.CUser.GetUsersList(m_objProfile);
                if ((objUserList != null) && (objUserList.Count > 0))
                {
                    cboxOwnerUser.Properties.Items.Add("");
                    foreach (ERP_Budget.Common.CUser objUser in objUserList)
                    {
                        cboxOwnerUser.Properties.Items.Add(objUser);
                    }
                }

                // компании
                List<ERP_Budget.Common.CCompany> objCompanyList = ERP_Budget.Common.CCompany.GetCompanyList(m_objProfile);
                if ((objCompanyList != null) && (objCompanyList.Count > 0))
                {
                    cboxCompany.Properties.Items.Add("");
                    foreach (ERP_Budget.Common.CCompany objCompany in objCompanyList)
                    {
                        cboxCompany.Properties.Items.Add(objCompany);
                    }
                }
                SetPointPropertiesReadOnly(true);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления выпадающих списков.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Обновляет выпадающие списки для свойств маршрута
        /// </summary>
        private void RefreshComboBoxForRoute()
        {
            try
            {
                cboxPointGroup.Properties.Items.Clear();
                List<ERP_Budget.Common.CRoutePointGroup> objRoutePointGroupList = ERP_Budget.Common.CRoutePointGroup.GetRoutePointGroupList(m_objProfile);
                if ((objRoutePointGroupList != null) && (objRoutePointGroupList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CRoutePointGroup objRoutePointGroup in objRoutePointGroupList)
                    {
                        cboxPointGroup.Properties.Items.Add(objRoutePointGroup);
                    }
                }
                cboxPointStateEvent.Properties.Items.Clear();
                List<ERP_Budget.Common.CBudgetDocEvent> objBudgetDocEventList = ERP_Budget.Common.CBudgetDocEvent.GetBudgetDocEventList(m_objProfile);
                if ((objBudgetDocEventList != null) && (objBudgetDocEventList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CBudgetDocEvent objBudgetDocEvent in objBudgetDocEventList)
                    {
                        cboxPointStateEvent.Properties.Items.Add(objBudgetDocEvent);
                    }
                }
                cboxPointStateIn.Properties.Items.Clear();
                cboxPointStateOut.Properties.Items.Clear();
                List<ERP_Budget.Common.CBudgetDocState> objBudgetDocStateList = ERP_Budget.Common.CBudgetDocState.GetBudgetDocStateListObj(m_objProfile);
                if ((objBudgetDocStateList != null) && (objBudgetDocStateList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CBudgetDocState objBudgetDocState in objBudgetDocStateList)
                    {
                        cboxPointStateIn.Properties.Items.Add(objBudgetDocState);
                        cboxPointStateOut.Properties.Items.Add(objBudgetDocState);
                    }
                }
                cboxPointUser.Properties.Items.Clear();
                List<ERP_Budget.Common.CUser> objUserList = ERP_Budget.Common.CUser.GetUsersList(m_objProfile);
                if ((objUserList != null) && (objUserList.Count > 0))
                {
                    foreach (ERP_Budget.Common.CUser objUser in objUserList)
                    {
                        cboxPointUser.Properties.Items.Add(objUser);
                    }
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления выпадающих списков.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        private void frmBudgetDocList_Load( object sender, EventArgs e )
        {
            try
            {
                RefreshComboBoxForSearch();
                RefreshComboBoxForRoute();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                "Ошибка открытия формы.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
            return;
        }
        #endregion

        #region Отображение свойств заявки
        /// <summary>
        /// Отображает свойства заявки в элементах управления
        /// </summary>
        /// <param name="objBudgetDoc">объект "заявка"</param>
        private void ShowBudgetDocProperties(ERP_Budget.Common.CManagementBudgetDoc objBudgetDoc)
        {
            try
            {
                btnEditRoute.Enabled = false;
                treeListDocState.Nodes.Clear();
                treeListTrn.Nodes.Clear();
                treeListRoute.Nodes.Clear();

                if (objBudgetDoc == null) { return; }

                if (treeListDocProperties.Nodes.Count == 0)
                {
                    treeListDocProperties.AppendNode(new object[] { strNodeID }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeDate }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeOwner }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeDepartament }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeMoney }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeCurrency }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeMoneyBudget }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeCompany }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodePaymentType }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeBudgetItem }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeBudgetItemList }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeObject }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeReciep }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeDocument }, null);
                    treeListDocProperties.AppendNode(new object[] { strNodeDescrpn }, null);
                }
                if (treeListDocProperties.Nodes.Count > 0)
                {
                    treeListDocProperties.Nodes[0].SetValue(colDocPropertieValue, objBudgetDoc.uuidID);
                    treeListDocProperties.Nodes[0].Tag = objBudgetDoc.uuidID;
                    treeListDocProperties.Nodes[1].SetValue(colDocPropertieValue, objBudgetDoc.Date);
                    treeListDocProperties.Nodes[1].Tag = objBudgetDoc.Date;                    
                    treeListDocProperties.Nodes[2].SetValue(colDocPropertieValue, objBudgetDoc.OwnerUser.UserFullName);
                    treeListDocProperties.Nodes[2].Tag = objBudgetDoc.OwnerUser;
                    treeListDocProperties.Nodes[3].SetValue(colDocPropertieValue, objBudgetDoc.BudgetDep);
                    treeListDocProperties.Nodes[3].Tag = objBudgetDoc.BudgetDep;
                    treeListDocProperties.Nodes[4].SetValue(colDocPropertieValue, objBudgetDoc.Money);
                    treeListDocProperties.Nodes[4].Tag = objBudgetDoc.Money;
                    treeListDocProperties.Nodes[5].SetValue(colDocPropertieValue, objBudgetDoc.Currency.CurrencyCode);
                    treeListDocProperties.Nodes[5].Tag = objBudgetDoc.Currency;
                    treeListDocProperties.Nodes[6].SetValue(colDocPropertieValue, objBudgetDoc.MoneyAgree);
                    treeListDocProperties.Nodes[6].Tag = objBudgetDoc.MoneyAgree;

                    treeListDocProperties.Nodes[7].SetValue(colDocPropertieValue, objBudgetDoc.Company);
                    treeListDocProperties.Nodes[7].Tag = objBudgetDoc.Company;
                    treeListDocProperties.Nodes[8].SetValue(colDocPropertieValue, objBudgetDoc.PaymentType);
                    treeListDocProperties.Nodes[8].Tag = objBudgetDoc.PaymentType;
                    treeListDocProperties.Nodes[9].SetValue(colDocPropertieValue, objBudgetDoc.BudgetItem);
                    treeListDocProperties.Nodes[9].Tag = objBudgetDoc.BudgetItem;
                    //treeListDocProperties.Nodes[9].SetValue(colDocPropertieValue, objBudgetDoc.BudgetItemList);
                    treeListDocProperties.Nodes[10].Tag = objBudgetDoc.BudgetItemList;
                    treeListDocProperties.Nodes[11].SetValue(colDocPropertieValue, objBudgetDoc.Objective);
                    treeListDocProperties.Nodes[11].Tag = objBudgetDoc.Objective;
                    treeListDocProperties.Nodes[12].SetValue(colDocPropertieValue, objBudgetDoc.Recipient);
                    treeListDocProperties.Nodes[12].Tag = objBudgetDoc.Recipient;
                    treeListDocProperties.Nodes[13].SetValue(colDocPropertieValue, objBudgetDoc.DocBasis);
                    treeListDocProperties.Nodes[13].Tag = objBudgetDoc.DocBasis;
                    treeListDocProperties.Nodes[14].SetValue(colDocPropertieValue, objBudgetDoc.Description);
                    treeListDocProperties.Nodes[14].Tag = objBudgetDoc.Description;
                    treeListDocProperties.FocusedNode = treeListDocProperties.Nodes[0];
                }


                // история состояний
                if (objBudgetDoc.StateHistoryList != null)
                {
                    foreach (ERP_Budget.Common.structBudgetDocStateHistory objDocStateHistory in objBudgetDoc.StateHistoryList)
                    {
                        //добавляем узел в дерево
                        DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                            treeListDocState.AppendNode(new object[] { objDocStateHistory.HistoryDate, 
                                objDocStateHistory.BudgetDocState.Name, objDocStateHistory.UserHistory.UserFullName }, null);
                        objNode.Tag = objDocStateHistory;
                    }
                }

                // история проводок
                if (objBudgetDoc.AccountTransnList != null)
                {
                    foreach (ERP_Budget.Common.CAccountTransn objAccountTransn in objBudgetDoc.AccountTransnList)
                    {
                        //добавляем узел в дерево
                        DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                            treeListTrn.AppendNode(new object[] { objAccountTransn.Date, 
                                objAccountTransn.Money, objAccountTransn.Currency.CurrencyCode,
                                objAccountTransn.OperName, objAccountTransn.User.UserFullName }, null);
                        objNode.Tag = objAccountTransn;
                    }
                }

                // маршрут
                btnEditRoute.Enabled = ( (objBudgetDoc.Route != null) && (objBudgetDoc.Route.RoutePointList != null) && (objBudgetDoc.Route.RoutePointList.Count > 0) );
                if ((objBudgetDoc.Route != null) && (objBudgetDoc.Route.RoutePointList != null) &&
                    (objBudgetDoc.Route.RoutePointList.Count > 0))
                {
                    System.Boolean bFindCurPoint = false;
                    System.Boolean bIsCheck = false;
                    System.Guid uuidGroupID = System.Guid.Empty;
                    DevExpress.XtraTreeList.Nodes.TreeListNode objLastRootNode = null;
                    foreach (ERP_Budget.Common.CRoutePoint objRoutePoint in objBudgetDoc.Route.RoutePointList)
                    {
                        // нужно определить, в этой ли точке маршрута находится заявка
                        if ((objBudgetDoc.DocState != null) && (objBudgetDoc.IsActive) &&
                            (objRoutePoint.BudgetDocStateIN != null))
                        {
                            if (objRoutePoint.BudgetDocStateIN.uuidID.CompareTo(objBudgetDoc.DocState.uuidID) == 0)
                            {
                                bFindCurPoint = true;
                            }
                        }

                        bIsCheck = (bFindCurPoint == false);

                        if (objRoutePoint.RoutePointGroup.uuidID.CompareTo(uuidGroupID) != 0)
                        {
                            uuidGroupID = objRoutePoint.RoutePointGroup.uuidID;
                            // группа действий
                            DevExpress.XtraTreeList.Nodes.TreeListNode objNodeGroup =
                                treeListRoute.AppendNode(new object[] { objRoutePoint.RoutePointGroup.Name, null, bIsCheck }, null);
                            objLastRootNode = objNodeGroup;

                        }
                        //if (objRoutePoint.ShowInDocument == false) { continue; }

                        // действие
                        DevExpress.XtraTreeList.Nodes.TreeListNode objNodeEvent =
                            treeListRoute.AppendNode(new object[] { objRoutePoint.UserEvent.UserFullName, objRoutePoint.BudgetDocEvent.Name, bIsCheck }, objLastRootNode);
                        objNodeEvent.Tag = objRoutePoint;

                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка отображения свойств заявки.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        private void treeListDocProperties_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                propertiesView.SelectedObject = null;

                if ((treeListDocProperties.Nodes.Count > 0) && (treeListDocProperties.FocusedNode != null) &&
                    (treeListDocProperties.FocusedNode.Tag != null))
                {
                    propertiesView.SelectedObject = treeListDocProperties.FocusedNode.Tag;

                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка смены записи.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        private void treelistBudgetDoc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if ((treelistBudgetDoc.Nodes.Count > 0) && (treelistBudgetDoc.FocusedNode != null) &&
                    (treelistBudgetDoc.FocusedNode.Tag != null))
                {
                    ERP_Budget.Common.CManagementBudgetDoc objBudgetDoc = (ERP_Budget.Common.CManagementBudgetDoc)treelistBudgetDoc.FocusedNode.Tag;
                    if (objBudgetDoc != null)
                    {
                        ShowBudgetDocProperties(objBudgetDoc);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка смены записи.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        /// <summary>
        /// Отображает свойства заявки в элементах управления более подробно
        /// </summary>
        /// <param name="objBudgetDoc">объект "заявка"</param>
        private void ShowBudgetDocPropertiesDetail(ERP_Budget.Common.CManagementBudgetDoc objBudgetDoc)
        {
            try
            {
                if (objBudgetDoc == null) { return; }

                objBudgetDoc.Init(m_objProfile, objBudgetDoc.uuidID);
                objBudgetDoc.Route.LoadPointList(m_objProfile, objBudgetDoc.uuidID, 0); 
                ShowBudgetDocProperties(objBudgetDoc);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка отображения свойств заявки подробно.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        private void mitemDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if ((treelistBudgetDoc.Nodes.Count > 0) && (treelistBudgetDoc.FocusedNode != null) &&
                    (treelistBudgetDoc.FocusedNode.Tag != null))
                {
                    ERP_Budget.Common.CManagementBudgetDoc objBudgetDoc = (ERP_Budget.Common.CManagementBudgetDoc)treelistBudgetDoc.FocusedNode.Tag;
                    if (objBudgetDoc != null)
                    {
                        ShowBudgetDocPropertiesDetail(objBudgetDoc);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка детализации записи.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        /// <summary>
        /// отображает информацию о точке маршрута в элементах управления
        /// </summary>
        /// <param name="objRoutePoint">точка маршрута</param>
        private void ShowRoutePointProperties(ERP_Budget.Common.CRoutePoint objRoutePoint)
        {
            try
            {
                if (objRoutePoint == null) { return; }
                {
                    // группа
                    foreach (object objRoutePointGroup in cboxPointGroup.Properties.Items)
                    {
                        if (((ERP_Budget.Common.CRoutePointGroup)objRoutePointGroup).uuidID.CompareTo(objRoutePoint.RoutePointGroup.uuidID) == 0)
                        {
                            cboxPointGroup.SelectedItem = objRoutePointGroup;
                            break;
                        }
                    }
                    // начальное состояние
                    if (objRoutePoint.BudgetDocStateIN != null)
                    {
                        foreach (object objStateIn in cboxPointStateIn.Properties.Items)
                        {
                            if (((ERP_Budget.Common.CBudgetDocState)objStateIn).uuidID.CompareTo(objRoutePoint.BudgetDocStateIN.uuidID) == 0)
                            {
                                cboxPointStateIn.SelectedItem = objStateIn;
                                break;
                            }
                        }
                    }
                    // действие
                    foreach (object objEvent in cboxPointStateEvent.Properties.Items)
                    {
                        if (((ERP_Budget.Common.CBudgetDocEvent)objEvent).uuidID.CompareTo(objRoutePoint.BudgetDocEvent.uuidID) == 0)
                        {
                            cboxPointStateEvent.SelectedItem = objEvent;
                            break;
                        }
                    }
                    // конечное состояние
                    foreach (object objStateOut in cboxPointStateOut.Properties.Items)
                    {
                        if (((ERP_Budget.Common.CBudgetDocState)objStateOut).uuidID.CompareTo(objRoutePoint.BudgetDocStateOUT.uuidID) == 0)
                        {
                            cboxPointStateOut.SelectedItem = objStateOut;
                            break;
                        }
                    }
                    // пользователь
                    foreach (object objUser in cboxPointUser.Properties.Items)
                    {
                        if (((ERP_Budget.Common.CUser)objUser).ulID == objRoutePoint.UserEvent.ulID)
                        {
                            cboxPointUser.SelectedItem = objUser;
                            break;
                        }
                    }
                    // вход
                    checkPointEnter.Checked = objRoutePoint.IsEnter;
                    // выход
                    checkPointExit.Checked = objRoutePoint.IsExit;
                    // показывать
                    checkPointShow.Checked = objRoutePoint.ShowInDocument;
                    btnEditRoute.Enabled = true;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка детализации свойств точки маршрута.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        /// <summary>
        /// устанавливает свойство ReadOnly элементов управления для свойств точки маршрута
        /// </summary>
        /// <param name="bReadOnly">значение свойства ReadOnly</param>
        private void SetPointPropertiesReadOnly(System.Boolean bReadOnly)
        {
            try
            {
                cboxPointGroup.Properties.ReadOnly = bReadOnly;
                cboxPointStateEvent.Properties.ReadOnly = bReadOnly;
                cboxPointStateIn.Properties.ReadOnly = bReadOnly;
                cboxPointStateOut.Properties.ReadOnly = bReadOnly;
                cboxPointUser.Properties.ReadOnly = bReadOnly;
                checkPointEnter.Properties.ReadOnly = bReadOnly;
                checkPointExit.Properties.ReadOnly = bReadOnly;
                checkPointShow.Properties.ReadOnly = bReadOnly;
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "SetcboxPointReadOnly.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        /// <summary>
        /// отображает информацию о точке маршрута в элементах управления
        /// </summary>
        /// <param name="objNode">узел дерева с информацией о точке маршрута</param>
        private void RefreshRoutePointProperties(DevExpress.XtraTreeList.Nodes.TreeListNode objNode)
        {
            try
            {
                cboxPointGroup.SelectedItem = null;
                cboxPointStateEvent.SelectedItem = null;
                cboxPointStateIn.SelectedItem = null;
                cboxPointStateOut.SelectedItem = null;
                cboxPointUser.SelectedItem = null;
                checkPointEnter.Checked = false;
                checkPointExit.Checked = false;
                checkPointShow.Checked = false;


                if ((objNode == null) || (objNode.Tag == null)) { return; }

                ShowRoutePointProperties((ERP_Budget.Common.CRoutePoint)objNode.Tag);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления свойств точки маршрута.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        private void treeListRoute_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (treeListRoute.FocusedNode == null) { return; }
                RefreshRoutePointProperties(treeListRoute.FocusedNode);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка смены точки маршрута.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        #endregion

    }

    public class BudgetDocListManage : PlugIn.IClassTypeView
    {
        public override void Run( UniXP.Common.MENUITEM objMenuItem, System.String strCaption )
        {
            frmBudgetDocListManage obj = new frmBudgetDocListManage( objMenuItem.objProfile );
            obj.Text = strCaption;
            obj.MdiParent = objMenuItem.objProfile.m_objMDIManager.MdiParent;
            obj.Visible = true;
        }
    }

}
