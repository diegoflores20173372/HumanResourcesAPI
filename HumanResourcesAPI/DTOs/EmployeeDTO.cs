using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesAPI.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string LastNameEmployee { get; set; }
        public int AgeEmployee { get; set; }
        public string EmailEmployee { get; set; }
    }
}
