namespace IdeaCipher
{
    partial class cipherForm
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
            this.inputKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.inputPlainText = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.inputEncryptedText = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncryptedSave = new System.Windows.Forms.Button();
            this.btnEncryptedLoad = new System.Windows.Forms.Button();
            this.btnPlainSave = new System.Windows.Forms.Button();
            this.btnPlainLoad = new System.Windows.Forms.Button();
            this.dlgEncryptedFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgPlainFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgEncryptedFileSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgPlainFileSave = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // inputKey
            // 
            this.inputKey.Location = new System.Drawing.Point(34, 32);
            this.inputKey.Name = "inputKey";
            this.inputKey.Size = new System.Drawing.Size(483, 20);
            this.inputKey.TabIndex = 0;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(34, 13);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(25, 13);
            this.lblKey.TabIndex = 1;
            this.lblKey.Text = "Key";
            // 
            // inputPlainText
            // 
            this.inputPlainText.Location = new System.Drawing.Point(33, 98);
            this.inputPlainText.Multiline = true;
            this.inputPlainText.Name = "inputPlainText";
            this.inputPlainText.Size = new System.Drawing.Size(198, 138);
            this.inputPlainText.TabIndex = 2;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(31, 74);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(50, 13);
            this.lblInput.TabIndex = 3;
            this.lblInput.Text = "Plain text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Encrypted data";
            // 
            // inputEncryptedText
            // 
            this.inputEncryptedText.Location = new System.Drawing.Point(317, 98);
            this.inputEncryptedText.Multiline = true;
            this.inputEncryptedText.Name = "inputEncryptedText";
            this.inputEncryptedText.ReadOnly = true;
            this.inputEncryptedText.Size = new System.Drawing.Size(200, 138);
            this.inputEncryptedText.TabIndex = 4;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(236, 129);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 9;
            this.btnEncrypt.Text = "Encrypt =>";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(236, 177);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 8;
            this.btnDecrypt.Text = "<= Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncryptedSave
            // 
            this.btnEncryptedSave.Location = new System.Drawing.Point(476, 69);
            this.btnEncryptedSave.Name = "btnEncryptedSave";
            this.btnEncryptedSave.Size = new System.Drawing.Size(42, 23);
            this.btnEncryptedSave.TabIndex = 19;
            this.btnEncryptedSave.Text = "Save";
            this.btnEncryptedSave.UseVisualStyleBackColor = true;
            this.btnEncryptedSave.Click += new System.EventHandler(this.btnEncryptedSave_Click);
            // 
            // btnEncryptedLoad
            // 
            this.btnEncryptedLoad.Location = new System.Drawing.Point(433, 69);
            this.btnEncryptedLoad.Name = "btnEncryptedLoad";
            this.btnEncryptedLoad.Size = new System.Drawing.Size(42, 23);
            this.btnEncryptedLoad.TabIndex = 18;
            this.btnEncryptedLoad.Text = "Load";
            this.btnEncryptedLoad.UseVisualStyleBackColor = true;
            this.btnEncryptedLoad.Click += new System.EventHandler(this.btnEncryptedLoad_Click);
            // 
            // btnPlainSave
            // 
            this.btnPlainSave.Location = new System.Drawing.Point(189, 69);
            this.btnPlainSave.Name = "btnPlainSave";
            this.btnPlainSave.Size = new System.Drawing.Size(42, 23);
            this.btnPlainSave.TabIndex = 17;
            this.btnPlainSave.Text = "Save";
            this.btnPlainSave.UseVisualStyleBackColor = true;
            this.btnPlainSave.Click += new System.EventHandler(this.btnPlainSave_Click);
            // 
            // btnPlainLoad
            // 
            this.btnPlainLoad.Location = new System.Drawing.Point(146, 69);
            this.btnPlainLoad.Name = "btnPlainLoad";
            this.btnPlainLoad.Size = new System.Drawing.Size(42, 23);
            this.btnPlainLoad.TabIndex = 16;
            this.btnPlainLoad.Text = "Load";
            this.btnPlainLoad.UseVisualStyleBackColor = true;
            this.btnPlainLoad.Click += new System.EventHandler(this.btnPlainLoad_Click);
            // 
            // dlgEncryptedFile
            // 
            this.dlgEncryptedFile.Filter = "Ecrypted files|*.dat";
            // 
            // dlgPlainFile
            // 
            this.dlgPlainFile.Filter = "Plain text|*.txt";
            // 
            // dlgEncryptedFileSave
            // 
            this.dlgEncryptedFileSave.Filter = "Encrypted data|*.dat";
            // 
            // dlgPlainFileSave
            // 
            this.dlgPlainFileSave.Filter = "Plain text|*.txt";
            // 
            // cipherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 254);
            this.Controls.Add(this.btnEncryptedSave);
            this.Controls.Add(this.btnEncryptedLoad);
            this.Controls.Add(this.btnPlainSave);
            this.Controls.Add(this.btnPlainLoad);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputEncryptedText);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.inputPlainText);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.inputKey);
            this.Name = "cipherForm";
            this.Text = "Idea (Block cipher)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox inputPlainText;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputEncryptedText;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncryptedSave;
        private System.Windows.Forms.Button btnEncryptedLoad;
        private System.Windows.Forms.Button btnPlainSave;
        private System.Windows.Forms.Button btnPlainLoad;
        private System.Windows.Forms.OpenFileDialog dlgEncryptedFile;
        private System.Windows.Forms.OpenFileDialog dlgPlainFile;
        private System.Windows.Forms.SaveFileDialog dlgEncryptedFileSave;
        private System.Windows.Forms.SaveFileDialog dlgPlainFileSave;
    }
}

