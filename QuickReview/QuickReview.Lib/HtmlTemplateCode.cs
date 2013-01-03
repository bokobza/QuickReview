// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTemplateCode.cs">
//  Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   Partial class to be used with the template.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace QuickReview.Lib
{
    /// <summary>
    /// Partial class to be used with the template.
    /// </summary>
    public partial class HtmlTemplate
    {
        /// <summary>
        /// Object to be used in the template.
        /// </summary>
        private readonly ShelvesetData shelvesetData;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTemplate"/> class. 
        /// </summary>
        /// <param name="shelvesetData">
        /// The object containing all the data for the template.
        /// </param>
        public HtmlTemplate(ShelvesetData shelvesetData)
        {
            this.shelvesetData = shelvesetData;
        }
    }
}
