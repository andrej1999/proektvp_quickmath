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
    public partial class FormHighScore : Form
    {
        private Dictionary<String, int> names;
        public FormHighScore()
        {
            names = new Dictionary<String, int>();
            InitializeComponent();
        }

        private void lblHighScores_Load(object sender, EventArgs e)
        {
            names = new Dictionary<String, int>();
            if (File.Exists("HighScores.txt"))
            {
                using (StreamReader sr = new StreamReader("HighScores.txt"))
                {
                    while(sr.ReadLine() != null)
                    {
                        String[] temp = sr.ReadLine().Split(':');
                        temp[0] = temp[0].Substring(0, 1).ToUpper() + temp[0].Substring(1);
                        names[temp[0]] = Int32.Parse(temp[1]);
                    }
                }
                NarediPoRed(names);
            }
        }

        private void NarediPoRed(Dictionary<String, int> names)
        {
            int i = 125;
            int j = 0;
            foreach (var item in names.OrderByDescending(key => key.Value))
            {
                if (j < 15)
                {
                    Label lbl = CreateNewLabel(item, i);
                    panel1.Controls.Add(lbl);
                    i += 40;
                    j++;
                }
                else
                {
                    break;
                }
            }
        }

        private Label CreateNewLabel(KeyValuePair<string, int> item, int i)
        {
            Label lblHigh = new Label();
            lblHigh.Location = new Point(85, i);
            lblHigh.Name = "lblHigh";
            lblHigh.AutoSize = true;
            lblHigh.Font = new Font("Calibri", 25);
            lblHigh.Text = item.Key + ": " + item.Value.ToString();
            lblHigh.Size = new System.Drawing.Size(45, 28);
            lblHigh.ForeColor = Color.Green;
            return lblHigh;
        }
    }
}
