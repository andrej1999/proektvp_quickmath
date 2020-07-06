using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Enter_Your_Name : Form
    {
        public String name;
        public String score;
        public Enter_Your_Name(String score)
        {
            this.score = score;
            name = "";
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            name = tbName.Text;
            if(File.Exists("HighScores.txt"))
            {
                using (StreamWriter w = File.AppendText("HighScores.txt"))
                {
                   w.WriteLine("\n" + name + ":" + score);
                }
            }
            else
            {
                StreamWriter file = new StreamWriter("HighScores.txt");
                file.WriteLine("\n" + name + ": " + score);
                file.Close();
            }
            this.Close();

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text.Length > 0)
                btnSave.Enabled = true;
        }
    }
}
