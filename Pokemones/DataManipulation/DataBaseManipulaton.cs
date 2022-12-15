using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones.DataManipulation
{
   public  class DataBaseManipulaton
    {  
        public  string ConnectionString;
       public SqlConnection Connection;   
     public  void OpenConnection ()
        {
            ConnectionString = @"Server=DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
                                    Trusted_Connection = True";

            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            Console.WriteLine("Conexion Exitosa!");
            
        }

        public void CloseConnection() 
        {
            Connection.Close();
        }

    }
}
