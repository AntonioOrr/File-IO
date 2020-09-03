using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangramCLR;
using System.IO;
using System.Collections;

namespace File_IO
{
    static class Program
    {
        /// Author: Antonio Orr
            //File I/O Activity
        /// 
        [STAThread]
        static void Main()
        {
            //creates string path to store text file
            const string file = "Numbers.txt";
            //creates array of strings separated by line
            string[] lines = System.IO.File.ReadAllLines(file);
            //creates array that converts strings to integers (needed to separate odds from evens)
            int[] convertLines = lines.Select(n => Convert.ToInt32(n)).ToArray();
 
            //creates arraylists to store odd and even numbers
            ArrayList odd = new ArrayList();
            ArrayList even = new ArrayList();
            //deletes files if already exists
            if (File.Exists("Odd.txt"))
            {
                File.Delete("Odd.txt");
            }
            if (File.Exists("Even.txt"))
            {
                File.Delete("Even.txt");
            }
            //loop that scans int array
            for (int i = 0; i < convertLines.Length; i++)
            {
                //if (i == 20)
                  //  break;
                //condition that separates odd from even
                if (convertLines[i] % 2 == 0)
                {
                    //even number added to even arraylist
                    even.Add(lines[i]);
                }
                else
                {
                    //odd number added to odd arraylist
                    odd.Add(lines[i]);
                }
            }
            //converts arraylists to string arrays
            string[] odd1 = odd.ToArray(typeof(string)) as string[];
            string[] even1 = even.ToArray(typeof(string)) as string[];
            //creates files with even/odd numbers written separately
            System.IO.File.WriteAllLines("Odd.txt", odd1);
            System.IO.File.WriteAllLines("Even.txt", even1);

        }
    }
}
