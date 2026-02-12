using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagumbay_Act8
{
    internal class Song : Media
    {
        public string Artist { get; set; }
        public string Popularity { get; set; }

        public Song(string title, string artist, string popularity)
            : base(title)
        {
            Artist = artist;
            Popularity = popularity;
        }

        public override string ToString()
        {
            return $"{Title} | {Artist} | {Popularity}";
        }

    }
}
