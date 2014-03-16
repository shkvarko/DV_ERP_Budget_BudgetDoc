using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErpBudgetBudgetDoc
{
   
    public partial class frmFind : DevExpress.XtraEditors.XtraForm
    {
        private System.String m_strFindText;
        public System.String FindText
        {
            get { return m_strFindText; }
            set { m_strFindText = value; }
        }
        public frmFind()
        {
            InitializeComponent();
            m_strFindText = "";
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                    "Ошибка обработки нажатия клавиши 'Отмена'.\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }

        private void btnOk_Click( object sender, EventArgs e )
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                m_strFindText = txtFind.Text;
                this.Close();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                    "Ошибка обработки нажатия клавиши 'Отмена'.\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }

        private void txtFind_KeyDown( object sender, KeyEventArgs e )
        {
            try
            {
                if( e.KeyCode == Keys.Enter )
                {
                    this.DialogResult = DialogResult.OK;
                    m_strFindText = txtFind.Text;
                    this.Close();
                }
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                    "Ошибка обработки 'txtFind_KeyDown'.\n" + f.Message, "Ошибка",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }

    }
}