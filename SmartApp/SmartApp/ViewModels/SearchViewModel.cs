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
    public class SearchViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<Idea> _ideas;

        public string Keyword { get; set; }


        public List<Idea> Ideas
        {
            get { return _ideas; }
            set
            {
                _ideas = value;
                OnPropertyChanged();
            }
        }


        /// <summary>Gets the search command.</summary>
        /// <value>The search command.</value>
        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Ideas = await _apiServices.SearchIdeasAsync(Keyword, Settings.AccessToken);
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
