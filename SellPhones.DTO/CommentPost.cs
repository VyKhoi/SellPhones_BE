namespace SellPhones.DTO
{
    public class CommentPost
    {
        public string? ContentComment { get; set; } = null!;

        public int? IdProductId { get; set; }

        public Guid? IdUserId { get; set; }

        public int? IdReply { get; set; }
    }
}