using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaryMaze
{
    public partial class Scare : Form
    {
        public Scare()
        {
            InitializeComponent();
            //Сделать форму полноэкранной
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            //Воспроизвести звук Scart
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Stream = Properties.Resources.scare;
            player.Play();
            
        }

        private void exit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
