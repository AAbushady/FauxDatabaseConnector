using System;

namespace FauxDatabaseConnector
{
    public class DbCommand
    {
        public string Command { get; set; }
        public DbConnection Connection { get; set; }

        public DbCommand(DbConnection connection, string command)
        {
            if (string.IsNullOrWhiteSpace(command) || connection == null)
            {
                throw new NullReferenceException("A command must be sent to a valid database, and it must not be an empty string.");
            }

            Command = command;
            Connection = connection;
        }

        // Again because this is a simple demonstration of Polymorphism, no commands will actual be run, all that will happen
        // is text being displayed to the console.

        public void Execute()
        {
            Connection.Open();
            Console.WriteLine("Now running: {0} on the database...\nComplete!", Command);
            Connection.Close();
        }
    }
}