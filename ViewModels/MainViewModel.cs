using CSharpPractice3.Helpers;
using CSharpPractice3.Models;
using CSharpPractice4.EventManagers;
using CSharpPractice4.Generators;
using CSharpPractice4.Storage;
using CSharpPractice4.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

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

        #region Private Services

        private readonly IUsersStorage usersStorage;
        private readonly IGenerator<User> usersGenerator;

        #endregion

        #region Properties

        public ObservableCollection<User> Users { get; private set; }

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

        private int _selectedUser;
        public int SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        #endregion

        #region Commands

        public ICommand AddUserCommand { get; private set; }
        public ICommand RemoveUserCommand { get; private set; }
        public ICommand SaveUsersCommand { get; private set; }

        private void AddUser(object param)
        {
            NewUserWindow newUserWindow = new NewUserWindow();
            newUserWindow.ShowDialog();
        }

        private void RemoveUser(object param)
        {
            Users.RemoveAt(SelectedUser);
        }

        private void SaveUsers(object param)
        {
            usersStorage.Save(Users);
        }

        #endregion

        private async Task LoadUsersData()
        {
            UsersLoading = true;

            var loadedUsers = usersStorage.Load();

            await foreach (var loadedUser in loadedUsers)
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

        private void OnNewUser(object? sender, User user)
        {
            Users.Add(user);
        }

        public MainViewModel()
        {
            usersStorage = new UsersFilesystemStorage("users.json");
            usersGenerator = new UserGenerator();
            _usersLoading = false;

            Users = new ObservableCollection<User>();

            //Run in parallel
            LoadUsersData();

            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser);
            SaveUsersCommand = new RelayCommand(SaveUsers);

            NewUserEventManager.Instance.OnEvent += OnNewUser;
        }
    }
}
