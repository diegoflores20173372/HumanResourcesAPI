using AutoMapper;
using HumanResourcesAPI.Data;
using HumanResourcesAPI.DTOs;
using HumanResourcesAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanResourcesAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EmployeeController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> Get()
        {
            var employees = await context.Employees.ToListAsync();
            return mapper.Map<List<EmployeeDTO>>(employees);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int Id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(emp => emp.Id == Id);
            if(employee == null)
            {
                return NotFound();
            }
            return mapper.Map<EmployeeDTO>(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeeCreateDTO employeeCreateDTO)
        {
            var employee = mapper.Map<Employee>(employeeCreateDTO);
            context.Add(employee);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] EmployeeCreateDTO employeeCreateDTO)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(emp => emp.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            employee = mapper.Map(employeeCreateDTO, employee);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var exist = await context.Employees.AnyAsync(ef => ef.Id == Id);
            if (!exist)
            {
                return NotFound();
            }
            context.Remove(new Employee() { Id = Id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
