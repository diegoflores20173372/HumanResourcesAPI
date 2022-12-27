using AutoMapper;
using HumanResourcesAPI.DTOs;
using HumanResourcesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesAPI.Utilities
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeeFamiliar, EmployeeFamiliarDTO>().ReverseMap();
            CreateMap<EmployeeFamiliarCreateDTO, EmployeeFamiliar>();
        }

    }
}
