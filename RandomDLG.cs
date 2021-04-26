using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLStartUpTemplate
{
    public partial class RandomDLG : Form
    {
        public RandomDLG()
        {
            InitializeComponent();
        }
        
        public int Seed
        {
            get
            {
                int seed;
                if (Int32.TryParse(textBox1.Text, out seed))
                {
                    seed = Int32.Parse(textBox1.Text);
                }
                return seed;
                
            }

            set
            {
                try
                {
                    int seed = Int32.Parse(textBox1.Text);
                    textBox1.Text = $"{seed}";
                }
                catch
                {
                    this.Close();
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
