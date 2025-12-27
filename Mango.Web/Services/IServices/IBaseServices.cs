using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IBaseServices
    {
       Task<ResponseDTO?> SendAsync(RequestDTO requestDTO);
    }
}
