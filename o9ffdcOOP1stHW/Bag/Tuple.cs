using EighthAssignment;
public class Tuple
    {
        public int Element { get; set; }
        public int Frequency { get; set; }
        public Tuple() { }
        public Tuple(int elem, int freq)
        {
            Element = elem;
            Frequency = freq;
        }
    }