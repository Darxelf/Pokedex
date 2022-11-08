using System;
using System.Collections.Generic;
using Pokedex.Pokemones;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;

namespace Pokedex
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SQL Connection String Information*/
            string connectionString,insertString = "";
            connectionString = @"Server=DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
                                    Trusted_Connection = True";
            SqlConnection dbcn = new SqlConnection(connectionString);
            dbcn.Open();
            Console.WriteLine("Conectado Exitosamente!");
            dbcn.Close();
            /*SQL String End*/
            /*SQL Consult Data From DataBase*/
            SqlCommand insert;
            string insertPokemon = "";
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
            /*Pokemon Creation  Data*/
            Console.WriteLine("<---Creacion del Pokemon--->");
            Pokemon pkmInserted = new Pokemon();
            Console.WriteLine("Insert Pokemon Name");
            pkmInserted.Name = Console.ReadLine();
            Console.WriteLine("Insert Pokemon Description:");
            pkmInserted.pkmnDescription = Console.ReadLine();
            Console.WriteLine("Insert Pokemon Type:");
            pkmInserted.TypeId = new Types{Id = Convert.ToInt32(Console.ReadLine())};
            Console.WriteLine("Insert Pokemon Skill:");
            pkmInserted.SkillId = new Skills {Id = Convert.ToInt32(Console.ReadLine())};
            Console.WriteLine("Insert Pokemon Move: ");
            pkmInserted.pkmnMoves = new Moves[]
            { 
                new Moves{ID = Convert.ToInt32(Console.ReadLine())}
            };
            pkmInserted.Darpresentacion();
            /*End Creation  Data*/
            Console.WriteLine("Deseas Insertar los datos del pokemon en la Base de Datos?");
            Console.WriteLine("Si = 1 , No = 0");
             int options = Convert.ToInt32(Console.ReadLine());
            if (options == 1)
            {
                insertPokemon = $"INSERT INTO Pokemons({pkmInserted.Name},{pkmInserted.pkmnDescription},{pkmInserted.TypeId},{pkmInserted.SkillId},{pkmInserted.pkmnMoves[0]})" +
                $"\r\nVALUES ('Swampert','it is said to sing plaintively as it seeks what few others of its kind still remain. ',\r\n  (SELECT ID FROM Types WHERE ID ={pkmInserted.TypeId}),(SELECT ID FROM Skills WHERE ID = {pkmInserted.SkillId}),(SELECT ID FROM Moves WHERE ID = {pkmInserted.pkmnMoves[0]}))";
                /*Pokemon Data To Data Base*/
                insert = new SqlCommand(insertPokemon,dbcn);
                adapter.InsertCommand = new SqlCommand(insertPokemon,dbcn);
                adapter.InsertCommand.ExecuteNonQuery();
                
               /*End Of Data Transmission*/
            }
            else 
            {
                Console.WriteLine("Wrong Chosen Number!!");
                
            }
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
