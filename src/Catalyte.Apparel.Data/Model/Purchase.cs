using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Model
{
    public class Purchase : BaseEntity
    {
        public DateTime OrderDate { get; set; }

        public DeliveryAddress DeliveryAddress { get; set; }

        public BillingAddress BillingAddress { get; set; }

        public List<LineItem> LineItems { get; set; }
    }
}
