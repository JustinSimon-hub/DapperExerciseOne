using System.Data;
using Exercise1Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace Exercise1Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperDepartmentRepository(conn);
           

            Console.WriteLine("Type in a new department name");

           string newDepartmentName = Console.ReadLine();
            repo.InsertDepartment(newDepartmentName);

            var departments = repo.GetAllDepartments();
            foreach ( var i in departments)
            {
                Console.WriteLine($"{i.Name}");
            }

        }
    }
}

