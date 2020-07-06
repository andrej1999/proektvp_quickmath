using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameOver : Form
    {
        private String gamemode;
        private String score;
        public GameOver(String g, String s)
        {
            gamemode = g;
            score = s;
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            Form1 f = Parent as Form1;
            DialogResult = DialogResult.OK; // Ok == Easy;
            this.Close();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            Form1 f = Parent as Form1;
            DialogResult = DialogResult.Retry; // Cancel == Medium;
            this.Close();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            Form1 f = Parent as Form1;
            DialogResult = DialogResult.Yes; // Yes == Hard;
            this.Close();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            lblGameModeText.Text = gamemode;
            if (gamemode.Equals("Easy"))
                lblGameModeText.ForeColor = Color.Green;
            if (gamemode.Equals("Medium"))
                lblGameModeText.ForeColor = Color.Orange;
            if (gamemode.Equals("Hard"))
                lblGameModeText.ForeColor = Color.Red;
            lblScoreText.Text = score;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Enter_Your_Name eyn = new Enter_Your_Name(score);
            eyn.Show();
        }
    }
}
