using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength:30, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string NameEmployee { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string LastNameEmployee { get; set; }
        [Range(1, 199, ErrorMessage = "El valor {0} debe ser entre {1} y {2}.")]
        public int AgeEmployee { get; set; }
        [EmailAddress]
        public string EmailEmployee { get; set; }
    }
}
