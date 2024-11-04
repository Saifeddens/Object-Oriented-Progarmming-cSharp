using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    internal class City
    {
        public List<District> ds = new();
        public City(List<District> dss)
        {
            
            foreach(District d in dss)
            {
                if (ds.Contains(d))
                {
                    throw new Exception();
                }
                else
                {
                    ds.Add(d);
                }
            }
        }
        public District WhichDistrict(Wonder w)
        {
           
            foreach(var d in ds)
            {
                if (d.ws.Contains(w))
                {
                    return d;
                }
            }
            return null;
        }
    }
}
