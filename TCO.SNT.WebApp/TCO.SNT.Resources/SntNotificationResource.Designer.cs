//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCO.SNT.Resources {
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
    public class SntNotificationResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SntNotificationResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TCO.SNT.Resources.SntNotificationResource", typeof(SntNotificationResource).Assembly);
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
        ///   Looks up a localized string similar to &lt;p style=\&quot;color: red; font-weight: bold; \&quot;&gt;{0}&lt;/p&gt;.
        /// </summary>
        public static string NotificationDeadlineExceedTemplate {
            get {
                return ResourceManager.GetString("NotificationDeadlineExceedTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}.
        /// </summary>
        public static string NotificationDeadlineNotExceedTemplate {
            get {
                return ResourceManager.GetString("NotificationDeadlineNotExceedTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Следующие СНТ требуют вашего внимания.
        /// </summary>
        public static string NotificationEmailSubject {
            get {
                return ResourceManager.GetString("NotificationEmailSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;tr&gt;
        ///&lt;td&gt;{0}&lt;/td&gt;
        ///&lt;td&gt;{1}&lt;/td&gt;
        ///&lt;td&gt;{2}&lt;/td&gt;
        ///&lt;td&gt;{3}&lt;/td&gt;
        ///&lt;td&gt;{4}&lt;/td&gt;
        ///&lt;td&gt;{5}&lt;/td&gt;
        ///&lt;/tr&gt;.
        /// </summary>
        public static string NotificationRowTemplate {
            get {
                return ResourceManager.GetString("NotificationRowTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;/tbody&gt;
        ///      &lt;/table&gt;
        ///   &lt;/div&gt;
        ///   &lt;/body&gt;
        ///&lt;/html&gt;.
        /// </summary>
        public static string NotificatuionTableTemplateEnd {
            get {
                return ResourceManager.GetString("NotificatuionTableTemplateEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///   &lt;head&gt;
        ///      &lt;style&gt;
        ///         body {
        ///         padding: 14px;
        ///         text-align: center;
        ///         }
        ///         table {
        ///         width: 100%;
        ///         margin: 20px auto;
        ///         table-layout: auto;
        ///         }
        ///         .fixed {
        ///         table-layout: fixed;
        ///         }
        ///         table,
        ///         td,
        ///         th {
        ///         border-collapse: collapse;
        ///         }
        ///         th,
        ///         td {
        ///         padding: 10px;
        ///         border: solid 1px;
        ///         text-align: center;
        ///         }
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        public static string NotificatuionTableTemplateStart {
            get {
                return ResourceManager.GetString("NotificatuionTableTemplateStart", resourceCulture);
            }
        }
    }
}
