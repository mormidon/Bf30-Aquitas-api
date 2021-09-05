using System;

namespace Catalyte.Apparel.Data.Model
{

    public class Product : BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Demographic { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public DateTime ReleaseDate { get; set; }

        private string PrimaryColorCode { get; set; }

        private string SecondaryColorCode { get; set; }

        private string StyleNumber { get; set; }

        private string GlobalProductCode { get; set; }

        private bool Active { get; set; }

    }

}
