using System;
using System.IO;

namespace OTUS_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDirectory = new DirectoryInfo(@"c:\Otus\TestDir1");
            var secondDirectory = new DirectoryInfo(@"c:\Otus\TestDir2");
            firstDirectory.Create();
            secondDirectory.Create();

            CreateFiles(firstDirectory.ToString());
            CreateFiles(secondDirectory.ToString());

            WriteToFile(firstDirectory.ToString(), "File");
            WriteToFile(secondDirectory.ToString(), "File");

            WriteToFile(firstDirectory.ToString(), DateTime.Now);
            WriteToFile(secondDirectory.ToString(), DateTime.Now);

            ReadFromFile(firstDirectory.ToString());
            ReadFromFile(secondDirectory.ToString());

            Console.ReadLine();
        }

        static void CreateFiles(string path)
        {
            for (int i = 1; i < 11; i++)
            {
                string auxiliaryString = path + @"\File" + i + ".txt";
                var myFile = File.Create(auxiliaryString);
                myFile.Close();
            }
        }

        static void WriteToFile(string directory, string message)
        {
            for (int i = 1; i < 11; i++)
            {
                string auxiliaryString = directory + @"\File" + i + ".txt";

                if (File.Exists(auxiliaryString))
                {
                    using (StreamWriter writer = new StreamWriter(auxiliaryString, true))
                    {
                        writer.Write(message + i + "\t");
                        writer.Close();
                    }
                }
            }
        }

        static void WriteToFile(string directory, DateTime dateTime)
        {
            for (int i = 1; i < 11; i++)
            {
                string auxiliaryString = directory + @"\File" + i + ".txt";

                if (File.Exists(auxiliaryString))
                {
                    using (StreamWriter writer = new StreamWriter(auxiliaryString, true))
                    {
                        writer.Write(dateTime.ToString());
                        writer.Close();
                    }
                }
            }
        }

        static void ReadFromFile(string directory)
        {
            for (int i = 1; i < 11; i++)
            {
                string auxiliaryString = directory + @"\File" + i + ".txt";

                if (File.Exists(auxiliaryString))
                {
                    using (StreamReader reader = new StreamReader(auxiliaryString))
                    {
                        string str = reader.ReadToEnd();
                        string[] arrayStr = str.Split('\t');
                        Console.WriteLine($"имя_файла: File" + i + $" текст: {arrayStr[0]} " + $"дополнение: {arrayStr[1]}");
                        reader.Close();
                    }
                }
            }
        }
    }
}
