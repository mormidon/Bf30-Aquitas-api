using System;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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

        public string PrimaryColorCode { get; set; }

        public string SecondaryColorCode { get; set; }

        public string StyleNumber { get; set; }

        public string GlobalProductCode { get; set; }

        public bool Active { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
