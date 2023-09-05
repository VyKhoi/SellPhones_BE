using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SellPhones.Domain.Entity.Identity;

namespace SellPhones.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected List<string> GetModelStateErrors()
        {
            return ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList();
        }

        protected string GetUserIdLogin()
        {
            return User.FindFirstValue(ClaimTypes.Name);
        }

        protected string GetProfileIdLogin()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        protected string GetHost()
        {
            return $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        }
    }
}
