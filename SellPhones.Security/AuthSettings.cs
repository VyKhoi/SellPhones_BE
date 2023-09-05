namespace SellPhones.Security
{
    public class AuthSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string TokenLifespanMinutes { get; set; } = string.Empty;
    }
}