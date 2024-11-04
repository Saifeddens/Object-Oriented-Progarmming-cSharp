using System.Globalization;
using System.Threading;
 
namespace EighthAssignment{
    class Program{
        public class ElementNullException : Exception { };
        static void Main(){
            
            int elem = 0;
            int freq = 0;
            int method = 0;
            Bag Elements = new Bag();
            
            do
            {
                Console.WriteLine("\nPlease choose one the methods displayed as options:\n");
                Console.WriteLine("(1). END");
                Console.WriteLine("(2).Add an element to the bag");
                Console.WriteLine("(3).Remove an element from the bag");
                Console.WriteLine("(4). Get frequency of an element");
                Console.WriteLine("(5). Get most frequent element");
                Console.WriteLine("(6). Print bag");
                Console.WriteLine();

                if (!int.TryParse(Console.ReadLine(), out method))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue; // here the loop will be skipped and prompt to the user
                }

                switch (method)
                {
                    case 2:
                        Console.Write("Enter an element to insert: ");
                        if(!int.TryParse(Console.ReadLine() ,  out elem)){
                            continue;
                        }
                        Console.Write("Enter its frequency to insert: ");
                        if(!int.TryParse(Console.ReadLine() ,  out freq) && (freq>0)){
                            continue;
                        }
                        if(freq<=0){
                            Console.WriteLine("ELEMENT MUST BE BIGGER THAN ZERO");
                            break;
                        }
                        Elements.AddElem(elem,freq);
                        Console.WriteLine("Element inserted successfully.({0},{1})",elem,freq);
                        break;

                    case 3:
                        Console.Write("Enter an element to delete: ");
                        if(!int.TryParse(Console.ReadLine() , out elem)){
                            continue;
                        }
                        Console.Write("Enter its frequency to delete: ");
                        if(!int.TryParse(Console.ReadLine() , out freq)){
                            continue;
                        }
                        if(freq<=0){
                            break;
                        }
                        bool removed = Elements.RemElem(elem,freq);
                        if (removed)
                        {
                            Console.WriteLine("Element removed successfully.({0},{1})",elem,freq);
                        }
                        else
                        {
                            Console.WriteLine("Element not found.");
                        }
                        break;

                    case 4:
                        Console.Write("Enter an element to find its frequency: ");
                        if(!int.TryParse(Console.ReadLine() , out elem)){
                            continue;
                        }
                        int frequency = Elements.FreqOfElem(elem);
                        if (frequency > 0)
                        {
                            Console.WriteLine("Element frequency: {1}.", elem, frequency);
                        }
                        else
                        {
                            Console.WriteLine("Element not in bag");
                        }
                        break;

                    case 5:
                        int? mostFrequentElement = Elements.MaxFreqElem();
                        if (mostFrequentElement > 0)
                        {
                            Console.WriteLine("Most frequent element: {0}.", mostFrequentElement);
                        }
                        else
                        {
                            Console.WriteLine("Bag is empty.");
                        }
                        break;

                    case 6:
                        Elements.PrintBag();
                        break;

                    case 1:
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
            } while (method != 1);
        }
    }
}