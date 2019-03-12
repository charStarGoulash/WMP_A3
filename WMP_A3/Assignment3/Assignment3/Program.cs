// FILE : Program.cs
// PROJECT : PROG2120 - Assignment #3
// PROGRAMMER : Attila Katona
// FIRST VERSION : 2018-10-19
// DESCRIPTION : This is the source code file for assignment 3. This program will test the speeds of several type of data
//               structures. It will test the speed of finding a value from the structure using rhe value and the key. It
//               will display the results indicating what test was completed, the result and the time it took.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Assignment3
{
    class Program
    {
        //Below are the variables used in this program
        public static Random r = new Random();
        public static Random randomNum = new Random();
        static void Main(string[] args)
        {
            //Below are the variables used in this program
            string word;
            string wordToSearch = "Attila";
            int keyToSearch = 50001;
            bool checker;
            int x;
            Hashtable ht = new Hashtable();
            Dictionary<int, string> dt = new Dictionary<int, string>();
            List<string> list = new List<string>();
            ArrayList al = new ArrayList();
            Stopwatch sw = new Stopwatch();

            //Below I am populating the data structures using all the same data throughout
            using (StreamWriter file = new StreamWriter("words.txt", true))
            {
                for (x = 0; x <= 500000; x++)
                {
                    word = GenerateName();
                    try
                    {
                        ht.Add(x, word);
                        dt.Add(x, word);
                        list.Add(word);
                        al.Add(word);
                    }
                    catch
                    {
                        Console.WriteLine("Duplicate keys! Did not add value!");
                    }
                    file.WriteLine(word); //writing the word to a file for reference to what the structures look like
                }
                //Below I am adding the word "Attila" to ensure that this value is in the data structures because this
                //is the word I am using to search the structures.
                try
                {
                    ht.Add(x, "Attila");
                    dt.Add(x, "Attila");
                    list.Add("Attila");
                    al.Add("Attila");
                }
                catch
                {
                    Console.WriteLine("Duplicate keys! Did not add value!");
                }
                file.WriteLine("Attila");//Also writing it to the file
            }

            Console.WriteLine("Assignment 3 - Windows Mobile Programming");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Searching Value: " + wordToSearch);
            Console.WriteLine("");
            Console.WriteLine("Searching Key  : " + keyToSearch);
            Console.WriteLine("");

            //Below I am searching each value and key 1000 times
            if (wordToSearch != "")
            {
                //Testing the Hash Table searching for a value
                sw = Stopwatch.StartNew();
                for (x = 1; x <= 999; x++)
                {
                    ht.ContainsValue(wordToSearch);
                }
                checker = ht.ContainsValue(wordToSearch);
                sw.Stop();
                Console.WriteLine("HashTable-Value Result : " + checker + " Time Elapsed : " + sw.Elapsed  + "  HashTable Size  : " + ht.Count);
                Console.WriteLine("");

                //Tesing the Hash Table searching for a key
                sw.Restart();
                for (x = 1; x <= 999; x++)
                {
                    ht.ContainsKey(keyToSearch);
                }
                checker = ht.ContainsKey(keyToSearch);
                sw.Stop();
                Console.WriteLine("HashTable-Key Result   : " + checker + " Time Elapsed : " + sw.Elapsed + "  HashTable Size  : " + ht.Count);
                Console.WriteLine("");

                //Testing the Dictionary searching for a value
                sw.Restart();
                for (x = 1; x <= 999; x++)
                {
                    dt.ContainsValue(wordToSearch);
                }
                checker = dt.ContainsValue(wordToSearch);
                sw.Stop();
                Console.WriteLine("Dictionary-Value Result: " + checker + " Time Elapsed : " + sw.Elapsed + "  Dictionary Size : " + dt.Count);
                Console.WriteLine("");

                //Testing the Dictionary searching for a key
                sw.Restart();
                for (x = 1; x <= 999; x++)
                {
                   dt.ContainsKey(keyToSearch);
                }
                checker = dt.ContainsKey(keyToSearch);
                sw.Stop();
                Console.WriteLine("Dictionary-Key Result  : " + checker + " Time Elapsed : " + sw.Elapsed + "  Dictionary Size : " + dt.Count);
                Console.WriteLine("");

                //Testing the List searching for a value
                sw.Restart();
                for (x = 1; x <= 999; x++)
                {
                    list.Contains(wordToSearch);
                }
                checker = list.Contains(wordToSearch);
                sw.Stop();
                Console.WriteLine("List Result            : " + checker + " Time Elapsed : " + sw.Elapsed + "  List Size       : " + list.Count);
                Console.WriteLine("");

                //Testing the Array List searching for a value
                sw.Restart();
                for (x = 1; x <= 999; x++)
                {
                    al.Contains(wordToSearch);
                }
                checker = al.Contains(wordToSearch);
                sw.Stop();
                Console.WriteLine("ArrayList Result       : " + checker + " Time Elapsed : " + sw.Elapsed + "  ArrayList Size  : " + al.Count);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Must enter a word. Look at words.txt for words to try");
            }


        }
        /// <summary>
        /// Generates a random First name, Last name and date of birth
        /// </summary>
        /// <returns>A string in the format FirstName*LastName*DOB</returns>
        public static string GenerateName()
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string userInfo = "";
            int randomNumber = randomNum.Next(0, 9);
            userInfo += consonants[r.Next(consonants.Length)].ToUpper();
            userInfo += vowels[r.Next(vowels.Length)];
            /// <summary>
            /// b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            /// </summary>
            int b = 2;
            while (b < randomNumber)
            {
                userInfo += consonants[r.Next(consonants.Length)];
                b++;
                userInfo += vowels[r.Next(vowels.Length)];
                b++;
            }
            
            return userInfo;
        }
    }
}
