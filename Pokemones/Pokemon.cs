﻿using Pokedex.Pokemones;
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
                Console.WriteLine("Id:"+ Id +" --Name: "+ Name+" Type: "+Type.Name+" Skill: "+Skill.Name );

            }
        public virtual void Darpresentacion(int id, string name,  string skill, string type) 
        {
            Console.WriteLine("Id:" + id + " --Name: " + name +" Type: " + type + " Skill: " + skill);

        }
        public virtual void Darpresentacion(int id, string name,string description, string skill, string type)
        {
            Console.WriteLine("Id:" + id + "\nName: " + name +"\nDescription: "+description+" \nSkill: " + skill+"\nType: " + type );

        }

    }
}