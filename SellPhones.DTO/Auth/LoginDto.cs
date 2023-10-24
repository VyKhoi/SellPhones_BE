using SellPhones.Domain.Entity.Identity;
using System.ComponentModel.DataAnnotations;

namespace SellPhones.DTO.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Passwod is required.")]
        public string Password { get; set; } = string.Empty;

        public string? FirebaseToken { set; get; }
    }

    public class LoginBodyDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Passwod is required.")]
        public string Password { get; set; } = string.Empty;

        public string? FirebaseTokenWeb { set; get; }
    }

    public class LoginWithSocialDto
    {
        public string? AccesssToken { get; set; }
        public string? Uid { get; set; }
        public TYPE_LOGIN? TypeLogin { get; set; }
        public string? FirebaseToken { set; get; }
        public string? Email { set; get; }
        public string? DisplayName { set; get; }
    }

    public class LoginResponseDto
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredAt { get; set; }

        //
        public string? RoleName { get; set; }

        public List<string>? GroupRoles { get; set; }
        public List<string>? UserRoles { get; set; }
        public string? Name { get; set; }
    }
}