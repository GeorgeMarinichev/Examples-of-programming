namespace ScaryMaze
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void EndGame(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            StartGame();
        }

        private void ScarePlayer(object sender, EventArgs e)
        {
            Scare fullScreen = new Scare();
            fullScreen.Show();
        }

        private void StartGame()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Enabled = true;
                    x.BackColor = System.Drawing.Color.SkyBlue;
                }

            }
            //Воспроизводит фоновую музыку
            player.Stream = Properties.Resources.bg_music;
            player.PlayLooping();
        }

        private void Reset()
        {
            button1.Enabled = true;
            player.Stop();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Enabled = false;
                    x.BackColor = System.Drawing.Color.Black;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
