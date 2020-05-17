using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SortVisualizer
{
    public partial class Form1 : Form
    {

        int[] mainArray;
        Graphics g;
        BackgroundWorker w = null;
        bool isPaused = false;




        public Form1()
        {
            InitializeComponent();
            PopulateDropdown();
        }


        // List of Names of classes that implement the Sort Interface
        private void PopulateDropdown()
        {
            List<string> classList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => typeof(SortInterface).IsAssignableFrom(x)
            && !x.IsInterface && !x.IsAbstract).Select(x => x.Name).ToList();
            classList.Sort();
            foreach( string entry in classList)
            {
                comboBox1.Items.Add(entry);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (mainArray == null) button1_Click(null, null);
            w = new BackgroundWorker();
            w.WorkerSupportsCancellation = true;
            w.DoWork += new DoWorkEventHandler(w_DoWork);
            w.RunWorkerAsync(argument: comboBox1.SelectedItem);

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

        

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    // Identigy class to get type of algortihm
        private void w_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            string SortInterfaceName = (string)e.Argument;
            Type type = Type.GetType("SortVisualizer." + SortInterfaceName);
            var contructors = type.GetConstructors();
            try
            {
                SortInterface s = (SortInterface)contructors[0].Invoke(new object[] { mainArray, g, panel1.Height });
                while(!s.isSorted() && (!w.CancellationPending))
                {
                    s.nextStep();
                }
                
            }
            catch(Exception ex)
            {
            }

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                w.CancelAsync();
                isPaused = true;
            }
            else
            {
                if (w.IsBusy) return;
                int NumEntires = panel1.Width;
                int MaxVal = panel1.Height;
                isPaused = false;
                for (int i = 0; i < NumEntires; i++)
                {
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), i, 0, 1, MaxVal);
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), i, MaxVal - mainArray[i], 1, MaxVal);
                }
                w.RunWorkerAsync(argument: comboBox1.SelectedItem);


            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
