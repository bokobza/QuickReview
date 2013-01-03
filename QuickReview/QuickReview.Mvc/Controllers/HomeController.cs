﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace QuickReview.Mvc.Controllers
{
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;

    using QuickReview.Lib;
    using QuickReview.Mvc.Models;

    // TODO make the page prettier    

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>The index.</summary>
        /// <param name="user">The user.</param> 
        /// <returns>The default view.</returns>
        public ActionResult Index(string user)
        {            
            TfsConnect.Initialize(ConfigurationManager.AppSettings.Get("teamProjectUrl"));

            string selectedUser = user ?? TfsConnect.CurrentUser;

            MainViewModel model = new MainViewModel();
            model.UsersChoice = from IdentityWrapper id in TfsConnect.Users
                                select new SelectListItem()
                                {
                                    Text = id.DisplayName,
                                    Value = id.UniqueName,
                                    Selected = selectedUser == id.UniqueName
                                };
            model.Shelvesets = from sh in TfsConnect.GetOrderedShelvesets(selectedUser)
                               select new ShelvesetModel
                                   {
                                       Name = sh.Name,
                                       DateCreated = sh.CreationDate,
                                       OwnerName = sh.OwnerName
                                   };
            
            return this.View(model);
        }

        /// <summary> The index. </summary>
        /// <param name="model"> The model. </param>
        /// <returns> The view after the user has been selected. </returns>
        [HttpPost]
        public ActionResult Index(MainViewModel model)
        {
            model.UsersChoice = from IdentityWrapper id in TfsConnect.Users
                                select new SelectListItem()
                                {
                                    Text = id.DisplayName,
                                    Value = id.UniqueName,
                                    Selected = model.SelectedUser == id.DisplayName
                                };
            model.Shelvesets = from sh in TfsConnect.GetOrderedShelvesets(model.SelectedUser)
                               select new ShelvesetModel
                               {
                                   Name = sh.Name,
                                   DateCreated = sh.CreationDate,
                                   OwnerName = sh.OwnerName
                               };
            return this.View(model);
        }

        /// <summary>The create report.</summary>
        /// <param name="shelveset">The shelveset.</param>
        /// <param name="emailRecipient">The email recipient.</param>
        /// <returns>The default view.</returns>
        [HttpPost]
        public ActionResult CreateEmail(ShelvesetModel shelveset, string emailRecipient)
        {
            // create the email.
            ShelvesetReport shelvesetReport = new ShelvesetReport(shelveset.Name, shelveset.OwnerName);
            shelvesetReport.PrepareEmail(emailRecipient);
            return this.RedirectToAction("Index", new { user = shelveset.OwnerName });
        }

        /// <summary> The create report.  </summary>
        /// <param name="shelveset"> The shelveset. </param>
        /// <returns> The default view.  </returns>
        public ActionResult Review(ShelvesetModel shelveset)
        {
            ShelvesetReport shelvesetReport = new ShelvesetReport(shelveset.Name, shelveset.OwnerName);
            return this.View("Review", new ReviewModel() { ShelvesetName = shelveset.Name, ShelvesetReport = shelvesetReport.ReportBody });
        }

        /// <summary> The About page. </summary>
        /// <returns> The About page view. </returns>
        public ActionResult About()
        {
            this.ViewBag.Message = "Your app description page.";
            return this.View();
        }
    }
}
