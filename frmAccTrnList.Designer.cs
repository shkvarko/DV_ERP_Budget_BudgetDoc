namespace ErpBudgetBudgetDoc
{
    partial class frmAccTrnList
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
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.treeListTrn = new DevExpress.XtraTreeList.TreeList();
            this.colTrnDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnMoney = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnCurrency = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnOper = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnUser = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTrnDescrpn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblDebitArticle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListTrn)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.barBtnPrint,
            this.barBtnClose});
            this.barManager.MaxItemId = 2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 1";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnClose)});
            this.bar1.Text = "Custom 1";
            // 
            // barBtnPrint
            // 
            this.barBtnPrint.Caption = "Печать";
            this.barBtnPrint.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.printer2;
            this.barBtnPrint.Id = 0;
            this.barBtnPrint.Name = "barBtnPrint";
            this.barBtnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPrint_ItemClick);
            // 
            // barBtnClose
            // 
            this.barBtnClose.Caption = "Выход";
            this.barBtnClose.Glyph = global::ErpBudgetBudgetDoc.Properties.Resources.delete2;
            this.barBtnClose.Id = 1;
            this.barBtnClose.Name = "barBtnClose";
            this.barBtnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnClose_ItemClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.treeListTrn, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(549, 329);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // treeListTrn
            // 
            this.treeListTrn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListTrn.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTrnDate,
            this.colTrnMoney,
            this.colTrnCurrency,
            this.colTrnOper,
            this.colTrnUser,
            this.colTrnDescrpn});
            this.treeListTrn.Location = new System.Drawing.Point(3, 63);
            this.treeListTrn.Name = "treeListTrn";
            this.treeListTrn.OptionsView.ShowSummaryFooter = true;
            this.treeListTrn.Size = new System.Drawing.Size(543, 263);
            this.treeListTrn.TabIndex = 4;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblMoney, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDebitArticle, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblInfo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 60);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblMoney
            // 
            this.lblMoney.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMoney.AutoSize = true;
            this.lblMoney.Location = new System.Drawing.Point(66, 43);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(35, 13);
            this.lblMoney.TabIndex = 2;
            this.lblMoney.Text = "label3";
            // 
            // lblDebitArticle
            // 
            this.lblDebitArticle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDebitArticle.AutoSize = true;
            this.lblDebitArticle.Location = new System.Drawing.Point(66, 23);
            this.lblDebitArticle.Name = "lblDebitArticle";
            this.lblDebitArticle.Size = new System.Drawing.Size(35, 13);
            this.lblDebitArticle.TabIndex = 1;
            this.lblDebitArticle.Text = "label2";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(66, 3);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "label1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Служба:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Статья:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сумма:";
            // 
            // frmAccTrnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 355);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "frmAccTrnList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Журнал проводок";
            this.Load += new System.EventHandler(this.frmAccTrnList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListTrn)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barBtnPrint;
        private DevExpress.XtraBars.BarButtonItem barBtnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblDebitArticle;
        private System.Windows.Forms.Label lblMoney;
        private DevExpress.XtraTreeList.TreeList treeListTrn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnMoney;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnCurrency;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnOper;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTrnDescrpn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}