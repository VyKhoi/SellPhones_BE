using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SellPhones.Data.EF;
using System.Text;

namespace SellPhones.Build
{
    public class Program
    {
        public static IConfigurationRoot Configuration;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                // Set up configuration sources.
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                    .AddJsonFile("appsettings.json", optional: true);

                Configuration = builder.Build();

                Console.WriteLine("Path: {0}", Path.Combine(AppContext.BaseDirectory));

                string connectionString = Configuration.GetConnectionString("MyDB");
                Console.WriteLine("Connection String: {0}", connectionString);

                var optionsBuilder = new DbContextOptionsBuilder<SellPhonesContext>();
                if (!string.IsNullOrEmpty(connectionString))
                    optionsBuilder.UseNpgsql(connectionString);

                using (var context = new BuildDbContext(optionsBuilder.Options))
                {
                    //context.EnsureSeedDataForContext();
                }
            }
            catch (Exception? ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");

                if (ex.InnerException != null)
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");

                throw;
            }

            Console.WriteLine("Data Migration Done!");
        }
    }
}