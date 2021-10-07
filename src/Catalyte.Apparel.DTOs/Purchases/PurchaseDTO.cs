using System;
using System.Collections.Generic;
using Catalyte.Apparel.DTOs.Purchases;

namespace Catalyte.Apparel.DTOs.Purchases
{
    public class PurchaseDTO
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DeliveryAddressDTO DeliveryAddress { get; set; }

        public BillingAddressDTO BillingAddress { get; set; }

        public CreditCardDTO CreditCard { get; set; }

        public List<LineItemDTO> LineItems { get; set; }
    }
}
