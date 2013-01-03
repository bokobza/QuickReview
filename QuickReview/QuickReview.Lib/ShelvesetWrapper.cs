// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShelvesetWrapper.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   A wrapper class for the Microsoft.TeamFoundation.VersionControl.Client.Shelveset object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Lib
{
    using System;

    /// <summary>
    /// Class representing a shelveset.
    /// </summary>
    public class ShelvesetWrapper
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the owner display name.
        /// </summary>
        public string OwnerDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the owner name.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets the policy override comment.
        /// </summary>
        public string PolicyOverrideComment { get; set; }

        #endregion
    }
} 