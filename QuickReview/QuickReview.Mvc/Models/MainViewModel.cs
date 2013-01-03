// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   The main view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace QuickReview.Mvc.Models
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel
    {      
        /// <summary>
        /// Gets or sets the collection of users for the dropdown list.
        /// </summary>
        public IEnumerable<SelectListItem> UsersChoice { get; set; }

        /// <summary>
        /// Gets or sets the collection of shelvesets for the user.
        /// </summary>
        public IEnumerable<ShelvesetModel> Shelvesets { get; set; }

        /// <summary>
        /// Gets or sets the user selected in the dropdown list.
        /// </summary>
        public string SelectedUser { get; set; }

        /// <summary>
        /// Gets or sets the shelveset selected for the review.
        /// </summary>
        public string SelectedShelveset { get; set; }
    }
}