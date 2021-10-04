using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.DTOs.Products
{
    public class BillingAddressDTO
    {
        public string BillingStreet { get; set; }

        public string BillingStreet2 { get; set; }

        public string BillingCity { get; set; }

        public string BillingState { get; set; }

        public int BillingZip { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
