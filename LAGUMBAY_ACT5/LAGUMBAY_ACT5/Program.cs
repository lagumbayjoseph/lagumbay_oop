using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAGUMBAY_ACT5
{
    internal class Program
    {
        internal class Song
        {
            // Instances
            public string Name { get; set; }
            public string DatingAko { get; set; }
            public string Fame { get; set; }

            // Constructor
            public Song(string name, string datingAko, string fame)
            {
                Name = name;
                DatingAko = datingAko;
                Fame = fame;
            }

            // USER INPUT METHOD
            // Purpose
            public static Song InputSong()
            {
                Console.Write("Enter song name: ");
                string name = Console.ReadLine();

                Console.Write("Enter DatingAko: ");
                string datingAko = Console.ReadLine();

                Console.Write("Enter Fame: ");
                string fame = Console.ReadLine();

                return new Song(name, datingAko, fame);
            }

            public override string ToString()
            {
                return $"{Name} | {DatingAko} | {Fame}";
            }
        }
    }
}

        