using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2
{
    public class StudentController : Controller
    {
        private MijnContext context;

        public StudentController(MijnContext context) 
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aantal(string voornaam)
        {
            ViewData["voornaam"] = voornaam;
            ViewData["aantal"] = context.students.Count(s => s.firstName.ToLower() == voornaam.ToLower());
            return View();
        }

        public IActionResult Email(int id)
        {
            ViewData["email"] = context.students.Single(s => s.studentNumber == id).email;
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                context.students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Details", new { id = student.studentNumber });
            }
            else
            {
                ViewData["error"] = "invalid Input!";
                return View();
            }
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            Student student = context.students.Single(s => s.studentNumber == id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student inputStudent) 
        {
            Student student = context.students.Single(s => s.studentNumber == inputStudent.studentNumber);

            student.firstName = inputStudent.firstName;
            student.email = inputStudent.email;
            context.SaveChanges();

            return RedirectToAction("Details", new { id = student.studentNumber });
        }
        
        public IActionResult Details(int id) 
        {
            Student student = context.students.Single(s => s.studentNumber == id);
            return View(student);
        }
    }
}