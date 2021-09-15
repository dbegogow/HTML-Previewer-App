namespace HTMLPreviewerApp.Areas.Identity.Pages.Account.Constants
{
    public class ValidationErrorMessages
    {
        public const string RequiredEmail = "Valid email is required.";
        public const string InvalidEmail = "Invalid email";
        public const string RequiredPassword = "Password is required.";
        public const string InvalidPasswordContent = "The password must contain a capital letter, a lowercase letter and a number.";
        public const string InvalidPasswordLength = "Password must be between {2} and {1} characters.";
        public const string InvalidPasswordConfirmation = "Password and password confirmation do not match.";

        public const string InvalidAttempt = "Invalid login attempt.";

        public const string InvalidPassword = "Invalid password.";
        public const string RequiredField = "Field is required.";

        public const string AlreadyExistUserWithEmail = "A user with this email already exists.";
        public const string InvalidChangeEmail = "An error occurred while changing the email.";
    }
}
