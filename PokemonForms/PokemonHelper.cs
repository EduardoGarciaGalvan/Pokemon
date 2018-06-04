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

        public static int DoDamage(Pokemon attackPkm, Pokemon defendPkm, IMove move)
        {
            double Attack = attackPkm.Attack;
            if (attackPkm.CurrentAttack > 0) Attack *= ((2.0 + attackPkm.CurrentAttack) / 2);
            else if(attackPkm.CurrentAttack < 0) Attack *= (2 / (2.0 + (attackPkm.CurrentAttack * -1)));

            double Defense = defendPkm.Defense;
            if (defendPkm.CurrentDefense > 0) Defense *= ((2.0 + defendPkm.CurrentDefense) / 2);
            else if (defendPkm.CurrentDefense < 0) Defense *= (2 / (2.0 + (defendPkm.CurrentDefense * -1)));

            double Damage = (((double)2 * attackPkm.Level / 5) * move.Power * (Attack / Defense) / 50) + 2;
            Damage *= new Random().NextDouble() * 0.25 + 0.85; // Random
            Damage *= (attackPkm.Type == move.Type) ? 1.5 : 1; // STAB
            Damage *= Effective(move.Type, defendPkm.Type); //Type Effectiveness

            defendPkm.CurrentHP -= (int)Damage;//Eduardo did dis
            return (int)Damage;
        }
    }
}
