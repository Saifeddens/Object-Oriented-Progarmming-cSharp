using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection.Emit;
using TextFile;

namespace OOP_2nd_assignment
{
    public class Ecosystem
    {
        private List<Plant> plants = new List<Plant>();
        private List<string> everyday = new List<string>();

        public void EcoPlantsData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                int plantCount = int.Parse(reader.ReadLine());
                for (int i = 0; i < plantCount; i++)
                {
                    var plantInfo = reader.ReadLine().Split(' ');
                    var plant = CreatePlant(plantInfo[0], plantInfo[1], int.Parse(plantInfo[2]));
                    plants.Add(plant);
                }

                int days = int.Parse(reader.ReadLine());
                for (int i = 1; i <= days; i++)
                {
                    everyday.Add(reader.ReadLine());
                }
            }
        }


        public Plant CreatePlant(string name, string type, int nutrients)
        {
            switch (type)
            {
                case "wom": return new Wombleroot(name, nutrients);
                case "wit": return new Wittentoot(name, nutrients);
                case "wor": return new Woreroot(name, nutrients);
                default: throw new ArgumentException("Unknown plant type");
            }
        }

        public void Radiation_form()
        {
            for (int i = 1; i <= everyday.Count; i++)
            {
                Console.WriteLine("Day:{0} of radiation", i);

                string radiationType;

                if (i == 1)
                {
                    radiationType = "none";
                    Console.WriteLine("Day 1: Radiation Type: none "); //bc in the question they said first day no radiation
                }
                else
                {
                    int alpha_radiation = 0;
                    int delta_radiation = 0;

                    foreach (Plant plant in plants)
                    {
                        if (plant.Living && plant.Radiation_Demand() > 0) //needs to be living to be included here
                        {
                            if (plant.GetType() == typeof(Wombleroot))
                            {
                                alpha_radiation += plant.Radiation_Demand();
                            }
                            else if (plant.GetType() == typeof(Wittentoot))
                            {
                                delta_radiation += plant.Radiation_Demand();
                            }
                        }
                    }

                    radiationType = Winner_form(alpha_radiation, delta_radiation);
                    Console.WriteLine("Radiation Type: {0}", radiationType);
                }

                
                foreach (Plant plant in plants)//to apply radiation to every plant
                {
                    if (plant.Living)
                    {
                        plant.Radiation(radiationType);
                    }
                    if (plant.Nutrient_Level == 0)
                    {
                        Console.WriteLine("Plant Name: {0}, Nutrient Level: {1} Wasted", plant.Name, plant.Nutrient_Level);
                    }
                    else
                    {
                        Console.WriteLine("Plant Name: {0}, Nutrient Level: {1}", plant.Name, plant.Nutrient_Level);
                    }
                }
            }
        }


        public string Winner_form(int alpha_radiation, int delta_radiation)
        {
            if (alpha_radiation - delta_radiation > 3)
            {
                return "alpha";
            }
            else if (delta_radiation - alpha_radiation > 3)
            {
                return "delta";
            }
            else
            {
                return "no_radiation";
            }
        }



        public string survivor()
        {
            Plant number1 = null;
            int max = 0;

            foreach (Plant plant in plants)
            {
                if (plant.Living && (plant.Nutrient_Level > max))
                {
                    number1 = plant;
                    max = plant.Nutrient_Level;
                    Console.WriteLine("");
                }
            }

            return number1 != null ? number1.Name : "None of the plants survived";
        }



        public void programrun(string filename)
        {
            EcoPlantsData(filename);
            Radiation_form();
            string result = survivor();
            Console.WriteLine("Strongest Plant: " + result);

        }
    }
}




