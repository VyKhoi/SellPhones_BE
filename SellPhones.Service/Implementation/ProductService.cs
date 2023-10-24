using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SellPhones.Commons;
using SellPhones.Data.Interfaces;
using SellPhones.Domain.Entity;
using SellPhones.DTO;
using SellPhones.DTO.Comment;
using SellPhones.DTO.Commons;
using SellPhones.DTO.Order;
using SellPhones.DTO.Product;
using SellPhones.Service.Interfaces;
using SellPhones.Services.Extensions;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

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
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
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
                IEnumerable<BranchProductColor> query = UnitOfWork.BranchProductColorRepository.GetAll()
                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.Smartphone)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.Reviews)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.ImageProducts)
                   .Include(x => x.Branch)
                   .Where(x => x.IsActive == true && x.IsDeleted == false && x.BranchId == dto.BranchId && x.ProductColor.Product.Type == dto.Type);

                // fillter data
                query = query.Filter(dto.FilterOptions, dto.Search);

                // sort ( belong to properties of that object )
                query = query.Sort(dto.SortOptions?.FirstOrDefault());

                // cut data (use for pagination)
                var data = query.Skip((int)(dto.PageIndex * dto.PageSize))
                .Take((int)dto.PageSize)
                .Select(x =>
                {
                    ProductListDto tmp = new ProductListDto();

                    tmp.Id = x.ProductColor?.Product.Id;
                    tmp.Name = x.ProductColor?.Product.Name;
                    tmp.ManufactureName = x.ProductColor?.Product.NameManufactureId;
                    tmp.Type = (TYPE_PRODUCT)x.ProductColor?.Product?.Type;

                    tmp.BranchName = x.Branch?.Name;

                    tmp.CurrentPrice = (double)x.ProductColor.Price;
                    tmp.Price = (double)x.ProductColor.Price;

                    tmp.ProductColorId = x.ProductColor.Id;
                    tmp.CurrentColor = x.ProductColor.NameColorId;
                    tmp.CurrentImage = x.ProductColor.Product.ImageProducts
                    .Where(i => i.Name.Equals(x.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                    tmp.ReviewTitle = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                    tmp.Introduce = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                    tmp.OperatorSystem = x?.ProductColor?.Product?.Smartphone?.OperatorSystem;
                    tmp.CPU = x?.ProductColor?.Product?.Smartphone?.Cpu;
                    tmp.RAM = x?.ProductColor?.Product?.Smartphone?.Ram;
                    tmp.ROM = x?.ProductColor?.Product?.Smartphone?.Rom;
                    tmp.Battery = x?.ProductColor?.Product?.Smartphone?.Battery;
                    tmp.Others = x?.ProductColor?.Product?.Smartphone?.Others;
                    tmp.Amount = x?.Amount;
                    tmp.BranchProductColorId = x?.Id;

                    return tmp;
                }).OrderBy(X => X.Id).ToList();
                // count total record
                dataList.TotalRecord = data != null ? data.Count() : 0;
                dataList.Items = data;
                //_logger!.LogInfo($"Search Customer Result with data {JsonConvert.SerializeObject(data)}");
                return new ResponseData(dataList);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        //get all laptop
        public async Task<ResponseData> SearchLaptopAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( smartphone )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all smartphone
                IEnumerable<BranchProductColor> query = UnitOfWork.BranchProductColorRepository.GetAll()
                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.Laptop)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.Reviews)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.ImageProducts)
                   .Include(x => x.Branch)
                   .Where(x => x.IsActive == true && x.IsDeleted == false && x.BranchId == dto.BranchId && x.ProductColor.Product.Type == dto.Type);

                // fillter data
                query = query.Filter(dto.FilterOptions, dto.Search);

                // sort ( belong to properties of that object )
                query = query.Sort(dto.SortOptions?.FirstOrDefault());

                // cut data (use for pagination)
                var data = query.Skip((int)(dto.PageIndex * dto.PageSize))
                .Take((int)dto.PageSize)
                .Select(x =>
                {
                    ProductListDto tmp = new ProductListDto();

                    tmp.Id = x.ProductColor?.Product.Id;
                    tmp.Name = x.ProductColor?.Product.Name;
                    tmp.ManufactureName = x.ProductColor?.Product.NameManufactureId;
                    tmp.Type = (TYPE_PRODUCT)x.ProductColor?.Product?.Type;

                    tmp.BranchName = x.Branch?.Name;

                    tmp.CurrentPrice = (double)x.ProductColor.Price;
                    tmp.Price = (double)x.ProductColor.Price;

                    tmp.ProductColorId = x.ProductColor.Id;
                    tmp.CurrentColor = x.ProductColor.NameColorId;
                    tmp.CurrentImage = x.ProductColor.Product.ImageProducts
                    .Where(i => i.Name.Equals(x.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                    tmp.ReviewTitle = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                    tmp.Introduce = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                    tmp.OperatorSystem = x?.ProductColor?.Product?.Laptop?.OperatorSystem;
                    tmp.CPU = x?.ProductColor?.Product?.Laptop?.Cpu;
                    tmp.RAM = x?.ProductColor?.Product?.Laptop?.Ram;
                    tmp.ROM = x?.ProductColor?.Product?.Laptop?.Rom;
                    tmp.Battery = x?.ProductColor?.Product?.Laptop?.Battery;
                    tmp.Others = x?.ProductColor?.Product?.Laptop?.Others;
                    tmp.GraphicCard = x?.ProductColor?.Product?.Laptop?.GraphicCard;

                    tmp.Amount = x?.Amount;
                    tmp.BranchProductColorId = x?.Id;

                    return tmp;
                }).OrderBy(X => X.Id).ToList();
                // count total record
                dataList.TotalRecord = data != null ? data.Count() : 0;
                dataList.Items = data;
                //_logger!.LogInfo($"Search Customer Result with data {JsonConvert.SerializeObject(data)}");
                return new ResponseData(dataList);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        //get all earphone
        public async Task<ResponseData> SearchEarphoneAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( smartphone )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all smartphone
                IEnumerable<BranchProductColor> query = UnitOfWork.BranchProductColorRepository.GetAll()
                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.Earphone)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.Reviews)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.ImageProducts)
                   .Include(x => x.Branch)
                   .Where(x => x.IsActive == true && x.IsDeleted == false && x.BranchId == dto.BranchId && x.ProductColor.Product.Type == dto.Type);

                // fillter data
                query = query.Filter(dto.FilterOptions, dto.Search);

                // sort ( belong to properties of that object )
                query = query.Sort(dto.SortOptions?.FirstOrDefault());

                // cut data (use for pagination)
                var data = query.Skip((int)(dto.PageIndex * dto.PageSize))
                .Take((int)dto.PageSize)
                .Select(x =>
                {
                    ProductListDto tmp = new ProductListDto();

                    tmp.Id = x.ProductColor?.Product.Id;
                    tmp.Name = x.ProductColor?.Product.Name;
                    tmp.ManufactureName = x.ProductColor?.Product.NameManufactureId;
                    tmp.Type = (TYPE_PRODUCT)x.ProductColor?.Product?.Type;

                    tmp.BranchName = x.Branch?.Name;

                    tmp.CurrentPrice = (double)x.ProductColor.Price;
                    tmp.Price = (double)x.ProductColor.Price;

                    tmp.ProductColorId = x.ProductColor.Id;
                    tmp.CurrentColor = x.ProductColor.NameColorId;
                    tmp.CurrentImage = x.ProductColor.Product.ImageProducts
                    .Where(i => i.Name.Equals(x.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                    tmp.ReviewTitle = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                    tmp.Introduce = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;

                    tmp.ConnectionType = x?.ProductColor?.Product?.Earphone?.ConnectionType;
                    tmp.Design = x?.ProductColor?.Product?.Earphone?.Design;
                    tmp.FrequencyResponse = x?.ProductColor?.Product?.Earphone?.FrequencyResponse;

                    tmp.Amount = x?.Amount;
                    tmp.BranchProductColorId = x?.Id;

                    return tmp;
                }).OrderBy(X => X.Id).ToList();

                // count total record
                dataList.TotalRecord = data != null ? data.Count() : 0;

                dataList.Items = data;
                //_logger!.LogInfo($"Search Customer Result with data {JsonConvert.SerializeObject(data)}");
                return new ResponseData(dataList);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        #endregion get all product of branch

        #region get all product of branch include promotion

        // this region define fuc to get data of product have promotion
        public async Task<ResponseData> SearchProductPromotionAsync(ProductSearchDto dto)
        {
            try
            {
                switch (dto.Type)
                {
                    case TYPE_PRODUCT.SMARTPHONE:
                        {
                            var rs = await SearchSmartphonePromotionAsync(dto);
                            return rs;
                        }
                    case TYPE_PRODUCT.LAPTOP:
                        {
                            var rs = await SearchLaptopPromotionAsync(dto);
                            return rs;
                        }
                    case TYPE_PRODUCT.EARPHONE:
                        {
                            var rs = await SearchEarphonePromotionAsync(dto);
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
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        // get all smartphone promotion
        public async Task<ResponseData> SearchSmartphonePromotionAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( smartphone )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all smartphone
                IEnumerable<Promotion> query = (IEnumerable<Promotion>)UnitOfWork.PromotionRepository.GetAll()
                    .Where(p => p.IsActive == true && p.Active == 1)
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)

                    .ThenInclude(bpc => bpc.Branch)// get branch
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Smartphone) // get smart phone
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.ImageProducts) // get image

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Reviews); // get Reviews

                // fillter data
                query = query.Filter(dto.FilterOptions, dto.Search);

                // sort ( belong to properties of that object )
                query = query.Sort(dto.SortOptions?.FirstOrDefault());

                // count total record
                //dataList.TotalRecord = query != null ? query.Count() : 0;

                // cut data (use for pagination)
                var data = query
                .Select(x =>
                {
                    List<ProductListDto> list = new List<ProductListDto>();
                    foreach (var bpp in x.BranchPromotionProducts)
                    {
                        if (bpp.IsDeleted == true || bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Type != dto.Type)
                        {
                            continue;
                        }
                        ProductListDto tmp = new ProductListDto();

                        tmp.Id = bpp.BrandProductColor.ProductColor.Product.Id;
                        tmp.Name = bpp.BrandProductColor.ProductColor.Product.Name;
                        tmp.ManufactureName = bpp.BrandProductColor.ProductColor.Product.NameManufactureId;
                        tmp.Type = bpp.BrandProductColor.ProductColor.Product.Type;
                        tmp.BranchName = bpp.BrandProductColor.Branch.Name;

                        tmp.CurrentPrice = (double)bpp.BrandProductColor.ProductColor.Price - ((double)bpp.BrandProductColor.ProductColor.Price * bpp.DiscountRate);
                        tmp.Price = (double)bpp.BrandProductColor.ProductColor.Price;
                        tmp.DiscountRate = bpp.DiscountRate;
                        tmp.ProductColorId = bpp.BrandProductColor.ProductColor.Id;
                        tmp.CurrentColor = bpp.BrandProductColor.ProductColor.NameColorId;
                        tmp.CurrentImage = bpp.BrandProductColor.ProductColor.Product.ImageProducts
                        .Where(i => i.Name.Equals(bpp.BrandProductColor.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                        tmp.ReviewTitle = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                        tmp.Introduce = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                        tmp.OperatorSystem = bpp.BrandProductColor?.ProductColor?.Product?.Smartphone?.OperatorSystem;
                        tmp.CPU = bpp.BrandProductColor?.ProductColor?.Product?.Smartphone?.Cpu;
                        tmp.RAM = bpp.BrandProductColor?.ProductColor?.Product?.Smartphone?.Ram;
                        tmp.ROM = bpp.BrandProductColor?.ProductColor?.Product?.Smartphone?.Rom;
                        tmp.Battery = bpp.BrandProductColor?.ProductColor?.Product?.Smartphone?.Battery;
                        tmp.Others = bpp.BrandProductColor?.ProductColor?.Product?.Smartphone?.Others;
                        tmp.Amount = bpp.BrandProductColor?.Amount;
                        tmp.BranchProductColorId = bpp.BrandProductColor?.Id;

                        list.Add(tmp);
                    }

                    list = list.DistinctBy(x => x.Id).OrderBy(x => x.Id)
                        .Skip((int)(dto.PageIndex * dto.PageSize))
                        .Take((int)dto.PageSize).ToList();

                    return list;
                });

                //dataList.Items = data;
                //_logger!.LogInfo($"Search Customer Result with data {JsonConvert.SerializeObject(data)}");
                return new ResponseData(data);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        //get all laptop promotion
        public async Task<ResponseData> SearchLaptopPromotionAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( smartphone )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all smartphone
                IEnumerable<Promotion> query = (IEnumerable<Promotion>)UnitOfWork.PromotionRepository.GetAll()
                    .Where(p => p.IsActive == true && p.Active == 1)
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)

                    .ThenInclude(bpc => bpc.Branch)// get branch
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Laptop) // get Laptop
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.ImageProducts) // get image

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Reviews); // get Reviews

                // fillter data
                query = query.Filter(dto.FilterOptions, dto.Search);

                // sort ( belong to properties of that object )
                query = query.Sort(dto.SortOptions?.FirstOrDefault());

                // count total record
                //dataList.TotalRecord = query != null ? query.Count() : 0;

                // cut data (use for pagination)
                var data = query
                .Select(x =>
                {
                    List<ProductListDto> list = new List<ProductListDto>();
                    foreach (var bpp in x.BranchPromotionProducts)
                    {
                        if (bpp.IsDeleted == true || bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Type != dto.Type)
                        {
                            continue;
                        }
                        ProductListDto tmp = new ProductListDto();

                        tmp.Id = bpp.BrandProductColor.ProductColor.Product.Id;
                        tmp.Name = bpp.BrandProductColor.ProductColor.Product.Name;
                        tmp.ManufactureName = bpp.BrandProductColor.ProductColor.Product.NameManufactureId;
                        tmp.Type = bpp.BrandProductColor.ProductColor.Product.Type;
                        tmp.BranchName = bpp.BrandProductColor.Branch.Name;

                        tmp.CurrentPrice = (double)bpp.BrandProductColor.ProductColor.Price - ((double)bpp.BrandProductColor.ProductColor.Price * bpp.DiscountRate);
                        tmp.Price = (double)bpp.BrandProductColor.ProductColor.Price;
                        tmp.DiscountRate = bpp.DiscountRate;
                        tmp.ProductColorId = bpp.BrandProductColor.ProductColor.Id;
                        tmp.CurrentColor = bpp.BrandProductColor.ProductColor.NameColorId;
                        tmp.CurrentImage = bpp.BrandProductColor.ProductColor.Product.ImageProducts
                        .Where(i => i.Name.Equals(bpp.BrandProductColor.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                        tmp.ReviewTitle = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                        tmp.Introduce = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                        tmp.OperatorSystem = bpp.BrandProductColor?.ProductColor?.Product?.Laptop?.OperatorSystem;
                        tmp.CPU = bpp.BrandProductColor?.ProductColor?.Product?.Laptop?.Cpu;
                        tmp.RAM = bpp.BrandProductColor?.ProductColor?.Product?.Laptop?.Ram;
                        tmp.ROM = bpp.BrandProductColor?.ProductColor?.Product?.Laptop?.Rom;
                        tmp.Battery = bpp.BrandProductColor?.ProductColor?.Product?.Laptop?.Battery;
                        tmp.Others = bpp.BrandProductColor?.ProductColor?.Product?.Laptop?.Others;
                        tmp.GraphicCard = bpp.BrandProductColor?.ProductColor?.Product?.Laptop?.GraphicCard;

                        tmp.Amount = bpp.BrandProductColor?.Amount;
                        tmp.BranchProductColorId = bpp.BrandProductColor?.Id;
                        list.Add(tmp);
                    }

                    list = list.DistinctBy(x => x.Id).OrderBy(x => x.Id)
                        .Skip((int)(dto.PageIndex * dto.PageSize))
                        .Take((int)dto.PageSize).ToList();

                    return list;
                });

                //dataList.Items = data;
                //_logger!.LogInfo($"Search Customer Result with data {JsonConvert.SerializeObject(data)}");
                return new ResponseData(data);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        //get all earphone promotion
        public async Task<ResponseData> SearchEarphonePromotionAsync(ProductSearchDto dto)
        {
            try // get all off infor relate of that product ( smartphone )
            {
                var dataList = new DataList<List<ProductListDto>>();
                // get all smartphone
                IEnumerable<Promotion> query = (IEnumerable<Promotion>)UnitOfWork.PromotionRepository.GetAll()
                    .Where(p => p.IsActive == true && p.Active == 1)
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)

                    .ThenInclude(bpc => bpc.Branch)// get branch
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Earphone) // get Earphone
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.ImageProducts) // get image

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Reviews); // get Reviews

                // fillter data
                query = query.Filter(dto.FilterOptions, dto.Search);

                // sort ( belong to properties of that object )
                query = query.Sort(dto.SortOptions?.FirstOrDefault());

                // count total record
                //dataList.TotalRecord = query != null ? query.Count() : 0;

                // cut data (use for pagination)
                var data = query
                .Select(x =>
                {
                    List<ProductListDto> list = new List<ProductListDto>();
                    foreach (var bpp in x.BranchPromotionProducts)
                    {
                        if (bpp.IsDeleted == true || bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Type != dto.Type)
                        {
                            continue;
                        }
                        ProductListDto tmp = new ProductListDto();

                        tmp.Id = bpp.BrandProductColor.ProductColor.Product.Id;
                        tmp.Name = bpp.BrandProductColor.ProductColor.Product.Name;
                        tmp.ManufactureName = bpp.BrandProductColor.ProductColor.Product.NameManufactureId;
                        tmp.Type = bpp.BrandProductColor.ProductColor.Product.Type;
                        tmp.BranchName = bpp.BrandProductColor.Branch.Name;

                        tmp.CurrentPrice = (double)bpp.BrandProductColor.ProductColor.Price - ((double)bpp.BrandProductColor.ProductColor.Price * bpp.DiscountRate);
                        tmp.Price = (double)bpp.BrandProductColor.ProductColor.Price;
                        tmp.DiscountRate = bpp.DiscountRate;
                        tmp.ProductColorId = bpp.BrandProductColor.ProductColor.Id;
                        tmp.CurrentColor = bpp.BrandProductColor.ProductColor.NameColorId;
                        tmp.CurrentImage = bpp.BrandProductColor.ProductColor.Product.ImageProducts
                        .Where(i => i.Name.Equals(bpp.BrandProductColor.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                        tmp.ReviewTitle = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                        tmp.Introduce = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                        tmp.ConnectionType = bpp.BrandProductColor?.ProductColor?.Product?.Earphone?.ConnectionType;
                        tmp.Design = bpp.BrandProductColor?.ProductColor?.Product?.Earphone?.Design;
                        tmp.FrequencyResponse = bpp.BrandProductColor?.ProductColor?.Product?.Earphone?.FrequencyResponse;

                        tmp.Amount = bpp.BrandProductColor?.Amount;
                        tmp.BranchProductColorId = bpp.BrandProductColor?.Id;

                        list.Add(tmp);
                    }

                    list = list.DistinctBy(x => x.Id).OrderBy(x => x.Id)
                        .Skip((int)(dto.PageIndex * dto.PageSize))
                        .Take((int)dto.PageSize).ToList();

                    return list;
                });

                //dataList.Items = data;
                //_logger!.LogInfo($"Search Customer Result with data {JsonConvert.SerializeObject(data)}");
                return new ResponseData(data);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        #endregion get all product of branch include promotion

        #region get detail a product of branch

        // get base detail a product of smartphone
        public async Task<ResponseData> DetailProductSmartphoneAsync(RequestDetailProductDTO dto)
        {
            try
            {
                IEnumerable<Promotion> queryPromotionProduct = (IEnumerable<Promotion>)UnitOfWork.PromotionRepository.GetAll()
                    .Where(p => p.IsActive == true && p.IsDeleted == false)
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)

                    .ThenInclude(bpc => bpc.Branch)// get branch
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(p => p.Smartphone)

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.ImageProducts) // get image

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Reviews);             // get Reviews

                // fortmat and select list product promotion curent
                var dataPromotionProduct = queryPromotionProduct
                  .Select(x =>
                  {
                      List<DetailProductDTO> list = new List<DetailProductDTO>();
                      foreach (var bpp in x.BranchPromotionProducts)
                      {
                          if (bpp.IsDeleted == true || bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Id != dto.Id)
                          {
                              continue;
                          }
                          DetailProductDTO tmp = new DetailProductDTO();

                          tmp.Id = bpp.BrandProductColor.ProductColor.Product.Id;
                          tmp.Name = bpp.BrandProductColor.ProductColor.Product.Name;
                          tmp.ManufactureName = bpp.BrandProductColor.ProductColor.Product.NameManufactureId;
                          tmp.DiscountRate = bpp.DiscountRate;
                          tmp.BranchName = bpp.BrandProductColor.Branch.Name;

                          tmp.CurrentPrice = (decimal?)((double)bpp.BrandProductColor.ProductColor.Price - ((double)bpp.BrandProductColor.ProductColor.Price * bpp.DiscountRate));
                          tmp.Price = bpp.BrandProductColor.ProductColor.Price;
                          tmp.NameColorId = bpp.BrandProductColor.ProductColor.NameColorId;
                          tmp.ImageLink = bpp.BrandProductColor.ProductColor.Product.ImageProducts.Where(x => x.Name.Trim().Equals(bpp.BrandProductColor.ProductColor.NameColorId.Trim())).FirstOrDefault().LinkImg;

                          tmp.DiscountRate = bpp.DiscountRate;

                          tmp.CPU = bpp.BrandProductColor.ProductColor.Product.Smartphone.OperatorSystem;
                          tmp.RAM = bpp.BrandProductColor.ProductColor.Product.Smartphone.Ram;
                          tmp.ROM = bpp.BrandProductColor.ProductColor.Product.Smartphone.Rom;
                          tmp.Battery = bpp.BrandProductColor.ProductColor.Product.Smartphone.Battery;
                          tmp.Others = bpp.BrandProductColor.ProductColor.Product.Smartphone.Others;
                          tmp.Amount = bpp.BrandProductColor.Amount;

                          tmp.ProductColorId = bpp.BrandProductColor.ProductColor.Id;
                          tmp.OperatorSystem = bpp.BrandProductColor?.ProductColor?.Product?.Smartphone?.OperatorSystem;

                          tmp.ReviewTitle = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                          tmp.Introduce = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                          tmp.Amount = bpp.BrandProductColor?.Amount;
                          tmp.BranchProductColorId = bpp.BrandProductColor?.Id;

                          // image
                          foreach (var i in bpp.BrandProductColor?.ProductColor?.Product.ImageProducts)
                          {
                              if (i.ProductId != dto.Id)
                              {
                                  continue;
                              }
                              ImageProductDTO dtor = new ImageProductDTO();
                              dtor.Link = i.LinkImg;
                              dtor.Name = i.Name;

                              tmp.Image.Add(dtor);
                          }

                          // option
                          foreach (var j in x.BranchPromotionProducts)
                          {
                              if (!j.BrandProductColor.ProductColor.Product.Name.Trim().ToLower().Equals(bpp.BrandProductColor?.ProductColor?.Product.Name.Trim().ToLower()))
                              {
                                  continue;
                              }
                              OptionalProduct dtor = new OptionalProduct();
                              dtor.ProductId = j.BrandProductColor.ProductColor.ProductId;
                              dtor.RAM = j.BrandProductColor?.ProductColor?.Product?.Smartphone?.Ram;
                              dtor.ROM = j.BrandProductColor?.ProductColor?.Product?.Smartphone?.Rom;
                              tmp.Options.Add(dtor);
                          }
                          tmp.Options = tmp.Options.DistinctBy(x => x.ProductId).ToList();

                          // color
                          foreach (var k in x.BranchPromotionProducts)
                          {
                              if (k.BrandProductColor.ProductColor.Product.Id != dto.Id)
                              {
                                  continue;
                              }
                              ProductColorDTO dtor = new ProductColorDTO();
                              dtor.BranchProductColorId = k.BrandProductColorId;
                              dtor.Color = k.BrandProductColor?.ProductColor?.NameColorId;
                              dtor.Price = k.BrandProductColor?.ProductColor?.Price;
                              tmp.Color.Add(dtor);
                          }
                          tmp.Color = tmp.Color.DistinctBy(x => x.Color).ToList();
                          // lấy color

                          list.Add(tmp);
                      }

                      return list;
                  });

                return new ResponseData(dataPromotionProduct);
            }
            catch (Exception ex)
            {
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        public async Task<ResponseData> DetailProductLaptopAsync(RequestDetailProductDTO dto)
        {
            try
            {
                IEnumerable<Promotion> queryPromotionProduct = (IEnumerable<Promotion>)UnitOfWork.PromotionRepository.GetAll()
                    .Where(p => p.IsActive == true && p.IsDeleted == false)
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)

                    .ThenInclude(bpc => bpc.Branch)// get branch
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(p => p.Laptop)

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.ImageProducts) // get image

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Reviews);             // get Reviews

                // fortmat and select list product promotion curent
                var dataPromotionProduct = queryPromotionProduct
                  .Select(x =>
                  {
                      List<DetailProductDTO> list = new List<DetailProductDTO>();
                      foreach (var bpp in x.BranchPromotionProducts)
                      {
                          if (bpp.IsDeleted == true || bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Id != dto.Id)
                          {
                              continue;
                          }
                          DetailProductDTO tmp = new DetailProductDTO();

                          tmp.Id = bpp.BrandProductColor.ProductColor.Product.Id;
                          tmp.Name = bpp.BrandProductColor.ProductColor.Product.Name;
                          tmp.ManufactureName = bpp.BrandProductColor.ProductColor.Product.NameManufactureId;
                          tmp.DiscountRate = bpp.DiscountRate;
                          tmp.BranchName = bpp.BrandProductColor.Branch.Name;

                          tmp.CurrentPrice = (decimal?)((double)bpp.BrandProductColor.ProductColor.Price - ((double)bpp.BrandProductColor.ProductColor.Price * bpp.DiscountRate));
                          tmp.Price = bpp.BrandProductColor.ProductColor.Price;
                          tmp.NameColorId = bpp.BrandProductColor.ProductColor.NameColorId;
                          tmp.ImageLink = bpp.BrandProductColor.ProductColor.Product.ImageProducts.Where(x => x.Name.Trim().Equals(bpp.BrandProductColor.ProductColor.NameColorId.Trim())).FirstOrDefault().LinkImg;

                          tmp.DiscountRate = bpp.DiscountRate;

                          tmp.CPU = bpp.BrandProductColor.ProductColor.Product.Laptop.OperatorSystem;
                          tmp.RAM = bpp.BrandProductColor.ProductColor.Product.Laptop.Ram;
                          tmp.ROM = bpp.BrandProductColor.ProductColor.Product.Laptop.Rom;
                          tmp.Battery = bpp.BrandProductColor.ProductColor.Product.Laptop.Battery;
                          tmp.Others = bpp.BrandProductColor.ProductColor.Product.Laptop.Others;
                          tmp.GraphicCard = bpp.BrandProductColor.ProductColor.Product.Laptop.GraphicCard;

                          tmp.Amount = bpp.BrandProductColor.Amount;

                          tmp.ProductColorId = bpp.BrandProductColor.ProductColor.Id;
                          tmp.OperatorSystem = bpp.BrandProductColor?.ProductColor?.Product?.Laptop?.OperatorSystem;

                          tmp.ReviewTitle = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                          tmp.Introduce = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                          tmp.Amount = bpp.BrandProductColor?.Amount;
                          tmp.BranchProductColorId = bpp.BrandProductColor?.Id;

                          // image
                          foreach (var i in bpp.BrandProductColor?.ProductColor?.Product.ImageProducts)
                          {
                              if (i.ProductId != dto.Id)
                              {
                                  continue;
                              }
                              ImageProductDTO dtor = new ImageProductDTO();
                              dtor.Link = i.LinkImg;
                              dtor.Name = i.Name;

                              tmp.Image.Add(dtor);
                          }

                          // option
                          foreach (var j in x.BranchPromotionProducts)
                          {
                              if (!j.BrandProductColor.ProductColor.Product.Name.Trim().ToLower().Equals(bpp.BrandProductColor?.ProductColor?.Product.Name.Trim().ToLower()))
                              {
                                  continue;
                              }
                              OptionalProduct dtor = new OptionalProduct();
                              dtor.ProductId = j.BrandProductColor.ProductColor.ProductId;
                              dtor.RAM = j.BrandProductColor?.ProductColor?.Product?.Laptop?.Ram;
                              dtor.ROM = j.BrandProductColor?.ProductColor?.Product?.Laptop?.Rom;
                              tmp.Options.Add(dtor);
                          }
                          tmp.Options = tmp.Options.DistinctBy(x => x.ProductId).ToList();

                          // color
                          foreach (var k in x.BranchPromotionProducts)
                          {
                              if (k.BrandProductColor.ProductColor.Product.Id != dto.Id)
                              {
                                  continue;
                              }
                              ProductColorDTO dtor = new ProductColorDTO();
                              dtor.BranchProductColorId = k.BrandProductColorId;
                              dtor.Color = k.BrandProductColor?.ProductColor?.NameColorId;
                              dtor.Price = k.BrandProductColor?.ProductColor?.Price;
                              tmp.Color.Add(dtor);
                          }
                          tmp.Color = tmp.Color.DistinctBy(x => x.Color).ToList();
                          // lấy color

                          list.Add(tmp);
                      }

                      return list;
                  });

                return new ResponseData(dataPromotionProduct);
            }
            catch (Exception ex)
            {
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        public async Task<ResponseData> SearchDetailProductAsync(RequestDetailProductDTO dto)
        {
            try
            {
                var p = UnitOfWork.ProductRepository.Find(dto.Id);
                switch (p.Type)
                {
                    case TYPE_PRODUCT.SMARTPHONE:
                        {
                            var rs = await DetailProductSmartphoneAsync(dto);
                            return rs;
                        }
                    case TYPE_PRODUCT.LAPTOP:
                        {
                            var rs = await DetailProductLaptopAsync(dto);
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
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        #endregion get detail a product of branch

        #region search key product

        public async Task<ResponseData> SearchProductAsync(ProductSearchDto dto)
        {
            try
            {
                // get all of product promotion curent
                IEnumerable<Promotion> queryPromotionProduct = (IEnumerable<Promotion>)UnitOfWork.PromotionRepository.GetAll()
                    .Where(p => p.IsActive == true && p.IsDeleted == false)
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)

                    .ThenInclude(bpc => bpc.Branch)// get branch
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.ImageProducts) // get image

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Reviews);             // get Reviews

                // fortmat and select list product promotion curent
                var dataPromotionProduct = queryPromotionProduct
                  .Select(x =>
                  {
                      List<SearchProductOutputDTO> list = new List<SearchProductOutputDTO>();
                      foreach (var bpp in x.BranchPromotionProducts)
                      {
                          if (bpp.IsDeleted == true || bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Name.ToLower().Trim().Equals(dto.Search.ToLower().Trim()))
                          {
                              continue;
                          }
                          SearchProductOutputDTO tmp = new SearchProductOutputDTO();

                          tmp.Id = bpp.BrandProductColor.ProductColor.Product.Id;
                          tmp.Name = bpp.BrandProductColor.ProductColor.Product.Name;
                          tmp.ManufactureName = bpp.BrandProductColor.ProductColor.Product.NameManufactureId;

                          tmp.BranchName = bpp.BrandProductColor.Branch.Name;

                          tmp.CurrentPrice = (double)bpp.BrandProductColor.ProductColor.Price - ((double)bpp.BrandProductColor.ProductColor.Price * bpp.DiscountRate);
                          tmp.Price = (double)bpp.BrandProductColor.ProductColor.Price;
                          tmp.DiscountRate = bpp.DiscountRate;
                          tmp.ProductColorId = bpp.BrandProductColor.ProductColor.Id;
                          tmp.CurrentColor = bpp.BrandProductColor.ProductColor.NameColorId;
                          tmp.CurrentImage = bpp.BrandProductColor.ProductColor.Product.ImageProducts
                          .Where(i => i.Name.Equals(bpp.BrandProductColor.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                          tmp.ReviewTitle = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                          tmp.Introduce = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                          tmp.Amount = bpp.BrandProductColor?.Amount;
                          tmp.BranchProductColorId = bpp.BrandProductColor?.Id;

                          list.Add(tmp);
                      }

                      list = list.DistinctBy(x => x.Id).OrderBy(x => x.Id).ToList();

                      return list;
                  });

                // get all product
                IEnumerable<BranchProductColor> queryProduct = UnitOfWork.BranchProductColorRepository.GetAll()
                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.Reviews)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.ImageProducts)
                   .Include(x => x.Branch)
                   .Where(x => x.IsActive == true && x.IsDeleted == false && x.BranchId == dto.BranchId && x.ProductColor.Product.Name.ToLower().Trim().Contains(dto.Search.ToLower().Trim()));

                // fortmat and select list product  (not contain promotion
                var dataProduct = queryProduct
                  .Select(x =>
                  {
                      SearchProductOutputDTO tmp = new SearchProductOutputDTO();

                      tmp.Id = x.ProductColor.Product.Id;
                      tmp.Name = x.ProductColor.Product.Name;
                      tmp.ManufactureName = x.ProductColor.Product.NameManufactureId;

                      tmp.BranchName = x.Branch.Name;

                      tmp.CurrentPrice = (double)x.ProductColor.Price;
                      tmp.Price = (double)x.ProductColor.Price;

                      tmp.ProductColorId = x.ProductColor.Id;
                      tmp.CurrentColor = x.ProductColor.NameColorId;
                      tmp.CurrentImage = x.ProductColor.Product.ImageProducts
                      .Where(i => i.Name.Equals(x.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                      tmp.ReviewTitle = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                      tmp.Introduce = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                      tmp.Amount = x?.Amount;
                      tmp.BranchProductColorId = x?.Id;

                      return tmp;
                  }).OrderBy(X => X.Id).DistinctBy(x => x.Id).ToList();

                // get current (first or defaut promotion) // now code just work with one promotion
                var lenght = dataPromotionProduct.FirstOrDefault();

                for (int i = 0; i < dataProduct.Count(); i++)
                {
                    //int j = 0;
                    for (int j = 0; j < lenght.Count(); j++)
                    {
                        var item = lenght[j];
                        if (dataProduct[i].BranchProductColorId == item.BranchProductColorId)
                        {
                            dataProduct[i] = item;
                            break;
                        }
                        //j++
                    }
                }

                return new ResponseData(dataProduct);
            }
            catch (Exception ex)
            {
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        #endregion search key product

        #region search price

        public async Task<ResponseData> SearchProductFromToPriceAsync(ProductSearchDto dto)
        {
            try
            {
                // get all of product promotion curent
                IEnumerable<Promotion> queryPromotionProduct = (IEnumerable<Promotion>)UnitOfWork.PromotionRepository.GetAll()
                    .Where(p => p.IsActive == true && p.IsDeleted == false)
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)

                    .ThenInclude(bpc => bpc.Branch)// get branch
                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.ImageProducts) // get image

                    .Include(pm => pm.BranchPromotionProducts)
                    .ThenInclude(bpp => bpp.BrandProductColor)
                    .ThenInclude(bpc => bpc.ProductColor) // get product color
                    .ThenInclude(pc => pc.Product)
                    .ThenInclude(pro => pro.Reviews);             // get Reviews

                // fortmat and select list product promotion curent
                var dataPromotionProduct = queryPromotionProduct
                  .Select(x =>
                  {
                      List<SearchProductOutputDTO> list = new List<SearchProductOutputDTO>();
                      foreach (var bpp in x.BranchPromotionProducts)
                      {
                          if (bpp.IsDeleted == true || bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Type != dto.Type || (bpp.BrandProductColor.ProductColor.Price > dto.PriceFrom && bpp.BrandProductColor.ProductColor.Price < dto.PriceTo) == false)
                          {
                              continue;
                          }
                          SearchProductOutputDTO tmp = new SearchProductOutputDTO();

                          tmp.Id = bpp.BrandProductColor.ProductColor.Product.Id;
                          tmp.Name = bpp.BrandProductColor.ProductColor.Product.Name;
                          tmp.ManufactureName = bpp.BrandProductColor.ProductColor.Product.NameManufactureId;

                          tmp.BranchName = bpp.BrandProductColor.Branch.Name;

                          tmp.CurrentPrice = (double)bpp.BrandProductColor.ProductColor.Price - ((double)bpp.BrandProductColor.ProductColor.Price * bpp.DiscountRate);
                          tmp.Price = (double)bpp.BrandProductColor.ProductColor.Price;
                          tmp.DiscountRate = bpp.DiscountRate;
                          tmp.ProductColorId = bpp.BrandProductColor.ProductColor.Id;
                          tmp.CurrentColor = bpp.BrandProductColor.ProductColor.NameColorId;
                          tmp.CurrentImage = bpp.BrandProductColor.ProductColor.Product.ImageProducts
                          .Where(i => i.Name.Equals(bpp.BrandProductColor.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                          tmp.ReviewTitle = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                          tmp.Introduce = bpp.BrandProductColor?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                          tmp.Amount = bpp.BrandProductColor?.Amount;
                          tmp.BranchProductColorId = bpp.BrandProductColor?.Id;

                          list.Add(tmp);
                      }

                      list = list.DistinctBy(x => x.Id).OrderBy(x => x.Id).ToList();

                      return list;
                  });

                // get all product
                IEnumerable<BranchProductColor> queryProduct = UnitOfWork.BranchProductColorRepository.GetAll()
                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.Reviews)

                   .Include(x => x.ProductColor)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x => x.ImageProducts)
                   .Include(x => x.Branch)
                   .Where(x => x.IsActive == true && x.ProductColor.Product.Type == dto.Type && x.IsDeleted == false && x.BranchId == dto.BranchId && (x.ProductColor.Price > dto.PriceFrom && x.ProductColor.Price < dto.PriceTo) == true);

                // fortmat and select list product  (not contain promotion
                var dataProduct = queryProduct
                  .Select(x =>
                  {
                      SearchProductOutputDTO tmp = new SearchProductOutputDTO();

                      tmp.Id = x.ProductColor.Product.Id;
                      tmp.Name = x.ProductColor.Product.Name;
                      tmp.ManufactureName = x.ProductColor.Product.NameManufactureId;

                      tmp.BranchName = x.Branch.Name;

                      tmp.CurrentPrice = (double)x.ProductColor.Price;
                      tmp.Price = (double)x.ProductColor.Price;

                      tmp.ProductColorId = x.ProductColor.Id;
                      tmp.CurrentColor = x.ProductColor.NameColorId;
                      tmp.CurrentImage = x.ProductColor.Product.ImageProducts
                      .Where(i => i.Name.Equals(x.ProductColor.NameColorId.ToString()))?.FirstOrDefault()?.LinkImg;

                      tmp.ReviewTitle = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Title;
                      tmp.Introduce = x?.ProductColor?.Product?.Reviews?.FirstOrDefault()?.Content;
                      tmp.Amount = x?.Amount;
                      tmp.BranchProductColorId = x?.Id;

                      return tmp;
                  }).OrderBy(X => X.Id).DistinctBy(x => x.Id).ToList();

                // get current (first or defaut promotion) // now code just work with one promotion
                var lenght = dataPromotionProduct.FirstOrDefault();

                for (int i = 0; i < dataProduct.Count(); i++)
                {
                    //int j = 0;
                    for (int j = 0; j < lenght.Count(); j++)
                    {
                        var item = lenght[j];
                        if (dataProduct[i].BranchProductColorId == item.BranchProductColorId)
                        {
                            dataProduct[i] = item;
                            break;
                        }
                        //j++
                    }
                }

                return new ResponseData(dataProduct);
            }
            catch (Exception ex)
            {
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        #endregion search price

        public async Task<ResponseData> OrderLookUp(string deliveryPhone)
        {
            try
            {
                var od = UnitOfWork.OrderRepository.GetAll().Where(x => x.DeliveryPhone == deliveryPhone.Trim())
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.BrandProductColor)
                .ThenInclude(x => x.ProductColor)
                .ThenInclude(x => x.Product).ToList();

                var data = od.Select(x =>
                {
                    var tmp = new OrderLookupDTO();
                    tmp.OrderID = x.Id;
                    tmp.Status = x.Status;
                    tmp.ToltalPrice = (double)x.OrderDetails.Sum(x => x.UnitPrice * x.Quantity);
                    tmp.OrderDate = x.OrderDate;
                    // select product
                    //SELECT p.id AS id_product,
                    //            p.Name as Name,
                    //            od.unit_price as unitPrice,
                    //            od.Quantity as quantity,
                    //            pc.nameColor_id as nameColor,
                    //            bpc.id AS id_branch_product_color

                    List<ProductDetailLookUp> lsTMP = x.OrderDetails.Select(x =>
                    {
                        var tmp = new ProductDetailLookUp();

                        tmp.ProductId = (int)(x.BrandProductColor?.ProductColor?.Product?.Id);
                        tmp.Name = (x.BrandProductColor?.ProductColor?.Product.Name);
                        tmp.UnitPrice = (double)x.UnitPrice;
                        tmp.Quantity = x.Quantity;
                        tmp.NameColor = x.BrandProductColor.ProductColor.NameColorId;
                        tmp.BranchProductColorID = x.BrandProductColor.Id;

                        return tmp;
                    }).ToList();

                    tmp.ProductDetail = lsTMP;
                    tmp.BranchProductColorId = x.OrderDetails.FirstOrDefault().BrandProductColorId;

                    return tmp;
                });
                return new ResponseData(data);
            }
            catch (Exception ex)
            {
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        public string GetComment(int productId)
        {
            try
            {
                var comments = UnitOfWork.CommentRepository.GetAll()
               .Where(c => c.ProductId == productId && c.IsDeleted != true)
               .Include(c => c.InverseIdReplyNavigations) // load các comment phản hồi
                   .ThenInclude(r => r.User) // load thông tin IdUser của các comment phản hồi
               .Select(c => new
               {
                   Id = c.Id,
                   userName = c.User.UserName,
                   contentComment = c.ContentComment,
                   idUser = c.User.Id,
                   idProduct = c.ProductId,
                   commentReply = c.InverseIdReplyNavigations
                       .Select(r => new
                       {
                           Id = r.Id,
                           userName = r.User.UserName,
                           contentComment = r.ContentComment,
                           idUser = r.User.Id,
                           idProduct = r.ProductId,// lấy thông tin userName của các comment phản hồi
                       })
               })
               .ToList();

                string json2 = JsonConvert.SerializeObject(comments);
                return json2;
            }
            catch (Exception ex)
            {
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return "";
            }
        }

        public Comment AddComment(CommentPost comment)
        {
            var cm = new Comment()
            {
                ContentComment = comment.ContentComment,
                ProductId = (int)comment.IdProductId,
                UserId = comment.IdUserId,
                ReplyId = comment.IdReply
            };

            UnitOfWork.CommentRepository.Add(cm);
            UnitOfWork.SaveChanges();

            return cm;
        }

        public async Task<ResponseData> DeleteCommentOfProduct(int id)
        {
            try
            {
                var comment = await UnitOfWork.CommentRepository.FindAsync(id);
                if (comment == null)
                {
                    return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL);
                }
                comment.IsDeleted = true;
                // Xóa tất cả các comment reply của comment này
                var replyComments = UnitOfWork.CommentRepository.GetAll().Where(c => c.ReplyId == comment.Id);
                foreach (var x in replyComments)
                {
                    x.IsDeleted = true;
                }
                UnitOfWork.CommentRepository.Update(replyComments);

                // Xóa comment này
                UnitOfWork.CommentRepository.Update(comment);

                await UnitOfWork.SaveChangesAsync();

                return new ResponseData();
            }
            catch (Exception ex)
            {
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        public async Task<ResponseData> ReplyComment(CommentPostDTO comment)
        {
            try
            {
                var cm = new Comment()
                {
                    ContentComment = comment.ContentComment,
                    ProductId = (int)comment.ProductId,
                    UserId = comment.UserId,
                    ReplyId = comment.Reply
                };

                UnitOfWork.CommentRepository.Add(cm);
                UnitOfWork.SaveChanges();

                return new ResponseData(cm);
            }
            catch (Exception ex)
            {
                //_logger!.LogError($"Search Customer, Exception: {ex.Message}");
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.FAIL, ex.Message);
            }
        }

        public async Task<ResponseData> GetAllProduct(ProductSearchDto dto)
        {
            try
            {
                var query = UnitOfWork.ProductRepository.GetAll().Where(x => x.IsDeleted != true);

                var data = query.Select(x => new ProductListDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ManufactureName = x.NameManufactureId,
                    Type = x.Type
                }).ToList();

                return new ResponseData(data);
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.SYSTEM_ERROR);
            }
        }

        public string AddProduct(ProductListDto dto)
        {
            try
            {
                Domain.Entity.Product product = new Domain.Entity.Product()
                {
                    Name = dto.Name,
                    Type = dto.Type,
                    NameManufactureId = dto.ManufactureName,
                };

                UnitOfWork.ProductRepository.Add(product);
                UnitOfWork.SaveChanges();

                // lưu hình ảnh
                for (int i = 0; i < dto.Images.Count; i++)
                {
                    ImageProduct imageproduct = new ImageProduct()
                    {
                        Name = dto.Images[i].NameImage,
                        LinkImg = dto.Images[i].Images,
                        ProductId = product.Id
                    };
                    UnitOfWork.ImageProductRepository.Add(imageproduct);
                    UnitOfWork.SaveChanges();
                }

                // lưu introduce cho sản phẩm
                Random random = new Random();
                int randomNumber = random.Next(9999999);
                Domain.Entity.Review review = new Domain.Entity.Review()
                {
                    Id = randomNumber,

                    Title = dto.Title,
                    Content = dto.Content,
                    ProductId = product.Id
                };
                UnitOfWork.ReviewRepository.Add(review);
                UnitOfWork.SaveChanges();
                // lưu các thông số sản phẩm

                if (dto.Type == TYPE_PRODUCT.LAPTOP)
                {
                    Laptop lt = new Laptop()
                    {
                        Id = product.Id,

                        Cpu = dto.CPU,

                        Ram = dto.RAM,

                        Rom = dto.ROM,

                        GraphicCard = dto.GraphicCard,

                        Battery = dto.Battery,
                        OperatorSystem = dto.OperatorSystem,

                        Others = dto.Others,
                    };
                    UnitOfWork.LaptopRepository.Add(lt);
                    UnitOfWork.SaveChanges();
                }

                if (dto.Type == TYPE_PRODUCT.SMARTPHONE)
                {
                    Smartphone lt = new Smartphone()
                    {
                        Id = product.Id,

                        Cpu = dto.CPU,

                        Ram = dto.RAM,

                        Rom = dto.ROM,

                        Battery = dto.Battery,
                        OperatorSystem = dto.OperatorSystem,

                        Others = dto.Others,
                    };
                    UnitOfWork.SmartphoneRepository.Add(lt);
                    UnitOfWork.SaveChanges();
                }

                UnitOfWork.SaveChanges();

                // trả về cái respones
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                string json = System.Text.Json.JsonSerializer.Serialize(product, options);

                return json;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string GetDetailBasicProduct(int id)
        {
            try
            {
                // get infor of product table
                Product product = UnitOfWork.ProductRepository.Find(id);
                if (product == null)
                {
                    return null;
                }

                // get image ("options sau này ")

                // get review 
                Review review = UnitOfWork.ReviewRepository.GetAll().FirstOrDefault(p => p.ProductId == product.Id);

                // get specifications bbelong to type
                Smartphone smartphone = null;
                Laptop laptop = null;
                if (product.Type == TYPE_PRODUCT.SMARTPHONE)
                {
                    smartphone = UnitOfWork.SmartphoneRepository.Find(product.Id);
                }
                if (product.Type == TYPE_PRODUCT.LAPTOP)
                {
                    laptop = UnitOfWork.LaptopRepository.Find(product.Id);
                }

                var tmp = new ProductListDto();



                tmp.Id = id;
                tmp.Name = product.Name;
                tmp.ManufactureName = product.NameManufactureId;
                tmp.Type = product.Type;
                tmp.Images = new List<ImagesProduct>();

                tmp.Title = review != null ? review.Title : "";
                tmp.Content = review != null ? review.Content : "";


                // if the product is phone , we will get infor about that propertires
                if (product.Type == TYPE_PRODUCT.SMARTPHONE)
                {
                    tmp.CPU = smartphone.Cpu;
                    tmp.RAM = smartphone.Ram;
                    tmp.ROM = smartphone.Rom;
                    tmp.Battery = smartphone.Battery;
                    tmp.OperatorSystem = smartphone.OperatorSystem;
                    tmp.Others = smartphone.Others;
                }


                if (product.Type == TYPE_PRODUCT.LAPTOP)
                {
                    tmp.CPU = laptop.Cpu;
                    tmp.RAM = laptop.Ram;
                    tmp.ROM = laptop.Rom;
                    tmp.Battery = laptop.Battery;
                    tmp.OperatorSystem = laptop.OperatorSystem;
                    tmp.Others = laptop.Others;
                }

                string json = JsonConvert.SerializeObject(tmp);
                return json;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}