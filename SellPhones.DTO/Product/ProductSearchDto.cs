using SellPhones.Commons;
using SellPhones.DTO.Commons;

namespace SellPhones.DTO.Product
{

    public class ProductSearchDto : FilterPagingRequest
    { 
        public TYPE_PRODUCT Type { get; set; }
        public int BranchId { get; set; }
    }
}