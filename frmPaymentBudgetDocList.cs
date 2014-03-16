using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErpBudgetBudgetDoc
{
    public partial class frmPaymentBudgetDocList : DevExpress.XtraEditors.XtraForm
    {
        private List<ERP_Budget.Common.CBudgetDoc> m_objBudjetDocArjList;
        private System.Guid m_uuidSelectedDocID;
        public System.Guid SelectedDocID
        {
            get { return m_uuidSelectedDocID; }
        }
        private UniXP.Common.CProfile m_objProfile;
        private const System.String strFind = "Для поиска оплаченных документов нажмите \"Обновить\"";
        private const System.String strSelect = "Для выбора заявки сделайте по ней двойной щелчок мышкой";
        private const System.String strTitle = "Список оплаченных бюджетных документов. Оплатил: ";

        public frmPaymentBudgetDocList(UniXP.Common.CProfile objProfile)
        {
            InitializeComponent();
            m_objBudjetDocArjList = new List<ERP_Budget.Common.CBudgetDoc>();
            m_uuidSelectedDocID = System.Guid.Empty;
            m_objProfile = objProfile;
            this.Text = strTitle + m_objProfile.m_strLastName;
            dtBeginDate.DateTime = System.DateTime.Today;
            dtEndDate.DateTime = System.DateTime.Today;
        }
        /// <summary>
        /// Загружает журнал оплаченных заявок
        /// </summary>
        /// <param name="objProfile">профайл</param>
        private void LoadBudgetDocList(UniXP.Common.CProfile objProfile)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Refresh();
            try
            {
                barBtnRefresh.Enabled = false;
                barBtnRefresh.Refresh();
                // удаляем записи в источнике данных
                dsBudgetDoc.Tables["dtDocNotActive"].Rows.Clear();
                // отключаем гриды
                gridDocNotActive.Enabled = false;

                // вывешиваем картинки "ожидания"
                tabPageDocNotActive.Image = ErpBudgetBudgetDoc.Properties.Resources.loading;
                TabControlDocList.Refresh();
                // запрашиваем список заявок
                m_objBudjetDocArjList.Clear();
                ERP_Budget.Common.CBudgetDoc.ReloadBudgetDocListForBackMoney(objProfile, m_objBudjetDocArjList,
                    dtBeginDate.DateTime, dtEndDate.DateTime);
                for (System.Int32 i2 = 0; i2 < m_objBudjetDocArjList.Count; i2++)
                {
                    // добавляем запись в набор данных
                    System.Data.DataRow row = dsBudgetDoc.Tables["dtDocNotActive"].NewRow();
                    row["C_" + "BUDGETDOC_GUID_ID"] = m_objBudjetDocArjList[i2].uuidID; // BUDGETDOC_GUID_ID
                    row["C_" + "CREATEDUSER_NAME"] = m_objBudjetDocArjList[i2].OwnerUser.UserFullName;
                    row["C_" + "DOCDATE"] = m_objBudjetDocArjList[i2].Date;
                    row["C_" + "BUDGETDEP_NAME"] = m_objBudjetDocArjList[i2].BudgetDep.Name;
                    row["C_" + "DOCOBJECTIVE"] = m_objBudjetDocArjList[i2].Objective;
                    row["C_" + "DOCMONEY"] = m_objBudjetDocArjList[i2].Money; // DOCMONEY
                    row["C_" + "DEBITARTICLE_NAME"] = m_objBudjetDocArjList[i2].BudgetItem.BudgetItemFullName;
                    row["C_" + "COMPANY_NAME"] = m_objBudjetDocArjList[i2].Company.CompanyAcronym; // COMPANY_NAME
                    row["C_" + "BUDGETDOCSTATE_NAME"] = m_objBudjetDocArjList[i2].DocState.Name; // BUDGETDOCSTATE_NAME
                    row["C_" + "BUDGETDOCTYPE_NAME"] = m_objBudjetDocArjList[i2].DocType.Name; // BUDGETDOCTYPE_NAME
                    row["C_" + "IMAGE_ID"] = m_objBudjetDocArjList[i2].DocState.OrderNum; // IMAGE_ID
                    row["C_" + "IMAGETYPE_ID"] = (m_objBudjetDocArjList[i2].DocType.Name == "Заявка") ? 0 : 1; // IMAGETYPE_ID
                    row["C_" + "DOCACTIVE"] = m_objBudjetDocArjList[i2].IsActive; // DOCACTIVE
                    row["C_" + "RECIPIENT"] = m_objBudjetDocArjList[i2].Recipient;
                    row["C_" + "DATESTATE"] = m_objBudjetDocArjList[i2].DateState; // objBudgetDoc.DateState.ToShortDateString() + " " + objBudgetDoc.DateState.ToShortTimeString();
                    dsBudgetDoc.Tables["dtDocNotActive"].Rows.Add(row);
                }
                dsBudgetDoc.AcceptChanges();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка загрузки журналов заявок.\n\nТекст ошибки : " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally // очищаем занимаемые ресурсы
            {
                gridDocNotActive.Enabled = (dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count > 0);
                lblOpenInfoBotton.Text = (gridDocNotActive.Enabled == true) ? strSelect : strFind;

                // вывешиваем картинки и подсчитываем количество заявок
                tabPageDocNotActive.Image = ErpBudgetBudgetDoc.Properties.Resources.mail_lock;

                tabPageDocNotActive.Text = "Оплаченные заявки (" + dsBudgetDoc.Tables["dtDocNotActive"].Rows.Count.ToString() + ")";

                barBtnRefresh.Enabled = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return;
        }
        /// <summary>
        /// Обновляет список заявок
        /// </summary>
        public void RefreshBudgetDocList()
        {
            try
            {
                // обновляем информацию
                LoadBudgetDocList(m_objProfile);
            }
            catch (System.Exception e)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка обновления списка заявок.\n\nТекст ошибки : " + e.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return;
        }

        private void barBtnRefres_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void gridViewDocNotActive_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ((gridViewDocNotActive.RowCount > 0) && (gridViewDocNotActive.FocusedRowHandle >= 0))
                {
                    m_uuidSelectedDocID = (System.Guid)gridViewDocNotActive.GetRowCellValue(gridViewDocNotActive.FocusedRowHandle, colC_BUDGETDOC_GUID_ID);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ошибка выбора заявки.\n\nТекст ошибки: " + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return;
        }

        private void frmPaymentBudgetDocList_Shown(object sender, EventArgs e)
        {
            lblOpenInfoBotton.Text = strFind;
        }


    }
}
