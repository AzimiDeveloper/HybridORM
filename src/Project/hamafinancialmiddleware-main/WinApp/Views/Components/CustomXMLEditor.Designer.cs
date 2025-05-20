namespace Hama.WinApp.Views.Components
{
    partial class CustomXMLEditor
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
            XMLEditor = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)XMLEditor).BeginInit();
            SuspendLayout();
            // 
            // XMLEditor
            // 
            XMLEditor.AllowExternalDrop = true;
            XMLEditor.CreationProperties = null;
            XMLEditor.DefaultBackgroundColor = System.Drawing.Color.White;
            XMLEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            XMLEditor.Location = new System.Drawing.Point(0, 0);
            XMLEditor.Name = "XMLEditor";
            XMLEditor.Size = new System.Drawing.Size(617, 307);
            XMLEditor.TabIndex = 0;
            XMLEditor.ZoomFactor = 1D;
            // 
            // CustomXMLEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(XMLEditor);
            Name = "CustomXMLEditor";
            Size = new System.Drawing.Size(617, 307);
            ((System.ComponentModel.ISupportInitialize)XMLEditor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Microsoft.Web.WebView2.WinForms.WebView2 XMLEditor;
    }
}
