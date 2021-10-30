using System.ComponentModel.DataAnnotations;

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

        public string Reviews { get; set; }
    }
}
