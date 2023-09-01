namespace CellPhones.Domain.Entity.Identity
{
    public interface IAudit
    {
        DateTime? AddedTimestamp { get; set; }

        DateTime? ChangedTimestamp { get; set; }
    }
}