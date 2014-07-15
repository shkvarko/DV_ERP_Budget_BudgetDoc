using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Budget.Common;
using System.Linq;

namespace ErpBudgetBudgetDoc
{
    public enum enumChahgedObjectType
    {
        Unkown = -1,
        BudgetDocDate = 0,
        Company = 1,
        PaymentType = 2,
        PaymentDate = 3
    }

    public partial class frmChangeDate : DevExpress.XtraEditors.XtraForm
    {
        #region Свойства
        private ERP_Budget.Common.CBudgetDoc m_objBudgetDoc;
        private ERP_Budget.Common.CUser m_objCurrentUser;
        private UniXP.Common.CProfile m_objProfile;
        private enumChahgedObjectType m_enChahgedObjectType;
        List<CBudgetDocPaymentItemArjive> m_objPaymentsListArjive;
        List<CCurrency> m_objCurrencyList;
        #endregion

        #region Конструктор
        public frmChangeDate( UniXP.Common.CProfile objProfile )
        {
            m_objBudgetDoc = null;
            m_objCurrentUser = null;
            m_objCurrencyList = null;
            m_objProfile = objProfile;
            m_enChahgedObjectType = enumChahgedObjectType.Unkown;
            
            InitializeComponent();

            dtNewDocDate.EditValue = null;
            dtNewPaymentDate.EditValue = null;
            m_objPaymentsListArjive = null;
            tabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }
        #endregion

        #region Редактирование даты
        /// <summary>
        /// Открывает форму с настройками для изменения даты
        /// </summary>
        /// <param name="objBudgetDoc">бюджетный документ</param>
        /// <param name="objCurrentUser">пользователь</param>
        public void OpenForChangeBudgetDocDate(ERP_Budget.Common.CBudgetDoc objBudgetDoc, ERP_Budget.Common.CUser objCurrentUser)
        {
            try
            {
                m_objBudgetDoc = objBudgetDoc;
                m_objCurrentUser = objCurrentUser;
                m_enChahgedObjectType = enumChahgedObjectType.BudgetDocDate;
                dtNewDocDate.DateTime = m_objBudgetDoc.Date;
                dtNewPaymentDate.DateTime = m_objBudgetDoc.PaymentDate;

                tabControl.SelectedTabPage = tabPageChangeDate;
                ShowDialog();
            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("OpenForChangeBudgetDocDate.\n\nТекст ошибки : " + e.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }

        /// <summary>
        /// Редактирование в БД даты оплаты бюджетного документа
        /// </summary>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        private System.Boolean ChangeBudgetDocDate(ref System.String strErr)
        {
            System.Boolean bRet = false;
            try
            {
                if (m_objBudgetDoc.ChangePaymentDate(m_objProfile, m_objCurrentUser.ulID, dtNewDocDate.DateTime, dtNewPaymentDate.DateTime) == true)
                {
                    m_objBudgetDoc.Date = dtNewDocDate.DateTime;
                    m_objBudgetDoc.PaymentDate = dtNewPaymentDate.DateTime;

                    bRet = true;
                }
            }
            catch (System.Exception e)
            {
                strErr += ("Ошибка изменения даты бюджетного документа.\n\nТекст ошибки : " + e.Message);
            }
            return bRet;
        }

        #endregion

        #region Редактирование компании
        /// <summary>
        /// Открывает форму с настройками для редактирования компании
        /// </summary>
        /// <param name="objBudgetDoc">бюджетный документ</param>
        /// <param name="objCurrentUser">пользователь</param>
        public void OpenForChangeCompany(ERP_Budget.Common.CBudgetDoc objBudgetDoc, ERP_Budget.Common.CUser objCurrentUser)
        {
            try
            {
                m_objBudgetDoc = objBudgetDoc;
                m_objCurrentUser = objCurrentUser;

                m_enChahgedObjectType = enumChahgedObjectType.Company;

                cboxCompany.Properties.Items.Clear();
                cboxCompanyNew.Properties.Items.Clear();

                List<CCompany> objCompanyList = CCompany.GetCompanyList(m_objProfile);

                if ((objCompanyList != null) && (objCompanyList.Count > 0))
                {
                    foreach (CCompany objCompany in objCompanyList)
                    {
                        if (m_objBudgetDoc.Company.uuidID.CompareTo(objCompany.uuidID) == 0)
                        {
                            cboxCompany.Properties.Items.Add(objCompany);
                            cboxCompany.SelectedItem = objCompany;
                        }
                        else
                        {
                            cboxCompanyNew.Properties.Items.Add(objCompany);
                        }
                    }
                }

                objCompanyList = null;
                cboxCompany.Properties.ReadOnly = true;

                tabControl.SelectedTabPage = tabPageChangeCompany;
                ShowDialog();
            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("OpenForChangeCompany.\n\nТекст ошибки : " + e.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        /// <summary>
        /// Редактирует признак "компания" для бюджетного документа в БД
        /// </summary>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        private System.Boolean ChangeCompany(ref System.String strErr)
        {
            System.Boolean bRet = false;
            try
            {
                if (cboxCompanyNew.SelectedItem == null)
                {
                    strErr += ("Необходимо указать компанию.");
                    return bRet;
                }

                CCompany objCompanyNew = (CCompany)cboxCompanyNew.SelectedItem;

                if (CBudgetDoc.ChangeBudgetDocCompany(m_objBudgetDoc.uuidID, objCompanyNew.uuidID, 
                    m_objProfile, ref strErr ) == true)
                {
                    m_objBudgetDoc.Company = objCompanyNew;

                    bRet = true;
                }
            }
            catch (System.Exception e)
            {
                strErr += ("Ошибка изменения компании для бюджетного документа.\n\nТекст ошибки : " + e.Message);
            }
            return bRet;
        }

        #endregion

        #region Редактирование формы оплаты
        /// <summary>
        /// Открывает форму с настройками для редактирования формы оплаты
        /// </summary>
        /// <param name="objBudgetDoc">бюджетный документ</param>
        /// <param name="objCurrentUser">пользователь</param>
        public void OpenForChangePaymentType(ERP_Budget.Common.CBudgetDoc objBudgetDoc, ERP_Budget.Common.CUser objCurrentUser)
        {
            try
            {
                m_objBudgetDoc = objBudgetDoc;
                m_objCurrentUser = objCurrentUser;

                m_enChahgedObjectType = enumChahgedObjectType.PaymentType;

                cboxPaymentType.Properties.Items.Clear();
                cboxPaymentTypeNew.Properties.Items.Clear();

                List<CPaymentType> objPaymentTypeList = CPaymentType.GetPaymentTypesList(m_objProfile);

                if ((objPaymentTypeList != null) && (objPaymentTypeList.Count > 0))
                {
                    foreach (CPaymentType objPaymentType in objPaymentTypeList)
                    {
                        if (m_objBudgetDoc.PaymentType.uuidID.CompareTo(objPaymentType.uuidID) == 0)
                        {
                            cboxPaymentType.Properties.Items.Add(objPaymentType);
                            cboxPaymentType.SelectedItem = objPaymentType;
                        }
                        else
                        {
                            cboxPaymentTypeNew.Properties.Items.Add(objPaymentType);
                        }
                    }
                }

                objPaymentTypeList = null;
                cboxPaymentType.Properties.ReadOnly = true;

                tabControl.SelectedTabPage = tabPageChangePaymentType;
                ShowDialog();
            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("OpenForChangePaymentType.\n\nТекст ошибки : " + e.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        /// <summary>
        /// Редактирует признак "форма оплаты" для бюджетного документа в БД
        /// </summary>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        private System.Boolean ChangePaymentType(ref System.String strErr)
        {
            System.Boolean bRet = false;
            try
            {
                if (cboxPaymentTypeNew.SelectedItem == null)
                {
                    strErr += ("Необходимо указать форму оплаты.");
                    return bRet;
                }

                CPaymentType objPaymentTypeNew = (CPaymentType)cboxPaymentTypeNew.SelectedItem;

                if (CBudgetDoc.ChangeBudgetDocPaymentType(m_objBudgetDoc.uuidID, objPaymentTypeNew.uuidID,
                    m_objProfile, ref strErr) == true)
                {
                    m_objBudgetDoc.PaymentType = objPaymentTypeNew;

                    bRet = true;
                }
            }
            catch (System.Exception e)
            {
                strErr += ("Ошибка изменения формы оплаты для бюджетного документа.\n\nТекст ошибки : " + e.Message);
            }
            return bRet;
        }
        #endregion

        #region Редактирование даты оплаты
        /// <summary>
        /// Открывает форму с настройками для редактирования даты оплаты
        /// </summary>
        /// <param name="objBudgetDoc">бюджетный документ</param>
        /// <param name="objCurrentUser">пользователь</param>
        /// <param name="bOnlyView">только для просмотра</param>
        public void OpenForChangePaymentDate(ERP_Budget.Common.CBudgetDoc objBudgetDoc, 
            ERP_Budget.Common.CUser objCurrentUser, System.Boolean bOnlyView  )
        {
            try
            {
                m_objBudgetDoc = objBudgetDoc;
                m_objCurrentUser = objCurrentUser;
                m_objPaymentsListArjive = null;

                m_enChahgedObjectType = enumChahgedObjectType.PaymentDate;

                treeListPayments.Nodes.Clear();

                repItemComboBoxFactCurrency.Items.Clear();
                if (m_objCurrencyList == null)
                {
                    m_objCurrencyList = CCurrency.GetCurrencyList(m_objProfile);
                }
                if (m_objCurrencyList != null)
                {
                    repItemComboBoxFactCurrency.Items.AddRange(m_objCurrencyList);
                }

                System.String strErr = System.String.Empty;

                List<CBudgetDocPaymentItem> objPaymentsList = CBudgetDocPaymentItem.GetBudgetDocPaymentItemList(m_objProfile, m_objBudgetDoc.uuidID, null, ref strErr);

                if ((objPaymentsList != null) && (objPaymentsList.Count > 0))
                {
                    foreach (CBudgetDocPaymentItem objPaymentItem in objPaymentsList)
                    {
                        treeListPayments.AppendNode(new object[] { objPaymentItem.PaymentDate, objPaymentItem.PaymentValue, 
                            ( ( objPaymentItem.Currency != null ) ? objPaymentItem.Currency.CurrencyCode : System.String.Empty ), 
                            objPaymentItem.FactCurrency, objPaymentItem.FactPaymentValue}, null).Tag = objPaymentItem;
                    }

                    m_objPaymentsListArjive = CBudgetDocPaymentItemArjive.GetBudgetDocPaymentItemArjive(m_objProfile, m_objBudgetDoc.uuidID, null, ref strErr);
                }

                objPaymentsList = null;
                this.Text = "Редактировать дату оплаты";

                tabControl.SelectedTabPage = tabPageChangePaymentDate;

                if (treeListPayments.Nodes.Count > 0)
                {
                    LoadArjiveBudgetDocPaymentItem((CBudgetDocPaymentItem)treeListPayments.Nodes[0].Tag);
                }

                treeListPayments.OptionsBehavior.Editable = !bOnlyView;
                treeListPaymentsLog.OptionsBehavior.Editable = false;
                btnOk.Enabled = !bOnlyView;

                ShowDialog();
            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("OpenForChangePaymentDate.\n\nТекст ошибки : " + e.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        /// <summary>
        /// Редактирует признак "дата оплаты" для бюджетного документа в БД
        /// </summary>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        private System.Boolean ChangePaymentDate(ref System.String strErr )
        {
            System.Boolean bRet = false;
            try
            {
                if (treeListPayments.Nodes.Count == 0)
                {
                    strErr += ("Список проведенных оплат пуст.");
                    return bRet;
                }

                List<CBudgetDocPaymentItem> objChangedItemsList = new List<CBudgetDocPaymentItem>();
                CBudgetDocPaymentItem objSrcItem = null;
                CCurrency objNewFactCurrency = null;
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeListPayments.Nodes)
                {
                    objSrcItem = ((CBudgetDocPaymentItem)objNode.Tag);
                    objNewFactCurrency = (CCurrency)objNode.GetValue(colFactCurrency);
                    
                    if( (System.DateTime.Compare(System.Convert.ToDateTime(objNode.GetValue(colPaymentDate)), objSrcItem.PaymentDate) != 0) ||
                        (System.Convert.ToDouble(objNode.GetValue(colFactPaymentValue)) != objSrcItem.FactPaymentValue ) ||
                        (objNewFactCurrency.uuidID.CompareTo(objSrcItem.FactCurrency.uuidID) != 0)
                        )
                    {
                        objChangedItemsList.Add(new CBudgetDocPaymentItem() 
                        { 
                            ID = objSrcItem.ID,
                            PaymentDate = System.Convert.ToDateTime(objNode.GetValue(colPaymentDate)),
                            Currency = objSrcItem.Currency,
                            PaymentValue = objSrcItem.PaymentValue,
                            FactCurrency = objNewFactCurrency, 
                            FactPaymentValue = System.Convert.ToDouble(objNode.GetValue(colFactPaymentValue))
                        });
                    }
                }

                if (objChangedItemsList.Count > 0)
                {
                    System.DateTime LastPayment_Date = System.DateTime.MinValue;
                    bRet = CBudgetDocPaymentItem.EditObjectListInDataBase(objChangedItemsList, m_objProfile, ref strErr, ref LastPayment_Date);
                    if ((bRet == true) && (System.DateTime.Compare(System.DateTime.MinValue, LastPayment_Date) != 0))
                    {
                        m_objBudgetDoc.PaymentDate = LastPayment_Date;
                    }
                }
                else
                {
                    bRet = true;
                }

                objChangedItemsList = null;
            }
            catch (System.Exception e)
            {
                strErr += ("Ошибка изменения формы оплаты для бюджетного документа.\n\nТекст ошибки : " + e.Message);
            }
            return bRet;
        }
        /// <summary>
        /// Журнал изменений оплаты
        /// </summary>
        /// <param name="objBudgetDocPaymentItem">оплата</param>
        private void LoadArjiveBudgetDocPaymentItem(CBudgetDocPaymentItem objBudgetDocPaymentItem)
        {
            try
            {
                treeListPaymentsLog.Nodes.Clear();
                lblPayment.Text = System.String.Empty;

                if (objBudgetDocPaymentItem == null) { return; }

                List<CBudgetDocPaymentItemArjive> objLog = m_objPaymentsListArjive.Where<CBudgetDocPaymentItemArjive>(x => x.ID.CompareTo(objBudgetDocPaymentItem.ID) == 0).ToList<CBudgetDocPaymentItemArjive>();
                if ((objLog != null) && (objLog.Count > 0))
                {
                    foreach (CBudgetDocPaymentItemArjive objItem in objLog)
                    {
                        treeListPaymentsLog.AppendNode(new object[] { objItem.RecordUpdated, objItem.RecordUserUdpated, 
                            objItem.PaymentDateOld, objItem.PaymentDateNew, 
                            objItem.FactCurrencyOld, objItem.FactCurrencyNew,
                            objItem.FactPaymentValueOld, objItem.FactPaymentValueNew}, null).Tag = objItem;
                    }
                }
                objLog = null;

                lblPayment.Text = System.String.Format("{0:### ### ### ###.00} от {1}", objBudgetDocPaymentItem.PaymentValue, objBudgetDocPaymentItem.PaymentDate.ToShortDateString());
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("LoadArjiveBudgetDocPaymentItem.\n\nТекст ошибки : " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }

        private void treeListPayments_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                LoadArjiveBudgetDocPaymentItem(((treeListPayments.FocusedNode == null) || (treeListPayments.FocusedNode.Tag == null)) ? null : (CBudgetDocPaymentItem)treeListPayments.FocusedNode.Tag);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("treeListPayments_FocusedNodeChanged.\n\nТекст ошибки : " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }


        #endregion

        #region Подтвердить изменения
        private void btnOk_Click(object sender, EventArgs e)
        {
            System.Boolean bChangedResult = false;
            System.String strErr = System.String.Empty;

            try
            {
                switch (m_enChahgedObjectType)
                {
                    case enumChahgedObjectType.BudgetDocDate:
                        {
                            bChangedResult = ChangeBudgetDocDate(ref strErr);
                            break;
                        }
                    case enumChahgedObjectType.Company:
                        {
                            bChangedResult = ChangeCompany(ref strErr);
                            break;
                        }
                    case enumChahgedObjectType.PaymentType:
                        {
                            bChangedResult = ChangePaymentType(ref strErr);
                            break;
                        }
                    case enumChahgedObjectType.PaymentDate:
                        {
                            bChangedResult = ChangePaymentDate(ref strErr);
                            break;
                        }
                    default:
                        break;
                }

                if (bChangedResult == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(strErr, "Ошибка",
                       System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("btnOk_Click.\n\nТекст ошибки : " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }
        #endregion

        #region Выход с отменой редактирования
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        private void frmChangeDate_Shown(object sender, EventArgs e)
        {

        }


    }
}
