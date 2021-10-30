namespace Catalyte.Aquitas.DTOs.Purchases
{
    public class CreditCardDTO
    {
        public string CardNumber { get; set; }

        public int CVV { get; set; }

        public string Expiration { get; set; }

        public string CardHolder { get; set; }
    }
}
