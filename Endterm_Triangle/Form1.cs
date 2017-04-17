using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Endterm_Triangle
{
    public partial class Form1 : Form
    {
        Point location1 = new Point(30, 30);
        Point location2 = new Point(130, 30);
        Point location3 = new Point(80, 130);

        Color color1;
        Color color2;
        Color color3;
        public Form1()
        {
            InitializeComponent();

           
        }

        void DrawCircles()
        {
            List<CircleControl> circleControls = new List<CircleControl>();


            List<List<Color>> sample = GetColorMatrix(color1, color2, color3, 9);

            int x0 = 90;
            int round = 0;
            int x = 90, y = 30;
            foreach (var list in sample)
            {
                foreach (var color in list)
                {
                    Point location = new Point(x, y);
                    circleControls.Add(new CircleControl(location, color));

                    x += 50;
                }
                x = x0 + (round * 5);
                y += 50;
            }


            foreach (var shade in circleControls)
            {
                this.Controls.Add(shade);
            }
        }

        static List<List<Color>> GetColorMatrix(Color c1, Color c2, Color c3, int parts)
        {
            parts = 9;

            List<List<Color>> colorMatrix = new List<List<Color>>();

            var c1c2 = MakeColors(c1, c2, parts);
            var c2c3 = MakeColors(c2, c3, parts);
            var c1c3 = MakeColors(c1, c3, parts);

            colorMatrix.Add(c1c2);

            int j = 1;

            for (int i = parts - 1; i > 0 && j < c1c3.Count; i--)
            {
                colorMatrix.Add(MakeColors(c1c3[j], c2c3[j], i));
                j++;
            }

            return colorMatrix;
        }

       static List<Color> MakeColors(Color color1, Color color2, int parts)
        {
            List<Color> colList = new List<Color>();
            colList.Add(color1);

            int deltaR = (color2.R - color1.R) / parts;
            int deltaG = (color2.G - color1.G) / parts;
            int deltaB = (color2.B - color1.B) / parts;

            for (int i = 1; i < parts; i++)
            {
                Color prevCol = colList[i - 1];

                int currentR = Math.Abs(deltaR + prevCol.R) % 255;
                int currentB = Math.Abs(deltaB + prevCol.B) % 255;
                int currentG = Math.Abs(deltaG + prevCol.G) % 255;

                colList.Add(Color.FromArgb(currentR, currentG, currentB));
            }
            return colList;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color1 = colorDialog1.Color;
            button1.BackColor = color1;
        }
         
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            color3 = colorDialog3.Color;
            button3.BackColor = color3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            color2 = colorDialog2.Color;
            button2.BackColor = color2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawCircles();
        }
    }
}
