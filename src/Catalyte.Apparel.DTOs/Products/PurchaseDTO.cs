using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.DTOs.Products
{
    public class PurchaseDTO
    {
        public DateTime OrderDate { get; set; }

        public DeliveryAddressDTO DeliveryAddress { get; set; }

        public BillingAddressDTO BillingAddress { get; set; }

        public CreditCardDTO CreditCard { get; set; }

        public List<LineItemDTO> LineItems { get; set; }
    }
}
