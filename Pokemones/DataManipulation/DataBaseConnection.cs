using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones.DataManipulation
{
    public class DataBaseConnection
    {
      string dataString = @"Server=DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;Trusted_Connection = True";
        SqlConnection connection = new SqlConnection();
       
        //public void OpenDataBaseConnection() 
        //{

        //} 

    }
}
