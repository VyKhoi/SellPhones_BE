namespace SellPhones.DTO.Customer
{
    public class CustomerListDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? Gender { get; set; }
        public string? Hometown { get; set; }
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? PhoneNumber { get; set; }
    }
}