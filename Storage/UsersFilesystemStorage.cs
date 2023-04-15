using CSharpPractice3.Models;
using CSharpPractice4.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSharpPractice4.Storage
{
    class UsersFilesystemStorage : IUsersStorage
    {
        private readonly string _storagePath;

        public UsersFilesystemStorage(string storagePath)
        {
            _storagePath = storagePath;
        }

        public async Task<IEnumerable<User>> Load()
        {
            if (!File.Exists(_storagePath))
                return Array.Empty<User>();

            var storageFileText = File.OpenRead(_storagePath);

            if(storageFileText == null)
            {
                throw new FilesystemStorageException("Cannot open file " + _storagePath);
            }

            var user = await JsonSerializer.DeserializeAsync<IEnumerable<User>>(storageFileText);

            if(user == null)
            {
                throw new FilesystemStorageException("Cannot deserialize file contents");
            }

            return user;
        }

        public async Task Save(IEnumerable<User> value)
        {
            var storageFileText = File.OpenWrite(_storagePath);

            if(storageFileText == null)
            {
                throw new FilesystemStorageException("Cannot open file " + _storagePath);
            }


            await JsonSerializer.SerializeAsync(storageFileText, value);
        }
    }
}
