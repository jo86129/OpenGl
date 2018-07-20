using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
namespace _20180321star_spin
{
    public partial class Form1 : Form
    {
        double radius = 50.0;
        double cx=100.0;
        double cy=100.0;
        double xstep = 3, ystep = 3;
        double rot;
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Gl.glClearColor(1.0f, 0.0f, 1.0f, 1.0f);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);       
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
        }
        private void Sierpinski(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            int[,] T = new int[3, 2];
            Random rn = new Random();
            int index = rn.Next(0, 3);
            int[] point = new int[2];

            T[0, 0] = x1; T[0, 1] = y1;
            T[1, 0] = x2; T[1, 1] = y2;
            T[2, 0] = x3; T[2, 1] = y3;

            point[0] = T[index, 0]; point[1] = T[index, 1];
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i < 3000; i++)
            {
                index = rn.Next(0, 3);
                point[0] = (point[0] + T[index, 0]) / 2;
                point[1] = (point[1] + T[index, 1]) / 2;
                Gl.glVertex2i(point[0], point[1]);
            }
            Gl.glEnd();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            int x1, y1, x2, y2, x3, y3;

            x1 = (int)(cx + radius * Math.Cos(rot * Math.PI / 180.0));
            y1 = (int)(cy + radius * Math.Sin(rot * Math.PI / 180.0));
            x2 = (int)(cx + radius * Math.Cos((rot + 120.0) * Math.PI / 180.0));
            y2 = (int)(cy + radius * Math.Sin((rot + 120.0) * Math.PI / 180.0));
            x3 = (int)(cx + radius * Math.Cos((rot - 120.0) * Math.PI / 180.0));
            y3 = (int)(cy + radius * Math.Sin((rot - 120.0) * Math.PI / 180.0));
            Sierpinski(x1, y1, x2, y2, x3, y3);
            x1 = (int)(cx + radius * Math.Cos((rot + 180.0) * Math.PI / 180.0));
            y1 = (int)(cy + radius * Math.Sin((rot + 180.0) * Math.PI / 180.0));
            x2 = (int)(cx + radius * Math.Cos((rot + 120.0 + 180.0) * Math.PI / 180.0));
            y2 = (int)(cy + radius * Math.Sin((rot + 120.0 + 180.0) * Math.PI / 180.0));
            x3 = (int)(cx + radius * Math.Cos((rot - 120.0 + 180.0) * Math.PI / 180.0));
            y3 = (int)(cy + radius * Math.Sin((rot - 120.0 + 180.0) * Math.PI / 180.0));
            Sierpinski(x1, y1, x2, y2, x3, y3);

            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < 360; i += 3)
                Gl.glVertex2d(cx + radius * Math.Cos(i * Math.PI / 180.0), cy + radius * Math.Sin(i * Math.PI / 180.0));
            Gl.glEnd();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rn=new Random();

            if (cx + radius > this.simpleOpenGlControl1.Size.Width || cx - radius < 0)
            {
                Gl.glColor3ub((byte)rn.Next(0, 256), (byte)rn.Next(0, 256), (byte)rn.Next(0, 256));
                xstep = -xstep;
            }
            if (cy + radius > this.simpleOpenGlControl1.Size.Height || cy - radius < 0)
            {
                Gl.glColor3ub((byte)rn.Next(0, 256), (byte)rn.Next(0, 256), (byte)rn.Next(0, 256));
                ystep = -ystep;
            }


            rot += 3;
            cx += xstep;
            cy += xstep;


            this.simpleOpenGlControl1.Refresh();
        }

    }
}
