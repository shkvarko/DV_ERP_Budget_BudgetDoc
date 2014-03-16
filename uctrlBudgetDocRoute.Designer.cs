namespace ErpBudgetBudgetDoc
{
    partial class uctrlBudgetDocRoute
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
            this.grCtrlRoute = new DevExpress.XtraEditors.GroupControl();
            this.btnHide = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCtrlRouteImage = new DevExpress.XtraEditors.PanelControl();
            this.txtDR4Route = new ERP_Budget.Common.CRouteVariableDynamicRight();
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlRoute)).BeginInit();
            this.grCtrlRoute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlRouteImage)).BeginInit();
            this.pnlCtrlRouteImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDR4Route.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grCtrlRoute
            // 
            this.grCtrlRoute.Controls.Add(this.btnHide);
            this.grCtrlRoute.Controls.Add(this.pnlCtrlRouteImage);
            this.grCtrlRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grCtrlRoute.Location = new System.Drawing.Point(0, 0);
            this.grCtrlRoute.Name = "grCtrlRoute";
            this.grCtrlRoute.Size = new System.Drawing.Size(775, 73);
            this.grCtrlRoute.TabIndex = 5;
            this.grCtrlRoute.Text = "Маршрут";
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.Appearance.Font = new System.Drawing.Font("Arial", 6.75F);
            this.btnHide.Appearance.Options.UseFont = true;
            this.btnHide.Location = new System.Drawing.Point(752, 1);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(20, 17);
            this.btnHide.TabIndex = 3;
            this.btnHide.Text = "<<";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // pnlCtrlRouteImage
            // 
            this.pnlCtrlRouteImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCtrlRouteImage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCtrlRouteImage.Controls.Add(this.txtDR4Route);
            this.pnlCtrlRouteImage.Location = new System.Drawing.Point(9, 22);
            this.pnlCtrlRouteImage.Name = "pnlCtrlRouteImage";
            this.pnlCtrlRouteImage.Size = new System.Drawing.Size(758, 41);
            this.pnlCtrlRouteImage.TabIndex = 2;
            // 
            // txtDR4Route
            // 
            this.txtDR4Route.Location = new System.Drawing.Point(691, 3);
            this.txtDR4Route.Name = "txtDR4Route";
            this.txtDR4Route.Size = new System.Drawing.Size(64, 20);
            this.txtDR4Route.TabIndex = 18;
            // 
            // uctrlBudgetDocRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grCtrlRoute);
            this.Name = "uctrlBudgetDocRoute";
            this.Size = new System.Drawing.Size(775, 73);
            ((System.ComponentModel.ISupportInitialize)(this.grCtrlRoute)).EndInit();
            this.grCtrlRoute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrlRouteImage)).EndInit();
            this.pnlCtrlRouteImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDR4Route.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grCtrlRoute;
        private DevExpress.XtraEditors.PanelControl pnlCtrlRouteImage;
        private DevExpress.XtraEditors.SimpleButton btnHide;
        private ERP_Budget.Common.CRouteVariableDynamicRight txtDR4Route;
    }
}
