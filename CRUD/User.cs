using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(35)]
        public string Name { get; set; }
    }
}
