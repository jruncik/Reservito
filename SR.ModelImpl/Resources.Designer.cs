﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SR.ModelImpl {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SR.ModelImpl.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to User &apos;{0}&apos; doesn&apos;t have requested right for this operation..
        /// </summary>
        internal static string NotEnoughtRights {
            get {
                return ResourceManager.GetString("NotEnoughtRights", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Paperformat &apos;{0}&apos; is buildin format..
        /// </summary>
        internal static string PapeFormatIsBuildinFormat {
            get {
                return ResourceManager.GetString("PapeFormatIsBuildinFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Paperformat with name &apos;{0}&apos; already exist..
        /// </summary>
        internal static string PaperFormatAlreadyExist {
            get {
                return ResourceManager.GetString("PaperFormatAlreadyExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Paperformat &apos;{0}&apos; wasn&apos;t found..
        /// </summary>
        internal static string PaperFormatNotFound {
            get {
                return ResourceManager.GetString("PaperFormatNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username or password is empty..
        /// </summary>
        internal static string UsernameOrPasswordIsEmpty {
            get {
                return ResourceManager.GetString("UsernameOrPasswordIsEmpty", resourceCulture);
            }
        }
    }
}
