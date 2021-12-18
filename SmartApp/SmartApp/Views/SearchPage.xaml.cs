using SmartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }



        /// <summary>Handles the ItemTapped event of the Boss control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemTappedEventArgs" /> instance containing the event data.</param>
        private async void Boss_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sort = e.Item as Idea;
            await Navigation.PushAsync(new EditIdeaPage(sort));
        }
    }
}