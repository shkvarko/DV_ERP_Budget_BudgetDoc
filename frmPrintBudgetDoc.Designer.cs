namespace ErpBudgetBudgetDoc
{
    partial class frmPrintBudgetDoc
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
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            this.TabPageTree = new DevExpress.XtraTab.XtraTabPage();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.colParametr = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.TabPageList = new DevExpress.XtraTab.XtraTabPage();
            this.memoEdit = new DevExpress.XtraEditors.MemoEdit();
            ( ( System.ComponentModel.ISupportInitialize )( this.barManager ) ).BeginInit();
            ( ( System.ComponentModel.ISupportInitialize )( this.TabControl ) ).BeginInit();
            this.TabControl.SuspendLayout();
            this.TabPageTree.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this.treeList ) ).BeginInit();
            this.TabPageList.SuspendLayout();
            ( ( System.ComponentModel.ISupportInitialize )( this.memoEdit.Properties ) ).BeginInit();
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
            this.barBtnPrint.Caption = "Печать";
            this.barBtnPrint.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.printer2;
            this.barBtnPrint.Hint = "Печать";
            this.barBtnPrint.Id = 0;
            this.barBtnPrint.Name = "barBtnPrint";
            this.barBtnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler( this.barBtnPrint_ItemClick );
            // 
            // barBtnClose
            // 
            this.barBtnClose.Caption = "Выход";
            this.barBtnClose.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.delete2;
            this.barBtnClose.Hint = "Выход";
            this.barBtnClose.Id = 1;
            this.barBtnClose.Name = "barBtnClose";
            this.barBtnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler( this.barBtnClose_ItemClick );
            // 
            // TabControl
            // 
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point( 0, 26 );
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedTabPage = this.TabPageTree;
            this.TabControl.Size = new System.Drawing.Size( 489, 301 );
            this.TabControl.TabIndex = 4;
            this.TabControl.TabPages.AddRange( new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageTree,
            this.TabPageList} );
            // 
            // TabPageTree
            // 
            this.TabPageTree.Controls.Add( this.treeList );
            this.TabPageTree.Name = "TabPageTree";
            this.TabPageTree.Size = new System.Drawing.Size( 485, 275 );
            this.TabPageTree.Text = "дерево";
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange( new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colParametr,
            this.colValue} );
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point( 0, 0 );
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.Size = new System.Drawing.Size( 485, 275 );
            this.treeList.TabIndex = 6;
            this.treeList.ToolTipController = this.toolTipController;
            // 
            // colParametr
            // 
            this.colParametr.Caption = "Наименование";
            this.colParametr.FieldName = "Дата";
            this.colParametr.Name = "colParametr";
            this.colParametr.OptionsColumn.AllowEdit = false;
            this.colParametr.OptionsColumn.AllowFocus = false;
            this.colParametr.OptionsColumn.ReadOnly = true;
            this.colParametr.VisibleIndex = 0;
            this.colParametr.Width = 116;
            // 
            // colValue
            // 
            this.colValue.Caption = "Состояние";
            this.colValue.FieldName = "Состояние";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowEdit = false;
            this.colValue.OptionsColumn.AllowFocus = false;
            this.colValue.OptionsColumn.ReadOnly = true;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 128;
            // 
            // TabPageList
            // 
            this.TabPageList.Controls.Add( this.memoEdit );
            this.TabPageList.Name = "TabPageList";
            this.TabPageList.Size = new System.Drawing.Size( 485, 275 );
            this.TabPageList.Text = "список";
            // 
            // memoEdit
            // 
            this.memoEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit.EditValue = "asd\r\nasd\r\nadsdd";
            this.memoEdit.Location = new System.Drawing.Point( 0, 0 );
            this.memoEdit.Name = "memoEdit";
            this.memoEdit.Properties.ReadOnly = true;
            this.memoEdit.Size = new System.Drawing.Size( 485, 275 );
            this.memoEdit.TabIndex = 0;
            // 
            // frmPrintBudgetDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 489, 327 );
            this.Controls.Add( this.TabControl );
            this.Controls.Add( this.barDockControlLeft );
            this.Controls.Add( this.barDockControlRight );
            this.Controls.Add( this.barDockControlBottom );
            this.Controls.Add( this.barDockControlTop );
            this.MinimumSize = new System.Drawing.Size( 400, 300 );
            this.Name = "frmPrintBudgetDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Печать";
            this.Load += new System.EventHandler( this.frmPrintBudgetDoc_Load );
            ( ( System.ComponentModel.ISupportInitialize )( this.barManager ) ).EndInit();
            ( ( System.ComponentModel.ISupportInitialize )( this.TabControl ) ).EndInit();
            this.TabControl.ResumeLayout( false );
            this.TabPageTree.ResumeLayout( false );
            ( ( System.ComponentModel.ISupportInitialize )( this.treeList ) ).EndInit();
            this.TabPageList.ResumeLayout( false );
            ( ( System.ComponentModel.ISupportInitialize )( this.memoEdit.Properties ) ).EndInit();
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
        private DevExpress.XtraTab.XtraTabControl TabControl;
        private DevExpress.XtraTab.XtraTabPage TabPageTree;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParametr;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colValue;
        private DevExpress.XtraTab.XtraTabPage TabPageList;
        private DevExpress.XtraEditors.MemoEdit memoEdit;
    }
}