using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity.Identity
{
    [Table("UserTokens")]
    public class UserToken : IdentityUserToken<Guid>
    {
        public string? AccessTokenHash { get; set; }

        public DateTimeOffset AccessTokenExpiresDateTime { get; set; }

        public string? RefreshTokenIdHash { get; set; }

        public string? RefreshTokenIdHashSource { get; set; }

        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }
        public virtual User? User { get; set; }
    }
}