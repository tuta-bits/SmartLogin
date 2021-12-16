using SmartApp.Helpers;
using SmartApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartApp.ViewModels
{
    public class RegisterViewModel
    {

        ApiServices _apiServices = new ApiServices();


        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(Email, Password, ConfirmPassword);


                    Settings.Username = Email;
                    Settings.Password = Password;

                    if (isSuccess)
                    {
                        await Application.Current.MainPage.DisplayAlert("Notification !", "Registration was Successful 👍🏿 !", "OK");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Notification !", "Please make sure your password contains " +
                            "Uppercase letters, " +
                            "Lowercase letters, " +
                            "Numerics & Special Characters 😥 !", "OK");
                    }


                });
            }
        }
    }
}
