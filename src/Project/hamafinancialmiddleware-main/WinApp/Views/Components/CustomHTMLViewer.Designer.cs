namespace Hama.WinApp.Views.Components
{
    partial class CustomHTMLViewer
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
            previewWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)previewWebView).BeginInit();
            SuspendLayout();
            // 
            // previewWebView
            // 
            previewWebView.AllowExternalDrop = true;
            previewWebView.CreationProperties = null;
            previewWebView.DefaultBackgroundColor = System.Drawing.Color.White;
            previewWebView.Dock = System.Windows.Forms.DockStyle.Fill;
            previewWebView.Location = new System.Drawing.Point(0, 0);
            previewWebView.Name = "previewWebView";
            previewWebView.Size = new System.Drawing.Size(754, 336);
            previewWebView.TabIndex = 1;
            previewWebView.ZoomFactor = 1D;
            // 
            // CustomHTMLViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(previewWebView);
            Name = "CustomHTMLViewer";
            Size = new System.Drawing.Size(754, 336);
            ((System.ComponentModel.ISupportInitialize)previewWebView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 previewWebView;
    }
}
