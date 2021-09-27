using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Model
{
    public class Purchase : BaseEntity
    {
        public DeliveryAddress DeliveryAddress { get; set; }

        public BillingAddress BillingAddress { get; set; }

        public List<LineItem> LineItems { get; set; }
    }
}
