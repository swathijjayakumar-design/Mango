using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface ICouponServices
    {
        Task<ResponseDTO?> GetCouponAsync(string couponDescription);
        Task<ResponseDTO?> GetCouponByIdAsync(int couponId);
        Task<ResponseDTO?> GetCouponAllAsync();
        Task<ResponseDTO?> CreateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> UpdateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> DeleteCouponAsync(int couponId);

    }
}
