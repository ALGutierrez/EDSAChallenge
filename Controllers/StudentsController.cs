using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Alumnos_v1.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Gestion_Alumnos_v1.Repository;

namespace Gestion_Alumnos_v1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGradeRepository _gradeRepository;

        public StudentsController(IStudentRepository studentRepository, IGradeRepository gradeRepository)
        {
            _studentRepository = studentRepository;
            _gradeRepository = gradeRepository;
        }

        // GET: Students
        public ActionResult Index()
        {
            var students = _studentRepository.GetStudents();
            return View(students);
            /*List<Student> reservationList = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44371/api/Students"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return View(reservationList);*/
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentRepository.GetStudentById(id.Value);
            /*await _context.Students
            .Include(s => s.Grade)
            .FirstOrDefaultAsync(m => m.Id == id);    async Task<IActionResult>*/
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewData["IdGrade"] = new SelectList(_gradeRepository.GetGrades(), "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,DNI,Phone,Enabled,IdGrade")] Student student)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(student);
                await _context.SaveChangesAsync();  _gradeRepository.GetGrades()*/
                _studentRepository.NewStudent(student);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGrade"] = new SelectList(_gradeRepository.GetGrades(), "Id", "Name", student.IdGrade);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentRepository.GetStudentById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["IdGrade"] = new SelectList(_gradeRepository.GetGrades(), "Id", "Name", student.IdGrade);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,DNI,Phone,Enabled,IdGrade")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentRepository.EditStudent(student);
                    /*_context.Update(student);
                    await _context.SaveChangesAsync();*/
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_studentRepository.Exist(student))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGrade"] = new SelectList(_gradeRepository.GetGrades(), "Id", "Name", student.IdGrade);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentRepository.GetStudentById(id.Value);
            /*var student = await _context.Students
                .Include(s => s.Grade)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _studentRepository.DeleteStudent(id);
                /*await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();*/
            return RedirectToAction(nameof(Index));
        }

    }
}
