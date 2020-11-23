using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2
{
    public class StudentAdministratieController : Controller
    {
        private MijnContext context;

        public StudentAdministratieController(MijnContext context)
        {
            this.context = context;
        }

        public IActionResult ZoekStudenten(char id)
        {
            List<Student> sList = context.students.Where(s => s.firstName.ToLower().StartsWith(id)).ToList();
            return View(sList);
        }
    }
}