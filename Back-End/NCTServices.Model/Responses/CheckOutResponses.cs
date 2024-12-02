using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Model.Responses
{
    public class CheckOutResponses
    {
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal? ProductPrice { get; set; }

    }
}
