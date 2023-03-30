using Pokedex.Pokemones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Pokedex.Pokemones
{
  public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Types Type { get; set; }
        public Skills Skill { get; set; }
        public Moves[] Moves = new Moves[1];
       
        public virtual void Darpresentacion ()
            {
                Console.WriteLine("Id:"+ Id +" --Name: "+ Name+"Type: "+Type.Name );
                //Console.WriteLine("Name: "+Name);
                //Console.WriteLine("Description: "+Description);
                //Console.WriteLine("TypeId: "+Type.Id);
                //Console.WriteLine("SkillId: "+Skill.Id);
                //Console.WriteLine("Moves: "+Moves[0].Id);
                //Console.WriteLine(Type);
            }

      
    }
}