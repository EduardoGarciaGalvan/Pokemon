using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonForms
{
    public class Pokemon
    {
        string name;
        int maxHP;
        int currentHP;
        int currentAttack;
        int currentDefense;
        int level;
        PokemonHelper.PokemonType type;
        IMove[] moves;

        public string Name { get => name; private set => name = value; }
        public int CurrentHP
        {
            get => currentHP;
            set
            {
                if(value < 0)
                {
                    currentHP = 0;
                }
                else
                {
                    currentHP = value; //Eduardo was here
                }
            }
        }
        public int CurrentAttack { get => CurrentAttack; set => CurrentAttack = value; }
        public int CurrentDefense { get => CurrentDefense; set => CurrentDefense = value; }
        public int MaxHP { get => maxHP; private set => maxHP = value; }
        public int Level { get => level; private set => level = value; }
        public PokemonHelper.PokemonType Type { get => type; private set => type = value; }

        IMove GetMove(int index)
        {
            return moves[index];
        }

        void PerformMove(int moveIndex, Pokemon foe)
        {
            moves[moveIndex].PerformMove(this, foe);
        }
    }
}
