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
        public SqlConnection Connection;

        public DataBaseManipulaton() 
        {
            Connection = new SqlConnection(ConnectionString);
        }

        public void OpenConnection()
        {
            Connection.Open();
            Console.WriteLine("Conexion Exitosa!");
        }

        public void CloseConnection() 
        {
            Connection.Close();
        }

    }
}
