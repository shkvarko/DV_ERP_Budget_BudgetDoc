using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ErpBudgetBudgetDoc
{
    public partial class frmDebitArticleEditor : DevExpress.XtraEditors.XtraForm
    {
        #region ����������, ��������, ���������
        private UniXP.Common.CProfile m_objProfile;
        private ERP_Budget.Common.CBudgetItem m_objBudgetItem;
        public ERP_Budget.Common.CBudgetItem BudgetItem
        {
            get { return m_objBudgetItem; }
        }
        /// <summary>
        /// ������ �� ������ "������"
        /// </summary>
        private ERP_Budget.Common.CBudget m_objBudget;
        /// <summary>
        /// ������ �� ������������ ������
        /// </summary>
        private ERP_Budget.Common.CBudgetItem m_objParentBudgetItem;
        #endregion

        #region �����������
        public frmDebitArticleEditor( UniXP.Common.CProfile objProfile )
        {
            InitializeComponent();

            this.m_objProfile = objProfile;
            this.m_objBudgetItem = null;
            this.m_objParentBudgetItem = null;
            this.m_objBudget = null;
            this.m_bCancelEvents = false;
        }
        #endregion

        #region ����� ���������
        /// <summary>
        /// �������� ����� ��������� ��������
        /// </summary>
        public void AddDebitArticleChild( ERP_Budget.Common.CBudgetItem objParentBudgetItem,
            ERP_Budget.Common.CBudget objBudget, ERP_Budget.Common.CCurrency objCurrency )
        {
            try
            {
                m_objBudgetItem = new ERP_Budget.Common.CBudgetItem();
                m_objBudgetItem.uuidID = System.Guid.NewGuid();
                m_objBudgetItem.BudgetGUID = objParentBudgetItem.BudgetGUID;
                m_objBudgetItem.TransprtRest = objParentBudgetItem.TransprtRest;
                m_objBudgetItem.DontChange = objParentBudgetItem.DontChange;
                m_objBudgetItem.OffExpenditures = objParentBudgetItem.OffExpenditures;
                m_objBudgetItem.ParentID = objParentBudgetItem.uuidID;
                m_objBudget = objBudget;
                m_objParentBudgetItem = objParentBudgetItem;

                for (System.Int32 i = 1; i <= 12; i++ )
                {
                    ERP_Budget.Common.CBudgetItemDecode objNewBudgetItemDecode =
                        new ERP_Budget.Common.CBudgetItemDecode((ERP_Budget.Common.enumMonth)i, objCurrency, "", 0);
                    m_objBudgetItem.AddBudgetItemDecode(objNewBudgetItemDecode);
                }

                // ������ �������� ������ ������ �������
                if (ERP_Budget.Common.CBudgetItem.LoadBudgetItemList(m_objProfile, treeList, m_objBudget) == true)
                {
                    if ( treeList.Nodes.Count > 0 )
                    {
                        foreach ( DevExpress.XtraTreeList.Nodes.TreeListNode objNode in treeList.Nodes )
                        {
                            objNode.Visible = (((System.Guid)objNode.GetValue(colDEBITARTICLE_GUID_ID)) == m_objParentBudgetItem.uuidID);
                        }
                        treeList.ExpandAll();
                    }
                }
                m_bCancelEvents = false;
                SetModified( false );
                this.ShowDialog();
            }
            catch( System.Exception f )
            {
                System.Windows.Forms.MessageBox.Show( null, "������ �������� ��������� �������.\n\n����� ������:\n" + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
            finally
            {
            }
            return;
        }

        #endregion

        #region ��������� ���������

        private System.Boolean m_bIsModified;
        private System.Boolean m_bCancelEvents;
        /// <summary>
        /// ������������� ��������� "�������� ������"
        /// </summary>
        private void SetModified( System.Boolean bModified )
        {
            try
            {
                m_bIsModified = bModified;
                btnSave.Enabled = bModified;
                btnCancel.Enabled = bModified;
            }
            catch( System.Exception f )
            {
                System.Windows.Forms.MessageBox.Show( this, "������ ������ SetModified().\n\n����� ������: " + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
            return;
        }
        /// <summary>
        /// ���������� ������� ����, ���������� �� ������
        /// </summary>
        /// <returns>true - ����������; false - �� ����������</returns>
        private System.Boolean IsModified()
        {
            System.Boolean bRes = false;
            try
            {
                return m_bIsModified;
            }
            catch( System.Exception e )
            {
                System.Windows.Forms.MessageBox.Show( this,
                    e.Message, "������",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning );
            }
            return bRes;
        }

        private void EditValueChanged( object sender, EventArgs e )
        {
            try
            {
                if( this.m_bCancelEvents == false )
                {
                    SetModified( true );
                }
            }
            catch( System.Exception f )
            {
                System.Windows.Forms.MessageBox.Show( this,
                "������ ������� EditValueChanged.\n������ : " + ( ( Control )sender ).Name + "\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }

        private void chklstBudgetDep_ItemCheck( object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e )
        {
            try
            {
                if( this.m_bCancelEvents == false )
                {
                    SetModified( true );
                }
            }
            catch( System.Exception f )
            {
                System.Windows.Forms.MessageBox.Show( this,
                "������ ������� chklstBudgetDep_ItemCheck.\n������ : " + ( ( Control )sender ).Name + "\n\n����� ������: " + f.Message, "��������",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

        #region ���������� ������� ������ ��������
        /// <summary>
        /// ����������� ��������� ������� �������� �� ��������� ����������
        /// </summary>
        /// <returns>true - �������� ������ �������;false - ������</returns>
        private System.Boolean bInitDebitArticleParams()
        {
            System.Boolean bRet = false;
            try
            {
                if ( treeList.FocusedNode == null )
                {
                    return bRet;
                }
                m_objBudgetItem.BudgetItemNum = txtDebitArticleNum.Text;
                m_objBudgetItem.Name = txtDebitArticleName.Text;
                m_objBudgetItem.BudgetItemDescription = txtDebitArticleDscrpn.Text;
                m_objBudgetItem.BudgetItemID = treeList.FocusedNode.Nodes.Count + 1;
                bRet = true;
            }
            catch( System.Exception f )
            {
                bRet = false;
                System.Windows.Forms.MessageBox.Show( this, "������ ������������� ������� ������� \"������ �������\".\n\n����� ������:\n" + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return bRet;
        }

        /// <summary>
        /// ��������� ���� ��������� ��������
        /// </summary>
        /// <returns>true - �������� ����������; false - ������</returns>
        private System.Boolean bSaveDebitArticle()
        {
            System.Boolean bRet = false;
            try
            {
                // ������ �������� ��������� ������� "������ ��������" �������� �� ��������� ����������
                bRet = bInitDebitArticleParams();
                if( bRet == true )
                {
                    // ������ �������� ������������ ���������
                    bRet = this.m_objBudgetItem.IsValidateProperties();
                }
                if( bRet == true )
                {
                    bRet = this.m_objBudgetItem.Add( this.m_objProfile );
                }
                if (bRet == true)
                {
                    bRet = this.m_objBudgetItem.SaveBudgetItem(m_objProfile);
                }

            }
            catch( System.Exception f )
            {
                System.Windows.Forms.MessageBox.Show( this, "������ ���������� ������� ������� \"������ ��������\".\n\n����� ������:\n" + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return bRet;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            try
            {
                if( IsModified() == false ) { return; }
                if( bSaveDebitArticle() )
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch( System.Exception f )
            {
                System.Windows.Forms.MessageBox.Show( this, "������ ���������� ������� ������ ��������.\n\n����� ������:\n" + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }

        #endregion

        #region ������
        private void btnCancel_Click( object sender, EventArgs e )
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch( System.Exception f )
            {
                System.Windows.Forms.MessageBox.Show( null, "������ ������ ���������.\n\n����� ������:\n" + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }
        #endregion

        private void frmDebitArticleEditor_Shown( object sender, EventArgs e )
        {
            try
            {
                txtDebitArticleName.Focus();
            }
            catch( System.Exception f )
            {
                System.Windows.Forms.MessageBox.Show( this, "������ ����������� �����.\n\n����� ������:\n" + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }

            return;
        }

        private void treeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if(( treeList.Nodes.Count > 0 ) && ( treeList.FocusedNode != null ) && ( treeList.FocusedNode.Tag != null ))
                {
                    ERP_Budget.Common.CBudgetItem objBudgetItem = ( ERP_Budget.Common.CBudgetItem )treeList.FocusedNode.Tag;
                    System.Boolean bHasChildren = treeList.FocusedNode.HasChildren;
                    if (bHasChildren == true)
                    {
                        txtDebitArticleNum.Text = objBudgetItem.BudgetItemNum + "." + (treeList.FocusedNode.Nodes.Count + 1).ToString();
                    } 
                    else
                    {
                        txtDebitArticleNum.Text = "";
                        txtDebitArticleName.Text = "";
                        txtDebitArticleDscrpn.Text = "";
                    }
                    txtDebitArticleNum.Enabled = bHasChildren;
                    txtDebitArticleName.Enabled = bHasChildren;
                    txtDebitArticleDscrpn.Enabled = bHasChildren;
                }
            }
            catch (System.Exception f)
            {
                System.Windows.Forms.MessageBox.Show(this, "������ ����� ������.\n\n����� ������:\n" + f.Message, "������",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


    }
}