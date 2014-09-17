namespace QuickReview.Outlook
{
    partial class SettingsBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsBox));
            this.lblEmailRecipient = new System.Windows.Forms.Label();
            this.txtBoxEmailRecipient = new System.Windows.Forms.TextBox();
            this.lblTeamProjectUrl = new System.Windows.Forms.Label();
            this.txtBoxTeamServerUrl = new System.Windows.Forms.TextBox();
            this.btnOKSettings = new System.Windows.Forms.Button();
            this.btnCancelSettings = new System.Windows.Forms.Button();
            this.closeShelvesetWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmailRecipient
            // 
            this.lblEmailRecipient.AutoSize = true;
            this.lblEmailRecipient.Location = new System.Drawing.Point(3, 13);
            this.lblEmailRecipient.Name = "lblEmailRecipient";
            this.lblEmailRecipient.Size = new System.Drawing.Size(80, 13);
            this.lblEmailRecipient.TabIndex = 0;
            this.lblEmailRecipient.Text = "Email Recipient";
            // 
            // txtBoxEmailRecipient
            // 
            this.txtBoxEmailRecipient.Location = new System.Drawing.Point(115, 10);
            this.txtBoxEmailRecipient.Name = "txtBoxEmailRecipient";
            this.txtBoxEmailRecipient.Size = new System.Drawing.Size(270, 20);
            this.txtBoxEmailRecipient.TabIndex = 1;
            // 
            // lblTeamProjectUrl
            // 
            this.lblTeamProjectUrl.AutoSize = true;
            this.lblTeamProjectUrl.Location = new System.Drawing.Point(3, 45);
            this.lblTeamProjectUrl.Name = "lblTeamProjectUrl";
            this.lblTeamProjectUrl.Size = new System.Drawing.Size(86, 13);
            this.lblTeamProjectUrl.TabIndex = 2;
            this.lblTeamProjectUrl.Text = "Team Project Url";
            // 
            // txtBoxTeamServerUrl
            // 
            this.txtBoxTeamServerUrl.Location = new System.Drawing.Point(115, 41);
            this.txtBoxTeamServerUrl.Name = "txtBoxTeamServerUrl";
            this.txtBoxTeamServerUrl.Size = new System.Drawing.Size(270, 20);
            this.txtBoxTeamServerUrl.TabIndex = 3;
            // 
            // btnOKSettings
            // 
            this.btnOKSettings.Location = new System.Drawing.Point(224, 171);
            this.btnOKSettings.Name = "btnOKSettings";
            this.btnOKSettings.Size = new System.Drawing.Size(75, 23);
            this.btnOKSettings.TabIndex = 4;
            this.btnOKSettings.Text = "OK";
            this.btnOKSettings.UseVisualStyleBackColor = true;
            this.btnOKSettings.Click += new System.EventHandler(this.BtnOKSettings_Click);
            // 
            // btnCancelSettings
            // 
            this.btnCancelSettings.Location = new System.Drawing.Point(310, 171);
            this.btnCancelSettings.Name = "btnCancelSettings";
            this.btnCancelSettings.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSettings.TabIndex = 5;
            this.btnCancelSettings.Text = "Cancel";
            this.btnCancelSettings.UseVisualStyleBackColor = true;
            this.btnCancelSettings.Click += new System.EventHandler(this.BtnCancelSettings_Click);
            // 
            // closeShelvesetWindowsCheckBox
            // 
            this.closeShelvesetWindowsCheckBox.Location = new System.Drawing.Point(6, 22);
            this.closeShelvesetWindowsCheckBox.Name = "closeShelvesetWindowsCheckBox";
            this.closeShelvesetWindowsCheckBox.Size = new System.Drawing.Size(225, 17);
            this.closeShelvesetWindowsCheckBox.TabIndex = 0;
            this.closeShelvesetWindowsCheckBox.Text = "Close shelvesets window on selection";
            this.closeShelvesetWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.closeShelvesetWindowsCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // SettingsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 199);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelSettings);
            this.Controls.Add(this.btnOKSettings);
            this.Controls.Add(this.txtBoxTeamServerUrl);
            this.Controls.Add(this.lblTeamProjectUrl);
            this.Controls.Add(this.txtBoxEmailRecipient);
            this.Controls.Add(this.lblEmailRecipient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsBox";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsBox_FormClosed);
            this.Load += new System.EventHandler(this.SettingsBox_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmailRecipient;
        private System.Windows.Forms.TextBox txtBoxEmailRecipient;
        private System.Windows.Forms.Label lblTeamProjectUrl;
        private System.Windows.Forms.TextBox txtBoxTeamServerUrl;
        private System.Windows.Forms.Button btnOKSettings;
        private System.Windows.Forms.Button btnCancelSettings;
        private System.Windows.Forms.CheckBox closeShelvesetWindowsCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}