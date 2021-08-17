using Gestion_Alumnos_v1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Alumnos_v1.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                var student = _context.Students.Find(id);
                _context.Students.Remove(student);
                int entries = _context.SaveChanges();
                return (entries > 0);

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditStudent(Student student)
        {
            try
            {
                var studentEntity = _context.Students.Find(student.Id);
                studentEntity.Name = student.Name;
                studentEntity.DNI = student.DNI;
                var grade = _context.Grades.Find(student.IdGrade);
                studentEntity.Grade = grade;
                studentEntity.Phone = student.Phone;
                studentEntity.Enabled = student.Enabled;
                _context.Students.Update(studentEntity);
                var entries = _context.SaveChanges();
                return (entries > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Exist(Student student)
        {
            return _context.Students.Any(e => e.Id == student.Id);
            /*var exist = _context.Students.Where(x => x.Name == student.Name && x.DNI == student.DNI).FirstOrDefault();
            bool resultado = exist != null ? resultado = true : resultado = false;
            return resultado; */
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Include(x => x.Grade).FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.Include(x => x.Grade);
        }

        public bool NewStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                var entries = _context.SaveChanges();
                return (entries > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
