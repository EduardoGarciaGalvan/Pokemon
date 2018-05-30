using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonForms
{
    public static class PokemonHelper
    {
        public enum PokemonType {
            Normal,   Fire,
            Fighting,    Water,
            Flying,  Grass,
            Poison,  Electric,
            Ground,  Psychic,
            Rock,    Ice,
            Bug, Dragon,
            Ghost,   Dark,
            Steel,   Fairy,
            Unknown
        };

        public static double Effective(PokemonType moveType, PokemonType pkmType)
        {
            return 1;
        }

        public static void DoDamage(Pokemon attackPkm, Pokemon defendPkm, IMove move)
        {
            double Damage = (((double)2 * attackPkm.Level / 5) * move.Power * ((double)attackPkm.CurrentAttack / defendPkm.CurrentDefense) / 50) + 2;
            Damage *= new Random().NextDouble() * 0.25 + 0.85; // Random
            Damage *= (attackPkm.Type == move.Type) ? 1.5 : 1; // STAB
            Damage *= Effective(move.Type, defendPkm.Type); //Type Effectiveness

            defendPkm.CurrentHP -= (int)Damage;//Eduardo did dis

        }
    }
}
