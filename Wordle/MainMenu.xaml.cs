namespace Wordle;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
	}

    private async void StartGame_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MainPage"); // Go the game
    }
}