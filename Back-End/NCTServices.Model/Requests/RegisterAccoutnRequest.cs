using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Model.Requests
{
    public class RegisterAccoutnRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } = string.Empty;

    }
}
