using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones
{
    class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Skills[] Moves = new Skills[4];
       
        public void Darpresentacion ()
            {
                Console.WriteLine(Id);
                Console.WriteLine(Name);
                Console.WriteLine(Type);
            }
    }
}
