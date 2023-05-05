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
        Skills skillData = new Skills();    
        Validators validate = new Validators();
        SqlCommand insert;
        SqlCommand select;
        SqlDataAdapter pokemonAdapter;
        SqlDataAdapter skillAdapter;
        SqlDataAdapter typesAdapter;
        DataSet pokemons = new DataSet();
        string insertPokemon = "";
        string pokemonInfo = "";
        private string selectPokemon = "SELECT * FROM POKEMONLIST";//query to a View
        private string selectSkills ="SELECT * FROM Skills";
        private string selectTypes = "SELECT *FROM Types";


        public DataBaseManipulaton() 
        {
            Connection = new SqlConnection(ConnectionString);
            
        }

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
                Console.WriteLine("Wrong Chosen Number!");
                Environment.Exit(0);    
            }
        }

        public void ReadData()
        {

            dataFiller();
            Console.WriteLine("Lista de Pokemones:");
            foreach (DataRow pokemonRow in pokemons.Tables["Pokemons"].Rows)
            {
               
                    pokemonData.Darpresentacion
                        (
                            Convert.ToInt32(pokemonRow["ID"])
                            , Convert.ToString(pokemonRow["Pokemon"])
                            , Convert.ToString(pokemonRow["Type"])
                            , Convert.ToString(pokemonRow["Skill"])
                        );
            }
        }
        public void ShowData(int pokemonSeleccionado)
        {

            foreach (DataRow pokemonRow in pokemons.Tables["Pokemons"].Rows)
            {
                if (pokemonSeleccionado == Convert.ToInt16(pokemonRow["ID"]))
                {

                        pokemonData.Darpresentacion
                      (
                          Convert.ToInt32(pokemonRow["ID"])
                          , Convert.ToString(pokemonRow["Pokemon"])
                          , Convert.ToString(pokemonRow["Type"])
                          , Convert.ToString(pokemonRow["Skill"])
                          , Convert.ToString(pokemonRow["Description"])
                      );
                        break;
                }

            }
        }
        public void dataFiller() 
        {
            Connection.Open();
            select = new SqlCommand(selectPokemon, Connection);
            select.ExecuteNonQuery();
           
            pokemonAdapter = new SqlDataAdapter(select);//al select tener el parametro del procedimiento y conexion se usa la variable y ya
            pokemonAdapter.Fill(pokemons, "Pokemons");
            Connection.Close();


        }

    }
}
