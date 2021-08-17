using Gestion_Alumnos_v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Gestion_Alumnos_v1.Repository
{
    public class APIStudentRepository : IAPIStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public APIStudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Student>> DeleteStudentAPI(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> EditStudentAPI(Student student)
        {
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                var studentEntity = _context.Students.Find(student.Id);
                studentEntity.Name = student.Name;
                studentEntity.DNI = student.DNI;
                var grade = _context.Grades.Find(student.IdGrade);
                studentEntity.Grade = grade;
                studentEntity.Phone = student.Phone;
                studentEntity.Enabled = student.Enabled;
                _context.Students.Update(studentEntity);
                var entries = await _context.SaveChangesAsync();
                return entries > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExistAPI(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudentsAPI()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<ActionResult<Student>> GetStudentByIdAPI(int id)
        {
            return await _context.Students.Include(x => x.Grade).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> NewStudentAPI(Student student)
        {
            try
            {
                _context.Students.Add(student);
                var entries = await _context.SaveChangesAsync();
                return entries > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
