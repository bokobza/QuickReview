// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsBox.cs" company="">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   Defines the settings form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Outlook
{
    using QuickReview.Lib;
    using QuickReview.Outlook.Properties;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The settings form
    /// </summary>
    public partial class SettingsBox : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsBox"/> class.
        /// </summary>
        public SettingsBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close the form on escape.
        /// </summary>
        /// <param name="msg">the msg</param>
        /// <param name="keyData">the key data</param>
        /// <returns>
        /// true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Handles the Click event of the btnCancelSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnOKSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOKSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EmailRecipient = this.txtBoxEmailRecipient.Text;
            
            // save the url to TFS and try to reconnect to it
            var url = this.txtBoxTeamServerUrl.Text;
            Properties.Settings.Default.TeamServerUrl = url;
            
            Uri uriResult;            
            if (!string.IsNullOrEmpty(url) && Uri.TryCreate(url, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
            {
                try
                {
                    TfsConnect.Initialize(url);
                }
                catch (Exception)
                {
                    TfsConnect.isInitialized = false;
                }                
            }
            else
            {
                TfsConnect.isInitialized = false;
            }

            this.Close();
        }

        /// <summary>
        /// Handles the Load event of the SettingsBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SettingsBox_Load(object sender, EventArgs e)
        {
            this.Location = Settings.Default.SettingsWindowsLocation;
            this.txtBoxEmailRecipient.Text = string.IsNullOrEmpty(Properties.Settings.Default.EmailRecipient) ? Properties.Resources.EmailRecipientBoxMessage : Properties.Settings.Default.EmailRecipient;
            this.txtBoxTeamServerUrl.Text = string.IsNullOrEmpty(Properties.Settings.Default.TeamServerUrl) ? Properties.Resources.TeamServerUrlBoxMessage : Properties.Settings.Default.TeamServerUrl;
        }

        /// <summary>
        /// Handles the FormClosed event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs" /> instance containing the event data.</param>
        private void SettingsBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.SettingsWindowsLocation = this.Location;
            Settings.Default.Save();
        }
    }
}
