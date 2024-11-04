using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanProject
{
    public interface Category
    {
        public abstract string Type();
    }
    public class Sprint : Category
    {
        private static Sprint? instance;
        private Sprint() { }
        public static Sprint Instance() 
        {
            if(instance == null) instance = new Sprint();
            return instance;
        }
        public string Type()
        {
            return "sprint";
        }
    }
    public class Beast : Category
    {
        private static Beast? instance;
        private Beast() { }
        public static Beast Instance()
        {
            if (instance == null) instance = new Beast();
            return instance;
        }
        public string Type()
        {
            return "beast";
        }
    }
    public class Super : Category
    {
        private static Super? instance;
        private Super() { }
        public static Super Instance()
        {
            if (instance == null) instance = new Super();
            return instance;
        }
        public string Type()
        {
            return "super";
        }
    }


}
