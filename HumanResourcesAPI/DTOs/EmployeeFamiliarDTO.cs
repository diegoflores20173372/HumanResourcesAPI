using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesAPI.DTOs
{
    public class EmployeeFamiliarDTO
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public string NameEmployeeFamiliar { get; set; }
        public string LastNameEmployeeFamiliar { get; set; }
        public int AgeEmployeeFamiliar { get; set; }
    }
}
