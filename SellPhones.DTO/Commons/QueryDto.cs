namespace SellPhones.DTO.Commons
{
    public class QueryDto
    {
        public string? keyword { get; set; }
        public string? orderField { get; set; }
        public bool isAscOrder { get; set; } = false;
        public int pageIndexFrom { get; set; } = 1;
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 20;
    }
}