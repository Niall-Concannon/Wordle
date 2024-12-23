using Plugin.Maui.Audio;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Wordle;

public partial class HistoryPage : ContentPage
{
    public string PlayerName { get; set; }
    public ObservableCollection<Attempt> Attempts { get; set; }

    private IAudioPlayer _audioPlayer;

    public HistoryPage(string playerName)
    {
        InitializeComponent();

        // Assign to properties
        PlayerName = playerName;
        Attempts = new ObservableCollection<Attempt>();

        BindingContext = this;
        LoadHistory();
    } // HistoryPage()

    private async void LoadHistory()
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, $"{PlayerName}.json");

        if (File.Exists(filePath)) // Error Checking
        {
            string json = await File.ReadAllTextAsync(filePath);
            History history = JsonSerializer.Deserialize<History>(json);

            foreach (var attempt in history.Attempts)
            {
                // Add attempts to collection
                Attempts.Add(attempt);
            }
        }
    } // LoadHistory()

    private async void ClearHistory_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        string filePath = Path.Combine(FileSystem.AppDataDirectory, $"{PlayerName}.json");

        File.Delete(filePath); // Delete the file so it doesn't show history when reopened

        Attempts.Clear(); // Clear the observable collection
    } // ClearHistory_Clicked()

    private async void ToMainPage_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        // Initialize MainPage with player name
        var mainPage = new MainPage(PlayerName);
        await Navigation.PushAsync(mainPage); // Go to the game
    } // ToMainPage_Clicked()

} // HistoryPage