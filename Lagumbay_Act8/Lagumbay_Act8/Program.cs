using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagumbay_Act8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SongLinkedList songList = new SongLinkedList();
            int choice;

            do
            {
                Console.WriteLine("\n===== SONG MENU =====");
                Console.WriteLine("1 - Insert Song");
                Console.WriteLine("2 - Remove Song");
                Console.WriteLine("3 - Display Songs");
                Console.WriteLine("4 - Exit");

                choice = UserInput.ReadIntInRange("Enter choice (1-4): ", 1, 4);
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        string title = UserInput.ReadNonEmpty("Enter Song Title: ");
                        string artist = UserInput.ReadNonEmpty("Enter Artist: ");
                        string popularity = UserInput.ReadNonEmpty("Enter Popularity: ");

                        Song newSong = new Song(title, artist, popularity);
                        songList.Insert(newSong);
                        break;

                    case 2:
                        string removeTitle = UserInput.ReadNonEmpty("Enter Song Title to remove: ");
                        songList.Remove(removeTitle);
                        break;

                    case 3:
                        songList.Display();
                        break;

                    case 4:
                        Console.WriteLine("Exiting program...");
                        break;
                }

            } while (choice != 4);


        }
    }
}
