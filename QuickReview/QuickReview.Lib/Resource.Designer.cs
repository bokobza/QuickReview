﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuickReview.Lib {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("QuickReview.Lib.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}/UI/Pages/Scc/Difference.aspx?opath={1}&amp;ocs={2}&amp;mpath={3}&amp;mss={4};{5}&amp;pguid={6}.
        /// </summary>
        internal static string DifferenceUri {
            get {
                return ResourceManager.GetString("DifferenceUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}/UI/Pages/Scc/ViewShelveset.aspx?shelveset={1};{2}&amp;pguid={3}.
        /// </summary>
        internal static string ViewShelvesetUri {
            get {
                return ResourceManager.GetString("ViewShelvesetUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}/UI/Pages/Scc/ViewSource.aspx?path={1}&amp;ss={2};{3}&amp;pguid={4}.
        /// </summary>
        internal static string ViewSourceUri {
            get {
                return ResourceManager.GetString("ViewSourceUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}/UI/Pages/WorkItems/WorkItemEdit.aspx?id={1}&amp;pguid={2}.
        /// </summary>
        internal static string ViewWorkItemUri {
            get {
                return ResourceManager.GetString("ViewWorkItemUri", resourceCulture);
            }
        }
    }
}
