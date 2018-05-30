using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonForms
{
    public interface IMove
    {
        PokemonHelper.PokemonType Type { get; }
        int Power { get; }
        void PerformMove(Pokemon ThisPkm, Pokemon FoePkm);
    }

    public class Slash : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Normal; }
        public int Power { get => 70; }

        public void PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            PokemonHelper.DoDamage(ThisPkm, FoePkm, this);
        }
    }
}
