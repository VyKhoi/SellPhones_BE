using Microsoft.EntityFrameworkCore;
using SellPhones.Commons;
using SellPhones.Data.Interfaces;
using SellPhones.Domain.Entity;
using SellPhones.DTO.Commons;
using SellPhones.DTO.Product;
using SellPhones.Service.Interfaces;
using SellPhones.Services.Extensions;
using System.Net;

namespace SellPhones.Service.Implementation
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        // get list all product belong type and branch ( no include promotion )
        public async Task<ResponseData> SearchAsync(ProductSearchDto dto)
        {
            try
            {
                switch (dto.TypeProduct)
                {
                    case TYPE_PRODUCT.SMARTPHONE:
                        {
                            var rs = await SearchSmartphoneAsync(dto);
                            return rs;
                        }
                    case TYPE_PRODUCT.LAPTOP:
                        {
                            return null;
                            break;
                        }
                    case TYPE_PRODUCT.EARPHONE:
                        {
                            return null;

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        public async Task<ResponseData> SearchSmartphoneAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( smartphone )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all smartphone
                IEnumerable<Product> query = UnitOfWork.ProductRepository.GetAll().Where(x => x.Type == TYPE_PRODUCT.SMARTPHONE && x.IsActive == true && x.IsDeleted == false)
                      .Include(x => x.Smartphone);

                // fillter data
                query = query.Filter(dto.FilterOptions, dto.Search);

                // sort ( belong to properties of that object )
                query = query.Sort(dto.SortOptions?.FirstOrDefault());

                // count total record
                dataList.TotalRecord = query != null ? query.Count() : 0;

                // cut data (use for pagination)
                var data = query.Skip(dto.PageIndex * dto.PageSize)
                .Take(dto.PageSize)
                .Select(x => new ProductListDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ManufactureName = x.NameManufactureId,
                    Type = (TYPE_PRODUCT)x.Type
                }).ToList();

                dataList.Items = data;
                //_logger!.LogInfo($"Search Customer Result with data {JsonConvert.SerializeObject(data)}");
                return new ResponseData(dataList);
            }
            catch (Exception ex)
            {
                _logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }
    }
}