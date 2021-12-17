using SmartApp.Models;
using SmartApp.ViewModels;
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
    public partial class IdeasPage : ContentPage
    {

        /// <summary>Initializes a new instance of the <see cref="IdeasPage" /> class.</summary>
        public IdeasPage()
        {
            InitializeComponent();
        }



        /// <summary>Handles the Clicked event of the GotoNewIdeaPage control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void GotoNewIdeaPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewIdeaPage());
        }



        /// <summary>Handles the ItemTapped event of the Smart control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemTappedEventArgs" /> instance containing the event data.</param>
        private async void Smart_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clear = e.Item as Idea;
            await Navigation.PushAsync(new EditIdeaPage(clear));
        }
    }
}