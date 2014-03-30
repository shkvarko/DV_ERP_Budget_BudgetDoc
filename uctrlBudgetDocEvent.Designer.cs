﻿namespace ErpBudgetBudgetDoc
{
    partial class uctrlBudgetDocEvent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grCtrlDocEvent = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rgrDocEvent = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblAccountPlan = new System.Windows.Forms.Label();
            this.cboxFactCurrency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.calcEventFactMoney = new DevExpress.XtraEditors.CalcEdit();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.calcEventMoney = new DevExpress.XtraEditors.CalcEdit();
            this.btnHide = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlDocEvent)).BeginInit();
            this.grCtrlDocEvent.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgrDocEvent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxFactCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEventFactMoney.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEventMoney.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grCtrlDocEvent
            // 
            this.grCtrlDocEvent.Controls.Add(this.tableLayoutPanel);
            this.grCtrlDocEvent.Controls.Add(this.btnHide);
            this.grCtrlDocEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCtrlDocEvent.Location = new System.Drawing.Point(0, 0);
            this.grCtrlDocEvent.Name = "grCtrlDocEvent";
            this.grCtrlDocEvent.Size = new System.Drawing.Size(775, 65);
            this.toolTipController.SetSuperTip(this.grCtrlDocEvent, null);
            this.grCtrlDocEvent.TabIndex = 8;
            this.grCtrlDocEvent.Text = "Действия";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 313F));
            this.tableLayoutPanel.Controls.Add(this.rgrDocEvent, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panelControl1, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(771, 43);
            this.toolTipController.SetSuperTip(this.tableLayoutPanel, null);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // rgrDocEvent
            // 
            this.rgrDocEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgrDocEvent.Location = new System.Drawing.Point(3, 3);
            this.rgrDocEvent.Name = "rgrDocEvent";
            this.rgrDocEvent.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.rgrDocEvent.Properties.Appearance.Options.UseBackColor = true;
            this.rgrDocEvent.Properties.AppearanceFocused.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rgrDocEvent.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.rgrDocEvent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgrDocEvent.Properties.Columns = 2;
            this.rgrDocEvent.Size = new System.Drawing.Size(452, 37);
            this.rgrDocEvent.TabIndex = 2;
            this.rgrDocEvent.ToolTip = "Действия, которые необходимо осуществить с бюджетным документом";
            this.rgrDocEvent.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.rgrDocEvent.SelectedIndexChanged += new System.EventHandler(this.rgrDocEvent_SelectedIndexChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.lblAccountPlan);
            this.panelControl1.Controls.Add(this.cboxFactCurrency);
            this.panelControl1.Controls.Add(this.calcEventFactMoney);
            this.panelControl1.Controls.Add(this.calcEventMoney);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(461, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(307, 37);
            this.toolTipController.SetSuperTip(this.panelControl1, null);
            this.panelControl1.TabIndex = 3;
            // 
            // lblAccountPlan
            // 
            this.lblAccountPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAccountPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAccountPlan.Location = new System.Drawing.Point(1, 1);
            this.lblAccountPlan.Name = "lblAccountPlan";
            this.lblAccountPlan.Size = new System.Drawing.Size(112, 13);
            this.toolTipController.SetSuperTip(this.lblAccountPlan, null);
            this.lblAccountPlan.TabIndex = 11;
            this.lblAccountPlan.Text = "оплачивается";
            // 
            // cboxFactCurrency
            // 
            this.cboxFactCurrency.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboxFactCurrency.Location = new System.Drawing.Point(119, 14);
            this.cboxFactCurrency.Name = "cboxFactCurrency";
            this.cboxFactCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxFactCurrency.Properties.PopupSizeable = true;
            this.cboxFactCurrency.Properties.Sorted = true;
            this.cboxFactCurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboxFactCurrency.Size = new System.Drawing.Size(64, 20);
            this.cboxFactCurrency.TabIndex = 1;
            this.cboxFactCurrency.ToolTip = "Валюта";
            this.cboxFactCurrency.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cboxFactCurrency.SelectedValueChanged += new System.EventHandler(this.cboxFactCurrency_SelectedValueChanged);
            // 
            // calcEventFactMoney
            // 
            this.calcEventFactMoney.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.calcEventFactMoney.EditValue = new decimal(new int[] {
            1111,
            0,
            0,
            131072});
            this.calcEventFactMoney.Location = new System.Drawing.Point(188, 14);
            this.calcEventFactMoney.Name = "calcEventFactMoney";
            this.calcEventFactMoney.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcEventFactMoney.Size = new System.Drawing.Size(111, 20);
            this.calcEventFactMoney.TabIndex = 2;
            this.calcEventFactMoney.ToolTipController = this.toolTipController;
            this.calcEventFactMoney.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.calcEventFactMoney.EditValueChanged += new System.EventHandler(this.calcEventFactMoney_EditValueChanged);
            this.calcEventFactMoney.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.calcEventFactMoney_EditValueChanging);
            // 
            // calcEventMoney
            // 
            this.calcEventMoney.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.calcEventMoney.EditValue = new decimal(new int[] {
            1111,
            0,
            0,
            131072});
            this.calcEventMoney.Location = new System.Drawing.Point(3, 14);
            this.calcEventMoney.Name = "calcEventMoney";
            this.calcEventMoney.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcEventMoney.Size = new System.Drawing.Size(111, 20);
            this.calcEventMoney.TabIndex = 0;
            this.calcEventMoney.ToolTipController = this.toolTipController;
            this.calcEventMoney.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.calcEventMoney.EditValueChanged += new System.EventHandler(this.calcEventMoney_EditValueChanged);
            this.calcEventMoney.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.calcEventMoney_EditValueChanging);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.Appearance.Font = new System.Drawing.Font("Arial", 6.75F);
            this.btnHide.Appearance.Options.UseFont = true;
            this.btnHide.Location = new System.Drawing.Point(753, 1);
            this.btnHide.Margin = new System.Windows.Forms.Padding(0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(20, 17);
            this.btnHide.TabIndex = 3;
            this.btnHide.Text = "<<";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(119, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.toolTipController.SetSuperTip(this.label1, null);
            this.label1.TabIndex = 12;
            this.label1.Text = "в валюте";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(188, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.toolTipController.SetSuperTip(this.label2, null);
            this.label2.TabIndex = 13;
            this.label2.Text = "суммой";
            // 
            // uctrlBudgetDocEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grCtrlDocEvent);
            this.Name = "uctrlBudgetDocEvent";
            this.Size = new System.Drawing.Size(775, 65);
            this.toolTipController.SetSuperTip(this, null);
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlDocEvent)).EndInit();
            this.grCtrlDocEvent.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgrDocEvent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboxFactCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEventFactMoney.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcEventMoney.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grCtrlDocEvent;
        private DevExpress.XtraEditors.RadioGroup rgrDocEvent;
        private DevExpress.XtraEditors.SimpleButton btnHide;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CalcEdit calcEventMoney;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraEditors.CalcEdit calcEventFactMoney;
        private DevExpress.XtraEditors.ComboBoxEdit cboxFactCurrency;
        private System.Windows.Forms.Label lblAccountPlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
