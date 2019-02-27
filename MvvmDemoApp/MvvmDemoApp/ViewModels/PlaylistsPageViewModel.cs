using MvvmDemoApp.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmDemoApp
{
     public class PlaylistsPageViewModel : BaseViewModel
    {
        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();

        //Data binding property to view
        private PlaylistViewModel _selectedPlaylist;
        private PageService pageService;

        public PlaylistViewModel SelectedPlaylist
        {
            get { return _selectedPlaylist; }
            set { SetValue(ref _selectedPlaylist, value);  }
        }

        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        private readonly IPageService _pageService;
        public PlaylistsPageViewModel(IPageService pageService)
        {
            _pageService = pageService;

            AddPlaylistCommand = new Command(AddPlaylist);
            // if target method is async you need to define asyncronous lambda expression
            SelectPlaylistCommand = new Command<PlaylistViewModel>(async vm => await SelectPlaylist(vm));
        }

        private void AddPlaylist()
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        private async Task SelectPlaylist(PlaylistViewModel playlist)
        {

            if (playlist == null)
                return;

            playlist.IsFavorite = !playlist.IsFavorite;

            SelectedPlaylist = null;

            await _pageService.PushAsync (new PlaylistDetailPage(playlist));
        }
    }
}
