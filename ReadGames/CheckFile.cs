using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection.Metadata;

namespace ReadGames
{
    public class CheckFile
    {
        private string fullPath { get; set; }
        private string fileOutput { get; set; }
        private bool checkGames;
        List<string> stringLines { get; set; }
        List<string> textPC { get; set; }

        //constructor CheckFile
        public CheckFile()
        {

        }
        public void CheckFileExists(string fullPathFile)
        {
            try
            {
                File.CreateText(fullPathFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void createFileOutput(string path0, string path1)
        {
            FileInfo fileText = new FileInfo(path0);
            //To get directory the file args[0]
            DirectoryInfo directory = fileText.Directory;
            fullPath = directory.FullName;
            //enter game list stringLines
            stringLines = new List<string>();
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
            fileOutput = path1;
            if (path1 == "" || path1 == null)
            {
                fileOutput = path1 = "juegos.txt";
            }
            if (File.Exists(fullPath + "\\" + path1))
            {
                try
                {
                    Console.WriteLine(File.ReadAllText(fullPath + "\\" + path1));
                    Console.WriteLine("Text in the file: " + fullPath + "\\" + path1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }

                Console.WriteLine("are you sure to rewrite the file? yes or no " + fullPath + "\\" + path1);
                string respuesta = Console.ReadLine();
                if (respuesta == "yes" || respuesta == "Yes")
                {

                    try
                    {
                        StreamWriter fileJuegos = File.CreateText(fullPath + "\\" + path1);
                        fileJuegos.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    Console.WriteLine("The file " + fullPath + "\\" + path1 + "was created.");
                    writeFileJuegos(textPC);


                }
                else if (respuesta == "no" || respuesta == "No")
                {
                    Console.WriteLine("The file " + fullPath + "\\" + path1 + " was not created.");
                }

            }
            else
            {
                try
                {
                    File.CreateText(fullPath + "\\" + path1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //fullPath + "\" + args[1];
                writeFileJuegos(textPC);
            }
        } //finish method CreateFileOutput
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
        private void writeFileJuegos(List<string> textPC)
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
    }
}
