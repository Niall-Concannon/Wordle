using Plugin.Maui.Audio;
using System.Text.Json;

namespace Wordle
{
    public partial class MainPage : ContentPage
    {
        // Properties
        public string PlayerName { get; set; }
        public string RandomWord { get; set; }
        public int NumGuesses { get; set; }
        public List<string> EmojiGrid { get; set; }

        // Variables
        private const string sourceFile = "https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt";
        private int currentRow = 0;
        private List<string> validWords = new List<string>(); // List adds valid words to check in game
        private string randomWord = "";
        bool gameWon = false;
        private RowColours _rowColours;
        private IAudioPlayer _audioPlayer;
        private int numGuesses = 0;

        public MainPage(string playerName)
        {
            InitializeComponent();

            _rowColours = new RowColours();
            BindingContext = _rowColours;

            PlayerName = playerName;

            EmojiGrid = new List<string>(); // Initialize grid
            EmojiGrid.Clear(); // Clear just to make sure its empty
        } // MainPage()

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Set the destination folder and file name
            // All links below helped
            // https://stackoverflow.com/questions/50308867/saving-file-into-path-combine-directory
            // https://github.com/dotnet/maui/discussions/21438
            string destinationFolder = FileSystem.AppDataDirectory;
            string destinationFileName = "words.txt";
            string destinationFilePath = Path.Combine(destinationFolder, destinationFileName);

            if (!File.Exists(destinationFilePath))
            {
                // If the file doesn't exist, download and save it
                await DownloadAndSave(sourceFile, destinationFolder, destinationFileName);
            }

            // Random word generator
            string[] lines = await File.ReadAllLinesAsync(destinationFilePath);
            Random random = new Random();

            // Get the word from the file
            int randomIndex = random.Next(lines.Length);
            randomWord = lines[randomIndex];
            RandomWord = randomWord; // Assign RandomWord property
            test.Text = randomWord;

            // Put valid words on the list
            foreach (string line in lines)
            {
                validWords.Add(line.ToUpper()); // Has to be upper or all words are invalid
            }

            // Set the first row to allow input - was previously IsEnabled but TextColor wouldn't be white when disabled
            // https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.visualelement.inputtransparent?view=net-maui-9.0
            Row1Col1.InputTransparent = false;
            Row1Col2.InputTransparent = false;
            Row1Col3.InputTransparent = false;
            Row1Col4.InputTransparent = false;
            Row1Col5.InputTransparent = false;
        } // OnAppearing()


        // All code below is for downloading the file for the wordle game
        // Website - https://www.code4it.dev/blog/download-and-save-files/ helped
        async Task DownloadAndSave(string sourceFile, string destinationFolder, string destinationFileName)
        {
            // Get the file stream from the URL
            Stream fileStream = await GetFileStream(sourceFile);

            if (fileStream != Stream.Null)
            {
                await SaveStream(fileStream, destinationFolder, destinationFileName); // Save to destination
            }
        } // DownloadAndSave()

        async Task<Stream> GetFileStream(string fileUrl)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                // Download the file as a stream
                Stream fileStream = await httpClient.GetStreamAsync(fileUrl);
                return fileStream;
            }
            catch (Exception)
            {
                return Stream.Null; // Error
            }
        } // GetFileStream()

        async Task SaveStream(Stream fileStream, string destinationFolder, string destinationFileName)
        {
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            // Path to the file
            string path = Path.Combine(destinationFolder, destinationFileName);

            // Save the file to the destination path
            using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
            {
                await fileStream.CopyToAsync(outputFileStream);
            }
        } // SaveStream()

        // Method checks what was entered into the entry boxes, only allowing letters
        private void Entry_TextChanged(object sender, TextChangedEventArgs e) // https://stackoverflow.com/questions/78098837/maui-entry-control-keyboard-to-accept-a-to-z-letters-only
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                var textFiltered = new string(e.NewTextValue.Where(char.IsLetter).ToArray());
                ((Entry)sender).Text = textFiltered;
            }
        } // Entry_TextChanged()

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
            _audioPlayer.Play();

            await Task.Delay(500); // Add delay so it doesn't play any audio at the same time

            // Variables
            bool allFilled = true;
            string wordValidator = "";

            // Check entry boxes
            if (currentRow == 0) // Row 1
            {
                if (string.IsNullOrEmpty(Row1Col1.Text) || string.IsNullOrEmpty(Row1Col2.Text) || string.IsNullOrEmpty(Row1Col3.Text) ||
                    string.IsNullOrEmpty(Row1Col4.Text) || string.IsNullOrEmpty(Row1Col5.Text))
                {
                    allFilled = false;
                }

                wordValidator = Row1Col1.Text + Row1Col2.Text + Row1Col3.Text + Row1Col4.Text + Row1Col5.Text;
            }
            else if (currentRow == 1) // Row 2
            {
                if (string.IsNullOrEmpty(Row2Col1.Text) || string.IsNullOrEmpty(Row2Col2.Text) || string.IsNullOrEmpty(Row2Col3.Text) ||
                    string.IsNullOrEmpty(Row2Col4.Text) || string.IsNullOrEmpty(Row2Col5.Text))
                {
                    allFilled = false;
                }

                wordValidator = Row2Col1.Text + Row2Col2.Text + Row2Col3.Text + Row2Col4.Text + Row2Col5.Text;
            }
            else if (currentRow == 2) // Row 3
            {
                if (string.IsNullOrEmpty(Row3Col1.Text) || string.IsNullOrEmpty(Row3Col2.Text) || string.IsNullOrEmpty(Row3Col3.Text) ||
                    string.IsNullOrEmpty(Row3Col4.Text) || string.IsNullOrEmpty(Row3Col5.Text))
                {
                    allFilled = false;
                }

                wordValidator = Row3Col1.Text + Row3Col2.Text + Row3Col3.Text + Row3Col4.Text + Row3Col5.Text;
            }
            else if (currentRow == 3) // Row 4
            {
                if (string.IsNullOrEmpty(Row4Col1.Text) || string.IsNullOrEmpty(Row4Col2.Text) || string.IsNullOrEmpty(Row4Col3.Text) ||
                    string.IsNullOrEmpty(Row4Col4.Text) || string.IsNullOrEmpty(Row4Col5.Text))
                {
                    allFilled = false;
                }

                wordValidator = Row4Col1.Text + Row4Col2.Text + Row4Col3.Text + Row4Col4.Text + Row4Col5.Text;
            }
            else if (currentRow == 4) // Row 5
            {
                if (string.IsNullOrEmpty(Row5Col1.Text) || string.IsNullOrEmpty(Row5Col2.Text) || string.IsNullOrEmpty(Row5Col3.Text) ||
                    string.IsNullOrEmpty(Row5Col4.Text) || string.IsNullOrEmpty(Row5Col5.Text))
                {
                    allFilled = false;
                }

                wordValidator = Row5Col1.Text + Row5Col2.Text + Row5Col3.Text + Row5Col4.Text + Row5Col5.Text;
            }
            else if (currentRow == 5) // Row 6
            {
                if (string.IsNullOrEmpty(Row6Col1.Text) || string.IsNullOrEmpty(Row6Col2.Text) || string.IsNullOrEmpty(Row6Col3.Text) ||
                    string.IsNullOrEmpty(Row6Col4.Text) || string.IsNullOrEmpty(Row6Col5.Text))
                {
                    allFilled = false;
                }

                wordValidator = Row6Col1.Text + Row6Col2.Text + Row6Col3.Text + Row6Col4.Text + Row6Col5.Text;
            }

            if (!allFilled)
            {
                _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("error.mp3"));
                _audioPlayer.Play();

                await DisplayAlert("Invalid", "Not enough letters", "OK");
                return;  // Exit
            }

            // Validate the word
            if (!IsValidWord(wordValidator))
            {
                _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("error.mp3"));
                _audioPlayer.Play();

                await DisplayAlert("Invalid", "Not in word list", "OK");
                return; // Exit
            }

            CheckLetters(wordValidator);

            numGuesses++;
            NumGuesses = numGuesses; // Assign NumGuesses property

            CheckForWin(wordValidator);

            if (gameWon == true)
            {
                return; // Exit
            }

            if(currentRow == 5) // Checks if Game Lost
            {
                DisableAllRows();
                submitBtn.IsEnabled = false;

                _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("lose.mp3"));
                _audioPlayer.Play();

                await DisplayAlert("You Lost", "Word was: " + randomWord.ToUpper(), "OK");

                await SaveAttempt(); // Save the attempt
                return; // Exit
            }

            DisableRowEntries(currentRow); // Disable that row

            if (currentRow < 5) // Only 5 rows
            {
                EnableRowEntries(currentRow + 1);
            }

            currentRow++;  // Next row
        } // Submit_Clicked()

        private void DisableRowEntries(int row)
        {
            switch (row)
            {
                case 0: // Row 1
                    Row1Col1.InputTransparent = true;
                    Row1Col2.InputTransparent = true;
                    Row1Col3.InputTransparent = true;
                    Row1Col4.InputTransparent = true;
                    Row1Col5.InputTransparent = true;
                    break;
                case 1: // Row 2
                    Row2Col1.InputTransparent = true;
                    Row2Col2.InputTransparent = true;
                    Row2Col3.InputTransparent = true;
                    Row2Col4.InputTransparent = true;
                    Row2Col5.InputTransparent = true;
                    break;
                case 2: // Row 3
                    Row3Col1.InputTransparent = true;
                    Row3Col2.InputTransparent = true;
                    Row3Col3.InputTransparent = true;
                    Row3Col4.InputTransparent = true;
                    Row3Col5.InputTransparent = true;
                    break;
                case 3: // Row 4
                    Row4Col1.InputTransparent = true;
                    Row4Col2.InputTransparent = true;
                    Row4Col3.InputTransparent = true;
                    Row4Col4.InputTransparent = true;
                    Row4Col5.InputTransparent = true;
                    break;
                case 4: // Row 5
                    Row5Col1.InputTransparent = true;
                    Row5Col2.InputTransparent = true;
                    Row5Col3.InputTransparent = true;
                    Row5Col4.InputTransparent = true;
                    Row5Col5.InputTransparent = true;
                    break;
                case 5: // Row 6
                    Row6Col1.InputTransparent = true;
                    Row6Col2.InputTransparent = true;
                    Row6Col3.InputTransparent = true;
                    Row6Col4.InputTransparent = true;
                    Row6Col5.InputTransparent = true;
                    break;
            } // switch
        } // DisableRowEntries()

        private void EnableRowEntries(int row)
        {
            switch (row)
            {
                case 0: // Row 1
                    Row1Col1.InputTransparent = false;
                    Row1Col2.InputTransparent = false;
                    Row1Col3.InputTransparent = false;
                    Row1Col4.InputTransparent = false;
                    Row1Col5.InputTransparent = false;
                    break;
                case 1: // Row 2
                    Row2Col1.InputTransparent = false;
                    Row2Col2.InputTransparent = false;
                    Row2Col3.InputTransparent = false;
                    Row2Col4.InputTransparent = false;
                    Row2Col5.InputTransparent = false;
                    break;
                case 2: // Row 3
                    Row3Col1.InputTransparent = false;
                    Row3Col2.InputTransparent = false;
                    Row3Col3.InputTransparent = false;
                    Row3Col4.InputTransparent = false;
                    Row3Col5.InputTransparent = false;
                    break;
                case 3: // Row 4
                    Row4Col1.InputTransparent = false;
                    Row4Col2.InputTransparent = false;
                    Row4Col3.InputTransparent = false;
                    Row4Col4.InputTransparent = false;
                    Row4Col5.InputTransparent = false;
                    break;
                case 4: // Row 5
                    Row5Col1.InputTransparent = false;
                    Row5Col2.InputTransparent = false;
                    Row5Col3.InputTransparent = false;
                    Row5Col4.InputTransparent = false;
                    Row5Col5.InputTransparent = false;
                    break;
                case 5: // Row 6
                    Row6Col1.InputTransparent = false;
                    Row6Col2.InputTransparent = false;
                    Row6Col3.InputTransparent = false;
                    Row6Col4.InputTransparent = false;
                    Row6Col5.InputTransparent = false;
                    break;
            } // switch
        } // EnableRowEntries()

        private bool IsValidWord(string word) // Check if the word is on the list
        {
            return validWords.Contains(word.ToUpper()); // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains?view=net-9.0
        } // IsValidWord()

        private async void CheckForWin(string guessedWord)
        {
            // Compare the guessed word with the correct word (randomWord)
            if (guessedWord.ToUpper() == randomWord.ToUpper())
            {
                gameWon = true;
                DisableAllRows();
                submitBtn.IsEnabled = false;

                _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("win.mp3"));
                _audioPlayer.Play();
                
                await DisplayAlert("You Win", "You Guessed the Correct Word", "OK");

                await SaveAttempt(); // Save the attempt
            }
        } // CheckForWin()

        private void DisableAllRows()
        {
            Row1Col1.InputTransparent = true;
            Row1Col2.InputTransparent = true;
            Row1Col3.InputTransparent = true;
            Row1Col4.InputTransparent = true;
            Row1Col5.InputTransparent = true;

            Row2Col1.InputTransparent = true;
            Row2Col2.InputTransparent = true;
            Row2Col3.InputTransparent = true;
            Row2Col4.InputTransparent = true;
            Row2Col5.InputTransparent = true;

            Row3Col1.InputTransparent = true;
            Row3Col2.InputTransparent = true;
            Row3Col3.InputTransparent = true;
            Row3Col4.InputTransparent = true;
            Row3Col5.InputTransparent = true;

            Row4Col1.InputTransparent = true;
            Row4Col2.InputTransparent = true;
            Row4Col3.InputTransparent = true;
            Row4Col4.InputTransparent = true;
            Row4Col5.InputTransparent = true;

            Row5Col1.InputTransparent = true;
            Row5Col2.InputTransparent = true;
            Row5Col3.InputTransparent = true;
            Row5Col4.InputTransparent = true;
            Row5Col5.InputTransparent = true;

            Row6Col1.InputTransparent = true;
            Row6Col2.InputTransparent = true;
            Row6Col3.InputTransparent = true;
            Row6Col4.InputTransparent = true;
            Row6Col5.InputTransparent = true;
        } // DisableAllRows()

        // Method used to check if letters are in the word
        private void CheckLetters(string guessedWord)
        {
            // Make both capitals due to case sensitivity
            guessedWord = guessedWord.ToUpper();
            string targetWord = randomWord.ToUpper();

            // Arrays to track letters that have been marked
            bool[] guessedMarked = new bool[5];
            bool[] targetMarked = new bool[5];

            // Create another list to fix null breaking the EmojiGrid list
            List<string> currentRow = new List<string>();

            // Check for Green
            for (int i = 0; i < 5; i++)
            {
                char guessedLetter = guessedWord[i];
                char targetLetter = targetWord[i];

                if (guessedLetter == targetLetter) // Check if Green
                {
                    SetColourForRow(i, Color.FromRgb(108, 169, 101), Colors.White); // Green if correct letter and position
                    currentRow.Add("🟩"); // Add Green box to emoji grid
                    // Set true if Green
                    guessedMarked[i] = true;
                    targetMarked[i] = true;
                }
                else
                {
                    currentRow.Add(null); // null if not Green so it keeps length of emoji grid to 5 and doesn't break the whole code
                }
            }

            // Check for yellow
            for (int i = 0; i < 5; i++)
            {
                if (!guessedMarked[i])  // if not green
                {
                    char guessedLetter = guessedWord[i];

                    bool isYellow = false;

                    // Check for Yellow
                    for (int j = 0; j < 5; j++)
                    {
                        if (!targetMarked[j] && guessedLetter == targetWord[j])
                        {
                            // Mark it yellow
                            SetColourForRow(i, Color.FromRgb(200, 182, 83), Colors.White); // Yellow if correct letter wrong position
                            currentRow[i] = "🟨"; // Add Yellow box to emoji grid
                            // Set true if Yellow
                            targetMarked[j] = true;
                            isYellow = true;
                            break; // break to not allow the same letter to be marked again
                        }
                    }

                    if (!isYellow) // if not Yellow then Grey
                    {
                        SetColourForRow(i, Color.FromRgb(120, 124, 127), Colors.White); // Grey if not correct letter
                        currentRow[i] = "🟥"; // Add Red to emoji grid - no grey box emojis
                    }
                } // if not green
            } // for

            // After processing the current guess, join currentRow into a single string
            string currentRowString = string.Join(" ", currentRow); // https://learn.microsoft.com/en-us/dotnet/api/system.string.join?view=net-9.0

            // Add the row to the EmojiGrid
            EmojiGrid.Add(currentRowString);
        } // CheckLetters()

        // Method sets the colours
        private void SetColourForRow(int col, Color colour, Color textColour)
        {
            switch (currentRow)
            {
                case 0: // Row 1
                    if (col == 0) { _rowColours.Row1Col1Colour = colour; _rowColours.Row1Col1TextColour = textColour; }
                    if (col == 1) { _rowColours.Row1Col2Colour = colour; _rowColours.Row1Col2TextColour = textColour; }
                    if (col == 2) { _rowColours.Row1Col3Colour = colour; _rowColours.Row1Col3TextColour = textColour; }
                    if (col == 3) { _rowColours.Row1Col4Colour = colour; _rowColours.Row1Col4TextColour = textColour; }
                    if (col == 4) { _rowColours.Row1Col5Colour = colour; _rowColours.Row1Col5TextColour = textColour; }
                    break;
                case 1: // Row 2
                    if (col == 0) { _rowColours.Row2Col1Colour = colour; _rowColours.Row2Col1TextColour = textColour; }
                    if (col == 1) { _rowColours.Row2Col2Colour = colour; _rowColours.Row2Col2TextColour = textColour; }
                    if (col == 2) { _rowColours.Row2Col3Colour = colour; _rowColours.Row2Col3TextColour = textColour; }
                    if (col == 3) { _rowColours.Row2Col4Colour = colour; _rowColours.Row2Col4TextColour = textColour; }
                    if (col == 4) { _rowColours.Row2Col5Colour = colour; _rowColours.Row2Col5TextColour = textColour; }
                    break;
                case 2: // Row 3
                    if (col == 0) { _rowColours.Row3Col1Colour = colour; _rowColours.Row3Col1TextColour = textColour; }
                    if (col == 1) { _rowColours.Row3Col2Colour = colour; _rowColours.Row3Col2TextColour = textColour; }
                    if (col == 2) { _rowColours.Row3Col3Colour = colour; _rowColours.Row3Col3TextColour = textColour; }
                    if (col == 3) { _rowColours.Row3Col4Colour = colour; _rowColours.Row3Col4TextColour = textColour; }
                    if (col == 4) { _rowColours.Row3Col5Colour = colour; _rowColours.Row3Col5TextColour = textColour; }
                    break;
                case 3: // Row 4
                    if (col == 0) { _rowColours.Row4Col1Colour = colour; _rowColours.Row4Col1TextColour = textColour; }
                    if (col == 1) { _rowColours.Row4Col2Colour = colour; _rowColours.Row4Col2TextColour = textColour; }
                    if (col == 2) { _rowColours.Row4Col3Colour = colour; _rowColours.Row4Col3TextColour = textColour; }
                    if (col == 3) { _rowColours.Row4Col4Colour = colour; _rowColours.Row4Col4TextColour = textColour; }
                    if (col == 4) { _rowColours.Row4Col5Colour = colour; _rowColours.Row4Col5TextColour = textColour; }
                    break;
                case 4: // Row 5
                    if (col == 0) { _rowColours.Row5Col1Colour = colour; _rowColours.Row5Col1TextColour = textColour; }
                    if (col == 1) { _rowColours.Row5Col2Colour = colour; _rowColours.Row5Col2TextColour = textColour; }
                    if (col == 2) { _rowColours.Row5Col3Colour = colour; _rowColours.Row5Col3TextColour = textColour; }
                    if (col == 3) { _rowColours.Row5Col4Colour = colour; _rowColours.Row5Col4TextColour = textColour; }
                    if (col == 4) { _rowColours.Row5Col5Colour = colour; _rowColours.Row5Col5TextColour = textColour; }
                    break;
                case 5: // Row 6
                    if (col == 0) { _rowColours.Row6Col1Colour = colour; _rowColours.Row6Col1TextColour = textColour; }
                    if (col == 1) { _rowColours.Row6Col2Colour = colour; _rowColours.Row6Col2TextColour = textColour; }
                    if (col == 2) { _rowColours.Row6Col3Colour = colour; _rowColours.Row6Col3TextColour = textColour; }
                    if (col == 3) { _rowColours.Row6Col4Colour = colour; _rowColours.Row6Col4TextColour = textColour; }
                    if (col == 4) { _rowColours.Row6Col5Colour = colour; _rowColours.Row6Col5TextColour = textColour; }
                    break;

            } // switch
        } // SetColourForRow()

        private async void StartNewGame_Clicked(object sender, EventArgs e)
        {
            _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
            _audioPlayer.Play();

            // Reset game
            currentRow = 0;
            gameWon = false;
            EmojiGrid.Clear();

            // Clear text in all entries
            Row1Col1.Text = Row1Col2.Text = Row1Col3.Text = Row1Col4.Text = Row1Col5.Text = "";
            Row2Col1.Text = Row2Col2.Text = Row2Col3.Text = Row2Col4.Text = Row2Col5.Text = "";
            Row3Col1.Text = Row3Col2.Text = Row3Col3.Text = Row3Col4.Text = Row3Col5.Text = "";
            Row4Col1.Text = Row4Col2.Text = Row4Col3.Text = Row4Col4.Text = Row4Col5.Text = "";
            Row5Col1.Text = Row5Col2.Text = Row5Col3.Text = Row5Col4.Text = Row5Col5.Text = "";
            Row6Col1.Text = Row6Col2.Text = Row6Col3.Text = Row6Col4.Text = Row6Col5.Text = "";

            // Reset colours for all rows
            _rowColours.Row1Col1Colour = _rowColours.Row1Col2Colour = _rowColours.Row1Col3Colour = _rowColours.Row1Col4Colour = _rowColours.Row1Col5Colour = Colors.White;
            _rowColours.Row2Col1Colour = _rowColours.Row2Col2Colour = _rowColours.Row2Col3Colour = _rowColours.Row2Col4Colour = _rowColours.Row2Col5Colour = Colors.White;
            _rowColours.Row3Col1Colour = _rowColours.Row3Col2Colour = _rowColours.Row3Col3Colour = _rowColours.Row3Col4Colour = _rowColours.Row3Col5Colour = Colors.White;
            _rowColours.Row4Col1Colour = _rowColours.Row4Col2Colour = _rowColours.Row4Col3Colour = _rowColours.Row4Col4Colour = _rowColours.Row4Col5Colour = Colors.White;
            _rowColours.Row5Col1Colour = _rowColours.Row5Col2Colour = _rowColours.Row5Col3Colour = _rowColours.Row5Col4Colour = _rowColours.Row5Col5Colour = Colors.White;
            _rowColours.Row6Col1Colour = _rowColours.Row6Col2Colour = _rowColours.Row6Col3Colour = _rowColours.Row6Col4Colour = _rowColours.Row6Col5Colour = Colors.White;

            // Reset text colours for all rows
            _rowColours.Row1Col1TextColour = _rowColours.Row1Col2TextColour = _rowColours.Row1Col3TextColour = _rowColours.Row1Col4TextColour = _rowColours.Row1Col5TextColour = Colors.Black;
            _rowColours.Row2Col1TextColour = _rowColours.Row2Col2TextColour = _rowColours.Row2Col3TextColour = _rowColours.Row2Col4TextColour = _rowColours.Row2Col5TextColour = Colors.Black;
            _rowColours.Row3Col1TextColour = _rowColours.Row3Col2TextColour = _rowColours.Row3Col3TextColour = _rowColours.Row3Col4TextColour = _rowColours.Row3Col5TextColour = Colors.Black;
            _rowColours.Row4Col1TextColour = _rowColours.Row4Col2TextColour = _rowColours.Row4Col3TextColour = _rowColours.Row4Col4TextColour = _rowColours.Row4Col5TextColour = Colors.Black;
            _rowColours.Row5Col1TextColour = _rowColours.Row5Col2TextColour = _rowColours.Row5Col3TextColour = _rowColours.Row5Col4TextColour = _rowColours.Row5Col5TextColour = Colors.Black;
            _rowColours.Row6Col1TextColour = _rowColours.Row6Col2TextColour = _rowColours.Row6Col3TextColour = _rowColours.Row6Col4TextColour = _rowColours.Row6Col5TextColour = Colors.Black;

            submitBtn.IsEnabled = true;

            OnAppearing();
        } // StartNewGame_Clicked()

        private async void ViewHistory_Clicked(object sender, EventArgs e)
        {
            _audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("select.mp3"));
            _audioPlayer.Play();

            await Navigation.PushAsync(new HistoryPage(PlayerName));
        } // ViewHistory_Clicked()

        private async Task SaveAttempt()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, $"{PlayerName}.json");

            // Create new history object
            History history = new History();

            if (File.Exists(filePath)) // Error Checking
            {
                string existingJson = await File.ReadAllTextAsync(filePath);
                history = JsonSerializer.Deserialize<History>(existingJson);
            }
            else
            {
                string json = JsonSerializer.Serialize(history);
                await File.WriteAllTextAsync(filePath, json);
            }

            // Create the attempt details
            var attempt = new Attempt
            {
                RandomWord = RandomWord.ToUpper(),
                NumGuesses = NumGuesses,
                EmojiGrid = string.Join(" ", EmojiGrid), // https://learn.microsoft.com/en-us/dotnet/api/system.string.join?view=net-9.0
                Timestamp = DateTime.Now
            };

            // Add the attempt details
            history.Attempts.Add(attempt);

            // Write to json file
            string jsonWrite = JsonSerializer.Serialize(history);
            await File.WriteAllTextAsync(filePath, jsonWrite);
        } // SaveAttempt()

    } // MainPage
} // namespace