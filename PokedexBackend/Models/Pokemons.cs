using System;
using System.Collections.Generic;

namespace PokedexBackend.Models
{
    public class PokemonInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Object Types { get; set; }
        public Object Sprites { get; set; }
        public bool IsFavorite { get; set; }
    }

    //public class Type2
    //{
        
    //}

    public class Type
    {
        public string name { get; set; }
        public Type type { get; set; }
    }

    public class Sprites
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }
    }

    public class SinglePokemonInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Type> types { get; set; }
        public Sprites sprites { get; set; }
        public bool IsFavorite { get; set; }

    }
    public class AllPokemonInfo
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Response
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<AllPokemonInfo> results { get; set; }
    }
}
