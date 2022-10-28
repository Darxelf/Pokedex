﻿using Pokedex.Pokemones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Pokemones
{
    class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string pkmnDescription { get; set; }
        public Types TypeId { get; set; }
        public Skills SkillId { get; set; }
        public Moves[] pkmnMoves = new Moves[1];
       
        public void Darpresentacion ()
            {
                Console.WriteLine(Name);
                Console.WriteLine(pkmnDescription);
                Console.WriteLine(TypeId);
                Console.WriteLine(SkillId);
                Console.WriteLine(pkmnMoves);
                //Console.WriteLine(Type);
            }
    }
}
//List<Pokemon> DatosPokemon = new List<Pokemon>()
//            {
//                //Pikachu
//                new Pokemon
//                {
//                    Id = 0,
//                    Name = "Pikachu",
//                    Type = "Electric",
//                    Moves = new Skills[]
//                    {
//                        new Skills
//                        {
//                            IdSkill = 15,
//                            SkillName = "Thunder",
//                            AttackPower = 120,
//                            PowerPoint = 10
//                        }
//                    }

//                },
//                //Salamence
//                new Pokemon
//                {
//                    Id = 1,
//                    Name = "Salamence",
//                    Type = "Dragon",
//                    Moves = new Skills[]
//                    {
//                        new Skills
//                        {
//                            IdSkill = 5,
//                            SkillName ="DragonBreath",
//                            AttackPower = 35,
//                            PowerPoint = 67
//                        }
//                    }
//                },
//                //Blastoise
//                new Pokemon
//                {
//                    Id = 2,
//                    Name = "Blastoise",
//                    Type = "Water",
//                    Moves= new Skills[]
//                    {
//                        new Skills
//                        {
//                            IdSkill = 10,
//                            SkillName = "HydroPump",
//                            AttackPower = 150,
//                            PowerPoint = 8
//                        }
//                    }
//                },
//                //Dragonite
//                new Pokemon
//                {
//                    Id = 3,
//                    Name = "Dragonite",
//                    Type = "Dragon",
//                    Moves =  new Skills[]
//                    {
//                        new Skills
//                        {
//                            IdSkill = 25,
//                            SkillName = "DracoMeteor",
//                            AttackPower = 160,
//                            PowerPoint= 8
//                        }
//                    }
//                }
//            };