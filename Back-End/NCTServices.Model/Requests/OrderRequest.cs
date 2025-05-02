

namespace NCTServices.Model.Requests
{
    public class OrderRequest
    {
        public int? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }
    }
}
