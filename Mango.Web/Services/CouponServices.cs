using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utilities;

namespace Mango.Web.Services
{
    public class CouponServices: ICouponServices
    {
        private readonly IBaseServices _baseServices;
        public CouponServices(IBaseServices baseServices) 
        {
            _baseServices = baseServices;
        }

        public async Task<ResponseDTO?> CreateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseServices.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiTypes.POST,
                Data= couponDTO,
                Url = StaticDetails.CouponApiBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> DeleteCouponAsync(int couponId)
        {
            return await _baseServices.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiTypes.DELETE,
                Url = StaticDetails.CouponApiBase + "/api/coupon?id=" +  couponId
            });
        }

        public async Task<ResponseDTO?> GetCouponAllAsync()
        {
            return await _baseServices.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiTypes.GET,
                Url = StaticDetails.CouponApiBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> GetCouponAsync(string couponDescription)
        {
            return await _baseServices.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiTypes.GET,
                Url = StaticDetails.CouponApiBase + "/api/coupon/GetByCode" + couponDescription
            });
        }

        public async Task<ResponseDTO?> GetCouponByIdAsync(int couponId)
        {
            return await _baseServices.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiTypes.GET,
                Url = StaticDetails.CouponApiBase + "/api/coupon/" + couponId
            });
        }

        public async Task<ResponseDTO?> UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseServices.SendAsync(new RequestDTO()
            {
                ApiType = StaticDetails.ApiTypes.PUT,
                Data = couponDTO,
                Url = StaticDetails.CouponApiBase + "/api/coupon"
            });
        }
    }
}
