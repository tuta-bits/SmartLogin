using SmartApp.Helpers;
using SmartApp.Models;
using SmartApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartApp.ViewModels
{
    public class EditIdeaViewModel
    {

        ApiServices _apiServices = new ApiServices();

        public Idea Idea { get; set; }


        /// <summary>Gets the edit command.</summary>
        /// <value>The edit command.</value>
        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.PutIdeaAsync(Idea, Settings.AccessToken);
                });
            }
        }
    }
}
