using CSharpPractice3.Exceptions;
using CSharpPractice3.Helpers;
using CSharpPractice3.Validators;
using CSharpPractice4.EventManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CSharpPractice4.ViewModels
{
    internal class NewUserViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region Properties

        private string? _firstName;
        private string? _lastName;
        private string? _email;
        private DateTime? _birthDate;

        public string FirstName
        {
            get => _firstName ?? "";
            set
            {
                _firstName = value;
                ProceedCommand.InvokeCanExecuteChanged();
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => _lastName ?? "";
            set
            {
                _lastName = value;
                ProceedCommand.InvokeCanExecuteChanged();
                OnPropertyChanged("LastName");
            }
        }

        public string Email
        {
            get => _email ?? "";
            set
            {
                _email = value;
                ProceedCommand.InvokeCanExecuteChanged();
                OnPropertyChanged("Email");
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate ?? DateTime.Now;
            set
            {
                _birthDate = value;
                ProceedCommand.InvokeCanExecuteChanged();
                OnPropertyChanged("BirthDate");
            }
        }

        #endregion

        #region Commands

        public RelayCommand ProceedCommand { get; private set; }

        private async void Proceed(object input)
        {
            Window window = (Window)input;

            await Task.Run(() =>
            {
                try
                {
                    BirthDateValidator.Instance.ValidateOrThrow(BirthDate);
                }
                catch (BirthDateValidationException e)
                {
                    MessageBox.Show(e.Message, "Invalid birth date", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    EmailValidator.Instance.ValidateOrThrow(Email);
                }
                catch (EmailValidationException e)
                {
                    MessageBox.Show(e.Message, "Invalid email", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            });

            NewUserEventManager.Instance.Emit(new CSharpPractice3.Models.User(FirstName, LastName, Email, BirthDate));
            window.Close();
        }

        private bool CanProceed(object input)
        {
            return
                _firstName?.Length > 0 &&
                _lastName?.Length > 0 &&
                _email?.Length > 0 &&
                _birthDate != null;
        }

        #endregion

        public NewUserViewModel()
        {
            _firstName = null;
            _lastName = null;
            _email = null;
            _birthDate = null;

            ProceedCommand = new RelayCommand(Proceed, CanProceed);
        }
    }
}
