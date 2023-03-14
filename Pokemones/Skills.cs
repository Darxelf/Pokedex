using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones
{
    public class Skills:Pokemon
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Description {get;set;}

        public override void Darpresentacion()
        {
            Console.WriteLine("Name: "+Name); 
        }


    }
}
