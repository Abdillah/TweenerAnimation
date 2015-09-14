using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TweenerStudio
{
    public partial class Displayer : Form
    {
        RenderEngine renderer;
        Polygon poly;

        int[,] points1;
        int[,] points2;

        public Displayer()
        {
            InitializeComponent();

            // Initialize render engine
            renderer = new RenderEngine(this.canvas);

            // Create polygon
            points2 = new int[,] {
				{130,125},
				{192,80},
				{247,72},
				{252,69},
				{315,69},
				{319,72},
				{375,80},
				{438,125},
				{412,174},
				{367,154},
				{370,309},
				{198,309},
				{200,154},
				{157,174} };

            points1 = new int[,] {
				{228,66},
				{387,66},
				{387,135},
				{380,318},
				{345,318},
				{311,138},
				{277,318},
				{243,318},
				{228,135},
				{228,66},
				{228,71},
				{387,71},
				{387,66},
				{228,66}};

            poly = new Polygon(points1);
            renderer.render(ref poly);
        }

        public void progressbarDecrement()
        {
            renderer.render();
            Thread.Sleep(100);
            if (progressbar.Value > 0)
            {
                progressbar.Value -= 1;
            }
            else
            {
                return;
            }
            double progress = (double)progressbar.Value / (double)progressbar.Maximum;
            poly.tweening(points1, points2, progress, progressbarDecrement);
        }

        public void progressbarIncrement()
        {
            renderer.render();
            Thread.Sleep(100);
            if (progressbar.Value < 100)
            {
                progressbar.Value += 1;
            }
            else
            {
                return;
            }
            double progress = (double)progressbar.Value / (double)progressbar.Maximum;
            poly.tweening(points1, points2, progress, progressbarIncrement);
        }

        private void reverse_btn_Click(object sender, EventArgs e)
        {
            double progress = (double)progressbar.Value / (double)progressbar.Maximum;
            poly.tweening(points1, points2, progress, progressbarDecrement);
        }

        private void play_Click(object sender, EventArgs e)
        {
            double progress = (double)progressbar.Value / (double)progressbar.Maximum;
            poly.tweening(points1, points2, progress, progressbarIncrement);
        }

        private void progressbar_Scroll(object sender, EventArgs e)
        {
            Console.WriteLine((double)(progressbar.Value / progressbar.Maximum) + " = " + progressbar.Value + " / " + progressbar.Maximum);
            poly.tweening(points1, points2, (double)((double) progressbar.Value / (double) progressbar.Maximum), renderer.render);
        }
    }
}
