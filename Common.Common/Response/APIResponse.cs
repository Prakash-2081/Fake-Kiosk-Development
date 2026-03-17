using System.Net;

namespace Common.Common.Response
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public HttpStatusCode Code { get; set; }
        public dynamic? Data { get; set; }
        public string Message { get; set; }

        public APIResponse() { }
        public APIResponse(bool success,HttpStatusCode code,dynamic? data,string message)
        {
            Success=success;
            Code=code;
            Data=data;
            Message=message;
        }
        public APIResponse(bool success,HttpStatusCode code,string message)
        {
            Success=success;
            Code=code;
            Message=message;
        }
    }
}
