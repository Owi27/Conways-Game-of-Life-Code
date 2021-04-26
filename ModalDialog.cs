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
    public partial class ModalDialog : Form
    {
        public ModalDialog()
        {
            InitializeComponent();
        }

        // Timer Setting DLG Box
        public int GetTimeNum()
        {
            return (int)TimerUpDown3.Value;
        }

        public void SetTimeNum(int number)
        {
            TimerUpDown3.Value = number;
        }

        // Grid Setting DLG Box
        public int GetGridX()
        {
            return (int)GridXUpDown1.Value;
        }

        public void SetGridX(int number)
        {
            GridXUpDown1.Value = number;
        }

        public int GetGridY()
        {
            return (int)GridYUpDown2.Value;
        }

        public void SetGridY(int number)
        {
            GridYUpDown2.Value = number;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GridYUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
