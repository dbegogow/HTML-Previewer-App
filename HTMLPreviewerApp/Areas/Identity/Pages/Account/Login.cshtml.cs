﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

using static HTMLPreviewerApp.Areas.Identity.Pages.Account.Constants.ValidationErrorMessages;

namespace HTMLPreviewerApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LoginModel(SignInManager<User> signInManager)
            => this._signInManager = signInManager;

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = RequiredEmail)]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = RequiredPassword)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await this._signInManager.PasswordSignInAsync(Input.Email, Input.Password, true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }

                ModelState.AddModelError("#", InvalidAttempt);

                return Page();
            }

            return Page();
        }
    }
}
