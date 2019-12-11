using System;

namespace FauxDatabaseConnector
{
    public abstract class DbConnection
    {
        private readonly string _connection;
        public static Random RandomTime = new Random();
        private protected bool OpenConnection;


        protected DbConnection(string connection)
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                throw new ArgumentNullException(nameof(connection), 
                    "A connection string cannot be null or whitespace. " +
                    "Please try again with a valid connection string.");
            }
            _connection = connection;
        }

        // The open and close methods are abstract because they would be implemented differently
        // based on which type of database is being used.
        public abstract void Open();
        public abstract void Close();
    }
}