﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketPlace.Resources.Models.Users {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ChangePasswordModel {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ChangePasswordModel() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MarketPlace.Resources.Models.Users.ChangePasswordModel", typeof(ChangePasswordModel).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New password.
        /// </summary>
        public static string NewPassword {
            get {
                return ResourceManager.GetString("NewPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Repeat new password.
        /// </summary>
        public static string NewRepeatPassword {
            get {
                return ResourceManager.GetString("NewRepeatPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Old password.
        /// </summary>
        public static string OldPassword {
            get {
                return ResourceManager.GetString("OldPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password must meet requirements (uppercase,lowercase,at least 1 number, lenght at least 8 symbols).
        /// </summary>
        public static string PasswordError1 {
            get {
                return ResourceManager.GetString("PasswordError1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Passwords do not match.
        /// </summary>
        public static string PasswordError2 {
            get {
                return ResourceManager.GetString("PasswordError2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Submit.
        /// </summary>
        public static string Submit {
            get {
                return ResourceManager.GetString("Submit", resourceCulture);
            }
        }
    }
}
