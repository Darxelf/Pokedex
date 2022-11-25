using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones
{
    public class Moves
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AttackPower { get; set; }
        public int PowerPoint { get; set; }
        public string Description { get; set;}
        public Types TypId { get; set; }
    }
}
