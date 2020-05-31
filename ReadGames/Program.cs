using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ReadGames
{
    class Program
    {
        //fullPath The path is file creating files on the file system
        static private string fullPath;
        static private string fileOutput;
        //private static bool checkGames;
        //static List<string> stringLines { get; set; }
        static List<string> textPC { get; set; }

        static void Main(string[] args)
        {

            int counter = 0;
            string path0;
            string path1;

            if (args.Length == 0)
            {
                Console.WriteLine("Program read text files on write other files with output only PC Games.");
                Console.WriteLine("Read text file:");
                Console.WriteLine("ReadGames.exe path");

            }

            if (args.Length >= 1)
            {
                if (args[0] != null)
                {
                    // introduce method for read file and create text file PC 
                    // Aqui introducimos el fichero 
                    // Enter a file here

                    path0 = args[0];
                    path1 = args[1];
                    CheckFile checkFile = new CheckFile();
                    checkFile.createFileOutput(path0, path1);

                } //fin args[0]

                if (args[0] == "--help")
                {
                    Console.WriteLine("usage: readgames file.txt or C:\file.txt ");
                    Console.WriteLine("");
                    /*
                        Usage: dir[OPTION]... [FILE]...
                        List information about the FILEs(the current directory by default).
                        Sort entries alphabetically if none of -cftuvSUX nor --sort is specified.

                        Mandatory arguments to long options are mandatory for short options too.
                          -a, --all                  do not ignore entries starting with.
                          -A, --almost-all           do not list implied.and ..
                              --author with -l, print the author of each file
                    */
                }
            } //fin del if (args.Length >= 1) 






        }//end of method Void Main(strings[] args)



      
    } //End of class Program
}

