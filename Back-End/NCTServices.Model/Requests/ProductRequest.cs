﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Model.Requests
{
    public class ProductRequest
    {
        public int? RowId { get; set; }
        public string? ProductName { get; set; }
        public string? Branch { get; set; }
        public decimal? Volumn { get; set; }
        public string? Color { get; set; }
        public string? StockQuantity { get; set; }
        public string? ProductDescription { get; set; }
        public double? Price { get; set; }
        public byte[]? Image { get; set; }
        public int? QuantityInStock { get; set; }
        public int? CategoryID { get; set; }

    }
}
