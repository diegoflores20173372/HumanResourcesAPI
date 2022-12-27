using AutoMapper;
using HumanResourcesAPI.Data;
using HumanResourcesAPI.DTOs;
using HumanResourcesAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesAPI.Controllers
{
    [Route("api/employee_familiar")]
    [ApiController]
    public class EmployeeFamiliarController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EmployeeFamiliarController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeFamiliarDTO>>> Get()
        {
            var employeesFamiliar = await context.EmployeeFamiliars.ToListAsync();
            return mapper.Map<List<EmployeeFamiliarDTO>>(employeesFamiliar);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<EmployeeFamiliarDTO>> Get(int Id)
        {
            var employeeFamiliar = await context.EmployeeFamiliars.FirstOrDefaultAsync(emp => emp.Id == Id);
            if (employeeFamiliar == null)
            {
                return NotFound();
            }
            return mapper.Map<EmployeeFamiliarDTO>(employeeFamiliar);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeeFamiliarCreateDTO employeeFamiliarCreateDTO)
        {
            var employeeFamiliar = mapper.Map<EmployeeFamiliar>(employeeFamiliarCreateDTO);
            context.Add(employeeFamiliar);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] EmployeeFamiliarCreateDTO employeeFamiliarCreateDTO)
        {
            var employeeFamiliar = await context.EmployeeFamiliars.FirstOrDefaultAsync(emp => emp.Id == Id);
            if (employeeFamiliar == null)
            {
                return NotFound();
            }
            employeeFamiliar = mapper.Map(employeeFamiliarCreateDTO, employeeFamiliar);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var exist = await context.EmployeeFamiliars.AnyAsync(ef => ef.Id == Id);
            if (!exist)
            {
                return NotFound();
            }
            context.Remove(new EmployeeFamiliar() { Id = Id });
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
