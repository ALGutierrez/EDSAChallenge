using Gestion_Alumnos_v1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Alumnos_v1.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Grade GetGradeById(int id)
        {
            return _context.Grades.Include(x => x.Teacher).FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Grade> GetGrades()
        {
            return _context.Grades.Include(x => x.Teacher);
        }
    }
}
