using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utilities;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mango.Web.Utilities.StaticDetails;

namespace Mango.Web.Services
{
    public class BaseServices :IBaseServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseServices(IHttpClientFactory httpClientFactory )
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //token
                message.RequestUri = new Uri(requestDTO.Url);
                if (requestDTO.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? httpResponse = null;
                switch (requestDTO.ApiType)
                {
                    case ApiTypes.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiTypes.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiTypes.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }
                httpResponse = await httpClient.SendAsync(message);

                switch (httpResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Found"
                        };

                    case HttpStatusCode.Forbidden:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Access Denied"
                        };
                    case HttpStatusCode.Unauthorized:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "UnAuthorized"
                        };
                    case HttpStatusCode.InternalServerError:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Internal Server Error"
                        };
                    default:
                        var apiContent = await httpResponse.Content.ReadAsStringAsync();
                        var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDTO;

                }

            }
            catch (Exception ex)
            {

                var dto = new ResponseDTO()
                {
                    Message=ex.Message.ToString(),
                    IsSuccess=false

                };
                return dto;
            }           
        }
    }
}
