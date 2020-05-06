using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNotes.Models;
using WPFNotes.ViewModels;

namespace WPFNotes.Commands
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public LoginViewModel LoginViewModel { get; set; }

        public LoginCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var user = parameter as User;

            //if (user == null)
            //    return false;
            //if (string.IsNullOrEmpty(user.Username))
            //    return false;
            //if (string.IsNullOrEmpty(user.Password))
            //    return false;

            return true;
        }

        public void Execute(object parameter)
        {
            LoginViewModel.Login();
        }
    }
}
