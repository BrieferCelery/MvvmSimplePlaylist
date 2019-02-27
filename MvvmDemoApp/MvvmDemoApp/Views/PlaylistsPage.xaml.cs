
using MvvmDemoApp.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MvvmDemoApp
{
    public partial class PlaylistsPage : ContentPage
    {
       

        public PlaylistsPage ()
        {
            BindingContext = new PlaylistsPageViewModel(new PageService());
            InitializeComponent ();
        }

        protected override void OnAppearing ()
        {
            
            base.OnAppearing ();
        }



        void OnPlaylistSelected (object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //listview does not have generic command so must manually execute
            ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
        }

        public PlaylistsPageViewModel ViewModel
        {
            get { return BindingContext as PlaylistsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}
