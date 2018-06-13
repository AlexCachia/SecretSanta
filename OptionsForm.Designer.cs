namespace Christmas
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.UploadButton = new System.Windows.Forms.Button();
            this.listDialog = new System.Windows.Forms.OpenFileDialog();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.UploadButton.Location = new System.Drawing.Point(41, 22);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(205, 28);
            this.UploadButton.TabIndex = 0;
            this.UploadButton.Text = "Upload Names From Txt File";
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // listDialog
            // 
            this.listDialog.DefaultExt = "txt";
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.UploadButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.Text = "Additional Options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.OpenFileDialog listDialog;
    }
}