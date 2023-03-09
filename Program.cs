using System;
using System.Collections.Generic;
using Pokedex.Pokemones;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Globalization;
using Pokedex.Pokemones.DataManipulation;
using Pokedex.Pokemones.Data_Manipulation;

namespace Pokedex
{
    class Program
    {
        static void Main(string[] args)
        {

            UserInterface Start = new UserInterface();
            Start.Interface();

        }
    }
}
