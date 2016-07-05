using System.Globalization;
using PianoMelody.I18N.Abstract;
using PianoMelody.I18N.Concrete;
    
namespace PianoMelody.I18N {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Add administrator</summary>
        public static string _AddAdministrator {
               get {
                   return (string) resourceProvider.GetResource("_AddAdministrator", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add label</summary>
        public static string _AddLabel {
               get {
                   return (string) resourceProvider.GetResource("_AddLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Administration</summary>
        public static string _Administration {
               get {
                   return (string) resourceProvider.GetResource("_Administration", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Change password</summary>
        public static string _ChangePassword {
               get {
                   return (string) resourceProvider.GetResource("_ChangePassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Confirma password</summary>
        public static string _ConfirmPassword {
               get {
                   return (string) resourceProvider.GetResource("_ConfirmPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Current password</summary>
        public static string _CurrentPassword {
               get {
                   return (string) resourceProvider.GetResource("_CurrentPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email</summary>
        public static string _Email {
               get {
                   return (string) resourceProvider.GetResource("_Email", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The {0} field is not valid email address</summary>
        public static string _ErrInvalidEmail {
               get {
                   return (string) resourceProvider.GetResource("_ErrInvalidEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The {0} field must be at least {2} characters long</summary>
        public static string _ErrLenghtValidation {
               get {
                   return (string) resourceProvider.GetResource("_ErrLenghtValidation", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The field is required</summary>
        public static string _ErrRequired {
               get {
                   return (string) resourceProvider.GetResource("_ErrRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Key</summary>
        public static string _Key {
               get {
                   return (string) resourceProvider.GetResource("_Key", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>label</summary>
        public static string _Label {
               get {
                   return (string) resourceProvider.GetResource("_Label", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Label created</summary>
        public static string _LabelCreated {
               get {
                   return (string) resourceProvider.GetResource("_LabelCreated", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Login</summary>
        public static string _Login {
               get {
                   return (string) resourceProvider.GetResource("_Login", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Log Off</summary>
        public static string _LogOff {
               get {
                   return (string) resourceProvider.GetResource("_LogOff", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Name</summary>
        public static string _Name {
               get {
                   return (string) resourceProvider.GetResource("_Name", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>New password</summary>
        public static string _NewPassword {
               get {
                   return (string) resourceProvider.GetResource("_NewPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Password</summary>
        public static string _Password {
               get {
                   return (string) resourceProvider.GetResource("_Password", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The passwords do not match</summary>
        public static string _PasswordValidation {
               get {
                   return (string) resourceProvider.GetResource("_PasswordValidation", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Save</summary>
        public static string _Save {
               get {
                   return (string) resourceProvider.GetResource("_Save", CultureInfo.CurrentUICulture.Name);
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

        }        
}
