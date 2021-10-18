﻿using System.ComponentModel.DataAnnotations;

namespace Catalyte.Aquitas.DTOs.Purchases
{
    public class DeliveryAddressDTO
    {
        public string DeliveryFirstName { get; set; }

        public string DeliveryLastName { get; set; }

        public string DeliveryStreet { get; set; }

        public string DeliveryStreet2 { get; set; }

        public string DeliveryCity { get; set; }
        [MaxLength(2,ErrorMessage = "State can only be two characters")]
        public string DeliveryState { get; set; }

        public int DeliveryZip { get; set; }
    }
}
