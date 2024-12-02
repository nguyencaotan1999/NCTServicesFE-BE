using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Model.Responses
{
    public class UserResponses
    {
        public int RowId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? UserRole { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public string? Address { get; set; }
    }
}
