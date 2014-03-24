// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ribbon1.cs" company="">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   Defines the Ribbon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon1();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.
// http://msdn.microsoft.com/en-us/library/aa338202.aspx


namespace QuickReview.Outlook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using QuickReview.Lib;

    using stdole;

    using Font = System.Drawing.Font;
    using Office = Microsoft.Office.Core;

    /// <summary>
    /// The Ribbon
    /// </summary>
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        /// <summary>
        /// The ribbon
        /// </summary>
        private Office.IRibbonUI ribbon;

        /// <summary>
        /// The button height
        /// </summary>
        private const int ButtonHeight = 40;

        /// <summary>
        /// The point asynchronous
        /// </summary>
        private int pointY;

        /// <summary>
        /// The form
        /// </summary>
        private Form1 form;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ribbon1"/> class.
        /// </summary>
        public Ribbon1()
        {
            
        }

        #region IRibbonExtensibility Members

        /// <summary>
        /// Gets the custom unique identifier.
        /// </summary>
        /// <param name="ribbonID">The ribbon unique identifier.</param>
        /// <returns>The string</returns>
        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("QuickReview.Outlook.Ribbon1.xml");
        }

        #endregion

        #region Ribbon Callbacks
        
        /// <summary>
        /// Ribbon_s the load.
        /// </summary>
        /// <param name="ribbonUI">The ribbon unique identifier.</param>
        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            this.ribbon.Invalidate();
        }

        /// <summary>
        /// Callback for setting the text in the editBox.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>The text to put in the editBox</returns>
        public string EmailRecipientBoxCallbackSetText(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "emailRecipientBox":
                    return string.IsNullOrEmpty(Properties.Settings.Default.EmailRecipient) ? "Default recipient" : Properties.Settings.Default.EmailRecipient;
                default:
                    return string.Empty;
            }            
        }

        /// <summary>
        /// Callback for persisting the text entered in the editbox to the settings.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="text">The text.</param>
        public void EmailRecipientBoxCallbackOnChange(Office.IRibbonControl control, string text)
        {
            Properties.Settings.Default.EmailRecipient = text;
        }

        #endregion

        /// <summary>
        /// Called when [change edit box].
        /// </summary>
        /// <param name="control">The control.</param>
        public void OnChangeEditBox(Office.IRibbonControl control)
        {
            Properties.Settings.Default.EmailRecipient = control.Context.Text;
        }

        /// <summary>
        /// Called when [shelvesets button].
        /// </summary>
        /// <param name="control">The control.</param>
        public void OnShelvesetsButton(Office.IRibbonControl control)
        {
            this.pointY = 0;
            var orderedShelvesets = TfsConnect.GetOrderedShelvesets(TfsConnect.CurrentUser);

            // we should only have one instance of the form
            if (this.form != null && !this.form.IsDisposed)
            {
                if (this.form.WindowState == FormWindowState.Minimized)
                    this.form.WindowState = FormWindowState.Normal;
                this.form.Focus();
                this.form.BringToFront();
                return;
            }

            this.form = new Form1
                {
                    Text = "Shelvesets for " + TfsConnect.CurrentUser,
                    lblShelvesetCount = { Text = orderedShelvesets.Count + " shelvesets" },
                };
            this.form.lblShelvesetCount.Font = new Font(this.form.lblShelvesetCount.Font, FontStyle.Bold);

            var buttons = new List<Button>();          
            for (var i = 0; i < orderedShelvesets.Count; i++)
            {
                Console.WriteLine(i + 1 + " " + orderedShelvesets[i].Name);
                buttons.Add(this.createButton(orderedShelvesets[i]));
                this.pointY += ButtonHeight;
            }

            foreach (var b in buttons)
            {
                this.form.panelShelvesets.Controls.Add(b);
            }

            this.form.Show();           
        }

        /// <summary>
        /// Called when [about button].
        /// </summary>
        /// <param name="control">The control.</param>
        public void OnAboutButton(Office.IRibbonControl control)
        {
            var about = new AboutBox1 
            {
                richTextBox1 =
                {
                    Rtf = Properties.Resources.about1
                } 
            };
            about.ShowDialog();
        }

        /// <summary>
        /// Gets the image callback.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>The picture to display</returns>
        public IPictureDisp GetImageCallback(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "shelvesetsButton":
                    return PictureConverter.ImageToPictureDisp(Properties.Resources._3);            
                case "aboutButton":
                    return PictureConverter.ImageToPictureDisp(Properties.Resources.about);      
                default:
                    return null;
            }            
        }

        /// <summary>
        /// Handles the Click event of the b control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            var shelvesetReport = new ShelvesetReport(((Button)sender).Tag.ToString(), TfsConnect.CurrentUser);
            shelvesetReport.PrepareEmail(string.IsNullOrEmpty(Properties.Settings.Default.EmailRecipient) ? string.Empty : Properties.Settings.Default.EmailRecipient);            
        }

        /// <summary>
        /// Creates a button.
        /// </summary>
        /// <param name="sw">The shelveset wrapper.</param>
        /// <returns>The button</returns>
        private Button createButton(ShelvesetWrapper sw)
        {
            var b = new Button
            {
                Tag = sw.Name,
                BackColor = SystemColors.Control,
                Location = new System.Drawing.Point(0, this.pointY),
                Size = new System.Drawing.Size(this.form.panelShelvesets.Width, ButtonHeight),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                
            };
            
            var lblShelvesetName = new Label
            {
                Text = sw.Name,
                AutoSize = true,
                Location = new Point(10, 10),
                
            };

            lblShelvesetName.Font = new Font(lblShelvesetName.Font.ToString(), lblShelvesetName.Font.Size, FontStyle.Regular);
            
            var lblShelvesetDate = new Label
            {
                Text = string.Format("{0:g}", sw.CreationDate),
                AutoSize = true,
                Anchor = AnchorStyles.Right

            };

            lblShelvesetDate.Location = new Point(b.Width - lblShelvesetDate.Width - 5, 10);

            b.Controls.Add(lblShelvesetName);
            b.Controls.Add(lblShelvesetDate);
            b.Click += this.Button_Click;
            foreach (Control control in b.Controls)
            {
                control.Click += (UserControl1, EventArgs) => this.Button_Click(b, EventArgs.Empty);
            }

            return b;
        }
      
        #region Helpers

        /// <summary>
        /// Gets the resource text.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns></returns>
        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// A class used to convert an image/icon to an IPictureDisp.
        /// </summary>
        internal class PictureConverter : AxHost
        {
            /// <summary>
            /// Prevents a default instance of the <see cref="PictureConverter"/> class from being created.
            /// </summary>
            private PictureConverter() : base(String.Empty) { }

            /// <summary>
            /// Images the automatic picture disp.
            /// </summary>
            /// <param name="image">The image.</param>
            /// <returns></returns>
            static public stdole.IPictureDisp ImageToPictureDisp(Image image)
            {
                return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
            }

            /// <summary>
            /// Icons the automatic picture disp.
            /// </summary>
            /// <param name="icon">The icon.</param>
            /// <returns></returns>
            static public stdole.IPictureDisp IconToPictureDisp(Icon icon)
            {
                return ImageToPictureDisp(icon.ToBitmap());
            }

            /// <summary>
            /// Pictures the disp automatic image.
            /// </summary>
            /// <param name="picture">The picture.</param>
            /// <returns></returns>
            static public Image PictureDispToImage(stdole.IPictureDisp picture)
            {
                return GetPictureFromIPicture(picture);
            }
        }
    }
}
