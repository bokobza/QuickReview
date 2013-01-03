// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShelvesetReport.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   The shelveset report.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Lib
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using Outlook = Microsoft.Office.Interop.Outlook;

    /// <summary>
    /// The shelveset report.
    /// </summary>
    public class ShelvesetReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShelvesetReport"/> class. 
        /// </summary>
        /// <param name="shelvesetName">
        /// The name of the shelveset.
        /// </param>
        /// <param name="shelvesetOwnerName">
        /// The owner of the shelveset.
        /// </param>
        public ShelvesetReport(string shelvesetName, string shelvesetOwnerName)
        {
            this.ShelvesetName = shelvesetName;
            this.ShelvesetOwnerName = shelvesetOwnerName;
            this.ReportBody = this.CreateShelvesetReport(shelvesetName, shelvesetOwnerName);
        }
        
        /// <summary>
        /// Gets an error that might have happened.
        /// </summary>
        public Exception Exception { get; private set; }
        
        /// <summary>
        /// Gets the content of the report, HTML formatted.
        /// </summary>
        public string ReportBody { get; private set; }

        /// <summary>
        /// Gets or sets the name of the shelveset.
        /// </summary>
        private string ShelvesetName { get; set; }

        /// <summary>
        /// Gets or sets the owner of the shelveset.
        /// </summary>
        private string ShelvesetOwnerName { get; set; }

        /// <summary>
        /// Prepares the email including the report.
        /// </summary>
        /// <param name="recipient">The recipient of the email.</param>
        public void PrepareEmail(string recipient)
        {
            try
            {
                var outlook = new Outlook.Application();
                var mail = (Outlook.MailItem)outlook.CreateItem(Outlook.OlItemType.olMailItem);
                mail.HTMLBody = this.ReportBody;
                mail.Subject = "Code review for shelveset [" + this.ShelvesetName + "]";
                mail.To = recipient;
                mail.Display(false);
            }
            catch (COMException exception)
            {
                if (!exception.Message.Contains("Operation aborted"))
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Saves an HTML file with the report.
        /// </summary>
        /// <param name="filename">The name of the file.</param>
        /// <param name="outputFolder">The folder in which to save the report.</param>
        /// <param name="openAfterSave">A value indicating whether to open the file after saving it.</param>
        /// <returns>The full path of the file.</returns>
        public string SaveHtmlFile(string filename, string outputFolder, bool openAfterSave)
        {
            // save as file.
            outputFolder = outputFolder.EndsWith("\\") ? outputFolder : outputFolder + "\\";

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string pathName = outputFolder + filename + ".html";
            File.WriteAllText(pathName, this.ReportBody);

            if (openAfterSave)
            {
                Process.Start(pathName);
            }

            return pathName;
        }

        /// <summary>Creates the shelveset report.</summary>
        /// <param name="shelvesetName">The name of the shelveset.</param>
        /// <param name="shelvesetOwnerName">The shelveset Owner Name.</param>
        /// <returns>The populated report template.</returns>
        private string CreateShelvesetReport(string shelvesetName, string shelvesetOwnerName)
        {
            try
            {
                var shelvesets = TfsConnect.GetShelveset(shelvesetName, shelvesetOwnerName);
                if (shelvesets.Length > 0)
                {
                    var sets = TfsConnect.GetShelvesetChanges(shelvesets[0]);
                    var data = new ShelvesetData
                    {
                        Changes = sets[0].PendingChanges,
                        ProjectId = TfsConnect.ProjectId,
                        Name = shelvesetName,
                        Owner = sets[0].OwnerName,
                        Comment = string.IsNullOrEmpty(shelvesets[0].Comment) ? string.Empty : shelvesets[0].Comment,
                        WorkItems = shelvesets[0].WorkItemInfo
                    };

                    var page = new HtmlTemplate(data);
                    return page.TransformText();
                }
                else
                {
                    this.Exception = new ShelvesetNotFoundException(string.Format(ErrorMessages.shelvesetNotFound, shelvesetName, shelvesetOwnerName));
                }
            }
            catch (IdentityNotFoundException)
            {
                this.Exception = new UserNotFoundException(string.Format(ErrorMessages.userNotFound, shelvesetOwnerName));
            }

            return string.Empty;
        }
    }
}
