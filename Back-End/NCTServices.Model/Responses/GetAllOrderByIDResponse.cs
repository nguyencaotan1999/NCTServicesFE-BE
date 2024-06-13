using NCTServices.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace NCTServices.Model.Responses
{
    public class GetAllOrderByIDResponse
    {
        public int? UserId { get; set; }
        public int? OrderDetailId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? STATUS { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; } 

    }
}
