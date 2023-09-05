using SellPhones.Data.Interfaces;
using SellPhones.Service.Interfaces;
using SellPhones.DTO.Commons;
using SellPhones.Domain.Entity;

namespace SellPhones.Service.Implementation
{
    public class ManufactureService : BaseService, IManufactureService
    {
        public ManufactureService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
        //test laasy data
        public ResponseData GetAll()
        {
            var ls = UnitOfWork.ManufactureRepository.GetAll().Select(x => new Manufacture()
            {
                Name = x.Name,
                AddedTimestamp = x.AddedTimestamp
            }).ToList();
            return new ResponseData(ls);
        }

        
    }
}