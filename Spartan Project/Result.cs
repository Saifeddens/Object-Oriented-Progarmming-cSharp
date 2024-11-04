using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanProject
{
    public class Result
    {
        private int min;
        private int sec;
        private int id;
        private Category cat;

        public int Min()
        {
            return min;
        }
        public int Sec()
        {
            return sec;
        }
        public int ID()
        {
            return id;
        }
        public Category Cat()
        {
            return cat;
        }
        public Result(int m, int s, int ID,Category c)
        {
            if(m <= 0 || s<0 || s>59 || ID<=0) 
            {
                throw new Exception();
            }
            this.min = m;
            this.sec = s;
            this.id = ID;
            this.cat = c;

        }
    }
}
