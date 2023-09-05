using Microsoft.AspNetCore.Identity;

namespace SellPhones.Security.Factory
{
    public static class CustomIdentityBuilderExtensions
    {
        public static IdentityBuilder AddForgotPasswordTotpTokenProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var totpProvider = typeof(PasswordlessLoginTotpTokenProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider("ForgotPasswordTotpProvider", totpProvider);
        }
    }
}