﻿using System;
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
        int attack;
        int defense;
        int currentAttack;
        int currentDefense;
        int Velocity;
        int level;
        PokemonHelper.PokemonType type;
        IMove[] moves;
        
        private  static readonly Pokemon [] pokedex = new Pokemon []
         {
             new Pokemon ("Charizard" , PokemonHelper.PokemonType.Fire, 78, 84, 78, 100, new IMove[]{new Slash()} ),
             new Pokemon ("Blastoise" , PokemonHelper.PokemonType.Water, 79, 83, 100, 78, new IMove[]{new FlashCannon()} ),
             new Pokemon ("Venosaur" , PokemonHelper.PokemonType.Grass, 80, 82, 83, 80, new IMove[]{new TakeDown()} )
         };

        public string Name
        {
            get => name;
            private set => name = value;
        }

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

        public int CurrentAttack 
        { 
            get => CurrentAttack;
            set => CurrentAttack = value;
        }

        public int CurrentDefense
        {
           get => CurrentDefense;
            set => CurrentDefense = value;
        }

        public int MaxHP
        {
            get => maxHP;
            private set => maxHP = value;
        }

        public int Level
        {
            get => level;
            private set => level = value;
        }

        public int Attack
        {
            get => attack;
            private set => attack = value;
        }
        
        public int Defense
        {
            get => defense;
            private set => defense = value;
        }

        public PokemonHelper.PokemonType Type
        {  
            get => type;
            private set => type = value;
        }

        private Pokemon(string name, PokemonHelper.PokemonType type1, int hpBase, int attackBase,
            int defenseBase, int velocityBase, IMove[] move)
        {
            this.name = name;
            type = type1;
            maxHP = hpBase;
            attack = attackBase;
            defense = defenseBase;
            Velocity = velocityBase;
            moves = move;
        }

        private Pokemon (Pokemon other)
        {
            this.name = other.name;
            this.type = other.type;
            this.maxHP = other.maxHP;
            this.attack = other.attack;
            this.defense = other.defense;
            this.Velocity = other.velocity;
            this.moves = other.moves;
        }

        public static Pokemon GeneratePokemon(int PokedexIndex)
        {
            return new Pokemon(pokedex [PokedexIndex]);
        }

        public IMove GetMove(int index)
        {
            return moves[index];
        }

        public void PerformMove(int moveIndex, Pokemon foe)
        {
            moves[moveIndex].PerformMove(this, foe);
        }
    }
}
