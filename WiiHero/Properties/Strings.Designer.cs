﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GuitarConnector.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GuitarConnector.Properties.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Could not close connection..
        /// </summary>
        internal static string error_closing {
            get {
                return ResourceManager.GetString("error_closing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please install the SCP driver..
        /// </summary>
        internal static string error_driver {
            get {
                return ResourceManager.GetString("error_driver", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No open connection available..
        /// </summary>
        internal static string error_notopen {
            get {
                return ResourceManager.GetString("error_notopen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not open COM port..
        /// </summary>
        internal static string error_opening {
            get {
                return ResourceManager.GetString("error_opening", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not pair correctly with serial device. Please try again..
        /// </summary>
        internal static string error_pairing {
            get {
                return ResourceManager.GetString("error_pairing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not read from serial port..
        /// </summary>
        internal static string error_read {
            get {
                return ResourceManager.GetString("error_read", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error has occured,.
        /// </summary>
        internal static string error_unknown {
            get {
                return ResourceManager.GetString("error_unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not write to serial port..
        /// </summary>
        internal static string error_write {
            get {
                return ResourceManager.GetString("error_write", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a COM port first..
        /// </summary>
        internal static string warning_selectport {
            get {
                return ResourceManager.GetString("warning_selectport", resourceCulture);
            }
        }
    }
}
