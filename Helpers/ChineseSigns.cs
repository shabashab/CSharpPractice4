using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice3.Helpers
{
    public static class ChineseSigns
    {
        private static string[] chineseSigns = new string[]
        {
            "Monkey",
            "Rooster",
            "Dog",
            "Pig",
            "Rat",
            "Ox",
            "Tiger",
            "Rabbit",
            "Dragon",
            "Snake",
            "Horse",
            "Goat"
        };

        public static string GetSignByDate(DateTime birthDate)
        {
            int remainder = birthDate.Year % 12;
            return chineseSigns[remainder];
        }

    }
}
