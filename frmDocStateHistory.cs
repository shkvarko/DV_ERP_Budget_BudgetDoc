using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErpBudgetBudgetDoc
{
    public partial class frmDocStateHistory : DevExpress.XtraEditors.XtraForm
    {
        #region ����������, ��������, ���������

        private UniXP.Common.CProfile m_objProfile;
        private ERP_Budget.Common.CBudgetDoc m_objBudgetDoc;

        #endregion

        #region �����������
        public frmDocStateHistory( UniXP.Common.CProfile objProfile, ERP_Budget.Common.CBudgetDoc objBudgetDoc )
        {
            InitializeComponent();

            this.m_objProfile = objProfile;
            this.m_objBudgetDoc = objBudgetDoc;
        }
        #endregion

        #region ���������� ������� ���������
        /// <summary>
        /// ��������� ������ ���������
        /// </summary>
        /// <returns>true - �������� ����������; false - ������</returns>
        System.Boolean bRefreshDocStateList()
        {
            System.Boolean bRet = false;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                treeListDocState.Nodes.Clear();
                System.String strInfoText = String.Format( "\t\t������ {0} \t\t {1} �� {2} \t\t��������� {3}",
                   this.m_objBudgetDoc.BudgetDep.Name, this.m_objBudgetDoc.DocType.Name,
                   this.m_objBudgetDoc.Date.ToShortDateString(), ( this.m_objBudgetDoc.OwnerUser.UserLastName + " " + this.m_objBudgetDoc.OwnerUser.UserFirstName ) );
                lblInfo.Text = strInfoText;

                lblMoney.Text = "\t\t" +  System.String.Format( "{0:### ### ##0.00}", this.m_objBudgetDoc.Money ) + " " + 
                    this.m_objBudgetDoc.Currency.CurrencyCode;
                lblDebitArticle.Text = "\t\t" +  this.m_objBudgetDoc.BudgetItem.BudgetItemFullName;

                //������ ���������
                List<ERP_Budget.Common.structBudgetDocStateHistory> objList = this.m_objBudgetDoc.GetBudgetDocHistory( this.m_objProfile );
                if( ( objList != null ) && ( objList.Count > 0 ) )
                {
                    foreach( ERP_Budget.Common.structBudgetDocStateHistory objDocStateHistory in objList )
                    {
                        // ��������� ���� � ������
                        treeListDocState.AppendNode( new object[] { objDocStateHistory.HistoryDate,
                            objDocStateHistory.BudgetDocState.Name, 
                          ( objDocStateHistory.UserHistory.UserLastName + " " + 
                            objDocStateHistory.UserHistory.UserFirstName ) }, null );
                    }
                }
                bRet = true;

            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                "������ ���������� ������� ���������.\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            return bRet;
        }
        #endregion

        #region �������� �����
        private void frmDocStateHistory_Load( object sender, EventArgs e )
        {
            try
            {
                // ��������� ������ ��������
                bRefreshDocStateList();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                "������ �������� ������� ���������.\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

        #region �������� �����
        private void barBtnClose_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                this.Close();
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( 
                "������ �������� ������� ���������.\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

        #region ������
        private void barBtnPrint_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if( DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable )
                    DevExpress.XtraPrinting.PrintHelper.ShowPreview( treeListDocState );
                else
                    MessageBox.Show( "XtraPrinting Library is not found...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                Cursor.Current = Cursors.Default;
            }
            catch( System.Exception f )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show( "������ ������.\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

    }
}