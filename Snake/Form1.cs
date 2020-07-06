using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private Dictionary<String, String> baseList; // baza na mozni problemi
        private List<Label> label;
        private int checkDifficulty; // 1 == easy, 2 == medium, 3 == hard,
        private bool gameInProgress; // true ako ima pocnato igra vishe;
        private int pogodeniCount;
        private int BRZADACI;
        private bool proveriZadaci;
        private bool proveriTezina;

        public Form1() //inicijalizacija 
        {
            baseList = new Dictionary<string, string>();
            checkDifficulty = -1;
            gameInProgress = false;
            pogodeniCount = 0;
            BRZADACI = 0;
            proveriZadaci = false;
            proveriTezina = false;
            InitializeComponent();
        }
        private bool checkToOpen()
        {
            if (File.Exists("Settings.txt"))
            {
                String settings = File.ReadAllText("Settings.txt");
                int value = Int32.Parse(settings);
                if (value == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
                return true;
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
           if(!gameInProgress) // ako nema pocnato igra, sozdadi igra
           {
                int index = -1;
                BRZADACI = 3;
                gameInProgress = true;
                pogodeniCount = 0;
                checkDifficulty = 1;
                label = new List<Label>(); // na easy ima 5 problemi 
                Random random = new Random();
                Easy easyBase = new Easy();
                baseList = easyBase.Napolni_dict();
                lblScoreText.Text = "0";
                lblBrZivotiText.Text = "5";
                for (int i = 0; i < BRZADACI; i++)
                {
                    index = random.Next(0, baseList.Count);
                    label.Add(createNewLabel(index, 4 * i));
                    panel1.Controls.Add(label[i]);

                }
                textBox1.Focus();
                timer1.Enabled = true; // zapocnuva pagjanjeto
           }
           else // ako ima pocnato igra, prasaj dali da se prekine i da pocne od novo
           {
                StartAnotherGame startanothergame = new StartAnotherGame();
                timer1.Enabled = false;
                DialogResult result = startanothergame.ShowDialog();
                if(result == DialogResult.OK)
                {
                    foreach (Label l in label)
                        l.Visible = false;
                    label.RemoveRange(0, label.Count);
                    gameInProgress = false;
                    this.btnEasy_Click(sender, null);
                }
                else if (result == DialogResult.Cancel);
                {
                    timer1.Enabled = true;
                }
            }
        }

        private Label createNewLabel(int index, int g) // Sozdavanje na label
        {
            Label lblGuess = new Label();
            if(BRZADACI == 3)
                lblGuess.Location = new Point(10 + (110*g), -3);
            if (BRZADACI == 4)
                lblGuess.Location = new Point(10 + (150 * g), -3);
            if (BRZADACI == 5)
                lblGuess.Location = new Point(10 + (230 * g), -3);
            if (BRZADACI == 1)
                lblGuess.Location = new Point(500, -3);
            if (BRZADACI == 2)
                lblGuess.Location = new Point(350 + (300 * g), -3);
            lblGuess.Name = "lblGuess" + g.ToString();
            lblGuess.AutoSize = true;
            lblGuess.Font = new Font("Calibri", 25);
            lblGuess.Text = baseList.ElementAt(index).Key;
            lblGuess.Size = new System.Drawing.Size(45, 28);
            lblGuess.ForeColor = Color.Green;
            return lblGuess;
        }

        private void timer1_Tick(object sender, EventArgs e) // Timer koj menuva lokaciite na aktivnite zadaci/labels
        {
            List<int> indexes = new List<int>();
            for(int i = label.Count - 1; i >= 0; i--) // Porveruvanje na pozicijata i soodvetno menuvanje na boite
            {
                label[i].Location = new Point(label[i].Location.X, label[i].Location.Y + 5 * checkDifficulty);
                int processNumber = checkLocation(label[i]);
                if (processNumber == 0)
                    label[i].ForeColor = Color.Green;
                if (processNumber == 1)
                    label[i].ForeColor = Color.Orange;
                if (processNumber == 2)
                    label[i].ForeColor = Color.Red;
                if (processNumber == 3) // brishenje na labelot i soodvetno namaluvanje na zivoti
                {
                    int broj = Int32.Parse(lblBrZivotiText.Text);
                    broj--;
                    if(broj <= 0)
                        lblBrZivotiText.Text = "0";
                    else
                        lblBrZivotiText.Text = broj.ToString();
                    label[i].Visible = false;
                    label.RemoveAt(i);
                }
            }
            if(lblBrZivotiText.Text.Equals("0")) // ako brojot na zivoti e 0, game over, pocni nova igra
            {
                GameOver gameover = new GameOver(this.sendDifficulty(), this.sendScore());
                //gameover.Show();
                timer1.Enabled = false;
                DialogResult result = gameover.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (Label l in label)
                        l.Visible = false;
                    label.RemoveRange(0, label.Count);
                    gameInProgress = false;
                    this.btnEasy_Click(sender, null);
                }
                else if(result == DialogResult.Retry)
                {
                    foreach (Label l in label)
                        l.Visible = false;
                    label.RemoveRange(0, label.Count);
                    gameInProgress = false;
                    this.btnMedium_Click(sender, null);
                }
                else if(result == DialogResult.Yes)
                {
                    foreach (Label l in label)
                        l.Visible = false;
                    label.RemoveRange(0, label.Count);
                    gameInProgress = false;
                    this.btnHard_Click(sender, null);
                }
                else
                {
                    foreach (Label l in label)
                        l.Visible = false;
                    label.RemoveRange(0, label.Count);
                    gameInProgress = false;
                }
            }
            if (label.Count < BRZADACI && !lblBrZivotiText.Text.Equals("0")) // ako brojot na prisutni labels e pomal od 5 dodadi nov label
            {
                Random random = new Random();
                Label newLabel = createNewLabel(random.Next(0, baseList.Count), random.Next(0, 5));
                label.Add(newLabel);
                panel1.Controls.Add(newLabel);
            }
        }


        private int checkLocation(Label l)
        {
            if (l.Location.Y > 445 && l.Location.Y < 612)   // 0 == zeleno, 1 == portokalovo, 2 = crveno, 3 == izguben zivot
                return 1;
            else if (l.Location.Y > 612 && l.Location.Y < 734)
                return 2;
            else if (l.Location.Y >= 735)
                return 3;
            else
                return 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (Label l in label)
            {
                String value = baseList[l.Text];
                if (textBox1.Text.Equals(value))
                { 
                    l.Visible = false;
                    label.Remove(l);
                    if(checkDifficulty == 1)
                        pogodeniCount++;
                    if (checkDifficulty == 2)
                        pogodeniCount += 2;
                    if (checkDifficulty == 3)
                        pogodeniCount += 3;
                    lblScoreText.Text = pogodeniCount.ToString();
                    textBox1.Clear();
                    textBox1.Focus();
                    break;
                }
            }
        }

        public String sendScore()
        {
            return lblScoreText.Text;
        }

        public String sendDifficulty()
        {
            if (checkDifficulty == 0)
                return "Easy";
            else if (checkDifficulty == 1)
                return "Medium";
            else
                return "Hard";
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            if (!gameInProgress) // ako nema pocnato igra, sozdadi igra
            {
                int index = -1;
                BRZADACI = 4;
                gameInProgress = true;
                pogodeniCount = 0;
                checkDifficulty = 2;
                label = new List<Label>(); // na medium ima 4 problemi 
                Random random = new Random();
                Medium mediumBase = new Medium();
                baseList = mediumBase.Napolni_dict();
                lblScoreText.Text = "0";
                lblBrZivotiText.Text = "5";
                for (int i = 0; i < BRZADACI; i++)
                {
                    index = random.Next(0, baseList.Count);
                    label.Add(createNewLabel(index, 2 * i));
                    panel1.Controls.Add(label[i]);

                }
                textBox1.Focus();
                timer1.Enabled = true; // zapocnuva pagjanjeto
            }
            else // ako ima pocnato igra, prasaj dali da se prekine i da pocne od novo
            {
                StartAnotherGame startanothergame = new StartAnotherGame();
                timer1.Enabled = false;
                DialogResult result = startanothergame.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (Label l in label)
                        l.Visible = false;
                    label.RemoveRange(0, label.Count);
                    gameInProgress = false;
                    this.btnMedium_Click(sender, null);
                }
                else if (result == DialogResult.Cancel) ;
                {
                    timer1.Enabled = true;
                }
            }
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            if (!gameInProgress) // ako nema pocnato igra, sozdadi igra
            {
                int index = -1;
                BRZADACI = 5;
                gameInProgress = true;
                pogodeniCount = 0;
                checkDifficulty = 3;
                label = new List<Label>(); // na hard ima 5 problemi 
                Random random = new Random();
                Hard hardBase = new Hard();
                baseList = hardBase.Napolni_dict();
                lblScoreText.Text = "0";
                lblBrZivotiText.Text = "5";
                for (int i = 0; i < BRZADACI; i++)
                {
                    index = random.Next(0, baseList.Count);
                    label.Add(createNewLabel(index, i));
                    panel1.Controls.Add(label[i]);

                }
                textBox1.Focus();
                timer1.Enabled = true; // zapocnuva pagjanjeto
            }
            else // ako ima pocnato igra, prasaj dali da se prekine i da pocne od novo
            {
                StartAnotherGame startanothergame = new StartAnotherGame();
                timer1.Enabled = false;
                DialogResult result = startanothergame.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (Label l in label)
                        l.Visible = false;
                    label.RemoveRange(0, label.Count);
                    gameInProgress = false;
                    this.btnHard_Click(sender, null);
                }
                else if (result == DialogResult.Cancel) ;
                {
                    timer1.Enabled = true;
                }
            }
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            if (!gameInProgress) // ako nema pocnato igra, sozdadi igra
            {
                int index = -1;
                BRZADACI = Int32.Parse(tbBrZadaci.Text);
                gameInProgress = true;
                pogodeniCount = 0;
                checkDifficulty = (int)numBrzina.Value;
                label = new List<Label>(); // na easy ima 5 problemi 
                Random random = new Random();
                if (tbTezina.Text.Equals("1"))
                {
                    Easy easyBase = new Easy();
                    baseList = easyBase.Napolni_dict();
                }
                if (tbTezina.Text.Equals("2"))
                {
                    Medium mediumBase = new Medium();
                    baseList = mediumBase.Napolni_dict();
                }
                if (tbTezina.Text.Equals("3"))
                {
                    Hard hardBase = new Hard();
                    baseList = hardBase.Napolni_dict();
                }
                lblScoreText.Text = "0";
                lblBrZivotiText.Text = "5";

                for (int i = 0; i < BRZADACI; i++)
                {
                    index = random.Next(0, baseList.Count);
                    label.Add(createNewLabel(index, i));
                    panel1.Controls.Add(label[i]);

                }
                textBox1.Focus();
                timer1.Enabled = true; // zapocnuva pagjanjeto
            }
            else // ako ima pocnato igra, prasaj dali da se prekine i da pocne od novo
            {
                StartAnotherGame startanothergame = new StartAnotherGame();
                timer1.Enabled = false;
                DialogResult result = startanothergame.ShowDialog();
                if (result == DialogResult.OK)
                {
                    foreach (Label l in label)
                        l.Visible = false;
                    label.RemoveRange(0, label.Count);
                    gameInProgress = false;
                    this.btnCustom_Click(sender, null);
                }
                else if (result == DialogResult.Cancel) ;
                {
                    timer1.Enabled = true;
                }
            }
        }


        private void tbBrZadaci_Validating(object sender, CancelEventArgs e)
        {
            int value = Int32.Parse(tbBrZadaci.Text);
            if(value > 0 && value < 6)
            {
                proveriZadaci = true;
                if(proveriTezina)
                    btnCustom.Enabled = true;
                epBrojZadaci.SetError(tbBrZadaci, null);
                numBrzina.Focus();
            }
            else
            {
                proveriZadaci = false;
                btnCustom.Enabled = false;
                tbBrZadaci.Focus();
                epBrojZadaci.SetError(tbBrZadaci, "Внесете бројка помеѓу 1 и 6");
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (checkToOpen())
            {
                Instruction instruction = new Instruction();
                instruction.Show();
            }
        }

        private void pokaziSegaInstrukciiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.Show();
        }

        private void pokazvajInstrukciiNaStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowInstructions showinstructions = new ShowInstructions();
            showinstructions.Show();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            int value = Int32.Parse(tbTezina.Text);
            if (value > 0 && value < 4)
            {
                proveriTezina = true;
                if(proveriZadaci)
                    btnCustom.Enabled = true;
                epTezina.SetError(tbTezina, null);
                numBrzina.Focus();
            }
            else
            {
                proveriTezina = false;
                btnCustom.Enabled = false;
                tbTezina.Focus();
                epTezina.SetError(tbTezina, "Внесете бројка помеѓу 1 и 3");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (lblBrZivotiText.Text.Equals("0"))
            {
                Enter_Your_Name eyn = new Enter_Your_Name(lblScoreText.Text);
                eyn.Show();
            }
            else
            {
                MessageBox.Show("Igrata ne e zavrshena");
                timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHighScore hs = new FormHighScore();
            hs.Show();
        }
    }
}
