using Gestion_Alumnos_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Alumnos_v1.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        bool Exist(Student student);
        bool NewStudent(Student student);
        bool EditStudent(Student student);
        Student GetStudentById(int id);
        bool DeleteStudent(int id);
    }
}
