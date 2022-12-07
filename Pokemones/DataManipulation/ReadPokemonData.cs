using Pokedex.Pokemones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Text;


namespace Pokedex.Pokemones.DataManipulation
{
    public class ReadPokemonData
    {
        SqlDataAdapter adapter;
        DataBaseConnection dbcn;
        DataSet Pokemons;
        Pokemon PokemonData = new Pokemon();
        //DataBaseConnection dbcc;
        public void ReadData(string SqlQuery) 
        {
            Pokemons = new DataSet();
            dbcn = new DataBaseConnection();
            dbcn.OpenConnection();
            adapter = new SqlDataAdapter(SqlQuery,dbcn.ConnectionString);
            adapter.Fill(Pokemons,"Pokemons");
            Console.WriteLine("Lista de Pokemones:");


        }
        public void DataFiller() 
        {
            foreach (DataRow pkmnRow in Pokemons.Tables["Pokemons"].Rows)
            {
                PokemonData.Id = Convert.ToInt32(pkmnRow["ID"]);
                PokemonData.Name = Convert.ToString(pkmnRow["Name"]);
                PokemonData.pkmnDescription = Convert.ToString(pkmnRow["Description"]);
                PokemonData.TypeId = new Types {Id = Convert.ToInt32(pkmnRow["TypeId"]) };
                PokemonData.SkillId = new Skills {Id= Convert.ToInt32(pkmnRow["SkillId"]) };
                PokemonData.pkmnMoves = new Moves[] 
                {
                    new Moves
                    {
                        ID =Convert.ToInt32(pkmnRow["MoveId"])
                    }
                };
                PokemonData.Darpresentacion();
            }
        }

        public void ShowData(int pokemonSeleccionado) 
        {

            foreach (DataRow pokemonRows in Pokemons.Tables["Pokemons"].Rows)
            {
                if (pokemonSeleccionado == Convert.ToInt16(pokemonRows["ID"]))
                {
                    Console.WriteLine(pokemonRows["ID"] + "--" + pokemonRows["Name"] + "--" + pokemonRows["Description"]);
                }
            }
        }
    }
}


//adapter = new SqlDataAdapter(sql, dbcn.ConnectionString);
//DataSet Pokemons = new DataSet();
//adapter.Fill(Pokemons, "Pokemons");
//Console.WriteLine("Lista de Pokemones:");
//Pokemon pkmInserted = new Pokemon();
//foreach (DataRow pokemonRows in Pokemons.Tables["Pokemons"].Rows)
//{
//    //pkmInserted = new Pokemon();
//    //Console.WriteLine(pokemonRows["ID"] + "--" + pokemonRows["Name"]);
//    pkmInserted.Id = Convert.ToInt32(pokemonRows["ID"]);
//    pkmInserted.Name = Convert.ToString(pokemonRows["Name"]);
//    pkmInserted.pkmnDescription = Convert.ToString(pokemonRows["Description"]);
//    pkmInserted.TypeId = new Types { Id = Convert.ToInt32(pokemonRows["TypeId"]) };
//    pkmInserted.SkillId = new Skills { Id = Convert.ToInt32(pokemonRows["SkillId"]) };
//    pkmInserted.pkmnMoves = new Moves[]
//    {
//                    new Moves {ID = Convert.ToInt32(pokemonRows["MoveId"])}
//    };
//    pkmInserted.Darpresentacion();
//    Console.ReadKey();
//};


//foreach (DataRow pokemonRows in Pokemons.Tables["Pokemons"].Rows)
//{
//    if (pokemonSeleccionado == Convert.ToInt16(pokemonRows["ID"]))
//    {
//        Console.WriteLine(pokemonRows["ID"] + "--" + pokemonRows["Name"] + "--" + pokemonRows["Description"]);
//    }
//}