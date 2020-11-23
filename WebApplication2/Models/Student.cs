using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Student
    {
        [Key]
        public int studentNumber { get; set; }
        public string firstName { get; set; }
        public string email { get; set;  }

        public Student() { }
        public Student(int studentNumber, string firstName, string email)
        {
            this.studentNumber = studentNumber;
            this.firstName = firstName;
            this.email = email;
        }
    }
}