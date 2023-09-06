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

        #region get all product of branch

        // get list all product belong type and branch ( no include promotion )
        public async Task<ResponseData> SearchAsync(ProductSearchDto dto)
        {
            try
            {
                switch (dto.Type)
                {
                    case TYPE_PRODUCT.SMARTPHONE:
                        {
                            var rs = await SearchSmartphoneAsync(dto);
                            return rs;
                        }
                    case TYPE_PRODUCT.LAPTOP:
                        {
                            var rs = await SearchLaptopAsync(dto);
                            return rs;
                        }
                    case TYPE_PRODUCT.EARPHONE:
                        {
                            var rs = await SearchEarphoneAsync(dto);
                            return rs;
                        }
                    default:
                        {
                            return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL);
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

        // get all smartphone
        public async Task<ResponseData> SearchSmartphoneAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( smartphone )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all smartphone
                IEnumerable<Product> query = UnitOfWork.ProductRepository.GetAll().Where(x => x.Type == TYPE_PRODUCT.SMARTPHONE && x.IsActive == true && x.IsDeleted == false)
                      .Include(x => x.Smartphone)
                      .Include(x => x.ProductColors).ThenInclude(x => x.BranchProductColors)
                      .Where(x => x.ProductColors.Any(pc => pc.BranchProductColors.Any(bpc => bpc.BranchId == dto.BranchId))).ToList();

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

        //get all laptop
        public async Task<ResponseData> SearchLaptopAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( laptop )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all laptop
                IEnumerable<Product> query = UnitOfWork.ProductRepository.GetAll().Where(x => x.Type == TYPE_PRODUCT.LAPTOP && x.IsActive == true && x.IsDeleted == false)
                       .Include(x => x.Laptop)
                       .Include(x => x.ProductColors).ThenInclude(x => x.BranchProductColors)
                       .Where(x => x.ProductColors.Any(pc => pc.BranchProductColors.Any(bpc => bpc.BranchId == dto.BranchId))).ToList();

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

        //get all earphone
        public async Task<ResponseData> SearchEarphoneAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( earphone )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all earphone
                IEnumerable<Product> query = UnitOfWork.ProductRepository.GetAll().Where(x => x.Type == TYPE_PRODUCT.EARPHONE && x.IsActive == true && x.IsDeleted == false)
               .Include(x => x.Earphone)
               .Include(x => x.ProductColors).ThenInclude(x => x.BranchProductColors)
               .Where(x => x.ProductColors.Any(pc => pc.BranchProductColors.Any(bpc => bpc.BranchId == dto.BranchId))).ToList();

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

        #endregion get all product of branch

        #region get detail a product of branch
        // get base detail a product of branch
        public async Task<ResponseData> DetailProductAsync(RequestDetailProductDTO dto)
        {
            try
            {
                // // get product corlor of that branch
                var query = UnitOfWork.BranchProductColorRepository.GetAll()
                    .Where(x => x.ProductColor.Product.Id == dto.Id && x.BranchId == dto.BranchId && x.IsActive == true && x.IsDeleted == false);

                if (query == null)
                {
                    return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL);
                }


                DetailProductDTO rs = new DetailProductDTO();
                //rs.Id = query.Id;
                //rs.Name = query.ProductColor.Product.Name;

                return new ResponseData(rs);


            }
            catch (Exception ex)
            {
                _logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }
        #endregion

    }
}