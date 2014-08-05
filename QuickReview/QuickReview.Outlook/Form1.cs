// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   Defines the Form1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Outlook
{
    using System;
    using System.Windows.Forms;

    using QuickReview.Outlook.Properties;

    /// <summary>
    /// The form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Close the form on escape.
        /// </summary>
        /// <param name="msg">the msg</param>
        /// <param name="keyData">the key data</param>
        /// <returns></returns>
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
        /// Handles the FormClosed event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.WindowsLocation = this.Location;
            Settings.Default.WindowsSize = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;

            Settings.Default.Save();
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = Settings.Default.WindowsLocation;
            this.Size = Settings.Default.WindowsSize;            
        }
    }
}
