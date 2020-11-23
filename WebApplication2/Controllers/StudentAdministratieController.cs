using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2
{
    public class StudentAdministratieController : Controller
    {
        private MijnContext context;
        private List<Student> students = new List<Student>();
        
        public StudentAdministratieController(MijnContext context)
        {
            this.context = context;

            students.Add(new Student(19026048, "Koen", "koen@camptoo.nl"));
            students.Add(new Student(19000502, "Robin", "robin@heidenis.com"));
            students.Add(new Student(18048730, "Binh", "binh@gmail.com"));
            students.Add(new Student(19082517, "Mehdi", "binh@gmail.com"));
            students.Add(new Student(19026048, "Koen", "koen@camptoo.nl"));
        }
        
        public IActionResult ZoekStudenten(char id)
        {
            List<Student> sList = new List<Student>();
            foreach (Student s in students)
            {
                if (s.firstName.ToLower().StartsWith(id))
                {
                    sList.Add(s);
                }
            }
            // OR
            // List<Student> sList = students.FindAll(s => s.firstName.ToLower().StartsWith(id));
            return View(sList);
        }
    }
}