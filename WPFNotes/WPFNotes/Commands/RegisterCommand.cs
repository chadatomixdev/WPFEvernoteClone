using System;
using System.Windows.Input;
using WPFNotes.Models;
using WPFNotes.ViewModels;

namespace WPFNotes.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }

        public RegisterCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            User user = parameter as User;

            //if (user != null)
            //{

            //    if (string.IsNullOrEmpty(user.Username))
            //        return false;

            //    if (string.IsNullOrEmpty(user.Password))
            //        return false;

            //    if (string.IsNullOrEmpty(user.Email))
            //        return false;

            //    if (string.IsNullOrEmpty(user.Lastname))
            //        return false;

            //    if (string.IsNullOrEmpty(user.Name))
            //        return false;
            //}

            return true;
        }

        public void Execute(object parameter)
        {
            LoginViewModel.Register();
        }
    }
}