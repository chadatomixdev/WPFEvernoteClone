using System.Windows;
using WPFNotes.ViewModels;

namespace WPFNotes.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            LoginViewModel vm = new LoginViewModel();
            containerGrid.DataContext = vm;
            vm.HasLoggedIn += Vm_HasLoggedIn;
        }

        private void Vm_HasLoggedIn(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void haveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            registerStackPanel.Visibility = Visibility.Collapsed;
            loginStackPanel.Visibility = Visibility.Visible;
        }

        private void noAccountButton_Click(object sender, RoutedEventArgs e)
        {
            registerStackPanel.Visibility = Visibility.Visible;
            loginStackPanel.Visibility = Visibility.Collapsed;
        }
    }
}