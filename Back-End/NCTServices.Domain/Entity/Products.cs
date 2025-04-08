using NCTServices.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Domain.Entity
{
    public class Products : BaseEntity
    {
        [MaxLength(50)]
        public string ProductName { get; set; } = string.Empty;
        public string? Brand { get; set; }
        public decimal Volume { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryID { get; set; }


        //Navigation properties
        public Categories? Categories { get; set; }
        public virtual ICollection<OrderDetails> OrderDetail { get; set; } = new List<OrderDetails>();
        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    }
}
