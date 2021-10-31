using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Model
{
    public class User : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
 
        public string ScreenName { get; set; }
       
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string LinkedInUsername { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public string Country { get; set; }
    }
}
