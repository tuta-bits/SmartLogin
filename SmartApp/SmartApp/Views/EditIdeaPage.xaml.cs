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
    public partial class EditIdeaPage : ContentPage
    {

        /// <summary>Initializes a new instance of the <see cref="EditIdeaPage" /> class.</summary>
        /// <param name="idea">The idea.</param>
        public EditIdeaPage(Idea idea)
        {
            var editIdeaViewModel = new EditIdeaViewModel();
            editIdeaViewModel.Idea = idea;

            BindingContext = editIdeaViewModel;

            InitializeComponent();

            //var editIdeaViewModel = BindingContext as EditIdeaViewModel;
            //editIdeaViewModel.Idea = idea;
        }


    }

}