namespace ErpBudgetBudgetDoc
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
            this.calcEventMoney = new DevExpress.XtraEditors.CalcEdit();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.btnHide = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlDocEvent)).BeginInit();
            this.grCtrlDocEvent.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgrDocEvent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
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
            this.rgrDocEvent.Size = new System.Drawing.Size(645, 37);
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
            this.panelControl1.Controls.Add(this.calcEventMoney);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(654, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(114, 37);
            this.toolTipController.SetSuperTip(this.panelControl1, null);
            this.panelControl1.TabIndex = 3;
            // 
            // calcEventMoney
            // 
            this.calcEventMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.calcEventMoney.EditValue = new decimal(new int[] {
            1111,
            0,
            0,
            131072});
            this.calcEventMoney.Location = new System.Drawing.Point(3, 11);
            this.calcEventMoney.Name = "calcEventMoney";
            this.calcEventMoney.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calcEventMoney.Size = new System.Drawing.Size(100, 20);
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
    }
}
