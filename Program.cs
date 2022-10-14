using System;
using System.Collections.Generic;
using Pokedex.Pokemones;

namespace Pokedex
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> DatosPokemon = new List<Pokemon>()
            {
                //Pikachu
                new Pokemon 
                {
                    Id = 0,
                    Name = "Pikachu",
                    Type = "Electric",
                    Moves = new Skills[]
                    {
                        new Skills
                        {
                            IdSkill = 15,
                            SkillName = "Thunder",
                            AttackPower = 120,
                            PowerPoint = 10
                        }
                    }
                    
                },
                //Salamence
                new Pokemon
                {
                    Id = 1,
                    Name = "Salamence",
                    Type = "Dragon",
                    Moves = new Skills[]
                    {
                        new Skills
                        {
                            IdSkill = 5,
                            SkillName ="DragonBreath",
                            AttackPower = 35,
                            PowerPoint = 67
                        }
                    }
                },
                //Blastoise
                new Pokemon
                {
                    Id = 2,
                    Name = "Blastoise",
                    Type = "Water",
                    Moves= new Skills[]
                    {
                        new Skills
                        {
                            IdSkill = 10,
                            SkillName = "HydroPump",
                            AttackPower = 150,
                            PowerPoint = 8
                        }
                    }
                },
                //Dragonite
                new Pokemon
                {
                    Id = 3,
                    Name = "Dragonite",
                    Type = "Dragon",
                    Moves =  new Skills[]
                    {
                        new Skills
                        {
                            IdSkill = 25,
                            SkillName = "DracoMeteor",
                            AttackPower = 160,
                            PowerPoint= 8
                        }
                    }
                }
            };
            Console.WriteLine("Lista de Pokemones:");

            foreach (Pokemon i in DatosPokemon)
            {
                Console.WriteLine(i.Id+"--"+i.Name);
            }

            Console.WriteLine("Eligir el pokemon deseado: ");
            int pokemonSeleccionado = Convert.ToInt32(Console.ReadLine());
            if (pokemonSeleccionado > DatosPokemon.Count-1)
            {
                Console.WriteLine("Pokemon Seleccionado incorrecto!");
            }
            else
            {
                DatosPokemon[pokemonSeleccionado].Darpresentacion();
            }

            Console.ReadKey();
        }
    }
}
