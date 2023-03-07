using Pokedex.Pokemones.DataManipulation;
using System;
using System.Collections.Generic;
using System.Text;



namespace Pokedex.Pokemones
{
    public class userInterface
    {
        private int opcionPokedex;
        private DataBaseManipulaton opcion = new DataBaseManipulaton();
        public void Interface() 
        {
            Console.WriteLine("--------Pokedex--------");
            Console.WriteLine("Indique las opcion a Utilizar: ");
            Console.WriteLine("1.Buscar Pokemon 2.Crear Pokemon ");
            opcionPokedex = Convert.ToInt32(Console.ReadLine());
            if (opcionPokedex == 1)
            {
                opcion.ReadData();
            }
            else { }
        }
      
           
       
    }
}
