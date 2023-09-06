using SellPhones.Data.Interfaces;
using SellPhones.Domain.Entity;
using SellPhones.DTO.Commons;
using SellPhones.Service.Interfaces;

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