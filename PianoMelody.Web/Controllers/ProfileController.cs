namespace PianoMelody.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using PianoMelody.Web.Extensions;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using ViewModels;

    [Authorize]
    public class ProfileController : BaseController
    {
        private ApplicationSignInManager _signInManager;

        private ApplicationUserManager _userManager;

        public ProfileController()
        {
        }

        public ProfileController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this._signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                this._signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this._userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this._userManager = value;
            }
        }

        // GET: /Profile/Index
        public ActionResult Index(ManageMessageId? message)
        {
            return this.RedirectToAction("Index", "Home");
        }

        // GET: /Profile/ChangePassword
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        // POST: /Profile/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var result =
                await
                this.UserManager.ChangePasswordAsync(
                    this.User.Identity.GetUserId(),
                    model.OldPassword,
                    model.NewPassword);
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }

                this.AddNotification("Your password has been changed successfull", NotificationType.SUCCESS);
                return this.RedirectToAction("Index");
            }

            this.AddErrors(result);
            return this.View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this._userManager != null)
            {
                this._userManager.Dispose();
                this._userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error);
            }
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,

            EditProfileSuccess,

            ChangePasswordSuccess,

            SetTwoFactorSuccess,

            SetPasswordSuccess,

            RemoveLoginSuccess,

            RemovePhoneSuccess,

            Error
        }

        #endregion
    }
}