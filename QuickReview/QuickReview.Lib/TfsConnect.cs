// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TfsConnect.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//  Class used to execute TFS operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.TeamFoundation;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Framework.Client;
    using Microsoft.TeamFoundation.Framework.Common;
    using Microsoft.TeamFoundation.VersionControl.Client;

    /// <summary>
    /// Class used to execute TFS operations.
    /// </summary>
    public class TfsConnect
    {
        /// <summary>The version control server.</summary>
        private static VersionControlServer versionControlcServer;

        /// <summary>Value indicating whether the connection to TFS has been initialized.</summary>
        private static bool isInitialized;

        /// <summary>The address of the team project in TFS.</summary>
        private static Uri tfsAddress;

        /// <summary>The TFS project collection.</summary>
        private static TfsTeamProjectCollection projectCollection;

        /// <summary>Gets the team project id.</summary>
        /// <value>The project id.</value>
        public static string ProjectId { get; private set; }

        /// <summary>Gets the owner of the shelveset.</summary>
        /// <value>The current user.</value>
        public static string CurrentUser { get; private set; }

        /// <summary>Gets the users.</summary>
        /// <value>The users.</value>
        public static IEnumerable<IdentityWrapper> Users { get; private set; }

        /// <summary>
        /// Initializes the tool.
        /// </summary>
        /// <param name="uriAddress"> The URI Address. </param>
        public static void Initialize(string uriAddress)
        {
            tfsAddress = new Uri(uriAddress);

            // gets the project id
            projectCollection = new TfsTeamProjectCollection(tfsAddress, new UICredentialsProvider());
            projectCollection.EnsureAuthenticated();

            versionControlcServer = projectCollection.GetService<VersionControlServer>();
            var catalogNodes = projectCollection.CatalogNode.QueryChildren(new[] { CatalogResourceTypes.TeamProject }, false, CatalogQueryOptions.None);
            foreach (var node in catalogNodes)
            {
                string projectId;
                node.Resource.Properties.TryGetValue("ProjectId", out projectId);
                ProjectId = projectId;
            }

            // gets the owner name from the environment
            CurrentUser = versionControlcServer.AuthorizedIdentity.UniqueName;
            Users = GetUsers();
            isInitialized = true;
        }

        /// <summary>
        /// Gets the shelvesets ordered by time.
        /// </summary>
        /// <param name="shelvesetOwnerName">The owner of the shelvesets.</param>
        /// <returns>A collection of shelvesets.</returns>
        public static List<ShelvesetWrapper> GetOrderedShelvesets(string shelvesetOwnerName)
        {
            if (!isInitialized)
            {
                throw new Exception("The connection to TFS must be initialized before it can be used.");
            }

            return (from shelveset in versionControlcServer.QueryShelvesets(null, shelvesetOwnerName)
                    select new ShelvesetWrapper 
                    { 
                        Name = shelveset.Name,
                        CreationDate = shelveset.CreationDate,
                        Comment = shelveset.Comment,
                        DisplayName = shelveset.DisplayName,
                        OwnerDisplayName = shelveset.OwnerDisplayName,
                        OwnerName = shelveset.OwnerName,
                        PolicyOverrideComment = shelveset.PolicyOverrideComment
                    }).OrderBy(s => s.CreationDate).Reverse().ToList();
        }

        /// <summary>Gets a shelveset.</summary>
        /// <param name="shelvesetName">The shelveset name.</param>
        /// <param name="shelvesetOwnerName">The shelveset owner name.</param>
        /// <returns>A collection of shelvesets.</returns>
        internal static Shelveset[] GetShelveset(string shelvesetName, string shelvesetOwnerName)
        {
            if (!isInitialized)
            {
                throw new Exception("The connection to TFS must be initialized before it can be used.");
            }

            return versionControlcServer.QueryShelvesets(shelvesetName, shelvesetOwnerName);
        }

        /// <summary>The get shelveset changes.</summary>
        /// <param name="shelveset">The shelveset.</param>
        /// <returns>A collection of shelveset changes.</returns>
        internal static PendingSet[] GetShelvesetChanges(Shelveset shelveset)
        {
            if (!isInitialized)
            {
                throw new Exception("The connection to TFS must be initialized before it can be used.");
            }

            return versionControlcServer.QueryShelvedChanges(shelveset);
        }

        /// <summary>Gets the users, sorted by name.</summary>
        /// <returns>The collection of users sorted by name.</returns>
        private static IEnumerable<IdentityWrapper> GetUsers()
        {
            var identityService = projectCollection.GetService<IIdentityManagementService>();
            TeamFoundationIdentity foundationIdentity = identityService.ReadIdentity(GroupWellKnownDescriptors.EveryoneGroup, MembershipQuery.Expanded, ReadIdentityOptions.None);
            IEnumerable<IdentityWrapper> items = from TeamFoundationIdentity id in identityService.ReadIdentities(foundationIdentity.Members, MembershipQuery.Direct, ReadIdentityOptions.None)
                                                where id != null && id.Descriptor.IdentityType == IdentityConstants.WindowsType && !id.IsContainer
                                                select new IdentityWrapper
                                                    {
                                                        DisplayName = id.DisplayName,
                                                        UniqueName = id.UniqueName
                                                    };
            return items.OrderBy(x => x.DisplayName);
        }
    }
}
