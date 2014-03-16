using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Budget.Common;

namespace ErpBudgetBudgetDoc
{
    public partial class frmChangeDocType : DevExpress.XtraEditors.XtraForm
    {
        #region Конструктор
        /// <summary>
        /// профайл
        /// </summary>
        UniXP.Common.CProfile m_objProfile;
        /// <summary>
        /// бюджетный документ
        /// </summary>
        CBudgetDoc m_objBudgetDoc;
        /// <summary>
        /// допустимые значения типов документов
        /// </summary>
        List<CBudgetDocTypeTransformTypeItem> m_objPossibleDocTypeList;
        /// <summary>
        /// список курсов валют
        /// </summary>
        private System.Collections.Generic.List<ERP_Budget.Common.CCurrencyRateItem> m_objCurrencyRateList;

        public frmChangeDocType(UniXP.Common.CProfile objProfile,
            CBudgetDoc objBudgetDoc,
            List<ERP_Budget.Common.CBudgetDocTypeTransformTypeItem> objPossibleDocTypeList)
        {
            m_objProfile = objProfile;
            m_objBudgetDoc = objBudgetDoc;
            m_objPossibleDocTypeList = objPossibleDocTypeList;

            InitializeComponent();

            memoEditWarning.EditValue = "";
            panelWarning.Visible = false;

        }
        #endregion

        #region Инициализация значений в элементах управления

        private void frmChangeDocType_Load(object sender, EventArgs e)
        {
            EditBudgetDocType();
        }

        private void EditBudgetDocType()
        {
            try
            {
                LoadCurrencyRateList();
                LoadBudgetDocProperties(m_objBudgetDoc);
                CheckNewValuesInControls();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "EditBudgetDocType.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Загрузка свойств объекта "Бюджетный документ" в элементы управления
        /// </summary>
        /// <param name="objBudgetDoc">бюджетный документ</param>
        private void LoadBudgetDocProperties(CBudgetDoc objBudgetDoc)
        {
            try
            {
                ClearControlsWithBudgetDocProperties();

                dtDocDate.EditValue = objBudgetDoc.Date;
                dtDocPaymentDate.EditValue = objBudgetDoc.PaymentDate;
                calcDocMoney.Value = System.Convert.ToDecimal( objBudgetDoc.Money );
                calcDocMoneyInBudgetCurrency.Value = System.Convert.ToDecimal( objBudgetDoc.MoneyAgree );

                if (objBudgetDoc.DocType != null)
                {
                    cboxBudgetDocType.Properties.Items.Add(objBudgetDoc.DocType);
                    cboxBudgetDocType.SelectedItem = ((cboxBudgetDocType.Properties.Items.Count > 0) ? cboxBudgetDocType.Properties.Items[0] : null);
                }
                if (objBudgetDoc.AccountPlan != null)
                {
                    cboxAccountPlan.Properties.Items.Add(objBudgetDoc.AccountPlan);
                    cboxAccountPlan.SelectedItem = ((cboxAccountPlan.Properties.Items.Count > 0) ? cboxAccountPlan.Properties.Items[0] : null);
                }
                if (objBudgetDoc.BudgetDep != null)
                {
                    cboxBudgetDep.Properties.Items.Add(objBudgetDoc.BudgetDep);
                    cboxBudgetDep.SelectedItem = ((cboxBudgetDep.Properties.Items.Count > 0) ? cboxBudgetDep.Properties.Items[0] : null);

                    if (cboxBudgetDep.SelectedItem != null)
                    {
                        RefreshBudgetProjectForBudgetDep(objBudgetDoc.BudgetDep);
                    }
                }
                if (objBudgetDoc.BudgetProject != null)
                {
                    cboxBudgetProject.Properties.Items.Add(objBudgetDoc.BudgetProject);
                    cboxBudgetProject.SelectedItem = ((cboxBudgetProject.Properties.Items.Count > 0) ? cboxBudgetProject.Properties.Items[0] : null);
                }
                if (objBudgetDoc.Company != null)
                {
                    cboxCompany.Properties.Items.Add(objBudgetDoc.Company);
                    cboxCompany.SelectedItem = ((cboxCompany.Properties.Items.Count > 0) ? cboxCompany.Properties.Items[0] : null);
                }
                if (objBudgetDoc.Currency != null)
                {
                    cboxCurrency.Properties.Items.Add(objBudgetDoc.Currency);
                    cboxCurrency.SelectedItem = ((cboxCurrency.Properties.Items.Count > 0) ? cboxCurrency.Properties.Items[0] : null);
                }
                if (objBudgetDoc.BudgetItem != null)
                {
                    cboxDebitArticle.Properties.Items.Add(objBudgetDoc.BudgetItem);
                    cboxDebitArticle.SelectedItem = ((cboxDebitArticle.Properties.Items.Count > 0) ? cboxDebitArticle.Properties.Items[0] : null);
                }
                if ((m_objBudgetDoc.BudgetItemList != null) && (m_objBudgetDoc.BudgetItemList.Count > 0))
                {
                    if ((m_objBudgetDoc.BudgetItemList.Count == 1) &&
                        (m_objBudgetDoc.BudgetItem.Name == m_objBudgetDoc.BudgetItemList[0].Name) &&
                        ((m_objBudgetDoc.BudgetItem.BudgetItemNum + ".0") == m_objBudgetDoc.BudgetItemList[0].BudgetItemNum))
                    {
                        // статья по-умолчанию
                    }
                    else
                    {
                        foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in m_objBudgetDoc.BudgetItemList)
                        {
                            if (objBudgetItem.ParentID.CompareTo(System.Guid.Empty) == 0) { continue; }
                            DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                            treelistBudgetItem.AppendNode(new object[] { true, 
                                objBudgetItem.BudgetItemFullName, objBudgetItem.RestMoney, objBudgetItem.MoneyInBudgetDocCurrency, 
                                objBudgetItem.MoneyInBudgetCurrency, objBudgetItem.DontChange, 
                                ( ( objBudgetItem.BudgetExpenseType != null ) ? objBudgetItem.BudgetExpenseType.Name : "" ),
                                ( ( objBudgetItem.AccountPlan != null ) ? objBudgetItem.AccountPlan.CodeIn1C : System.String.Empty )}, null);
                            objNode.Tag = objBudgetItem;
                        }
                    }
                }

                cboxPaymentType.Properties.Items.Add(objBudgetDoc.PaymentType);
                cboxPaymentType.SelectedItem = ((cboxPaymentType.Properties.Items.Count > 0) ? cboxPaymentType.Properties.Items[0] : null);

                if ((m_objPossibleDocTypeList != null) && (m_objPossibleDocTypeList.Count > 0))
                {
                    foreach( CBudgetDocTypeTransformTypeItem objTransformTypeItem in  m_objPossibleDocTypeList)
                    {
                        cboxNewBudgetDocType.Properties.Items.Add(objTransformTypeItem.NewBudgetDocType);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "LoadBudgetDocProperties.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Очистка значений в элементах управления, отображающих свойства бюджетного документа
        /// </summary>
        private void ClearControlsWithBudgetDocProperties()
        {
            try
            {
                dtDocDate.EditValue = null;
                dtDocPaymentDate.EditValue = null;
                calcDocMoney.Value = 0;
                calcDocMoneyInBudgetCurrency.Value = 0;

                cboxBudgetDocType.SelectedItem = null;
                cboxBudgetDocType.Properties.Items.Clear();

                cboxAccountPlan.SelectedItem = null;
                cboxAccountPlan.Properties.Items.Clear();

                cboxBudgetDep.SelectedItem = null;
                cboxBudgetDep.Properties.Items.Clear();

                cboxBudgetDocType.SelectedItem = null;
                cboxBudgetDocType.Properties.Items.Clear();

                cboxBudgetProject.SelectedItem = null;
                cboxBudgetProject.Properties.Items.Clear();

                cboxCompany.SelectedItem = null;
                cboxCompany.Properties.Items.Clear();

                cboxCurrency.SelectedItem = null;
                cboxCurrency.Properties.Items.Clear();

                cboxDebitArticle.SelectedItem = null;
                cboxDebitArticle.Properties.Items.Clear();

                cboxNewAccountPlan.SelectedItem = null;
                cboxNewAccountPlan.Properties.Items.Clear();

                cboxNewBudgetDocType.SelectedItem = null;
                cboxNewBudgetDocType.Properties.Items.Clear();

                cboxNewBudgetItem.SelectedItem = null;
                cboxNewBudgetItem.Properties.Items.Clear();

                cboxPaymentType.SelectedItem = null;
                cboxPaymentType.Properties.Items.Clear();

                treelistBudgetItem.Nodes.Clear();
                treelistNewBudgetItem.Nodes.Clear();

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "ClearControlsWithBudgetDocProperties.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        /// <summary>
        /// Загружает список курсов валют
        /// </summary>
        private void LoadCurrencyRateList()
        {
            try
            {
                CCurrency objCurrencyBudget = CCurrency.GetCurrencyList(m_objProfile).SingleOrDefault<CCurrency>(x => x.CurrencyCode == ERP_Budget.Global.Consts.strCurrencyBudget);
                m_objCurrencyRateList = CCurrencyRateItem.GetCurrencyRateList(m_objProfile, m_objBudgetDoc.Date, objCurrencyBudget.uuidID);

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "LoadCurrencyRateList.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        /// <summary>
        /// Обновляет список доступных проектов для указанного бюджетного подразделения
        /// </summary>
        /// <param name="objBudgetDep">бюджетное подразделение</param>
        private void RefreshBudgetProjectForBudgetDep(CBudgetDep objBudgetDep)
        {
            try
            {
                cboxNewBudgetProject.Properties.Items.Clear();
                System.String strErr = "";

                if (objBudgetDep == null) { cboxNewBudgetProject.Properties.Items.Clear(); }
                else
                {
                    List<CBudgetProject> objBudgetProjectlist = CBudgetProjectDataBaseModel.GetBudgetProjectListForBudgetDepInDocument(m_objProfile, null, objBudgetDep.uuidID, dtDocDate.DateTime, ref strErr);
                    if ((objBudgetProjectlist != null) && (objBudgetProjectlist.Count > 0))
                    {
                        cboxNewBudgetProject.Properties.Items.AddRange(objBudgetProjectlist);
                        cboxNewBudgetProject.SelectedItem = cboxNewBudgetProject.Properties.Items[0];
                    }
                    else if (strErr.Length > 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Ошибка обновления списка проектов.\nТекст ошибки: " + strErr, "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления списка проектов.\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }
        #endregion

        #region Проверка значений
        /// <summary>
        /// Подсветка элементов управления с незаполненными значениями
        /// </summary>
        private void SetColorInControls()
        {
            try
            {
                cboxNewBudgetDocType.Properties.Appearance.BackColor = ((cboxNewBudgetDocType.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxNewBudgetProject.Properties.Appearance.BackColor = ((cboxNewBudgetProject.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxNewBudgetItem.Properties.Appearance.BackColor = ((cboxNewBudgetItem.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
                cboxNewAccountPlan.Properties.Appearance.BackColor = ((cboxNewAccountPlan.SelectedItem == null) ? System.Drawing.Color.Tomato : System.Drawing.Color.White);
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "SetColorInControls.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        /// <summary>
        /// Проверка указанных значений
        /// </summary>
        /// <returns>true - все значения корректны; false - значения не прошли проверку</returns>
        private System.Boolean IsAllPropertiesValid()
        {
            System.Boolean bRet = false;
            try
            {
                System.Decimal dcmlSumDocMoney = System.Convert.ToDecimal( treelistNewBudgetItem.GetSummaryValue( colNewMoney ) );

                System.Boolean bAllAccountPlansIsValid = true;

                foreach( DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treelistNewBudgetItem.Nodes )
                {
                    if (System.Convert.ToBoolean(objNode.GetValue( colNewCheck)) == true)
                    {
                        if (System.Convert.ToString(objNode.GetValue(colAccountPlan)) == "")
                        {
                            bAllAccountPlansIsValid = false;
                            break;
                        }
                    }
                }

                bRet = ((cboxNewBudgetDocType.SelectedItem != null) &&
                    (cboxNewBudgetItem.SelectedItem != null) &&
                    (cboxNewBudgetProject.SelectedItem != null) && 
                    (cboxNewAccountPlan.SelectedItem != null) && (bAllAccountPlansIsValid == true) &&
                    ((dcmlSumDocMoney > 0) && (dcmlSumDocMoney <= calcDocMoney.Value))
                    );
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "IsAllPropertiesValid.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return bRet;
        }
        /// <summary>
        /// Проверка значений в элементах управления
        /// </summary>
        private void CheckNewValuesInControls()
        {
            try
            {
                btnSave.Enabled = IsAllPropertiesValid();
                SetColorInControls();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "CheckNewValues.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return ;
        }
        #endregion

        #region Обработка событий в дереве статей бюджета

        /// <summary>
        /// Обновляет выпадающий список статей бюджета для выбранной служба
        /// </summary>
        /// <param name="uuidBudgetDepID">уи службы</param>
        /// <param name="uuidBudgetDepProjectID">уи проекта</param>
        /// <param name="objBudgetDocType">тип бюджетного документа</param>
        private void RefreshBudgetItemList(System.Guid uuidBudgetDepID,
            System.Guid uuidBudgetDepProjectID, CBudgetDocType objBudgetDocType )
        {
            try
            {
                // очищаем список статей
                treelistNewBudgetItem.Tag = null;
                cboxNewBudgetItem.Properties.Items.Clear();
                cboxNewBudgetItem.Text = "загрузка статей бюджета...";
                cboxNewBudgetItem.Refresh();

                // план счетов
                cboxNewAccountPlan.SelectedItem = null;
                cboxNewAccountPlan.Properties.Items.Clear();

                // очищаем список подстатей
                treelistNewBudgetItem.Nodes.Clear();

                if (uuidBudgetDepID.Equals(System.Guid.Empty) || 
                    uuidBudgetDepProjectID.Equals(System.Guid.Empty) ||
                    objBudgetDocType.uuidID.Equals(System.Guid.Empty)) { return; }

                // для выбранной службы запрашиваем список статей бюджета
                if (m_objBudgetDoc.LoadPopupBudgetItemList(m_objProfile, uuidBudgetDepID) == true)
                {
                    // фильтруем список статей по указанному проекту
                    m_objBudgetDoc.PopupBudgetItemList = m_objBudgetDoc.PopupBudgetItemList.Where<CPopupBudgetItem>(x => ((x.ParentBudgetItem.BudgetProject != null) && (x.ParentBudgetItem.BudgetProject.uuidID.Equals(uuidBudgetDepProjectID)))).ToList<CPopupBudgetItem>();

                    // фильтруем список статей по типу документа
                    List<CPopupBudgetItem> objPopupBudgetItemListFilter = new List<CPopupBudgetItem>();
                    List<CPopupBudgetItem> objPopupBudgetItemList = null;
                    foreach (CBudgetType objBudgetType in objBudgetDocType.ValidBudgetTypeList)
                    {
                        objPopupBudgetItemList = m_objBudgetDoc.PopupBudgetItemList.Where<CPopupBudgetItem>(x => ((x.ParentBudgetItem.BudgetType != null) && (x.ParentBudgetItem.BudgetType.uuidID.Equals(objBudgetType.uuidID)))).ToList<CPopupBudgetItem>();
                        if ((objPopupBudgetItemList != null) && (objPopupBudgetItemList.Count > 0))
                        {
                            objPopupBudgetItemListFilter.AddRange(objPopupBudgetItemList);
                        }
                    }
                    m_objBudgetDoc.PopupBudgetItemList = objPopupBudgetItemListFilter;
                    objPopupBudgetItemList = null;

                    if ((m_objBudgetDoc.PopupBudgetItemList != null) && (m_objBudgetDoc.PopupBudgetItemList.Count > 0))
                    {
                        // если в списке есть статьи из разных бюджетов, то нужно это обозначить,
                        // указав перед группой статей название бюджета
                        // если все статьи из одного бюджета, то его название не пишем
                        List<System.Guid> BudgetGUIDList = m_objBudgetDoc.PopupBudgetItemList.Select(x => x.ParentBudgetItem.BudgetGUID).Distinct().ToList<System.Guid>();

                        if (BudgetGUIDList != null)
                        {
                            if (BudgetGUIDList.Count > 1)
                            {
                                System.String strBudgetName = "";
                                foreach (System.Guid uuidBudgetId in BudgetGUIDList)
                                {
                                    strBudgetName = (m_objBudgetDoc.PopupBudgetItemList.First<CPopupBudgetItem>(x => x.ParentBudgetItem.BudgetGUID.Equals(uuidBudgetId))).ParentBudgetItem.BudgetName;
                                    cboxNewBudgetItem.Properties.Items.Add((String.Format("- {0}", strBudgetName)));

                                    cboxNewBudgetItem.Properties.Items.AddRange(m_objBudgetDoc.PopupBudgetItemList.Where<CPopupBudgetItem>(x => x.ParentBudgetItem.BudgetGUID.Equals(uuidBudgetId)).ToList<CPopupBudgetItem>());
                                }
                            }
                            else
                            {
                                cboxNewBudgetItem.Properties.Items.AddRange(m_objBudgetDoc.PopupBudgetItemList);
                            }
                        }

                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обновления выпадающего списка \"Статьи бюджета\"\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                cboxNewBudgetItem.Text = "";
                cboxNewBudgetItem.SelectedItem = null;
            }
            return;
        }
        /// <summary>
        /// Обновление списка подстатей
        /// </summary>
        /// <param name="objPopupBudgetItem">Статья бюджета</param>
        private void RefreshChildBudgetItemList( CPopupBudgetItem objPopupBudgetItem )
        {
            try
            {
                // счёт из плана счетов
                if (objPopupBudgetItem.ParentBudgetItem.AccountPlan == null) { cboxNewAccountPlan.Properties.Items.Clear(); }
                else
                {
                    if ((cboxNewAccountPlan.SelectedItem == null) || (((CAccountPlan)cboxNewAccountPlan.SelectedItem).uuidID.Equals(objPopupBudgetItem.ParentBudgetItem.AccountPlan.uuidID) == false))
                    {
                        // счёт не выбран или он не соответствует счёту статьи
                        cboxNewAccountPlan.Properties.Items.Clear();
                        if (objPopupBudgetItem.ParentBudgetItem.AccountPlan != null)
                        {
                            cboxNewAccountPlan.Properties.Items.Add(objPopupBudgetItem.ParentBudgetItem.AccountPlan);
                            cboxNewAccountPlan.SelectedItem = cboxNewAccountPlan.Properties.Items[0];
                        }
                    }
                }

                // обновляет список подстатей
                treelistNewBudgetItem.Nodes.Clear();
                foreach (ERP_Budget.Common.CBudgetItem objBudgetItem in objPopupBudgetItem.ChlildBudgetItemList)
                {
                    if (objBudgetItem.uuidID.CompareTo(m_objBudgetDoc.BudgetItem.uuidID) == 0) { continue; }

                    DevExpress.XtraTreeList.Nodes.TreeListNode objNode =
                        treelistNewBudgetItem.AppendNode(new object[] { false, 
                        objBudgetItem.BudgetItemFullName, objBudgetItem.RestMoney, 0, 0, objBudgetItem.DontChange, 
                        ( ( objBudgetItem.BudgetExpenseType != null ) ? objBudgetItem.BudgetExpenseType.Name : "" ),
                        ( ( objBudgetItem.AccountPlan != null ) ? objBudgetItem.AccountPlan.CodeIn1C : System.String.Empty )}, null);
                    objNode.Tag = objBudgetItem;
                }
                if( treelistNewBudgetItem.Nodes.Count == 1 )
                {
                    treelistNewBudgetItem.Nodes[0].SetValue( colNewCheck, true );
                    treelistNewBudgetItem.Nodes[0].SetValue( colMoney, calcDocMoney.Value );
                }


            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "RefreshChildBudgetItemList\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }

        private void treelistNewBudgetItem_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            try
            {
                // если меняется значение в столбце "Сумма", то пересчитаем значение в столбце "Сумма, EUR"
                if (e.Column == colNewMoney)
                {
                    System.Decimal Money = System.Convert.ToDecimal(e.Value);
                    // сумма в валюте бюджета
                    System.Decimal MoneyBudgetCurrency = 0;

                    CCurrency objCurrencyBudgetDoc = (CCurrency)cboxCurrency.SelectedItem;

                    if (objCurrencyBudgetDoc.CurrencyCode == ERP_Budget.Global.Consts.strCurrencyBudget)
                    {
                        MoneyBudgetCurrency = Money;
                    }
                    else
                    {
                        CCurrencyRateItem objCurrencyRateItem = m_objCurrencyRateList.FirstOrDefault<CCurrencyRateItem>(x => (x.CurrencyIn.CurrencyCode == objCurrencyBudgetDoc.CurrencyCode && x.CurrencyOut.CurrencyCode == ERP_Budget.Global.Consts.strCurrencyBudget));
                        if (objCurrencyRateItem != null)
                        {
                            MoneyBudgetCurrency = Money * objCurrencyRateItem.Value;
                        }
                    }

                    // прописываем поллученное значение в столбец "Сумма, EUR"
                    e.Node.SetValue(colMoneyBudget, MoneyBudgetCurrency);
                }
                if (e.Column == colNewCheck)
                {
                    if (System.Convert.ToBoolean(e.Value) == false)
                    {
                        e.Node.SetValue(colMoneyBudget, 0);
                        e.Node.SetValue(colMoney, 0);
                    }
                }

                System.Decimal dcmlSumDocMoney = System.Convert.ToDecimal(treelistNewBudgetItem.GetSummaryValue(colNewMoney));

                if (dcmlSumDocMoney == 0)
                {
                    memoEditWarning.EditValue = "";
                    memoEditWarning.EditValue = "Сумма документа не должна быть равна нулю.";
                    panelWarning.Visible = true;
                }
                else if (dcmlSumDocMoney > calcDocMoney.Value)
                {
                    memoEditWarning.EditValue = "";
                    memoEditWarning.EditValue = "Сумма документа больше допустимой.";
                    panelWarning.Visible = true;

                    calcDocMoney.Font = new Font(calcDocMoney.Font, FontStyle.Bold);
                    calcDocMoney.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    memoEditWarning.EditValue = "";
                    panelWarning.Visible = false;
                    calcDocMoney.Font = new Font(calcDocMoney.Font, FontStyle.Regular);
                    calcDocMoney.ForeColor = System.Drawing.Color.Black;
                }

            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "treelistNewBudgetItem_CellValueChanged\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                CheckNewValuesInControls();
            }
            return;
        }
        private void treelistNewBudgetItem_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colNewMoney)
                {
                    if (System.Convert.ToDecimal(e.Value) > 0)
                    {
                        if (System.Convert.ToBoolean(e.Node.GetValue(colNewCheck)) == false)
                        {
                            e.Node.SetValue(colNewCheck, true);
                        }
                    }
                    else
                    {
                        if (System.Convert.ToDecimal(e.Value) < 0)
                        {
                            e.Value = 0;
                        }
                        else if (System.Convert.ToDecimal(e.Value) == 0)
                        {
                            e.Node.SetValue(colNewCheck, false);
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "treelistNewBudgetItem_CellValueChanging\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void treelistNewBudgetItem_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            try
            {
                if ((e.Node == treelistNewBudgetItem.FocusedNode && e.Column != treelistNewBudgetItem.FocusedColumn) || e.Node == null || e.Column == null) return;
                if (System.Convert.ToString(e.Node.GetValue(colAccountPlan)) == "")
                {

                    e.Appearance.Font = new Font(DevExpress.Utils.AppearanceObject.DefaultFont, FontStyle.Strikeout);
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "treelistNewBudgetItem_CustomDrawNodeCell.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        #endregion

        #region Выбор нового типа документа
        private void cboxNewBudgetDocType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if( (cboxNewBudgetDocType.SelectedItem != null) && (cboxNewBudgetProject.SelectedItem != null) )
                {
                    RefreshBudgetItemList(m_objBudgetDoc.BudgetDep.uuidID, ((CBudgetProject)cboxNewBudgetProject.SelectedItem ).uuidID,
                        (CBudgetDocType)cboxNewBudgetDocType.SelectedItem);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "cboxNewBudgetDocType_SelectedValueChanged\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                CheckNewValuesInControls();
            }
            return;
        }
        #endregion

        #region Выбор нового проекта

        #endregion

        #region Выбор новой статьи расходов
        private void cboxNewBudgetItem_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboxNewBudgetItem.SelectedItem != null)
                {
                    RefreshChildBudgetItemList((CPopupBudgetItem)cboxNewBudgetItem.SelectedItem);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "cboxNewBudgetItem_SelectedValueChanged\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                CheckNewValuesInControls();
            }
            return;
        }
        #endregion

        #region Выбор нового плана счетов
        private void cboxNewAccountPlan_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckNewValuesInControls();
        }
        #endregion

        #region Выход
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
        #endregion

        #region Смена типа документа
        /// <summary>
        /// Изменяет в БД тип бюджетного документа
        /// </summary>
        /// <param name="strErr">сообщение об ошибке</param>
        /// <returns>true - удачное завершение операции; false - ошибка</returns>
        private System.Boolean ChangeBudgetDocTypeInBudgetDoc( ref System.String strErr )
        {
            System.Boolean bRet = false;
            try
            {
                if (cboxNewBudgetDocType.SelectedItem == null)
                {
                    strErr += ("Необходимо указать новый тип бюджетного документа.");
                    return bRet;
                }
                if (cboxNewBudgetItem.SelectedItem == null)
                {
                    strErr += ("Необходимо указать новую статью бюджета.");
                    return bRet;
                }
                if (System.Convert.ToDouble(treelistNewBudgetItem.GetSummaryValue(colNewMoney)) <= 0)
                {
                    strErr += ("Сумма документа должна быть больше нуля.");
                    return bRet;
                }

                System.Guid BUDGETDOC_GUID_ID = m_objBudgetDoc.uuidID;
                System.Double BUDGETDOC_MONEY = System.Convert.ToDouble(treelistNewBudgetItem.GetSummaryValue(colNewMoney));
                System.Double BUDGETDOC_MONEYAGREE = System.Convert.ToDouble(treelistNewBudgetItem.GetSummaryValue(colNewMoneyBudget));
                System.Guid BUDGETDOCTYPE_GUID_ID = ((CBudgetDocType)cboxNewBudgetDocType.SelectedItem).uuidID; 
                System.Guid BUDGETITEM_GUID_ID = ( ((CPopupBudgetItem)cboxNewBudgetItem.SelectedItem).ParentBudgetItem.uuidID );
                System.Guid ACCOUNTPLAN_GUID =  ( ( cboxNewAccountPlan.SelectedItem == null ) ? System.Guid.Empty : ((CAccountPlan)cboxNewAccountPlan.SelectedItem).uuidID  );
                System.Int32 USERS_ID =  CUser.GetUsersInfo(m_objProfile).ulID;
                System.Guid BUDGETPROJECT_GUID = (((CBudgetProject)cboxNewBudgetProject.SelectedItem).uuidID);
                List<CBudgetItem> objBudgetItemList = new List<CBudgetItem>();
                CBudgetItem objBudgetItem = null;
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode objectNode in treelistNewBudgetItem.Nodes)
                {
                    if (((System.Boolean)objectNode.GetValue(colNewCheck)) &&
                        (objectNode.Tag != null))
                    {
                        // эта подстатья выбрана и сумма не нулевая
                        objBudgetItem = (CBudgetItem)objectNode.Tag;

                        objBudgetItem.MoneyInBudgetCurrency = System.Convert.ToDouble(objectNode.GetValue( colNewMoneyBudget));
                        objBudgetItem.MoneyInBudgetDocCurrency = System.Convert.ToDouble(objectNode.GetValue( colNewMoney));

                        if (objBudgetItem.MoneyInBudgetDocCurrency > 0)
                        { objBudgetItemList.Add(objBudgetItem); }
                    }
                }

                if (objBudgetItemList.Count == 0)
                {
                    strErr += ("Необходимо указать хотя бы одну подстатью бюджета и сумму.");
                    return bRet;
                }
                if( BUDGETDOC_MONEY <= 0 )
                {
                    strErr += ("Сумма документа должна быть больше нуля.");
                    return bRet;
                }

                System.Int32 iretCode = -1;

                Cursor = Cursors.WaitCursor;

                bRet = CBudgetDocTypeDataBaseModel.ChangeDocTypeInBudgetDoc(BUDGETDOC_GUID_ID, BUDGETDOC_MONEY, BUDGETDOC_MONEYAGREE, BUDGETDOCTYPE_GUID_ID,
                    BUDGETITEM_GUID_ID, ACCOUNTPLAN_GUID, USERS_ID, BUDGETPROJECT_GUID, objBudgetItemList, m_objProfile, ref iretCode, ref strErr);

            }
            catch (System.Exception f)
            {
                strErr += ("ChangeBudgetDocTypeInBudgetDoc. Текст ошибки: " + f.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return bRet;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAllPropertiesValid() == true)
                {
                    System.String strErr = "";
                    if (ChangeBudgetDocTypeInBudgetDoc(ref strErr) == true)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(
                        "Ошибка изменения типа документа.\nТекст ошибки: " + strErr, "Внимание",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Заполнены не все обязательные значения.\nПожалуйста, проверьте данные и повторите попытку.", "Внимание",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "btnSave_Click\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
            return;
        }
        #endregion

    }
}
