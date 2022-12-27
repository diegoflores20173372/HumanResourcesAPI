using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesAPI.Entities
{
    public class EmployeeFamiliar
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string NameEmployeeFamiliar { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string LastNameEmployeeFamiliar { get; set; }
        [Range(1, 199, ErrorMessage = "El valor {0} debe ser entre {1} y {2}.")]
        public int AgeEmployeeFamiliar { get; set; }
    }
}
