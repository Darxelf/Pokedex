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
using Pokedex.Pokemones.DataManipulation;
using Pokedex.Pokemones.Data_Manipulation;

namespace Pokedex
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyBoardData = "";
            DataBaseConnection dbcn = new DataBaseConnection();
            ReadPokemonData read = new ReadPokemonData(); 
            Pokemon PokemonData = new Pokemon ();
            InsertPokemonData pokemonInfo = new InsertPokemonData ();
            /*SQL String End*/
            /*SQL Consult Data From DataBase*/
            //SqlCommand insert;
            //string insertPokemon = "";
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql= "";
           dbcn.OpenConnection();
            sql = "SELECT * FROM Pokemons";
            read.ReadData(sql);
            read.DataFiller();
            /*End DataBase Consult*/
            dbcn.CloseConnection();
            /*Pokemon Creation  Data*/
            Validators Validate = new Validators();
            pokemonInfo.CreatePokemon(keyBoardData);
            /*End Creation  Data*/
            /*Insert Pokemon Data*/
            pokemonInfo.InsertPokemon();
            /*End of Insert*/
            Console.WriteLine("Eligir el pokemon deseado: ");
            int pokemonSeleccionado = Convert.ToInt32(Console.ReadLine());
            read.ShowData(pokemonSeleccionado);
            Console.ReadKey();




        }
      

    }
}
