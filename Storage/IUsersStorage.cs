using CSharpPractice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice4.Storage
{
    interface IUsersStorage : IStorage<IEnumerable<User>>
    {
    }
}
