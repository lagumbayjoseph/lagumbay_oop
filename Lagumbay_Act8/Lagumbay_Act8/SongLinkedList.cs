using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagumbay_Act8
{
    internal class SongLinkedList
    {
        private class Node
        {
            public Song Data;
            public Node Next;

            public Node(Song song)
            {
                Data = song;
                Next = null;
            }
        }

        private Node head;

        // INSERT
        public void Insert(Song song)
        {
            Node newNode = new Node(song);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = head;
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newNode;
            }

            Console.WriteLine("Song added successfully.");
        }

        // REMOVE by title
        public void Remove(string title)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            if (head.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                head = head.Next;
                Console.WriteLine("Song removed successfully.");
                return;
            }

            Node current = head;
            while (current.Next != null &&
                   !current.Next.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                Console.WriteLine("Song not found.");
            }
            else
            {
                current.Next = current.Next.Next;
                Console.WriteLine("Song removed successfully.");
            }
        }

        // DISPLAY
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("No songs in the list.");
                return;
            }

            Node temp = head;
            Console.WriteLine("\nSONG LIST:");
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }
}
