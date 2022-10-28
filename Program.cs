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
            connectionString = @"Server=DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
                                    Trusted_Connection = True";
            SqlConnection dbcn = new SqlConnection(connectionString);
            dbcn.Open();
            Console.WriteLine("Conectado Exitosamente!");
            dbcn.Close();
            /*SQL String End*/
            /*SQL Consult Data From DataBase*/
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader reader;
            string sql= "";
            dbcn.Open();
            sql = "SELECT ID,Name,Description FROM Pokemons";
            adapter = new SqlDataAdapter(sql,dbcn);
            DataSet Pokemons = new DataSet();
            adapter.Fill(Pokemons,"Pokemons");
            Console.WriteLine("Lista de Pokemones:");
            foreach (DataRow pokemonRows in Pokemons.Tables["Pokemons"].Rows)
            {
                Console.WriteLine(pokemonRows["ID"] + "--" + pokemonRows["Name"]);
            };
            /*End DataBase Consult*/
            /*Pokemon Inserted Data*/
            Console.WriteLine("<---Creacion del Pokemon--->");
            Pokemon pkmInserted = new Pokemon();
            Console.WriteLine("Insert Pokemon Name");
            pkmInserted.Name = Console.ReadLine();
            Console.WriteLine("Insert Pokemon Description:");
            pkmInserted.pkmnDescription = Console.ReadLine();
            Console.WriteLine("Insert Pokemon Type:");
            pkmInserted.TypeId.Id = Convert.ToInt32(new Types());
            Console.WriteLine("Insert Pokemon Skill:");
            pkmInserted.SkillId.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Pokemon Move: ");
            pkmInserted.pkmnMoves = new Moves[]
            { 
                new Moves{ID = Convert.ToInt32(Console.ReadLine())}
            };
            pkmInserted.Darpresentacion();
            /*End Insert Data*/
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
