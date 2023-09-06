using SellPhones.Commons;
using System.Net;

namespace SellPhones.DTO.Commons
{
    public class ResponseAPI
    {
        public int statusCode { get; set; }
        public bool success { get; set; }
        public string? message { get; set; }
        public dynamic? data { get; set; }
    }

    public class ResponseData
    {
        public HttpStatusCode statusCode { get; set; }
        public bool success { get; set; }
        public string? message { get; set; }
        public dynamic? data { get; set; }

        public ResponseData()
        { }

        public ResponseData(dynamic _data)
        {
            statusCode = HttpStatusCode.OK;
            success = true;
            message = ErrorCode.SUCCESSFULL;
            data = _data;
        }

        public ResponseData(bool _success, string _message)
        {
            statusCode = HttpStatusCode.OK;
            success = _success;
            message = _message;
        }

        public ResponseData(HttpStatusCode _statusCode, bool _success, string _message)
        {
            statusCode = _statusCode;
            success = _success;
            message = _message;
        }

        public ResponseData(HttpStatusCode _statusCode, bool _success, string _message, dynamic _data)
        {
            statusCode = _statusCode;
            success = _success;
            message = _message;
            data = _data;
        }
    }
}