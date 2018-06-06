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

            lblBattleMessage.Text = null;

            picMyPkm.Image = ThisPokemon.BackImage;
            picFoePkm.Image = FoePokemon.FrontImage;

            ThisPokemon.ResetStats();
            FoePokemon.ResetStats();
        }

        private void ActiveButtons()
        {

            btnAttack.Enabled = true;
            btnDefender.Enabled = true;
            btnHeal.Enabled = true;
            btnRun.Enabled = true;
            lblBattleMessage.Text = null;
        }

        private void DesactiveButtons()
        {
            btnAttack.Enabled = false;
            btnDefender.Enabled = false;
            btnHeal.Enabled = false;
            btnRun.Enabled = false;
        }

        private async void BtnAttack_Click(object sender, EventArgs e)
        {
            DesactiveButtons();
            if (ThisPokemon.Speed >= FoePokemon.Speed)
            {
                BattleMessage(ThisPokemon.PerformMove(0, FoePokemon));
                await Delay();

                BattleMessage(FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon));
                await Delay();
            }
            else
            {
                BattleMessage(FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon));
                await Delay();

                BattleMessage(ThisPokemon.PerformMove(0, FoePokemon));
                await Delay();
            }
            ActiveButtons();
            GetHP();
        }

        private async void BtnHeal_Click(object sender, EventArgs e)
        {
            DesactiveButtons();
            ThisPokemon.CurrentHP += 200;
            FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon);
            MessageHeal(ThisPokemon);
            await Delay();
            ActiveButtons();
            GetHP();
        }

        private async void BtnDefender_Click(object sender, EventArgs e)
        {
            DesactiveButtons();
            if (ThisPokemon.Speed >= FoePokemon.Speed)
            {
                BattleMessage(ThisPokemon.PerformMove(1, FoePokemon));
                await Delay();
                BattleMessage(FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon));
                await Delay();
            }
            else
            {
                BattleMessage(FoePokemon.PerformMove(new Random().Next(0, 2), ThisPokemon));
                await Delay();
                BattleMessage(ThisPokemon.PerformMove(1, FoePokemon));
                await Delay();
            }
            ActiveButtons();
            GetHP();
        }

        private async void BtnRun_Click(object sender, EventArgs e)
        {
            BattleMessage("You fled like a coward.");
            await Delay();
            this.Close();
        }

        private void BattleMessage(String msg)
        {
            lblBattleMessage.Text = msg;
        }

        private void MessageHeal(Pokemon pokemon1)
        {
            BattleMessage("Has usado pocion sobre " + pokemon1.Name);
        }

        public static Task Delay()
        {
            var tcs = new TaskCompletionSource<bool>();
            var timer = new System.Threading.Timer(o => tcs.SetResult(false));
            timer.Change(2000, -1);
            return tcs.Task;
        }

        public void GetHP()
        {
            if(ThisPokemon.CurrentHP <= 0 || FoePokemon.CurrentHP <= 0)
            {
                DesactiveButtons();
                btnAttack.Visible = false;
                btnDefender.Visible = false;
                btnHeal.Visible = false;
                btnRun.Visible = false;
                if (ThisPokemon.CurrentHP <= 0)
                {
                    BattleMessage (FoePokemon.Name + " ha ganado");
                    picMyPkm.Visible = false;
                }
                else if (FoePokemon.CurrentHP <= 0)
                {
                    BattleMessage(ThisPokemon.Name + " ha ganado");
                    picFoePkm.Visible = false;
                }
            }
        }
    }
}
