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
    public partial class Instruction : Form
    {
        public Instruction()
        {
            InitializeComponent();
            this.BringToFront();
            this.Activate();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if(cbDontShow.Checked)
            {
                StreamWriter File = new StreamWriter("Settings.txt");
                File.Write("0");
                File.Close();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
