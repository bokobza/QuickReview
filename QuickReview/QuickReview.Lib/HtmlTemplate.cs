// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace QuickReview.Lib
{
    using System;
    
    
    #line 1 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class HtmlTemplate : HtmlTemplateBase
    {
        public virtual string TransformText()
        {
            this.Write("\r\n<html lang=\"en\">\r\n    <head>\r\n        <!--<link rel=\'stylesheet\' type=\'text/css" +
                    "\'  href=\'report.css\'/>-->\r\n\r\n<style type=\"text/css\">\r\n        \r\na:link\r\n{\r\n    c" +
                    "olor: blue;\r\n}\r\na:visited\r\n{\r\n    color: purple;\r\n}\r\n\r\n.bold\r\n{\r\n    font-weight" +
                    ": bold\r\n}  \r\n\r\ntable.detailsTable, table.workItemTable, table.changesTable\r\n{\r\n " +
                    "   border-collapse: collapse;          \r\n    border: 0;      \r\n    margin-left: " +
                    "10px;\r\n    margin-right: 10px;\r\n}\r\n     \r\ntable.detailsTable td, table.workItemT" +
                    "able td, table.changesTable td\r\n{\r\n    border: none; \r\n    border-right: solid w" +
                    "hite 1.0pt; \r\n    margin: 0cm;\r\n    margin-bottom: .0001pt;\r\n    font-size: 12.0" +
                    "pt;\r\n    font-family: \"Calibri\",\"sans-serif\";\r\n}   \r\n     \r\ntr.changesRow td\r\n{\r" +
                    "\n    background: #DEE8F2;\r\n    padding: 1.45pt 3.6pt 1.45pt 3.6pt;        \r\n}\r\n " +
                    "       \r\ntr.changesRow td.small\r\n{\r\n    font-size:10.0pt;\r\n}\r\n        \r\ntr.topRo" +
                    "w td\r\n{\r\n    background: #3D5277;\r\n    padding: 1.45pt 3.6pt 1.45pt 3.6pt;\r\n    " +
                    "text-align: center;\r\n    color: white;\r\n    font-weight: bold\r\n}\r\n        \r\ntabl" +
                    "e.detailsTable tr td\r\n{\r\n    padding: 0cm 3.6pt 0cm 0cm;   \r\n    color: #3D5277;" +
                    "              \r\n}\r\n     \r\ntable.workItemTable tr td\r\n{\r\n    padding: 0cm 3.6pt 0" +
                    "cm 0cm;\r\n    color: #3D5277;          \r\n    font-size: 10.0pt;    \r\n}        \r\n " +
                    "      \r\ntable.workItemTable tr td.title\r\n{\r\n    padding: 0cm 1.6pt 0cm 0cm\r\n}\r\n " +
                    "      \r\ntable.workItemTable tr td.checkinAction\r\n{\r\n    padding: 0cm 50.6pt 0cm " +
                    "0cm\r\n}\r\n        \r\n</style>\r\n\r\n    </head>\r\n\r\n<body>\r\n    &nbsp;\r\n    <table clas" +
                    "s=\"detailsTable\">\r\n        <tr>\r\n            <td class=\"bold\">Team Project Colle" +
                    "ction:</td>\r\n            <td>");
            
            #line 93 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.shelvesetData.Changes[0].VersionControlServer.TeamProjectCollection.Name));
            
            #line default
            #line hidden
            this.Write("</td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"bold\">Shelveset:</td>\r" +
                    "\n            <td><a href=");
            
            #line 97 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.shelvesetData.GetShelvesetPath()));
            
            #line default
            #line hidden
            this.Write(" target=\"_blank\">");
            
            #line 97 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.shelvesetData.Owner + "\\" + this.shelvesetData.Name));
            
            #line default
            #line hidden
            this.Write("</a></td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"bold\">Comment:</td" +
                    ">\r\n            <td>");
            
            #line 101 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.shelvesetData.Comment));
            
            #line default
            #line hidden
            this.Write("</td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"bold\">Work items:</td>" +
                    "\r\n        </tr>\r\n    </table>\r\n\r\n    <table class=\"workItemTable\">\r\n        ");
            
            #line 109 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
 foreach(var item in this.shelvesetData.WorkItems)
                        { var workItem = item.WorkItem;
                        
            
            #line default
            #line hidden
            this.Write("        <tr>\r\n            <td>\r\n                <a href=");
            
            #line 114 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.shelvesetData.GetWorkItemPath(workItem.Id)));
            
            #line default
            #line hidden
            this.Write(" target=\"_blank\">");
            
            #line 114 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(workItem.Id));
            
            #line default
            #line hidden
            this.Write("</a>\r\n            </td>\r\n            <td class=\"checkinAction\">");
            
            #line 116 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(workItem.Type.Name + " [" + item.CheckinAction + "]"));
            
            #line default
            #line hidden
            this.Write("</td>\r\n            <td class=\"title\">");
            
            #line 117 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(workItem.Title));
            
            #line default
            #line hidden
            this.Write("</td>\r\n        </tr>\r\n            ");
            
            #line 119 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    </table>\r\n\r\n    &nbsp;\r\n\r\n    <table class=\"changesTable\">\r\n        <tr class" +
                    "=\"topRow\">\r\n            <td>Folder</td>\r\n            <td>File name</td>\r\n       " +
                    "     <td>Status</td>\r\n            <td>Link</td>\r\n        </tr>\r\n        ");
            
            #line 131 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
 foreach(var change in this.shelvesetData.Changes)
                { var changeConfig = this.shelvesetData.GetChangeConfig(change);
                
            
            #line default
            #line hidden
            this.Write(" \r\n        <tr class=\"changesRow\">\r\n            <td class=\"small\">");
            
            #line 135 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(change.LocalOrServerFolder));
            
            #line default
            #line hidden
            this.Write("</td>\r\n            <td>");
            
            #line 136 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(change.FileName));
            
            #line default
            #line hidden
            this.Write("</td>\r\n            <td><span style=\'color:");
            
            #line 137 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(changeConfig.Colour));
            
            #line default
            #line hidden
            this.Write("\'>");
            
            #line 137 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(changeConfig.Text));
            
            #line default
            #line hidden
            this.Write("</span></td>\r\n            <td><a href=");
            
            #line 138 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(changeConfig.Link));
            
            #line default
            #line hidden
            this.Write(" target=\"_blank\">");
            
            #line 138 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(changeConfig.LinkText));
            
            #line default
            #line hidden
            this.Write("</a>\r\n            </td>\r\n        </tr>\r\n            ");
            
            #line 141 "C:\Users\jeremy\Documents\CodePlex\QuickReview\QuickReview.Lib\HtmlTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    </table>    \r\n    \r\n     &nbsp;\r\n</body>\r\n</html>\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public class HtmlTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
