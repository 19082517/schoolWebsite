using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApplication2;
using WebApplication2.Data;
using WebApplication2.Models;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        private string databaseName; // zonder deze property kun je geen clean context maken.

        private void AddStudentsInDb(MijnContext context)
        {
            context.Add(new Student { studentNumber = 1, firstName = "Koen", email = "Koen@student.hhs.nl" });
            context.Add(new Student { studentNumber = 2, firstName = "Robin", email = "Robin@student.hhs.nl" });
            context.Add(new Student { studentNumber = 3, firstName = "Binh", email = "Binh@student.hhs.nl" });
            context.Add(new Student { studentNumber = 4, firstName = "Mehdi", email = "Mehdi@student.hhs.nl" });
            context.Add(new Student { studentNumber = 5, firstName = "Klaas", email = "Klaas@student.hhs.nl" });
            context.SaveChanges();
        }

        private MijnContext GetInMemoryDBMetData()
        {
            MijnContext context = GetNewInMemoryDatabase(true);
            AddStudentsInDb(context);
            return GetNewInMemoryDatabase(false); // gebruik een nieuw (clean) object voor de context
        }

        private MijnContext GetNewInMemoryDatabase(bool NewDb)
        {
            if (NewDb) this.databaseName = Guid.NewGuid().ToString(); // unieke naam

            var options = new DbContextOptionsBuilder<MijnContext>()
                .UseInMemoryDatabase(this.databaseName)
                .Options;

            return new MijnContext(options);
        }

        [Fact]
        public void StudentDetailsTest()
        {
            var context = GetInMemoryDBMetData();

            StudentController s = new StudentController(context);


        }

        [Fact]
        public void ZoekStudentTest() 
        {
            var context = GetInMemoryDBMetData();

            StudentAdministratieController s = new StudentAdministratieController(context);
            var result = Assert.IsType<ViewResult>(s.ZoekStudenten('i'));
            var model = Assert.IsType<List<Student>>(result.Model);

            Assert.True(model.Count == 3);
        }
    }
}
