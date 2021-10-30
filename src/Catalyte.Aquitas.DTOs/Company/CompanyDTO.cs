using Catalyte.Aquitas.DTOs.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.DTOs.Company
{
    public class CompanyDTO
    {
        public string Name { get; set; }

        public string Summary { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }

        public string Industry { get; set; }

        public int EmployeeSize { get; set; }

        public bool IsPrivateCompany { get; set; }

        public string Reviews { get; set; }
    }
}
