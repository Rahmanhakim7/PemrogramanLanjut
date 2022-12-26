namespace Praktikum8
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using MySql.Data.MySqlClient;

    public class MYDB : DbContext
    {
        // Your context has been configured to use a 'MYDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Praktikum8.MYDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MYDB' 
        // connection string in the application configuration file.
        public MYDB()
            : base("name=MYDB")
        {
        }

        private MySqlConnection connection = new MySqlConnection(
            "server=localhost;port=3306;username=root;password=;database=library_4416");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public DataTable getData(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, getConnection());

            if (parameters!= null)
            {
                command.Parameters.AddRange(parameters);
            }

            DataTable table = new DataTable();  
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }  

        public int setData(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, getConnection());

            if (parameters!= null) 
            {
                command.Parameters.AddRange(parameters);
            }

            openConnection();

            int commandState = command.ExecuteNonQuery();

            closeConnection();

            return commandState;
        }



        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}