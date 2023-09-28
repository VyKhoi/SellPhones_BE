namespace SellPhones.DTO.Comment
{
    public class CommentDTO
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? ContentComment { get; set; }
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public int? ReplyId { get; set; }

        public List<CommentReplyDTO>? CommentReply { get; set; } = null;
    }

    public class CommentReplyDTO
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? ContentComment { get; set; }
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
    }
}