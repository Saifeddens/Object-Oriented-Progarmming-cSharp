using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
 
namespace EighthAssignment{
    public class Bag{
        public class ElementNullException : Exception { };
        public class ElementNotFoundException : Exception { };
        public class ElementNotIntegerException : Exception { };
 
        private List<Tuple> Elements = new List<Tuple>();
        public class BagEmptyException : Exception { };
 
        public void AddElem(int elem,int freq)
        {
            bool exists = false;
            foreach (Tuple tup in Elements)
            {
                if(tup.Element == elem){
                    tup.Frequency+=freq;
                    exists = true;  
                }
            }

            if(!exists){
                Elements.Add(new Tuple(elem, freq));
            }
        }
 
        public bool RemElem(int elem, int freq)
        { 
            var tupleToRemove = Elements.Find(t => t.Element == elem);
            if (tupleToRemove != null){
                tupleToRemove.Frequency -= freq;
                if (tupleToRemove.Frequency <= 0)
                {
                    Elements.Remove(tupleToRemove);
                }
                return true;
            }else{
                return false;
            }
        }

        public int FreqOfElem(int elem){ 
            var freqofelement = Elements.Find(t => t.Element == elem); //i tried == elem.Value
            if (freqofelement != null){
                return freqofelement.Frequency;
            }
            return -1;
        }
 
        public int? MaxFreqElem()
        {
            if (Elements.Count == 0){
                throw new BagEmptyException();
            }else if(Elements.Count == 1){
                Console.WriteLine("There's only one tuple in the bag so the max would'nt make sense add another tuple" );
            }
            int maxFrequency = 0;
            int? mostFrequentElement = null;
            foreach (Tuple tup in Elements)
            {
                if (tup.Frequency > maxFrequency)
                {
                    maxFrequency = tup.Frequency;
                    mostFrequentElement = tup.Element;
                }
            }
            return mostFrequentElement;
        }
 
        public void PrintBag()
        {
            foreach (Tuple tup in Elements){
            Console.WriteLine($"{tup.Element}: {tup.Frequency}");
            }
        }
    }
}