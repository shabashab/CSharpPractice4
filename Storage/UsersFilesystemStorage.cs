using CSharpPractice3.Models;
using CSharpPractice4.Exceptions;
using CSharpPractice4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async IAsyncEnumerable<User> Load()
        {
            if (!File.Exists(_storagePath))
                yield break;

            var storageFileText = File.OpenRead(_storagePath);

            if(storageFileText == null)
            {
                throw new FilesystemStorageException("Cannot open file " + _storagePath);
            }

            var users = JsonSerializer.DeserializeAsyncEnumerable<JsonUser>(storageFileText);

            if(users == null)
            {
                throw new FilesystemStorageException("Cannot deserialize file contents");
            }

            await foreach(var jsonUser in users)
            {
                if (jsonUser == null)
                    continue;

                yield return new User(jsonUser);
            }
        }

        public async Task Save(IEnumerable<User> value)
        {
            if (File.Exists(_storagePath))
                File.Delete(_storagePath);

            var storageFileText = File.OpenWrite(_storagePath);

            if(storageFileText == null)
            {
                throw new FilesystemStorageException("Cannot open file " + _storagePath);
            }

            await JsonSerializer.SerializeAsync(storageFileText, value.Select(user => new JsonUser(user)));
        }
    }
}
