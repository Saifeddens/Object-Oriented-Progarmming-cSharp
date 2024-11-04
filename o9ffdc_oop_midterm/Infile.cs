using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using o9ffdc_oop_midterm;
using System.Linq.Expressions;

namespace o9ffdc_oop_midterm
{
    public class Data
    {
        public int month;
        public string name;
        public int income;
        public Data(int month, string name, int income)
        {
            this.month = month;
            this.name = name;
            this.income = income;
        }
        public static void Read(ref Infile.Status st,ref Data e,ref TextFileReader x)
        {
            e = new Data(0 , "", 0);
            x.ReadInt(out e.month);
            x.ReadString(out e.name);
            bool l = x.ReadInt(out e.income);
            st = l ? Infile.Status.norm : Infile.Status.abnorm;
        }
    }
    public class Mydata
    {
        public int month;
        public string name;
        public int totalincome;
        public override string ToString()
        {
            return $"({name} - {totalincome})";
        }
    }
    public class Infile
    {
        public enum Status { norm, abnorm }
        private Status st;
        private Data e;
        private TextFileReader x;
        private bool end;
        private Mydata curr;
        public Infile(string name)
        {
            x = new TextFileReader(name);
            curr = new Mydata();
        }
        public void First()
        {
            Data.Read(ref st, ref e, ref x);
            Next();
        }
        public void Next()
        {
            end = st == Status.abnorm;
            if(!end)
            {
                curr.month = e.month;
                curr.name = e.name;
                curr.totalincome = 0;
                while(st == Status.norm && e.month== curr.month  && e.name ==curr.name )
                {
                    curr.totalincome = curr.totalincome + e.income;
                    Data.Read(ref st, ref e, ref x);
                }
                Console.WriteLine("{0}{1}",curr.totalincome,curr.name);
            }
        }
        public Mydata Current()
        {
            return curr;
        }
        public bool End()
        {
            return end;
        }
    }
}

