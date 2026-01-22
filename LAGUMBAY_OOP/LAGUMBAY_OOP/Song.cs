using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAGUMBAY_OOP
{
    internal class Song
    {
        public string Name { get; set; }
        public string DatingAko { get; set; }
        public string Fame { get; set; }

        public Song(string name, string datingAko, string fame)
        {
            Name = name;
            DatingAko = datingAko;
            Fame = fame;
        }

        public override string ToString()
        {
            return $"{Name} - {DatingAko} - {Fame}";
        }


    }
}
