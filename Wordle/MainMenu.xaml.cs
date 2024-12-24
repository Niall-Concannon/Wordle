using Plugin.Maui.Audio;

namespace Wordle;

public partial class MainMenu : ContentPage
{
    // Variables
    private IAudioPlayer _audioPlayer;
    public MainMenu()
	{
		InitializeComponent();
        LoadSavedTheme();
    } // MainMenu()

    private async void StartGame_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        await Task.Delay(500); // Add delay so it doesn't play any audio at the same time

        string playerName = playerNameEntry.Text;

        // Check if Entry box is empty
        if (string.IsNullOrEmpty(playerName))
        {
            _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("error.mp3"));
            _audioPlayer.Play();

            await DisplayAlert("Invalid", "Please enter a Username in the Entry Box", "OK");
            return;
        }

        // Initialize MainPage with player name
        var mainPage = new MainPage(playerName);
        await Navigation.PushAsync(mainPage); // Go to the game
    } // StartGame_Clicked()

    private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string playerName = playerNameEntry.Text;

        // Invalid file name - no special characters
        // https://learn.microsoft.com/it-it/dotnet/api/system.char.isletterordigit?view=net-8.0
        if (playerName.Any(c => !char.IsLetterOrDigit(c)))
        {
            _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("error.mp3"));
            _audioPlayer.Play();

            await DisplayAlert("Invalid", "No Special Characters are Allowed in Usernames", "OK");

            // Remove the last character typed
            // https://stackoverflow.com/questions/25220745/how-to-remove-the-last-character-typed-in-a-textbox
            playerNameEntry.Text = playerNameEntry.Text.Remove(playerNameEntry.Text.Length - 1);
        }
    } // Entry_TextChanged()

    private async void Settings_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        await Task.Delay(500); // Add delay to not overlap sfx

        string playerName = playerNameEntry.Text;

        if(string.IsNullOrEmpty(playerName))
        {
            _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("error.mp3"));
            _audioPlayer.Play();

            await DisplayAlert("Invalid", "Please enter a Username in the Entry Box", "OK");
            return; // Exit
        }

        // Initialize MainPage with player name
        var settingsPage = new SettingsPage(playerName);
        await Navigation.PushAsync(settingsPage); // Go to the game
    }

    private void LoadSavedTheme()
    {
        var savedTheme = Preferences.Get("AppTheme", "Light");

        if (savedTheme == "Dark")
        {
            this.BackgroundColor = Colors.Black;
        }
        else
        {
            this.BackgroundColor = Colors.White;
        }
    } // LoadSavedTheme()

} // MainMenu