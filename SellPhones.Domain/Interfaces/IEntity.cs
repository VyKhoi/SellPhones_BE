namespace SellPhones.Domain.Entity.Identity
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}