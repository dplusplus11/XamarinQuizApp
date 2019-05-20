using QuizApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
    public class LoginViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);

                    //Settings.AccessToken = accesstoken;
                });
            }
        }

        //public LoginViewModel()
        //{
        //    Username = Settings.Username;
        //    Password = Settings.Password;
        //}
    }
}
