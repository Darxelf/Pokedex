using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones.DataManipulation
{
    public class DataBaseManipulaton
    {
        private string ConnectionString = @"Server=DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
                                    Trusted_Connection = True";
        private SqlConnection Connection;

        public string ConnectionInformation()
        {
            return ConnectionString;
        }
       public  void OpenConnection ()
        {
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
