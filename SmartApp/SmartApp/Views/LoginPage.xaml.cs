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
    public partial class LoginPage : ContentPage
    {

        /// <summary>Initializes a new instance of the <see cref="LoginPage" /> class.</summary>
        public LoginPage()
        {
            InitializeComponent();
        }


        /// <summary>Handles the Clicked event of the ButtonIdea control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void ButtonIdea_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IdeasPage());
        }
    }
}