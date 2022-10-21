using System;
using System.Collections.Generic;
using Pokedex.Pokemones;
using System.Data.SqlClient;
using System.Data;

namespace Pokedex
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SQL Connection String Information*/
            string connectionString = "";
            SqlConnection dbcn;
            connectionString = @"Server =DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
                                    Trusted_Connection = True";
            dbcn = new SqlConnection(connectionString);
            dbcn.Open();
            Console.WriteLine("Conectado Exitosamente!");
            dbcn.Close();
            /*SQL String End*/
            /*SQL Inserting Data*/
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader reader;
            string sql, output = "";
            //string Insert = "";
            //dbcn.Open();
            ////Insert = "Insert into Pokedex (Id,Name,Description)," +
            ////    "Values('Keen Eye','Pidgeots Accuracy cannot be Lowered by Opponent ')";
            ////command = new SqlCommand(Insert,dbcn);
            ////adapter.InsertCommand = new SqlCommand(Insert, dbcn);
            ////adapter.InsertCommand.ExecuteNonQuery();

            //command.Dispose();
            dbcn.Open();
            sql = "SELECT ID,Name,Description FROM Pokemons";
            command = new SqlCommand(sql, dbcn);
            reader = command.ExecuteReader();
            //output = reader.GetValue(0) + "--" + reader.GetValue(1)
            //+ "--" + reader.GetValue(2);
            //Console.WriteLine(output);
            //dbcn.Close();
            /**SQL End Insert*/

            Console.WriteLine("Lista de Pokemones:");

            while (reader.Read())
            {
                Console.WriteLine
                (
                    output = reader.GetValue(0) + "--" + reader.GetValue(1)
                 ); ;
            };
            dbcn.Close();

            Console.WriteLine("Eligir el pokemon deseado: ");
            int pokemonSeleccionado = Convert.ToInt32(Console.ReadLine());
            dbcn.Open();
            reader = command.ExecuteReader();
          
            if ()
            {
                
            };
            dbcn.Close();

            Console.ReadKey();
        }
    }
}
