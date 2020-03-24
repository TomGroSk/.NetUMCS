using System;
using System.Collections.Generic;
using System.Linq;
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
            panel3.BringToFront();
        }
        private void zadanie4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
        }
        private void zadanie5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel5.BringToFront();
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
            globalRectangle.Add("");
            globalTrapezoid.Add("");
            globalTrapezoid.Add("Trapezoid:");
            globalTrapezoid.Add("");
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

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox3.Text;
            double z = double.Parse(text);
            Random random = new Random();
            double exactValue = Math.Pow(100, 4) / 4.0;
            List<string> globalData = new List<string>();
            int i = 0;

            while(true)
            {
                SingleCount singleCountRectangle = new SingleCount(0, 100, random.Next(10, 100000), AreaType.Rectangle, 0, 1);
                double rectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => x * x * x).SingleCountsList.Last().Area;
                double exactnessRectangle = Math.Abs(exactValue - rectangleValue) / exactValue * 100;

                if (exactnessRectangle > z)
                {
                    globalData.Add("Rectangle: ");
                    globalData.Add(i.ToString());
                    break;
                }

                i++;
            }

            i = 0;
            while (true)
            {
                SingleCount singleCountTrapezoid = new SingleCount(0, 100, random.Next(10, 100000), AreaType.Trapezoid, 0, 1);
                double trapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x * x).SingleCountsList.Last().Area;
                double exactnessTrapezoid = Math.Abs(exactValue - trapezoidValue) / exactValue * 100;

                if (exactnessTrapezoid > z)
                {
                    globalData.Add("Trapezoid: ");
                    globalData.Add(i.ToString());
                    break;
                }
                i++;

            }
            listBox2.DataSource = globalData;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text1 = textBox4.Text;
            string text2 = textBox5.Text;
            double x1 = double.Parse(text1);
            double x2 = double.Parse(text2);
            Random random = new Random();
            int n = random.Next(10, 1000000);
            double tempResult = 0;
            List<string> data = new List<string>();

            SingleCount singleCountRectangle = new SingleCount(x1, x2, n, AreaType.Rectangle, 0, 1);
            SingleCount singleCountTrapezoid = new SingleCount(x1, x2, n, AreaType.Trapezoid, 0, 1);
            Global globalRectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => x * x);
            Global globalTrapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x);

            for(int i = 0; i < n; i++)
            {
                tempResult += Math.Pow((globalRectangleValue.SingleCountsList[i].Area - globalTrapezoidValue.SingleCountsList[i].Area),2);
            }

            data.Add("Błąd średniokwadratowy dla n równego - " + n.ToString());
            data.Add((tempResult / n).ToString());
            listBox3.DataSource = data;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //6 7 8 9 listbox4

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text1 = textBox11.Text;
        }
    }
}
