using PokedexBackend.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using System;

namespace PokedexBackend.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _client;
        private readonly string _url = "https://pokeapi.co/api/v2/pokemon?limit=10000";
        public PokemonService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<AllPokemonInfo>> GetAllPokemons()
        {
            var response = await _client.GetAsync(_url);
            var allPokemons = await JsonSerializer.DeserializeAsync<Response>(await response.Content.ReadAsStreamAsync());

            return allPokemons.results;
        }

        public async Task<PokemonInfo> GetPokemonName(string name)
        {
            using (HttpResponseMessage response = await _client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{ name }"))
            {
                if (response.IsSuccessStatusCode)
                {
                    SinglePokemonInfo details = await JsonSerializer.DeserializeAsync<SinglePokemonInfo>(await response.Content.ReadAsStreamAsync());
                    var pokemonDetails = new PokemonInfo()
                    {
                        Id = details.id,
                        Name = details.name,
                        Types = details.types,
                        Sprites = details.sprites
                    };
                    return pokemonDetails;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}


