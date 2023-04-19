using CSharpPractice4.ViewModels;
using System.Windows;

namespace CSharpPractice4.Views
{
    /// <summary>
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window
    {
        public NewUserWindow()
        {
            InitializeComponent();

            DataContext = new NewUserViewModel();
        }
    }
}
