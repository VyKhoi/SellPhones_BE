namespace SellPhones.DTO.Commons
{

    public class FilterPagingRequest
    {
        public string? Search { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public List<FilterOption>? FilterOptions { get; set; }
        public List<SortOption>? SortOptions { get; set; }
    }

    public class FilterOption
    {
        public string Column { get; set; }
        public string? Value { get; set; }
    }

    public class SortOption
    {
        public string Column { get; set; }
        public string Direction { get; set; }
    }
}