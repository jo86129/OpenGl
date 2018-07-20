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

namespace openGL
{
    public partial class Form1 : Form
    {
        int[,] points = new int[300, 2];
        int numPoints = 0;
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
        }
        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);

        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            /*
             第二個範例 sierpinski
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);// 清除繪圖產生器
            Sierpinski(100,100,400,100,250,400);
             */
            /*
             第一個範例
            Random rn = new Random(); //這裡使產生星空圖
            Gl.glPointSize(3.0f);
            Gl.glColor3ub(255, 0, 255);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);// 清除繪圖產生器
            
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i < 200; i++)
            {
                Gl.glVertex2i(rn.Next(0, this.simpleOpenGlControl1.Size.Width),
                              rn.Next(0, this.simpleOpenGlControl1.Size.Height));
            }
            Gl.glEnd();
            */

            Random rn = new Random(0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            for (int i = 0; i < numPoints / 3; i++)
            {
                byte R, G, B;
                R = (byte)(rn.Next(0, 256));
                G = (byte)(rn.Next(0, 256));
                B = (byte)(rn.Next(0, 256));
                Gl.glColor3ub(R, G, B); //隨機設定Sierpinski三角形的顏色
                Sierpinski(points[3 * i, 0], points[3 * i, 1], points[3 * i + 1, 0], points[3 * i + 1, 1],
                           points[3 * i + 2, 0], points[3 * i + 2, 1]);
            }


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

        private void simpleOpenGlControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                if(numPoints<300)
                {
                    points[numPoints, 0] = e.X;
                    points[numPoints, 1] = this.simpleOpenGlControl1.Size.Height-e.Y;
                    numPoints++;
                }
               
            }
            if (e.Button == MouseButtons.Right)
            {
                numPoints = 0;
            }
            this.simpleOpenGlControl1.Refresh();//從新繪製圖片
        }


     
    }
}
