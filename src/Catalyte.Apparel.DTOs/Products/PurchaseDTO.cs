using System;

namespace Catalyte.Apparel.DTOs.Products
{
    public class PurchaseDTO
    {
        public DateTime OrderDate { get; set; }

        public DeliveryAddressDTO DeliveryAddress { get; set; }

        public BillingAddressDTO BillingAddress { get; set; }
    }
}
