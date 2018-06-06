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
        string PerformMove(Pokemon ThisPkm, Pokemon FoePkm);
    }

    public class Slash : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Normal; }
        public int Power { get => 70; }

        public string PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            PokemonHelper.DoDamage(ThisPkm, FoePkm, this);
            return ThisPkm.Name + " ha usado Slash";
        }
    }

    public class FlashCannon : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Steel; }
        public int Power { get => 80; }
        public string PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            PokemonHelper.DoDamage(ThisPkm, FoePkm, this);
            if(new Random().Next(0,10) == 0)
            {
                if(FoePkm.CurrentDefense > -6)
                    FoePkm.CurrentDefense--;
            }
            return ThisPkm.Name + " ha usado Flash Cannon";
        }
    }

    public class TakeDown : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Normal; }
        public int Power { get => 90; }
        public string PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            int damage;
            damage = PokemonHelper.DoDamage(ThisPkm, FoePkm, this);
            ThisPkm.CurrentHP -= damage / 4;
            return ThisPkm.Name + " ha usado Take Down";
        }
    }

    public class Growl : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Normal; }
        public int Power { get => 0; }
        public string PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            if (FoePkm.CurrentAttack > -6)
                FoePkm.CurrentAttack--;
            return ThisPkm.Name + " ha usado Growl";
        }
    }

    public class Withdraw : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Water; }
        public int Power { get => 0; }
        public string PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            if (ThisPkm.CurrentDefense < 6)
                ThisPkm.CurrentDefense++;
            return ThisPkm.Name + " ha usado Withdraw";
        }
    }

    public class SleepPowder : IMove
    {
        public PokemonHelper.PokemonType Type { get => PokemonHelper.PokemonType.Grass; }
        public int Power { get => 0; }
        public string PerformMove(Pokemon ThisPkm, Pokemon FoePkm)
        {
            FoePkm.sleep = true;
            return ThisPkm.Name + " ha usado Sleep Powder\n" + FoePkm.Name + " se a dormido";
        }
    }
}
