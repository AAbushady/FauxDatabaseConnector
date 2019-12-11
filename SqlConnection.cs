using System;
using System.ComponentModel;
using System.Runtime.Remoting.Channels;

namespace FauxDatabaseConnector
{
    public class SqlConnection : DbConnection
    {
        private readonly TimeSpan _timeOut = TimeSpan.FromSeconds(90);
        private readonly int _connectionTime = RandomTime.Next(92);

        public SqlConnection(string connection) 
            : base(connection)
        {
        }

        // In a real program the following methods would interact with a database.
        // However, this is just for demonstration purposes and will just output text
        // to the console.
        public override void Open()
        {
            // This will simulate when there is a time out on the database connection.
            if (Convert.ToInt32(_timeOut.TotalSeconds) < _connectionTime)
            {
                Console.WriteLine("We're sorry the connection timed out... \nPlease try again!");
            }
            else
            {
                Console.WriteLine("The SQL Database connection has been established!");
                OpenConnection = true;
            }
        }

        public override void Close()
        {
            if (OpenConnection == false)
            {
                throw new InvalidOperationException("You cannot close a database connection unless there is an existing open connection.");
            }
            Console.WriteLine("The SQL Database connection has been closed.");
        }
    }
}