namespace SpartanProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("competition constructor check: ");
                List<Category> cath = new();
                Competition comp = new(2009, "salgo", cath);
                Console.WriteLine("WRONG");
            }
            catch (Exception)
            {
                Console.WriteLine("OK - zero categories");
            }
            try
            {
                Console.Write("competition constructor check: ");
                List<Category> cath = new();
                cath.Add(Sprint.Instance());
                Competition competition = new(1999, "salgo", cath);
                Console.WriteLine("WRONG");
            }
            catch (Exception)
            {
                Console.WriteLine("OK - too small year");
            }
            try
            {
                Console.Write("competition score check: ");
                List<Category> cath = new();
                cath.Add(Sprint.Instance());
                Competition comp = new(2009, "salgo", cath);
                comp.Score(1, 1, 1, Super.Instance());
                Console.WriteLine("WRONG");
            }
            catch (Exception)
            {
                Console.WriteLine("OK - nonexisting category");
            }
            try
            {
                Console.Write("competition score check: ");
                List<Category> cath = new();
                cath.Add(Sprint.Instance());
                Competition comp = new(2009, "salgo", cath);
                comp.Score(1, 1, 1, Sprint.Instance());
                comp.Score(1, 2, 1, Sprint.Instance());
                Console.WriteLine("WRONG");
            }
            catch (Exception)
            {
                Console.WriteLine("OK - existing score");
            }
            try
            {
                Console.Write("result constructor check: ");
                Result res = new(-2, 2, 1, null);
                Console.WriteLine("WRONG");
            }
            catch (Exception)
            {
                Console.WriteLine("OK - negative min");
            }
            try
            {
                Console.Write("result constructor check: ");
                Result res = new(2, -2, 1, null);
                Console.WriteLine("WRONG");
            }
            catch (Exception)
            {
                Console.WriteLine("OK - negative sec");
            }
            try
            {
                Console.Write("result constructor check: ");
                Result res = new(2, 60, 1, null);
                Console.WriteLine("WRONG");
            }
            catch (Exception)
            {
                Console.WriteLine("OK - too big sec");
            }
            List<Category> cath2 = new();
            cath2.Add(Sprint.Instance());
            cath2.Add(Super.Instance());
            Competition comp2 = new(2001, "Salgotarjan", cath2);
            Console.WriteLine("Popular empty: " + (comp2.PopularCat().Type() == "sprint" ? "OK" : "WRONG"));

            bool l;
            int winner = 0;

            (l, winner) = comp2.Winner(Sprint.Instance());
            Console.WriteLine("Winner empty: " + (l ? "WRONG" : "OK"));


            comp2.Score(10, 8, 4, Super.Instance());
            comp2.Score(10, 8, 4, Sprint.Instance());
            (l, winner) = comp2.Winner(Sprint.Instance());
            Console.WriteLine("Winner 4: " + ((l && winner == 4) ? "OK" : "WRONG"));

            comp2.Score(10, 10, 1, Sprint.Instance());
            comp2.Score(20, 10, 1, Super.Instance());
            Console.WriteLine("Popular sprint: " + (comp2.PopularCat().Type() == "sprint" ? "OK" : "WRONG"));
            (l, winner) = comp2.Winner(Sprint.Instance());
            Console.WriteLine("Winner 1: " + ((l && winner == 4) ? "OK" : "WRONG"));

            comp2.Score(10, 7, 2, Super.Instance());
            Console.WriteLine("Popular super: " + (comp2.PopularCat().Type() == "super" ? "OK" : "WRONG"));
            (l, winner) = comp2.Winner(Super.Instance());
            Console.WriteLine("Winner 2: " + ((l && winner == 2) ? "OK" : "WRONG"));
        }
    }
}
