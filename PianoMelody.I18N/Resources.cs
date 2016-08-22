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
            
        /// <summary>Are you sure you want to delete this?</summary>
        public static string _AreYouSure {
               get {
                   return (string) resourceProvider.GetResource("_AreYouSure", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Article group</summary>
        public static string _ArticleGroup {
               get {
                   return (string) resourceProvider.GetResource("_ArticleGroup", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Article groups</summary>
        public static string _ArticleGroups {
               get {
                   return (string) resourceProvider.GetResource("_ArticleGroups", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>BG Content</summary>
        public static string _BgContent {
               get {
                   return (string) resourceProvider.GetResource("_BgContent", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>BG Description</summary>
        public static string _BgDescription {
               get {
                   return (string) resourceProvider.GetResource("_BgDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>BG Name</summary>
        public static string _BgName {
               get {
                   return (string) resourceProvider.GetResource("_BgName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>BG Title</summary>
        public static string _BgTitle {
               get {
                   return (string) resourceProvider.GetResource("_BgTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cancel</summary>
        public static string _Cancel {
               get {
                   return (string) resourceProvider.GetResource("_Cancel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Carousel</summary>
        public static string _Carousel {
               get {
                   return (string) resourceProvider.GetResource("_Carousel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Change password</summary>
        public static string _ChangePassword {
               get {
                   return (string) resourceProvider.GetResource("_ChangePassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Clear</summary>
        public static string _Clear {
               get {
                   return (string) resourceProvider.GetResource("_Clear", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Condition</summary>
        public static string _Condition {
               get {
                   return (string) resourceProvider.GetResource("_Condition", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Confirma password</summary>
        public static string _ConfirmPassword {
               get {
                   return (string) resourceProvider.GetResource("_ConfirmPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Create</summary>
        public static string _CreateNew {
               get {
                   return (string) resourceProvider.GetResource("_CreateNew", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Current password</summary>
        public static string _CurrentPassword {
               get {
                   return (string) resourceProvider.GetResource("_CurrentPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Delete</summary>
        public static string _Delete {
               get {
                   return (string) resourceProvider.GetResource("_Delete", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Description</summary>
        public static string _Description {
               get {
                   return (string) resourceProvider.GetResource("_Description", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Edit</summary>
        public static string _Edit {
               get {
                   return (string) resourceProvider.GetResource("_Edit", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email</summary>
        public static string _Email {
               get {
                   return (string) resourceProvider.GetResource("_Email", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>EN Content</summary>
        public static string _EnContent {
               get {
                   return (string) resourceProvider.GetResource("_EnContent", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>EN Description</summary>
        public static string _EnDescription {
               get {
                   return (string) resourceProvider.GetResource("_EnDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>EN Name</summary>
        public static string _EnName {
               get {
                   return (string) resourceProvider.GetResource("_EnName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>EN Title</summary>
        public static string _EnTitle {
               get {
                   return (string) resourceProvider.GetResource("_EnTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The {0} field is not valid email address</summary>
        public static string _ErrInvalidEmail {
               get {
                   return (string) resourceProvider.GetResource("_ErrInvalidEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Invalid price</summary>
        public static string _ErrInvalidPrice {
               get {
                   return (string) resourceProvider.GetResource("_ErrInvalidPrice", CultureInfo.CurrentUICulture.Name);
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
            
        /// <summary>Please select image</summary>
        public static string _ErrSelectImage {
               get {
                   return (string) resourceProvider.GetResource("_ErrSelectImage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Filter</summary>
        public static string _Filter {
               get {
                   return (string) resourceProvider.GetResource("_Filter", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Gallery image</summary>
        public static string _GalleryImage {
               get {
                   return (string) resourceProvider.GetResource("_GalleryImage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>New</summary>
        public static string _IsNew {
               get {
                   return (string) resourceProvider.GetResource("_IsNew", CultureInfo.CurrentUICulture.Name);
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
            
        /// <summary>Manufacturer</summary>
        public static string _Manufacturer {
               get {
                   return (string) resourceProvider.GetResource("_Manufacturer", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Name</summary>
        public static string _Name {
               get {
                   return (string) resourceProvider.GetResource("_Name", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Negotiable</summary>
        public static string _Negotiable {
               get {
                   return (string) resourceProvider.GetResource("_Negotiable", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>New</summary>
        public static string _New {
               get {
                   return (string) resourceProvider.GetResource("_New", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>New password</summary>
        public static string _NewPassword {
               get {
                   return (string) resourceProvider.GetResource("_NewPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>News</summary>
        public static string _News {
               get {
                   return (string) resourceProvider.GetResource("_News", CultureInfo.CurrentUICulture.Name);
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
            
        /// <summary>Photo</summary>
        public static string _Photo {
               get {
                   return (string) resourceProvider.GetResource("_Photo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Photos</summary>
        public static string _Photos {
               get {
                   return (string) resourceProvider.GetResource("_Photos", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Product</summary>
        public static string _Product {
               get {
                   return (string) resourceProvider.GetResource("_Product", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reference</summary>
        public static string _Reference {
               get {
                   return (string) resourceProvider.GetResource("_Reference", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>RU Content</summary>
        public static string _RuContent {
               get {
                   return (string) resourceProvider.GetResource("_RuContent", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>RU Description</summary>
        public static string _RuDescription {
               get {
                   return (string) resourceProvider.GetResource("_RuDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>RU Name</summary>
        public static string _RuName {
               get {
                   return (string) resourceProvider.GetResource("_RuName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>RU Title</summary>
        public static string _RuTitle {
               get {
                   return (string) resourceProvider.GetResource("_RuTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Save</summary>
        public static string _Save {
               get {
                   return (string) resourceProvider.GetResource("_Save", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Second hand</summary>
        public static string _SecondHand {
               get {
                   return (string) resourceProvider.GetResource("_SecondHand", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Service</summary>
        public static string _Service {
               get {
                   return (string) resourceProvider.GetResource("_Service", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Type</summary>
        public static string _Type {
               get {
                   return (string) resourceProvider.GetResource("_Type", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Url address</summary>
        public static string _UrlAddress {
               get {
                   return (string) resourceProvider.GetResource("_UrlAddress", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Without choice</summary>
        public static string _WithoutChoice {
               get {
                   return (string) resourceProvider.GetResource("_WithoutChoice", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>About us</summary>
        public static string About {
               get {
                   return (string) resourceProvider.GetResource("About", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>All</summary>
        public static string All {
               get {
                   return (string) resourceProvider.GetResource("All", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Contacts</summary>
        public static string Contacts {
               get {
                   return (string) resourceProvider.GetResource("Contacts", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Gallery</summary>
        public static string Gallery {
               get {
                   return (string) resourceProvider.GetResource("Gallery", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Home</summary>
        public static string Home {
               get {
                   return (string) resourceProvider.GetResource("Home", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Useful information</summary>
        public static string Info {
               get {
                   return (string) resourceProvider.GetResource("Info", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Piano</summary>
        public static string Logo {
               get {
                   return (string) resourceProvider.GetResource("Logo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Manufacturers</summary>
        public static string Manufacturers {
               get {
                   return (string) resourceProvider.GetResource("Manufacturers", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>News</summary>
        public static string News {
               get {
                   return (string) resourceProvider.GetResource("News", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Price</summary>
        public static string Price {
               get {
                   return (string) resourceProvider.GetResource("Price", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Products</summary>
        public static string Products {
               get {
                   return (string) resourceProvider.GetResource("Products", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>References</summary>
        public static string References {
               get {
                   return (string) resourceProvider.GetResource("References", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Services</summary>
        public static string Services {
               get {
                   return (string) resourceProvider.GetResource("Services", CultureInfo.CurrentUICulture.Name);
               }
            }

        }        
}
