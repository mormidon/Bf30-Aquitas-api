using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalyte.Apparel.Data.SeedData
{
    public class ProductFactory
    {
        Random _rand = new();

        private List<string> _colors = new()
        {
            "#000000", // white
            "#ffffff", // black
            "#39add1", // light blue
            "#3079ab", // dark blue
            "#c25975", // mauve
            "#e15258", // red
            "#f9845b", // orange
            "#838cc7", // lavender
            "#7d669e", // purple
            "#53bbb4", // aqua
            "#51b46d", // green
            "#e0ab18", // mustard
            "#637a91", // dark gray
            "#f092b0", // pink
            "#b7c0c7"  // light gray
        };

        private readonly List<string> _demographics = new()
        {
            "Men",
            "Women",
            "Kids"
        };
        private readonly List<string> _categories = new()
        {
            "Golf",
            "Soccer",
            "Basketball",
            "Hockey",
            "Football",
            "Running",
            "Baseball",
            "Skateboarding",
            "Boxing",
            "Weightlifting"
        };

        private List<string> _adjectives = new()
        {
            "Lightweight",
            "Slim",
            "Shock Absorbing",
            "Exotic",
            "Elastic",
            "Fashionable",
            "Trendy",
            "Next Gen",
            "Colorful",
            "Comfortable",
            "Water Resistant",
            "Wicking",
            "Heavy Duty"
        };

        private List<string> _types = new()
        {
            "Pant",
            "Short",
            "Shoe",
            "Glove",
            "Jacket",
            "Tank Top",
            "Sock",
            "Sunglasses",
            "Hat",
            "Helmet",
            "Belt",
            "Visor",
            "Shin Guard",
            "Elbow Pad",
            "Headband",
            "Wristband",
            "Hoodie",
            "Flip Flop",
            "Pool Noodle"
        };

        private List<string> _skus = new()
        {
            "SHL-100-Blue",
            "SHL-100-Red",
            "HOV-AB-KJ",
            "TLX-DRESS-SM",
            "ATK-34-RD",
            "TRE-33-LRG",
            "TRE-30-SM"
        };

        private string GetDemographic()
        {
            return _demographics[_rand.Next(0, 2)];
        }

        private string GetRandomProductId()
        {
            return "po-" + RandomString(7);
        }

        private string GetStyleCode()
        {
            return "sc" + RandomString(5);
        }

        public List<Product> GenerateRandomProducts(int numberOfProducts)
        {

            var productList = new List<Product>();

            for (var i = 0; i < numberOfProducts; i++)
            {
                productList.Add(CreateRandomProduct(i+1));
            }

            return productList;
        }

        private Product CreateRandomProduct(int id)
        {
            return new Product
            {
                Id=id,
                Category = _categories[_rand.Next(0, 9)],
                Type = "Pant",
                Sku = _skus[id-1],
                Demographic = GetDemographic(),
                GlobalProductCode = GetRandomProductId(),
                StyleNumber = GetStyleCode(),
                ReleaseDate = DateTime.Now,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };
        }

        private string RandomString(int size, bool lowerCase = false)
        {

            // ** Learning moment **
            // Code From
            // https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

            // ** Learning moment **
            // Always use a string builder when concatenating more than a couple of strings.
            // Why? https://www.geeksforgeeks.org/c-sharp-string-vs-stringbuilder/
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                // ** Learning moment **
                // Because 'char' is a reserved word you can put '@' at the beginning to allow
                // its use as a variable name.  You could do the same thing with 'class'
                var @char = (char)_rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }





    }
}
