using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TextFile;

namespace OOP_2nd_assignment
{
	public interface Plant
	{
        public string Name { get; set; }
        public int Nutrient_Level { get; set; }
        public bool Living { get; set; }
        public int Radiation_Demand();
        //public virtual int Radiation_Demand()
        //{
        //    return 0;
        //}
        public void Radiation(string form);
    }

    public class Woreroot : Plant
    {
        public string Name { get; set; }
        public int Nutrient_Level { get; set; }
        public bool Living { get; set; } 
        public Woreroot(string name, int nutrient_level)
        {
            this.Name = name;
            this.Nutrient_Level = nutrient_level;
            Living = true;
        }

        //public override int Radiation_Demand()
        public int Radiation_Demand()
        {
            return 0;
        }

        public void Radiation(string form)
        {
            if (!Living) return;
            switch (form)
            {
                case "alpha":
                    Nutrient_Level += 1; // inc nutrients
                    break;
                case "no_radiation":
                    Nutrient_Level -= 1; // dec nutrients
                    break;
                case "delta":
                    Nutrient_Level += 1; // inc nutrients 
                    break;
            }


            if (Nutrient_Level <= 0)
            {
                Nutrient_Level = 0; 
                Living = false;
            }
        }
    }

    public class Wombleroot : Plant
    {
        public string Name { get; set; }
        public int Nutrient_Level { get; set; }
        public bool Living { get; set; } 
        public Wombleroot(string name, int nutrient_level) //  here we didnt put bool is_alive because in the text file it doesnt mention that
        {
            this.Name = name;
            this.Nutrient_Level = nutrient_level;
            Living = true;
        }

        public int Radiation_Demand()
        {
            return 10;
        }

        public void Radiation(string form)
        {
            if (!Living) return;
            switch (form)
            {
                case "alpha":
                    Nutrient_Level += 2; // inc nutrients
                    break;
                case "no_radiation":
                    Nutrient_Level -= 1; // dec nutrients
                    break;
                case "delta":
                    Nutrient_Level -= 2; // dec double nutrients 
                    break;
            }


            if ( Nutrient_Level > 10 || Nutrient_Level <= 0) // here if the levels of nutrients are above 10 it dies 
            {
                Nutrient_Level = 0;
                Living = false;
            }
        }
    }

    public class Wittentoot : Plant
    {
        public string Name { get; set; }
        public int Nutrient_Level { get; set; }
        public bool Living { get; set; }
        public Wittentoot(string name, int nutrient_level)
        {
            this.Name = name;
            this.Nutrient_Level = nutrient_level;
            Living = true;
        }

        public int Radiation_Demand()
        {
            return Nutrient_Level < 5 ? 4 :
                   (Nutrient_Level >= 5 && Nutrient_Level <= 10) ? 1 : 0;
        }

        public void Radiation(string form)
        {
            if (!Living) return;
            switch (form)
            {
                case "alpha":
                    Nutrient_Level -= 3; // dec nutrients
                    break;
                case "no_radiation":
                    Nutrient_Level -= 1; // dec nutrients
                    break;
                case "delta":
                    Nutrient_Level += 4; // inc nutrients 
                    break;
            }


            if (Nutrient_Level <= 0) // here if the levels of nutrients are below or equal to 10 it dies  
            {
                Nutrient_Level = 0;
                Living = false;
            }
        }
    }
}

