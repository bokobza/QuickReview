// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityWrapper.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   A wrapper class for the user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Lib
{
    /// <summary>
    /// Class representing a user.
    /// </summary>
    public class IdentityWrapper
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the unique name.
        /// </summary>
        public string UniqueName { get; set; }
    }
}
