using SQLite;
using System;
using WPFNotes.Commands;
using WPFNotes.Helpers;
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

		public event EventHandler HasLoggedIn;

		public LoginViewModel()
		{
			User = new User();
			RegisterCommand = new RegisterCommand(this);
			LoginCommand = new LoginCommand(this);
		}

		public void Login()
		{
			using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
			{
				connection.CreateTable<User>();
				var user = connection.Table<User>().Where(u => u.Username == User.Username).FirstOrDefault();

				if (user.Password == User.Password)
				{
					App.UserId = user.Id.ToString();
					HasLoggedIn(this, new EventArgs());
				}
			}
		}

		public void Register()
		{
			using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
			{
				connection.CreateTable<User>();
				var result = DatabaseHelper.Insert(User);

				if (result)
				{
					App.UserId = User.Id.ToString();
					HasLoggedIn(this, new EventArgs());
				}
			}
		}

	}
}