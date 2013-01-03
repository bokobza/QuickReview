// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeConfig.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   Defines the ChangeConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Lib
{
    /// <summary>
    /// Simple object to hold the. 
    /// </summary>
    public class ChangeConfig
    {
        /// <summary>
        /// Gets or sets the colour of the link.
        /// </summary>
        /// <value>
        /// The colour of the link.
        /// </value>
        public string Colour { get; set; }

        /// <summary>
        /// Gets or sets the text for the change type.
        /// </summary>
        /// <value>
        /// The text for the change type.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the link to the item.
        /// </summary>
        /// <value>
        /// The link to the item to show.
        /// </value>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the text for the link.
        /// </summary>
        /// <value>
        /// The text for the link.
        /// </value>
        public string LinkText { get; set; }
    }
}