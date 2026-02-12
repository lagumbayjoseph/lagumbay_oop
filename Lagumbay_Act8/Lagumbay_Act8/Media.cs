using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagumbay_Act8
{
    internal class Media
    {
        public string Title { get; set; }

        public Media(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"Title: {Title}";
        }


    }
}
