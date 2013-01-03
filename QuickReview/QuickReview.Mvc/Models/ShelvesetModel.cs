// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShelvesetModel.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   The shelveset model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace QuickReview.Mvc.Models
{
    using System;

    /// <summary>
    /// The shelveset model.
    /// </summary>
    public class ShelvesetModel
    {
        /// <summary>
        /// Gets or sets the name of the shelveset.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date the shelveset was created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the name of the shelveset's owner.
        /// </summary>
        public string OwnerName { get; set; }
    }
}