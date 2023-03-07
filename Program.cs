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
            //string inputData = "";
            //string sql = "";
            int pokemonSeleccionado = 0;
            DataBaseManipulaton dbcn = new DataBaseManipulaton();
            ReadPokemonData read = new ReadPokemonData(); 
            //Pokemon PokemonData = new Pokemon ();
            DataBaseManipulaton pokemonInfo = new DataBaseManipulaton ();
            /*SQL String End*/
            /*SQL Consult Data From DataBase*/
            SqlDataAdapter adapter = new SqlDataAdapter();
            //dbcn.OpenConnection();
            //sql = "SELECT * FROM Pokemons";
            read.ReadData();
            //read.DataFiller();
            /*End DataBase Consult*/
            //dbcn.CloseConnection();//////////////this
            /*Pokemon Creation  Data*/
           // Validators Validate = new Validators();
            pokemonInfo.CreatePokemon();
            /*End Creation  Data*/
            /*Insert Pokemon Data*/
            pokemonInfo.InsertPokemon();
            /*End of Insert*/
            Console.WriteLine("Eligir el pokemon deseado: ");
            pokemonSeleccionado = Convert.ToInt32(Console.ReadLine());
            read.ShowData(pokemonSeleccionado);
            Console.ReadKey();
        }
    }
}
