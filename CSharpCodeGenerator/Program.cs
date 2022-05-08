using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CSharpCodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Download();
            ReadCSV("temp.csv");



            Console.ReadKey();
        }
        static void Download()
        {

            WebClient mywebClient = new WebClient();
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/unique_equipment_enhance_rate.sql", Environment.CurrentDirectory + @"/temp.csv");
            Console.WriteLine("done");
        }
        static void ReadCSV(string filename)
        {
            StreamReader sr = new StreamReader(filename); ;
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var values = line.Split(';');

                listA.Add(line);
                foreach (var coloumn1 in listA)
                {
                    Console.WriteLine(coloumn1);
                }
            }
        }
    }
}
