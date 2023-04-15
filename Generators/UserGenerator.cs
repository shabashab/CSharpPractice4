using CSharpPractice3.Models;
using System;

namespace CSharpPractice4.Generators
{
    public class UserGenerator : BasicGenerator<User>
    {
        private static string[] FirstNames = new string[] 
        {
            "Anton", "Artem", "Daniil", "Danylo", "Kate", "Ann", "Vladyslava"
        };

        private static string[] LastNames = new string[]
        {
            "Tarasenko", "Khomichenko", "Vasylenko", "Grygorenko", "Lobachenko", "Grygorevich", "Vasylevich", "Obama", "Trump", "Biden"
        };

        private Random random;

        public UserGenerator()
        {
            random = new Random();
        }

        private string NextRandomFirstName()
        {
            return FirstNames[random.Next(0, FirstNames.Length)];
        }

        private string NextRandomLastName()
        {
            return LastNames[random.Next(0, LastNames.Length)];
        }

        private DateTime NextRandomBirthDate()
        {
            return new DateTime(random.Next(1970, 2002), random.Next(1, 13), random.Next(1, 28));
        }

        private string CreateEmailForUserData(string firstName, string lastName, DateTime birthDate)
        {
            return firstName + "." + lastName + "." + birthDate.Year + "@gmail.com";
        }

        public override User GenerateSingle()
        {
            string firstName = NextRandomFirstName();
            string lastName = NextRandomLastName();
            DateTime birthDate = NextRandomBirthDate();
            string email = CreateEmailForUserData(firstName, lastName, birthDate);

            return new User(firstName, lastName, email, birthDate);
        }
    }
}
