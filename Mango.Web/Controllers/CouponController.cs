using Mango.Web.Models;
using Mango.Web.Services;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponServices _couponServices;
        public CouponController(ICouponServices couponServices)
        {
            _couponServices = couponServices;
        }
        public async Task<IActionResult> CouponIndex()
        {
            
            List<CouponDTO> couponDTOs=new ();
            ResponseDTO? responseDTO = await _couponServices.GetCouponAllAsync();
            if (responseDTO != null && responseDTO.IsSuccess) 
            {
                couponDTOs=JsonConvert .DeserializeObject<List<CouponDTO>>(Convert.ToString(responseDTO.Result));

            }
            return View(couponDTOs);
        }
        [HttpGet]
        public IActionResult CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDTO couponDTO)
        {
            if (ModelState.IsValid)
            {
                ResponseDTO? responseDTO = await _couponServices.CreateCouponAsync(couponDTO);
                if (responseDTO != null && responseDTO.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));

                }
            }
            return View(couponDTO);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDTO? responseDTO = await _couponServices.GetCouponByIdAsync(id);

            if (responseDTO == null || !responseDTO.IsSuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }

            var coupon =
                JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(responseDTO.Result));

            return View(coupon); 
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CouponDTO couponDTO)
        {
            ResponseDTO? responseDTO = await _couponServices.DeleteCouponAsync(couponDTO.CouponID);
            
            return RedirectToAction(nameof(CouponIndex));
            
        }
    }
}
