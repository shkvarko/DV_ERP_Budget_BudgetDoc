namespace ErpBudgetBudgetDoc
{
    partial class frmBudgetDocListManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBudgetDocListManage));
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treelistBudgetDoc = new DevExpress.XtraTreeList.TreeList();
            this.colOwnerUser = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBudgetDocDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDepartament = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMoney = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCurrency = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMoneyBudget = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBudgetItem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCompany = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colBudgetDocState = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mitemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemCopyBudgetDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDeleteBudgetDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemBackMoney = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemTrnList = new System.Windows.Forms.ToolStripMenuItem();
            this.mitemDocStateList = new System.Windows.Forms.ToolStripMenuItem();
            this.repItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repItemCalcEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.repItemCheckDontChange = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grCntrlFind = new DevExpress.XtraEditors.GroupControl();
            this.cboxCompany = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.cboxOwnerUser = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboxDebitArticle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboxDepartament = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtDocDateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dtDocDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabCntrlProperties = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageProperties = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListDocProperties = new DevExpress.XtraTreeList.TreeList();
            this.colDocPropertie = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDocPropertieValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.propertiesView = new DevExpress.XtraLayout.Customization.PropertiesView();
            this.tabPageAccTrn = new DevExpress.XtraTab.XtraTabPage();
            this.treeListTrn = new DevExpress.XtraTreeList.TreeList();
            this.colTrnDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnMoney = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnCurrency = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnOper = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnUser = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnDescrpn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tabPageBudgetDocState = new DevExpress.XtraTab.XtraTabPage();
            this.treeListDocState = new DevExpress.XtraTreeList.TreeList();
            this.colDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDocState = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUser = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tabPageRoute = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListRoute = new DevExpress.XtraTreeList.TreeList();
            this.colRouteGroup = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRouteAction = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRouteCheck = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repItemRouteCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grCtrlPointProperties = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkPointShow = new DevExpress.XtraEditors.CheckEdit();
            this.checkPointExit = new DevExpress.XtraEditors.CheckEdit();
            this.cboxPointUser = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboxPointStateOut = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboxPointStateEvent = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboxPointStateIn = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboxPointGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.checkPointEnter = new DevExpress.XtraEditors.CheckEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditRoute = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treelistBudgetDoc)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCalcEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckDontChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCntrlFind)).BeginInit();
            this.grCntrlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxOwnerUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxDebitArticle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxDepartament.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocDateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocDateBegin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocDateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCntrlProperties)).BeginInit();
            this.tabCntrlProperties.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDocProperties)).BeginInit();
            this.tabPageAccTrn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListTrn)).BeginInit();
            this.tabPageBudgetDocState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDocState)).BeginInit();
            this.tabPageRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListRoute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemRouteCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlPointProperties)).BeginInit();
            this.grCtrlPointProperties.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPointShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPointExit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointStateOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointStateEvent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointStateIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPointEnter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
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
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl.Horizontal = false;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerControl.Panel1.MinSize = 100;
            this.splitContainerControl.Panel1.Text = "splitContainerControl1_Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.tabCntrlProperties);
            this.splitContainerControl.Panel2.MinSize = 200;
            this.splitContainerControl.Panel2.ShowCaption = true;
            this.splitContainerControl.Panel2.Text = "Сойства:";
            this.splitContainerControl.Size = new System.Drawing.Size(645, 546);
            this.splitContainerControl.SplitterPosition = 225;
            this.toolTipController.SetSuperTip(this.splitContainerControl, null);
            this.splitContainerControl.TabIndex = 4;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.treelistBudgetDoc, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grCntrlFind, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(641, 221);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // treelistBudgetDoc
            // 
            this.treelistBudgetDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treelistBudgetDoc.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colOwnerUser,
            this.colBudgetDocDate,
            this.colDepartament,
            this.colMoney,
            this.colCurrency,
            this.colMoneyBudget,
            this.colBudgetItem,
            this.colCompany,
            this.colBudgetDocState});
            this.treelistBudgetDoc.ContextMenuStrip = this.contextMenuStrip;
            this.treelistBudgetDoc.Location = new System.Drawing.Point(3, 121);
            this.treelistBudgetDoc.Name = "treelistBudgetDoc";
            this.treelistBudgetDoc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemCheckEdit,
            this.repItemCalcEdit,
            this.repItemCheckDontChange});
            this.treelistBudgetDoc.Size = new System.Drawing.Size(635, 97);
            this.treelistBudgetDoc.TabIndex = 12;
            this.treelistBudgetDoc.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treelistBudgetDoc_FocusedNodeChanged);
            // 
            // colOwnerUser
            // 
            this.colOwnerUser.Caption = "Инициатор";
            this.colOwnerUser.FieldName = "Инициатор";
            this.colOwnerUser.MinWidth = 40;
            this.colOwnerUser.Name = "colOwnerUser";
            this.colOwnerUser.OptionsColumn.AllowEdit = false;
            this.colOwnerUser.OptionsColumn.AllowFocus = false;
            this.colOwnerUser.OptionsColumn.ReadOnly = true;
            this.colOwnerUser.Visible = true;
            this.colOwnerUser.VisibleIndex = 0;
            // 
            // colBudgetDocDate
            // 
            this.colBudgetDocDate.Caption = "Дата заявки";
            this.colBudgetDocDate.FieldName = "Дата заявки";
            this.colBudgetDocDate.Name = "colBudgetDocDate";
            this.colBudgetDocDate.OptionsColumn.AllowEdit = false;
            this.colBudgetDocDate.OptionsColumn.AllowFocus = false;
            this.colBudgetDocDate.OptionsColumn.ReadOnly = true;
            this.colBudgetDocDate.Visible = true;
            this.colBudgetDocDate.VisibleIndex = 1;
            // 
            // colDepartament
            // 
            this.colDepartament.AppearanceCell.Options.UseTextOptions = true;
            this.colDepartament.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDepartament.Caption = "Служба";
            this.colDepartament.FieldName = "Служба";
            this.colDepartament.Name = "colDepartament";
            this.colDepartament.OptionsColumn.AllowEdit = false;
            this.colDepartament.OptionsColumn.AllowFocus = false;
            this.colDepartament.OptionsColumn.ReadOnly = true;
            this.colDepartament.Visible = true;
            this.colDepartament.VisibleIndex = 2;
            // 
            // colMoney
            // 
            this.colMoney.Caption = "Сумма";
            this.colMoney.FieldName = "Сумма";
            this.colMoney.Format.FormatString = "### ### ##0.00";
            this.colMoney.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMoney.Name = "colMoney";
            this.colMoney.OptionsColumn.AllowEdit = false;
            this.colMoney.OptionsColumn.AllowFocus = false;
            this.colMoney.OptionsColumn.ReadOnly = true;
            this.colMoney.Visible = true;
            this.colMoney.VisibleIndex = 3;
            this.colMoney.Width = 80;
            // 
            // colCurrency
            // 
            this.colCurrency.Caption = "Валюта";
            this.colCurrency.FieldName = "Валюта";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.OptionsColumn.AllowEdit = false;
            this.colCurrency.OptionsColumn.AllowFocus = false;
            this.colCurrency.OptionsColumn.ReadOnly = true;
            this.colCurrency.Visible = true;
            this.colCurrency.VisibleIndex = 4;
            // 
            // colMoneyBudget
            // 
            this.colMoneyBudget.AppearanceCell.Options.UseTextOptions = true;
            this.colMoneyBudget.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMoneyBudget.Caption = "Сумма, EUR";
            this.colMoneyBudget.FieldName = "Сумма, EUR";
            this.colMoneyBudget.Format.FormatString = "### ### ##0.00";
            this.colMoneyBudget.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMoneyBudget.Name = "colMoneyBudget";
            this.colMoneyBudget.OptionsColumn.AllowEdit = false;
            this.colMoneyBudget.OptionsColumn.AllowFocus = false;
            this.colMoneyBudget.OptionsColumn.ReadOnly = true;
            this.colMoneyBudget.Visible = true;
            this.colMoneyBudget.VisibleIndex = 5;
            // 
            // colBudgetItem
            // 
            this.colBudgetItem.Caption = "Статья расходов";
            this.colBudgetItem.FieldName = "Статья расходов";
            this.colBudgetItem.Name = "colBudgetItem";
            this.colBudgetItem.OptionsColumn.AllowEdit = false;
            this.colBudgetItem.OptionsColumn.AllowFocus = false;
            this.colBudgetItem.OptionsColumn.ReadOnly = true;
            this.colBudgetItem.Visible = true;
            this.colBudgetItem.VisibleIndex = 6;
            // 
            // colCompany
            // 
            this.colCompany.Caption = "Компания";
            this.colCompany.FieldName = "Компания";
            this.colCompany.Name = "colCompany";
            this.colCompany.OptionsColumn.AllowEdit = false;
            this.colCompany.OptionsColumn.AllowFocus = false;
            this.colCompany.OptionsColumn.ReadOnly = true;
            this.colCompany.Visible = true;
            this.colCompany.VisibleIndex = 7;
            // 
            // colBudgetDocState
            // 
            this.colBudgetDocState.Caption = "Состояние";
            this.colBudgetDocState.FieldName = "Состояние";
            this.colBudgetDocState.Name = "colBudgetDocState";
            this.colBudgetDocState.OptionsColumn.AllowEdit = false;
            this.colBudgetDocState.OptionsColumn.AllowFocus = false;
            this.colBudgetDocState.OptionsColumn.ReadOnly = true;
            this.colBudgetDocState.Visible = true;
            this.colBudgetDocState.VisibleIndex = 8;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemRefresh,
            this.mitemDetail,
            this.mitemCopyBudgetDoc,
            this.mitemDeleteBudgetDoc,
            this.mitemBackMoney,
            this.mitemTrnList,
            this.mitemDocStateList});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(188, 158);
            this.toolTipController.SetSuperTip(this.contextMenuStrip, null);
            // 
            // mitemRefresh
            // 
            this.mitemRefresh.Name = "mitemRefresh";
            this.mitemRefresh.Size = new System.Drawing.Size(187, 22);
            this.mitemRefresh.Text = "Обновить";
            // 
            // mitemDetail
            // 
            this.mitemDetail.Name = "mitemDetail";
            this.mitemDetail.Size = new System.Drawing.Size(187, 22);
            this.mitemDetail.Text = "Подробнее";
            this.mitemDetail.Click += new System.EventHandler(this.mitemDetail_Click);
            // 
            // mitemCopyBudgetDoc
            // 
            this.mitemCopyBudgetDoc.Name = "mitemCopyBudgetDoc";
            this.mitemCopyBudgetDoc.Size = new System.Drawing.Size(187, 22);
            this.mitemCopyBudgetDoc.Text = "Копировать заявку";
            this.mitemCopyBudgetDoc.Visible = false;
            // 
            // mitemDeleteBudgetDoc
            // 
            this.mitemDeleteBudgetDoc.Name = "mitemDeleteBudgetDoc";
            this.mitemDeleteBudgetDoc.Size = new System.Drawing.Size(187, 22);
            this.mitemDeleteBudgetDoc.Text = "Удалить заявку";
            this.mitemDeleteBudgetDoc.Visible = false;
            // 
            // mitemBackMoney
            // 
            this.mitemBackMoney.Name = "mitemBackMoney";
            this.mitemBackMoney.Size = new System.Drawing.Size(187, 22);
            this.mitemBackMoney.Text = "Возврат средств";
            this.mitemBackMoney.Visible = false;
            // 
            // mitemTrnList
            // 
            this.mitemTrnList.Name = "mitemTrnList";
            this.mitemTrnList.Size = new System.Drawing.Size(187, 22);
            this.mitemTrnList.Text = "Журнал транзакций";
            this.mitemTrnList.Visible = false;
            // 
            // mitemDocStateList
            // 
            this.mitemDocStateList.Name = "mitemDocStateList";
            this.mitemDocStateList.Size = new System.Drawing.Size(187, 22);
            this.mitemDocStateList.Text = "Журнал состояний";
            this.mitemDocStateList.Visible = false;
            // 
            // repItemCheckEdit
            // 
            this.repItemCheckEdit.AutoHeight = false;
            this.repItemCheckEdit.Name = "repItemCheckEdit";
            // 
            // repItemCalcEdit
            // 
            this.repItemCalcEdit.Appearance.Options.UseTextOptions = true;
            this.repItemCalcEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repItemCalcEdit.AutoHeight = false;
            this.repItemCalcEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemCalcEdit.Name = "repItemCalcEdit";
            // 
            // repItemCheckDontChange
            // 
            this.repItemCheckDontChange.AutoHeight = false;
            this.repItemCheckDontChange.Name = "repItemCheckDontChange";
            // 
            // grCntrlFind
            // 
            this.grCntrlFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grCntrlFind.Controls.Add(this.cboxCompany);
            this.grCntrlFind.Controls.Add(this.labelControl5);
            this.grCntrlFind.Controls.Add(this.btnSearch);
            this.grCntrlFind.Controls.Add(this.cboxOwnerUser);
            this.grCntrlFind.Controls.Add(this.labelControl4);
            this.grCntrlFind.Controls.Add(this.cboxDebitArticle);
            this.grCntrlFind.Controls.Add(this.labelControl3);
            this.grCntrlFind.Controls.Add(this.cboxDepartament);
            this.grCntrlFind.Controls.Add(this.labelControl2);
            this.grCntrlFind.Controls.Add(this.dtDocDateEnd);
            this.grCntrlFind.Controls.Add(this.dtDocDateBegin);
            this.grCntrlFind.Controls.Add(this.labelControl1);
            this.grCntrlFind.Location = new System.Drawing.Point(3, 3);
            this.grCntrlFind.Name = "grCntrlFind";
            this.grCntrlFind.Size = new System.Drawing.Size(635, 112);
            this.toolTipController.SetSuperTip(this.grCntrlFind, null);
            this.grCntrlFind.TabIndex = 0;
            this.grCntrlFind.Text = "Поиск";
            // 
            // cboxCompany
            // 
            this.cboxCompany.Location = new System.Drawing.Point(355, 59);
            this.cboxCompany.Name = "cboxCompany";
            this.cboxCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxCompany.Size = new System.Drawing.Size(180, 20);
            this.cboxCompany.TabIndex = 15;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(290, 62);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Фирма:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(553, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.ToolTip = "Поиск";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboxOwnerUser
            // 
            this.cboxOwnerUser.Location = new System.Drawing.Point(355, 30);
            this.cboxOwnerUser.Name = "cboxOwnerUser";
            this.cboxOwnerUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxOwnerUser.Size = new System.Drawing.Size(180, 20);
            this.cboxOwnerUser.TabIndex = 12;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(290, 33);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Инициатор:";
            // 
            // cboxDebitArticle
            // 
            this.cboxDebitArticle.Location = new System.Drawing.Point(81, 85);
            this.cboxDebitArticle.Name = "cboxDebitArticle";
            this.cboxDebitArticle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxDebitArticle.Size = new System.Drawing.Size(180, 20);
            this.cboxDebitArticle.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Статья:";
            // 
            // cboxDepartament
            // 
            this.cboxDepartament.Location = new System.Drawing.Point(81, 59);
            this.cboxDepartament.Name = "cboxDepartament";
            this.cboxDepartament.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxDepartament.Size = new System.Drawing.Size(180, 20);
            this.cboxDepartament.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Служба:";
            // 
            // dtDocDateEnd
            // 
            this.dtDocDateEnd.EditValue = null;
            this.dtDocDateEnd.Location = new System.Drawing.Point(174, 30);
            this.dtDocDateEnd.Name = "dtDocDateEnd";
            this.dtDocDateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDocDateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDocDateEnd.Size = new System.Drawing.Size(87, 20);
            this.dtDocDateEnd.TabIndex = 6;
            // 
            // dtDocDateBegin
            // 
            this.dtDocDateBegin.EditValue = null;
            this.dtDocDateBegin.Location = new System.Drawing.Point(81, 30);
            this.dtDocDateBegin.Name = "dtDocDateBegin";
            this.dtDocDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDocDateBegin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDocDateBegin.Size = new System.Drawing.Size(87, 20);
            this.dtDocDateBegin.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Дата заявки:";
            // 
            // tabCntrlProperties
            // 
            this.tabCntrlProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCntrlProperties.Location = new System.Drawing.Point(0, 0);
            this.tabCntrlProperties.Name = "tabCntrlProperties";
            this.tabCntrlProperties.SelectedTabPage = this.tabPageProperties;
            this.tabCntrlProperties.Size = new System.Drawing.Size(641, 293);
            this.tabCntrlProperties.TabIndex = 0;
            this.tabCntrlProperties.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageProperties,
            this.tabPageAccTrn,
            this.tabPageBudgetDocState,
            this.tabPageRoute});
            this.tabCntrlProperties.Text = "xtraTabControl1";
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.splitContainerControl1);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Size = new System.Drawing.Size(632, 262);
            this.tabPageProperties.Text = "Свойства";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeListDocProperties);
            this.splitContainerControl1.Panel1.MinSize = 100;
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.propertiesView);
            this.splitContainerControl1.Panel2.MinSize = 100;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(632, 262);
            this.splitContainerControl1.SplitterPosition = 245;
            this.toolTipController.SetSuperTip(this.splitContainerControl1, null);
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeListDocProperties
            // 
            this.treeListDocProperties.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.treeListDocProperties.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.treeListDocProperties.Appearance.Empty.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.treeListDocProperties.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.treeListDocProperties.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treeListDocProperties.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.EvenRow.Options.UseBorderColor = true;
            this.treeListDocProperties.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.treeListDocProperties.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.treeListDocProperties.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(171)))), ((int)(((byte)(177)))));
            this.treeListDocProperties.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treeListDocProperties.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.treeListDocProperties.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.treeListDocProperties.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treeListDocProperties.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.treeListDocProperties.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.treeListDocProperties.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.treeListDocProperties.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.GroupButton.Options.UseBorderColor = true;
            this.treeListDocProperties.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.treeListDocProperties.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.treeListDocProperties.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treeListDocProperties.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.treeListDocProperties.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.treeListDocProperties.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.treeListDocProperties.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treeListDocProperties.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeListDocProperties.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(211)))), ((int)(((byte)(215)))));
            this.treeListDocProperties.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.treeListDocProperties.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.treeListDocProperties.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.treeListDocProperties.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.treeListDocProperties.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treeListDocProperties.Appearance.OddRow.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.OddRow.Options.UseBorderColor = true;
            this.treeListDocProperties.Appearance.OddRow.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.treeListDocProperties.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.treeListDocProperties.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.treeListDocProperties.Appearance.Preview.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.Preview.Options.UseFont = true;
            this.treeListDocProperties.Appearance.Preview.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.treeListDocProperties.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treeListDocProperties.Appearance.Row.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.Row.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(201)))), ((int)(((byte)(207)))));
            this.treeListDocProperties.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.treeListDocProperties.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeListDocProperties.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.treeListDocProperties.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.treeListDocProperties.Appearance.VertLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.treeListDocProperties.Appearance.VertLine.Options.UseBackColor = true;
            this.treeListDocProperties.Appearance.VertLine.Options.UseBorderColor = true;
            this.treeListDocProperties.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDocPropertie,
            this.colDocPropertieValue});
            this.treeListDocProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDocProperties.Location = new System.Drawing.Point(0, 0);
            this.treeListDocProperties.Name = "treeListDocProperties";
            this.treeListDocProperties.OptionsView.EnableAppearanceEvenRow = true;
            this.treeListDocProperties.OptionsView.EnableAppearanceOddRow = true;
            this.treeListDocProperties.Size = new System.Drawing.Size(242, 258);
            this.treeListDocProperties.TabIndex = 0;
            this.treeListDocProperties.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListDocProperties_FocusedNodeChanged);
            // 
            // colDocPropertie
            // 
            this.colDocPropertie.Caption = "Свойства документа";
            this.colDocPropertie.FieldName = "Свойства документа";
            this.colDocPropertie.Name = "colDocPropertie";
            this.colDocPropertie.OptionsColumn.AllowEdit = false;
            this.colDocPropertie.OptionsColumn.AllowFocus = false;
            this.colDocPropertie.OptionsColumn.ReadOnly = true;
            this.colDocPropertie.Visible = true;
            this.colDocPropertie.VisibleIndex = 0;
            // 
            // colDocPropertieValue
            // 
            this.colDocPropertieValue.Caption = "Значение";
            this.colDocPropertieValue.FieldName = "Значение";
            this.colDocPropertieValue.Name = "colDocPropertieValue";
            this.colDocPropertieValue.OptionsColumn.ReadOnly = true;
            this.colDocPropertieValue.Visible = true;
            this.colDocPropertieValue.VisibleIndex = 1;
            // 
            // propertiesView
            // 
            this.propertiesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesView.Location = new System.Drawing.Point(0, 0);
            this.propertiesView.Name = "propertiesView";
            this.propertiesView.Size = new System.Drawing.Size(376, 258);
            this.toolTipController.SetSuperTip(this.propertiesView, null);
            this.propertiesView.TabIndex = 1;
            // 
            // tabPageAccTrn
            // 
            this.tabPageAccTrn.Controls.Add(this.treeListTrn);
            this.tabPageAccTrn.Name = "tabPageAccTrn";
            this.tabPageAccTrn.Size = new System.Drawing.Size(632, 262);
            this.tabPageAccTrn.Text = "Проводки";
            // 
            // treeListTrn
            // 
            this.treeListTrn.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTrnDate,
            this.colTrnMoney,
            this.colTrnCurrency,
            this.colTrnOper,
            this.colTrnUser,
            this.colTrnDescrpn});
            this.treeListTrn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListTrn.Location = new System.Drawing.Point(0, 0);
            this.treeListTrn.Name = "treeListTrn";
            this.treeListTrn.OptionsView.ShowSummaryFooter = true;
            this.treeListTrn.Size = new System.Drawing.Size(632, 262);
            this.treeListTrn.TabIndex = 5;
            // 
            // colTrnDate
            // 
            this.colTrnDate.Caption = "Дата";
            this.colTrnDate.FieldName = "Дата";
            this.colTrnDate.Name = "colTrnDate";
            this.colTrnDate.OptionsColumn.AllowEdit = false;
            this.colTrnDate.OptionsColumn.AllowFocus = false;
            this.colTrnDate.OptionsColumn.ReadOnly = true;
            this.colTrnDate.Visible = true;
            this.colTrnDate.VisibleIndex = 0;
            this.colTrnDate.Width = 139;
            // 
            // colTrnMoney
            // 
            this.colTrnMoney.AppearanceCell.Options.UseTextOptions = true;
            this.colTrnMoney.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTrnMoney.Caption = "Сумма";
            this.colTrnMoney.FieldName = "Сумма";
            this.colTrnMoney.Format.FormatString = "#### ### ##0.00";
            this.colTrnMoney.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTrnMoney.Name = "colTrnMoney";
            this.colTrnMoney.OptionsColumn.AllowEdit = false;
            this.colTrnMoney.OptionsColumn.AllowFocus = false;
            this.colTrnMoney.OptionsColumn.ReadOnly = true;
            this.colTrnMoney.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.colTrnMoney.SummaryFooterStrFormat = "{0:### ### ##0.00}";
            this.colTrnMoney.Visible = true;
            this.colTrnMoney.VisibleIndex = 1;
            this.colTrnMoney.Width = 103;
            // 
            // colTrnCurrency
            // 
            this.colTrnCurrency.AppearanceCell.Options.UseTextOptions = true;
            this.colTrnCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTrnCurrency.Caption = "Валюта";
            this.colTrnCurrency.FieldName = "Валюта";
            this.colTrnCurrency.Name = "colTrnCurrency";
            this.colTrnCurrency.OptionsColumn.AllowEdit = false;
            this.colTrnCurrency.OptionsColumn.AllowFocus = false;
            this.colTrnCurrency.OptionsColumn.ReadOnly = true;
            this.colTrnCurrency.Visible = true;
            this.colTrnCurrency.VisibleIndex = 2;
            this.colTrnCurrency.Width = 61;
            // 
            // colTrnOper
            // 
            this.colTrnOper.Caption = "Операция";
            this.colTrnOper.FieldName = "Операция";
            this.colTrnOper.Name = "colTrnOper";
            this.colTrnOper.OptionsColumn.AllowEdit = false;
            this.colTrnOper.OptionsColumn.AllowFocus = false;
            this.colTrnOper.OptionsColumn.ReadOnly = true;
            this.colTrnOper.Visible = true;
            this.colTrnOper.VisibleIndex = 3;
            this.colTrnOper.Width = 111;
            // 
            // colTrnUser
            // 
            this.colTrnUser.Caption = "Пользователь";
            this.colTrnUser.FieldName = "Пользователь";
            this.colTrnUser.Name = "colTrnUser";
            this.colTrnUser.OptionsColumn.AllowEdit = false;
            this.colTrnUser.OptionsColumn.AllowFocus = false;
            this.colTrnUser.OptionsColumn.ReadOnly = true;
            this.colTrnUser.Visible = true;
            this.colTrnUser.VisibleIndex = 4;
            this.colTrnUser.Width = 112;
            // 
            // colTrnDescrpn
            // 
            this.colTrnDescrpn.Caption = "Примечание";
            this.colTrnDescrpn.FieldName = "Примечание";
            this.colTrnDescrpn.Name = "colTrnDescrpn";
            this.colTrnDescrpn.OptionsColumn.AllowEdit = false;
            this.colTrnDescrpn.OptionsColumn.AllowFocus = false;
            this.colTrnDescrpn.OptionsColumn.ReadOnly = true;
            this.colTrnDescrpn.Width = 80;
            // 
            // tabPageBudgetDocState
            // 
            this.tabPageBudgetDocState.Controls.Add(this.treeListDocState);
            this.tabPageBudgetDocState.Name = "tabPageBudgetDocState";
            this.tabPageBudgetDocState.Size = new System.Drawing.Size(632, 262);
            this.tabPageBudgetDocState.Text = "Состояния";
            // 
            // treeListDocState
            // 
            this.treeListDocState.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDate,
            this.colDocState,
            this.colUser});
            this.treeListDocState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDocState.Location = new System.Drawing.Point(0, 0);
            this.treeListDocState.Name = "treeListDocState";
            this.treeListDocState.Size = new System.Drawing.Size(632, 262);
            this.treeListDocState.TabIndex = 5;
            // 
            // colDate
            // 
            this.colDate.Caption = "Дата";
            this.colDate.FieldName = "Дата";
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.OptionsColumn.AllowFocus = false;
            this.colDate.OptionsColumn.ReadOnly = true;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            this.colDate.Width = 116;
            // 
            // colDocState
            // 
            this.colDocState.Caption = "Состояние";
            this.colDocState.FieldName = "Состояние";
            this.colDocState.Name = "colDocState";
            this.colDocState.OptionsColumn.AllowEdit = false;
            this.colDocState.OptionsColumn.AllowFocus = false;
            this.colDocState.OptionsColumn.ReadOnly = true;
            this.colDocState.Visible = true;
            this.colDocState.VisibleIndex = 1;
            this.colDocState.Width = 128;
            // 
            // colUser
            // 
            this.colUser.Caption = "Пользователь";
            this.colUser.FieldName = "Пользователь";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.OptionsColumn.AllowFocus = false;
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 2;
            this.colUser.Width = 184;
            // 
            // tabPageRoute
            // 
            this.tabPageRoute.Controls.Add(this.splitContainerControl2);
            this.tabPageRoute.Name = "tabPageRoute";
            this.tabPageRoute.Size = new System.Drawing.Size(632, 262);
            this.tabPageRoute.Text = "Маршрут";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.treeListRoute);
            this.splitContainerControl2.Panel1.MinSize = 100;
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.grCtrlPointProperties);
            this.splitContainerControl2.Panel2.MinSize = 100;
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(632, 262);
            this.splitContainerControl2.SplitterPosition = 275;
            this.toolTipController.SetSuperTip(this.splitContainerControl2, null);
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // treeListRoute
            // 
            this.treeListRoute.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.treeListRoute.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.treeListRoute.Appearance.Empty.Options.UseBackColor = true;
            this.treeListRoute.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.treeListRoute.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.treeListRoute.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treeListRoute.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeListRoute.Appearance.EvenRow.Options.UseBorderColor = true;
            this.treeListRoute.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeListRoute.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.treeListRoute.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.treeListRoute.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeListRoute.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeListRoute.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(171)))), ((int)(((byte)(177)))));
            this.treeListRoute.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treeListRoute.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeListRoute.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeListRoute.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.treeListRoute.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.treeListRoute.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treeListRoute.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeListRoute.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.treeListRoute.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treeListRoute.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.treeListRoute.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.treeListRoute.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeListRoute.Appearance.GroupButton.Options.UseBorderColor = true;
            this.treeListRoute.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.treeListRoute.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.treeListRoute.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treeListRoute.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeListRoute.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.treeListRoute.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treeListRoute.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.treeListRoute.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.treeListRoute.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treeListRoute.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeListRoute.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeListRoute.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeListRoute.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(211)))), ((int)(((byte)(215)))));
            this.treeListRoute.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.treeListRoute.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeListRoute.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeListRoute.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.treeListRoute.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeListRoute.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.treeListRoute.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.treeListRoute.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treeListRoute.Appearance.OddRow.Options.UseBackColor = true;
            this.treeListRoute.Appearance.OddRow.Options.UseBorderColor = true;
            this.treeListRoute.Appearance.OddRow.Options.UseForeColor = true;
            this.treeListRoute.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.treeListRoute.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.treeListRoute.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.treeListRoute.Appearance.Preview.Options.UseBackColor = true;
            this.treeListRoute.Appearance.Preview.Options.UseFont = true;
            this.treeListRoute.Appearance.Preview.Options.UseForeColor = true;
            this.treeListRoute.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.treeListRoute.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treeListRoute.Appearance.Row.Options.UseBackColor = true;
            this.treeListRoute.Appearance.Row.Options.UseForeColor = true;
            this.treeListRoute.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(201)))), ((int)(((byte)(207)))));
            this.treeListRoute.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.treeListRoute.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeListRoute.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeListRoute.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.treeListRoute.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeListRoute.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.treeListRoute.Appearance.VertLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.treeListRoute.Appearance.VertLine.Options.UseBackColor = true;
            this.treeListRoute.Appearance.VertLine.Options.UseBorderColor = true;
            this.treeListRoute.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colRouteGroup,
            this.colRouteAction,
            this.colRouteCheck});
            this.treeListRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListRoute.Location = new System.Drawing.Point(0, 0);
            this.treeListRoute.Name = "treeListRoute";
            this.treeListRoute.OptionsView.EnableAppearanceEvenRow = true;
            this.treeListRoute.OptionsView.EnableAppearanceOddRow = true;
            this.treeListRoute.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemRouteCheck});
            this.treeListRoute.Size = new System.Drawing.Size(271, 258);
            this.treeListRoute.TabIndex = 1;
            this.treeListRoute.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListRoute_FocusedNodeChanged);
            // 
            // colRouteGroup
            // 
            this.colRouteGroup.Caption = "Точка маршрута";
            this.colRouteGroup.FieldName = "Точка маршрута";
            this.colRouteGroup.Name = "colRouteGroup";
            this.colRouteGroup.OptionsColumn.AllowEdit = false;
            this.colRouteGroup.OptionsColumn.AllowFocus = false;
            this.colRouteGroup.OptionsColumn.ReadOnly = true;
            this.colRouteGroup.Visible = true;
            this.colRouteGroup.VisibleIndex = 0;
            // 
            // colRouteAction
            // 
            this.colRouteAction.Caption = "Действие";
            this.colRouteAction.FieldName = "Действие";
            this.colRouteAction.Name = "colRouteAction";
            this.colRouteAction.OptionsColumn.AllowEdit = false;
            this.colRouteAction.OptionsColumn.AllowFocus = false;
            this.colRouteAction.OptionsColumn.ReadOnly = true;
            this.colRouteAction.Visible = true;
            this.colRouteAction.VisibleIndex = 1;
            // 
            // colRouteCheck
            // 
            this.colRouteCheck.Caption = "Пройдено";
            this.colRouteCheck.ColumnEdit = this.repItemRouteCheck;
            this.colRouteCheck.FieldName = "Пройдено";
            this.colRouteCheck.Name = "colRouteCheck";
            this.colRouteCheck.OptionsColumn.AllowEdit = false;
            this.colRouteCheck.OptionsColumn.AllowFocus = false;
            this.colRouteCheck.OptionsColumn.ReadOnly = true;
            this.colRouteCheck.Visible = true;
            this.colRouteCheck.VisibleIndex = 2;
            // 
            // repItemRouteCheck
            // 
            this.repItemRouteCheck.AutoHeight = false;
            this.repItemRouteCheck.Name = "repItemRouteCheck";
            // 
            // grCtrlPointProperties
            // 
            this.grCtrlPointProperties.Controls.Add(this.tableLayoutPanel2);
            this.grCtrlPointProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCtrlPointProperties.Location = new System.Drawing.Point(0, 0);
            this.grCtrlPointProperties.Name = "grCtrlPointProperties";
            this.grCtrlPointProperties.Size = new System.Drawing.Size(347, 258);
            this.toolTipController.SetSuperTip(this.grCtrlPointProperties, null);
            this.grCtrlPointProperties.TabIndex = 0;
            this.grCtrlPointProperties.Text = "Свойства";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.checkPointShow, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.checkPointExit, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.cboxPointUser, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cboxPointStateOut, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cboxPointStateEvent, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cboxPointStateIn, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cboxPointGroup, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl7, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelControl8, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelControl11, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.labelControl12, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.labelControl13, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.checkPointEnter, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnEditRoute, 0, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(343, 236);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel2, null);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // checkPointShow
            // 
            this.checkPointShow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkPointShow.Location = new System.Drawing.Point(121, 178);
            this.checkPointShow.Name = "checkPointShow";
            this.checkPointShow.Properties.Caption = "";
            this.checkPointShow.Size = new System.Drawing.Size(75, 19);
            this.checkPointShow.TabIndex = 23;
            // 
            // checkPointExit
            // 
            this.checkPointExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkPointExit.Location = new System.Drawing.Point(121, 153);
            this.checkPointExit.Name = "checkPointExit";
            this.checkPointExit.Properties.Caption = "";
            this.checkPointExit.Size = new System.Drawing.Size(75, 19);
            this.checkPointExit.TabIndex = 22;
            // 
            // cboxPointUser
            // 
            this.cboxPointUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxPointUser.Location = new System.Drawing.Point(121, 103);
            this.cboxPointUser.Name = "cboxPointUser";
            this.cboxPointUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxPointUser.Size = new System.Drawing.Size(219, 20);
            this.cboxPointUser.TabIndex = 20;
            // 
            // cboxPointStateOut
            // 
            this.cboxPointStateOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxPointStateOut.Location = new System.Drawing.Point(121, 78);
            this.cboxPointStateOut.Name = "cboxPointStateOut";
            this.cboxPointStateOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxPointStateOut.Size = new System.Drawing.Size(219, 20);
            this.cboxPointStateOut.TabIndex = 19;
            // 
            // cboxPointStateEvent
            // 
            this.cboxPointStateEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxPointStateEvent.Location = new System.Drawing.Point(121, 53);
            this.cboxPointStateEvent.Name = "cboxPointStateEvent";
            this.cboxPointStateEvent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxPointStateEvent.Size = new System.Drawing.Size(219, 20);
            this.cboxPointStateEvent.TabIndex = 18;
            // 
            // cboxPointStateIn
            // 
            this.cboxPointStateIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxPointStateIn.Location = new System.Drawing.Point(121, 28);
            this.cboxPointStateIn.Name = "cboxPointStateIn";
            this.cboxPointStateIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxPointStateIn.Size = new System.Drawing.Size(219, 20);
            this.cboxPointStateIn.TabIndex = 17;
            // 
            // cboxPointGroup
            // 
            this.cboxPointGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxPointGroup.Location = new System.Drawing.Point(121, 3);
            this.cboxPointGroup.Name = "cboxPointGroup";
            this.cboxPointGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxPointGroup.Size = new System.Drawing.Size(219, 20);
            this.cboxPointGroup.TabIndex = 16;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl10.Location = new System.Drawing.Point(3, 6);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(36, 13);
            this.labelControl10.TabIndex = 4;
            this.labelControl10.Text = "Группа";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl6.Location = new System.Drawing.Point(3, 31);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(110, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Начальное состояние";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl7.Location = new System.Drawing.Point(3, 56);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Действие";
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl9.Location = new System.Drawing.Point(3, 106);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(72, 13);
            this.labelControl9.TabIndex = 3;
            this.labelControl9.Text = "Пользователь";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl8.Location = new System.Drawing.Point(3, 81);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(104, 13);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Конечное состояние";
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl11.Location = new System.Drawing.Point(3, 131);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(37, 13);
            this.labelControl11.TabIndex = 5;
            this.labelControl11.Text = "Начало";
            // 
            // labelControl12
            // 
            this.labelControl12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl12.Location = new System.Drawing.Point(3, 156);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(33, 13);
            this.labelControl12.TabIndex = 6;
            this.labelControl12.Text = "Выход";
            // 
            // labelControl13
            // 
            this.labelControl13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelControl13.Location = new System.Drawing.Point(3, 181);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(62, 13);
            this.labelControl13.TabIndex = 7;
            this.labelControl13.Text = "Показывать";
            // 
            // checkPointEnter
            // 
            this.checkPointEnter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkPointEnter.Location = new System.Drawing.Point(121, 128);
            this.checkPointEnter.Name = "checkPointEnter";
            this.checkPointEnter.Properties.Caption = "";
            this.checkPointEnter.Size = new System.Drawing.Size(75, 19);
            this.checkPointEnter.TabIndex = 21;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnRefresh});
            this.barManager.MaxItemId = 1;
            this.barManager.ToolTipController = this.toolTipController;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRefresh)});
            this.bar1.Text = "Custom 1";
            // 
            // barBtnRefresh
            // 
            this.barBtnRefresh.Caption = "barBtnRefres";
            this.barBtnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnRefresh.Glyph")));
            this.barBtnRefresh.Hint = "Обновить список";
            this.barBtnRefresh.Id = 0;
            this.barBtnRefresh.Name = "barBtnRefresh";
            this.barBtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRefres_ItemClick);
            // 
            // btnEditRoute
            // 
            this.btnEditRoute.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEditRoute.Location = new System.Drawing.Point(3, 206);
            this.btnEditRoute.Name = "btnEditRoute";
            this.btnEditRoute.Size = new System.Drawing.Size(75, 23);
            this.btnEditRoute.TabIndex = 24;
            this.btnEditRoute.Text = "Изменить";
            this.btnEditRoute.ToolTip = "Изменить маршрут";
            // 
            // frmBudgetDocListManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 572);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmBudgetDocListManage";
            this.toolTipController.SetSuperTip(this, null);
            this.Text = "Журнал заявок";
            this.Load += new System.EventHandler(this.frmBudgetDocList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treelistBudgetDoc)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCalcEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCheckDontChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCntrlFind)).EndInit();
            this.grCntrlFind.ResumeLayout(false);
            this.grCntrlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxOwnerUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxDebitArticle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxDepartament.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocDateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocDateBegin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDocDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCntrlProperties)).EndInit();
            this.tabCntrlProperties.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDocProperties)).EndInit();
            this.tabPageAccTrn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListTrn)).EndInit();
            this.tabPageBudgetDocState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDocState)).EndInit();
            this.tabPageRoute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListRoute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemRouteCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlPointProperties)).EndInit();
            this.grCtrlPointProperties.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPointShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPointExit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointStateOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointStateEvent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointStateIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxPointGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkPointEnter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barBtnRefresh;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mitemRefresh;
        private System.Windows.Forms.ToolStripMenuItem mitemDetail;
        private System.Windows.Forms.ToolStripMenuItem mitemCopyBudgetDoc;
        private System.Windows.Forms.ToolStripMenuItem mitemDeleteBudgetDoc;
        private System.Windows.Forms.ToolStripMenuItem mitemBackMoney;
        private System.Windows.Forms.ToolStripMenuItem mitemTrnList;
        private System.Windows.Forms.ToolStripMenuItem mitemDocStateList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl grCntrlFind;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtDocDateEnd;
        private DevExpress.XtraEditors.DateEdit dtDocDateBegin;
        private DevExpress.XtraEditors.ComboBoxEdit cboxDebitArticle;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboxDepartament;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cboxOwnerUser;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraTreeList.TreeList treelistBudgetDoc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOwnerUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemCheckEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBudgetDocDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDepartament;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMoney;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repItemCalcEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMoneyBudget;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemCheckDontChange;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCurrency;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBudgetItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCompany;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colBudgetDocState;
        private DevExpress.XtraTab.XtraTabControl tabCntrlProperties;
        private DevExpress.XtraTab.XtraTabPage tabPageProperties;
        private DevExpress.XtraTab.XtraTabPage tabPageAccTrn;
        private DevExpress.XtraTab.XtraTabPage tabPageBudgetDocState;
        private DevExpress.XtraTab.XtraTabPage tabPageRoute;
        private DevExpress.XtraTreeList.TreeList treeListTrn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnMoney;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnCurrency;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnOper;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnDescrpn;
        private DevExpress.XtraTreeList.TreeList treeListDocState;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDocState;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUser;
        private DevExpress.XtraEditors.ComboBoxEdit cboxCompany;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeListDocProperties;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDocPropertie;
        private DevExpress.XtraLayout.Customization.PropertiesView propertiesView;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDocPropertieValue;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraTreeList.TreeList treeListRoute;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRouteGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRouteAction;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRouteCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repItemRouteCheck;
        private DevExpress.XtraEditors.GroupControl grCtrlPointProperties;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cboxPointStateIn;
        private DevExpress.XtraEditors.ComboBoxEdit cboxPointGroup;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.ComboBoxEdit cboxPointStateEvent;
        private DevExpress.XtraEditors.ComboBoxEdit cboxPointStateOut;
        private DevExpress.XtraEditors.ComboBoxEdit cboxPointUser;
        private DevExpress.XtraEditors.CheckEdit checkPointEnter;
        private DevExpress.XtraEditors.CheckEdit checkPointShow;
        private DevExpress.XtraEditors.CheckEdit checkPointExit;
        private DevExpress.XtraEditors.SimpleButton btnEditRoute;
    }
}