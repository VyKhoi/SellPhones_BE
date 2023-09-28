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
                var data = query.Skip(dto.PageIndex * dto.PageSize)
                .Take(dto.PageSize)
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
                }).OrderBy(X=> X.Id).ToList();
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
                var data = query.Skip(dto.PageIndex * dto.PageSize)
                .Take(dto.PageSize)
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
                var data = query.Skip(dto.PageIndex * dto.PageSize)
                .Take(dto.PageSize)
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
                _logger!.LogError($"Search Customer, Exception: {ex.Message}");
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
                        if (bpp.IsDeleted = false && (bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Type != dto.Type))
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
                        .Skip(dto.PageIndex * dto.PageSize)
                        .Take(dto.PageSize).ToList();

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
                        if (bpp.IsDeleted = false && (bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Type != dto.Type))
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
                        .Skip(dto.PageIndex * dto.PageSize)
                        .Take(dto.PageSize).ToList();

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
                        if (bpp.IsDeleted = false && (bpp.BrandProductColor.BranchId != dto.BranchId || bpp.BrandProductColor.ProductColor.Product.Type != dto.Type))
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
                        .Skip(dto.PageIndex * dto.PageSize)
                        .Take(dto.PageSize).ToList();

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

                List<DetailProductDTO> rs = query.Select(x => new DetailProductDTO()
                {
                    Id = dto.Id,
                    Name = x.ProductColor.Product.Name,
                }).ToList();
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

        #endregion get detail a product of branch

        #region search key product
        public async Task<ResponseData> SearchProductAsync(RequestDetailProductDTO dto)
        {
          
        }

        #endregion

    }
}