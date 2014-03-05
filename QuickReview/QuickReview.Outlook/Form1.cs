﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// Handles the TextChanged event of the txtBoxEmailRecipient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TxtBoxEmailRecipient_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EmailRecipient = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Handles the FormClosed event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.WindowsLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = Properties.Settings.Default.WindowsLocation;
        }
    }
}
