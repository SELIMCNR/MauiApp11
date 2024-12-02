using MauiApp1.ViewModel;
using Plugin.Maui.Audio;

namespace MauiApp11
{
    public partial class MainPage : ContentPage
    {
        private readonly IAudioManager audioManager;
        public MainPage(MainViewModel mvm)
        {
            InitializeComponent();
            BindingContext = mvm;
            this.audioManager = audioManager;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sound.mp3"));
            player.Play();
        }

    }

}
