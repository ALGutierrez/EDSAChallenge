using Gestion_Alumnos_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Alumnos_v1.Repository
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetGrades();
        Grade GetGradeById(int id);
    }
}
