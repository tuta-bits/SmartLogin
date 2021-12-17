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
    public class AddNewIdeaViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string Title { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }



        /// <summary>Gets the add command.</summary>
        /// <value>The add command.</value>
        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var groot = new Idea
                    {
                        Title = Title,
                        Category = Category,
                        Description = Description
                    };
                    await _apiServices.PostIdeaAsync(groot, Settings.AccessToken);

                    
                });
            }
        }
    }
}
