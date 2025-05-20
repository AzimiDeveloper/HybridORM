namespace Hama.WinApp.Views.Forms.Documents
{
    partial class VocucherPreviewForm
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
            HtmlEditorControl = new Hama.WinApp.Views.Components.CustomHTMLViewer();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
            SuspendLayout();
            // 
            // alertControl1
            // 
            alertControl1.AppearanceCaption.Font = new System.Drawing.Font("B Titr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178);
            alertControl1.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            alertControl1.AppearanceCaption.Options.UseFont = true;
            alertControl1.AppearanceCaption.Options.UseForeColor = true;
            alertControl1.AppearanceCaption.Options.UseTextOptions = true;
            alertControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            alertControl1.AppearanceText.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178);
            alertControl1.AppearanceText.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            alertControl1.AppearanceText.Options.UseFont = true;
            alertControl1.AppearanceText.Options.UseForeColor = true;
            alertControl1.AppearanceText.Options.UseTextOptions = true;
            alertControl1.AppearanceText.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            alertControl1.AppearanceText.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            alertControl1.AppearanceText.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            // 
            // HtmlEditorControl
            // 
            HtmlEditorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            HtmlEditorControl.Location = new System.Drawing.Point(0, 53);
            HtmlEditorControl.Name = "HtmlEditorControl";
            HtmlEditorControl.Size = new System.Drawing.Size(840, 480);
            HtmlEditorControl.TabIndex = 0;
            // 
            // VocucherPreviewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(840, 533);
            Controls.Add(HtmlEditorControl);
            Name = "VocucherPreviewForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "VocucherPreviewForm";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Controls.SetChildIndex(HtmlEditorControl, 0);
            ((System.ComponentModel.ISupportInitialize)dxError).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Components.CustomHTMLViewer HtmlEditorControl;
    }
}