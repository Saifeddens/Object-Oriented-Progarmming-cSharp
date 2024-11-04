using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    internal class District
    {
        private string name;
        public string Name(string name)
        {
            return name;
        }
        
        public List<Wonder> ws = new List<Wonder>();   
        public District(string n,List<Wonder> wss) 
        {
            name = n;
            foreach(Wonder w in wss)
            {
                if (ws.Contains(w))
                {
                    throw new Exception();
                }
                else
                {
                    ws.Add(w);
                }
            }
        }
        public int MaxDistance()
        {
            if(ws.Count == 0)
            {
                throw new Exception("error");
            }
            else
            {
                int max = int.MinValue;
                foreach(Wonder w in ws)
                {
                    
                    if(max< w.Farthest(ws))
                    {
                        max = w.Farthest(ws);
                    }
                }
                return max;
            }
            
        }
    }
}
