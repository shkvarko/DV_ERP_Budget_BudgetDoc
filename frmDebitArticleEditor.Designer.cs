namespace ErpBudgetBudgetDoc
{
    partial class frmDebitArticleEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebitArticleEditor));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.colDEBITARTICLE_GUID_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDEBITARTICLE_PARENT_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDEBITARTICLE_NUM = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colREADONLY = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDEBITARTICLE_MULTIBUDGETDEP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colJANUARY = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repItemPopupContainerEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.colFEBRUARY = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMARCH = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAPRIL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMAY = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colJUNE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colJULY = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAUGUST = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSEPTEMBER = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colOCTEMBER = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNOVEMBER = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDECEMBER = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSummary = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDebitArticleDscrpn = new DevExpress.XtraEditors.MemoEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDebitArticleName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebitArticleNum = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemPopupContainerEdit)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitArticleDscrpn.Properties)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitArticleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitArticleNum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.treeList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(496, 273);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // treeList
            // 
            this.treeList.AllowDrop = true;
            this.treeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.treeList.Appearance.Empty.Options.UseBackColor = true;
            this.treeList.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
            this.treeList.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treeList.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeList.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
            this.treeList.Appearance.OddRow.Options.UseBackColor = true;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDEBITARTICLE_GUID_ID,
            this.colDEBITARTICLE_PARENT_ID,
            this.colDEBITARTICLE_NUM,
            this.colREADONLY,
            this.colDEBITARTICLE_MULTIBUDGETDEP,
            this.colJANUARY,
            this.colFEBRUARY,
            this.colMARCH,
            this.colAPRIL,
            this.colMAY,
            this.colJUNE,
            this.colJULY,
            this.colAUGUST,
            this.colSEPTEMBER,
            this.colOCTEMBER,
            this.colNOVEMBER,
            this.colDECEMBER,
            this.colSummary});
            this.treeList.ImageIndexFieldName = "";
            this.treeList.KeyFieldName = "";
            this.treeList.Location = new System.Drawing.Point(3, 3);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.AutoChangeParent = false;
            this.treeList.OptionsBehavior.AutoNodeHeight = false;
            this.treeList.OptionsBehavior.DragNodes = true;
            this.treeList.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeList.OptionsBehavior.ShowEditorOnMouseUp = true;
            this.treeList.OptionsBehavior.SmartMouseHover = false;
            this.treeList.OptionsBehavior.UseTabKey = true;
            this.treeList.OptionsPrint.PrintImages = false;
            this.treeList.OptionsPrint.PrintPreview = true;
            this.treeList.OptionsPrint.PrintRowFooterSummary = true;
            this.treeList.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList.OptionsView.EnableAppearanceOddRow = true;
            this.treeList.ParentFieldName = "";
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemPopupContainerEdit});
            this.treeList.Size = new System.Drawing.Size(490, 127);
            this.treeList.TabIndex = 3;
            this.treeList.ToolTipController = this.toolTipController;
            this.treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            // 
            // colDEBITARTICLE_GUID_ID
            // 
            this.colDEBITARTICLE_GUID_ID.Caption = "УИ статьи расходов";
            this.colDEBITARTICLE_GUID_ID.FieldName = "УИ статьи расходов";
            this.colDEBITARTICLE_GUID_ID.Name = "colDEBITARTICLE_GUID_ID";
            this.colDEBITARTICLE_GUID_ID.OptionsColumn.AllowFocus = false;
            this.colDEBITARTICLE_GUID_ID.OptionsColumn.AllowMove = false;
            this.colDEBITARTICLE_GUID_ID.OptionsColumn.AllowSort = false;
            // 
            // colDEBITARTICLE_PARENT_ID
            // 
            this.colDEBITARTICLE_PARENT_ID.Caption = "УИ Родителя";
            this.colDEBITARTICLE_PARENT_ID.FieldName = "УИ Родителя";
            this.colDEBITARTICLE_PARENT_ID.Name = "colDEBITARTICLE_PARENT_ID";
            this.colDEBITARTICLE_PARENT_ID.OptionsColumn.AllowEdit = false;
            this.colDEBITARTICLE_PARENT_ID.OptionsColumn.ReadOnly = true;
            // 
            // colDEBITARTICLE_NUM
            // 
            this.colDEBITARTICLE_NUM.Caption = "№";
            this.colDEBITARTICLE_NUM.FieldName = "№";
            this.colDEBITARTICLE_NUM.MinWidth = 100;
            this.colDEBITARTICLE_NUM.Name = "colDEBITARTICLE_NUM";
            this.colDEBITARTICLE_NUM.OptionsColumn.AllowEdit = false;
            this.colDEBITARTICLE_NUM.OptionsColumn.AllowMove = false;
            this.colDEBITARTICLE_NUM.OptionsColumn.AllowSort = false;
            this.colDEBITARTICLE_NUM.OptionsColumn.ReadOnly = true;
            this.colDEBITARTICLE_NUM.Visible = true;
            this.colDEBITARTICLE_NUM.VisibleIndex = 0;
            this.colDEBITARTICLE_NUM.Width = 407;
            // 
            // colREADONLY
            // 
            this.colREADONLY.Caption = "READONLY";
            this.colREADONLY.FieldName = "READONLY";
            this.colREADONLY.Name = "colREADONLY";
            this.colREADONLY.OptionsColumn.AllowMove = false;
            this.colREADONLY.OptionsColumn.AllowSort = false;
            this.colREADONLY.Width = 39;
            // 
            // colDEBITARTICLE_MULTIBUDGETDEP
            // 
            this.colDEBITARTICLE_MULTIBUDGETDEP.Caption = "Мульти";
            this.colDEBITARTICLE_MULTIBUDGETDEP.FieldName = "Мульти";
            this.colDEBITARTICLE_MULTIBUDGETDEP.Name = "colDEBITARTICLE_MULTIBUDGETDEP";
            this.colDEBITARTICLE_MULTIBUDGETDEP.OptionsColumn.AllowFocus = false;
            this.colDEBITARTICLE_MULTIBUDGETDEP.OptionsColumn.AllowMove = false;
            this.colDEBITARTICLE_MULTIBUDGETDEP.OptionsColumn.AllowSort = false;
            // 
            // colJANUARY
            // 
            this.colJANUARY.AppearanceCell.Options.UseBackColor = true;
            this.colJANUARY.AppearanceCell.Options.UseForeColor = true;
            this.colJANUARY.AppearanceCell.Options.UseTextOptions = true;
            this.colJANUARY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colJANUARY.Caption = "Январь";
            this.colJANUARY.ColumnEdit = this.repItemPopupContainerEdit;
            this.colJANUARY.FieldName = "Январь";
            this.colJANUARY.MinWidth = 70;
            this.colJANUARY.Name = "colJANUARY";
            this.colJANUARY.OptionsColumn.AllowMove = false;
            this.colJANUARY.OptionsColumn.AllowSort = false;
            this.colJANUARY.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Custom;
            this.colJANUARY.RowFooterSummaryStrFormat = "";
            this.colJANUARY.SummaryFooterStrFormat = "";
            this.colJANUARY.Width = 70;
            // 
            // repItemPopupContainerEdit
            // 
            this.repItemPopupContainerEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemPopupContainerEdit.CloseOnLostFocus = false;
            this.repItemPopupContainerEdit.CloseOnOuterMouseClick = false;
            this.repItemPopupContainerEdit.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.NumPad0);
            this.repItemPopupContainerEdit.Name = "repItemPopupContainerEdit";
            this.repItemPopupContainerEdit.PopupSizeable = false;
            this.repItemPopupContainerEdit.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;
            // 
            // colFEBRUARY
            // 
            this.colFEBRUARY.AppearanceCell.Options.UseTextOptions = true;
            this.colFEBRUARY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFEBRUARY.Caption = "Февраль";
            this.colFEBRUARY.ColumnEdit = this.repItemPopupContainerEdit;
            this.colFEBRUARY.FieldName = "Февраль";
            this.colFEBRUARY.MinWidth = 70;
            this.colFEBRUARY.Name = "colFEBRUARY";
            this.colFEBRUARY.OptionsColumn.AllowMove = false;
            this.colFEBRUARY.OptionsColumn.AllowSort = false;
            this.colFEBRUARY.Width = 70;
            // 
            // colMARCH
            // 
            this.colMARCH.AppearanceCell.Options.UseTextOptions = true;
            this.colMARCH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMARCH.Caption = "Март";
            this.colMARCH.ColumnEdit = this.repItemPopupContainerEdit;
            this.colMARCH.FieldName = "Март";
            this.colMARCH.MinWidth = 70;
            this.colMARCH.Name = "colMARCH";
            this.colMARCH.OptionsColumn.AllowMove = false;
            this.colMARCH.OptionsColumn.AllowSort = false;
            this.colMARCH.Width = 70;
            // 
            // colAPRIL
            // 
            this.colAPRIL.AppearanceCell.Options.UseTextOptions = true;
            this.colAPRIL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAPRIL.Caption = "Апрель";
            this.colAPRIL.ColumnEdit = this.repItemPopupContainerEdit;
            this.colAPRIL.FieldName = "Апрель";
            this.colAPRIL.MinWidth = 70;
            this.colAPRIL.Name = "colAPRIL";
            this.colAPRIL.OptionsColumn.AllowMove = false;
            this.colAPRIL.OptionsColumn.AllowSort = false;
            this.colAPRIL.Width = 70;
            // 
            // colMAY
            // 
            this.colMAY.AppearanceCell.Options.UseTextOptions = true;
            this.colMAY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMAY.Caption = "Май";
            this.colMAY.ColumnEdit = this.repItemPopupContainerEdit;
            this.colMAY.FieldName = "Май";
            this.colMAY.MinWidth = 70;
            this.colMAY.Name = "colMAY";
            this.colMAY.OptionsColumn.AllowMove = false;
            this.colMAY.OptionsColumn.AllowSort = false;
            this.colMAY.Width = 70;
            // 
            // colJUNE
            // 
            this.colJUNE.AppearanceCell.Options.UseTextOptions = true;
            this.colJUNE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colJUNE.Caption = "Июнь";
            this.colJUNE.ColumnEdit = this.repItemPopupContainerEdit;
            this.colJUNE.FieldName = "Июнь";
            this.colJUNE.MinWidth = 70;
            this.colJUNE.Name = "colJUNE";
            this.colJUNE.OptionsColumn.AllowMove = false;
            this.colJUNE.OptionsColumn.AllowSort = false;
            this.colJUNE.Width = 70;
            // 
            // colJULY
            // 
            this.colJULY.AppearanceCell.Options.UseTextOptions = true;
            this.colJULY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colJULY.Caption = "Июль";
            this.colJULY.ColumnEdit = this.repItemPopupContainerEdit;
            this.colJULY.FieldName = "Июль";
            this.colJULY.MinWidth = 70;
            this.colJULY.Name = "colJULY";
            this.colJULY.OptionsColumn.AllowMove = false;
            this.colJULY.OptionsColumn.AllowSort = false;
            this.colJULY.Width = 70;
            // 
            // colAUGUST
            // 
            this.colAUGUST.AppearanceCell.Options.UseTextOptions = true;
            this.colAUGUST.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAUGUST.Caption = "Август";
            this.colAUGUST.ColumnEdit = this.repItemPopupContainerEdit;
            this.colAUGUST.FieldName = "Август";
            this.colAUGUST.MinWidth = 70;
            this.colAUGUST.Name = "colAUGUST";
            this.colAUGUST.OptionsColumn.AllowMove = false;
            this.colAUGUST.OptionsColumn.AllowSort = false;
            this.colAUGUST.Width = 70;
            // 
            // colSEPTEMBER
            // 
            this.colSEPTEMBER.AppearanceCell.Options.UseTextOptions = true;
            this.colSEPTEMBER.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSEPTEMBER.Caption = "Сентябрь";
            this.colSEPTEMBER.ColumnEdit = this.repItemPopupContainerEdit;
            this.colSEPTEMBER.FieldName = "Сентябрь";
            this.colSEPTEMBER.MinWidth = 70;
            this.colSEPTEMBER.Name = "colSEPTEMBER";
            this.colSEPTEMBER.OptionsColumn.AllowMove = false;
            this.colSEPTEMBER.OptionsColumn.AllowSort = false;
            this.colSEPTEMBER.Width = 70;
            // 
            // colOCTEMBER
            // 
            this.colOCTEMBER.AppearanceCell.Options.UseTextOptions = true;
            this.colOCTEMBER.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colOCTEMBER.Caption = "Октябрь";
            this.colOCTEMBER.ColumnEdit = this.repItemPopupContainerEdit;
            this.colOCTEMBER.FieldName = "Октябрь";
            this.colOCTEMBER.MinWidth = 70;
            this.colOCTEMBER.Name = "colOCTEMBER";
            this.colOCTEMBER.OptionsColumn.AllowMove = false;
            this.colOCTEMBER.OptionsColumn.AllowSort = false;
            this.colOCTEMBER.Width = 70;
            // 
            // colNOVEMBER
            // 
            this.colNOVEMBER.AppearanceCell.Options.UseTextOptions = true;
            this.colNOVEMBER.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNOVEMBER.Caption = "Ноябрь";
            this.colNOVEMBER.ColumnEdit = this.repItemPopupContainerEdit;
            this.colNOVEMBER.FieldName = "Ноябрь";
            this.colNOVEMBER.MinWidth = 70;
            this.colNOVEMBER.Name = "colNOVEMBER";
            this.colNOVEMBER.OptionsColumn.AllowMove = false;
            this.colNOVEMBER.OptionsColumn.AllowSort = false;
            // 
            // colDECEMBER
            // 
            this.colDECEMBER.AppearanceCell.Options.UseTextOptions = true;
            this.colDECEMBER.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDECEMBER.Caption = "Декабрь";
            this.colDECEMBER.ColumnEdit = this.repItemPopupContainerEdit;
            this.colDECEMBER.FieldName = "Декабрь";
            this.colDECEMBER.MinWidth = 70;
            this.colDECEMBER.Name = "colDECEMBER";
            this.colDECEMBER.OptionsColumn.AllowMove = false;
            this.colDECEMBER.OptionsColumn.AllowSort = false;
            this.colDECEMBER.Width = 70;
            // 
            // colSummary
            // 
            this.colSummary.AppearanceCell.Options.UseTextOptions = true;
            this.colSummary.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSummary.Caption = "Итого";
            this.colSummary.FieldName = "Итого";
            this.colSummary.MinWidth = 70;
            this.colSummary.Name = "colSummary";
            this.colSummary.OptionsColumn.AllowEdit = false;
            this.colSummary.OptionsColumn.AllowMove = false;
            this.colSummary.OptionsColumn.AllowSort = false;
            this.colSummary.OptionsColumn.ReadOnly = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel3.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 245);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(496, 28);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel3, null);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(313, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 22);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.ToolTip = "Сохранить изменения и закрыть форму";
            this.btnSave.ToolTipController = this.toolTipController;
            this.btnSave.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(408, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 22);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.ToolTip = "Закрыть форму";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtDebitArticleDscrpn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 162);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(490, 80);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel2, null);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // txtDebitArticleDscrpn
            // 
            this.txtDebitArticleDscrpn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebitArticleDscrpn.Location = new System.Drawing.Point(72, 3);
            this.txtDebitArticleDscrpn.Name = "txtDebitArticleDscrpn";
            this.txtDebitArticleDscrpn.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDebitArticleDscrpn.Size = new System.Drawing.Size(415, 74);
            this.txtDebitArticleDscrpn.TabIndex = 2;
            this.txtDebitArticleDscrpn.ToolTip = "Примечание";
            this.txtDebitArticleDscrpn.ToolTipController = this.toolTipController;
            this.txtDebitArticleDscrpn.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtDebitArticleDscrpn.EditValueChanged += new System.EventHandler(this.EditValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.toolTipController.SetSuperTip(this.label3, null);
            this.label3.TabIndex = 2;
            this.label3.Text = "Описание:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.toolTipController.SetSuperTip(this.label2, null);
            this.label2.TabIndex = 1;
            this.label2.Text = "Наименование:";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.txtDebitArticleName, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtDebitArticleNum, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 133);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(490, 29);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel4, null);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // txtDebitArticleName
            // 
            this.txtDebitArticleName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebitArticleName.Location = new System.Drawing.Point(259, 3);
            this.txtDebitArticleName.Name = "txtDebitArticleName";
            this.txtDebitArticleName.Size = new System.Drawing.Size(228, 20);
            this.txtDebitArticleName.TabIndex = 1;
            this.txtDebitArticleName.ToolTip = "Наименование статьи/подстатьи";
            this.txtDebitArticleName.ToolTipController = this.toolTipController;
            this.txtDebitArticleName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtDebitArticleName.EditValueChanged += new System.EventHandler(this.EditValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.toolTipController.SetSuperTip(this.label1, null);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер:";
            // 
            // txtDebitArticleNum
            // 
            this.txtDebitArticleNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebitArticleNum.Location = new System.Drawing.Point(73, 3);
            this.txtDebitArticleNum.Name = "txtDebitArticleNum";
            this.txtDebitArticleNum.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDebitArticleNum.Properties.Appearance.Options.UseFont = true;
            this.txtDebitArticleNum.Properties.ReadOnly = true;
            this.txtDebitArticleNum.Size = new System.Drawing.Size(90, 20);
            this.txtDebitArticleNum.TabIndex = 0;
            this.txtDebitArticleNum.ToolTip = "Номер";
            this.txtDebitArticleNum.ToolTipController = this.toolTipController;
            this.txtDebitArticleNum.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtDebitArticleNum.EditValueChanged += new System.EventHandler(this.EditValueChanged);
            // 
            // frmDebitArticleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "frmDebitArticleEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.toolTipController.SetSuperTip(this, null);
            this.Shown += new System.EventHandler(this.frmDebitArticleEditor_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemPopupContainerEdit)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitArticleDscrpn.Properties)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitArticleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebitArticleNum.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.TextEdit txtDebitArticleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtDebitArticleNum;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.MemoEdit txtDebitArticleDscrpn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDEBITARTICLE_GUID_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDEBITARTICLE_PARENT_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDEBITARTICLE_NUM;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colREADONLY;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDEBITARTICLE_MULTIBUDGETDEP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colJANUARY;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repItemPopupContainerEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFEBRUARY;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMARCH;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAPRIL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMAY;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colJUNE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colJULY;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAUGUST;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSEPTEMBER;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOCTEMBER;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNOVEMBER;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDECEMBER;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSummary;
    }
}