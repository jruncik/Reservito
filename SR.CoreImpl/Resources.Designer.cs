﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TV.CoreImpl {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TV.CoreImpl.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to User &apos;{0}&apos; is already logged in..
        /// </summary>
        internal static string AlreadyLogedIn {
            get {
                return ResourceManager.GetString("AlreadyLogedIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Build in user can&apos;t be deleted..
        /// </summary>
        internal static string DeleteingBuildInUser {
            get {
                return ResourceManager.GetString("DeleteingBuildInUser", resourceCulture);
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
        ///   Looks up a localized string similar to PasswordCantBeEmpty.
        /// </summary>
        internal static string PasswordCantBeEmpty {
            get {
                return ResourceManager.GetString("PasswordCantBeEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UserAccountExpired.
        /// </summary>
        internal static string UserAccountExpired {
            get {
                return ResourceManager.GetString("UserAccountExpired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User with name &apos;{0}&apos; already exists..
        /// </summary>
        internal static string UserAlreadyExists {
            get {
                return ResourceManager.GetString("UserAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username cant be empty.
        /// </summary>
        internal static string UsernameCantBeEmpty {
            get {
                return ResourceManager.GetString("UsernameCantBeEmpty", resourceCulture);
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
        
        /// <summary>
        ///   Looks up a localized string similar to Username &apos;{0}&apos; isn&apos;t valid..
        /// </summary>
        internal static string UsernameUnknow {
            get {
                return ResourceManager.GetString("UsernameUnknow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wrong password..
        /// </summary>
        internal static string WrongPassword {
            get {
                return ResourceManager.GetString("WrongPassword", resourceCulture);
            }
        }
    }
}