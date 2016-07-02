using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace PianoMelody.I18N {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Add administrator</summary>
        public static string AddAdministrator {
               get {
                   return (string) resourceProvider.GetResource("AddAdministrator", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Administration</summary>
        public static string Administration {
               get {
                   return (string) resourceProvider.GetResource("Administration", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Change password</summary>
        public static string ChangePassword {
               get {
                   return (string) resourceProvider.GetResource("ChangePassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Confirma password</summary>
        public static string ConfirmPassword {
               get {
                   return (string) resourceProvider.GetResource("ConfirmPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email</summary>
        public static string Email {
               get {
                   return (string) resourceProvider.GetResource("Email", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Home</summary>
        public static string Home {
               get {
                   return (string) resourceProvider.GetResource("Home", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Piano</summary>
        public static string Logo {
               get {
                   return (string) resourceProvider.GetResource("Logo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Log Off</summary>
        public static string LogOff {
               get {
                   return (string) resourceProvider.GetResource("LogOff", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>New password</summary>
        public static string NewPassword {
               get {
                   return (string) resourceProvider.GetResource("NewPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Old password</summary>
        public static string OldPassword {
               get {
                   return (string) resourceProvider.GetResource("OldPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Password</summary>
        public static string Password {
               get {
                   return (string) resourceProvider.GetResource("Password", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The {0} field is required</summary>
        public static string RequiredField {
               get {
                   return (string) resourceProvider.GetResource("RequiredField", CultureInfo.CurrentUICulture.Name);
               }
            }

        }        
}
