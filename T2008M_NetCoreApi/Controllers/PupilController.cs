using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T2008M_NetCoreApi.Dtos;
using T2008M_NetCoreApi.Models;
using T2008M_NetCoreApi.Repositories;

namespace T2008M_NetCoreApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]    
    public class StudentsController : ControllerBase
    {
        private PPupilRepositories repository;

        public StudentsController(PPupilRepositories repository)
        {
            this.repository = repository;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IEnumerable<Pupil>> GetStudents()
        {
            return await repository.GetStudentsAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pupil>> GetStudent(int id)
        {
            var Student = await repository.GetStudentByIdAsync(id);

            if (Student == null)
            {
                return NotFound();
            }

            return Student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Pupil student)
        {
            student.Id = id;
            await repository.UpdateStudentAsync(student);            
      
            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pupil>> PostStudent(StudentDto StudentDto)
        {
            Pupil Student = new()
            {
                FirstName = StudentDto.FirstName,
                LastName = StudentDto.LastName,
                PhoneNumber = StudentDto.PhoneNumber,
                Email = StudentDto.Email,
            };
            await repository.AddStudentAsync(Student);
            await repository.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = Student.Id }, Student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            
            await repository.DeleteStudentAsync(id);
            await repository.SaveChangesAsync();
            return NoContent();
        }     

    }
}
