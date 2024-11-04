using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanProject
{
    public class Competition
    {
        public int year;
        public string place;
        public List<Result> res = new List<Result>();
        public List<Category> cat = new List<Category>();


        public Competition(int y, string p,List<Category> c)
        {
            if(c.Count == 0 || y<=2000)
            {
                throw new Exception();
            }
            this.year = y;
            this.place = p;
            this.cat = c;
        }
        public Category PopularCat()
        {
            int max = 0;
           Category ?c = null;
            bool l = false;
           
            foreach (Category e in cat)
            {
                int count = 0;
                foreach(Result e2 in res)
                {
                    if( e2.Cat().Type() == e.Type()){
                        count++;
                    }
                }
                
                if (!l)
                {
                    l = true;
                    max = count; 
                    c = e;
                }
                else
                {
                    if(count > max)
                    {
                        max = count;
                        c = e;
                    }
                }
            }
                return c;
            
        }

        public void Score(int min,int sec,int num,Category c)
        {
            bool l2 = false;
            bool l3 = false;
            foreach(Category e in cat)
            {
                if (e == c)
                {
                    l2 = true;
                }
            }
            if(!l2)
            {
                throw new Exception();
            }
            
            foreach(Result e in res)
            {
                if(e.Cat() == c &&  e.ID() == num)
                {
                    l3 = true;
                }
            }
            if (l3)
            {
                throw new Exception();
            }
            res.Add(new Result(min,sec,num,c));
            
        }
        public Tuple<bool,int> Winner(Category c)
        {
            bool l = false;
            Result? elem = null;
            int min = int.MaxValue;
            foreach(Result e in res)
            {
                if (e.Cat() == c)
                {
                    if (!l)
                    {
                        l = true;
                        min = ((e.Min() * 60) + (e.Sec()));
                        elem = e;
                    }
                    else
                    {
                        if(min > ((e.Min() * 60) + (e.Sec())))
                        {
                            elem = e;
                            min = (e.Min() * 60) + (e.Sec());
                        }
                    }
                }
                
            }
            if(elem == null)
            {
                return new Tuple<bool, int>(false, 0);
            }
            int n = elem.ID();
            return new Tuple<bool,int> (l,n);
        }
    }
}
