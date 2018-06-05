using System;
using System.Windows.Forms;
using PokemonForms;

public class TimeHandler
{
    Timer time;
    Delegate onTick;

    public TimeHandler()
	{
        time = new Timer();
    }

    public void WaitandDoAfter(Delegate onTick)
    {
        this.onTick = onTick;
        time.Interval = 1000;
        time.Tick += TimeElapsed;
        time.Start();
    }

    private void TimeElapsed(object sender, EventArgs e)
    {
        
    }
}
