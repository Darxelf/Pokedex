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
        Pokemon PokemonData = new Pokemon();
        Validators Validate = new Validators();
        DataBaseConnection dbcn = new DataBaseConnection();
        SqlCommand insert;
        string insertPokemon = "";
        public void CreatePokemon(string pokemonInfo) 
        {
            Console.WriteLine("<---Creacion del Pokemon--->");
            Console.WriteLine("Insert Pokemon Name");
            pokemonInfo = Console.ReadLine();
            Validate.TextValidation(pokemonInfo);
            PokemonData.Name = pokemonInfo;
            Console.WriteLine("Insert Pokemon Description:");
            pokemonInfo = Console.ReadLine();
            Validate.TextValidation(pokemonInfo);
            PokemonData.pkmnDescription = pokemonInfo;
            Console.WriteLine("Insert Pokemon Type:");
            pokemonInfo = Console.ReadLine();
            Validate.NumberValidation(pokemonInfo);
            PokemonData.TypeId = new Types { Id = Convert.ToInt32(pokemonInfo)};
            Console.WriteLine("Insert Pokemon Skill:");
            pokemonInfo = Console.ReadLine();
            Validate.NumberValidation(pokemonInfo);
            PokemonData.SkillId = new Skills { Id = Convert.ToInt32(pokemonInfo)};
            Console.WriteLine("Insert Pokemon Move: ");
            pokemonInfo = Console.ReadLine();
            Validate.NumberValidation(pokemonInfo);
            PokemonData.pkmnMoves = new Moves[]
            {
                new Moves{ID = Convert.ToInt32(pokemonInfo[0])}
            };
            PokemonData.Darpresentacion();
        }
        public void InsertPokemon( ) 
        {
            Console.WriteLine("Deseas Insertar los datos del pokemon en la Base de Datos?");
            Console.WriteLine("Si = 1 , No = 0");
            int options = Convert.ToInt32(Console.ReadLine());
            if (options == 1)
            {
                dbcn.OpenConnection();
                insertPokemon = $" INSERT INTO Pokemons ([Name],[Description],[TypeId],[SkillId],[MoveId])" +
                $" VALUES ('{PokemonData.Name}','{PokemonData.pkmnDescription}', {PokemonData.TypeId.Id},{PokemonData.SkillId.Id}, {PokemonData.pkmnMoves[0].ID})";
                /*Pokemon Data To Data Base*/
                insert = new SqlCommand(insertPokemon, dbcn.connection);
                insert.ExecuteNonQuery();
                /*End Of Data Transmission*/
                dbcn.CloseConnection();
            }
            else
            {
                Console.WriteLine("Wrong Chosen Number!!");
            }
        }
    }
}
