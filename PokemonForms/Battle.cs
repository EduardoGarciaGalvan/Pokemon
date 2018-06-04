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
        Pokemon ThisPokemon=null;
        Pokemon FoePokemon=null;

        public Form1()
        {
            InitializeComponent();
            
            ThisPokemon = Pokemon.GeneratePokemon(0);
            FoePokemon=Pokemon.GeneratePokemon(1);

            _form_resize = new clsResize(this);
            this.Resize += new EventHandler(_Resize);

        }

        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            barMyPkm.Value = barMyPkm.Maximum;
            barFoePkm.Value = barFoePkm.Maximum;

            label1.Text = barMyPkm.Maximum.ToString();
            lblMyPkmLevel.Text = barMyPkm.Value.ToString();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            ThisPokemon.PerformMove(0, FoePokemon);

            label1.Text = barMyPkm.Maximum.ToString();
            lblMyPkmLevel.Text = barMyPkm.Value.ToString();
        }

        private void barMyPkm_Click(object sender, EventArgs e)
        {

        }
    }
}
