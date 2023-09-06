using System.ComponentModel.DataAnnotations.Schema;

namespace SellPhones.Domain.Entity.Identity
{
    [Table("SysUserTokens")]
    public class SysUserToken : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? AccessToken { get; set; }
        public string? Token_id { get; set; }
        public string? RefreshToken { get; set; }
        public int Expires { get; set; }
        public string? Uuid { get; set; }
    }
}