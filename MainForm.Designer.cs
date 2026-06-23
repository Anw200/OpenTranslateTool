namespace OpenTranslateTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cmbDict = new ComboBox();
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnTranslate = new Button();
            chkOutputBase64 = new CheckBox();
            SuspendLayout();
            // 
            // cmbDict
            // 
            cmbDict.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDict.FormattingEnabled = true;
            cmbDict.Location = new Point(12, 12);
            cmbDict.Name = "cmbDict";
            cmbDict.Size = new Size(300, 23);
            cmbDict.TabIndex = 0;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(12, 50);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(600, 150);
            txtInput.TabIndex = 1;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(12, 260);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(600, 150);
            txtOutput.TabIndex = 2;
            // 
            // btnTranslate
            // 
            btnTranslate.Location = new Point(330, 12);
            btnTranslate.Name = "btnTranslate";
            btnTranslate.Size = new Size(120, 23);
            btnTranslate.TabIndex = 3;
            btnTranslate.Text = "Translate";
            btnTranslate.UseVisualStyleBackColor = true;
            btnTranslate.Click += btnTranslate_Click;
            // 
            // chkOutputBase64
            // 
            chkOutputBase64.AutoSize = true;
            chkOutputBase64.Location = new Point(498, 16);
            chkOutputBase64.Name = "chkOutputBase64";
            chkOutputBase64.Size = new Size(62, 19);
            chkOutputBase64.TabIndex = 4;
            chkOutputBase64.Text = "Base64";
            chkOutputBase64.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            ClientSize = new Size(630, 430);
            Controls.Add(chkOutputBase64);
            Controls.Add(btnTranslate);
            Controls.Add(txtOutput);
            Controls.Add(txtInput);
            Controls.Add(cmbDict);
            Name = "MainForm";
            Text = "OpenTranslateTool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDict;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnTranslate;
        private CheckBox chkOutputBase64;
    }
}
