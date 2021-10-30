using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Model
{
    public class Company : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public string Summary { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }

        public string Industry { get; set; }

        public int EmployeeSize { get; set; }

        public bool IsPrivateCompany { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
