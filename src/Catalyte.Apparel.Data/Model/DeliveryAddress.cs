namespace Catalyte.Apparel.Data.Model
{

    public class DeliveryAddress : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DeliveryStreet { get; set; }

        public string DeliveryStreet2 { get; set; }

        public string DeliveryCity { get; set; }

        public string DeliveryState { get; set; }

        public int DeliveryZip { get; set; }

    }

}
