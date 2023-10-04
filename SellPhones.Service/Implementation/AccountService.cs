using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SellPhones.Commons;
using SellPhones.Data.Interfaces;
using SellPhones.Domain.Entity.Identity;
using SellPhones.DTO.Auth;
using SellPhones.DTO.Commons;
using SellPhones.DTO.Role;
using SellPhones.DTO.User;
using SellPhones.Service.Interfaces;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace SellPhones.Service.Implementation
{
    public class AccountService : BaseService, IAccountService
    {
        //public IConfiguration Configuration { get; set; }
        public AccountService(IUnitOfWork UnitOfWork, SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration) : base(UnitOfWork, configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            //Configuration = configuration;
        }

        //get token
        private string GetToken(List<Claim> authClaims)
        {
            //_logger.LogInfo($"[AuthService] -> GetToken -> Generate token");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration!["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddDays(2),
                claims: authClaims,
                signingCredentials: credentials);

            //_logger.LogInfo($"[AuthService] -> GetToken -> Generate token successfully");
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // tạo reponse
        private async Task<LoginResponseDto> GenerateResponse(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {   new Claim(ClaimTypes.NameIdentifier,user.UserName),
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var token = GetToken(authClaims);
            var data = new LoginResponseDto
            {
                UserId = user.Id,
                Token = token,
                ExpiredAt = DateTime.UtcNow.AddDays(2),
                //Lang = user.Language
            };
            return data;
        }

        // create account
        public async Task<ResponseData> CreateCustomerAsync(UserCreateAccountDto dto)
        {
            try
            {
          
                if (UnitOfWork.UserRepository.GetAll().Any(x => x.UserName.ToLower() == dto.Email.ToLower() || x.Email == dto.Email))
                {
                   
                    return new ResponseData(HttpStatusCode.Conflict, false, Commons.ErrorCode.USER_EXISTED);
                };
                User user = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = dto.Email,
                    Email = dto.Email,
                    Code = $"LN{10000 + UnitOfWork.UserRepository.GetAll().Count()}",
                    IsActive = dto.IsActive,
                    PhoneNumber = dto.PhoneNumber,
                    NormalizedEmail = dto.Email.ToUpper(),
                    NormalizedUserName = dto.Email.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    FirebaseTokenWeb = null,

                };

                user.PasswordHash = new PasswordHasher<User>().HashPassword(user, dto.PassWord);

                UnitOfWork.UserRepository.Add(user);

                await UnitOfWork.SaveChangesAsync();
              

                return new ResponseData(new { Id = user.Id }); ;
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, Commons.ErrorCode.INSERT_FAIL, dto);
            }
        }

        // login acount normal
        public async Task<ResponseData> LoginAsync(LoginBodyDto login)
        {
            var query = UnitOfWork.UserRepository.GetAll();

            var user = query.FirstOrDefault(x => x.Email.ToLower() == login.UserName.ToLower() && x.IsActive && !x.IsDeleted);
            if (user == null)
            {
                return new ResponseData(HttpStatusCode.NotFound, true, ErrorCode.LOGIN_ERROR);
            }

            if (user.LockoutEnabled && user.LockoutEnd.HasValue && user.LockoutEnd.Value.CompareTo(DateTime.UtcNow) > 0)
            {
                return new ResponseData(HttpStatusCode.Conflict, true, ErrorCode.LOGIN_ERROR);
            }

            var identityResult = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (identityResult.Succeeded)
            {
                //var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {   new Claim(ClaimTypes.NameIdentifier,user.UserName),
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                };

                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                var usrRoles = (from role in UnitOfWork.RoleRepository.GetAll()
                                join usrl in UnitOfWork.UserRoleRepository.GetAll() on role.Id equals usrl.RoleId
                                where usrl.UserId == user.Id
                                select new UserRoleDto()
                                {
                                    Name = role.Name
                                }).Select(x => x.Name).ToList();

                //var roleName = UnitOfWork.GroupRepository.GetAll().Where(x => x.Id == user.GroupId).Select(x => x.Code);
                var roleName = UnitOfWork.GroupRepository.GetAll().Where(x => x.Id == user.GroupId).Select(x => x.Code);

                var groupRoles = (from grp in UnitOfWork.GroupRepository.GetAll()
                                  join grprle in UnitOfWork.GroupRoleRepository.GetAll() on grp.Id equals grprle.GroupId
                                  join rle in UnitOfWork.RoleRepository.GetAll() on grprle.RoleId equals rle.Id
                                  where grp.Id == user.GroupId
                                  select new UserRoleDto()
                                  {
                                      Name = rle.Name
                                  }).Select(x => x.Name).ToList();

                //add firebase token
                if (!string.IsNullOrEmpty(login.FirebaseTokenWeb))
                {
                    user.FirebaseTokenWeb = login.FirebaseTokenWeb;

                    UnitOfWork.UserRepository.Update(user);

                    UnitOfWork.SaveChanges();
                }

                var token = GetToken(authClaims);
                var data = new LoginResponseDto
                {
                    UserId = user.Id,
                    RoleName = roleName.ToString(),
                    GroupRoles = groupRoles,
                    UserRoles = usrRoles,
                    userName = user.Name,
                    Token = token,
                    ExpiredAt = DateTime.UtcNow.AddHours(24),
                };
                return new ResponseData(data);
            }

            return new ResponseData(HttpStatusCode.Conflict, true, ErrorCode.LOGIN_ERROR);
        }

        // login with google
        public async Task<ResponseData> LoginWithSocialAsync(LoginWithSocialDto model)
        {
            try
            {
                var firebase = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(model.AccesssToken);
                var emailExists = firebase.Claims.ContainsKey("email");
                string Uid = "", email = "";
                if (emailExists)
                {
                    //auto false
                    email = firebase.Claims["email"].ToString();
                }

                if (string.IsNullOrEmpty(email))
                {
                    email = model.Email != null ? model.Email : "";
                }

                if (model.TypeLogin == TYPE_LOGIN.Google)
                {
                    Uid = firebase.Uid;
                }
                if (string.IsNullOrWhiteSpace(model.FirebaseToken))
                {
                }
                if (firebase == null || firebase.Uid != model.Uid)
                {
                    return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.INVALID_TOKEN);
                }

                User accountDeleted = new User();

                #region Check account delete

                if (!string.IsNullOrWhiteSpace(email))
                {
                    // check account delete
                    accountDeleted = UnitOfWork.UserRepository.GetAll()
                        .Where(x => x.Email.ToLower() == email.ToLower() && !x.IsActive && x.IsDeleted).FirstOrDefault();
                }
                else
                {
                    // check account delete
                    accountDeleted = UnitOfWork.UserRepository.GetAll()
                        .Where(x => x.SocialId.ToLower() == Uid.ToLower() && !x.IsActive && x.IsDeleted).FirstOrDefault();
                }

                #endregion Check account delete

                if (accountDeleted != null) // acount đã delete.
                {
                    return new ResponseData(HttpStatusCode.NotAcceptable, false, ErrorCode.CHOOSE_ANOTHER_ACCOUNT_GOOGLE);
                }
                else
                {
                    //check exist database
                    var user = UnitOfWork.UserRepository.GetAll().Where(x => /*x.SocialId == firebase.Uid && */  x.Email == email).FirstOrDefault();
                    if (user == null)
                    {
                        // sử lý tạo mói user ở đâys

                        User newUser = new User();

                        if (!string.IsNullOrWhiteSpace(email))
                        {
                            newUser.Email = email;
                        }
                        else
                        {
                            //newUser.Email = Uid;
                            return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.INVALID_EMAIL);
                        }

                        newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, firebase.Uid);

                        UnitOfWork.UserRepository.Add(newUser);
                        UnitOfWork.SaveChanges();

                        var data = await GenerateResponse(newUser);
                        return new ResponseData(data);
                    }
                    else
                    {
                        // update lại firebase token mới
                        if (user.FirebaseTokenWeb != model.FirebaseToken)
                        {

                            if (user.Email.ToLower() != email.ToLower())
                            {
                                user.Email = email;
                                user.NormalizedEmail = email;
                                user.NormalizedUserName = email;
                                user.Email = email;
                            }
                            user.FirebaseTokenWeb = model.FirebaseToken;

                            UnitOfWork.UserRepository.Update(user);
                            await UnitOfWork.SaveChangesAsync();
                        }
                        var data = await GenerateResponse(user);
                        return new ResponseData(data);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseData(HttpStatusCode.BadRequest, false, ErrorCode.INVALID_TOKEN);
            }
        }
    }
}