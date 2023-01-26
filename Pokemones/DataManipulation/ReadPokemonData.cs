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
        private string sqlString = "SELECT * FROM Pokemons";
        SqlDataAdapter adapter;
        DataBaseManipulaton dbcn = new DataBaseManipulaton();
        DataSet pokemons = new DataSet();
        Pokemon pokemonData = new Pokemon();
        
        //DataBaseConnection dbcc;
        public void ReadData() 
        {
            dbcn.OpenConnection();
            adapter = new SqlDataAdapter(sqlString,dbcn.ConnectionInformation());
            adapter.Fill(pokemons,"Pokemons");
            Console.WriteLine("Lista de Pokemones:");
        }
        public void DataFiller() 
        {
            foreach (DataRow pokemonRow in pokemons.Tables["Pokemons"].Rows)
            {
                pokemonData.Id = Convert.ToInt32(pokemonRow["ID"]);
                pokemonData.Name = Convert.ToString(pokemonRow["Name"]);
                pokemonData.Description = Convert.ToString(pokemonRow["Description"]);
                pokemonData.Type = new Types {Id = Convert.ToInt32(pokemonRow["TypeId"]) };
                pokemonData.Skill = new Skills {Id= Convert.ToInt32(pokemonRow["SkillId"]) };
                pokemonData.Moves = new Moves[] 
                {
                    new Moves
                    {
                        Id =Convert.ToInt32(pokemonRow["MoveId"])
                    }
                };
                pokemonData.Darpresentacion();
            }
        }

        public void ShowData(int pokemonSeleccionado) 
        {

            foreach (DataRow pokemonRows in pokemons.Tables["Pokemons"].Rows)
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