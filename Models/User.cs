using CSharpPractice3.Exceptions;
using CSharpPractice3.Helpers;
using CSharpPractice3.Validators;
using CSharpPractice4.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CSharpPractice3.Models
{
    public class User
    {
        private DateTime? _birthDate;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? Email { get; set; }

        public DateTime? BirthDate {
            get => _birthDate;
            set 
            {
                _birthDate = value;
                RecalculateBirthDateDependants();
            }
        }

        private bool? _isAdult;
        private string? _sunSign;
        private string? _chineseSign;
        private bool? _isBirthday;

        public bool? IsAdult { get => _isAdult; }
        public string? SunSign { get => _sunSign; }
        public string? ChineseSign { get => _chineseSign; }
        public bool? IsBirthday { get => _isBirthday; }

        public User(string firstName, string lastName, string? email, DateTime? birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public User(string firstName, string lastName, string email) : this(firstName, lastName, email, null)
        { }

        public User(string firstName, string lastName, DateTime birthDate) : this(firstName, lastName, null, birthDate)
        { }

        public User(JsonUser user) : this(user.FirstName, user.LastName, user.Email, user.BirthDate)
        { }

        private void RecalculateBirthDateDependants()
        {
            if (!_birthDate.HasValue)
            {
                _isAdult = null;
                _chineseSign = null;
                _sunSign = null;
                _isBirthday = null;

                return;
            }

            DateTime birthDate = _birthDate.Value;

            DateTime now = DateTime.Now;
            int age = (int)((now - birthDate).TotalDays / 365.25);

            if (age < 0)
                throw new BirthDateValidationException("Person's age can't be less than zero");

            _isAdult = age >= 18;
            _isBirthday = now.Day == birthDate.Day && now.Month == birthDate.Month;
            _sunSign = SunSigns.GetSignByDate(birthDate);
            _chineseSign = ChineseSigns.GetSignByDate(birthDate);
        }
    }
}
