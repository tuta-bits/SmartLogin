using SmartApp.Helpers;
using SmartApp.Models;
using SmartApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartApp.ViewModels
{
    public class IdeasViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<Idea> _ideas;


        // public string AccessToken { get; set; }



        /// <summary>Gets or sets the ideas.</summary>
        /// <value>The ideas.</value>
        public List<Idea> Ideas 
        { 
            get { return _ideas; } 
            set
            {
                _ideas = value;
                OnPropertyChanged();
            }
        }


        /// <summary>Gets the get ideas command.</summary>
        /// <value>The get ideas command.</value>
        public ICommand GetIdeasCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                    Ideas = await _apiServices.GetIdeasAsync(accesstoken);
                });
            }
        }



        /// <summary>Occurs when a property value changes.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
