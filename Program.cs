using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptSort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] HashList = new string[args.Length];
            for (int i = 0; i < args.Length; i++)
            { HashList[i] = sha256(args[i]); }

            string[] HashListOriginalSorting = new string[args.Length];
            HashList.CopyTo(HashListOriginalSorting, 0);
            Array.Sort(HashList);

            foreach (var arg in args)
            { Console.Write(arg+" "); }
            Console.WriteLine();

            foreach (var hash in HashList)
            { Console.Write(hash + " "); }
            Console.WriteLine();

            foreach (var hash in HashListOriginalSorting)
            { Console.Write(hash + " "); }
            Console.WriteLine();

            string[] SortedArgs = new string[HashList.Length];
            for (int i = 0; i < HashListOriginalSorting.Length; i++)
            {
                int index = Array.IndexOf(HashList, HashListOriginalSorting[i]);
                SortedArgs[i] = args[index];
            }

            foreach (var arg in SortedArgs)
            { Console.Write(arg + " "); }




        }

        static string sha256(string data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                { sb.Append(bytes[i].ToString("x2")); }

                return sb.ToString();
            }
        }
    }
}
