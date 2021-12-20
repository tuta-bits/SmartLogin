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
    public partial class AddNewIdeaPage : ContentPage
    {
        public AddNewIdeaPage()
        {
            InitializeComponent();
        }


        /// <summary>Creates new post_clicked.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void NewPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IdeasPage());
        }
    }
}