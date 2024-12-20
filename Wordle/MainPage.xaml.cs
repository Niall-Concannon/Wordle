using Microsoft.Maui.Graphics.Text;

namespace Wordle
{
    public partial class MainPage : ContentPage
    {
        // Variables
        private const string sourceFile = "https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt";
        private int currentRow = 0;
        private List<string> validWords = new List<string>(); // List adds valid words to check in game
        string randomWord = "";
        bool gameWon = false;
        private RowColours _rowColours;

        public MainPage()
        {
            InitializeComponent();
            // Initalize and set the binding
            _rowColours = new RowColours();
            BindingContext = _rowColours;
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
                await DisplayAlert("Invalid", "Not enough letters", "OK");
                return;  // Exit
            }

            // Validate the word
            if (!IsValidWord(wordValidator))
            {
                await DisplayAlert("Invalid", "Not in word list", "OK");
                return; // Exit
            }

            CheckLetters(wordValidator);

            CheckForWin(wordValidator);

            if (gameWon == true)
            {
                return; // Exit
            }

            if(currentRow == 5) // Checks if Game Lost
            {
                await DisplayAlert("You Lost", "Word was: " + randomWord.ToUpper(), "OK");
                DisableAllRows();
                submitBtn.IsEnabled = false;
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

                await DisplayAlert("You Win", "You Guessed the Correct Word", "OK");
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

            // Loop checks each letter
            for (int i = 0; i < 5; i++)
            {
                char guessedLetter = guessedWord[i];
                char targetLetter = targetWord[i];

                // Wordle colour scheme used - https://www.color-hex.com/color-palette/1012607
                if (guessedLetter == targetLetter)
                {
                    SetColourForRow(i, Color.FromRgb(108, 169, 101), Colors.White); // Green if correct letter and position
                }
                else if (targetWord.Contains(guessedLetter))
                {
                    SetColourForRow(i, Color.FromRgb(200, 182, 83), Colors.White); // Yellow if correct letter wrong position
                }
                else
                {
                    SetColourForRow(i, Color.FromRgb(120, 124, 127), Colors.White); // Grey if not correct letter
                }
            }
        } // CheckLetter()

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

    } // MainPage
} // namespace
