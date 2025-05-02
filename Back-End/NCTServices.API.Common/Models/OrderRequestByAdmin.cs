using NCTServices.Domain.Entity;

namespace NCTServices.API.Common.Models
{
    public class OrderRequestByAdmin
    {
        public int? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }

    }
}
