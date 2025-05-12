using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Model.Requests
{
    public class CustomerRequest
    {
        public int RowId { get; set; } 

        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerRegion { get; set; }


    }
    
}
