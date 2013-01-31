// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShelvesetData.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   Defines the ShelvesetData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace QuickReview.Lib
{
    using System.Configuration;

    using Microsoft.TeamFoundation.VersionControl.Client;

    /// <summary>
    /// The shelveset data.
    /// </summary>
    public class ShelvesetData
    {
        /// <summary>
        /// Gets or sets the changes included in the shelveset.
        /// </summary>
        /// <value>
        /// The changes included in the shelveset.
        /// </value>
        public PendingChange[] Changes { get; set; }

        /// <summary>
        /// Gets or sets the shelveset owner.
        /// </summary>
        /// <value>
        /// The shelveset owner.
        /// </value>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the shelveset name.
        /// </summary>
        /// <value>
        /// The shelveset name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the shelveset comment.
        /// </summary>
        /// <value>
        /// The shelveset comment.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        /// <value>
        /// The project id.
        /// </value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the work items associated with the shelveset.
        /// </summary>
        /// <value>
        /// The work items associated with the shelveset.
        /// </value>
        public WorkItemCheckinInfo[] WorkItems { get; set; }

        /// <summary>
        /// Gets the url to the shelveset in team web access.
        /// </summary>
        /// <returns>
        /// The url to the shelveset in team web access.
        /// </returns>
        public string GetShelvesetPath()
        {
            return string.Format(
                Resource.ViewShelvesetUri,
                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                System.Web.HttpUtility.UrlEncode(this.Name),
                this.Owner,
                this.ProjectId);
        }

        /// <summary>
        /// Gets the url to the work item in team web access.
        /// </summary>
        /// <param name="workItemId">The work Item Id.</param>
        /// <returns>
        /// The url to the work item in team web access..
        /// </returns>
        public string GetWorkItemPath(int workItemId)
        {
            return string.Format(
                Resource.ViewWorkItemUri,
                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                workItemId,
                this.ProjectId);
        }

        /// <summary>
        /// Gets the internal representation of the pending change to be used in the template.
        /// </summary>
        /// <param name="change">The pending change.</param>
        /// <returns>The <see cref="ChangeConfig"/> object to use ion the template.</returns>
        public ChangeConfig GetChangeConfig(PendingChange change)
        {
            switch (change.ChangeType)
            {
                case ChangeType.Add | ChangeType.Edit | ChangeType.Encoding:
                case ChangeType.Add | ChangeType.Encoding:
                    return new ChangeConfig()
                        {
                            Colour = "green",
                            Text = "add",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                                change.ServerItem,
                                System.Web.HttpUtility.UrlEncode(this.Name),
                                this.Owner,
                                this.ProjectId),
                            LinkText = "view"
                        };
                case ChangeType.Edit:
                    return new ChangeConfig()
                        {
                            Colour = "black",
                            Text = "edit",
                            Link = string.Format(
                                Resource.DifferenceUri,
                                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                                change.SourceServerItem ?? change.ServerItem,
                                change.Version,
                                change.ServerItem,
                                System.Web.HttpUtility.UrlEncode(this.Name),
                               this.Owner,
                                this.ProjectId),
                            LinkText = "diff"
                        };
                case ChangeType.Edit | ChangeType.Rename:
                    return new ChangeConfig()
                        {
                            Colour = "black",
                            Text = "edit, rename",
                            Link = string.Format(
                                Resource.DifferenceUri,
                                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                                change.SourceServerItem,
                                change.Version,
                                change.ServerItem,
                                System.Web.HttpUtility.UrlEncode(this.Name),
                                this.Owner,
                                this.ProjectId),
                            LinkText = "diff"
                        };
                case ChangeType.Edit | ChangeType.Rollback:
                    return new ChangeConfig()
                        {
                            Colour = "black",
                            Text = "edit, rollback",
                            Link = string.Format(
                                Resource.DifferenceUri,
                                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                                change.SourceServerItem ?? change.ServerItem,
                                change.Version,
                                change.ServerItem,
                                System.Web.HttpUtility.UrlEncode(this.Name),
                                this.Owner,
                                this.ProjectId),
                            LinkText = "diff"
                        };
                case ChangeType.Edit | ChangeType.Undelete:
                    return new ChangeConfig()
                    {
                        Colour = "black",
                        Text = "undelete, edit",
                        Link = string.Format(
                            Resource.DifferenceUri,
                            ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                            change.SourceServerItem ?? change.ServerItem,
                            change.Version,
                            change.ServerItem,
                            System.Web.HttpUtility.UrlEncode(this.Name),
                            this.Owner,
                            this.ProjectId),
                        LinkText = "diff"
                    };
                case ChangeType.Edit | ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = "black",
                        Text = "merge, edit",
                        Link = string.Format(
                            Resource.DifferenceUri,
                            ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                            change.SourceServerItem ?? change.ServerItem,
                            change.Version,
                            change.ServerItem,
                            System.Web.HttpUtility.UrlEncode(this.Name),
                            this.Owner,
                            this.ProjectId),
                        LinkText = "diff"
                    };
                case ChangeType.Edit | ChangeType.Encoding | ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = "black",
                        Text = "merge, type, edit",
                        Link = string.Format(
                            Resource.DifferenceUri,
                            ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                            change.SourceServerItem ?? change.ServerItem,
                            change.Version,
                            change.ServerItem,
                            System.Web.HttpUtility.UrlEncode(this.Name),
                            this.Owner,
                            this.ProjectId),
                        LinkText = "diff"
                    };
                case ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = "black",
                        Text = "merge",
                        Link = string.Format(
                            Resource.ViewSourceUri,
                            ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                            change.ServerItem,
                            System.Web.HttpUtility.UrlEncode(this.Name),
                            this.Owner,
                            this.ProjectId),
                        LinkText = "view"
                    };
                case ChangeType.Delete:
                    return new ChangeConfig()
                        {
                            Colour = "red",
                            Text = "delete",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                                change.ServerItem,
                                System.Web.HttpUtility.UrlEncode(this.Name),
                                this.Owner,
                                this.ProjectId),
                            LinkText = "view"
                        };
                case ChangeType.Delete | ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = "red",
                        Text = "merge, delete",
                        Link = string.Format(
                            Resource.ViewSourceUri,
                            ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                            change.ServerItem,
                            System.Web.HttpUtility.UrlEncode(this.Name),
                            this.Owner,
                            this.ProjectId),
                        LinkText = "view"
                    };
                case ChangeType.Encoding | ChangeType.Branch:
                    return new ChangeConfig()
                        {
                            Colour = "black",
                            Text = "branch",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                                change.ServerItem,
                                System.Web.HttpUtility.UrlEncode(this.Name),
                                this.Owner,
                                this.ProjectId),
                            LinkText = "view"
                        };
                case ChangeType.Merge | ChangeType.Branch:
                    return new ChangeConfig()
                    {
                        Colour = "black",
                        Text = "merge, branch",
                        Link = string.Format(
                            Resource.ViewSourceUri,
                            ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                            change.ServerItem,
                            System.Web.HttpUtility.UrlEncode(this.Name),
                            this.Owner,
                            this.ProjectId),
                        LinkText = "view"
                    };
                case ChangeType.Rename:
                    return new ChangeConfig()
                        {
                            Colour = "black",
                            Text = "rename",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                                change.ServerItem,
                                System.Web.HttpUtility.UrlEncode(this.Name),
                                this.Owner,
                                this.ProjectId),
                            LinkText = "view"
                        };
                case ChangeType.Undelete:
                    return new ChangeConfig()
                        {
                            Colour = "green",
                            Text = "undelete",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                ConfigurationManager.AppSettings.Get("teamWebAccessUrl"),
                                change.ServerItem,
                                System.Web.HttpUtility.UrlEncode(this.Name),
                                this.Owner,
                                this.ProjectId),
                            LinkText = "view"
                        };

                case ChangeType.None:
                case ChangeType.Encoding:                
                case ChangeType.Branch:                
                case ChangeType.Lock:
                case ChangeType.Rollback:
                case ChangeType.SourceRename:
                    return new ChangeConfig()
                        {
                            Colour = "red",
                            Text = "undefined, please drop me an email.",
                            Link = "bokobza@gmail.com",
                            LinkText = "email"
                        };
                default:
                    return new ChangeConfig()
                        {
                            Colour = "red",
                            Text = "undefined, please drop me an email.",
                            Link = "bokobza@gmail.com",
                            LinkText = "email"
                        };
            }
        }
    }
}