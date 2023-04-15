using CSharpPractice3.Models;
using CSharpPractice4.Generators;
using CSharpPractice4.Storage;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharpPractice4.ViewModels
{
    public class MainViewModel
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        private readonly IUsersStorage usersStorage;
        private readonly IGenerator<User> usersGenerator;

        private bool _usersLoading;

        public bool UsersLoading 
        {
            get => _usersLoading;
            set
            {
                _usersLoading = value;
                OnPropertyChanged("UsersLoading");
            }
        }

        public ObservableCollection<User> Users { get; private set; }

        private async Task LoadUsersData()
        {
            UsersLoading = true;

            var loadedUsers = await usersStorage.Load();

            foreach (var loadedUser in loadedUsers)
            {
                Users.Add(loadedUser);
            }

            if(Users.Count == 0)
            {
                var newUsers = usersGenerator.GenerateMany(50);

                foreach(var newUser in newUsers)
                {
                    Users.Add(newUser);
                }

                await usersStorage.Save(Users);
            }

            UsersLoading = false;
        }

        public MainViewModel()
        {
            usersStorage = new UsersFilesystemStorage("users.json");
            usersGenerator = new UserGenerator();
            _usersLoading = false;

            Users = new ObservableCollection<User>();

            //Run in parallel
            LoadUsersData();
        }
    }
}
