namespace SellPhones.DTO.User
{
    public class UserCreateAccountDto
    {
        public string? Name { get; set; } = null!;

        public string? Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? PassWord { get; set; }

        public bool IsActive { get; set; } = true;
    }
}