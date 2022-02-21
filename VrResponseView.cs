using System.Net;

namespace FCS.Virk
{
    public class VrResponseView
    {
        public HttpStatusCode Code { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public string Message { get; set; } = "";
    }
}