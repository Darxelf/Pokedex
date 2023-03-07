using System.Data.SqlClient;
using Pokedex.Pokemones;
using Pokedex.Pokemones.DataManipulation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pokedex.Pokemones.Data_Manipulation
{
    public class InsertPokemonData
    {
        Pokemon pokemonData = new Pokemon();
        Validators validate = new Validators();
        DataBaseManipulaton dbcn = new DataBaseManipulaton();
        SqlCommand insert;
        string insertPokemon = "";
        public void CreatePokemon(string pokemonInfo) 
        {
            Console.WriteLine("<---Creacion del Pokemon--->");
            Console.WriteLine("Insert Pokemon Name");
            pokemonInfo = Console.ReadLine();
            validate.TextValidation(pokemonInfo);
            pokemonData.Name = pokemonInfo;
            Console.WriteLine("Insert Pokemon Description:");
            pokemonInfo = Console.ReadLine();
            validate.TextValidation(pokemonInfo);
            pokemonData.Description = pokemonInfo;
            Console.WriteLine("Insert Pokemon Type:");
            pokemonInfo = Console.ReadLine();
            validate.NumberValidation(pokemonInfo);
            pokemonData.Type = new Types { Id = Convert.ToInt32(pokemonInfo)};
            Console.WriteLine("Insert Pokemon Skill:");
            pokemonInfo = Console.ReadLine();
            validate.NumberValidation(pokemonInfo);
            pokemonData.Skill = new Skills { Id = Convert.ToInt32(pokemonInfo)};
            Console.WriteLine("Insert Pokemon Move: ");
            pokemonInfo = Console.ReadLine();
            validate.NumberValidation(pokemonInfo);
            pokemonData.Moves = new Moves[]
            {
                new Moves{Id = Convert.ToInt32(pokemonInfo[0])}
            };
            pokemonData.Darpresentacion();
        }
        public void InsertPokemon( ) 
        {
            Console.WriteLine("Deseas Insertar los datos del pokemon en la Base de Datos?");
            Console.WriteLine("Si = 1 , No = 0");
            int options = Convert.ToInt32(Console.ReadLine());
            if (options == 1)
            {
                //dbcn.OpenConnection();
                insertPokemon = $" INSERT INTO Pokemons ([Name],[Description],[TypeId],[SkillId],[MoveId])" +
                $" VALUES ('{pokemonData.Name}','{pokemonData.Description}', {pokemonData.Type.Id},{pokemonData.Skill.Id}, {pokemonData.Moves[0].Id})";
                /*Pokemon Data To Data Base*/
                insert = new SqlCommand(insertPokemon,dbcn.Connection);
                insert.ExecuteNonQuery();
                /*End Of Data Transmission*/
                //    dbcn.CloseConnection();
            }
            else
            {
                Console.WriteLine("Wrong Chosen Number!!");
            }
        }
    }
}
