using System;

namespace FauxDatabaseConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Faux Database Connector!");

            Console.WriteLine("What type of database are you trying to connect to?");
            Console.Write("Please enter SQL, or Oracle: ");
            var input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "sql":
                    Console.Write("Please enter a connection string: ");
                    input = Console.ReadLine();
                    var sqlConnection = new SqlConnection(input);
                    Console.WriteLine("Now enter a command for the SQL Database.");
                    input = Console.ReadLine();
                    var sqlCommand = new DbCommand(sqlConnection, input);
                    sqlCommand.Execute();
                    break;
                case "oracle":
                    Console.Write("Please enter a connection string: ");
                    input = Console.ReadLine();
                    var oracleConnection = new OracleConnection(input);
                    Console.WriteLine("Now enter a command for the Oracle Database.");
                    input = Console.ReadLine();
                    var oracleCommand = new DbCommand(oracleConnection, input);
                    oracleCommand.Execute();
                    break;
                default:
                    throw new InvalidOperationException("That was not a valid database type!");
            }

            Console.WriteLine("Thank you for using the Faux Database Connector.");
        }
    }
}
