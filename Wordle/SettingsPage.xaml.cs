using Plugin.Maui.Audio;

namespace Wordle;

public partial class SettingsPage : ContentPage
{
    public string PlayerName { get; set; }

    private IAudioPlayer _audioPlayer;

    public SettingsPage(string playerName)
	{
		InitializeComponent();

        PlayerName = playerName;

        LoadSavedTheme();
        LoadSavedTimeLimit();
    } // SettingsPage()

    private async void OnThemeModeToggled(object sender, ToggledEventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        if (themeSwitch.IsToggled) // Dark mode
        {
            // Set dark background
            this.BackgroundColor = Colors.Black;

            // Save dark
            Preferences.Set("AppTheme", "Dark");
        }
        else // Light mode
        {
            // Set light background
            this.BackgroundColor = Colors.White;

            // Save light
            Preferences.Set("AppTheme", "Light");
        }
    } // OnThemeModeToggled

    private void LoadSavedTheme()
    {
        var savedTheme = Preferences.Get("AppTheme", "Light"); // Light theme by default

        if (savedTheme == "Dark")
        {
            // Set dark theme colour
            this.BackgroundColor = Colors.Black;

            // Turn on dark mode
            themeSwitch.IsToggled = true;
        }
        else
        {
            // Set light theme colour
            this.BackgroundColor = Colors.White;

            // Turn off for light mode
            themeSwitch.IsToggled = false;
        }
    } // LoadSavedTheme()

    // Handle the time limit toggle switch
    private async void OnTimeLimitToggled(object sender, ToggledEventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        if (timeLimitSwitch.IsToggled)
        {
            timeLimitLayout.IsVisible = true; // Show time limit Entry
            Preferences.Set("TimeLimitEnabled", true); // Save time limit state as enabled
        }
        else
        {
            timeLimitLayout.IsVisible = false; // Hide time limit Entry
            Preferences.Set("TimeLimitEnabled", false); // Save time limit state as disabled
        }
    }

    private void LoadSavedTimeLimit()
    {
        bool isTimeLimitEnabled = Preferences.Get("TimeLimitEnabled", false); // Default to false (disabled)

        // Set the time limit switch based on the saved state
        timeLimitSwitch.IsToggled = isTimeLimitEnabled;
        timeLimitLayout.IsVisible = isTimeLimitEnabled;

        // If time limit is enabled, load the previously saved time limit value
        if (isTimeLimitEnabled)
        {
            var savedTimeLimit = Preferences.Get("TimeLimitValue", ""); // Default to empty
            timeLimitEntry.Text = savedTimeLimit; // Set the saved time limit value in the entry
        }
    }

    // Save time limit when the value is changed
    private void OnTimeLimitChanged(object sender, TextChangedEventArgs e)
    {
        var timeLimitValue = timeLimitEntry.Text;
        Preferences.Set("TimeLimitValue", timeLimitValue); // Save time limit value
    }

    private async void ToMainPage_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        // Initialize MainPage with player name
        var mainPage = new MainPage(PlayerName);
        await Navigation.PushAsync(mainPage); // Go to the game
    } // ToMainPage_Clicked()

} // SettingsPage