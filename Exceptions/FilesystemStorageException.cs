using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice4.Exceptions
{
    public class FilesystemStorageException : Exception
    {
        public FilesystemStorageException(string message) : base("An error occurred while trying to read filesystem data. " + message)
        {
        }
    }
}
