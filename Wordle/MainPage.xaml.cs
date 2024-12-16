namespace Wordle
{
    public partial class MainPage : ContentPage
    {
        // Variables
        private const string sourceFile = "https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt";

        public MainPage()
        {
            InitializeComponent();
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
        }

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

    } // MainPage
} // namespace
