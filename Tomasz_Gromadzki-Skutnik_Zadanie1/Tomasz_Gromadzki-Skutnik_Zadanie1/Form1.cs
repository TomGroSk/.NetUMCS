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
            panel1.BringToFront();
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
            panel6.BringToFront();
        }
        private void zadanie7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel7.BringToFront();
        }
        private void zadanie8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel8.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            double m = double.Parse(text1);
            double z = double.Parse(text2);
            Random random = new Random();
            List<string> globalData = new List<string>();
            double exactValue = Math.Pow(100, 3) / 3.0;

            globalData.Add("Rectangle:");
            globalData.Add("");
            globalData.AddRange(Calculation.GetAllValuesDiffFromZ(z, m, exactValue, AreaType.Rectangle));
            globalData.Add("");
            globalData.Add("Trapezoid:");
            globalData.Add("");
            globalData.AddRange(Calculation.GetAllValuesDiffFromZ(z, m, exactValue, AreaType.Trapezoid));

            listBox1.DataSource = globalData;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox3.Text;
            double z = double.Parse(text);
            Random random = new Random();
            double exactValue = Math.Pow(100, 4) / 4.0;
            List<string> globalData = new List<string>();

            globalData.Add("Rectangle: ");
            globalData.Add(Calculation.FindNDiffFromZ(z, exactValue, AreaType.Rectangle));
            globalData.Add("Trapezoid: ");
            globalData.Add(Calculation.FindNDiffFromZ(z, exactValue, AreaType.Trapezoid));
            globalData.Add("");
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
            List<string> finalData = new List<string>();

            SingleCount singleCountRectangle = new SingleCount(x1, x2, n, AreaType.Rectangle, 0, 1);
            SingleCount singleCountTrapezoid = new SingleCount(x1, x2, n, AreaType.Trapezoid, 0, 1);
            Global globalRectangleValue = Calculation.calculateIntegral(singleCountRectangle, x => x * x);
            Global globalTrapezoidValue = Calculation.calculateIntegral(singleCountTrapezoid, x => x * x);

            for (int i = 0; i < n; i++)
            {
                tempResult += Math.Pow((globalRectangleValue.SingleCountsList[i].Area - globalTrapezoidValue.SingleCountsList[i].Area), 2);
            }

            finalData.Add("Błąd średniokwadratowy dla n równego - " + n.ToString());
            finalData.Add((tempResult / n).ToString());
            listBox3.DataSource = finalData;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text1 = textBox6.Text;
            string text2 = textBox7.Text;
            string text3 = textBox8.Text;
            string text4 = textBox9.Text;

            double z = double.Parse(text3);
            int n = (int)Math.Pow(10, int.Parse(text4));
            double x1 = double.Parse(text2);
            double x2 = double.Parse(text1);

            List<string> globalData = new List<string>();
            globalData.Add("Rectangle:");
            globalData.Add(Calculation.FindX1X2DivByZ(x1, x2, n, z, AreaType.Rectangle));
            globalData.Add("Trapezoid:");
            globalData.Add(Calculation.FindX1X2DivByZ(x1, x2, n, z, AreaType.Trapezoid));

            listBox4.DataSource = globalData;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text1 = textBox11.Text;
            int n = (int)Math.Pow(10, int.Parse(text1));

            List<string> globalRectangle = new List<string>();
            List<string> globalTrapezoid = new List<string>();
            globalRectangle.Add("Rectangle:");
            globalTrapezoid.Add("Trapezoid:");

            globalRectangle.Add(Calculation.FindX1X2ForFunctionValuesEquality(n, AreaType.Rectangle));
            globalTrapezoid.Add(Calculation.FindX1X2ForFunctionValuesEquality(n, AreaType.Trapezoid));

            globalRectangle.AddRange(globalTrapezoid);
            listBox5.DataSource = globalRectangle;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text1 = textBox10.Text;
            string text2 = textBox12.Text;
            int m = int.Parse(text1);
            int n = (int)Math.Pow(10, int.Parse(text2));
            Random random = new Random();
            List<string> globalData = new List<string>();

            globalData.Add("Rectangle:");
            globalData.Add(Calculation.FindMinDiff(m, n, AreaType.Rectangle));
            globalData.Add("");
            globalData.Add("Trapezoid:");
            globalData.Add(Calculation.FindMinDiff(m, n, AreaType.Trapezoid));

            listBox6.DataSource = globalData;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double x1 = double.Parse(textBox16.Text);
            double x2 = double.Parse(textBox15.Text);
            double z = double.Parse(textBox13.Text);
            List<string> globalData = new List<string>();

            if (x1 == x2)
            {
                globalData.Add("0");
                listBox7.DataSource = globalData;
                return;
            }

            globalData.Add("Rectangle:");
            globalData.Add(Calculation.FindFirstNDivideByZ(x1, x2, z, AreaType.Rectangle));
            globalData.Add("Trapezoid:");
            globalData.Add(Calculation.FindFirstNDivideByZ(x1, x2, z, AreaType.Trapezoid));
            listBox7.DataSource = globalData;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            double z = double.Parse(textBox14.Text);
            double x2 = Math.PI / 2;
            double exactValue = Math.Sin(x2);
            List<string> globalData = new List<string>
            {
                "Rectangle: ",
                Calculation.FindFirstN(x2, z, exactValue, AreaType.Rectangle),

                "Trapezoid: ",
                Calculation.FindFirstN(x2, z, exactValue, AreaType.Trapezoid)
            };

            listBox8.DataSource = globalData;
        }
    }
}
