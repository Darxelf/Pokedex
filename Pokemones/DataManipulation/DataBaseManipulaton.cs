using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pokedex.Pokemones.DataManipulation
{
    public class DataBaseManipulaton
    {
        private string ConnectionString = @"Server=DESKTOP-CCJ8U8S\MSSQLSERVER02;Database=Pokedex;
                                    Trusted_Connection = True";
        public SqlConnection Connection;
        Pokemon pokemonData = new Pokemon();
        Validators validate = new Validators();
        //DataBaseManipulaton dbcn = new DataBaseManipulaton();
        SqlCommand insert;
        string insertPokemon = "";
        string pokemonInfo = "";
        private string sqlString = "SELECT * FROM Pokemons";
        SqlDataAdapter adapter;
        //DataBaseManipulaton dbcn = new DataBaseManipulaton();
        //SqlConnection dbcn = new SqlConnection();
        DataSet pokemons = new DataSet();
        //Pokemon pokemonData = new Pokemon();
        public DataBaseManipulaton() 
        {
            Connection = new SqlConnection(ConnectionString);
            
        }

        //public void OpenConnection()
        //{
        //    Connection.Open();
        //    Console.WriteLine("Conexion Exitosa!");
        //}

        //public void CloseConnection()
        //{
        //    Connection.Close();
        //}

        public void CreatePokemon()
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
            pokemonData.Type = new Types { Id = Convert.ToInt32(pokemonInfo) };
            Console.WriteLine("Insert Pokemon Skill:");
            pokemonInfo = Console.ReadLine();
            validate.NumberValidation(pokemonInfo);
            pokemonData.Skill = new Skills { Id = Convert.ToInt32(pokemonInfo) };
            Console.WriteLine("Insert Pokemon Move: ");
            pokemonInfo = Console.ReadLine();
            validate.NumberValidation(pokemonInfo);
            pokemonData.Moves = new Moves[]
            {
                new Moves{Id = Convert.ToInt32(pokemonInfo[0])}
            };
            pokemonData.Darpresentacion();
        }
        public void InsertPokemon()
        {
            Console.WriteLine("Deseas Insertar los datos del pokemon en la Base de Datos?");
            Console.WriteLine("Si = 1 , No = 0");
            int options = Convert.ToInt32(Console.ReadLine());
            if (options == 1)
            {
                Connection.Open();
                //dbcn.OpenConnection();
                insertPokemon = $" INSERT INTO Pokemons ([Name],[Description],[TypeId],[SkillId],[MoveId])" +
                $" VALUES ('{pokemonData.Name}','{pokemonData.Description}', {pokemonData.Type.Id},{pokemonData.Skill.Id}, {pokemonData.Moves[0].Id})";
                /*Pokemon Data To Data Base*/
                insert = new SqlCommand(insertPokemon, Connection);
                insert.ExecuteNonQuery();
                /*End Of Data Transmission*/
                Connection.Close();
               //dbcn.CloseConnection();
            }
            else
            {
                Console.WriteLine("Wrong Chosen Number!!");
            }
        }


        //DataBaseConnection dbcc;
        public void ReadData()
        {
            //dbcn.OpenConnection();
            adapter = new SqlDataAdapter(sqlString,Connection);
            adapter.Fill(pokemons, "Pokemons");
            Console.WriteLine("Lista de Pokemones:");
            foreach (DataRow pokemonRow in pokemons.Tables["Pokemons"].Rows)
            {
                pokemonData.Id = Convert.ToInt32(pokemonRow["ID"]);
                pokemonData.Name = Convert.ToString(pokemonRow["Name"]);
                pokemonData.Description = Convert.ToString(pokemonRow["Description"]);
                pokemonData.Type = new Types { Id = Convert.ToInt32(pokemonRow["TypeId"]) };
                pokemonData.Skill = new Skills { Id = Convert.ToInt32(pokemonRow["SkillId"]) };
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
