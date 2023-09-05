namespace SellPhones.Security.Factory
{
    public class DataProtectionTokenProviderOptions
    {
        public string Name { get; set; } = "DataProtectorTokenProvider";
        public TimeSpan TokenLifespan { get; set; } = TimeSpan.FromSeconds(30);
    }
}