using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace buildfor_2030_Aquitas_api.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage =" First Name cannot be null or empty")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required(ErrorMessage = " Screen Name cannot be null or empty")]
        public string ScreenName { get; set; }
        [Required(ErrorMessage = " email cannot be null or empty")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = " password cannot be null or empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = " LinkedIn username cannot be null or empty")]
        public string LinkedInUsername { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public string Country { get; set; }
    }
}

