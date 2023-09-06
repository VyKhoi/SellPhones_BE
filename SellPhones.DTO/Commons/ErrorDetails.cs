using Newtonsoft.Json;

namespace SellPhones.DTO.Commons
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}