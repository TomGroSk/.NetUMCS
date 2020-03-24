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

            while (true)
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
            List<string> finalData = new List<string>();

            SingleCount singleCountRectangle = new SingleCount(x1, x2, n, AreaType.Rectangle, 0, 1);
            SingleCount singleCountTrapezoid = new SingleCount(x1, x2, n, AreaType.Trapezoid, 0, 1);
            Global globalRectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => x * x);
            Global globalTrapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x);

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

            List<string> globalRectangle = new List<string>();
            List<string> globalTrapezoid = new List<string>();
            globalRectangle.Add("Rectangle:");
            globalTrapezoid.Add("Trapezoid:");

            double z = double.Parse(text3);
            int n = (int)Math.Pow(10, int.Parse(text4));
            double x1 = double.Parse(text2);
            double x2 = double.Parse(text1);


            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < x2; j++)
                {
                    SingleCount singleCountRectangle = new SingleCount(i, j, n, AreaType.Rectangle, 0, 1);
                    SingleCount singleCountTrapezoid = new SingleCount(i, j, n, AreaType.Trapezoid, 0, 1);
                    double rectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => x * x * x).SingleCountsList.Last().Area;
                    double trapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x * x).SingleCountsList.Last().Area;

                    if (Math.Round(rectangleValue) % z == 0 && globalRectangle.Count() == 1 && Math.Round(rectangleValue) != 0)
                    {
                        globalRectangle.Add("X1: " + i.ToString() + "   X2: " + j.ToString());

                    }
                    if (Math.Round(trapezoidValue) % z == 0 && globalTrapezoid.Count() == 1 && Math.Round(trapezoidValue) != 0)
                    {
                        globalTrapezoid.Add("X1: " + i.ToString() + "   X2: " + j.ToString());
                    }

                    if (globalRectangle.Count() == 2 && globalTrapezoid.Count() == 2)
                    {
                        globalRectangle.AddRange(globalTrapezoid);
                        listBox4.DataSource = globalRectangle;
                        return;
                    }
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text1 = textBox11.Text;
            int n = (int)Math.Pow(10, int.Parse(text1));
            bool rectangleFlag = false;
            bool trapezoidFlag = false;

            List<string> globalRectangle = new List<string>();
            List<string> globalTrapezoid = new List<string>();
            globalRectangle.Add("Rectangle:");
            globalTrapezoid.Add("Trapezoid:");

            int i = 0;
            while (true)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!rectangleFlag)
                    {
                        SingleCount singleCountRectangle = new SingleCount(i, j, n, AreaType.Rectangle, 0, 1);
                        double rectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => x * x * x).SingleCountsList.Last().Area;
                        singleCountRectangle = new SingleCount(i, j, n, AreaType.Rectangle, 0, 1);
                        double rectangleValue2 = Calculation.CoronaDidIt(singleCountRectangle, x => x * x).SingleCountsList.Last().Area;
                        if (rectangleValue == rectangleValue2)
                        {
                            globalRectangle.Add("X1: " + i.ToString() + "   X2: " + j.ToString());
                            rectangleFlag = true;
                            continue;
                        }
                    }
                    if (!trapezoidFlag)
                    {
                        SingleCount singleCountTrapezoid = new SingleCount(i, j, n, AreaType.Trapezoid, 0, 1);
                        double trapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x * x).SingleCountsList.Last().Area;
                        singleCountTrapezoid = new SingleCount(i, j, n, AreaType.Trapezoid, 0, 1);
                        double trapezoidValue2 = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x).SingleCountsList.Last().Area;
                        if (trapezoidValue == trapezoidValue2)
                        {
                            globalTrapezoid.Add("X1: " + i.ToString() + "   X2: " + j.ToString());
                            trapezoidFlag = true;
                        }
                    }
                    if (rectangleFlag && trapezoidFlag) break;
                }
                i++;
                if (rectangleFlag && trapezoidFlag) break;
            }

            globalRectangle.AddRange(globalTrapezoid);
            listBox5.DataSource = globalRectangle;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text1 = textBox10.Text;
            string text2 = textBox12.Text;
            int m = int.Parse(text1);
            int n = (int)Math.Pow(10, int.Parse(text2));
            double minRectangle = double.MaxValue;
            double minTrapezoid = double.MaxValue;
            Random random = new Random();
            List<string> globalRectangle = new List<string>();
            List<string> globalTrapezoid = new List<string>();
            globalRectangle.Add("Rectangle:");
            globalTrapezoid.Add("");
            globalTrapezoid.Add("Trapezoid:");

            for (int i = 0; i < m; i++)
            {
                var tuple = new Tuple<double, double>(random.Next(10, 1000000), random.Next(10, 1000000));
                SingleCount singleCountRectangle = new SingleCount(tuple.Item1, tuple.Item2, n, AreaType.Rectangle, 0, 1);
                SingleCount singleCountTrapezoid = new SingleCount(tuple.Item1, tuple.Item2, n, AreaType.Trapezoid, 0, 1);
                double rectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => x * x * x).SingleCountsList.Last().Area;
                double trapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x * x).SingleCountsList.Last().Area;
                double rectangleValue2 = Calculation.CoronaDidIt(singleCountRectangle, x => x * x).SingleCountsList.Last().Area;
                double trapezoidValue2 = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x).SingleCountsList.Last().Area;

                double rectangleDiffValue = (rectangleValue2 - rectangleValue);
                double trapezoidDiffValue = (trapezoidValue2 - trapezoidValue);
                if (rectangleDiffValue < minRectangle)
                {
                    minRectangle = rectangleDiffValue;
                }
                if (trapezoidDiffValue < minTrapezoid)
                {
                    minTrapezoid = trapezoidDiffValue;
                }
            }

            globalRectangle.Add(minRectangle.ToString());
            globalTrapezoid.Add(minTrapezoid.ToString());
            globalRectangle.AddRange(globalTrapezoid);
            listBox6.DataSource = globalRectangle;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double x1 = double.Parse(textBox16.Text);
            double x2 = double.Parse(textBox15.Text);
            double z = double.Parse(textBox13.Text);
            List<string> globalRectangle = new List<string>();
            List<string> globalTrapezoid = new List<string>();
            globalRectangle.Add("Rectangle:");
            globalTrapezoid.Add("Trapezoid:");

            int i = 0;
            while(true)
            {
                SingleCount singleCountRectangle = new SingleCount(x1, x2, i, AreaType.Rectangle, 0, 1);
                SingleCount singleCountTrapezoid = new SingleCount(x1, x2, i, AreaType.Trapezoid, 0, 1);
                double rectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => x * x).SingleCountsList.Last().Area;
                double trapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => x * x).SingleCountsList.Last().Area;

                if (Math.Round(rectangleValue) % z == 0 && globalRectangle.Count() == 1 && Math.Round(rectangleValue) != 0)
                {
                    globalRectangle.Add("N: " + i.ToString());

                }
                if (Math.Round(trapezoidValue) % z == 0 && globalTrapezoid.Count() == 1 && Math.Round(trapezoidValue) != 0)
                {
                    globalTrapezoid.Add("N: " + i.ToString());
                }

                if (globalRectangle.Count() == 2 && globalTrapezoid.Count() == 2)
                {
                    globalRectangle.AddRange(globalTrapezoid);
                    listBox7.DataSource = globalRectangle;
                    return;
                }

                i++;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double z = double.Parse(textBox14.Text);
            double x2 = Math.PI / 2;
            double exactValue = Math.Sin(x2);
            List<string> globalData = new List<string>();
            bool rectangleFlag = false, trapezoidFlag = false;
            int i = 0;
            while (true)
            {
                if (!rectangleFlag)
                {
                    SingleCount singleCountRectangle = new SingleCount(0, x2, i, AreaType.Rectangle, 0, 1);
                    double rectangleValue = Calculation.CoronaDidIt(singleCountRectangle, x => Math.Cos(x)).SingleCountsList.Last().Area;
                    double exactnessRectangle = Math.Abs(exactValue - rectangleValue) / exactValue * 100;

                    if (exactnessRectangle > z)
                    {
                        globalData.Add("Rectangle: ");
                        globalData.Add(i.ToString());
                        rectangleFlag = true;
                    }
                }
                if (!trapezoidFlag)
                {
                    SingleCount singleCountTrapezoid = new SingleCount(0, x2, i, AreaType.Trapezoid, 0, 1);
                    double trapezoidValue = Calculation.CoronaDidIt(singleCountTrapezoid, x => Math.Cos(x)).SingleCountsList.Last().Area;
                    double exactnessTrapezoid = Math.Abs(exactValue - trapezoidValue) / exactValue * 100;

                    if (exactnessTrapezoid > z)
                    {
                        globalData.Add("Trapezoid: ");
                        globalData.Add(i.ToString());
                        trapezoidFlag = true;
                    }
                }
                if (trapezoidFlag && rectangleFlag) break;
                i++;
            }
            listBox8.DataSource = globalData;
        }
    }
}
