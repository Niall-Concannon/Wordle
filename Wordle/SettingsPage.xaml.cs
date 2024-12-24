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
    } // SettingsPage()

    private void OnThemeModeToggled(object sender, ToggledEventArgs e)
    {
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

    private void OnTimeLimitToggled(object sender, ToggledEventArgs e)
    {
        if (timeLimitSwitch.IsToggled)
        {
            timeLimitLayout.IsVisible = true; // Show time limit Entry
        }
        else
        {
            timeLimitLayout.IsVisible = false; // Hide time limit Entry
        }
    } // OnTimeLimitToggled()

    private async void ToMainPage_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        // Initialize MainPage with player name
        var mainPage = new MainPage(PlayerName);
        await Navigation.PushAsync(mainPage); // Go to the game
    } // ToMainPage_Clicked()

} // SettingsPage