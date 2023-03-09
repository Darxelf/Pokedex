using Pokedex.Pokemones.DataManipulation;
using System;
using System.Collections.Generic;
using System.Text;



namespace Pokedex.Pokemones
{
    public class UserInterface
    {
        private int opcionPokedex;
        private DataBaseManipulaton opcion = new DataBaseManipulaton();
        int pokemonSeleccionado = 0; 
        public void Interface() 
        {
            Console.WriteLine("--------Pokedex--------");
            Console.WriteLine("Indique las opcion a Utilizar: ");
            Console.WriteLine("1.Buscar Pokemon 2.Crear Pokemon ");
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
