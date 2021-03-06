using System.Globalization;
using PianoMelody.I18N.Abstract;
using PianoMelody.I18N.Concrete;
    
namespace PianoMelody.I18N 
{
    public class Resources 
    {
        private static IResourceProvider resourceProvider = new DbResourceProvider();
        
        public static void Refresh()
        {
            resourceProvider = new DbResourceProvider();
        }
                
        /// <summary>Add administrator</summary>
        public static string _AddAdministrator 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_AddAdministrator", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Add label</summary>
        public static string _AddLabel 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_AddLabel", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Address</summary>
        public static string _Address 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Address", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Administration</summary>
        public static string _Administration 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Administration", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Are we agent</summary>
        public static string _AreWeAgent 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_AreWeAgent", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Are you sure you want to delete this?</summary>
        public static string _AreYouSure 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_AreYouSure", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Article group</summary>
        public static string _ArticleGroup 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ArticleGroup", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Article groups</summary>
        public static string _ArticleGroups 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ArticleGroups", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Ask about</summary>
        public static string _AskAbout 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_AskAbout", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Availability</summary>
        public static string _Availability 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Availability", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>BG Content</summary>
        public static string _BgContent 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_BgContent", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>BG Description</summary>
        public static string _BgDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_BgDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>BG Name</summary>
        public static string _BgName 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_BgName", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>BG Title</summary>
        public static string _BgTitle 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_BgTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Cancel</summary>
        public static string _Cancel 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Cancel", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Carousel</summary>
        public static string _Carousel 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Carousel", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Change password</summary>
        public static string _ChangePassword 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ChangePassword", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Clear</summary>
        public static string _Clear 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Clear", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Condition</summary>
        public static string _Condition 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Condition", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Confirm password</summary>
        public static string _ConfirmPassword 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ConfirmPassword", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Contact form</summary>
        public static string _ContactForm 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ContactForm", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Contact form enquery</summary>
        public static string _ContactFormSubject 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ContactFormSubject", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Date created</summary>
        public static string _Created 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Created", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Create</summary>
        public static string _CreateNew 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_CreateNew", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Current password</summary>
        public static string _CurrentPassword 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_CurrentPassword", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Delete</summary>
        public static string _Delete 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Delete", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Description</summary>
        public static string _Description 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Description", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Dictionary</summary>
        public static string _Dict 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Dict", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Edit</summary>
        public static string _Edit 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Edit", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        
        public static string _EditAbout 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_EditAbout", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        
        public static string _EditAddress 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_EditAddress", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        
        public static string _EditContact 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_EditContact", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Email</summary>
        public static string _Email 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Email", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Your enquery has been sent successfully</summary>
        public static string _EmailSentSuccessfully 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_EmailSentSuccessfully", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>EN Content</summary>
        public static string _EnContent 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_EnContent", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>EN Description</summary>
        public static string _EnDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_EnDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>EN Name</summary>
        public static string _EnName 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_EnName", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>EN Title</summary>
        public static string _EnTitle 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_EnTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>The {0} field is not valid email address</summary>
        public static string _ErrInvalidEmail 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ErrInvalidEmail", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Invalid price</summary>
        public static string _ErrInvalidPrice 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ErrInvalidPrice", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>The {0} field must be at least {2} characters long</summary>
        public static string _ErrLenghtValidation 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ErrLenghtValidation", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>The field is required</summary>
        public static string _ErrRequired 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ErrRequired", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Please select multimedia</summary>
        public static string _ErrSelectMultimedia 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_ErrSelectMultimedia", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Filter</summary>
        public static string _Filter 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Filter", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Gallery image</summary>
        public static string _GalleryImage 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_GalleryImage", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>In stock</summary>
        public static string _InStock 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_InStock", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>New</summary>
        public static string _IsNew 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_IsNew", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Is sold</summary>
        public static string _IsSold 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_IsSold", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Key</summary>
        public static string _Key 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Key", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>label</summary>
        public static string _Label 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Label", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Label created</summary>
        public static string _LabelCreated 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_LabelCreated", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Label updated</summary>
        public static string _LabelUpdated 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_LabelUpdated", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Login</summary>
        public static string _Login 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Login", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Log Off</summary>
        public static string _LogOff 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_LogOff", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Manufacturer</summary>
        public static string _Manufacturer 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Manufacturer", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Manufacturers</summary>
        public static string _Manufacturers 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Manufacturers", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Message</summary>
        public static string _Message 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Message", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Name</summary>
        public static string _Name 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Name", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Negotiable</summary>
        public static string _Negotiable 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Negotiable", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>New</summary>
        public static string _New 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_New", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>New password</summary>
        public static string _NewPassword 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_NewPassword", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>News</summary>
        public static string _News 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_News", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Password</summary>
        public static string _Password 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Password", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>The passwords do not match</summary>
        public static string _PasswordValidation 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_PasswordValidation", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Phone</summary>
        public static string _Phone 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Phone", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Photo</summary>
        public static string _Photo 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Photo", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Photos</summary>
        public static string _Photos 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Photos", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Position</summary>
        public static string _Position 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Position", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Product</summary>
        public static string _Product 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Product", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Promotion</summary>
        public static string _PromoPrice 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_PromoPrice", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Reference</summary>
        public static string _Reference 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Reference", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>RU Content</summary>
        public static string _RuContent 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_RuContent", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>RU Description</summary>
        public static string _RuDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_RuDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>RU Name</summary>
        public static string _RuName 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_RuName", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>RU Title</summary>
        public static string _RuTitle 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_RuTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Save</summary>
        public static string _Save 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Save", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Second hand</summary>
        public static string _SecondHand 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_SecondHand", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Send</summary>
        public static string _Send 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Send", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Service</summary>
        public static string _Service 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Service", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Sold out</summary>
        public static string _SoldOut 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_SoldOut", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Type</summary>
        public static string _Type 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Type", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Url address</summary>
        public static string _UrlAddress 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_UrlAddress", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Video</summary>
        public static string _Video 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_Video", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Video Url</summary>
        public static string _VideoUrl 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_VideoUrl", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Without choice</summary>
        public static string _WithoutChoice 
        {
            get 
            {
                return (string) resourceProvider.GetResource("_WithoutChoice", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>About us</summary>
        public static string About 
        {
            get 
            {
                return (string) resourceProvider.GetResource("About", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Melodia</summary>
        public static string AboutDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AboutDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Melodia</summary>
        public static string AboutKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AboutKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Accessories</summary>
        public static string Accessories 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Accessories", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Accessories, stools and metronoms</summary>
        public static string AccessoriesDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AccessoriesDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>accessories, stools, piano benches, metronoms, lamps</summary>
        public static string AccessoriesKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AccessoriesKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Accordions</summary>
        public static string Accordions 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Accordions", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Accordions new and second hand</summary>
        public static string AccordionsDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AccordionsDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>accordion,accordions</summary>
        public static string AccordionsKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AccordionsKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Acoustic pianos</summary>
        public static string AcousticPianos 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AcousticPianos", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Acoustic pianos</summary>
        public static string AcousticPianosDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AcousticPianosDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>piano, pianos, grand piano, acoustic</summary>
        public static string AcousticPianosKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("AcousticPianosKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>All</summary>
        public static string All 
        {
            get 
            {
                return (string) resourceProvider.GetResource("All", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Contacts</summary>
        public static string Contacts 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Contacts", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Address, contacts and working time</summary>
        public static string ContactsDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("ContactsDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>address, contact, contacts, working time</summary>
        public static string ContactsKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("ContactsKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Digital pianos</summary>
        public static string DigitalPianos 
        {
            get 
            {
                return (string) resourceProvider.GetResource("DigitalPianos", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Digital pianos</summary>
        public static string DigitalPianosDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("DigitalPianosDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>digital, pianos, Piano</summary>
        public static string DigitalPianosKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("DigitalPianosKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Gallery</summary>
        public static string Gallery 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Gallery", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Video and photo content about us</summary>
        public static string GalleryDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("GalleryDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>video,photo,multimedia,content</summary>
        public static string GalleryKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("GalleryKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Piano shop</summary>
        public static string Home 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Home", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Piano shop Melody, sale of pianos and grand pianos. Import and export of new and second hand pianos. Exclusive representative for PETROF, C.BECHSTEIN and others for BULGARIA.</summary>
        public static string HomeDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("HomeDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Melody piano lounge, piano, grand piano, royals, used piano, music, music store, metronomes, guitar, accordion, music, piano bar, stools</summary>
        public static string HomeKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("HomeKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Useful information</summary>
        public static string Info 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Info", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Useful information</summary>
        public static string InfoDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("InfoDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>useful,information,info,about,pianos</summary>
        public static string InfoKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("InfoKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Melodia</summary>
        public static string Logo 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Logo", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>News</summary>
        public static string News 
        {
            get 
            {
                return (string) resourceProvider.GetResource("News", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Our news</summary>
        public static string NewsDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("NewsDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>news,media</summary>
        public static string NewsKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("NewsKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Price</summary>
        public static string Price 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Price", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Products</summary>
        public static string Products 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Products", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Our products are pianos, royals and accessoaries</summary>
        public static string ProductsDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("ProductsDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>products,pianos,royals,accessoaries</summary>
        public static string ProductsKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("ProductsKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Sale</summary>
        public static string Promotions 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Promotions", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Sales pianos, grand pianos and accessories</summary>
        public static string PromotionsDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("PromotionsDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>sale, promotion, promotions</summary>
        public static string PromotionsKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("PromotionsKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>References</summary>
        public static string References 
        {
            get 
            {
                return (string) resourceProvider.GetResource("References", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Our references </summary>
        public static string ReferencesDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("ReferencesDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>References</summary>
        public static string ReferencesKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("ReferencesKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Grand pianos</summary>
        public static string Royals 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Royals", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Grand pianos new and second hand</summary>
        public static string RoyalsDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("RoyalsDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>grand piano, grand pianos</summary>
        public static string RoyalsKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("RoyalsKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Services</summary>
        public static string Services 
        {
            get 
            {
                return (string) resourceProvider.GetResource("Services", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Transport and delivery of piano and grand piano. Rental of pianos and grand pianos. Restoration and tuning. Piano lessons.</summary>
        public static string ServicesDescription 
        {
            get 
            {
                return (string) resourceProvider.GetResource("ServicesDescription", CultureInfo.CurrentUICulture.Name);
            }
        }
            
        /// <summary>Transportation, handling, piano, rental, tuning, restoration, lessons</summary>
        public static string ServicesKeywords 
        {
            get 
            {
                return (string) resourceProvider.GetResource("ServicesKeywords", CultureInfo.CurrentUICulture.Name);
            }
        }

    }        
}
