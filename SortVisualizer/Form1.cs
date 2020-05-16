using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortVisualizer
{
    public partial class Form1 : Form
    {

        int[] mainArray;
        Graphics g; 
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Reset Button to generate the New Array
        private void button1_Click(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            int NumEntries = panel1.Width;
            int MaxVal = panel1.Height;
            mainArray = new int[NumEntries];
            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, NumEntries, MaxVal);
            Random rand = new Random();

            // Put Random Values into the Array
            for (int i = 0; i < NumEntries; i++)
            {
                mainArray[i] = rand.Next(0, MaxVal);

            }

            // Draw in Rectangles for the sorting array
            for (int i = 0; i < NumEntries; i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), i, MaxVal - mainArray[i], 1, MaxVal);
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
