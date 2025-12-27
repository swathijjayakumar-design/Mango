using Mango.Web.Utilities;
using static Mango.Web.Utilities.StaticDetails;

namespace Mango.Web.Models
{
    public class RequestDTO
    {
        public ApiTypes ApiType { get; set; } = ApiTypes.GET;
        public string Url { get; set; }
        public Object Data { get; set; }
        public string AccessToken {  get; set; }
    }
}
