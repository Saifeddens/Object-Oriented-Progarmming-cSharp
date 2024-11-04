using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    public abstract class Wonder
    {
        public int x{ get; protected set; }
        public int y{ get; protected set; }
        protected int interest;
        protected int built;
        protected Wonder(int x,int y,int i,int b) 
        {
            this.x= x;
            this.y= y;
            interest= i;
            built= b;
        }
        public abstract string GetType();
        public int ExpectedTime()
        {
            return Factor() * interest;
        }
        protected abstract int Factor();
        public static int Distance(Wonder w1,Wonder w2)
        {
            return Math.Abs(w1.x - w2.x) + Math.Abs(w1.y - w2.y);
        }
        public int Farthest(List<Wonder> ws) 
        {
            if (ws.Count == 0)
            {
                throw new Exception("0 LENGTH");
            }

            int max = int.MinValue;
            foreach (Wonder w in ws)
            {
                
                if(max< Distance(w,this))
                {
                    max= Distance(w, this);
                }
            }return max;
            
        }
        
    }
    public class Cathedral : Wonder
    {
        public Cathedral(int x, int y, int i, int b) : base(x, y, i, b) { }
        public override string GetType()
        {
            return "cath";
        }
        protected override int Factor()
        {
            return (2023 - built) + 5;
        }
    }
    public class Museum : Wonder
    {
        public Museum(int x, int y, int i, int b) : base(x, y, i, b) { }
        public override string GetType()
        {
            return "mus";
        }
        protected override int Factor()
        {
            return 1000 / (x * x + y * y + 1);
        }
    }
    public class Castle : Wonder
    {
        public Castle(int x, int y, int i, int b) : base(x, y, i, b) { }
        public override string GetType()
        {
            return "cast";
        }
        protected override int Factor()
        {
            return (2023 - built) * 2;
        }
    }
}
