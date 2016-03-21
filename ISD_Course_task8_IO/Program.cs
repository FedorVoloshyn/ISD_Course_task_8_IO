using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace ISD_Course_task_8_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            int chosen_exersise = -1;

            while (chosen_exersise != 0)
            {
                Console.WriteLine("\tISD Course. Task 8. Homework by Fedor Voloshyn.\n");
                Console.WriteLine("Enter number of exercise or '0' to exit: ");
                chosen_exersise = ImputFilter.ImputIntNumber(Console.ReadLine());
                Console.Clear();

                switch (chosen_exersise)
                {
                    case 0: Console.WriteLine("Have a nice day!");
                        break;
                    case 1: ExerciseOne();
                        break;
                    case 2: ExerciseTwo();
                        break;
                    case 3: ExerciseThree();
                        break;
                    default: Console.WriteLine("Looks like you entered wrong number! Try again ;)");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void ExerciseOne()
        {
            DirectoryInfo myDirectory = new DirectoryInfo(@"..\..\"); // Current progect folder
            List<DirectoryInfo> arrayOfFolders = new List<DirectoryInfo>();

            for(int i = 0; i < 100; i++)
            {
                myDirectory.CreateSubdirectory("Folder_" + i.ToString());
                arrayOfFolders.Add(new DirectoryInfo(@"..\..\Folder_" + i.ToString()));
            }

            Console.WriteLine("Folders created! Press any key to delete them...");
            Console.ReadKey();

            foreach(var folder in arrayOfFolders)
            {
                folder.Delete();
            }
        }
        public static void ExerciseTwo()
        {
            File.AppendAllText(@"..\..\MyFile.txt", "Text in file.");
            string textFromFile = File.ReadAllText(@"..\..\MyFile.txt");
            Console.WriteLine(textFromFile);
        }
        public static void ExerciseThree() // Еще не доделано
        {
            Console.WriteLine("Enter file name: ");
            string fileName = Console.ReadLine();
            DirectoryInfo startDirectory = new DirectoryInfo(@"E:\");
            string pathToFile = SearchForFile(startDirectory, fileName);
            if (pathToFile != "")
            {
                Console.WriteLine("Your file is in the next directory: {0}", pathToFile);
                FileStream fileStream = new FileStream(pathToFile, FileMode.Open);
            }
            else
                Console.WriteLine("No such file!");
        }
        static string SearchForFile(DirectoryInfo startDirectory, string fileName)
        {
            FileInfo[] filesInFolder = startDirectory.GetFiles();
            foreach (FileInfo infoAboutFile in filesInFolder)
            {
                if (fileName.Equals(infoAboutFile.Name))
                {
                    return infoAboutFile.Directory.Name + @"\" + infoAboutFile.Name;
                }
            }
            DirectoryInfo[] dirs = startDirectory.GetDirectories();
            foreach (DirectoryInfo directoryInfo in dirs)
            {
                SearchForFile(directoryInfo, fileName);
            }
            return "";
        }
    }
}
