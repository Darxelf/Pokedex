using System;
using System.Collections.Generic;
using Pokedex.Pokemones;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

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
            sql = "SELECT * FROM Pokemons";
            adapter = new SqlDataAdapter(sql,dbcn);
            DataSet Pokemons = new DataSet();
            adapter.Fill(Pokemons,"Pokemons");
            Console.WriteLine("Lista de Pokemones:");
            Pokemon pkmInserted = new Pokemon();
            foreach (DataRow pokemonRows in Pokemons.Tables["Pokemons"].Rows)
            {
                 pkmInserted = new Pokemon();
                Console.WriteLine(pokemonRows["ID"] + "--" + pokemonRows["Name"]);
                pkmInserted.Id = Convert.ToInt32(pokemonRows["ID"]);    
                pkmInserted.Name = Convert.ToString(pokemonRows["Name"]);
                pkmInserted.pkmnDescription = Convert.ToString(pokemonRows["Description"]);
                pkmInserted.TypeId = new Types { Id = Convert.ToInt32(pokemonRows["TypeId"])};
                pkmInserted.SkillId = new Skills {Id= Convert.ToInt32(pokemonRows["SkillId"]) };
                pkmInserted.pkmnMoves  = new Moves[]
                { 
                    new Moves {ID = Convert.ToInt32(pokemonRows["MoveId"])} 
                };
                pkmInserted.Darpresentacion();
                Console.WriteLine("TEST!");
                Console.ReadKey();
            };
            /*End DataBase Consult*/
            dbcn.Close();
            /*Pokemon Creation  Data*/
            Console.WriteLine("<---Creacion del Pokemon--->");
            Console.WriteLine("Insert Pokemon Name");
            pkmInserted.Name = Console.ReadLine();
            pkmInserted.TextValidation(pkmInserted.Name);
            Console.WriteLine("Insert Pokemon Description:");
            pkmInserted.pkmnDescription = Console.ReadLine();
            pkmInserted.TextValidation(pkmInserted.pkmnDescription);
            Console.WriteLine("Insert Pokemon Type:");
            pkmInserted.TypeId = new Types{Id = Convert.ToInt32(Console.ReadLine())};
            pkmInserted.NumberValidation(Convert.ToString(pkmInserted.TypeId.Id));
            Console.WriteLine("Insert Pokemon Skill:");
            pkmInserted.SkillId = new Skills {Id = Convert.ToInt32(Console.ReadLine())};
            pkmInserted.NumberValidation(Convert.ToString(pkmInserted.SkillId.Id));
            Console.WriteLine("Insert Pokemon Move: ");
            pkmInserted.pkmnMoves = new Moves[]
            { 
                new Moves{ID = Convert.ToInt32(Console.ReadLine())}
            };
            pkmInserted.NumberValidation(Convert.ToString(pkmInserted.pkmnMoves[0]));
            pkmInserted.Darpresentacion();
            /*End Creation  Data*/
            Console.WriteLine("Deseas Insertar los datos del pokemon en la Base de Datos?");
            Console.WriteLine("Si = 1 , No = 0");
            int options = Convert.ToInt32(Console.ReadLine());
            if (options == 1)
            {
                dbcn.Open();
                insertPokemon = $" INSERT INTO Pokemons ([Name],[Description],[TypeId],[SkillId],[MoveId])" +
                $" VALUES ('{pkmInserted.Name}','{pkmInserted.pkmnDescription}', {pkmInserted.TypeId.Id},{pkmInserted.SkillId.Id}, {pkmInserted.pkmnMoves[0].ID})";
                /*Pokemon Data To Data Base*/
                insert = new SqlCommand(insertPokemon,dbcn);
                insert.ExecuteNonQuery();
                /*End Of Data Transmission*/
                dbcn.Close();
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
