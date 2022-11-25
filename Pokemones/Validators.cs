using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Pokedex.Pokemones
{
  public  class Validators :Pokemon
    {
        public string TextValidation(string keyInformation)
        {
            //keyInformation = pkmInserted.Name;
            string text = @"[a-z]";
            //string incorrect = "";

            if (Regex.IsMatch(keyInformation, text))
            {
                Console.WriteLine("Datos Correctos!");
                return  keyInformation;

            }
            else 
            {
                Console.WriteLine("Datos incorrectos!");
                Environment.Exit(0);
                return keyInformation;
            }
        }
        public string NumberValidation(string numberPressed)
        {
            string number = @"[0-9]";
            if (Regex.IsMatch(numberPressed, number))
            {
                Console.WriteLine("Datos Correctos!");
                return numberPressed;   
            }
            else
            {
                Console.WriteLine("Datos Incorrectos!");
                Environment.Exit(0);
                return numberPressed;
            }
        }
    }
}
