using System;
using System.ComponentModel.DataAnnotations;

namespace Catalyte.Aquitas.Data.Model
{

    public class BaseEntity
    {

        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

    }

}
