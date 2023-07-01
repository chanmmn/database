using ConAppRandomState.Models;

namespace ConAppRandomState
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string state = "";
            Console.WriteLine("Hello, Start!");
            // Scaffold-DbContext "Server=localhost;Database=poc;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -t CountryState -f
            state = GetRandom();
            InsertDB(state);
            Console.WriteLine("Hello, End!");
        }

        public static string GetRandom()
        {
            Random random = new Random();
            List<string> list = new List<string> { "West Coast", "Wellington", "Lower Hutt", 
                "Masterton", "Porirua", "Upper Hutt", "Wellington", "Tasman", "Waikato" };
            int index = random.Next(list.Count);
            //Console.WriteLine(list[index]);
            return (list[index]);
        }

        public static void InsertDB(string state)
        {
            PocContext context = new PocContext();  
            CountryState country = new CountryState();
            country.StateName = state;
            context.Add(country);
            context.SaveChanges();
        }
    }
}