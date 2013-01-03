// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//  The main class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace QuickReview.Console
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using QuickReview.Lib;

    /// <summary>
    /// The main class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The application main.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            // initialize the connection to TFS.
            TfsConnect.Initialize(ConfigurationManager.AppSettings.Get("teamProjectUrl"));

            // set up the menu.
            int shelvesetToShow;
            int.TryParse(ConfigurationManager.AppSettings.Get("shelvesetToShow"), out shelvesetToShow);
            var menu = new Dictionary<string, string>();
            if (shelvesetToShow > 0)
            {
                Console.WriteLine(LocalizableResource.introText + Environment.NewLine);
                var orderedShelvesets = TfsConnect.GetOrderedShelvesets(TfsConnect.CurrentUser);
                for (var i = 0; i < System.Math.Min(shelvesetToShow, orderedShelvesets.Count); i++)
                {
                    Console.WriteLine(i + 1 + " " + orderedShelvesets[i].Name);
                    menu.Add((i + 1).ToString(), orderedShelvesets[i].Name);
                }
            }

            // get user input and creates the code review report
            while (true)
            {
                Console.Write(Environment.NewLine + string.Format("Shelveset ({0}-{1}): ", 1, menu.Count));
                var userInput = Console.ReadLine();

                if (userInput == "exit" || userInput == "kill")
                {
                    Environment.Exit(0);
                }

                if (!string.IsNullOrEmpty(userInput))
                {
                    userInput = userInput.Replace("\"", string.Empty);
                }

                if (string.IsNullOrEmpty(userInput))
                {
                    continue;
                }

                string shelvesetName, shelvesetOwnerName;
                if (userInput.Contains("\\"))
                {
                    var values = userInput.Split('\\');
                    shelvesetOwnerName = values[0];
                    shelvesetName = values[1];
                }
                else if (menu.ContainsKey(userInput))
                {
                    // get the shelveset name and the owner name.
                    menu.TryGetValue(userInput, out shelvesetName);
                    shelvesetOwnerName = TfsConnect.CurrentUser;
                }
                else
                {
                    shelvesetName = userInput;
                    shelvesetOwnerName = TfsConnect.CurrentUser;
                }

                ShelvesetReport shelvesetReport = new ShelvesetReport(shelvesetName, shelvesetOwnerName);
                if (shelvesetReport.Exception == null)
                {
                    // open in browser.
                    if (bool.Parse(ConfigurationManager.AppSettings.Get("openInBrowser")))
                    {
                        // save as file.
                        string pathName = shelvesetReport.SaveHtmlFile(shelvesetName, ConfigurationManager.AppSettings.Get("outputFolder"), true);
                        Console.WriteLine(string.Format(LocalizableResource.doneSavingFile, pathName));
                    }

                    // open in email.
                    if (bool.Parse(ConfigurationManager.AppSettings.Get("openAsEmail")))
                    {
                        Console.WriteLine(LocalizableResource.doneCreatingEmail);
                        shelvesetReport.PrepareEmail(ConfigurationManager.AppSettings["mailTo"]);
                    }
                }
                else
                {
                    Console.WriteLine(shelvesetReport.Exception.Message);
                }
            }
        }       
    }
}
