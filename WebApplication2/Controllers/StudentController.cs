using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2
{
    public class StudentController : Controller
    {
        private MijnContext context;
        private static List<Student> students = new List<Student>()
        {
            new Student(19026048, "Koen", "koen@camptoo.nl"),
            new Student(19000502, "Robin", "robin@heidenis.com"),
            new Student(18048730, "Binh", "binh@gmail.com"),
            new Student(19082517, "Mehdi", "binh@gmail.com"),
            new Student(19026048, "Koen", "koen@camptoo.nl")
        };

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
            ViewData["aantal"] = CountNames(voornaam);
            // OR
            // ViewData["aantal"] = students.FindAll(s => s.firstName.ToLower() == voornaam.ToLower()).Count;
            return View();
        }

        private int CountNames(string voornaam)
        {
            int countNames = 0;
            foreach (Student student in students)
            {
                if (student.firstName.ToLower() == voornaam.ToLower()) countNames++;
            }

            return countNames;
        }

        public IActionResult Email(int id)
        {
            ViewData["email"] = findEmailByID(id);
            // OR
            // ViewData["email"] = students.Find(s => s.studentNumber == id)?.email;

            return View();
        }

        private string findEmailByID(int id)
        {
            foreach (Student student in students)
            {
                if (id == student.studentNumber)
                {
                    return student.email;
                }
            }
            return "";
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int nummer, string voornaam, string email)
        {
            AddStudentToList(new Student(nummer, voornaam, email));
            return RedirectToAction("Details", new { id = nummer });
        }

        private void AddStudentToList(Student student)
        {
            if (student.studentNumber != 0 && student.firstName != null && student.email != null)
            {
                students.Add(student);
            }
        }

        [HttpGet]
        public IActionResult Update(int id) 
        {
            Student student = findStudentById(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student inputStudent) 
        {
            Student student = findStudentById(inputStudent.studentNumber);

            student.firstName = inputStudent.firstName;
            student.email = inputStudent.email;

            return RedirectToAction("Details", new { id = student.studentNumber });
        }

        private Student findStudentById(int id) 
        {
            foreach (Student student in students) if (id == student.studentNumber) return student;
            return null;
        }

        public IActionResult Details(int id) 
        {
            Student student = findStudentById(id);

            return View(student);
        }
    }
}