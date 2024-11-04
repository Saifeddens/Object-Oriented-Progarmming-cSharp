using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using o9ffdc_oop_midterm;

namespace o9ffdc_oop_midterm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            bool fileError = true;
            do
            {
                try
                {
                    Console.WriteLine("Enter filename: ");
                    string name = Console.ReadLine();
                    Infile t = new Infile(name);
                    bool l = false;
                    int count = 0;
                    int count1 = 0;
                    t.First();
                   
                    

                    while (!t.End())
                    {
                        int right = t.Current().totalincome;
                        int month = 0;
                        
                        if ((right >= 30000) && t.Current().name == "Johnny" ) 
                        {
                           l = true;
                            count++;
                            count1++;
                        }
                        

                        else
                        {
                            l = false;
                            t.End();

                        }
                        t.Next();
                    }

                    if (count == count1 && l == true)
                    {
                        Console.WriteLine("yes");
                    }
                    else
                    {
                        Console.WriteLine("no");
                    }
                    fileError = false;

                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("enter filename in correct format please");
                    Console.WriteLine("");
                }
            }while (fileError);
        }
    }
}