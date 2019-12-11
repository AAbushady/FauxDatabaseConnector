using System;

namespace FauxDatabaseConnector
{
    public class OracleConnection : DbConnection
    {
        private readonly TimeSpan _timeOut = TimeSpan.FromSeconds(60);
        private readonly int _connectionTime = RandomTime.Next(62);

        public OracleConnection(string connection) : base(connection)
        {
        }

        // In a real program the following methods would interact with a database.
        // However, this is just for demonstration purposes and will just output text
        // to the console.

        public override void Open()
        {
            // This will simulate when there is a timeout on the database connection.
            if (Convert.ToInt32(_timeOut.TotalSeconds) < _connectionTime)
            {
                Console.WriteLine("We're sorry the connection timed out... \nPlease try again!");
            }
            else
            {
                Console.WriteLine("The Oracle Database connection has been established!");
            }
        }

        public override void Close()
        {
            Console.WriteLine("The Oracle Database connection has been closed.");
        }
    }
}