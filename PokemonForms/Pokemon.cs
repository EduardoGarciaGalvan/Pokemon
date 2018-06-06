using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PokemonForms.Properties;

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
        int speed;
        int currentSpeed;
        int level;
        PokemonHelper.PokemonType type;
        IMove[] moves;

        Image frontImage;
        Image backImage;

        ProgressBar progressBar;
        Label hpLabel;

        public bool sleep = false;
        
        private  static readonly Pokemon [] pokedex = new Pokemon []
         {
             new Pokemon ("Charizard" , PokemonHelper.PokemonType.Fire, 78, 84, 78, 100, 
                 new IMove[]{new Slash(), new Growl()}, Resources.Charizard_XY_variocolor1, Resources.Charizard_Back_Shiny_XY1),
             new Pokemon ("Blastoise" , PokemonHelper.PokemonType.Water, 79, 83, 100, 78, 
                 new IMove[]{new FlashCannon(), new Withdraw()}, Resources.Blastoise_XY, Resources.BlastoiseBack_XY ),
             new Pokemon ("Venosaur" , PokemonHelper.PokemonType.Grass, 80, 82, 83, 80, 
                 new IMove[]{new TakeDown(), new SleepPowder()}, Resources.Venusaur_XY, Resources.Venusaur_Back_XY )
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
                else if(value > maxHP)
                {
                    currentHP = maxHP;
                }
                else
                {
                    currentHP = value; //Eduardo was here
                }

                if(progressBar != null)
                {
                    progressBar.Value = currentHP;
                }
                if(hpLabel != null)
                {
                    hpLabel.Text = currentHP.ToString();
                }
            }
        }

        public int CurrentAttack 
        { 
            get => currentAttack;
            set => currentAttack = value;
        }

        public int CurrentDefense
        {
           get => currentDefense;
            set => currentDefense = value;
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

        public int CurrentSpeed { get => currentSpeed; set => currentSpeed = value; }

        public int Speed { get => speed; private set => speed = value; }
        public Image FrontImage { get => frontImage; private set => frontImage = value; }
        public Image BackImage { get => backImage; private set => backImage = value; }

        private Pokemon(string name, PokemonHelper.PokemonType type1, int hpBase, int attackBase,
            int defenseBase, int velocityBase, IMove[] move, Bitmap front, Bitmap back)
        {
            this.name = name;
            type = type1;
            maxHP = hpBase;
            attack = attackBase;
            defense = defenseBase;
            speed = velocityBase;
            moves = move;
            frontImage = front;
            backImage = back;
        }

        private Pokemon (Pokemon other)
        {
            this.name = other.name;
            this.type = other.type;
            this.maxHP = other.maxHP;
            this.attack = other.attack;
            this.defense = other.defense;
            this.speed = other.speed;
            this.moves = other.moves;
            this.frontImage = other.frontImage;
            this.backImage = other.backImage;
        }

        public static Pokemon GeneratePokemon(int pokedexIndex, int level)
        {
            var pkm = new Pokemon(pokedex[pokedexIndex]) { level = level };
            CalculateStats(pkm);
            return pkm;
        }

        private static void CalculateStats(Pokemon pokemon)
        {
            pokemon.maxHP = (int)Math.Floor((2 * pokemon.maxHP) * pokemon.level / 100f) + pokemon.level + 10;
            pokemon.attack = (int)Math.Floor((2 * pokemon.attack) * pokemon.level / 100f) + 5;
            pokemon.defense = (int)Math.Floor((2 * pokemon.defense) * pokemon.level / 100f) + 5;
            pokemon.speed = (int)Math.Floor((2 * pokemon.speed) * pokemon.level / 100f) + 5;
        }

        public IMove GetMove(int index)
        {
            return moves[index];
        }

        public string PerformMove(int moveIndex, Pokemon foe)
        {
            string msg = "";
            if(sleep)
            {
                if (new Random().Next(0, 2) == 0)
                {
                    msg += Name + " se ha despertado\n";
                    sleep = false;
                }
                else msg += Name + " esta dormido";
            }
            if(!sleep)
            {
                msg += moves[moveIndex].PerformMove(this, foe);
            }
            return msg;
        }

        public void ResetStats()
        {
            currentAttack = 0;
            currentDefense = 0;
            currentSpeed = 0;
            currentHP = maxHP;
        }

        public void SetControls(ProgressBar progressBar,Label hpLabel = null)
        {
            this.progressBar = progressBar;
            this.hpLabel = hpLabel;
        }
    }
}
