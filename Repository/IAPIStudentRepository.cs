using Gestion_Alumnos_v1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Alumnos_v1.Repository
{
    public interface IAPIStudentRepository
    {
        Task<ActionResult<IEnumerable<Student>>> GetAllStudentsAPI();
        bool ExistAPI(Student student);
        Task<bool> NewStudentAPI(Student student);
        Task<bool> EditStudentAPI(Student student);
        Task<ActionResult<Student>> GetStudentByIdAPI(int id);
        Task<ActionResult<Student>> DeleteStudentAPI(int id);
    }
}
