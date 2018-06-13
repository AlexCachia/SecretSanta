namespace Christmas
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.DomainCombobox = new System.Windows.Forms.ComboBox();
            this.SendEmailButton = new System.Windows.Forms.Button();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.EmailDomainValidator = new System.Windows.Forms.ErrorProvider(this.components);
            this.EmailAddressValidator = new System.Windows.Forms.ErrorProvider(this.components);
            this.PasswordValidator = new System.Windows.Forms.ErrorProvider(this.components);
            this.BackButton = new System.Windows.Forms.Button();
            this.ConnectionValidator = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EmailDomainValidator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailAddressValidator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordValidator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionValidator)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(395, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "@";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Email Address:";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PasswordTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextbox.Location = new System.Drawing.Point(215, 71);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(400, 22);
            this.PasswordTextbox.TabIndex = 4;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EmailTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.Location = new System.Drawing.Point(215, 29);
            this.EmailTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(180, 22);
            this.EmailTextbox.TabIndex = 2;
            // 
            // DomainCombobox
            // 
            this.DomainCombobox.BackColor = System.Drawing.SystemColors.Window;
            this.DomainCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DomainCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DomainCombobox.FormattingEnabled = true;
            this.DomainCombobox.Items.AddRange(new object[] {
            "gmail.com",
            "hotmail.co.uk",
            "hotmail.com",
            "outlook.com",
            "yahoo.com"});
            this.DomainCombobox.Location = new System.Drawing.Point(417, 27);
            this.DomainCombobox.Margin = new System.Windows.Forms.Padding(4);
            this.DomainCombobox.Name = "DomainCombobox";
            this.DomainCombobox.Size = new System.Drawing.Size(198, 24);
            this.DomainCombobox.TabIndex = 3;
            // 
            // SendEmailButton
            // 
            this.SendEmailButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SendEmailButton.FlatAppearance.BorderSize = 0;
            this.SendEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendEmailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendEmailButton.Location = new System.Drawing.Point(540, 139);
            this.SendEmailButton.Name = "SendEmailButton";
            this.SendEmailButton.Size = new System.Drawing.Size(75, 23);
            this.SendEmailButton.TabIndex = 7;
            this.SendEmailButton.Text = "Send emails";
            this.SendEmailButton.UseVisualStyleBackColor = false;
            this.SendEmailButton.Click += new System.EventHandler(this.SendEmailButton_Click);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressLabel.Location = new System.Drawing.Point(341, 188);
            this.ProgressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(42, 16);
            this.ProgressLabel.TabIndex = 53;
            this.ProgressLabel.Text = "Label";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.BackColor = System.Drawing.SystemColors.Window;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.progressBar1.Location = new System.Drawing.Point(113, 208);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(502, 28);
            this.progressBar1.TabIndex = 52;
            // 
            // EmailDomainValidator
            // 
            this.EmailDomainValidator.ContainerControl = this;
            // 
            // EmailAddressValidator
            // 
            this.EmailAddressValidator.ContainerControl = this;
            // 
            // PasswordValidator
            // 
            this.PasswordValidator.ContainerControl = this;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(113, 139);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ConnectionValidator
            // 
            this.ConnectionValidator.ContainerControl = this;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.SendEmailButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.BackButton;
            this.ClientSize = new System.Drawing.Size(734, 261);
            this.ControlBox = false;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.SendEmailButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.EmailTextbox);
            this.Controls.Add(this.DomainCombobox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Secret Santa";
            ((System.ComponentModel.ISupportInitialize)(this.EmailDomainValidator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailAddressValidator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordValidator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionValidator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.ComboBox DomainCombobox;
        private System.Windows.Forms.Button SendEmailButton;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ErrorProvider EmailDomainValidator;
        private System.Windows.Forms.ErrorProvider EmailAddressValidator;
        private System.Windows.Forms.ErrorProvider PasswordValidator;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ErrorProvider ConnectionValidator;
    }
}
