using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_3._4_Towers_of_Hanoi
{
    class Program
    {
        // towers are static membors for ease of access during console output
        static Tower tower1;
        static Tower tower2;
        static Tower tower3;

        static void Main(string[] args)
        {
            PrintHeaderMsg(3, 4, "Towers of Hanoi");

            // Three towers
            tower1 = new Tower(new[] { 5, 4, 3, 2, 1 });
            tower2 = new Tower();
            tower3 = new Tower();

            PrintTowers(tower1, tower2, tower3);

            MoveDisks(5, tower1, tower3, tower2);            

            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// Recursive function moves 1 disk at a time, using 1 tower as the origin,
        /// 1 tower as the destination, and 1 tower as the buffer.
        /// Which tower is which depends on the call. Sometimes tower1/2/3 is the origin,
        /// sometimes the buffer, sometimes the destination.
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="buffer"></param>
        private static void MoveDisks(int n, Tower origin, Tower destination, Tower buffer)
        {
            if (n <= 0)
                return;

            // move n-1 disks from origin to buffer, using destination as a buffer
            MoveDisks(n - 1, origin, buffer, destination);

            // move top disk from origin to destination
            destination.Push(origin.Pop());
            PrintTowers(tower1, tower2, tower3);

            // move top n-1 disks from buffer to destination, using origin as a buffer
            MoveDisks(n - 1, buffer, destination, origin);
        }        

        private static void PrintTowers(Tower tower1, Tower tower2, Tower tower3)
        {
            Console.Write("Tower 1 Contains: ");
            foreach (int i in tower1.ToList())
                Console.Write(i + ", ");
            Console.WriteLine();

            Console.Write("Tower 2 Contains: ");
            foreach (int i in tower2.ToList())
                Console.Write(i + ", ");
            Console.WriteLine();

            Console.Write("Tower 3 Contains: ");
            foreach (int i in tower3.ToList())
                Console.Write(i + ", ");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }
 
    /// <summary>
    /// 
    /// Derive a new class 'Tower' from Stack<int> and hide Push() method
    /// with new function that insures you can only push a value onto a 
    /// larger value.
    /// 
    /// NOTE: hiding requires 'new' keyword when creating objects
    /// 
    /// </summary>
    class Tower : Stack<int>
    {
        public Tower() : base()
        {
        }

        // necessary for initialization via passed set
        public Tower(IEnumerable<int> collection) : base(collection)
        {
        }

        // new Push() function hides base function, but calls it after test
        public void Push(int item)
        {
            if ((base.Count > 0) && (item > Peek()))
                throw new InvalidOperationException("Tried to push larger value onto smaller value.");

            base.Push(item);            
        }
    }
}