// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThisAddIn.cs" company="">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   Defines the add in.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Outlook
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using QuickReview.Lib;

    using Office = Microsoft.Office.Core;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// The add in 
    /// </summary>
    public partial class ThisAddIn
    {
        /// <summary>
        /// Returns an object that implements the Microsoft.Office.Core.IRibbonExtensibility interface.
        /// </summary>
        /// <returns>
        /// An object that implements the Microsoft.Office.Core.IRibbonExtensibility interface.
        /// </returns>
        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {   
            return new Ribbon1();
        }

        /// <summary>
        /// Handles the Startup event of the ThisAddIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // initialize the connection to TFS.
            var url = Properties.Settings.Default.TeamServerUrl;
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
        }

        /// <summary>
        /// Handles the Shutdown event of the ThisAddIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
