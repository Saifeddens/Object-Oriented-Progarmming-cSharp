using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("testcases")]

namespace OOP_2nd_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the filename to start the ecosystem simulation:");
            bool fileread = true;
            while (fileread)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(filename))
                {
                    Console.WriteLine("Filename cannot be empty. Please enter a valid filename.");
                    continue;
                }
                else try
                {
                    DisplayFileContents(filename);
                    Ecosystem ecosystem = new Ecosystem();
                    ecosystem.programrun(filename);
                    fileread = false;
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("File not found: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            }
            
            Console.WriteLine("Ecosystem simulation complete.");

            static void DisplayFileContents(string filename)
            {
                Console.WriteLine("\nContents of the file:");
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
            }
        }
    }
}
