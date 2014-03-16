namespace ErpBudgetBudgetDoc
{
    partial class frmBudgetDocList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudgetDocList));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnRefres = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnNewDoc = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnEditDoc = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCopyDoc = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDeleteDoc = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnAutoRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.lblStatusBar = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TabControlDocList = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageDocWork = new DevExpress.XtraTab.XtraTabPage();
            this.gridDocWork = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemNewBudgetDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemCopyBudgetDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDeleteBudgetDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemTrnList = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDocStateList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.mitemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemChange = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemChangePaymentDate = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemChangeCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemChangePaymentType = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDePay = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemChangeDocType = new System.Windows.Forms.ToolStripMenuItem();
            this.dsBudgetDoc = new System.Data.DataSet();
            this.dtDocWork = new System.Data.DataTable();
            this.A_BUDGETDOC_GUID_ID = new System.Data.DataColumn();
            this.A_CREATEDUSER_NAME = new System.Data.DataColumn();
            this.A_DOCDATE = new System.Data.DataColumn();
            this.A_BUDGETDEP_NAME = new System.Data.DataColumn();
            this.A_DOCOBJECTIVE = new System.Data.DataColumn();
            this.A_DOCMONEY = new System.Data.DataColumn();
            this.A_DEBITARTICLE_NAME = new System.Data.DataColumn();
            this.A_COMPANY_NAME = new System.Data.DataColumn();
            this.A_BUDGETDOCSTATE_NAME = new System.Data.DataColumn();
            this.A_IMAGE_ID = new System.Data.DataColumn();
            this.A_DOCACTIVE = new System.Data.DataColumn();
            this.A_RECIPIENT = new System.Data.DataColumn();
            this.A_IMAGETYPE_ID = new System.Data.DataColumn();
            this.A_BUDGETDOCTYPE_NAME = new System.Data.DataColumn();
            this.A_DATESTATE = new System.Data.DataColumn();
            this.A_ATTACH = new System.Data.DataColumn();
            this.A_CURRENCY = new System.Data.DataColumn();
            this.A_DOCMONEYAGREE = new System.Data.DataColumn();
            this.A_ACCTRNSUM = new System.Data.DataColumn();
            this.A_SALDOTRN = new System.Data.DataColumn();
            this.A_NOTETYPE = new System.Data.DataColumn();
            this.A_NOTETYPE_PREV = new System.Data.DataColumn();
            this.A_USERCOMMENT = new System.Data.DataColumn();
            this.A_PAYMENTTYPE_NAME = new System.Data.DataColumn();
            this.A_BUDGETEXPENSETYPE_NAME = new System.Data.DataColumn();
            this.dtDocWorked = new System.Data.DataTable();
            this.B_BUDGETDOC_GUID_ID = new System.Data.DataColumn();
            this.B_CREATEDUSER_NAME = new System.Data.DataColumn();
            this.B_DOCDATE = new System.Data.DataColumn();
            this.B_BUDGETDEP_NAME = new System.Data.DataColumn();
            this.B_DOCOBJECTIVE = new System.Data.DataColumn();
            this.B_DOCMONEY = new System.Data.DataColumn();
            this.B_DEBITARTICLE_NAME = new System.Data.DataColumn();
            this.B_COMPANY_NAME = new System.Data.DataColumn();
            this.B_BUDGETDOCSTATE_NAME = new System.Data.DataColumn();
            this.B_IMAGE_ID = new System.Data.DataColumn();
            this.B_DOCACTIVE = new System.Data.DataColumn();
            this.B_RECIPIENT = new System.Data.DataColumn();
            this.B_IMAGETYPE_ID = new System.Data.DataColumn();
            this.B_BUDGETDOCTYPE_NAME = new System.Data.DataColumn();
            this.B_DATESTATE = new System.Data.DataColumn();
            this.B_ATTACH = new System.Data.DataColumn();
            this.B_CURRENCY = new System.Data.DataColumn();
            this.B_DOCMONEYAGREE = new System.Data.DataColumn();
            this.B_ACCTRNSUM = new System.Data.DataColumn();
            this.B_SALDOTRN = new System.Data.DataColumn();
            this.B_NOTETYPE = new System.Data.DataColumn();
            this.B_NOTETYPE_PREV = new System.Data.DataColumn();
            this.B_USERCOMMENT = new System.Data.DataColumn();
            this.B_PAYMENTTYPE_NAME = new System.Data.DataColumn();
            this.B_BUDGETEXPENSETYPE_NAME = new System.Data.DataColumn();
            this.dtDocNotActive = new System.Data.DataTable();
            this.C_BUDGETDOC_GUID_ID = new System.Data.DataColumn();
            this.C_CREATEDUSER_NAME = new System.Data.DataColumn();
            this.C_DOCDATE = new System.Data.DataColumn();
            this.C_BUDGETDEP_NAME = new System.Data.DataColumn();
            this.C_DOCOBJECTIVE = new System.Data.DataColumn();
            this.C_DOCMONEY = new System.Data.DataColumn();
            this.C_DEBITARTICLE_NAME = new System.Data.DataColumn();
            this.C_COMPANY_NAME = new System.Data.DataColumn();
            this.C_BUDGETDOCSTATE_NAME = new System.Data.DataColumn();
            this.C_IMAGE_ID = new System.Data.DataColumn();
            this.C_DOCACTIVE = new System.Data.DataColumn();
            this.C_RECIPIENT = new System.Data.DataColumn();
            this.C_IMAGETYPE_ID = new System.Data.DataColumn();
            this.C_BUDGETDOCTYPE_NAME = new System.Data.DataColumn();
            this.C_DATESTATE = new System.Data.DataColumn();
            this.C_ATTACH = new System.Data.DataColumn();
            this.C_CURRENCY = new System.Data.DataColumn();
            this.C_DOCMONEYAGREE = new System.Data.DataColumn();
            this.C_ACCTRNSUM = new System.Data.DataColumn();
            this.C_SALDOTRN = new System.Data.DataColumn();
            this.C_NOTETYPE = new System.Data.DataColumn();
            this.C_NOTETYPE_PREV = new System.Data.DataColumn();
            this.C_USERCOMMENT = new System.Data.DataColumn();
            this.C_PAYMENTTYPE_NAME = new System.Data.DataColumn();
            this.C_BUDGETEXPENSETYPE_NAME = new System.Data.DataColumn();
            this.dtDocError = new System.Data.DataTable();
            this.E_BUDGETDOC_GUID_ID = new System.Data.DataColumn();
            this.E_CREATEDUSER_NAME = new System.Data.DataColumn();
            this.E_DOCDATE = new System.Data.DataColumn();
            this.E_BUDGETDEP_NAME = new System.Data.DataColumn();
            this.E_DOCOBJECTIVE = new System.Data.DataColumn();
            this.E_DOCMONEY = new System.Data.DataColumn();
            this.E_DEBITARTICLE_NAME = new System.Data.DataColumn();
            this.E_COMPANY_NAME = new System.Data.DataColumn();
            this.E_BUDGETDOCSTATE_NAME = new System.Data.DataColumn();
            this.E_IMAGE_ID = new System.Data.DataColumn();
            this.E_DOCACTIVE = new System.Data.DataColumn();
            this.E_RECIPIENT = new System.Data.DataColumn();
            this.E_IMAGETYPE_ID = new System.Data.DataColumn();
            this.E_BUDGETDOCTYPE_NAME = new System.Data.DataColumn();
            this.E_DATESTATE = new System.Data.DataColumn();
            this.E_ATTACH = new System.Data.DataColumn();
            this.E_CURRENCY = new System.Data.DataColumn();
            this.E_DOCMONEYAGREE = new System.Data.DataColumn();
            this.E_ACCTRNSUM = new System.Data.DataColumn();
            this.E_SALDOTRN = new System.Data.DataColumn();
            this.E_NOTETYPE = new System.Data.DataColumn();
            this.E_NOTETYPE_PREV = new System.Data.DataColumn();
            this.E_USERCOMMENT = new System.Data.DataColumn();
            this.E_PAYMENTTYPE_NAME = new System.Data.DataColumn();
            this.E_BUDGETEXPENSETYPE_NAME = new System.Data.DataColumn();
            this.gridViewDocWork = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colA_IMAGE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_IMAGETYPE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_ATTACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_BUDGETDOC_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_CREATEDUSER_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_DOCDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_BUDGETDEP_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_DOCOBJECTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_DOCMONEY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_DEBITARTICLE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_COMPANY_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_BUDGETDOCSTATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_DATESTATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_BUDGETDOCTYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_RECIPIENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_CURRENCY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_DOCMONEYAGREE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_ACCTRNSUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_SALDOTRN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_NOTETYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_NOTETYPE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_NOTETYPE_PREVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_COMMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_COMMENTTEXT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_PAYMENTTYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colA_BUDGETEXPENSETYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.tabPageDocWorked = new DevExpress.XtraTab.XtraTabPage();
            this.gridDocWorked = new DevExpress.XtraGrid.GridControl();
            this.gridViewDocWorked = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colB_IMAGE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_IMAGETYPE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_ATTACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_BUDGETDOC_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_CREATEDUSER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_CREATEDUSER_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_DOCDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_BUDGETDEP_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_BUDGETDEP_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_DOCOBJECTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_DOCMONEY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_BUDGETITEM_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_DEBITARTICLE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_COMPANY_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_COMPANY_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_BUDGETDOCSTATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_BUDGETDOCSTATE_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_DATESTATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_BUDGETDOCTYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_RECIPIENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_CURRENCY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_DOCMONEYAGREE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_ACCTRNSUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_SALDOTRN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_NOTETYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_NOTETYPE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_NOTETYPE_PREVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_COMMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_COMMENTTEXT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_PAYMENTTYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB_BUDGETEXPENSETYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageDocNotActive = new DevExpress.XtraTab.XtraTabPage();
            this.tableLPFind = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFind = new DevExpress.XtraEditors.PanelControl();
            this.radioGroupDateType = new DevExpress.XtraEditors.RadioGroup();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dtBeginDate = new DevExpress.XtraEditors.DateEdit();
            this.gridDocNotActive = new DevExpress.XtraGrid.GridControl();
            this.gridViewDocNotActive = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colС_IMAGE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_IMAGETYPE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_ATTACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_BUDGETDOC_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_CREATEDUSER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_CREATEDUSER_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DOCDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_BUDGETDEP_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_BUDGETDEP_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DOCOBJECTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DOCMONEY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_BUDGETITEM_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DEBITARTICLE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_COMPANY_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_COMPANY_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_BUDGETDOCSTATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_BUDGETDOCSTATE_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DATESTATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_BUDGETDOCTYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_RECIPIENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_CURRENCY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_DOCMONEYAGREE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_ACCTRNSUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_SALDOTRN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NOTETYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NOTETYPE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_NOTETYPE_PREVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_COMMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_COMMENTTEXT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_PAYMENTTYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC_BUDGETEXPENSETYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageError = new DevExpress.XtraTab.XtraTabPage();
            this.gridDocErr = new DevExpress.XtraGrid.GridControl();
            this.gridViewDocErr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colE_IMAGE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_IMAGETYPE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_BUDGETDOC_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_CREATEDUSER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_CREATEDUSER_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_DOCDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_BUDGETDEP_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_BUDGETDEP_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_DOCOBJECTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_DOCMONEY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_BUDGETITEM_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_DEBITARTICLE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_COMPANY_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_COMPANY_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_BUDGETDOCSTATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_BUDGETDOCSTATE_GUID_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_DOCACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_BUDGETDOCTYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colE_PAYMENTTYPE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuNoteType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuComment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitemAddComment = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDeleteComment = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabControlDocList)).BeginInit();
            this.TabControlDocList.SuspendLayout();
            this.tabPageDocWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocWork)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsBudgetDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocWorked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocNotActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.tabPageDocWorked.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocWorked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocWorked)).BeginInit();
            this.tabPageDocNotActive.SuspendLayout();
            this.tableLPFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFind)).BeginInit();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupDateType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocNotActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocNotActive)).BeginInit();
            this.tabPageError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocErr)).BeginInit();
            this.contextMenuNoteType.SuspendLayout();
            this.contextMenuComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.barStatus});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnRefres,
            this.barBtnNewDoc,
            this.barBtnEditDoc,
            this.barBtnCopyDoc,
            this.barBtnDeleteDoc,
            this.barBtnAutoRefresh,
            this.lblStatusBar});
            this.barManager.MaxItemId = 14;
            this.barManager.StatusBar = this.barStatus;
            this.barManager.ToolTipController = this.toolTipController;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRefres),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnNewDoc),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnEditDoc),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnCopyDoc),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnDeleteDoc),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnAutoRefresh)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 1";
            // 
            // barBtnRefres
            // 
            this.barBtnRefres.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.refresh;
            this.barBtnRefres.Hint = "Обновить список";
            this.barBtnRefres.Id = 0;
            this.barBtnRefres.Name = "barBtnRefres";
            this.barBtnRefres.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRefres_ItemClick);
            // 
            // barBtnNewDoc
            // 
            this.barBtnNewDoc.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.mail_add;
            this.barBtnNewDoc.Hint = "Новая заявка";
            this.barBtnNewDoc.Id = 1;
            this.barBtnNewDoc.Name = "barBtnNewDoc";
            this.barBtnNewDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnNewDoc_ItemClick);
            // 
            // barBtnEditDoc
            // 
            this.barBtnEditDoc.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.mail_write;
            this.barBtnEditDoc.Hint = "Редактировать заявку";
            this.barBtnEditDoc.Id = 2;
            this.barBtnEditDoc.Name = "barBtnEditDoc";
            this.barBtnEditDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEditDoc_ItemClick);
            // 
            // barBtnCopyDoc
            // 
            this.barBtnCopyDoc.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.mail_exchange;
            this.barBtnCopyDoc.Hint = "Копировать заявку";
            this.barBtnCopyDoc.Id = 3;
            this.barBtnCopyDoc.Name = "barBtnCopyDoc";
            this.barBtnCopyDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCopyDoc_ItemClick);
            // 
            // barBtnDeleteDoc
            // 
            this.barBtnDeleteDoc.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.mail_delete;
            this.barBtnDeleteDoc.Hint = "Удалить заявку";
            this.barBtnDeleteDoc.Id = 4;
            this.barBtnDeleteDoc.Name = "barBtnDeleteDoc";
            // 
            // barBtnAutoRefresh
            // 
            this.barBtnAutoRefresh.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.barBtnAutoRefresh.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.clock_stop;
            this.barBtnAutoRefresh.Hint = "Автообновление";
            this.barBtnAutoRefresh.Id = 7;
            this.barBtnAutoRefresh.Name = "barBtnAutoRefresh";
            this.barBtnAutoRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAutoRefresh_ItemClick);
            // 
            // barStatus
            // 
            this.barStatus.BarName = "barStatus";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatusBar)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.AllowRename = true;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "barStatus";
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblStatusBar.Caption = "lblStatusBar";
            this.lblStatusBar.Id = 12;
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.toolTipController.SetSuperTip(this.barDockControlTop, null);
            // 
            // barDockControlBottom
            // 
            this.toolTipController.SetSuperTip(this.barDockControlBottom, null);
            // 
            // barDockControlLeft
            // 
            this.toolTipController.SetSuperTip(this.barDockControlLeft, null);
            // 
            // barDockControlRight
            // 
            this.toolTipController.SetSuperTip(this.barDockControlRight, null);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TabControlDocList, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 365);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // TabControlDocList
            // 
            this.TabControlDocList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlDocList.Location = new System.Drawing.Point(3, 3);
            this.TabControlDocList.Name = "TabControlDocList";
            this.TabControlDocList.SelectedTabPage = this.tabPageDocWork;
            this.TabControlDocList.Size = new System.Drawing.Size(582, 359);
            this.TabControlDocList.TabIndex = 0;
            this.TabControlDocList.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageDocWork,
            this.tabPageDocWorked,
            this.tabPageDocNotActive,
            this.tabPageError});
            this.TabControlDocList.ToolTipController = this.toolTipController;
            // 
            // tabPageDocWork
            // 
            this.tabPageDocWork.Controls.Add(this.gridDocWork);
            this.tabPageDocWork.Image = global::ErpBudgetBudgetDoc.Properties.Resources.mail_new;
            this.tabPageDocWork.Name = "tabPageDocWork";
            this.tabPageDocWork.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDocWork.Size = new System.Drawing.Size(573, 326);
            this.tabPageDocWork.Text = "Необработанные заявки";
            this.tabPageDocWork.Tooltip = "Список заявок, ожидающих обработки";
            // 
            // gridDocWork
            // 
            this.gridDocWork.ContextMenuStrip = this.contextMenuStrip;
            this.gridDocWork.DataMember = "dtDocWork";
            this.gridDocWork.DataSource = this.dsBudgetDoc;
            this.gridDocWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDocWork.EmbeddedNavigator.Name = "";
            this.gridDocWork.Location = new System.Drawing.Point(3, 3);
            this.gridDocWork.MainView = this.gridViewDocWork;
            this.gridDocWork.Name = "gridDocWork";
            this.gridDocWork.Size = new System.Drawing.Size(567, 320);
            this.gridDocWork.TabIndex = 0;
            this.gridDocWork.ToolTipController = this.toolTipController;
            this.gridDocWork.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDocWork});
            this.gridDocWork.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemRefresh,
            this.mitemNewBudgetDoc,
            this.mitemCopyBudgetDoc,
            this.mitemDeleteBudgetDoc,
            this.toolStripMenuItem1,
            this.mitemTrnList,
            this.mitemDocStateList,
            this.toolStripMenuItem8,
            this.mitemExportToExcel,
            this.mitemChange,
            this.mitemDePay,
            this.mitemChangeDocType});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(246, 258);
            this.toolTipController.SetSuperTip(this.contextMenuStrip, null);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // mitemRefresh
            // 
            this.mitemRefresh.Name = "mitemRefresh";
            this.mitemRefresh.Size = new System.Drawing.Size(245, 22);
            this.mitemRefresh.Text = "Обновить";
            this.mitemRefresh.Click += new System.EventHandler(this.mitemRefresh_Click);
            // 
            // mitemNewBudgetDoc
            // 
            this.mitemNewBudgetDoc.Name = "mitemNewBudgetDoc";
            this.mitemNewBudgetDoc.Size = new System.Drawing.Size(245, 22);
            this.mitemNewBudgetDoc.Text = "Создать заявку";
            this.mitemNewBudgetDoc.Click += new System.EventHandler(this.mitemNewBudgetDoc_Click);
            // 
            // mitemCopyBudgetDoc
            // 
            this.mitemCopyBudgetDoc.Name = "mitemCopyBudgetDoc";
            this.mitemCopyBudgetDoc.Size = new System.Drawing.Size(245, 22);
            this.mitemCopyBudgetDoc.Text = "Копировать заявку";
            this.mitemCopyBudgetDoc.Click += new System.EventHandler(this.mitemCopyBudgetDoc_Click);
            // 
            // mitemDeleteBudgetDoc
            // 
            this.mitemDeleteBudgetDoc.Name = "mitemDeleteBudgetDoc";
            this.mitemDeleteBudgetDoc.Size = new System.Drawing.Size(245, 22);
            this.mitemDeleteBudgetDoc.Text = "Удалить заявку";
            this.mitemDeleteBudgetDoc.Click += new System.EventHandler(this.mitemDeleteBudgetDoc_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
            // 
            // mitemTrnList
            // 
            this.mitemTrnList.Name = "mitemTrnList";
            this.mitemTrnList.Size = new System.Drawing.Size(245, 22);
            this.mitemTrnList.Text = "Журнал транзакций";
            this.mitemTrnList.Click += new System.EventHandler(this.mitemTrnList_Click);
            // 
            // mitemDocStateList
            // 
            this.mitemDocStateList.Name = "mitemDocStateList";
            this.mitemDocStateList.Size = new System.Drawing.Size(245, 22);
            this.mitemDocStateList.Text = "Журнал состояний";
            this.mitemDocStateList.Click += new System.EventHandler(this.mitemDocStateList_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(242, 6);
            // 
            // mitemExportToExcel
            // 
            this.mitemExportToExcel.Name = "mitemExportToExcel";
            this.mitemExportToExcel.Size = new System.Drawing.Size(245, 22);
            this.mitemExportToExcel.Text = "Экспорт списка заявок в MS Excel";
            this.mitemExportToExcel.Click += new System.EventHandler(this.sbExportToXLS_Click);
            // 
            // mitemChange
            // 
            this.mitemChange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemChangePaymentDate,
            this.mitemChangeCompany,
            this.mitemChangePaymentType});
            this.mitemChange.Name = "mitemChange";
            this.mitemChange.Size = new System.Drawing.Size(245, 22);
            this.mitemChange.Text = "Редактировать";
            // 
            // mitemChangePaymentDate
            // 
            this.mitemChangePaymentDate.Name = "mitemChangePaymentDate";
            this.mitemChangePaymentDate.Size = new System.Drawing.Size(159, 22);
            this.mitemChangePaymentDate.Text = "Дату оплаты...";
            this.mitemChangePaymentDate.Click += new System.EventHandler(this.mitemChangeDateBudgetDoc_Click);
            // 
            // mitemChangeCompany
            // 
            this.mitemChangeCompany.Name = "mitemChangeCompany";
            this.mitemChangeCompany.Size = new System.Drawing.Size(159, 22);
            this.mitemChangeCompany.Text = "Компанию...";
            this.mitemChangeCompany.Click += new System.EventHandler(this.mitemChangeCompany_Click);
            // 
            // mitemChangePaymentType
            // 
            this.mitemChangePaymentType.Name = "mitemChangePaymentType";
            this.mitemChangePaymentType.Size = new System.Drawing.Size(159, 22);
            this.mitemChangePaymentType.Text = "Форму оплаты...";
            this.mitemChangePaymentType.Click += new System.EventHandler(this.mitemChangePaymentType_Click);
            // 
            // mitemDePay
            // 
            this.mitemDePay.Name = "mitemDePay";
            this.mitemDePay.Size = new System.Drawing.Size(245, 22);
            this.mitemDePay.Text = "Аннулировать оплату";
            this.mitemDePay.Click += new System.EventHandler(this.mitemDePayBudgetDoc_Click);
            // 
            // mitemChangeDocType
            // 
            this.mitemChangeDocType.Name = "mitemChangeDocType";
            this.mitemChangeDocType.Size = new System.Drawing.Size(245, 22);
            this.mitemChangeDocType.Text = "Изменить тип документа";
            this.mitemChangeDocType.Click += new System.EventHandler(this.mitemChangeDocType_Click);
            // 
            // dsBudgetDoc
            // 
            this.dsBudgetDoc.DataSetName = "dsBudgetDoc";
            this.dsBudgetDoc.Tables.AddRange(new System.Data.DataTable[] {
            this.dtDocWork,
            this.dtDocWorked,
            this.dtDocNotActive,
            this.dtDocError});
            // 
            // dtDocWork
            // 
            this.dtDocWork.Columns.AddRange(new System.Data.DataColumn[] {
            this.A_BUDGETDOC_GUID_ID,
            this.A_CREATEDUSER_NAME,
            this.A_DOCDATE,
            this.A_BUDGETDEP_NAME,
            this.A_DOCOBJECTIVE,
            this.A_DOCMONEY,
            this.A_DEBITARTICLE_NAME,
            this.A_COMPANY_NAME,
            this.A_BUDGETDOCSTATE_NAME,
            this.A_IMAGE_ID,
            this.A_DOCACTIVE,
            this.A_RECIPIENT,
            this.A_IMAGETYPE_ID,
            this.A_BUDGETDOCTYPE_NAME,
            this.A_DATESTATE,
            this.A_ATTACH,
            this.A_CURRENCY,
            this.A_DOCMONEYAGREE,
            this.A_ACCTRNSUM,
            this.A_SALDOTRN,
            this.A_NOTETYPE,
            this.A_NOTETYPE_PREV,
            this.A_USERCOMMENT,
            this.A_PAYMENTTYPE_NAME,
            this.A_BUDGETEXPENSETYPE_NAME});
            this.dtDocWork.TableName = "dtDocWork";
            // 
            // A_BUDGETDOC_GUID_ID
            // 
            this.A_BUDGETDOC_GUID_ID.ColumnName = "A_BUDGETDOC_GUID_ID";
            this.A_BUDGETDOC_GUID_ID.DataType = typeof(System.Guid);
            // 
            // A_CREATEDUSER_NAME
            // 
            this.A_CREATEDUSER_NAME.ColumnName = "A_CREATEDUSER_NAME";
            // 
            // A_DOCDATE
            // 
            this.A_DOCDATE.ColumnName = "A_DOCDATE";
            this.A_DOCDATE.DataType = typeof(System.DateTime);
            // 
            // A_BUDGETDEP_NAME
            // 
            this.A_BUDGETDEP_NAME.ColumnName = "A_BUDGETDEP_NAME";
            // 
            // A_DOCOBJECTIVE
            // 
            this.A_DOCOBJECTIVE.ColumnName = "A_DOCOBJECTIVE";
            // 
            // A_DOCMONEY
            // 
            this.A_DOCMONEY.ColumnName = "A_DOCMONEY";
            this.A_DOCMONEY.DataType = typeof(double);
            // 
            // A_DEBITARTICLE_NAME
            // 
            this.A_DEBITARTICLE_NAME.ColumnName = "A_DEBITARTICLE_NAME";
            // 
            // A_COMPANY_NAME
            // 
            this.A_COMPANY_NAME.ColumnName = "A_COMPANY_NAME";
            // 
            // A_BUDGETDOCSTATE_NAME
            // 
            this.A_BUDGETDOCSTATE_NAME.ColumnName = "A_BUDGETDOCSTATE_NAME";
            // 
            // A_IMAGE_ID
            // 
            this.A_IMAGE_ID.ColumnName = "A_IMAGE_ID";
            this.A_IMAGE_ID.DataType = typeof(int);
            // 
            // A_DOCACTIVE
            // 
            this.A_DOCACTIVE.ColumnName = "A_DOCACTIVE";
            this.A_DOCACTIVE.DataType = typeof(bool);
            // 
            // A_RECIPIENT
            // 
            this.A_RECIPIENT.ColumnName = "A_RECIPIENT";
            // 
            // A_IMAGETYPE_ID
            // 
            this.A_IMAGETYPE_ID.ColumnName = "A_IMAGETYPE_ID";
            this.A_IMAGETYPE_ID.DataType = typeof(int);
            // 
            // A_BUDGETDOCTYPE_NAME
            // 
            this.A_BUDGETDOCTYPE_NAME.ColumnName = "A_BUDGETDOCTYPE_NAME";
            // 
            // A_DATESTATE
            // 
            this.A_DATESTATE.Caption = "A_DATESTATE";
            this.A_DATESTATE.ColumnName = "A_DATESTATE";
            this.A_DATESTATE.DataType = typeof(System.DateTime);
            this.A_DATESTATE.DateTimeMode = System.Data.DataSetDateTime.Utc;
            // 
            // A_ATTACH
            // 
            this.A_ATTACH.ColumnName = "A_ATTACH";
            this.A_ATTACH.DataType = typeof(bool);
            // 
            // A_CURRENCY
            // 
            this.A_CURRENCY.Caption = "A_CURRENCY";
            this.A_CURRENCY.ColumnName = "A_CURRENCY";
            // 
            // A_DOCMONEYAGREE
            // 
            this.A_DOCMONEYAGREE.ColumnName = "A_DOCMONEYAGREE";
            this.A_DOCMONEYAGREE.DataType = typeof(double);
            // 
            // A_ACCTRNSUM
            // 
            this.A_ACCTRNSUM.ColumnName = "A_ACCTRNSUM";
            this.A_ACCTRNSUM.DataType = typeof(double);
            // 
            // A_SALDOTRN
            // 
            this.A_SALDOTRN.ColumnName = "A_SALDOTRN";
            this.A_SALDOTRN.DataType = typeof(double);
            this.A_SALDOTRN.Expression = "A_DOCMONEYAGREE + A_ACCTRNSUM";
            this.A_SALDOTRN.ReadOnly = true;
            // 
            // A_NOTETYPE
            // 
            this.A_NOTETYPE.ColumnName = "A_NOTETYPE";
            this.A_NOTETYPE.DataType = typeof(System.Guid);
            // 
            // A_NOTETYPE_PREV
            // 
            this.A_NOTETYPE_PREV.ColumnName = "A_NOTETYPE_PREV";
            this.A_NOTETYPE_PREV.DataType = typeof(System.Guid);
            // 
            // A_USERCOMMENT
            // 
            this.A_USERCOMMENT.ColumnName = "A_USERCOMMENT";
            // 
            // A_PAYMENTTYPE_NAME
            // 
            this.A_PAYMENTTYPE_NAME.ColumnName = "A_PAYMENTTYPE_NAME";
            // 
            // A_BUDGETEXPENSETYPE_NAME
            // 
            this.A_BUDGETEXPENSETYPE_NAME.ColumnName = "A_BUDGETEXPENSETYPE_NAME";
            // 
            // dtDocWorked
            // 
            this.dtDocWorked.Columns.AddRange(new System.Data.DataColumn[] {
            this.B_BUDGETDOC_GUID_ID,
            this.B_CREATEDUSER_NAME,
            this.B_DOCDATE,
            this.B_BUDGETDEP_NAME,
            this.B_DOCOBJECTIVE,
            this.B_DOCMONEY,
            this.B_DEBITARTICLE_NAME,
            this.B_COMPANY_NAME,
            this.B_BUDGETDOCSTATE_NAME,
            this.B_IMAGE_ID,
            this.B_DOCACTIVE,
            this.B_RECIPIENT,
            this.B_IMAGETYPE_ID,
            this.B_BUDGETDOCTYPE_NAME,
            this.B_DATESTATE,
            this.B_ATTACH,
            this.B_CURRENCY,
            this.B_DOCMONEYAGREE,
            this.B_ACCTRNSUM,
            this.B_SALDOTRN,
            this.B_NOTETYPE,
            this.B_NOTETYPE_PREV,
            this.B_USERCOMMENT,
            this.B_PAYMENTTYPE_NAME,
            this.B_BUDGETEXPENSETYPE_NAME});
            this.dtDocWorked.TableName = "dtDocWorked";
            // 
            // B_BUDGETDOC_GUID_ID
            // 
            this.B_BUDGETDOC_GUID_ID.ColumnName = "B_BUDGETDOC_GUID_ID";
            this.B_BUDGETDOC_GUID_ID.DataType = typeof(System.Guid);
            // 
            // B_CREATEDUSER_NAME
            // 
            this.B_CREATEDUSER_NAME.ColumnName = "B_CREATEDUSER_NAME";
            // 
            // B_DOCDATE
            // 
            this.B_DOCDATE.ColumnName = "B_DOCDATE";
            this.B_DOCDATE.DataType = typeof(System.DateTime);
            // 
            // B_BUDGETDEP_NAME
            // 
            this.B_BUDGETDEP_NAME.ColumnName = "B_BUDGETDEP_NAME";
            // 
            // B_DOCOBJECTIVE
            // 
            this.B_DOCOBJECTIVE.ColumnName = "B_DOCOBJECTIVE";
            // 
            // B_DOCMONEY
            // 
            this.B_DOCMONEY.ColumnName = "B_DOCMONEY";
            this.B_DOCMONEY.DataType = typeof(double);
            // 
            // B_DEBITARTICLE_NAME
            // 
            this.B_DEBITARTICLE_NAME.ColumnName = "B_DEBITARTICLE_NAME";
            // 
            // B_COMPANY_NAME
            // 
            this.B_COMPANY_NAME.ColumnName = "B_COMPANY_NAME";
            // 
            // B_BUDGETDOCSTATE_NAME
            // 
            this.B_BUDGETDOCSTATE_NAME.ColumnName = "B_BUDGETDOCSTATE_NAME";
            // 
            // B_IMAGE_ID
            // 
            this.B_IMAGE_ID.ColumnName = "B_IMAGE_ID";
            this.B_IMAGE_ID.DataType = typeof(int);
            // 
            // B_DOCACTIVE
            // 
            this.B_DOCACTIVE.ColumnName = "B_DOCACTIVE";
            this.B_DOCACTIVE.DataType = typeof(bool);
            // 
            // B_RECIPIENT
            // 
            this.B_RECIPIENT.ColumnName = "B_RECIPIENT";
            // 
            // B_IMAGETYPE_ID
            // 
            this.B_IMAGETYPE_ID.ColumnName = "B_IMAGETYPE_ID";
            this.B_IMAGETYPE_ID.DataType = typeof(int);
            // 
            // B_BUDGETDOCTYPE_NAME
            // 
            this.B_BUDGETDOCTYPE_NAME.ColumnName = "B_BUDGETDOCTYPE_NAME";
            // 
            // B_DATESTATE
            // 
            this.B_DATESTATE.ColumnName = "B_DATESTATE";
            this.B_DATESTATE.DataType = typeof(System.DateTime);
            this.B_DATESTATE.DateTimeMode = System.Data.DataSetDateTime.Utc;
            // 
            // B_ATTACH
            // 
            this.B_ATTACH.ColumnName = "B_ATTACH";
            this.B_ATTACH.DataType = typeof(bool);
            // 
            // B_CURRENCY
            // 
            this.B_CURRENCY.ColumnName = "B_CURRENCY";
            // 
            // B_DOCMONEYAGREE
            // 
            this.B_DOCMONEYAGREE.ColumnName = "B_DOCMONEYAGREE";
            this.B_DOCMONEYAGREE.DataType = typeof(double);
            // 
            // B_ACCTRNSUM
            // 
            this.B_ACCTRNSUM.ColumnName = "B_ACCTRNSUM";
            this.B_ACCTRNSUM.DataType = typeof(double);
            // 
            // B_SALDOTRN
            // 
            this.B_SALDOTRN.ColumnName = "B_SALDOTRN";
            this.B_SALDOTRN.DataType = typeof(double);
            this.B_SALDOTRN.Expression = "B_DOCMONEYAGREE + B_ACCTRNSUM";
            this.B_SALDOTRN.ReadOnly = true;
            // 
            // B_NOTETYPE
            // 
            this.B_NOTETYPE.ColumnName = "B_NOTETYPE";
            this.B_NOTETYPE.DataType = typeof(System.Guid);
            // 
            // B_NOTETYPE_PREV
            // 
            this.B_NOTETYPE_PREV.ColumnName = "B_NOTETYPE_PREV";
            this.B_NOTETYPE_PREV.DataType = typeof(System.Guid);
            // 
            // B_USERCOMMENT
            // 
            this.B_USERCOMMENT.ColumnName = "B_USERCOMMENT";
            // 
            // B_PAYMENTTYPE_NAME
            // 
            this.B_PAYMENTTYPE_NAME.ColumnName = "B_PAYMENTTYPE_NAME";
            // 
            // B_BUDGETEXPENSETYPE_NAME
            // 
            this.B_BUDGETEXPENSETYPE_NAME.ColumnName = "B_BUDGETEXPENSETYPE_NAME";
            // 
            // dtDocNotActive
            // 
            this.dtDocNotActive.Columns.AddRange(new System.Data.DataColumn[] {
            this.C_BUDGETDOC_GUID_ID,
            this.C_CREATEDUSER_NAME,
            this.C_DOCDATE,
            this.C_BUDGETDEP_NAME,
            this.C_DOCOBJECTIVE,
            this.C_DOCMONEY,
            this.C_DEBITARTICLE_NAME,
            this.C_COMPANY_NAME,
            this.C_BUDGETDOCSTATE_NAME,
            this.C_IMAGE_ID,
            this.C_DOCACTIVE,
            this.C_RECIPIENT,
            this.C_IMAGETYPE_ID,
            this.C_BUDGETDOCTYPE_NAME,
            this.C_DATESTATE,
            this.C_ATTACH,
            this.C_CURRENCY,
            this.C_DOCMONEYAGREE,
            this.C_ACCTRNSUM,
            this.C_SALDOTRN,
            this.C_NOTETYPE,
            this.C_NOTETYPE_PREV,
            this.C_USERCOMMENT,
            this.C_PAYMENTTYPE_NAME,
            this.C_BUDGETEXPENSETYPE_NAME});
            this.dtDocNotActive.TableName = "dtDocNotActive";
            // 
            // C_BUDGETDOC_GUID_ID
            // 
            this.C_BUDGETDOC_GUID_ID.ColumnName = "C_BUDGETDOC_GUID_ID";
            this.C_BUDGETDOC_GUID_ID.DataType = typeof(System.Guid);
            // 
            // C_CREATEDUSER_NAME
            // 
            this.C_CREATEDUSER_NAME.ColumnName = "C_CREATEDUSER_NAME";
            // 
            // C_DOCDATE
            // 
            this.C_DOCDATE.ColumnName = "C_DOCDATE";
            this.C_DOCDATE.DataType = typeof(System.DateTime);
            // 
            // C_BUDGETDEP_NAME
            // 
            this.C_BUDGETDEP_NAME.ColumnName = "C_BUDGETDEP_NAME";
            // 
            // C_DOCOBJECTIVE
            // 
            this.C_DOCOBJECTIVE.ColumnName = "C_DOCOBJECTIVE";
            // 
            // C_DOCMONEY
            // 
            this.C_DOCMONEY.ColumnName = "C_DOCMONEY";
            this.C_DOCMONEY.DataType = typeof(double);
            // 
            // C_DEBITARTICLE_NAME
            // 
            this.C_DEBITARTICLE_NAME.ColumnName = "C_DEBITARTICLE_NAME";
            // 
            // C_COMPANY_NAME
            // 
            this.C_COMPANY_NAME.ColumnName = "C_COMPANY_NAME";
            // 
            // C_BUDGETDOCSTATE_NAME
            // 
            this.C_BUDGETDOCSTATE_NAME.ColumnName = "C_BUDGETDOCSTATE_NAME";
            // 
            // C_IMAGE_ID
            // 
            this.C_IMAGE_ID.ColumnName = "C_IMAGE_ID";
            this.C_IMAGE_ID.DataType = typeof(int);
            // 
            // C_DOCACTIVE
            // 
            this.C_DOCACTIVE.ColumnName = "C_DOCACTIVE";
            this.C_DOCACTIVE.DataType = typeof(bool);
            // 
            // C_RECIPIENT
            // 
            this.C_RECIPIENT.ColumnName = "C_RECIPIENT";
            // 
            // C_IMAGETYPE_ID
            // 
            this.C_IMAGETYPE_ID.ColumnName = "C_IMAGETYPE_ID";
            this.C_IMAGETYPE_ID.DataType = typeof(int);
            // 
            // C_BUDGETDOCTYPE_NAME
            // 
            this.C_BUDGETDOCTYPE_NAME.ColumnName = "C_BUDGETDOCTYPE_NAME";
            // 
            // C_DATESTATE
            // 
            this.C_DATESTATE.ColumnName = "C_DATESTATE";
            this.C_DATESTATE.DataType = typeof(System.DateTime);
            this.C_DATESTATE.DateTimeMode = System.Data.DataSetDateTime.Utc;
            // 
            // C_ATTACH
            // 
            this.C_ATTACH.ColumnName = "C_ATTACH";
            this.C_ATTACH.DataType = typeof(bool);
            // 
            // C_CURRENCY
            // 
            this.C_CURRENCY.ColumnName = "C_CURRENCY";
            // 
            // C_DOCMONEYAGREE
            // 
            this.C_DOCMONEYAGREE.ColumnName = "C_DOCMONEYAGREE";
            this.C_DOCMONEYAGREE.DataType = typeof(double);
            // 
            // C_ACCTRNSUM
            // 
            this.C_ACCTRNSUM.ColumnName = "C_ACCTRNSUM";
            this.C_ACCTRNSUM.DataType = typeof(double);
            // 
            // C_SALDOTRN
            // 
            this.C_SALDOTRN.ColumnName = "C_SALDOTRN";
            this.C_SALDOTRN.DataType = typeof(double);
            this.C_SALDOTRN.Expression = "IIF( ( C_ACCTRNSUM > 0), -1, 1 ) * C_ACCTRNSUM + C_DOCMONEYAGREE";
            this.C_SALDOTRN.ReadOnly = true;
            // 
            // C_NOTETYPE
            // 
            this.C_NOTETYPE.ColumnName = "C_NOTETYPE";
            this.C_NOTETYPE.DataType = typeof(System.Guid);
            // 
            // C_NOTETYPE_PREV
            // 
            this.C_NOTETYPE_PREV.ColumnName = "C_NOTETYPE_PREV";
            this.C_NOTETYPE_PREV.DataType = typeof(System.Guid);
            // 
            // C_USERCOMMENT
            // 
            this.C_USERCOMMENT.ColumnName = "C_USERCOMMENT";
            // 
            // C_PAYMENTTYPE_NAME
            // 
            this.C_PAYMENTTYPE_NAME.ColumnName = "C_PAYMENTTYPE_NAME";
            // 
            // C_BUDGETEXPENSETYPE_NAME
            // 
            this.C_BUDGETEXPENSETYPE_NAME.ColumnName = "C_BUDGETEXPENSETYPE_NAME";
            // 
            // dtDocError
            // 
            this.dtDocError.Columns.AddRange(new System.Data.DataColumn[] {
            this.E_BUDGETDOC_GUID_ID,
            this.E_CREATEDUSER_NAME,
            this.E_DOCDATE,
            this.E_BUDGETDEP_NAME,
            this.E_DOCOBJECTIVE,
            this.E_DOCMONEY,
            this.E_DEBITARTICLE_NAME,
            this.E_COMPANY_NAME,
            this.E_BUDGETDOCSTATE_NAME,
            this.E_IMAGE_ID,
            this.E_DOCACTIVE,
            this.E_RECIPIENT,
            this.E_IMAGETYPE_ID,
            this.E_BUDGETDOCTYPE_NAME,
            this.E_DATESTATE,
            this.E_ATTACH,
            this.E_CURRENCY,
            this.E_DOCMONEYAGREE,
            this.E_ACCTRNSUM,
            this.E_SALDOTRN,
            this.E_NOTETYPE,
            this.E_NOTETYPE_PREV,
            this.E_USERCOMMENT,
            this.E_PAYMENTTYPE_NAME,
            this.E_BUDGETEXPENSETYPE_NAME});
            this.dtDocError.TableName = "dtDocError";
            // 
            // E_BUDGETDOC_GUID_ID
            // 
            this.E_BUDGETDOC_GUID_ID.ColumnName = "E_BUDGETDOC_GUID_ID";
            this.E_BUDGETDOC_GUID_ID.DataType = typeof(System.Guid);
            // 
            // E_CREATEDUSER_NAME
            // 
            this.E_CREATEDUSER_NAME.ColumnName = "E_CREATEDUSER_NAME";
            // 
            // E_DOCDATE
            // 
            this.E_DOCDATE.ColumnName = "E_DOCDATE";
            this.E_DOCDATE.DataType = typeof(System.DateTime);
            // 
            // E_BUDGETDEP_NAME
            // 
            this.E_BUDGETDEP_NAME.ColumnName = "E_BUDGETDEP_NAME";
            // 
            // E_DOCOBJECTIVE
            // 
            this.E_DOCOBJECTIVE.ColumnName = "E_DOCOBJECTIVE";
            // 
            // E_DOCMONEY
            // 
            this.E_DOCMONEY.ColumnName = "E_DOCMONEY";
            this.E_DOCMONEY.DataType = typeof(double);
            // 
            // E_DEBITARTICLE_NAME
            // 
            this.E_DEBITARTICLE_NAME.ColumnName = "E_DEBITARTICLE_NAME";
            // 
            // E_COMPANY_NAME
            // 
            this.E_COMPANY_NAME.ColumnName = "E_COMPANY_NAME";
            // 
            // E_BUDGETDOCSTATE_NAME
            // 
            this.E_BUDGETDOCSTATE_NAME.ColumnName = "E_BUDGETDOCSTATE_NAME";
            // 
            // E_IMAGE_ID
            // 
            this.E_IMAGE_ID.ColumnName = "E_IMAGE_ID";
            this.E_IMAGE_ID.DataType = typeof(int);
            // 
            // E_DOCACTIVE
            // 
            this.E_DOCACTIVE.ColumnName = "E_DOCACTIVE";
            this.E_DOCACTIVE.DataType = typeof(bool);
            // 
            // E_RECIPIENT
            // 
            this.E_RECIPIENT.ColumnName = "E_RECIPIENT";
            // 
            // E_IMAGETYPE_ID
            // 
            this.E_IMAGETYPE_ID.ColumnName = "E_IMAGETYPE_ID";
            this.E_IMAGETYPE_ID.DataType = typeof(int);
            // 
            // E_BUDGETDOCTYPE_NAME
            // 
            this.E_BUDGETDOCTYPE_NAME.ColumnName = "E_BUDGETDOCTYPE_NAME";
            // 
            // E_DATESTATE
            // 
            this.E_DATESTATE.ColumnName = "E_DATESTATE";
            this.E_DATESTATE.DataType = typeof(System.DateTime);
            // 
            // E_ATTACH
            // 
            this.E_ATTACH.ColumnName = "E_ATTACH";
            this.E_ATTACH.DataType = typeof(bool);
            // 
            // E_CURRENCY
            // 
            this.E_CURRENCY.ColumnName = "E_CURRENCY";
            // 
            // E_DOCMONEYAGREE
            // 
            this.E_DOCMONEYAGREE.ColumnName = "E_DOCMONEYAGREE";
            this.E_DOCMONEYAGREE.DataType = typeof(double);
            // 
            // E_ACCTRNSUM
            // 
            this.E_ACCTRNSUM.ColumnName = "E_ACCTRNSUM";
            this.E_ACCTRNSUM.DataType = typeof(double);
            // 
            // E_SALDOTRN
            // 
            this.E_SALDOTRN.ColumnName = "E_SALDOTRN";
            this.E_SALDOTRN.DataType = typeof(double);
            this.E_SALDOTRN.Expression = "E_DOCMONEYAGREE+E_ACCTRNSUM";
            this.E_SALDOTRN.ReadOnly = true;
            // 
            // E_NOTETYPE
            // 
            this.E_NOTETYPE.ColumnName = "E_NOTETYPE";
            this.E_NOTETYPE.DataType = typeof(System.Guid);
            // 
            // E_NOTETYPE_PREV
            // 
            this.E_NOTETYPE_PREV.ColumnName = "E_NOTETYPE_PREV";
            this.E_NOTETYPE_PREV.DataType = typeof(System.Guid);
            // 
            // E_USERCOMMENT
            // 
            this.E_USERCOMMENT.ColumnName = "E_USERCOMMENT";
            // 
            // E_PAYMENTTYPE_NAME
            // 
            this.E_PAYMENTTYPE_NAME.ColumnName = "E_PAYMENTTYPE_NAME";
            // 
            // E_BUDGETEXPENSETYPE_NAME
            // 
            this.E_BUDGETEXPENSETYPE_NAME.ColumnName = "E_BUDGETEXPENSETYPE_NAME";
            // 
            // gridViewDocWork
            // 
            this.gridViewDocWork.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colA_IMAGE_ID,
            this.colA_IMAGETYPE_ID,
            this.colA_ATTACH,
            this.colA_BUDGETDOC_GUID_ID,
            this.colA_CREATEDUSER_NAME,
            this.colA_DOCDATE,
            this.colA_BUDGETDEP_NAME,
            this.colA_DOCOBJECTIVE,
            this.colA_DOCMONEY,
            this.colA_DEBITARTICLE_NAME,
            this.colA_COMPANY_NAME,
            this.colA_BUDGETDOCSTATE_NAME,
            this.colA_DATESTATE,
            this.colA_BUDGETDOCTYPE_NAME,
            this.colA_RECIPIENT,
            this.colA_CURRENCY,
            this.colA_DOCMONEYAGREE,
            this.colA_ACCTRNSUM,
            this.colA_SALDOTRN,
            this.colA_NOTETYPE,
            this.colA_NOTETYPE_ID,
            this.colA_NOTETYPE_PREVID,
            this.colA_COMMENT,
            this.colA_COMMENTTEXT,
            this.colA_PAYMENTTYPE_NAME,
            this.colA_BUDGETEXPENSETYPE_NAME});
            this.gridViewDocWork.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDocWork.GridControl = this.gridDocWork;
            this.gridViewDocWork.Images = this.imageCollection;
            this.gridViewDocWork.Name = "gridViewDocWork";
            this.gridViewDocWork.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            this.gridViewDocWork.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewDocWork_RowCellStyle);
            this.gridViewDocWork.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridViewDocWork_MouseDown);
            // 
            // colA_IMAGE_ID
            // 
            this.colA_IMAGE_ID.FieldName = "A_IMAGE_ID";
            this.colA_IMAGE_ID.MinWidth = 16;
            this.colA_IMAGE_ID.Name = "colA_IMAGE_ID";
            this.colA_IMAGE_ID.OptionsColumn.AllowEdit = false;
            this.colA_IMAGE_ID.OptionsColumn.AllowFocus = false;
            this.colA_IMAGE_ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colA_IMAGE_ID.OptionsColumn.ReadOnly = true;
            this.colA_IMAGE_ID.OptionsFilter.AllowAutoFilter = false;
            this.colA_IMAGE_ID.OptionsFilter.AllowFilter = false;
            this.colA_IMAGE_ID.Width = 16;
            // 
            // colA_IMAGETYPE_ID
            // 
            this.colA_IMAGETYPE_ID.AppearanceCell.Options.UseTextOptions = true;
            this.colA_IMAGETYPE_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colA_IMAGETYPE_ID.FieldName = "A_IMAGETYPE_ID";
            this.colA_IMAGETYPE_ID.MinWidth = 16;
            this.colA_IMAGETYPE_ID.Name = "colA_IMAGETYPE_ID";
            this.colA_IMAGETYPE_ID.OptionsColumn.AllowEdit = false;
            this.colA_IMAGETYPE_ID.OptionsColumn.AllowFocus = false;
            this.colA_IMAGETYPE_ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colA_IMAGETYPE_ID.OptionsColumn.ReadOnly = true;
            this.colA_IMAGETYPE_ID.OptionsFilter.AllowAutoFilter = false;
            this.colA_IMAGETYPE_ID.OptionsFilter.AllowFilter = false;
            this.colA_IMAGETYPE_ID.Visible = true;
            this.colA_IMAGETYPE_ID.VisibleIndex = 0;
            this.colA_IMAGETYPE_ID.Width = 16;
            // 
            // colA_ATTACH
            // 
            this.colA_ATTACH.ImageIndex = 1;
            this.colA_ATTACH.Name = "colA_ATTACH";
            this.colA_ATTACH.OptionsColumn.AllowEdit = false;
            this.colA_ATTACH.OptionsColumn.AllowFocus = false;
            this.colA_ATTACH.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colA_ATTACH.OptionsColumn.ReadOnly = true;
            this.colA_ATTACH.OptionsFilter.AllowAutoFilter = false;
            this.colA_ATTACH.OptionsFilter.AllowFilter = false;
            this.colA_ATTACH.Visible = true;
            this.colA_ATTACH.VisibleIndex = 1;
            this.colA_ATTACH.Width = 20;
            // 
            // colA_BUDGETDOC_GUID_ID
            // 
            this.colA_BUDGETDOC_GUID_ID.Caption = "A_BUDGETDOC_GUID_ID";
            this.colA_BUDGETDOC_GUID_ID.FieldName = "A_BUDGETDOC_GUID_ID";
            this.colA_BUDGETDOC_GUID_ID.Name = "colA_BUDGETDOC_GUID_ID";
            this.colA_BUDGETDOC_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colA_BUDGETDOC_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colA_BUDGETDOC_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colA_BUDGETDOC_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colA_CREATEDUSER_NAME
            // 
            this.colA_CREATEDUSER_NAME.Caption = "Инициатор";
            this.colA_CREATEDUSER_NAME.FieldName = "A_CREATEDUSER_NAME";
            this.colA_CREATEDUSER_NAME.Name = "colA_CREATEDUSER_NAME";
            this.colA_CREATEDUSER_NAME.OptionsColumn.AllowEdit = false;
            this.colA_CREATEDUSER_NAME.OptionsColumn.AllowFocus = false;
            this.colA_CREATEDUSER_NAME.OptionsColumn.ReadOnly = true;
            this.colA_CREATEDUSER_NAME.Visible = true;
            this.colA_CREATEDUSER_NAME.VisibleIndex = 2;
            this.colA_CREATEDUSER_NAME.Width = 42;
            // 
            // colA_DOCDATE
            // 
            this.colA_DOCDATE.Caption = "Дата заявки";
            this.colA_DOCDATE.DisplayFormat.FormatString = "g";
            this.colA_DOCDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colA_DOCDATE.FieldName = "A_DOCDATE";
            this.colA_DOCDATE.Name = "colA_DOCDATE";
            this.colA_DOCDATE.OptionsColumn.AllowEdit = false;
            this.colA_DOCDATE.OptionsColumn.AllowFocus = false;
            this.colA_DOCDATE.OptionsColumn.ReadOnly = true;
            this.colA_DOCDATE.Visible = true;
            this.colA_DOCDATE.VisibleIndex = 3;
            this.colA_DOCDATE.Width = 49;
            // 
            // colA_BUDGETDEP_NAME
            // 
            this.colA_BUDGETDEP_NAME.Caption = "Служба";
            this.colA_BUDGETDEP_NAME.FieldName = "A_BUDGETDEP_NAME";
            this.colA_BUDGETDEP_NAME.Name = "colA_BUDGETDEP_NAME";
            this.colA_BUDGETDEP_NAME.OptionsColumn.AllowEdit = false;
            this.colA_BUDGETDEP_NAME.OptionsColumn.AllowFocus = false;
            this.colA_BUDGETDEP_NAME.OptionsColumn.ReadOnly = true;
            this.colA_BUDGETDEP_NAME.Visible = true;
            this.colA_BUDGETDEP_NAME.VisibleIndex = 4;
            this.colA_BUDGETDEP_NAME.Width = 44;
            // 
            // colA_DOCOBJECTIVE
            // 
            this.colA_DOCOBJECTIVE.Caption = "Описание цели";
            this.colA_DOCOBJECTIVE.FieldName = "A_DOCOBJECTIVE";
            this.colA_DOCOBJECTIVE.Name = "colA_DOCOBJECTIVE";
            this.colA_DOCOBJECTIVE.OptionsColumn.AllowEdit = false;
            this.colA_DOCOBJECTIVE.OptionsColumn.AllowFocus = false;
            this.colA_DOCOBJECTIVE.OptionsColumn.ReadOnly = true;
            this.colA_DOCOBJECTIVE.Visible = true;
            this.colA_DOCOBJECTIVE.VisibleIndex = 5;
            this.colA_DOCOBJECTIVE.Width = 44;
            // 
            // colA_DOCMONEY
            // 
            this.colA_DOCMONEY.Caption = "Сумма";
            this.colA_DOCMONEY.DisplayFormat.FormatString = "### ### ###.##";
            this.colA_DOCMONEY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colA_DOCMONEY.FieldName = "A_DOCMONEY";
            this.colA_DOCMONEY.Name = "colA_DOCMONEY";
            this.colA_DOCMONEY.OptionsColumn.AllowEdit = false;
            this.colA_DOCMONEY.OptionsColumn.AllowFocus = false;
            this.colA_DOCMONEY.OptionsColumn.ReadOnly = true;
            this.colA_DOCMONEY.Visible = true;
            this.colA_DOCMONEY.VisibleIndex = 6;
            this.colA_DOCMONEY.Width = 44;
            // 
            // colA_DEBITARTICLE_NAME
            // 
            this.colA_DEBITARTICLE_NAME.Caption = "Статья расходов";
            this.colA_DEBITARTICLE_NAME.FieldName = "A_DEBITARTICLE_NAME";
            this.colA_DEBITARTICLE_NAME.Name = "colA_DEBITARTICLE_NAME";
            this.colA_DEBITARTICLE_NAME.OptionsColumn.AllowEdit = false;
            this.colA_DEBITARTICLE_NAME.OptionsColumn.AllowFocus = false;
            this.colA_DEBITARTICLE_NAME.OptionsColumn.ReadOnly = true;
            this.colA_DEBITARTICLE_NAME.Visible = true;
            this.colA_DEBITARTICLE_NAME.VisibleIndex = 7;
            this.colA_DEBITARTICLE_NAME.Width = 44;
            // 
            // colA_COMPANY_NAME
            // 
            this.colA_COMPANY_NAME.Caption = "Фирма";
            this.colA_COMPANY_NAME.FieldName = "A_COMPANY_NAME";
            this.colA_COMPANY_NAME.Name = "colA_COMPANY_NAME";
            this.colA_COMPANY_NAME.OptionsColumn.AllowEdit = false;
            this.colA_COMPANY_NAME.OptionsColumn.AllowFocus = false;
            this.colA_COMPANY_NAME.OptionsColumn.ReadOnly = true;
            this.colA_COMPANY_NAME.Visible = true;
            this.colA_COMPANY_NAME.VisibleIndex = 8;
            this.colA_COMPANY_NAME.Width = 44;
            // 
            // colA_BUDGETDOCSTATE_NAME
            // 
            this.colA_BUDGETDOCSTATE_NAME.Caption = "Состояние";
            this.colA_BUDGETDOCSTATE_NAME.FieldName = "A_BUDGETDOCSTATE_NAME";
            this.colA_BUDGETDOCSTATE_NAME.Name = "colA_BUDGETDOCSTATE_NAME";
            this.colA_BUDGETDOCSTATE_NAME.OptionsColumn.AllowEdit = false;
            this.colA_BUDGETDOCSTATE_NAME.OptionsColumn.AllowFocus = false;
            this.colA_BUDGETDOCSTATE_NAME.OptionsColumn.ReadOnly = true;
            this.colA_BUDGETDOCSTATE_NAME.Visible = true;
            this.colA_BUDGETDOCSTATE_NAME.VisibleIndex = 9;
            this.colA_BUDGETDOCSTATE_NAME.Width = 66;
            // 
            // colA_DATESTATE
            // 
            this.colA_DATESTATE.Caption = "Дата";
            this.colA_DATESTATE.DisplayFormat.FormatString = "g";
            this.colA_DATESTATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colA_DATESTATE.FieldName = "A_DATESTATE";
            this.colA_DATESTATE.Name = "colA_DATESTATE";
            this.colA_DATESTATE.OptionsColumn.AllowEdit = false;
            this.colA_DATESTATE.OptionsColumn.AllowFocus = false;
            this.colA_DATESTATE.OptionsColumn.ReadOnly = true;
            this.colA_DATESTATE.Visible = true;
            this.colA_DATESTATE.VisibleIndex = 10;
            this.colA_DATESTATE.Width = 67;
            // 
            // colA_BUDGETDOCTYPE_NAME
            // 
            this.colA_BUDGETDOCTYPE_NAME.Caption = "Тип документа";
            this.colA_BUDGETDOCTYPE_NAME.FieldName = "A_BUDGETDOCTYPE_NAME";
            this.colA_BUDGETDOCTYPE_NAME.Name = "colA_BUDGETDOCTYPE_NAME";
            // 
            // colA_RECIPIENT
            // 
            this.colA_RECIPIENT.Caption = "Получатель средств";
            this.colA_RECIPIENT.FieldName = "A_RECIPIENT";
            this.colA_RECIPIENT.Name = "colA_RECIPIENT";
            // 
            // colA_CURRENCY
            // 
            this.colA_CURRENCY.Caption = "Валюта";
            this.colA_CURRENCY.FieldName = "A_CURRENCY";
            this.colA_CURRENCY.Name = "colA_CURRENCY";
            // 
            // colA_DOCMONEYAGREE
            // 
            this.colA_DOCMONEYAGREE.Caption = "Сумма, EUR";
            this.colA_DOCMONEYAGREE.DisplayFormat.FormatString = "Numeric \"### ### ###.##\"";
            this.colA_DOCMONEYAGREE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colA_DOCMONEYAGREE.FieldName = "A_DOCMONEYAGREE";
            this.colA_DOCMONEYAGREE.Name = "colA_DOCMONEYAGREE";
            this.colA_DOCMONEYAGREE.OptionsColumn.AllowEdit = false;
            this.colA_DOCMONEYAGREE.OptionsColumn.AllowFocus = false;
            this.colA_DOCMONEYAGREE.OptionsColumn.ReadOnly = true;
            this.colA_DOCMONEYAGREE.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colA_ACCTRNSUM
            // 
            this.colA_ACCTRNSUM.Caption = "Сумма проводок, EUR";
            this.colA_ACCTRNSUM.DisplayFormat.FormatString = "Numeric \"### ### ###.##\"";
            this.colA_ACCTRNSUM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colA_ACCTRNSUM.FieldName = "A_ACCTRNSUM";
            this.colA_ACCTRNSUM.Name = "colA_ACCTRNSUM";
            this.colA_ACCTRNSUM.OptionsColumn.AllowEdit = false;
            this.colA_ACCTRNSUM.OptionsColumn.AllowFocus = false;
            this.colA_ACCTRNSUM.OptionsColumn.ReadOnly = true;
            this.colA_ACCTRNSUM.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colA_SALDOTRN
            // 
            this.colA_SALDOTRN.Caption = "Сальдо, EUR";
            this.colA_SALDOTRN.DisplayFormat.FormatString = "Numeric \"### ### ###.##\"";
            this.colA_SALDOTRN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colA_SALDOTRN.FieldName = "A_SALDOTRN";
            this.colA_SALDOTRN.Name = "colA_SALDOTRN";
            this.colA_SALDOTRN.OptionsColumn.AllowEdit = false;
            this.colA_SALDOTRN.OptionsColumn.AllowFocus = false;
            this.colA_SALDOTRN.OptionsColumn.ReadOnly = true;
            this.colA_SALDOTRN.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colA_NOTETYPE
            // 
            this.colA_NOTETYPE.CustomizationCaption = "Пометка";
            this.colA_NOTETYPE.ImageIndex = 2;
            this.colA_NOTETYPE.MinWidth = 29;
            this.colA_NOTETYPE.Name = "colA_NOTETYPE";
            this.colA_NOTETYPE.OptionsColumn.AllowEdit = false;
            this.colA_NOTETYPE.OptionsColumn.AllowFocus = false;
            this.colA_NOTETYPE.OptionsColumn.AllowSize = false;
            this.colA_NOTETYPE.OptionsColumn.FixedWidth = true;
            this.colA_NOTETYPE.OptionsColumn.ReadOnly = true;
            this.colA_NOTETYPE.Width = 29;
            // 
            // colA_NOTETYPE_ID
            // 
            this.colA_NOTETYPE_ID.FieldName = "A_NOTETYPE";
            this.colA_NOTETYPE_ID.Name = "colA_NOTETYPE_ID";
            this.colA_NOTETYPE_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colA_NOTETYPE_PREVID
            // 
            this.colA_NOTETYPE_PREVID.FieldName = "A_NOTETYPE_PREV";
            this.colA_NOTETYPE_PREVID.Name = "colA_NOTETYPE_PREVID";
            this.colA_NOTETYPE_PREVID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colA_COMMENT
            // 
            this.colA_COMMENT.CustomizationCaption = "Примечание";
            this.colA_COMMENT.FieldName = "A_USERCOMMENT";
            this.colA_COMMENT.ImageIndex = 3;
            this.colA_COMMENT.MinWidth = 29;
            this.colA_COMMENT.Name = "colA_COMMENT";
            this.colA_COMMENT.OptionsColumn.AllowEdit = false;
            this.colA_COMMENT.OptionsColumn.AllowFocus = false;
            this.colA_COMMENT.OptionsColumn.AllowSize = false;
            this.colA_COMMENT.OptionsColumn.FixedWidth = true;
            this.colA_COMMENT.OptionsColumn.ReadOnly = true;
            this.colA_COMMENT.Width = 29;
            // 
            // colA_COMMENTTEXT
            // 
            this.colA_COMMENTTEXT.FieldName = "A_USERCOMMENT";
            this.colA_COMMENTTEXT.Name = "colA_COMMENTTEXT";
            this.colA_COMMENTTEXT.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colA_PAYMENTTYPE_NAME
            // 
            this.colA_PAYMENTTYPE_NAME.Caption = "Форма оплаты";
            this.colA_PAYMENTTYPE_NAME.FieldName = "A_PAYMENTTYPE_NAME";
            this.colA_PAYMENTTYPE_NAME.Name = "colA_PAYMENTTYPE_NAME";
            this.colA_PAYMENTTYPE_NAME.OptionsColumn.AllowEdit = false;
            this.colA_PAYMENTTYPE_NAME.OptionsColumn.AllowFocus = false;
            this.colA_PAYMENTTYPE_NAME.OptionsColumn.ReadOnly = true;
            this.colA_PAYMENTTYPE_NAME.Visible = true;
            this.colA_PAYMENTTYPE_NAME.VisibleIndex = 11;
            this.colA_PAYMENTTYPE_NAME.Width = 40;
            // 
            // colA_BUDGETEXPENSETYPE_NAME
            // 
            this.colA_BUDGETEXPENSETYPE_NAME.Caption = "Тип бюджетных расходов";
            this.colA_BUDGETEXPENSETYPE_NAME.FieldName = "A_BUDGETEXPENSETYPE_NAME";
            this.colA_BUDGETEXPENSETYPE_NAME.Name = "colA_BUDGETEXPENSETYPE_NAME";
            this.colA_BUDGETEXPENSETYPE_NAME.OptionsColumn.AllowEdit = false;
            this.colA_BUDGETEXPENSETYPE_NAME.OptionsColumn.AllowFocus = false;
            this.colA_BUDGETEXPENSETYPE_NAME.OptionsColumn.ReadOnly = true;
            this.colA_BUDGETEXPENSETYPE_NAME.Visible = true;
            this.colA_BUDGETEXPENSETYPE_NAME.VisibleIndex = 12;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            // 
            // tabPageDocWorked
            // 
            this.tabPageDocWorked.Controls.Add(this.gridDocWorked);
            this.tabPageDocWorked.Image = global::ErpBudgetBudgetDoc.Properties.Resources.mail_preferences;
            this.tabPageDocWorked.Name = "tabPageDocWorked";
            this.tabPageDocWorked.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDocWorked.Size = new System.Drawing.Size(573, 326);
            this.tabPageDocWorked.Text = "Обработанные заявки";
            this.tabPageDocWorked.Tooltip = "Список обработанных заявок";
            // 
            // gridDocWorked
            // 
            this.gridDocWorked.ContextMenuStrip = this.contextMenuStrip;
            this.gridDocWorked.DataMember = "dtDocWorked";
            this.gridDocWorked.DataSource = this.dsBudgetDoc;
            this.gridDocWorked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDocWorked.EmbeddedNavigator.Name = "";
            this.gridDocWorked.Location = new System.Drawing.Point(3, 3);
            this.gridDocWorked.MainView = this.gridViewDocWorked;
            this.gridDocWorked.Name = "gridDocWorked";
            this.gridDocWorked.Size = new System.Drawing.Size(567, 320);
            this.gridDocWorked.TabIndex = 0;
            this.gridDocWorked.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDocWorked});
            this.gridDocWorked.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // gridViewDocWorked
            // 
            this.gridViewDocWorked.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colB_IMAGE_ID,
            this.colB_IMAGETYPE_ID,
            this.colB_ATTACH,
            this.colB_BUDGETDOC_GUID_ID,
            this.colB_CREATEDUSER_ID,
            this.colB_CREATEDUSER_NAME,
            this.colB_DOCDATE,
            this.colB_BUDGETDEP_GUID_ID,
            this.colB_BUDGETDEP_NAME,
            this.colB_DOCOBJECTIVE,
            this.colB_DOCMONEY,
            this.colB_BUDGETITEM_GUID_ID,
            this.colB_DEBITARTICLE_NAME,
            this.colB_COMPANY_GUID_ID,
            this.colB_COMPANY_NAME,
            this.colB_BUDGETDOCSTATE_NAME,
            this.colB_BUDGETDOCSTATE_GUID_ID,
            this.colB_DATESTATE,
            this.colB_BUDGETDOCTYPE_NAME,
            this.colB_RECIPIENT,
            this.colB_CURRENCY,
            this.colB_DOCMONEYAGREE,
            this.colB_ACCTRNSUM,
            this.colB_SALDOTRN,
            this.colB_NOTETYPE,
            this.colB_NOTETYPE_ID,
            this.colB_NOTETYPE_PREVID,
            this.colB_COMMENT,
            this.colB_COMMENTTEXT,
            this.colB_PAYMENTTYPE_NAME,
            this.colB_BUDGETEXPENSETYPE_NAME});
            this.gridViewDocWorked.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDocWorked.GridControl = this.gridDocWorked;
            this.gridViewDocWorked.Images = this.imageCollection;
            this.gridViewDocWorked.Name = "gridViewDocWorked";
            this.gridViewDocWorked.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            this.gridViewDocWorked.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridViewDocWorked_MouseDown);
            // 
            // colB_IMAGE_ID
            // 
            this.colB_IMAGE_ID.FieldName = "B_IMAGE_ID";
            this.colB_IMAGE_ID.MinWidth = 16;
            this.colB_IMAGE_ID.Name = "colB_IMAGE_ID";
            this.colB_IMAGE_ID.OptionsColumn.AllowEdit = false;
            this.colB_IMAGE_ID.OptionsColumn.AllowFocus = false;
            this.colB_IMAGE_ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colB_IMAGE_ID.OptionsColumn.ReadOnly = true;
            this.colB_IMAGE_ID.OptionsColumn.ShowInCustomizationForm = false;
            this.colB_IMAGE_ID.OptionsFilter.AllowAutoFilter = false;
            this.colB_IMAGE_ID.OptionsFilter.AllowFilter = false;
            this.colB_IMAGE_ID.Width = 24;
            // 
            // colB_IMAGETYPE_ID
            // 
            this.colB_IMAGETYPE_ID.FieldName = "B_IMAGETYPE_ID";
            this.colB_IMAGETYPE_ID.MinWidth = 16;
            this.colB_IMAGETYPE_ID.Name = "colB_IMAGETYPE_ID";
            this.colB_IMAGETYPE_ID.OptionsColumn.AllowEdit = false;
            this.colB_IMAGETYPE_ID.OptionsColumn.AllowFocus = false;
            this.colB_IMAGETYPE_ID.OptionsColumn.AllowMove = false;
            this.colB_IMAGETYPE_ID.OptionsColumn.ReadOnly = true;
            this.colB_IMAGETYPE_ID.OptionsColumn.ShowInCustomizationForm = false;
            this.colB_IMAGETYPE_ID.OptionsFilter.AllowAutoFilter = false;
            this.colB_IMAGETYPE_ID.OptionsFilter.AllowFilter = false;
            this.colB_IMAGETYPE_ID.Visible = true;
            this.colB_IMAGETYPE_ID.VisibleIndex = 0;
            this.colB_IMAGETYPE_ID.Width = 16;
            // 
            // colB_ATTACH
            // 
            this.colB_ATTACH.ImageIndex = 1;
            this.colB_ATTACH.Name = "colB_ATTACH";
            this.colB_ATTACH.OptionsColumn.AllowEdit = false;
            this.colB_ATTACH.OptionsColumn.AllowFocus = false;
            this.colB_ATTACH.OptionsColumn.AllowMove = false;
            this.colB_ATTACH.OptionsColumn.ReadOnly = true;
            this.colB_ATTACH.OptionsFilter.AllowAutoFilter = false;
            this.colB_ATTACH.OptionsFilter.AllowFilter = false;
            this.colB_ATTACH.Visible = true;
            this.colB_ATTACH.VisibleIndex = 1;
            this.colB_ATTACH.Width = 20;
            // 
            // colB_BUDGETDOC_GUID_ID
            // 
            this.colB_BUDGETDOC_GUID_ID.Caption = "B_BUDGETDOC_GUID_ID";
            this.colB_BUDGETDOC_GUID_ID.FieldName = "B_BUDGETDOC_GUID_ID";
            this.colB_BUDGETDOC_GUID_ID.Name = "colB_BUDGETDOC_GUID_ID";
            this.colB_BUDGETDOC_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colB_BUDGETDOC_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colB_BUDGETDOC_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colB_BUDGETDOC_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_CREATEDUSER_ID
            // 
            this.colB_CREATEDUSER_ID.Caption = "B_CREATEDUSER_ID";
            this.colB_CREATEDUSER_ID.FieldName = "B_CREATEDUSER_ID";
            this.colB_CREATEDUSER_ID.Name = "colB_CREATEDUSER_ID";
            this.colB_CREATEDUSER_ID.OptionsColumn.AllowEdit = false;
            this.colB_CREATEDUSER_ID.OptionsColumn.AllowFocus = false;
            this.colB_CREATEDUSER_ID.OptionsColumn.ReadOnly = true;
            this.colB_CREATEDUSER_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_CREATEDUSER_NAME
            // 
            this.colB_CREATEDUSER_NAME.Caption = "Инициатор";
            this.colB_CREATEDUSER_NAME.FieldName = "B_CREATEDUSER_NAME";
            this.colB_CREATEDUSER_NAME.Name = "colB_CREATEDUSER_NAME";
            this.colB_CREATEDUSER_NAME.OptionsColumn.AllowEdit = false;
            this.colB_CREATEDUSER_NAME.OptionsColumn.AllowFocus = false;
            this.colB_CREATEDUSER_NAME.OptionsColumn.ReadOnly = true;
            this.colB_CREATEDUSER_NAME.Visible = true;
            this.colB_CREATEDUSER_NAME.VisibleIndex = 2;
            this.colB_CREATEDUSER_NAME.Width = 44;
            // 
            // colB_DOCDATE
            // 
            this.colB_DOCDATE.Caption = "Дата заявки";
            this.colB_DOCDATE.FieldName = "B_DOCDATE";
            this.colB_DOCDATE.Name = "colB_DOCDATE";
            this.colB_DOCDATE.OptionsColumn.AllowEdit = false;
            this.colB_DOCDATE.OptionsColumn.AllowFocus = false;
            this.colB_DOCDATE.OptionsColumn.ReadOnly = true;
            this.colB_DOCDATE.Visible = true;
            this.colB_DOCDATE.VisibleIndex = 3;
            this.colB_DOCDATE.Width = 44;
            // 
            // colB_BUDGETDEP_GUID_ID
            // 
            this.colB_BUDGETDEP_GUID_ID.Caption = "B_BUDGETDEP_GUID_ID";
            this.colB_BUDGETDEP_GUID_ID.FieldName = "B_BUDGETDEP_GUID_ID";
            this.colB_BUDGETDEP_GUID_ID.Name = "colB_BUDGETDEP_GUID_ID";
            this.colB_BUDGETDEP_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colB_BUDGETDEP_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colB_BUDGETDEP_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colB_BUDGETDEP_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_BUDGETDEP_NAME
            // 
            this.colB_BUDGETDEP_NAME.Caption = "Служба";
            this.colB_BUDGETDEP_NAME.FieldName = "B_BUDGETDEP_NAME";
            this.colB_BUDGETDEP_NAME.Name = "colB_BUDGETDEP_NAME";
            this.colB_BUDGETDEP_NAME.OptionsColumn.AllowEdit = false;
            this.colB_BUDGETDEP_NAME.OptionsColumn.AllowFocus = false;
            this.colB_BUDGETDEP_NAME.OptionsColumn.ReadOnly = true;
            this.colB_BUDGETDEP_NAME.Visible = true;
            this.colB_BUDGETDEP_NAME.VisibleIndex = 4;
            this.colB_BUDGETDEP_NAME.Width = 44;
            // 
            // colB_DOCOBJECTIVE
            // 
            this.colB_DOCOBJECTIVE.Caption = "Описание цели";
            this.colB_DOCOBJECTIVE.FieldName = "B_DOCOBJECTIVE";
            this.colB_DOCOBJECTIVE.Name = "colB_DOCOBJECTIVE";
            this.colB_DOCOBJECTIVE.OptionsColumn.AllowEdit = false;
            this.colB_DOCOBJECTIVE.OptionsColumn.AllowFocus = false;
            this.colB_DOCOBJECTIVE.OptionsColumn.ReadOnly = true;
            this.colB_DOCOBJECTIVE.Visible = true;
            this.colB_DOCOBJECTIVE.VisibleIndex = 5;
            this.colB_DOCOBJECTIVE.Width = 44;
            // 
            // colB_DOCMONEY
            // 
            this.colB_DOCMONEY.Caption = "Сумма";
            this.colB_DOCMONEY.DisplayFormat.FormatString = "### ### ###.##";
            this.colB_DOCMONEY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colB_DOCMONEY.FieldName = "B_DOCMONEY";
            this.colB_DOCMONEY.Name = "colB_DOCMONEY";
            this.colB_DOCMONEY.OptionsColumn.AllowEdit = false;
            this.colB_DOCMONEY.OptionsColumn.AllowFocus = false;
            this.colB_DOCMONEY.OptionsColumn.ReadOnly = true;
            this.colB_DOCMONEY.Visible = true;
            this.colB_DOCMONEY.VisibleIndex = 6;
            this.colB_DOCMONEY.Width = 44;
            // 
            // colB_BUDGETITEM_GUID_ID
            // 
            this.colB_BUDGETITEM_GUID_ID.Caption = "B_BUDGETITEM_GUID_ID";
            this.colB_BUDGETITEM_GUID_ID.FieldName = "B_BUDGETITEM_GUID_ID";
            this.colB_BUDGETITEM_GUID_ID.Name = "colB_BUDGETITEM_GUID_ID";
            this.colB_BUDGETITEM_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colB_BUDGETITEM_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colB_BUDGETITEM_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colB_BUDGETITEM_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_DEBITARTICLE_NAME
            // 
            this.colB_DEBITARTICLE_NAME.Caption = "Статья расходов";
            this.colB_DEBITARTICLE_NAME.FieldName = "B_DEBITARTICLE_NAME";
            this.colB_DEBITARTICLE_NAME.Name = "colB_DEBITARTICLE_NAME";
            this.colB_DEBITARTICLE_NAME.OptionsColumn.AllowEdit = false;
            this.colB_DEBITARTICLE_NAME.OptionsColumn.AllowFocus = false;
            this.colB_DEBITARTICLE_NAME.OptionsColumn.ReadOnly = true;
            this.colB_DEBITARTICLE_NAME.Visible = true;
            this.colB_DEBITARTICLE_NAME.VisibleIndex = 7;
            this.colB_DEBITARTICLE_NAME.Width = 44;
            // 
            // colB_COMPANY_GUID_ID
            // 
            this.colB_COMPANY_GUID_ID.Caption = "B_COMPANY_GUID_ID";
            this.colB_COMPANY_GUID_ID.FieldName = "B_COMPANY_GUID_ID";
            this.colB_COMPANY_GUID_ID.Name = "colB_COMPANY_GUID_ID";
            this.colB_COMPANY_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colB_COMPANY_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colB_COMPANY_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colB_COMPANY_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_COMPANY_NAME
            // 
            this.colB_COMPANY_NAME.Caption = "Фирма";
            this.colB_COMPANY_NAME.FieldName = "B_COMPANY_NAME";
            this.colB_COMPANY_NAME.Name = "colB_COMPANY_NAME";
            this.colB_COMPANY_NAME.OptionsColumn.AllowEdit = false;
            this.colB_COMPANY_NAME.OptionsColumn.AllowFocus = false;
            this.colB_COMPANY_NAME.OptionsColumn.ReadOnly = true;
            this.colB_COMPANY_NAME.Visible = true;
            this.colB_COMPANY_NAME.VisibleIndex = 8;
            this.colB_COMPANY_NAME.Width = 44;
            // 
            // colB_BUDGETDOCSTATE_NAME
            // 
            this.colB_BUDGETDOCSTATE_NAME.Caption = "Состояние";
            this.colB_BUDGETDOCSTATE_NAME.FieldName = "B_BUDGETDOCSTATE_NAME";
            this.colB_BUDGETDOCSTATE_NAME.Name = "colB_BUDGETDOCSTATE_NAME";
            this.colB_BUDGETDOCSTATE_NAME.OptionsColumn.AllowEdit = false;
            this.colB_BUDGETDOCSTATE_NAME.OptionsColumn.AllowFocus = false;
            this.colB_BUDGETDOCSTATE_NAME.OptionsColumn.ReadOnly = true;
            this.colB_BUDGETDOCSTATE_NAME.Visible = true;
            this.colB_BUDGETDOCSTATE_NAME.VisibleIndex = 9;
            this.colB_BUDGETDOCSTATE_NAME.Width = 59;
            // 
            // colB_BUDGETDOCSTATE_GUID_ID
            // 
            this.colB_BUDGETDOCSTATE_GUID_ID.Caption = "B_BUDGETDOCSTATE_GUID_ID";
            this.colB_BUDGETDOCSTATE_GUID_ID.FieldName = "B_BUDGETDOCSTATE_GUID_ID";
            this.colB_BUDGETDOCSTATE_GUID_ID.Name = "colB_BUDGETDOCSTATE_GUID_ID";
            this.colB_BUDGETDOCSTATE_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colB_BUDGETDOCSTATE_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colB_BUDGETDOCSTATE_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colB_BUDGETDOCSTATE_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_DATESTATE
            // 
            this.colB_DATESTATE.Caption = "Дата";
            this.colB_DATESTATE.DisplayFormat.FormatString = "g";
            this.colB_DATESTATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colB_DATESTATE.FieldName = "B_DATESTATE";
            this.colB_DATESTATE.Name = "colB_DATESTATE";
            this.colB_DATESTATE.OptionsColumn.AllowEdit = false;
            this.colB_DATESTATE.OptionsColumn.AllowFocus = false;
            this.colB_DATESTATE.OptionsColumn.ReadOnly = true;
            this.colB_DATESTATE.Visible = true;
            this.colB_DATESTATE.VisibleIndex = 10;
            this.colB_DATESTATE.Width = 74;
            // 
            // colB_BUDGETDOCTYPE_NAME
            // 
            this.colB_BUDGETDOCTYPE_NAME.Caption = "Тип документа";
            this.colB_BUDGETDOCTYPE_NAME.FieldName = "B_BUDGETDOCTYPE_NAME";
            this.colB_BUDGETDOCTYPE_NAME.Name = "colB_BUDGETDOCTYPE_NAME";
            // 
            // colB_RECIPIENT
            // 
            this.colB_RECIPIENT.Caption = "Получатель средств";
            this.colB_RECIPIENT.FieldName = "B_RECIPIENT";
            this.colB_RECIPIENT.Name = "colB_RECIPIENT";
            // 
            // colB_CURRENCY
            // 
            this.colB_CURRENCY.Caption = "Валюта";
            this.colB_CURRENCY.FieldName = "B_CURRENCY";
            this.colB_CURRENCY.Name = "colB_CURRENCY";
            // 
            // colB_DOCMONEYAGREE
            // 
            this.colB_DOCMONEYAGREE.Caption = "Сумма, EUR";
            this.colB_DOCMONEYAGREE.DisplayFormat.FormatString = "### ### ###.##";
            this.colB_DOCMONEYAGREE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colB_DOCMONEYAGREE.FieldName = "B_DOCMONEYAGREE";
            this.colB_DOCMONEYAGREE.Name = "colB_DOCMONEYAGREE";
            this.colB_DOCMONEYAGREE.OptionsColumn.AllowEdit = false;
            this.colB_DOCMONEYAGREE.OptionsColumn.AllowFocus = false;
            this.colB_DOCMONEYAGREE.OptionsColumn.ReadOnly = true;
            this.colB_DOCMONEYAGREE.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_ACCTRNSUM
            // 
            this.colB_ACCTRNSUM.Caption = "Сумма транзакций, EUR";
            this.colB_ACCTRNSUM.DisplayFormat.FormatString = "### ### ###.##";
            this.colB_ACCTRNSUM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colB_ACCTRNSUM.FieldName = "B_ACCTRNSUM";
            this.colB_ACCTRNSUM.Name = "colB_ACCTRNSUM";
            this.colB_ACCTRNSUM.OptionsColumn.AllowEdit = false;
            this.colB_ACCTRNSUM.OptionsColumn.AllowFocus = false;
            this.colB_ACCTRNSUM.OptionsColumn.ReadOnly = true;
            this.colB_ACCTRNSUM.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_SALDOTRN
            // 
            this.colB_SALDOTRN.Caption = "Сальдо, EUR";
            this.colB_SALDOTRN.DisplayFormat.FormatString = "### ### ###.##";
            this.colB_SALDOTRN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colB_SALDOTRN.FieldName = "B_SALDOTRN";
            this.colB_SALDOTRN.Name = "colB_SALDOTRN";
            this.colB_SALDOTRN.OptionsColumn.AllowEdit = false;
            this.colB_SALDOTRN.OptionsColumn.AllowFocus = false;
            this.colB_SALDOTRN.OptionsColumn.ReadOnly = true;
            this.colB_SALDOTRN.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_NOTETYPE
            // 
            this.colB_NOTETYPE.CustomizationCaption = "Пометка";
            this.colB_NOTETYPE.ImageIndex = 2;
            this.colB_NOTETYPE.MinWidth = 29;
            this.colB_NOTETYPE.Name = "colB_NOTETYPE";
            this.colB_NOTETYPE.OptionsColumn.AllowEdit = false;
            this.colB_NOTETYPE.OptionsColumn.AllowFocus = false;
            this.colB_NOTETYPE.OptionsColumn.AllowSize = false;
            this.colB_NOTETYPE.OptionsColumn.FixedWidth = true;
            this.colB_NOTETYPE.OptionsColumn.ReadOnly = true;
            this.colB_NOTETYPE.Width = 29;
            // 
            // colB_NOTETYPE_ID
            // 
            this.colB_NOTETYPE_ID.FieldName = "B_NOTETYPE";
            this.colB_NOTETYPE_ID.Name = "colB_NOTETYPE_ID";
            this.colB_NOTETYPE_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_NOTETYPE_PREVID
            // 
            this.colB_NOTETYPE_PREVID.FieldName = "B_NOTETYPE_PREV";
            this.colB_NOTETYPE_PREVID.Name = "colB_NOTETYPE_PREVID";
            this.colB_NOTETYPE_PREVID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_COMMENT
            // 
            this.colB_COMMENT.CustomizationCaption = "Примечание";
            this.colB_COMMENT.FieldName = "B_USERCOMMENT";
            this.colB_COMMENT.ImageIndex = 3;
            this.colB_COMMENT.MinWidth = 29;
            this.colB_COMMENT.Name = "colB_COMMENT";
            this.colB_COMMENT.OptionsColumn.AllowEdit = false;
            this.colB_COMMENT.OptionsColumn.AllowFocus = false;
            this.colB_COMMENT.OptionsColumn.AllowSize = false;
            this.colB_COMMENT.OptionsColumn.FixedWidth = true;
            this.colB_COMMENT.OptionsColumn.ReadOnly = true;
            this.colB_COMMENT.Width = 29;
            // 
            // colB_COMMENTTEXT
            // 
            this.colB_COMMENTTEXT.Caption = "B_USERCOMMENT";
            this.colB_COMMENTTEXT.FieldName = "B_USERCOMMENT";
            this.colB_COMMENTTEXT.Name = "colB_COMMENTTEXT";
            this.colB_COMMENTTEXT.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colB_PAYMENTTYPE_NAME
            // 
            this.colB_PAYMENTTYPE_NAME.Caption = "Форма оплаты";
            this.colB_PAYMENTTYPE_NAME.FieldName = "B_PAYMENTTYPE_NAME";
            this.colB_PAYMENTTYPE_NAME.Name = "colB_PAYMENTTYPE_NAME";
            this.colB_PAYMENTTYPE_NAME.OptionsColumn.AllowEdit = false;
            this.colB_PAYMENTTYPE_NAME.OptionsColumn.AllowFocus = false;
            this.colB_PAYMENTTYPE_NAME.OptionsColumn.ReadOnly = true;
            this.colB_PAYMENTTYPE_NAME.Visible = true;
            this.colB_PAYMENTTYPE_NAME.VisibleIndex = 11;
            this.colB_PAYMENTTYPE_NAME.Width = 40;
            // 
            // colB_BUDGETEXPENSETYPE_NAME
            // 
            this.colB_BUDGETEXPENSETYPE_NAME.Caption = "Тип бюджетных расходов";
            this.colB_BUDGETEXPENSETYPE_NAME.FieldName = "B_BUDGETEXPENSETYPE_NAME";
            this.colB_BUDGETEXPENSETYPE_NAME.Name = "colB_BUDGETEXPENSETYPE_NAME";
            this.colB_BUDGETEXPENSETYPE_NAME.OptionsColumn.AllowEdit = false;
            this.colB_BUDGETEXPENSETYPE_NAME.OptionsColumn.AllowFocus = false;
            this.colB_BUDGETEXPENSETYPE_NAME.OptionsColumn.ReadOnly = true;
            this.colB_BUDGETEXPENSETYPE_NAME.Visible = true;
            this.colB_BUDGETEXPENSETYPE_NAME.VisibleIndex = 12;
            // 
            // tabPageDocNotActive
            // 
            this.tabPageDocNotActive.Controls.Add(this.tableLPFind);
            this.tabPageDocNotActive.Image = global::ErpBudgetBudgetDoc.Properties.Resources.mail_lock;
            this.tabPageDocNotActive.Name = "tabPageDocNotActive";
            this.tabPageDocNotActive.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDocNotActive.Size = new System.Drawing.Size(573, 326);
            this.tabPageDocNotActive.Text = "Архив заявок";
            this.tabPageDocNotActive.Tooltip = "Архив заявок";
            // 
            // tableLPFind
            // 
            this.tableLPFind.ColumnCount = 1;
            this.tableLPFind.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLPFind.Controls.Add(this.pnlFind, 0, 0);
            this.tableLPFind.Controls.Add(this.gridDocNotActive, 0, 1);
            this.tableLPFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLPFind.Location = new System.Drawing.Point(3, 3);
            this.tableLPFind.Margin = new System.Windows.Forms.Padding(0);
            this.tableLPFind.Name = "tableLPFind";
            this.tableLPFind.RowCount = 2;
            this.tableLPFind.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLPFind.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLPFind.Size = new System.Drawing.Size(567, 320);
            this.toolTipController.SetSuperTip(this.tableLPFind, null);
            this.tableLPFind.TabIndex = 1;
            // 
            // pnlFind
            // 
            this.pnlFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFind.Controls.Add(this.radioGroupDateType);
            this.pnlFind.Controls.Add(this.btnRefresh);
            this.pnlFind.Controls.Add(this.labelControl2);
            this.pnlFind.Controls.Add(this.labelControl1);
            this.pnlFind.Controls.Add(this.dtEndDate);
            this.pnlFind.Controls.Add(this.dtBeginDate);
            this.pnlFind.Location = new System.Drawing.Point(3, 3);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(561, 30);
            this.toolTipController.SetSuperTip(this.pnlFind, null);
            this.pnlFind.TabIndex = 0;
            // 
            // radioGroupDateType
            // 
            this.radioGroupDateType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroupDateType.Location = new System.Drawing.Point(333, 4);
            this.radioGroupDateType.Name = "radioGroupDateType";
            this.radioGroupDateType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "по дате заявки"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "по дате в архиве")});
            this.radioGroupDateType.Size = new System.Drawing.Size(223, 21);
            this.radioGroupDateType.TabIndex = 5;
            this.radioGroupDateType.ToolTip = "Выбор вариантов даты документа для поиска";
            this.radioGroupDateType.ToolTipController = this.toolTipController;
            this.radioGroupDateType.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::ErpBudgetBudgetDoc.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(252, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.ToolTip = "Обновить архив заявок";
            this.btnRefresh.ToolTipController = this.toolTipController;
            this.btnRefresh.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnRefresh.Click += new System.EventHandler(this.mitemRefresh_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(124, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(16, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "по";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(7, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "с";
            // 
            // dtEndDate
            // 
            this.dtEndDate.EditValue = null;
            this.dtEndDate.Location = new System.Drawing.Point(146, 5);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtEndDate.TabIndex = 1;
            // 
            // dtBeginDate
            // 
            this.dtBeginDate.EditValue = null;
            this.dtBeginDate.Location = new System.Drawing.Point(18, 5);
            this.dtBeginDate.Name = "dtBeginDate";
            this.dtBeginDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBeginDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtBeginDate.Size = new System.Drawing.Size(100, 20);
            this.dtBeginDate.TabIndex = 0;
            // 
            // gridDocNotActive
            // 
            this.gridDocNotActive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDocNotActive.DataMember = "dtDocNotActive";
            this.gridDocNotActive.DataSource = this.dsBudgetDoc;
            this.gridDocNotActive.EmbeddedNavigator.Name = "";
            this.gridDocNotActive.Location = new System.Drawing.Point(3, 39);
            this.gridDocNotActive.MainView = this.gridViewDocNotActive;
            this.gridDocNotActive.Name = "gridDocNotActive";
            this.gridDocNotActive.Size = new System.Drawing.Size(561, 278);
            this.gridDocNotActive.TabIndex = 0;
            this.gridDocNotActive.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDocNotActive});
            this.gridDocNotActive.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // gridViewDocNotActive
            // 
            this.gridViewDocNotActive.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colС_IMAGE_ID,
            this.colC_IMAGETYPE_ID,
            this.colC_ATTACH,
            this.colC_BUDGETDOC_GUID_ID,
            this.colC_CREATEDUSER_ID,
            this.colC_CREATEDUSER_NAME,
            this.colC_DOCDATE,
            this.colC_BUDGETDEP_GUID_ID,
            this.colC_BUDGETDEP_NAME,
            this.colC_DOCOBJECTIVE,
            this.colC_DOCMONEY,
            this.colC_BUDGETITEM_GUID_ID,
            this.colC_DEBITARTICLE_NAME,
            this.colC_COMPANY_GUID_ID,
            this.colC_COMPANY_NAME,
            this.colC_BUDGETDOCSTATE_NAME,
            this.colC_BUDGETDOCSTATE_GUID_ID,
            this.colC_DATESTATE,
            this.colC_BUDGETDOCTYPE_NAME,
            this.colC_RECIPIENT,
            this.colC_CURRENCY,
            this.colC_DOCMONEYAGREE,
            this.colC_ACCTRNSUM,
            this.colC_SALDOTRN,
            this.colC_NOTETYPE,
            this.colC_NOTETYPE_ID,
            this.colC_NOTETYPE_PREVID,
            this.colC_COMMENT,
            this.colC_COMMENTTEXT,
            this.colC_PAYMENTTYPE_NAME,
            this.colC_BUDGETEXPENSETYPE_NAME});
            this.gridViewDocNotActive.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDocNotActive.GridControl = this.gridDocNotActive;
            this.gridViewDocNotActive.Images = this.imageCollection;
            this.gridViewDocNotActive.Name = "gridViewDocNotActive";
            this.gridViewDocNotActive.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            this.gridViewDocNotActive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridViewDocNotActive_MouseDown);
            // 
            // colС_IMAGE_ID
            // 
            this.colС_IMAGE_ID.DisplayFormat.FormatString = "g";
            this.colС_IMAGE_ID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colС_IMAGE_ID.FieldName = "C_IMAGE_ID";
            this.colС_IMAGE_ID.MinWidth = 16;
            this.colС_IMAGE_ID.Name = "colС_IMAGE_ID";
            this.colС_IMAGE_ID.OptionsColumn.AllowEdit = false;
            this.colС_IMAGE_ID.OptionsColumn.AllowFocus = false;
            this.colС_IMAGE_ID.OptionsColumn.ReadOnly = true;
            this.colС_IMAGE_ID.OptionsFilter.AllowAutoFilter = false;
            this.colС_IMAGE_ID.OptionsFilter.AllowFilter = false;
            this.colС_IMAGE_ID.Visible = true;
            this.colС_IMAGE_ID.VisibleIndex = 0;
            this.colС_IMAGE_ID.Width = 17;
            // 
            // colC_IMAGETYPE_ID
            // 
            this.colC_IMAGETYPE_ID.FieldName = "C_IMAGETYPE_ID";
            this.colC_IMAGETYPE_ID.MinWidth = 16;
            this.colC_IMAGETYPE_ID.Name = "colC_IMAGETYPE_ID";
            this.colC_IMAGETYPE_ID.OptionsColumn.AllowEdit = false;
            this.colC_IMAGETYPE_ID.OptionsColumn.AllowFocus = false;
            this.colC_IMAGETYPE_ID.OptionsColumn.ReadOnly = true;
            this.colC_IMAGETYPE_ID.OptionsFilter.AllowAutoFilter = false;
            this.colC_IMAGETYPE_ID.OptionsFilter.AllowFilter = false;
            this.colC_IMAGETYPE_ID.Visible = true;
            this.colC_IMAGETYPE_ID.VisibleIndex = 1;
            this.colC_IMAGETYPE_ID.Width = 17;
            // 
            // colC_ATTACH
            // 
            this.colC_ATTACH.ImageIndex = 1;
            this.colC_ATTACH.Name = "colC_ATTACH";
            this.colC_ATTACH.OptionsColumn.AllowEdit = false;
            this.colC_ATTACH.OptionsColumn.AllowFocus = false;
            this.colC_ATTACH.OptionsColumn.ReadOnly = true;
            this.colC_ATTACH.OptionsFilter.AllowAutoFilter = false;
            this.colC_ATTACH.OptionsFilter.AllowFilter = false;
            this.colC_ATTACH.Visible = true;
            this.colC_ATTACH.VisibleIndex = 2;
            this.colC_ATTACH.Width = 20;
            // 
            // colC_BUDGETDOC_GUID_ID
            // 
            this.colC_BUDGETDOC_GUID_ID.Caption = "C_BUDGETDOC_GUID_ID";
            this.colC_BUDGETDOC_GUID_ID.FieldName = "C_BUDGETDOC_GUID_ID";
            this.colC_BUDGETDOC_GUID_ID.Name = "colC_BUDGETDOC_GUID_ID";
            this.colC_BUDGETDOC_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colC_BUDGETDOC_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colC_BUDGETDOC_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colC_BUDGETDOC_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_CREATEDUSER_ID
            // 
            this.colC_CREATEDUSER_ID.Caption = "C_CREATEDUSER_ID";
            this.colC_CREATEDUSER_ID.FieldName = "C_CREATEDUSER_ID";
            this.colC_CREATEDUSER_ID.Name = "colC_CREATEDUSER_ID";
            this.colC_CREATEDUSER_ID.OptionsColumn.AllowEdit = false;
            this.colC_CREATEDUSER_ID.OptionsColumn.AllowFocus = false;
            this.colC_CREATEDUSER_ID.OptionsColumn.ReadOnly = true;
            this.colC_CREATEDUSER_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_CREATEDUSER_NAME
            // 
            this.colC_CREATEDUSER_NAME.Caption = "Инициатор";
            this.colC_CREATEDUSER_NAME.FieldName = "C_CREATEDUSER_NAME";
            this.colC_CREATEDUSER_NAME.Name = "colC_CREATEDUSER_NAME";
            this.colC_CREATEDUSER_NAME.OptionsColumn.AllowEdit = false;
            this.colC_CREATEDUSER_NAME.OptionsColumn.AllowFocus = false;
            this.colC_CREATEDUSER_NAME.OptionsColumn.ReadOnly = true;
            this.colC_CREATEDUSER_NAME.Visible = true;
            this.colC_CREATEDUSER_NAME.VisibleIndex = 3;
            this.colC_CREATEDUSER_NAME.Width = 36;
            // 
            // colC_DOCDATE
            // 
            this.colC_DOCDATE.Caption = "Дата заявки";
            this.colC_DOCDATE.FieldName = "C_DOCDATE";
            this.colC_DOCDATE.Name = "colC_DOCDATE";
            this.colC_DOCDATE.OptionsColumn.AllowEdit = false;
            this.colC_DOCDATE.OptionsColumn.AllowFocus = false;
            this.colC_DOCDATE.OptionsColumn.ReadOnly = true;
            this.colC_DOCDATE.Visible = true;
            this.colC_DOCDATE.VisibleIndex = 4;
            this.colC_DOCDATE.Width = 36;
            // 
            // colC_BUDGETDEP_GUID_ID
            // 
            this.colC_BUDGETDEP_GUID_ID.Caption = "C_BUDGETDEP_GUID_ID";
            this.colC_BUDGETDEP_GUID_ID.FieldName = "C_BUDGETDEP_GUID_ID";
            this.colC_BUDGETDEP_GUID_ID.Name = "colC_BUDGETDEP_GUID_ID";
            this.colC_BUDGETDEP_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colC_BUDGETDEP_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colC_BUDGETDEP_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colC_BUDGETDEP_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_BUDGETDEP_NAME
            // 
            this.colC_BUDGETDEP_NAME.Caption = "Служба";
            this.colC_BUDGETDEP_NAME.FieldName = "C_BUDGETDEP_NAME";
            this.colC_BUDGETDEP_NAME.Name = "colC_BUDGETDEP_NAME";
            this.colC_BUDGETDEP_NAME.OptionsColumn.AllowEdit = false;
            this.colC_BUDGETDEP_NAME.OptionsColumn.AllowFocus = false;
            this.colC_BUDGETDEP_NAME.OptionsColumn.ReadOnly = true;
            this.colC_BUDGETDEP_NAME.Visible = true;
            this.colC_BUDGETDEP_NAME.VisibleIndex = 5;
            this.colC_BUDGETDEP_NAME.Width = 36;
            // 
            // colC_DOCOBJECTIVE
            // 
            this.colC_DOCOBJECTIVE.Caption = "Описание цели";
            this.colC_DOCOBJECTIVE.FieldName = "C_DOCOBJECTIVE";
            this.colC_DOCOBJECTIVE.Name = "colC_DOCOBJECTIVE";
            this.colC_DOCOBJECTIVE.OptionsColumn.AllowEdit = false;
            this.colC_DOCOBJECTIVE.OptionsColumn.AllowFocus = false;
            this.colC_DOCOBJECTIVE.OptionsColumn.ReadOnly = true;
            this.colC_DOCOBJECTIVE.Visible = true;
            this.colC_DOCOBJECTIVE.VisibleIndex = 6;
            this.colC_DOCOBJECTIVE.Width = 36;
            // 
            // colC_DOCMONEY
            // 
            this.colC_DOCMONEY.Caption = "Сумма";
            this.colC_DOCMONEY.DisplayFormat.FormatString = "### ### ###.##";
            this.colC_DOCMONEY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colC_DOCMONEY.FieldName = "C_DOCMONEY";
            this.colC_DOCMONEY.Name = "colC_DOCMONEY";
            this.colC_DOCMONEY.OptionsColumn.AllowEdit = false;
            this.colC_DOCMONEY.OptionsColumn.AllowFocus = false;
            this.colC_DOCMONEY.OptionsColumn.ReadOnly = true;
            this.colC_DOCMONEY.Visible = true;
            this.colC_DOCMONEY.VisibleIndex = 7;
            this.colC_DOCMONEY.Width = 36;
            // 
            // colC_BUDGETITEM_GUID_ID
            // 
            this.colC_BUDGETITEM_GUID_ID.Caption = "C_BUDGETITEM_GUID_ID";
            this.colC_BUDGETITEM_GUID_ID.FieldName = "C_BUDGETITEM_GUID_ID";
            this.colC_BUDGETITEM_GUID_ID.Name = "colC_BUDGETITEM_GUID_ID";
            this.colC_BUDGETITEM_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colC_BUDGETITEM_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colC_BUDGETITEM_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colC_BUDGETITEM_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_DEBITARTICLE_NAME
            // 
            this.colC_DEBITARTICLE_NAME.Caption = "Статья расходов";
            this.colC_DEBITARTICLE_NAME.FieldName = "C_DEBITARTICLE_NAME";
            this.colC_DEBITARTICLE_NAME.Name = "colC_DEBITARTICLE_NAME";
            this.colC_DEBITARTICLE_NAME.OptionsColumn.AllowEdit = false;
            this.colC_DEBITARTICLE_NAME.OptionsColumn.AllowFocus = false;
            this.colC_DEBITARTICLE_NAME.OptionsColumn.ReadOnly = true;
            this.colC_DEBITARTICLE_NAME.Visible = true;
            this.colC_DEBITARTICLE_NAME.VisibleIndex = 8;
            this.colC_DEBITARTICLE_NAME.Width = 36;
            // 
            // colC_COMPANY_GUID_ID
            // 
            this.colC_COMPANY_GUID_ID.Caption = "C_COMPANY_GUID_ID";
            this.colC_COMPANY_GUID_ID.FieldName = "C_COMPANY_GUID_ID";
            this.colC_COMPANY_GUID_ID.Name = "colC_COMPANY_GUID_ID";
            this.colC_COMPANY_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colC_COMPANY_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colC_COMPANY_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colC_COMPANY_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_COMPANY_NAME
            // 
            this.colC_COMPANY_NAME.Caption = "Фирма";
            this.colC_COMPANY_NAME.FieldName = "C_COMPANY_NAME";
            this.colC_COMPANY_NAME.Name = "colC_COMPANY_NAME";
            this.colC_COMPANY_NAME.OptionsColumn.AllowEdit = false;
            this.colC_COMPANY_NAME.OptionsColumn.AllowFocus = false;
            this.colC_COMPANY_NAME.OptionsColumn.ReadOnly = true;
            this.colC_COMPANY_NAME.Visible = true;
            this.colC_COMPANY_NAME.VisibleIndex = 9;
            this.colC_COMPANY_NAME.Width = 36;
            // 
            // colC_BUDGETDOCSTATE_NAME
            // 
            this.colC_BUDGETDOCSTATE_NAME.Caption = "Состояние";
            this.colC_BUDGETDOCSTATE_NAME.FieldName = "C_BUDGETDOCSTATE_NAME";
            this.colC_BUDGETDOCSTATE_NAME.Name = "colC_BUDGETDOCSTATE_NAME";
            this.colC_BUDGETDOCSTATE_NAME.OptionsColumn.AllowEdit = false;
            this.colC_BUDGETDOCSTATE_NAME.OptionsColumn.AllowFocus = false;
            this.colC_BUDGETDOCSTATE_NAME.OptionsColumn.ReadOnly = true;
            this.colC_BUDGETDOCSTATE_NAME.Visible = true;
            this.colC_BUDGETDOCSTATE_NAME.VisibleIndex = 10;
            this.colC_BUDGETDOCSTATE_NAME.Width = 52;
            // 
            // colC_BUDGETDOCSTATE_GUID_ID
            // 
            this.colC_BUDGETDOCSTATE_GUID_ID.Caption = "C_BUDGETDOCSTATE_GUID_ID";
            this.colC_BUDGETDOCSTATE_GUID_ID.FieldName = "C_BUDGETDOCSTATE_GUID_ID";
            this.colC_BUDGETDOCSTATE_GUID_ID.Name = "colC_BUDGETDOCSTATE_GUID_ID";
            this.colC_BUDGETDOCSTATE_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colC_BUDGETDOCSTATE_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colC_BUDGETDOCSTATE_GUID_ID.OptionsColumn.ReadOnly = true;
            this.colC_BUDGETDOCSTATE_GUID_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_DATESTATE
            // 
            this.colC_DATESTATE.Caption = "Дата";
            this.colC_DATESTATE.DisplayFormat.FormatString = "g";
            this.colC_DATESTATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colC_DATESTATE.FieldName = "C_DATESTATE";
            this.colC_DATESTATE.Name = "colC_DATESTATE";
            this.colC_DATESTATE.OptionsColumn.AllowEdit = false;
            this.colC_DATESTATE.OptionsColumn.AllowFocus = false;
            this.colC_DATESTATE.OptionsColumn.ReadOnly = true;
            this.colC_DATESTATE.Visible = true;
            this.colC_DATESTATE.VisibleIndex = 11;
            this.colC_DATESTATE.Width = 116;
            // 
            // colC_BUDGETDOCTYPE_NAME
            // 
            this.colC_BUDGETDOCTYPE_NAME.Caption = "Тип документа";
            this.colC_BUDGETDOCTYPE_NAME.FieldName = "C_BUDGETDOCTYPE_NAME";
            this.colC_BUDGETDOCTYPE_NAME.Name = "colC_BUDGETDOCTYPE_NAME";
            // 
            // colC_RECIPIENT
            // 
            this.colC_RECIPIENT.Caption = "Получатель средств";
            this.colC_RECIPIENT.FieldName = "C_RECIPIENT";
            this.colC_RECIPIENT.Name = "colC_RECIPIENT";
            // 
            // colC_CURRENCY
            // 
            this.colC_CURRENCY.Caption = "Валюта";
            this.colC_CURRENCY.FieldName = "C_CURRENCY";
            this.colC_CURRENCY.Name = "colC_CURRENCY";
            // 
            // colC_DOCMONEYAGREE
            // 
            this.colC_DOCMONEYAGREE.Caption = "Сумма, EUR";
            this.colC_DOCMONEYAGREE.CustomizationCaption = "Сумма, EUR";
            this.colC_DOCMONEYAGREE.DisplayFormat.FormatString = "### ### ###.##";
            this.colC_DOCMONEYAGREE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colC_DOCMONEYAGREE.FieldName = "C_DOCMONEYAGREE";
            this.colC_DOCMONEYAGREE.Name = "colC_DOCMONEYAGREE";
            this.colC_DOCMONEYAGREE.OptionsColumn.AllowEdit = false;
            this.colC_DOCMONEYAGREE.OptionsColumn.AllowFocus = false;
            this.colC_DOCMONEYAGREE.OptionsColumn.ReadOnly = true;
            // 
            // colC_ACCTRNSUM
            // 
            this.colC_ACCTRNSUM.Caption = "Сумма транзакций, EUR";
            this.colC_ACCTRNSUM.CustomizationCaption = "Сумма транзакций, EUR";
            this.colC_ACCTRNSUM.DisplayFormat.FormatString = "### ### ###.##";
            this.colC_ACCTRNSUM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colC_ACCTRNSUM.FieldName = "C_ACCTRNSUM";
            this.colC_ACCTRNSUM.Name = "colC_ACCTRNSUM";
            this.colC_ACCTRNSUM.OptionsColumn.AllowEdit = false;
            this.colC_ACCTRNSUM.OptionsColumn.AllowFocus = false;
            this.colC_ACCTRNSUM.OptionsColumn.ReadOnly = true;
            // 
            // colC_SALDOTRN
            // 
            this.colC_SALDOTRN.Caption = "Сальдо, EUR";
            this.colC_SALDOTRN.CustomizationCaption = "Сальдо, EUR";
            this.colC_SALDOTRN.DisplayFormat.FormatString = "### ### ###.##";
            this.colC_SALDOTRN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colC_SALDOTRN.FieldName = "C_SALDOTRN";
            this.colC_SALDOTRN.Name = "colC_SALDOTRN";
            this.colC_SALDOTRN.OptionsColumn.AllowEdit = false;
            this.colC_SALDOTRN.OptionsColumn.AllowFocus = false;
            this.colC_SALDOTRN.OptionsColumn.ReadOnly = true;
            // 
            // colC_NOTETYPE
            // 
            this.colC_NOTETYPE.CustomizationCaption = "Пометка";
            this.colC_NOTETYPE.ImageIndex = 2;
            this.colC_NOTETYPE.MinWidth = 29;
            this.colC_NOTETYPE.Name = "colC_NOTETYPE";
            this.colC_NOTETYPE.OptionsColumn.AllowEdit = false;
            this.colC_NOTETYPE.OptionsColumn.AllowFocus = false;
            this.colC_NOTETYPE.OptionsColumn.AllowSize = false;
            this.colC_NOTETYPE.OptionsColumn.FixedWidth = true;
            this.colC_NOTETYPE.OptionsColumn.ReadOnly = true;
            this.colC_NOTETYPE.OptionsFilter.AllowAutoFilter = false;
            this.colC_NOTETYPE.OptionsFilter.AllowFilter = false;
            this.colC_NOTETYPE.Width = 29;
            // 
            // colC_NOTETYPE_ID
            // 
            this.colC_NOTETYPE_ID.FieldName = "C_NOTETYPE";
            this.colC_NOTETYPE_ID.Name = "colC_NOTETYPE_ID";
            this.colC_NOTETYPE_ID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_NOTETYPE_PREVID
            // 
            this.colC_NOTETYPE_PREVID.FieldName = "C_NOTETYPE_PREV";
            this.colC_NOTETYPE_PREVID.Name = "colC_NOTETYPE_PREVID";
            this.colC_NOTETYPE_PREVID.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_COMMENT
            // 
            this.colC_COMMENT.CustomizationCaption = "Примечание";
            this.colC_COMMENT.FieldName = "C_USERCOMMENT";
            this.colC_COMMENT.ImageIndex = 3;
            this.colC_COMMENT.MinWidth = 29;
            this.colC_COMMENT.Name = "colC_COMMENT";
            this.colC_COMMENT.OptionsColumn.AllowEdit = false;
            this.colC_COMMENT.OptionsColumn.AllowFocus = false;
            this.colC_COMMENT.OptionsColumn.AllowSize = false;
            this.colC_COMMENT.OptionsColumn.FixedWidth = true;
            this.colC_COMMENT.OptionsColumn.ReadOnly = true;
            this.colC_COMMENT.Width = 29;
            // 
            // colC_COMMENTTEXT
            // 
            this.colC_COMMENTTEXT.FieldName = "C_USERCOMMENT";
            this.colC_COMMENTTEXT.Name = "colC_COMMENTTEXT";
            this.colC_COMMENTTEXT.OptionsColumn.AllowEdit = false;
            this.colC_COMMENTTEXT.OptionsColumn.AllowFocus = false;
            this.colC_COMMENTTEXT.OptionsColumn.ReadOnly = true;
            this.colC_COMMENTTEXT.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colC_PAYMENTTYPE_NAME
            // 
            this.colC_PAYMENTTYPE_NAME.Caption = "Форма оплаты";
            this.colC_PAYMENTTYPE_NAME.FieldName = "C_PAYMENTTYPE_NAME";
            this.colC_PAYMENTTYPE_NAME.Name = "colC_PAYMENTTYPE_NAME";
            this.colC_PAYMENTTYPE_NAME.OptionsColumn.AllowEdit = false;
            this.colC_PAYMENTTYPE_NAME.OptionsColumn.AllowFocus = false;
            this.colC_PAYMENTTYPE_NAME.OptionsColumn.ReadOnly = true;
            this.colC_PAYMENTTYPE_NAME.Visible = true;
            this.colC_PAYMENTTYPE_NAME.VisibleIndex = 12;
            this.colC_PAYMENTTYPE_NAME.Width = 40;
            // 
            // colC_BUDGETEXPENSETYPE_NAME
            // 
            this.colC_BUDGETEXPENSETYPE_NAME.Caption = "Тип бюджетных расходов";
            this.colC_BUDGETEXPENSETYPE_NAME.FieldName = "C_BUDGETEXPENSETYPE_NAME";
            this.colC_BUDGETEXPENSETYPE_NAME.Name = "colC_BUDGETEXPENSETYPE_NAME";
            this.colC_BUDGETEXPENSETYPE_NAME.OptionsColumn.AllowEdit = false;
            this.colC_BUDGETEXPENSETYPE_NAME.OptionsColumn.AllowFocus = false;
            this.colC_BUDGETEXPENSETYPE_NAME.OptionsColumn.ReadOnly = true;
            this.colC_BUDGETEXPENSETYPE_NAME.Visible = true;
            this.colC_BUDGETEXPENSETYPE_NAME.VisibleIndex = 13;
            // 
            // tabPageError
            // 
            this.tabPageError.Controls.Add(this.gridDocErr);
            this.tabPageError.Image = global::ErpBudgetBudgetDoc.Properties.Resources.loading;
            this.tabPageError.Name = "tabPageError";
            this.tabPageError.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageError.Size = new System.Drawing.Size(573, 326);
            this.tabPageError.Text = "Журнал ошибок";
            // 
            // gridDocErr
            // 
            this.gridDocErr.DataMember = "dtDocError";
            this.gridDocErr.DataSource = this.dsBudgetDoc;
            this.gridDocErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDocErr.EmbeddedNavigator.Name = "";
            this.gridDocErr.Location = new System.Drawing.Point(3, 3);
            this.gridDocErr.MainView = this.gridViewDocErr;
            this.gridDocErr.Name = "gridDocErr";
            this.gridDocErr.Size = new System.Drawing.Size(567, 320);
            this.gridDocErr.TabIndex = 0;
            this.gridDocErr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDocErr});
            // 
            // gridViewDocErr
            // 
            this.gridViewDocErr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colE_IMAGE_ID,
            this.colE_IMAGETYPE_ID,
            this.colE_BUDGETDOC_GUID_ID,
            this.colE_CREATEDUSER_ID,
            this.colE_CREATEDUSER_NAME,
            this.colE_DOCDATE,
            this.colE_BUDGETDEP_GUID_ID,
            this.colE_BUDGETDEP_NAME,
            this.colE_DOCOBJECTIVE,
            this.colE_DOCMONEY,
            this.colE_BUDGETITEM_GUID_ID,
            this.colE_DEBITARTICLE_NAME,
            this.colE_COMPANY_GUID_ID,
            this.colE_COMPANY_NAME,
            this.colE_BUDGETDOCSTATE_NAME,
            this.colE_BUDGETDOCSTATE_GUID_ID,
            this.colE_DOCACTIVE,
            this.colE_BUDGETDOCTYPE_NAME,
            this.colE_PAYMENTTYPE_NAME});
            this.gridViewDocErr.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDocErr.GridControl = this.gridDocErr;
            this.gridViewDocErr.Name = "gridViewDocErr";
            // 
            // colE_IMAGE_ID
            // 
            this.colE_IMAGE_ID.FieldName = "E_IMAGE_ID";
            this.colE_IMAGE_ID.MinWidth = 16;
            this.colE_IMAGE_ID.Name = "colE_IMAGE_ID";
            this.colE_IMAGE_ID.OptionsColumn.AllowEdit = false;
            this.colE_IMAGE_ID.OptionsColumn.AllowFocus = false;
            this.colE_IMAGE_ID.OptionsColumn.AllowSize = false;
            this.colE_IMAGE_ID.OptionsColumn.ReadOnly = true;
            this.colE_IMAGE_ID.OptionsFilter.AllowAutoFilter = false;
            this.colE_IMAGE_ID.OptionsFilter.AllowFilter = false;
            this.colE_IMAGE_ID.Width = 16;
            // 
            // colE_IMAGETYPE_ID
            // 
            this.colE_IMAGETYPE_ID.FieldName = "E_IMAGETYPE_ID";
            this.colE_IMAGETYPE_ID.MinWidth = 16;
            this.colE_IMAGETYPE_ID.Name = "colE_IMAGETYPE_ID";
            this.colE_IMAGETYPE_ID.OptionsColumn.AllowEdit = false;
            this.colE_IMAGETYPE_ID.OptionsColumn.AllowFocus = false;
            this.colE_IMAGETYPE_ID.OptionsColumn.AllowSize = false;
            this.colE_IMAGETYPE_ID.OptionsColumn.ReadOnly = true;
            this.colE_IMAGETYPE_ID.OptionsFilter.AllowAutoFilter = false;
            this.colE_IMAGETYPE_ID.OptionsFilter.AllowFilter = false;
            this.colE_IMAGETYPE_ID.Visible = true;
            this.colE_IMAGETYPE_ID.VisibleIndex = 0;
            this.colE_IMAGETYPE_ID.Width = 16;
            // 
            // colE_BUDGETDOC_GUID_ID
            // 
            this.colE_BUDGETDOC_GUID_ID.Caption = "E_BUDGETDOC_GUID_ID";
            this.colE_BUDGETDOC_GUID_ID.FieldName = "E_BUDGETDOC_GUID_ID";
            this.colE_BUDGETDOC_GUID_ID.Name = "colE_BUDGETDOC_GUID_ID";
            this.colE_BUDGETDOC_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colE_BUDGETDOC_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colE_BUDGETDOC_GUID_ID.OptionsColumn.ReadOnly = true;
            // 
            // colE_CREATEDUSER_ID
            // 
            this.colE_CREATEDUSER_ID.Caption = "E_CREATEDUSER_ID";
            this.colE_CREATEDUSER_ID.FieldName = "E_CREATEDUSER_ID";
            this.colE_CREATEDUSER_ID.Name = "colE_CREATEDUSER_ID";
            this.colE_CREATEDUSER_ID.OptionsColumn.AllowEdit = false;
            this.colE_CREATEDUSER_ID.OptionsColumn.AllowFocus = false;
            this.colE_CREATEDUSER_ID.OptionsColumn.ReadOnly = true;
            // 
            // colE_CREATEDUSER_NAME
            // 
            this.colE_CREATEDUSER_NAME.Caption = "Инициатор";
            this.colE_CREATEDUSER_NAME.FieldName = "E_CREATEDUSER_NAME";
            this.colE_CREATEDUSER_NAME.Name = "colE_CREATEDUSER_NAME";
            this.colE_CREATEDUSER_NAME.OptionsColumn.AllowEdit = false;
            this.colE_CREATEDUSER_NAME.OptionsColumn.AllowFocus = false;
            this.colE_CREATEDUSER_NAME.OptionsColumn.ReadOnly = true;
            this.colE_CREATEDUSER_NAME.Visible = true;
            this.colE_CREATEDUSER_NAME.VisibleIndex = 1;
            this.colE_CREATEDUSER_NAME.Width = 55;
            // 
            // colE_DOCDATE
            // 
            this.colE_DOCDATE.Caption = "Дата заявки";
            this.colE_DOCDATE.FieldName = "E_DOCDATE";
            this.colE_DOCDATE.Name = "colE_DOCDATE";
            this.colE_DOCDATE.OptionsColumn.AllowEdit = false;
            this.colE_DOCDATE.OptionsColumn.AllowFocus = false;
            this.colE_DOCDATE.OptionsColumn.ReadOnly = true;
            this.colE_DOCDATE.Visible = true;
            this.colE_DOCDATE.VisibleIndex = 2;
            this.colE_DOCDATE.Width = 55;
            // 
            // colE_BUDGETDEP_GUID_ID
            // 
            this.colE_BUDGETDEP_GUID_ID.Caption = "E_BUDGETDEP_GUID_ID";
            this.colE_BUDGETDEP_GUID_ID.FieldName = "E_BUDGETDEP_GUID_ID";
            this.colE_BUDGETDEP_GUID_ID.Name = "colE_BUDGETDEP_GUID_ID";
            this.colE_BUDGETDEP_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colE_BUDGETDEP_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colE_BUDGETDEP_GUID_ID.OptionsColumn.ReadOnly = true;
            // 
            // colE_BUDGETDEP_NAME
            // 
            this.colE_BUDGETDEP_NAME.Caption = "Служба";
            this.colE_BUDGETDEP_NAME.FieldName = "E_BUDGETDEP_NAME";
            this.colE_BUDGETDEP_NAME.Name = "colE_BUDGETDEP_NAME";
            this.colE_BUDGETDEP_NAME.OptionsColumn.AllowEdit = false;
            this.colE_BUDGETDEP_NAME.OptionsColumn.AllowFocus = false;
            this.colE_BUDGETDEP_NAME.OptionsColumn.ReadOnly = true;
            this.colE_BUDGETDEP_NAME.Visible = true;
            this.colE_BUDGETDEP_NAME.VisibleIndex = 3;
            this.colE_BUDGETDEP_NAME.Width = 55;
            // 
            // colE_DOCOBJECTIVE
            // 
            this.colE_DOCOBJECTIVE.Caption = "Описание цели";
            this.colE_DOCOBJECTIVE.FieldName = "E_DOCOBJECTIVE";
            this.colE_DOCOBJECTIVE.Name = "colE_DOCOBJECTIVE";
            this.colE_DOCOBJECTIVE.OptionsColumn.AllowEdit = false;
            this.colE_DOCOBJECTIVE.OptionsColumn.AllowFocus = false;
            this.colE_DOCOBJECTIVE.OptionsColumn.ReadOnly = true;
            this.colE_DOCOBJECTIVE.Visible = true;
            this.colE_DOCOBJECTIVE.VisibleIndex = 4;
            this.colE_DOCOBJECTIVE.Width = 55;
            // 
            // colE_DOCMONEY
            // 
            this.colE_DOCMONEY.Caption = "Сумма";
            this.colE_DOCMONEY.DisplayFormat.FormatString = "### ###.##";
            this.colE_DOCMONEY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colE_DOCMONEY.FieldName = "E_DOCMONEY";
            this.colE_DOCMONEY.Name = "colE_DOCMONEY";
            this.colE_DOCMONEY.OptionsColumn.AllowEdit = false;
            this.colE_DOCMONEY.OptionsColumn.AllowFocus = false;
            this.colE_DOCMONEY.OptionsColumn.ReadOnly = true;
            this.colE_DOCMONEY.Visible = true;
            this.colE_DOCMONEY.VisibleIndex = 5;
            this.colE_DOCMONEY.Width = 55;
            // 
            // colE_BUDGETITEM_GUID_ID
            // 
            this.colE_BUDGETITEM_GUID_ID.Caption = "E_BUDGETITEM_GUID_ID";
            this.colE_BUDGETITEM_GUID_ID.FieldName = "E_BUDGETITEM_GUID_ID";
            this.colE_BUDGETITEM_GUID_ID.Name = "colE_BUDGETITEM_GUID_ID";
            this.colE_BUDGETITEM_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colE_BUDGETITEM_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colE_BUDGETITEM_GUID_ID.OptionsColumn.ReadOnly = true;
            // 
            // colE_DEBITARTICLE_NAME
            // 
            this.colE_DEBITARTICLE_NAME.Caption = "Статья расходов";
            this.colE_DEBITARTICLE_NAME.FieldName = "E_DEBITARTICLE_NAME";
            this.colE_DEBITARTICLE_NAME.Name = "colE_DEBITARTICLE_NAME";
            this.colE_DEBITARTICLE_NAME.OptionsColumn.AllowEdit = false;
            this.colE_DEBITARTICLE_NAME.OptionsColumn.AllowFocus = false;
            this.colE_DEBITARTICLE_NAME.OptionsColumn.ReadOnly = true;
            this.colE_DEBITARTICLE_NAME.Visible = true;
            this.colE_DEBITARTICLE_NAME.VisibleIndex = 6;
            this.colE_DEBITARTICLE_NAME.Width = 55;
            // 
            // colE_COMPANY_GUID_ID
            // 
            this.colE_COMPANY_GUID_ID.Caption = "E_COMPANY_GUID_ID";
            this.colE_COMPANY_GUID_ID.FieldName = "E_COMPANY_GUID_ID";
            this.colE_COMPANY_GUID_ID.Name = "colE_COMPANY_GUID_ID";
            this.colE_COMPANY_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colE_COMPANY_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colE_COMPANY_GUID_ID.OptionsColumn.ReadOnly = true;
            // 
            // colE_COMPANY_NAME
            // 
            this.colE_COMPANY_NAME.Caption = "Фирма";
            this.colE_COMPANY_NAME.FieldName = "E_COMPANY_NAME";
            this.colE_COMPANY_NAME.Name = "colE_COMPANY_NAME";
            this.colE_COMPANY_NAME.OptionsColumn.AllowEdit = false;
            this.colE_COMPANY_NAME.OptionsColumn.AllowFocus = false;
            this.colE_COMPANY_NAME.OptionsColumn.ReadOnly = true;
            this.colE_COMPANY_NAME.Visible = true;
            this.colE_COMPANY_NAME.VisibleIndex = 7;
            this.colE_COMPANY_NAME.Width = 55;
            // 
            // colE_BUDGETDOCSTATE_NAME
            // 
            this.colE_BUDGETDOCSTATE_NAME.Caption = "Состояние";
            this.colE_BUDGETDOCSTATE_NAME.FieldName = "E_BUDGETDOCSTATE_NAME";
            this.colE_BUDGETDOCSTATE_NAME.Name = "colE_BUDGETDOCSTATE_NAME";
            this.colE_BUDGETDOCSTATE_NAME.OptionsColumn.AllowEdit = false;
            this.colE_BUDGETDOCSTATE_NAME.OptionsColumn.AllowFocus = false;
            this.colE_BUDGETDOCSTATE_NAME.OptionsColumn.ReadOnly = true;
            this.colE_BUDGETDOCSTATE_NAME.Visible = true;
            this.colE_BUDGETDOCSTATE_NAME.VisibleIndex = 8;
            this.colE_BUDGETDOCSTATE_NAME.Width = 79;
            // 
            // colE_BUDGETDOCSTATE_GUID_ID
            // 
            this.colE_BUDGETDOCSTATE_GUID_ID.Caption = "E_BUDGETDOCSTATE_GUID_ID";
            this.colE_BUDGETDOCSTATE_GUID_ID.FieldName = "E_BUDGETDOCSTATE_GUID_ID";
            this.colE_BUDGETDOCSTATE_GUID_ID.Name = "colE_BUDGETDOCSTATE_GUID_ID";
            this.colE_BUDGETDOCSTATE_GUID_ID.OptionsColumn.AllowEdit = false;
            this.colE_BUDGETDOCSTATE_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colE_BUDGETDOCSTATE_GUID_ID.OptionsColumn.ReadOnly = true;
            // 
            // colE_DOCACTIVE
            // 
            this.colE_DOCACTIVE.Caption = "E_DOCACTIVE";
            this.colE_DOCACTIVE.FieldName = "E_DOCACTIVE";
            this.colE_DOCACTIVE.Name = "colE_DOCACTIVE";
            this.colE_DOCACTIVE.OptionsColumn.AllowEdit = false;
            this.colE_DOCACTIVE.OptionsColumn.AllowFocus = false;
            this.colE_DOCACTIVE.OptionsColumn.ReadOnly = true;
            // 
            // colE_BUDGETDOCTYPE_NAME
            // 
            this.colE_BUDGETDOCTYPE_NAME.Caption = "Тип документа";
            this.colE_BUDGETDOCTYPE_NAME.FieldName = "E_BUDGETDOCTYPE_NAME";
            this.colE_BUDGETDOCTYPE_NAME.Name = "colE_BUDGETDOCTYPE_NAME";
            // 
            // colE_PAYMENTTYPE_NAME
            // 
            this.colE_PAYMENTTYPE_NAME.Caption = "Форма оплаты";
            this.colE_PAYMENTTYPE_NAME.FieldName = "E_PAYMENTTYPE_NAME";
            this.colE_PAYMENTTYPE_NAME.Name = "colE_PAYMENTTYPE_NAME";
            this.colE_PAYMENTTYPE_NAME.OptionsColumn.AllowEdit = false;
            this.colE_PAYMENTTYPE_NAME.OptionsColumn.AllowFocus = false;
            this.colE_PAYMENTTYPE_NAME.OptionsColumn.ReadOnly = true;
            this.colE_PAYMENTTYPE_NAME.Visible = true;
            this.colE_PAYMENTTYPE_NAME.VisibleIndex = 9;
            this.colE_PAYMENTTYPE_NAME.Width = 40;
            // 
            // contextMenuNoteType
            // 
            this.contextMenuNoteType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator1,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.contextMenuNoteType.Name = "contextMenuStrip";
            this.contextMenuNoteType.Size = new System.Drawing.Size(177, 142);
            this.toolTipController.SetSuperTip(this.contextMenuNoteType, null);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem2.Text = "Обновить";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem3.Text = "Создать заявку";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem4.Text = "Копировать заявку";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem5.Text = "Удалить заявку";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem6.Text = "Журнал транзакций";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem7.Text = "Журнал состояний";
            // 
            // contextMenuComment
            // 
            this.contextMenuComment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemAddComment,
            this.mitemDeleteComment});
            this.contextMenuComment.Name = "contextMenuComment";
            this.contextMenuComment.Size = new System.Drawing.Size(188, 48);
            this.toolTipController.SetSuperTip(this.contextMenuComment, null);
            this.contextMenuComment.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuComment_Opening);
            // 
            // mitemAddComment
            // 
            this.mitemAddComment.Image = global::ErpBudgetBudgetDoc.Properties.Resources.message_add;
            this.mitemAddComment.Name = "mitemAddComment";
            this.mitemAddComment.Size = new System.Drawing.Size(187, 22);
            this.mitemAddComment.Text = "Комментарий";
            this.mitemAddComment.Click += new System.EventHandler(this.mitemAddComment_Click);
            // 
            // mitemDeleteComment
            // 
            this.mitemDeleteComment.Image = global::ErpBudgetBudgetDoc.Properties.Resources.message_delete;
            this.mitemDeleteComment.Name = "mitemDeleteComment";
            this.mitemDeleteComment.Size = new System.Drawing.Size(187, 22);
            this.mitemDeleteComment.Text = "Удалить комментарий";
            this.mitemDeleteComment.Click += new System.EventHandler(this.mitemDeleteComment_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmBudgetDocList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 415);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "frmBudgetDocList";
            this.toolTipController.SetSuperTip(this, null);
            this.Text = "Журнал заявок";
            this.toolTipController.SetToolTipIconType(this, DevExpress.Utils.ToolTipIconType.Information);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBudgetDocList_FormClosing);
            this.Load += new System.EventHandler(this.frmBudgetDocList_Load);
            this.Shown += new System.EventHandler(this.frmBudgetDocList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabControlDocList)).EndInit();
            this.TabControlDocList.ResumeLayout(false);
            this.tabPageDocWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocWork)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsBudgetDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocWorked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocNotActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.tabPageDocWorked.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocWorked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocWorked)).EndInit();
            this.tabPageDocNotActive.ResumeLayout(false);
            this.tableLPFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFind)).EndInit();
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupDateType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocNotActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocNotActive)).EndInit();
            this.tabPageError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocErr)).EndInit();
            this.contextMenuNoteType.ResumeLayout(false);
            this.contextMenuComment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barBtnRefres;
        private DevExpress.XtraBars.BarButtonItem barBtnNewDoc;
        private DevExpress.XtraBars.BarButtonItem barBtnEditDoc;
        private DevExpress.XtraBars.BarButtonItem barBtnCopyDoc;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraBars.BarButtonItem barBtnDeleteDoc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraTab.XtraTabControl TabControlDocList;
        private DevExpress.XtraTab.XtraTabPage tabPageDocWork;
        private DevExpress.XtraTab.XtraTabPage tabPageDocWorked;
        private DevExpress.XtraTab.XtraTabPage tabPageDocNotActive;
        private DevExpress.XtraGrid.GridControl gridDocWork;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDocWork;
        private DevExpress.XtraGrid.GridControl gridDocWorked;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDocWorked;
        private DevExpress.XtraGrid.GridControl gridDocNotActive;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDocNotActive;
        private System.Data.DataSet dsBudgetDoc;
        private System.Data.DataTable dtDocWork;
        private System.Data.DataTable dtDocWorked;
        private System.Data.DataTable dtDocNotActive;
        private System.Data.DataColumn A_BUDGETDOC_GUID_ID;
        private System.Data.DataColumn A_CREATEDUSER_NAME;
        private System.Data.DataColumn A_DOCDATE;
        private System.Data.DataColumn A_BUDGETDEP_NAME;
        private System.Data.DataColumn A_DOCOBJECTIVE;
        private System.Data.DataColumn A_DOCMONEY;
        private System.Data.DataColumn A_DEBITARTICLE_NAME;
        private System.Data.DataColumn A_COMPANY_NAME;
        private System.Data.DataColumn A_BUDGETDOCSTATE_NAME;
        private System.Data.DataColumn B_BUDGETDOC_GUID_ID;
        private System.Data.DataColumn B_CREATEDUSER_NAME;
        private System.Data.DataColumn B_DOCDATE;
        private System.Data.DataColumn B_BUDGETDEP_NAME;
        private System.Data.DataColumn B_DOCOBJECTIVE;
        private System.Data.DataColumn B_DOCMONEY;
        private System.Data.DataColumn B_DEBITARTICLE_NAME;
        private System.Data.DataColumn B_COMPANY_NAME;
        private System.Data.DataColumn B_BUDGETDOCSTATE_NAME;
        private System.Data.DataColumn A_IMAGE_ID;
        private System.Data.DataColumn B_IMAGE_ID;
        private System.Data.DataColumn C_BUDGETDOC_GUID_ID;
        private System.Data.DataColumn C_CREATEDUSER_NAME;
        private System.Data.DataColumn C_DOCDATE;
        private System.Data.DataColumn C_BUDGETDEP_NAME;
        private System.Data.DataColumn C_DOCOBJECTIVE;
        private System.Data.DataColumn C_DOCMONEY;
        private System.Data.DataColumn C_DEBITARTICLE_NAME;
        private System.Data.DataColumn C_COMPANY_NAME;
        private System.Data.DataColumn C_BUDGETDOCSTATE_NAME;
        private System.Data.DataColumn C_IMAGE_ID;
        private System.Data.DataColumn A_DOCACTIVE;
        private System.Data.DataColumn B_DOCACTIVE;
        private System.Data.DataColumn C_DOCACTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colA_BUDGETDOC_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colA_CREATEDUSER_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colA_DOCDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colA_BUDGETDEP_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colA_DOCOBJECTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colA_DOCMONEY;
        private DevExpress.XtraGrid.Columns.GridColumn colA_DEBITARTICLE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colA_COMPANY_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colA_BUDGETDOCSTATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colA_IMAGE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_BUDGETDOC_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_CREATEDUSER_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_CREATEDUSER_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colB_DOCDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colB_BUDGETDEP_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_BUDGETDEP_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colB_DOCOBJECTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colB_DOCMONEY;
        private DevExpress.XtraGrid.Columns.GridColumn colB_BUDGETITEM_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_DEBITARTICLE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colB_COMPANY_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_COMPANY_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colB_BUDGETDOCSTATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colB_BUDGETDOCSTATE_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_IMAGE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_BUDGETDOC_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_CREATEDUSER_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_CREATEDUSER_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DOCDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colC_BUDGETDEP_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_BUDGETDEP_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DOCOBJECTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DOCMONEY;
        private DevExpress.XtraGrid.Columns.GridColumn colC_BUDGETITEM_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DEBITARTICLE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_COMPANY_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_COMPANY_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_BUDGETDOCSTATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_BUDGETDOCSTATE_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colС_IMAGE_ID;
        private DevExpress.XtraTab.XtraTabPage tabPageError;
        private System.Data.DataTable dtDocError;
        private System.Data.DataColumn E_BUDGETDOC_GUID_ID;
        private System.Data.DataColumn E_CREATEDUSER_NAME;
        private System.Data.DataColumn E_DOCDATE;
        private System.Data.DataColumn E_BUDGETDEP_NAME;
        private System.Data.DataColumn E_DOCOBJECTIVE;
        private System.Data.DataColumn E_DOCMONEY;
        private System.Data.DataColumn E_DEBITARTICLE_NAME;
        private System.Data.DataColumn E_COMPANY_NAME;
        private System.Data.DataColumn E_BUDGETDOCSTATE_NAME;
        private System.Data.DataColumn E_IMAGE_ID;
        private System.Data.DataColumn E_DOCACTIVE;
        private DevExpress.XtraGrid.GridControl gridDocErr;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDocErr;
        private DevExpress.XtraGrid.Columns.GridColumn colE_BUDGETDOC_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colE_CREATEDUSER_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colE_CREATEDUSER_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colE_DOCDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colE_BUDGETDEP_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colE_BUDGETDEP_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colE_DOCOBJECTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colE_DOCMONEY;
        private DevExpress.XtraGrid.Columns.GridColumn colE_BUDGETITEM_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colE_DEBITARTICLE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colE_COMPANY_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colE_COMPANY_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colE_BUDGETDOCSTATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colE_BUDGETDOCSTATE_GUID_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colE_IMAGE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colE_DOCACTIVE;
        private System.Data.DataColumn A_RECIPIENT;
        private System.Data.DataColumn B_RECIPIENT;
        private System.Data.DataColumn C_RECIPIENT;
        private System.Data.DataColumn E_RECIPIENT;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mitemTrnList;
        private System.Windows.Forms.ToolStripMenuItem mitemRefresh;
        private System.Windows.Forms.ToolStripMenuItem mitemNewBudgetDoc;
        private System.Windows.Forms.ToolStripMenuItem mitemCopyBudgetDoc;
        private System.Windows.Forms.ToolStripMenuItem mitemDeleteBudgetDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Data.DataColumn A_IMAGETYPE_ID;
        private System.Data.DataColumn B_IMAGETYPE_ID;
        private System.Data.DataColumn C_IMAGETYPE_ID;
        private System.Data.DataColumn E_IMAGETYPE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colA_IMAGETYPE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_IMAGETYPE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_IMAGETYPE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colE_IMAGETYPE_ID;
        private System.Data.DataColumn A_BUDGETDOCTYPE_NAME;
        private System.Data.DataColumn B_BUDGETDOCTYPE_NAME;
        private System.Data.DataColumn C_BUDGETDOCTYPE_NAME;
        private System.Data.DataColumn E_BUDGETDOCTYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colA_BUDGETDOCTYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colB_BUDGETDOCTYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_BUDGETDOCTYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colE_BUDGETDOCTYPE_NAME;
        private System.Windows.Forms.ToolStripMenuItem mitemDocStateList;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraBars.BarButtonItem barBtnAutoRefresh;
        private System.Data.DataColumn A_DATESTATE;
        private System.Data.DataColumn B_DATESTATE;
        private System.Data.DataColumn C_DATESTATE;
        private System.Data.DataColumn E_DATESTATE;
        private DevExpress.XtraGrid.Columns.GridColumn colA_DATESTATE;
        private DevExpress.XtraGrid.Columns.GridColumn colB_DATESTATE;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DATESTATE;
        private System.Data.DataColumn A_ATTACH;
        private System.Data.DataColumn B_ATTACH;
        private System.Data.DataColumn C_ATTACH;
        private System.Data.DataColumn E_ATTACH;
        private DevExpress.XtraGrid.Columns.GridColumn colA_ATTACH;
        private DevExpress.XtraGrid.Columns.GridColumn colB_ATTACH;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ATTACH;
        private System.Windows.Forms.TableLayoutPanel tableLPFind;
        private DevExpress.XtraEditors.PanelControl pnlFind;
        private DevExpress.XtraEditors.DateEdit dtEndDate;
        private DevExpress.XtraEditors.DateEdit dtBeginDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraGrid.Columns.GridColumn colA_RECIPIENT;
        private DevExpress.XtraGrid.Columns.GridColumn colB_RECIPIENT;
        private DevExpress.XtraGrid.Columns.GridColumn colC_RECIPIENT;
        private System.Data.DataColumn A_CURRENCY;
        private System.Data.DataColumn B_CURRENCY;
        private System.Data.DataColumn C_CURRENCY;
        private System.Data.DataColumn E_CURRENCY;
        private DevExpress.XtraGrid.Columns.GridColumn colA_CURRENCY;
        private DevExpress.XtraGrid.Columns.GridColumn colB_CURRENCY;
        private DevExpress.XtraGrid.Columns.GridColumn colC_CURRENCY;
        private System.Data.DataColumn C_DOCMONEYAGREE;
        private System.Data.DataColumn C_ACCTRNSUM;
        private System.Data.DataColumn C_SALDOTRN;
        private System.Data.DataColumn A_DOCMONEYAGREE;
        private System.Data.DataColumn A_ACCTRNSUM;
        private System.Data.DataColumn A_SALDOTRN;
        private System.Data.DataColumn E_DOCMONEYAGREE;
        private System.Data.DataColumn E_ACCTRNSUM;
        private System.Data.DataColumn E_SALDOTRN;
        private DevExpress.XtraGrid.Columns.GridColumn colA_DOCMONEYAGREE;
        private DevExpress.XtraGrid.Columns.GridColumn colA_ACCTRNSUM;
        private DevExpress.XtraGrid.Columns.GridColumn colA_SALDOTRN;
        private System.Data.DataColumn B_DOCMONEYAGREE;
        private System.Data.DataColumn B_ACCTRNSUM;
        private System.Data.DataColumn B_SALDOTRN;
        private DevExpress.XtraGrid.Columns.GridColumn colB_DOCMONEYAGREE;
        private DevExpress.XtraGrid.Columns.GridColumn colB_ACCTRNSUM;
        private DevExpress.XtraGrid.Columns.GridColumn colB_SALDOTRN;
        private DevExpress.XtraGrid.Columns.GridColumn colC_DOCMONEYAGREE;
        private DevExpress.XtraGrid.Columns.GridColumn colC_ACCTRNSUM;
        private DevExpress.XtraGrid.Columns.GridColumn colC_SALDOTRN;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Data.DataColumn A_NOTETYPE;
        private System.Data.DataColumn A_NOTETYPE_PREV;
        private System.Data.DataColumn B_NOTETYPE;
        private System.Data.DataColumn B_NOTETYPE_PREV;
        private System.Data.DataColumn C_NOTETYPE;
        private System.Data.DataColumn C_NOTETYPE_PREV;
        private System.Data.DataColumn E_NOTETYPE;
        private System.Data.DataColumn E_NOTETYPE_PREV;
        private DevExpress.XtraGrid.Columns.GridColumn colA_NOTETYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colB_NOTETYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NOTETYPE;
        private System.Windows.Forms.ContextMenuStrip contextMenuNoteType;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private DevExpress.XtraGrid.Columns.GridColumn colA_NOTETYPE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_NOTETYPE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NOTETYPE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colA_NOTETYPE_PREVID;
        private DevExpress.XtraGrid.Columns.GridColumn colB_NOTETYPE_PREVID;
        private DevExpress.XtraGrid.Columns.GridColumn colC_NOTETYPE_PREVID;
        private System.Data.DataColumn A_USERCOMMENT;
        private System.Data.DataColumn B_USERCOMMENT;
        private System.Data.DataColumn C_USERCOMMENT;
        private System.Data.DataColumn E_USERCOMMENT;
        private DevExpress.XtraGrid.Columns.GridColumn colA_COMMENT;
        private DevExpress.XtraGrid.Columns.GridColumn colA_COMMENTTEXT;
        private DevExpress.XtraGrid.Columns.GridColumn colB_COMMENT;
        private DevExpress.XtraGrid.Columns.GridColumn colB_COMMENTTEXT;
        private DevExpress.XtraGrid.Columns.GridColumn colC_COMMENT;
        private DevExpress.XtraGrid.Columns.GridColumn colC_COMMENTTEXT;
        private System.Windows.Forms.ContextMenuStrip contextMenuComment;
        private System.Windows.Forms.ToolStripMenuItem mitemAddComment;
        private System.Windows.Forms.ToolStripMenuItem mitemDeleteComment;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem lblStatusBar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem mitemExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mitemChangePaymentDate;
        private System.Windows.Forms.ToolStripMenuItem mitemDePay;
        private DevExpress.XtraGrid.Columns.GridColumn colC_PAYMENTTYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colE_PAYMENTTYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colB_PAYMENTTYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colA_PAYMENTTYPE_NAME;
        private System.Data.DataColumn A_PAYMENTTYPE_NAME;
        private System.Data.DataColumn B_PAYMENTTYPE_NAME;
        private System.Data.DataColumn C_PAYMENTTYPE_NAME;
        private System.Data.DataColumn E_PAYMENTTYPE_NAME;
        private DevExpress.XtraEditors.RadioGroup radioGroupDateType;
        private System.Data.DataColumn A_BUDGETEXPENSETYPE_NAME;
        private System.Data.DataColumn B_BUDGETEXPENSETYPE_NAME;
        private System.Data.DataColumn C_BUDGETEXPENSETYPE_NAME;
        private System.Data.DataColumn E_BUDGETEXPENSETYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colA_BUDGETEXPENSETYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colB_BUDGETEXPENSETYPE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colC_BUDGETEXPENSETYPE_NAME;
        private System.Windows.Forms.ToolStripMenuItem mitemChangeDocType;
        private System.Windows.Forms.ToolStripMenuItem mitemChange;
        private System.Windows.Forms.ToolStripMenuItem mitemChangeCompany;
        private System.Windows.Forms.ToolStripMenuItem mitemChangePaymentType;
    }
}