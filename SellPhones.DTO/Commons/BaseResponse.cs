namespace SellPhones.DTO.Commons
{
    public class DataList<T>
    {
        public T? Items { get; set; }
        public int? TotalRecord { get; set; }
    }
}