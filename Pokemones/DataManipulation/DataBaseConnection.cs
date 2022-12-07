using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones.DataManipulation
{
   public  class DataBaseConnection
    {  
        public  string ConnectionString;
       public SqlConnection connection;   
     public  void OpenConnection ()
        {
            ConnectionString = @"Server=DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
                                    Trusted_Connection = True";

            connection = new SqlConnection(ConnectionString);
            connection.Open();
            Console.WriteLine("Conexion Exitosa!");
            
        }

        public void CloseConnection() 
        {
            connection.Close();
        }

    }
}
