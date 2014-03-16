using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErpBudgetBudgetDoc
{
    public partial class frmUserComment : DevExpress.XtraEditors.XtraForm
    {
        #region Переменные
        /// <summary>
        /// Пользовательский комментарий
        /// </summary>
        private System.String m_strComment;
        /// <summary>
        /// Пользовательский комментарий
        /// </summary>
        public System.String Comment
        {
            get { return m_strComment; }
        }
        /// <summary>
        /// УИ бюджетного документа
        /// </summary>
        private System.Guid m_uuidBudgetDocID;
        /// <summary>
        /// УИ бюджетного документа
        /// </summary>
        public System.Guid BudgetDocID
        {
            get { return m_uuidBudgetDocID; }
        }
        /// <summary>
        /// Признак того, что комментарий был изменен
        /// </summary>
        private System.Boolean m_bIsCommentModified;
        /// <summary>
        /// Признак того, что комментарий был изменен
        /// </summary>
        public System.Boolean IsCommentModified
        {
            get { return m_bIsCommentModified; }
        }
        /// <summary>
        /// Профайл пользователя
        /// </summary>
        private UniXP.Common.CProfile m_objProfile;

        #endregion

        #region Конструктор
        public frmUserComment(UniXP.Common.CProfile objProfile, System.Guid uuidBudgetDocID, System.String strComment)
        {
            m_objProfile = objProfile;
            m_uuidBudgetDocID = uuidBudgetDocID;
            m_strComment = strComment;
            m_bIsCommentModified = false;

            InitializeComponent();
            InitFormProperties();
        }
        /// <summary>
        /// Инициализирует свойства формы
        /// </summary>
        private void InitFormProperties()
        {
            try
            {
                edComment.EditValueChanging -= new DevExpress.XtraEditors.Controls.ChangingEventHandler(edComment_EditValueChanging);
                edComment.Text = m_strComment;
                btnCancel.Enabled = true;
                btnOk.Enabled = false;
                edComment.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(edComment_EditValueChanging);
                edComment.Focus();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка инициализации свойств формы.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Обработчик изменения текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edComment_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (e.NewValue != null)
                {
                    System.String strText = ((System.String)e.NewValue).Trim();
                    btnOk.Enabled = (strText == "") ? false : true;
                    btnCancel.Enabled = true;
                    m_bIsCommentModified = (strText != m_strComment);
                    e.Cancel = false;
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Во время проверки текста комментария произошла ошибка.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Назначить комментарий
        /// <summary>
        /// Сохраняет комментарий в базе данных
        /// </summary>
        /// <returns>true - успешное завершение; false - ошибка</returns>
        private System.Boolean bSetComment()
        {
            System.Boolean bRet = false;
            try
            {
                if ((m_bIsCommentModified == true) && (edComment.Text != ""))
                {
                    // сперва удалим старый комментарий
                    bRet = ERP_Budget.Common.CNoteType.DeleteCommentFromBudgetDoc(m_objProfile, m_uuidBudgetDocID);
                    // теперь запишем новый
                    if (bRet == true)
                    {
                        bRet = ERP_Budget.Common.CNoteType.MakeCommentToBudgetDoc(m_objProfile, m_uuidBudgetDocID, edComment.Text);
                        if (bRet == true)
                        {
                            m_strComment = edComment.Text;
                        }
                    }
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Во время сохранения комментария произошла ошибка.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bRet;
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (bSetComment() == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обработки нажатия клавиши.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (System.Exception f)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                "Ошибка обработки нажатия клавиши.\n\nТекст ошибки: " + f.Message, "Внимание",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

    }
}
