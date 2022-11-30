using System;
using System.Collections.Generic;
using Pokedex.Pokemones;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Pokedex
{
    class Program
    {
        static void Main(string[] args)
        {
            /*SQL Connection String Information*/
         
            string keyBoardData = "";
            string connectionString  = @"Server=DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
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
                 //pkmInserted = new Pokemon();
                //Console.WriteLine(pokemonRows["ID"] + "--" + pokemonRows["Name"]);
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
                Console.ReadKey();
            };
            /*End DataBase Consult*/
            dbcn.Close();
            /*Pokemon Creation  Data*/
            Validators Validate = new Validators();
            Console.WriteLine("<---Creacion del Pokemon--->");
            Console.WriteLine("Insert Pokemon Name");
            keyBoardData = Console.ReadLine();
            Validate.TextValidation(keyBoardData);
            pkmInserted.Name = keyBoardData;
            Console.WriteLine("Insert Pokemon Description:");
            keyBoardData = Console.ReadLine();
            Validate.TextValidation(keyBoardData);
            pkmInserted.pkmnDescription = keyBoardData;
            Console.WriteLine("Insert Pokemon Type:");
            keyBoardData = Console.ReadLine();
            Validate.NumberValidation(keyBoardData);
            pkmInserted.TypeId = new Types{Id = Convert.ToInt32(keyBoardData)};
            Console.WriteLine("Insert Pokemon Skill:");
            keyBoardData = Console.ReadLine();
            Validate.NumberValidation(keyBoardData);
            pkmInserted.SkillId = new Skills {Id = Convert.ToInt32(keyBoardData)};
            Console.WriteLine("Insert Pokemon Move: ");
            keyBoardData = Console.ReadLine();
            Validate.NumberValidation(keyBoardData);
            pkmInserted.pkmnMoves = new Moves[]
            { 
                new Moves{ID = Convert.ToInt32(keyBoardData)}
            };
            //pkmInserted.NumberValidation(Convert.ToString(pkmInserted.pkmnMoves[0]));
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
