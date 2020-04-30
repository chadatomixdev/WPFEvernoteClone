﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNotes.Commands;
using WPFNotes.Models;

namespace WPFNotes.ViewModels
{
    public class LoginViewModel
    {
		private User user;

		public User User
		{
			get { return user; }
			set { user = value; }
		}


		public RegisterCommand RegisterCommand { get; set; }

		public LoginCommand LoginCommand { get; set; }


		public LoginViewModel()
		{
			RegisterCommand = new RegisterCommand(this);
			LoginCommand = new LoginCommand(this);
		}
	}
}