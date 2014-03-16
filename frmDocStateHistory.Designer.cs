namespace ErpBudgetBudgetDoc
{
    partial class frmDocStateHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.toolTipController = new DevExpress.Utils.ToolTipController( this.components );
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.treeListDocState = new DevExpress.XtraTreeList.TreeList();
            this.colDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDocState = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUser = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblDebitArticle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ( ( System.ComponentModel.ISupportInitialize )( this.barManager ) ).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this.treeListDocState ) ).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange( new DevExpress.XtraBars.Bar[] {
            this.bar1} );
            this.barManager.DockControls.Add( this.barDockControlTop );
            this.barManager.DockControls.Add( this.barDockControlBottom );
            this.barManager.DockControls.Add( this.barDockControlLeft );
            this.barManager.DockControls.Add( this.barDockControlRight );
            this.barManager.Form = this;
            this.barManager.Items.AddRange( new DevExpress.XtraBars.BarItem[] {
            this.barBtnPrint,
            this.barBtnClose} );
            this.barManager.MaxItemId = 2;
            this.barManager.ToolTipController = this.toolTipController;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange( new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnClose)} );
            this.bar1.Text = "Custom 1";
            // 
            // barBtnPrint
            // 
            this.barBtnPrint.Caption = "������";
            this.barBtnPrint.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.printer2;
            this.barBtnPrint.Hint = "������";
            this.barBtnPrint.Id = 0;
            this.barBtnPrint.Name = "barBtnPrint";
            this.barBtnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler( this.barBtnPrint_ItemClick );
            // 
            // barBtnClose
            // 
            this.barBtnClose.Caption = "�����";
            this.barBtnClose.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.delete2;
            this.barBtnClose.Hint = "�����";
            this.barBtnClose.Id = 1;
            this.barBtnClose.Name = "barBtnClose";
            this.barBtnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler( this.barBtnClose_ItemClick );
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            this.tableLayoutPanel2.Controls.Add( this.treeListDocState, 0, 2 );
            this.tableLayoutPanel2.Controls.Add( this.tableLayoutPanel1, 0, 1 );
            this.tableLayoutPanel2.Controls.Add( this.lblInfo, 0, 0 );
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point( 0, 26 );
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding( 0 );
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
            this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 40F ) );
            this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            this.tableLayoutPanel2.Size = new System.Drawing.Size( 549, 329 );
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // treeListDocState
            // 
            this.treeListDocState.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) 
            | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.treeListDocState.Columns.AddRange( new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDate,
            this.colDocState,
            this.colUser} );
            this.treeListDocState.Location = new System.Drawing.Point( 3, 63 );
            this.treeListDocState.Name = "treeListDocState";
            this.treeListDocState.Size = new System.Drawing.Size( 543, 263 );
            this.treeListDocState.TabIndex = 4;
            // 
            // colDate
            // 
            this.colDate.Caption = "����";
            this.colDate.FieldName = "����";
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.OptionsColumn.AllowFocus = false;
            this.colDate.OptionsColumn.ReadOnly = true;
            this.colDate.VisibleIndex = 0;
            this.colDate.Width = 116;
            // 
            // colDocState
            // 
            this.colDocState.Caption = "���������";
            this.colDocState.FieldName = "���������";
            this.colDocState.Name = "colDocState";
            this.colDocState.OptionsColumn.AllowEdit = false;
            this.colDocState.OptionsColumn.AllowFocus = false;
            this.colDocState.OptionsColumn.ReadOnly = true;
            this.colDocState.VisibleIndex = 1;
            this.colDocState.Width = 128;
            // 
            // colUser
            // 
            this.colUser.Caption = "������������";
            this.colUser.FieldName = "������������";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.OptionsColumn.AllowFocus = false;
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.VisibleIndex = 2;
            this.colUser.Width = 184;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ( ( System.Windows.Forms.AnchorStyles )( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) 
            | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 58F ) );
            this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            this.tableLayoutPanel1.Controls.Add( this.lblMoney, 1, 1 );
            this.tableLayoutPanel1.Controls.Add( this.lblDebitArticle, 1, 0 );
            this.tableLayoutPanel1.Controls.Add( this.label2, 0, 0 );
            this.tableLayoutPanel1.Controls.Add( this.label3, 0, 1 );
            this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 20 );
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding( 0 );
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
            this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
            this.tableLayoutPanel1.Size = new System.Drawing.Size( 549, 40 );
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblMoney
            // 
            this.lblMoney.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point( 61, 23 );
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size( 49, 13 );
            this.lblMoney.TabIndex = 2;
            this.lblMoney.Text = "lblMoney";
            // 
            // lblDebitArticle
            // 
            this.lblDebitArticle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDebitArticle.AutoSize = true;
            this.lblDebitArticle.Location = new System.Drawing.Point( 61, 3 );
            this.lblDebitArticle.Name = "lblDebitArticle";
            this.lblDebitArticle.Size = new System.Drawing.Size( 72, 13 );
            this.lblDebitArticle.TabIndex = 1;
            this.lblDebitArticle.Text = "lblDebitArticle";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold );
            this.label2.Location = new System.Drawing.Point( 3, 3 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 52, 13 );
            this.label2.TabIndex = 1;
            this.label2.Text = "������:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold );
            this.label3.Location = new System.Drawing.Point( 3, 23 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 47, 13 );
            this.label3.TabIndex = 2;
            this.label3.Text = "�����:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Bold );
            this.lblInfo.Location = new System.Drawing.Point( 3, 3 );
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size( 43, 13 );
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "lblInfo";
            // 
            // frmDocStateHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 549, 355 );
            this.Controls.Add( this.tableLayoutPanel2 );
            this.Controls.Add( this.barDockControlLeft );
            this.Controls.Add( this.barDockControlRight );
            this.Controls.Add( this.barDockControlBottom );
            this.Controls.Add( this.barDockControlTop );
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size( 500, 300 );
            this.Name = "frmDocStateHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "������ ���������";
            this.Load += new System.EventHandler( this.frmDocStateHistory_Load );
            ( ( System.ComponentModel.ISupportInitialize )( this.barManager ) ).EndInit();
            this.tableLayoutPanel2.ResumeLayout( false );
            this.tableLayoutPanel2.PerformLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this.treeListDocState ) ).EndInit();
            this.tableLayoutPanel1.ResumeLayout( false );
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barBtnPrint;
        private DevExpress.XtraBars.BarButtonItem barBtnClose;
        private DevExpress.Utils.ToolTipController toolTipController;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraTreeList.TreeList treeListDocState;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblDebitArticle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDocState;
    }
}