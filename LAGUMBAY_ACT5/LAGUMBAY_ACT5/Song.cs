using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAGUMBAY_ACT5
{
    internal class Song
    {
        public Song(string songName, string artist, string popularity)
        {
            SongName = songName;
            Artist = artist;
            Popularity = popularity;
        }

        public string SongName { get; }
        public string Artist { get; }
        public string Popularity { get; }

        static void Main(string[] args)
        {
            Console.WriteLine("SONG LIST (User Input)\n");

            var songs = new List<Song>();
            int entryNumber = 1;

            // Collect at least 3 songs
            while (true)
            {
                string songName = ReadNonEmpty($"Enter Song #{entryNumber} Name: ");
                string artist = ReadNonEmpty($"Enter Artist for Song #{entryNumber}: ");
                string popularity = ReadNonEmpty($"Enter Popularity for Song #{entryNumber}: ");

                songs.Add(new Song(songName, artist, popularity));
                entryNumber++;

                Console.WriteLine();

                if (songs.Count >= 3)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1 - Add more songs");
                    Console.WriteLine("2 - Done");

                    int choice = ReadIntInRange("Enter choice (1 or 2): ", 1, 2);
                    Console.WriteLine();

                    if (choice == 2)
                        break;
                }
            }

            // Convert List to 2D Array (3 rows)
            int rows = 2;
            int cols = (int)Math.Ceiling(songs.Count / (double)rows);
            Song[,] songGrid = new Song[rows, cols];

            for (int i = 0; i < songs.Count; i++)
            {
                int r = i / cols;
                int c = i % cols;
                songGrid[r, c] = songs[i];
            }

            // Display songs in grid format
            Console.WriteLine("SONG GRID:\n");

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (songGrid[r, c] != null)
                        Console.Write(songGrid[r, c] + "\t");
                }
                Console.WriteLine("\n");
            }

            // Display as table
            Console.WriteLine("DISPLAYING SONGS (2D ARRAY)\n");

            for (int r = 0; r < songGrid.GetLength(0); r++)
            {
                for (int c = 0; c < songGrid.GetLength(1); c++)
                {
                    if (songGrid[r, c] != null)
                        Console.Write(songGrid[r, c] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Read number with validation
        private static int ReadIntInRange(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                    return value;

                Console.WriteLine($"Invalid input. Enter a number between {min} and {max}.");
            }
        }

        // Read non-empty text
        private static string ReadNonEmpty(string prompt)
        {
            string text;
            do
            {
                Console.Write(prompt);
                text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text))
                    Console.WriteLine("Input cannot be empty.");
            }
            while (string.IsNullOrWhiteSpace(text));

            return text.Trim();
        }
    }
}
