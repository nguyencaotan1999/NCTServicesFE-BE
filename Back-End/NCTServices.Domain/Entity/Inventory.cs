using NCTServices.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NCTServices.Domain.Entity
{
    public class Inventory : BaseEntity
    {
       

        public int Quantity { get; set; }

        [MaxLength(255)]
        public string? TransactionType {get;set;}

        [MaxLength(255)]
        public string? Description { get; set; }

        public DateTime TransactionDate = DateTime.Now;

        public int ProductId { get; set; }


        //navigation properties
        public Products? Products { get; set; }

    }
}
