using CSharpPractice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice4.Models
{
    public class JsonUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public JsonUser()
        { }

        public JsonUser(string firstName, string lastName, string? email, DateTime? birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public JsonUser(User user) : this(user.FirstName, user.LastName, user.Email, user.BirthDate)
        { }
    }
}
