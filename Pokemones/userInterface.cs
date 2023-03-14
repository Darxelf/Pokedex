using Pokedex.Pokemones.DataManipulation;
using System;
using System.Collections.Generic;
using System.Text;



namespace Pokedex.Pokemones
{
    public class UserInterface:DataBaseManipulaton
    {
        private int opcionPokedex;
        private DataBaseManipulaton opcion = new DataBaseManipulaton();
        //UserInterface opcion = new UserInterface();
        int pokemonSeleccionado = 0; 
        public void Interface() 
        {
            Console.WriteLine("--------Bienvenido al Pokedex Pokemon--------");
            Console.WriteLine("Indique las opcion a Utilizar: ");
            Console.WriteLine("1.Lista Pokemon 2.Crear Pokemon ");
            opcionPokedex = Convert.ToInt32(Console.ReadLine());
            if (opcionPokedex == 1)
            {
                opcion.ReadData();
                Console.WriteLine("Cual Pokemon deseas Elegir? ");
                pokemonSeleccionado = Convert.ToInt32(Console.ReadLine());
                opcion.ShowData(pokemonSeleccionado);
                Console.ReadKey();
            }
            else 
            {
                opcion.CreatePokemon();
                opcion.InsertPokemon();
            }
        }
      
           
       
    }
}
