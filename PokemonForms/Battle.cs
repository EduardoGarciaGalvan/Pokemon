using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonForms
{
    public partial class Form1 : Form
    {
        clsResize _form_resize;
        Pokemon ThisPokemon = null;
        Pokemon FoePokemon = null;

        public Form1()
        {
            InitializeComponent();

            var rnd = new Random();

            ThisPokemon = Pokemon.GeneratePokemon(rnd.Next(0,3), 100);
            FoePokemon = Pokemon.GeneratePokemon(rnd.Next(0, 3), 100);

            ThisPokemon.SetControls(barMyPkm, lblCurrentHP);
            FoePokemon.SetControls(barFoePkm);

            _form_resize = new clsResize(this);
            this.Resize += new EventHandler(_Resize);

        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            barMyPkm.Maximum = ThisPokemon.MaxHP;
            barFoePkm.Maximum = FoePokemon.MaxHP;

            barMyPkm.Value = barMyPkm.Maximum;
            barFoePkm.Value = barFoePkm.Maximum;

            lblMaxHP.Text = barMyPkm.Maximum.ToString();
            lblMyPkmLevel.Text = barMyPkm.Value.ToString();

            lblCurrentHP.Text = barMyPkm.Maximum.ToString();

            lblMyPkmLevel.Text = ThisPokemon.Level.ToString();
            lblFoePkm.Text = FoePokemon.Level.ToString();

            lblMyPkm.Text = ThisPokemon.Name;
            lblFoePkm.Text = FoePokemon.Name;

            picMyPkm.Image = ThisPokemon.BackImage;
            picFoePkm.Image = FoePokemon.FrontImage;

            ThisPokemon.ResetStats();
            FoePokemon.ResetStats();
        }

        private void BtnAttack_Click(object sender, EventArgs e)
        {
            if(ThisPokemon.Speed >= FoePokemon.Speed )
            {
                ThisPokemon.PerformMove(0, FoePokemon);
                FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon);
            }
            else
            {
                FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon);
                ThisPokemon.PerformMove(0, FoePokemon);
            }
        }

        private void BtnHeal_Click(object sender, EventArgs e)
        {
            ThisPokemon.CurrentHP += 200;
            FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon);
        }

        private void BtnDefender_Click(object sender, EventArgs e)
        {
            if (ThisPokemon.Speed >= FoePokemon.Speed)
            {
                ThisPokemon.PerformMove(1, FoePokemon);
                FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon);
            }
            else
            {
                FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon);
                ThisPokemon.PerformMove(1, FoePokemon);
            }
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You fled like a coward.");
            this.Close();
        }
    }
}
