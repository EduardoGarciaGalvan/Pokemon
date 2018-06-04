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

    public class FlashCannon : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Steel; }
        public int Power { get => 80; }
        public void PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            PokemonHelper.DoDamage(ThisPkm, FoePkm, this);
            if(new Random().Next(0,10) == 0)
            {
                if(FoePkm.CurrentDefense > -6)
                    FoePkm.CurrentDefense--;
            }
        }
    }

    public class TakeDown : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Normal; }
        public int Power { get => 90; }
        public void PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            int damage;
            damage = PokemonHelper.DoDamage(ThisPkm, FoePkm, this);
            ThisPkm.CurrentHP -= damage / 4;
        }
    }

    public class Growl : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Normal; }
        public int Power { get => 0; }
        public void PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            if (FoePkm.CurrentAttack > -6)
                FoePkm.CurrentAttack--;
        }
    }

    public class Withdraw : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Water; }
        public int Power { get => 0; }
        public void PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            if (ThisPkm.CurrentDefense < 6)
                ThisPkm.CurrentDefense++;
        }
    }

    public class SleepPowder : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Grass; }
        public int Power { get => 0; }
        public void PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            FoePkm.sleep = true;
        }
    }
}
