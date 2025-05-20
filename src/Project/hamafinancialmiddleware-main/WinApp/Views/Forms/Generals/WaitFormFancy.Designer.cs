namespace Hama.WinApp.Views.Forms
{
    partial class WaitFormFancy
    {
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;

        private void InitializeComponent()
        {
            progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            SuspendLayout();
            // 
            // progressPanel1
            // 
            progressPanel1.AnimationAcceleration = 3F;
            progressPanel1.AnimationSpeed = 10F;
            progressPanel1.AnimationToTextDistance = 5;
            progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            progressPanel1.Appearance.Options.UseBackColor = true;
            progressPanel1.Appearance.Options.UseFont = true;
            progressPanel1.Appearance.Options.UseTextOptions = true;
            progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("B Titr", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178);
            progressPanel1.AppearanceCaption.Options.UseFont = true;
            progressPanel1.AppearanceCaption.Options.UseTextOptions = true;
            progressPanel1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            progressPanel1.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178);
            progressPanel1.AppearanceDescription.Options.UseFont = true;
            progressPanel1.AppearanceDescription.Options.UseTextOptions = true;
            progressPanel1.AppearanceDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            progressPanel1.AppearanceDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            progressPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            progressPanel1.Caption = "... لطفا منتظر باشید";
            progressPanel1.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            progressPanel1.Description = "در حال پردازش";
            progressPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            progressPanel1.LineAnimationElementHeight = 20;
            progressPanel1.Location = new System.Drawing.Point(0, 0);
            progressPanel1.Name = "progressPanel1";
            progressPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            progressPanel1.Size = new System.Drawing.Size(220, 82);
            progressPanel1.TabIndex = 0;
            // 
            // WaitFormFancy
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(220, 82);
            Controls.Add(progressPanel1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "WaitFormFancy";
            RightToLeftLayout = true;
            ResumeLayout(false);
        }
    }
}
