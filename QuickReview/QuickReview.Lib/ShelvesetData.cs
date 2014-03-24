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
    using System;
    using System.Configuration;

    using Microsoft.TeamFoundation.VersionControl.Client;

    /// <summary>
    /// The shelveset data.
    /// </summary>
    public class ShelvesetData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShelvesetData"/> class
        /// </summary>
        public ShelvesetData()
        {

            this.TeamWebAccessUrl = TfsConnect.TfsWebAddress;
        }

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
        /// Gets the link to the Team Web Access URL, from the config
        /// </summary>
        public string TeamWebAccessUrl { get; private set; }

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
                this.TeamWebAccessUrl,
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
                this.TeamWebAccessUrl,
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
            string projectId = this.ProjectId;
            string owner = Uri.EscapeDataString(this.Owner);
            string shelvesetName = Uri.EscapeDataString(this.Name);
            string serverItem = change.ServerItem != null ? Uri.EscapeDataString(change.ServerItem) : null;
            string sourceServerItem = change.SourceServerItem != null ? Uri.EscapeDataString(change.SourceServerItem) : null;
            int version = change.Version;

            switch (change.ChangeType)
            {
                case ChangeType.Add | ChangeType.Edit | ChangeType.Encoding:
                case ChangeType.Add | ChangeType.Encoding:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Green,
                            Text = "add",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                this.TeamWebAccessUrl,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                            LinkText = ChangeConfigConstants.LinkText.View
                        };
                case ChangeType.Edit:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Black,
                            Text = "edit",
                            Link = string.Format(
                                Resource.DifferenceUri,
                                this.TeamWebAccessUrl,
                                sourceServerItem ?? serverItem,
                                version,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                            LinkText = ChangeConfigConstants.LinkText.Difference
                        };
                case ChangeType.Edit | ChangeType.Rename:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Black,
                            Text = "edit, rename",
                            Link = string.Format(
                                Resource.DifferenceUri,
                                this.TeamWebAccessUrl,
                                sourceServerItem,
                                version,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                            LinkText = ChangeConfigConstants.LinkText.Difference
                        };
                case ChangeType.Edit | ChangeType.Rename | ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Black,
                        Text = "merge, rename, edit",
                        Link = string.Format(
                            Resource.DifferenceUri,
                            this.TeamWebAccessUrl,
                            sourceServerItem,
                            version,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.Difference
                    };
                case ChangeType.Edit | ChangeType.Rollback:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Black,
                            Text = "edit, rollback",
                            Link = string.Format(
                                Resource.DifferenceUri,
                                this.TeamWebAccessUrl,
                                sourceServerItem ?? serverItem,
                                version,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                            LinkText = ChangeConfigConstants.LinkText.Difference
                        };
                case ChangeType.Delete | ChangeType.Rollback:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Red,
                        Text = "delete, rollback",
                        Link = string.Format(
                                Resource.ViewSourceUri,
                                this.TeamWebAccessUrl,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                        LinkText = ChangeConfigConstants.LinkText.View
                    };
                case ChangeType.Edit | ChangeType.Undelete:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Black,
                        Text = "undelete, edit",
                        Link = string.Format(
                            Resource.DifferenceUri,
                            this.TeamWebAccessUrl,
                            sourceServerItem ?? serverItem,
                            version,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.Difference
                    };
                case ChangeType.Edit | ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Black,
                        Text = "merge, edit",
                        Link = string.Format(
                            Resource.DifferenceUri,
                            this.TeamWebAccessUrl,
                            sourceServerItem ?? serverItem,
                            version,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.Difference
                    };
                case ChangeType.Edit | ChangeType.Encoding | ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Black,
                        Text = "merge, type, edit",
                        Link = string.Format(
                            Resource.DifferenceUri,
                            this.TeamWebAccessUrl,
                            sourceServerItem ?? serverItem,
                            version,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.Difference
                    };
                case ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Black,
                        Text = "merge",
                        Link = string.Format(
                            Resource.ViewSourceUri,
                            this.TeamWebAccessUrl,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.View
                    };
                case ChangeType.Delete:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Red,
                            Text = "delete",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                this.TeamWebAccessUrl,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                            LinkText = ChangeConfigConstants.LinkText.View
                        };
                case ChangeType.Delete | ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Red,
                        Text = "merge, delete",
                        Link = string.Format(
                            Resource.ViewSourceUri,
                            this.TeamWebAccessUrl,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.View
                    };
                case ChangeType.Delete | ChangeType.Merge | ChangeType.Rename:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Red,
                        Text = "merge, delete, rename",
                        Link = string.Format(
                            Resource.ViewSourceUri,
                            this.TeamWebAccessUrl,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.View
                    };
                case ChangeType.Rename | ChangeType.Merge:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Black,
                        Text = "merge, rename",
                        Link = string.Format(
                             Resource.DifferenceUri,
                             this.TeamWebAccessUrl,
                             sourceServerItem,
                             version,
                             serverItem,
                             shelvesetName,
                             owner,
                             projectId),
                        LinkText = ChangeConfigConstants.LinkText.Difference
                    };
                case ChangeType.Encoding | ChangeType.Branch:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Black,
                            Text = "branch",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                this.TeamWebAccessUrl,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                            LinkText = ChangeConfigConstants.LinkText.View
                        };
                case ChangeType.Merge | ChangeType.Branch:
                case ChangeType.Merge | ChangeType.Branch | ChangeType.Encoding:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Black,
                        Text = "merge, branch",
                        Link = string.Format(
                            Resource.ViewSourceUri,
                            this.TeamWebAccessUrl,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.View
                    };
                case ChangeType.Rename:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Black,
                            Text = "rename",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                this.TeamWebAccessUrl,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                            LinkText = ChangeConfigConstants.LinkText.View
                        };
                case ChangeType.Undelete:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Green,
                            Text = "undelete",
                            Link = string.Format(
                                Resource.ViewSourceUri,
                                this.TeamWebAccessUrl,
                                serverItem,
                                shelvesetName,
                                owner,
                                projectId),
                            LinkText = ChangeConfigConstants.LinkText.View
                        };
                case ChangeType.Undelete | ChangeType.Rollback:
                    return new ChangeConfig()
                    {
                        Colour = ChangeConfigConstants.Color.Green,
                        Text = "undelete, rollback",
                        Link = string.Format(
                            Resource.ViewSourceUri,
                            this.TeamWebAccessUrl,
                            serverItem,
                            shelvesetName,
                            owner,
                            projectId),
                        LinkText = ChangeConfigConstants.LinkText.View
                    };
                default:
                    return new ChangeConfig()
                        {
                            Colour = ChangeConfigConstants.Color.Red,
                            Text = "undefined, please let me know about this",
                            Link = "https://quickreview.codeplex.com/discussions",
                            LinkText = ChangeConfigConstants.LinkText.Open
                        };
            }
        }
    }
}