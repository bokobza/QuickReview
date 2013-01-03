// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewModel.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   The review model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Mvc.Models
{
    /// <summary>
    /// The review model.
    /// </summary>
    public class ReviewModel
    {
        /// <summary>
        /// Gets or sets the shelveset report.
        /// </summary>
        public string ShelvesetReport { get; set; }

        /// <summary>
        /// Gets or sets the shelveset name.
        /// </summary>
        public string ShelvesetName { get; set; }
    }
}