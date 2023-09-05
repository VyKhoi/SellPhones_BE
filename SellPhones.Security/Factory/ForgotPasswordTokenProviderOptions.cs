namespace SellPhones.Security.Factory
{
    public class ForgotPasswordTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public ForgotPasswordTokenProviderOptions()
        {
            // update the defaults
            Name = "ForgotPasswordTokenProviderOptions";
            TokenLifespan = TimeSpan.FromSeconds(30);
        }
    }
}