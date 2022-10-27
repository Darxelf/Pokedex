using System;
using System.Collections.Generic;
using Pokedex.Pokemones;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;

namespace Pokedex
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SQL Connection String Information*/
            string connectionString = "";
            connectionString = @"Server =DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
                                    Trusted_Connection = True";
            SqlConnection dbcn = new SqlConnection(connectionString);
            dbcn.Open();
            Console.WriteLine("Conectado Exitosamente!");
            dbcn.Close();
            /*SQL String End*/
            /*SQL Inserting Data*/
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader reader;
            string sql, output = "";
            dbcn.Open();
            sql = "SELECT ID,Name,Description FROM Pokemons"+"SELECT";
            adapter = new SqlDataAdapter(sql,dbcn);
            DataSet Pokemons = new DataSet();
            adapter.Fill(Pokemons,"Pokemons");
            Console.WriteLine("Lista de Pokemones:");
            foreach (DataRow pokemonRows in Pokemons.Tables["Pokemons"].Rows)
            {
                Console.WriteLine(pokemonRows["ID"] + "--" + pokemonRows["Name"]);
            };

            Console.WriteLine("Eligir el pokemon deseado: ");
            int pokemonSeleccionado = Convert.ToInt32(Console.ReadLine());
            //DataRow seleccionado = Pokemons.Tables["Pokemons"].Rows.Contains(pokemonSeleccionado);
            //dbcn.Open();
            //reader = command.ExecuteReader();
            foreach  (DataRow pokemonRows in Pokemons.Tables["Pokemons"].Rows)
            {
                if (pokemonSeleccionado == Convert.ToInt16(pokemonRows["ID"]))
                {
                    Console.WriteLine(pokemonRows["ID"]+"--"+pokemonRows["Name"]+"--"+pokemonRows["Description"]);
                }
            }

            //dbcn.Close();

            Console.ReadKey();
        }
    }
}
