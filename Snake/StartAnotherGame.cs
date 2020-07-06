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
    public partial class StartAnotherGame : Form
    {
        public StartAnotherGame()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Form1 f = Parent as Form1;
            DialogResult = DialogResult.OK; // Ok == Start Again;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Form1 f = Parent as Form1;
            DialogResult = DialogResult.Cancel; // Cancel == ;
            this.Close();
        }
    }
}
