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
        static List<string> textPC  { get; set; }

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
                    
                    FileInfo fileText = new FileInfo(path0);
                    //To get directory the file args[0]
                    DirectoryInfo directory = fileText.Directory;
                    fullPath = directory.FullName;
                    //enter game list textPC
                    textPC = new List<string>();
                    string newLine = "";
                    //ReadFile(fileText);
                    using (StreamReader sr = fileText.OpenText())
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {

                            stringLines.Add(s);
                            //Console.WriteLine(s);
                            counter++;
                        }
                    }

                    foreach (string sLines in stringLines)
                    {


                        if (sLines.Contains("PC") || sLines.Contains("PS4") || sLines.Contains("One") || sLines.Contains("Switch"))
                        {
                            bool parentesisiz = sLines.Contains("(");
                            bool parentesisd = sLines.Contains(")");
                            if (parentesisiz)
                            {
                                checkGames = checkPC(sLines);
                                int start = sLines.IndexOf("(");
                                int end = sLines.IndexOf(")");
                                int counter0 = end - start;
                                counter0++;
                                string sLinea = sLines.Remove(start, counter0);
                                newLine = sLinea;
                            }
                            textPC.Add(newLine);
                            //si es falso checkPC no añada la linea
                            if (checkGames == false)
                            {
                                textPC.Remove(newLine);
                            }


                        }
                        else
                        {
                            textPC.Add(sLines);
                        }


                    } //fin foreach
                    //crear fichero con el args[1] y manejando excepciones
                    //var listJuegosPC = textPC;
                    fileOutput = args[1];
                    if (args[1] == "" || args[1] == null)
                    {
                        fileOutput = args[1] = "juegos.txt";
                    }
                    
                    if (File.Exists(fullPath + "\\" + args[1]))
                    {
                        try
                        {
                            Console.WriteLine(File.ReadAllText(fullPath + "\\" + args[1]));
                            Console.WriteLine("Text in the file: " + fullPath + "\\" + args[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error:" + ex.Message);
                        }

                        Console.WriteLine("are you sure to rewrite the file? yes or no " + fullPath + "\\" + args[1]);
                        string respuesta = Console.ReadLine();
                        if (respuesta == "yes" || respuesta == "Yes")
                        {

                            try
                            {
                                StreamWriter fileJuegos = File.CreateText(fullPath + "\\" + args[1]);
                                fileJuegos.Close();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            Console.WriteLine("The file " + fullPath + "\\" + args[1] + "was created.");
                            writeFileJuegos(textPC);


                        }
                        else if (respuesta == "no" || respuesta == "No")
                        {
                            Console.WriteLine("The file " + fullPath + "\\" + args[1] + " was not created.");
                        }

                    }
                    else
                    {
                        try
                        {
                            File.CreateText(fullPath + "\\" + args[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        //fullPath + "\" + args[1];
                        writeFileJuegos(textPC);
                    }



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

            
            
            


        }//fin metodo Void Main
        
        private static bool checkPC(string linea)
        {
            bool sPC = linea.Contains("PC");
            if (!sPC)
            {
                sPC = false;
                return false;
            }
            else
            {
                sPC = true;
                return true;
            }
           
        }
        private static void writeFileJuegos(List<string> textPC)
        {
            
            using (StreamWriter sw = new StreamWriter(fullPath + "\\" + fileOutput))
            {
                foreach (string sLines in textPC)
                {
                    //File.WriteAllText(fullPath + "\\" + fileOutput, sLines);
                    sw.WriteLine(sLines);
                }
                sw.Close();
            }
            
                
                
            
        }
        //método para borrar caracteres 
    }

