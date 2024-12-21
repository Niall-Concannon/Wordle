using Plugin.Maui.Audio;

namespace Wordle;

public partial class MainMenu : ContentPage
{
    // Variables
    private IAudioPlayer _audioPlayer;
    public MainMenu()
	{
		InitializeComponent();
	} // MainMenu()

    private async void StartGame_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        await Shell.Current.GoToAsync("MainPage"); // Go the game
    } // StartGame_Clicked()

    private async void CreateFile_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        string fileName = fileNameEntry.Text;

        string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName + ".txt");

        // Save some game data to the file
        await File.WriteAllTextAsync(filePath, "Game data saved here");

        createBtn.IsEnabled = false;
    } // CreateFile_Clicked()

    private async void LoadFile_Clicked(object sender, EventArgs e)
    {
        _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
        _audioPlayer.Play();

        string fileName = fileNameEntry.Text;
        string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName + ".txt");

        string fileContent = await File.ReadAllTextAsync(filePath);
    } // LoadFile_Clicked()

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string fileName = fileNameEntry.Text;

        // Invalid file name - no special characters
        // https://stackoverflow.com/questions/22746468/how-to-check-if-a-string-contains-invalid-filename-characters-in-c
        if (string.IsNullOrEmpty(fileName) || fileName.Any(c => Path.GetInvalidFileNameChars().Contains(c))) 
        {
            loadBtn.IsEnabled = false;
            createBtn.IsEnabled = false;
        }
        else // Valid name
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName + ".txt");
            // Enable buttons based on if it exists or not
            loadBtn.IsEnabled = File.Exists(filePath);
            createBtn.IsEnabled = !File.Exists(filePath);
        }
    } // Entry_TextChanged()

} // MainMenu