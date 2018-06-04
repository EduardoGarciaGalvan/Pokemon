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

    public class FlashCannon:IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Steel; }
        public int Power { get => 80; }
        public void PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            PokemonHelper.DoDamage(ThisPkm, FoePkm, this);
            if(new Random().Next(0,9) == 0)
            {
                FoePkm.CurrentDefense -= 1;
            }
        }
    }

    public class TakeDown:IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Normal; }
        public int Power { get => 90; }
        public void PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            int damage;
            damage = PokemonHelper.DoDamage(ThisPkm, FoePkm, this);
            ThisPkm.CurrentHP -= damage/4;
        }
    }
}
