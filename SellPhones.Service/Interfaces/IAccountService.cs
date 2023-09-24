using SellPhones.DTO.Auth;
using SellPhones.DTO.Commons;
using SellPhones.DTO.User;

namespace SellPhones.Service.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseData> CreateCustomerAsync(UserCreateAccountDto dto);
        Task<ResponseData> LoginAsync(LoginBodyDto login);
        Task<ResponseData> LoginWithSocialAsync(LoginWithSocialDto model);
    }
}