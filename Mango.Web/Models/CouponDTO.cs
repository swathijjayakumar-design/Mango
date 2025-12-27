using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Services.IServices
{
    public class CouponDTO
    {
        [Key]
        public int CouponID { get; set; }
        [Required]
        public string CouponDescription { get; set; }
        [Required]
        public double CouponAmount { get; set; }
        public int DiscAmount { get; set; }
    }
}
