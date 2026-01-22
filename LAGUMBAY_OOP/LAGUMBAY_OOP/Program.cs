using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAGUMBAY_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Song List");
            Console.WriteLine();

            var songs = new List<Song>();
            int entryNumber = 1;

            // Collect songs: require at least 3 entries; after 3 allow user to Add more or Done
            while (true)
            {
                string songName = ReadNonEmpty($"Enter Song#{entryNumber} name: ");
                string datingAko = ReadNonEmpty($"Enter datingako{entryNumber}: ");
                string fame = ReadNonEmpty($"Enter fame for {entryNumber}: ");

                songs.Add(new Song(songName, datingAko, fame));
                entryNumber++;
                Console.WriteLine();

                if (songs.Count >= 3)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1 - Add more");
                    Console.WriteLine("2 - Done");

                    int opt = ReadIntInRange("Enter 1 or 2: ", 1, 2);
                    Console.WriteLine();

                    if (opt == 2)
                        break;
                }
            }

            // Selection loop
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine();

                var distinctSongs = songs
                    .Select(c => c.Name.Trim())
                    .Where(r => !string.IsNullOrWhiteSpace(r))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(r => r, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                Console.WriteLine("Choose a song:");
                Console.WriteLine("0 - All");
                for (int i = 0; i < distinctSongs.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {distinctSongs[i]}");
                }

                int maxChoice = distinctSongs.Count;
                int choice = ReadIntInRange("Enter choice: ", 0, maxChoice);
                Console.WriteLine();

                if (choice == 0)
                {
                    DisplaySongs(songs);
                }
                else
                {
                    string selectedSong = distinctSongs[choice - 1];
                    var filtered = songs
                        .Where(c => string.Equals(c.Name.Trim(), selectedSong.Trim(), StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (filtered.Count == 0)
                    {
                        Console.WriteLine($"No songs found with: {selectedSong}");
                    }
                    else
                    {
                        Console.WriteLine($"Song details for: {selectedSong}");
                        for (int i = 0; i < filtered.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {filtered[i]}");
                        }
                    }
                }

                Console.WriteLine();
                Console.Write("Do you want to choose another song? (Y/N): ");
                string resp = Console.ReadLine() ?? string.Empty;
                if (!resp.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    keepRunning = false;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DisplaySongs(List<Song> songs)
        {
            Console.WriteLine("All Songs:");
            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {songs[i]}");
            }
        }

        private static int ReadIntInRange(string prompt, int min, int max)
        {
            int value = min - 1;
            while (value < min || value > max)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (!int.TryParse(s, out value))
                {
                    Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
                    value = min - 1;
                }
                else if (value < min || value > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                }
            }
            return value;
        }

        private static string ReadNonEmpty(string prompt)
        {
            string text = string.Empty;
            while (string.IsNullOrWhiteSpace(text))
            {
                Console.Write(prompt);
                text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Value cannot be empty. Try again.");
                }
            }
            return text.Trim();
        }
    }


}
    


