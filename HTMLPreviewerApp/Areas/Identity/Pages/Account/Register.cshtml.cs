using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using static HTMLPreviewerApp.Data.DataConstants.User;
using static HTMLPreviewerApp.Areas.Identity.Pages.Account.Constants.ValidationErrorMessages;

namespace HTMLPreviewerApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private const string DuplicateUserNameErrorCode = "DuplicateUserName";

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [BindProperty] public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = RequiredEmail)]
            [EmailAddress(ErrorMessage = InvalidEmail)]
            public string Email { get; set; }

            [Required(ErrorMessage = RequiredPassword)]
            [StringLength(PasswordMaxLength, ErrorMessage = InvalidPasswordLength, MinimumLength = PasswordMinLength)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare(nameof(Password), ErrorMessage = InvalidPasswordConfirmation)]
            public string ConfirmPassword { get; set; }
        }

        public void OnGetAsync(string returnUrl = null)
            => ReturnUrl = returnUrl;

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                };

                var result = await this._userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await this._signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                var hasDuplicateUserNameInvalid = result
                    .Errors
                    .Any(e => e.Code == DuplicateUserNameErrorCode);

                ModelState.AddModelError("#",
                    hasDuplicateUserNameInvalid ? AlreadyExistUserWithEmail : InvalidPasswordContent);
            }

            return Page();
        }
    }
}
