using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tomasz_Gromadzki_Skutnik_Zadanie1.Model;

namespace Tomasz_Gromadzki_Skutnik_Zadanie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void zadanie1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }
        private void zadanie2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }
        private void zadanie3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void zadanie4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void zadanie5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void zadanie6ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void zadanie7ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void zadanie8ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            double m = double.Parse(text1);
            double z = double.Parse(text2);
            Random random = new Random();
            List<string> globalRectangle = new List<string>();
            List<string> globalTrapezoid = new List<string>();
            globalRectangle.Add("Rectangle:");
            globalTrapezoid.Add("Trapezoid:");
            double exactValue = Math.Pow(100, 3) / 3.0;

            for (int i = 0; i < m; i++)
            {
                SingleCount singleCountRectangle = new SingleCount(0, 100, random.Next(10, 100000), AreaType.Rectangle, 0, 1);
                SingleCount singleCountTrapezoid = new SingleCount(0, 100, random.Next(10, 100000), AreaType.Trapezoid, 0, 1);
                double rectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => x * x).SingleCountsList.Last().Area;
                double trapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x).SingleCountsList.Last().Area;
                double exactnessRectangle = Math.Abs(exactValue - rectangleValue) / exactValue * 100;
                double exactnessTrapezoid = Math.Abs(exactValue - trapezoidValue) / exactValue * 100;

                if (exactnessRectangle <= z) 
                {
                    globalRectangle.Add(rectangleValue.ToString());
                }

                if (exactnessTrapezoid <= z)
                {
                    globalTrapezoid.Add(trapezoidValue.ToString());
                }
                
            }
            globalRectangle.AddRange(globalTrapezoid);
            listBox1.DataSource = globalRectangle;
        }
    }
}
