using PokedexBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokedexBackend.Services
{
    public interface IPokemonService
    {
        Task<List<AllPokemonInfo>> GetAllPokemons();
        Task<PokemonInfo> GetPokemonName(string name);
    }
}
