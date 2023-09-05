using SellPhones.Commons;
using SellPhones.DTO.Commons;

namespace SellPhones.DTO.Product
{
    public class ProductSearchDto : FilterPagingRequest
    {
        public TYPE_PRODUCT TypeProduct;
        public int BranchId;
    }
}