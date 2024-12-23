namespace Wordle
{
    public class History
    {
        public List<Attempt> Attempts { get; set; } = new List<Attempt>();
    } // History

    public class Attempt
    {
        public string RandomWord { get; set; }
        public int NumGuesses { get; set; }
        public DateTime Timestamp { get; set; }
        public string EmojiGrid { get; set; }

        // Property that formats the EmojiGrid into a grid
        public string FormattedEmojiGrid
        {
            get
            {
                string[] emojis = EmojiGrid.Split(' '); // Split the string wherever there is a space

                // List that will format the emojis
                List<string> rows = new List<string>();

                // Loop through all 5 rows
                for (int i = 0; i < emojis.Length; i += 5)
                {
                    string row = "";

                    // Add the 5 emojis to the row
                    for (int j = i; j < i + 5 && j < emojis.Length; j++)
                    {
                        // Add each emoji to row and add space
                        row += " ";
                        row += emojis[j];
                    }

                    // Add the row to list
                    rows.Add(row);
                }

                // Join all the rows with a new line between them
                return string.Join("\n", rows); //  https://learn.microsoft.com/en-us/dotnet/api/system.string.join?view=net-9.0
            } // get
        } // FormattedEmojiGrid()

    } // Attempt
} // namespace