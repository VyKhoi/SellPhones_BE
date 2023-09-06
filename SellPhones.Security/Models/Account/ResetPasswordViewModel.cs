namespace SellPhones.Security.Models.Account
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string Code { get; set; }
    }

    public class ChangePasswordViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class ResfreshTokenFirebase
    {
        public string NewFirebaseToken { get; set; }
    }

    public class RemoveTokenFirebase
    {
        public string FirebaseToken { get; set; }
    }

    public class TokenFirebaseDto
    {
        public Guid UserId { get; set; }
        public string OldFirebaseToken { get; set; }
        public string NewFirebaseToken { get; set; }
    }
}