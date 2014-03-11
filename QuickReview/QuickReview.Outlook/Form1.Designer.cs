namespace QuickReview.Outlook
{
    partial class Form1
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
            this.lblShelvesetCount = new System.Windows.Forms.Label();
            this.panelShelvesets = new System.Windows.Forms.Panel();
            this.txtBoxEmailRecipient = new System.Windows.Forms.TextBox();
            this.lblEmailRecipient = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblShelvesetCount
            // 
            this.lblShelvesetCount.AutoSize = true;
            this.lblShelvesetCount.Location = new System.Drawing.Point(7, 13);
            this.lblShelvesetCount.Name = "lblShelvesetCount";
            this.lblShelvesetCount.Size = new System.Drawing.Size(82, 13);
            this.lblShelvesetCount.TabIndex = 1;
            this.lblShelvesetCount.Text = "ShelvesetCount";
            // 
            // panelShelvesets
            // 
            this.panelShelvesets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelShelvesets.AutoScroll = true;
            this.panelShelvesets.BackColor = System.Drawing.SystemColors.Control;
            this.panelShelvesets.Location = new System.Drawing.Point(0, 39);
            this.panelShelvesets.Name = "panelShelvesets";
            this.panelShelvesets.Size = new System.Drawing.Size(484, 222);
            this.panelShelvesets.TabIndex = 2;
            // 
            // txtBoxEmailRecipient
            // 
            this.txtBoxEmailRecipient.Location = new System.Drawing.Point(251, 13);
            this.txtBoxEmailRecipient.Name = "txtBoxEmailRecipient";
            this.txtBoxEmailRecipient.Size = new System.Drawing.Size(172, 20);
            this.txtBoxEmailRecipient.TabIndex = 3;
            this.txtBoxEmailRecipient.Visible = false;
            this.txtBoxEmailRecipient.TextChanged += new System.EventHandler(this.TxtBoxEmailRecipient_TextChanged);
            // 
            // lblEmailRecipient
            // 
            this.lblEmailRecipient.AutoSize = true;
            this.lblEmailRecipient.Location = new System.Drawing.Point(170, 16);
            this.lblEmailRecipient.Name = "lblEmailRecipient";
            this.lblEmailRecipient.Size = new System.Drawing.Size(77, 13);
            this.lblEmailRecipient.TabIndex = 4;
            this.lblEmailRecipient.Text = "email recipient:";
            this.lblEmailRecipient.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.lblEmailRecipient);
            this.Controls.Add(this.txtBoxEmailRecipient);
            this.Controls.Add(this.panelShelvesets);
            this.Controls.Add(this.lblShelvesetCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "My shelvesets";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblShelvesetCount;
        public System.Windows.Forms.Panel panelShelvesets;
        public System.Windows.Forms.TextBox txtBoxEmailRecipient;
        private System.Windows.Forms.Label lblEmailRecipient;
    }
}