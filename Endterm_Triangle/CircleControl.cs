using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Endterm_Triangle
{
    public partial class CircleControl : UserControl
    {
        private GraphicsPath path = null;
        ToolTip tp;

        public CircleControl(Point location, Color color)
        {
            this.Location = location;
            this.BackColor = color;
            this.Size = new Size(50, 50);
            Draw();
            MouseClick += button1_Click;
            tp = new ToolTip();
            tp.SetToolTip(this, $"Red - {BackColor.R}, Green - {BackColor.G}, Blue - {BackColor.B}");
        }

        public void Draw()
        {
            path = new GraphicsPath();
            path.AddEllipse(this.ClientRectangle);
            this.Region = new Region(path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (path != null)
            {
                e.Graphics.FillPath(new SolidBrush(this.BackColor), path);
                e.Graphics.DrawPath(new Pen(this.BackColor, 1), path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Red - {BackColor.R}, Green - {BackColor.G}, Blue - {BackColor.B}");
        }

    }
}
