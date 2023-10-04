using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellPhones.DTO.Auth;
using SellPhones.DTO.Commons;
using SellPhones.DTO.User;
using SellPhones.Service.Interfaces;
using System.Net;

namespace SellPhones.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController : BaseController
    {
        private IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {

            this._accountService = accountService;
        }

        /// <summary>
        /// Đăng nhập cho khách hàng bình thường
        /// </summary>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var loginDto = new LoginBodyDto()
                {
                    UserName = model.UserName,
                    Password = model.Password,
                   
                    FirebaseTokenWeb = model.FirebaseToken
                };
                var response = await _accountService.LoginAsync(loginDto);


                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Tạo tài khoản học viên
        /// </summary>
        [HttpPost("Create")]
        public async Task<ActionResult> CreateLearner([FromBody] UserCreateAccountDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                return Ok(new ResponseData(HttpStatusCode.BadRequest, false, Commons.ErrorCode.FULLNAME_IS_REQUIRE));
            }
         
            var response = await _accountService.CreateCustomerAsync(dto);
            return Ok(response);
        }

    }
}
