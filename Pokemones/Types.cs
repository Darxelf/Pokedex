using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones
{
    public class Types:Pokemon
    {
        public int Id {get;set;}
        public string Name {get;set;}

        public override void Darpresentacion()
        {
            Console.WriteLine("Name: "+Name);
        }
    }
}
