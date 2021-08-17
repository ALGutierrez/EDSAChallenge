using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_Alumnos_v1.Models;
using Gestion_Alumnos_v1.Repository;

namespace Gestion_Alumnos_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsAPIController : ControllerBase
    {
        private readonly IAPIStudentRepository _iAPIStudentRepository;

        public StudentsAPIController(IAPIStudentRepository apiStudentRepository)
        {
            _iAPIStudentRepository = apiStudentRepository;
        }

        // GET: api/StudentsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _iAPIStudentRepository.GetAllStudentsAPI();
        }

        // GET: api/StudentsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _iAPIStudentRepository.GetStudentByIdAPI(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/StudentsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var result = _iAPIStudentRepository.EditStudentAPI(student);
            if (await result.ConfigureAwait(true))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            /* _context.Entry(student).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!StudentExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent(); */
        }

        // POST: api/StudentsAPI

        [HttpPost]
        public async Task<ActionResult> CreateStudent([FromBody] Student student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                DNI = student.DNI,
                Phone = student.Phone,
                Enabled = student.Enabled,
                IdGrade = student.IdGrade,
                Grade = student.Grade
            };
            var result =  _iAPIStudentRepository.NewStudentAPI(newStudent);

            if (await result.ConfigureAwait(true))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/StudentsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _iAPIStudentRepository.GetStudentByIdAPI(id);
            if (student == null)
            {
                return NotFound();
            }

            return await _iAPIStudentRepository.DeleteStudentAPI(id);

        }

    }
}
