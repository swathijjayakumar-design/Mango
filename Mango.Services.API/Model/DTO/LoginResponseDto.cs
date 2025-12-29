namespace Mango.Services.AuthApi.Model.DTO
{
    public class LoginResponseDto
    {
        public UserDTO User { get; set; }
        public string token { get; set; }
    }
}
