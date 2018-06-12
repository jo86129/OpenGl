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

namespace _1042060_HW2
{
    public partial class Form1 : Form
    {
        private double num = 1.0;

        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            label1.Text = num.ToString();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            

            Gl.glMatrixMode(Gl.GL_PROJECTION);
             Random ran = new Random();
            //sin
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-Math.PI * num, Math.PI * num, -2, 2); //圖的範圍
            Gl.glViewport(0, this.simpleOpenGlControl1.Height / 2, this.simpleOpenGlControl1.Width / 3, this.simpleOpenGlControl1.Height / 2);
            Gl.glLineWidth(1.5f);
            Gl.glColor3ub((byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)));
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = -Math.PI * num; x < Math.PI * num; x += 0.005) //每隔0.005取樣一次
            {
                double fx=Math.Sin(x);
                Gl.glVertex2d(x, fx);
            }
            Gl.glEnd();

          


            //cos
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-Math.PI * num, Math.PI * num, -2, 2); //圖的範圍
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Width / 3, this.simpleOpenGlControl1.Height / 2);
            Gl.glLineWidth(1.5f);
            Gl.glColor3ub((byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)));
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = -Math.PI * num; x < Math.PI * num; x += 0.005) //每隔0.005取樣一次
            {
                double fx = Math.Cos(x);
                Gl.glVertex2d(x, fx);
            }
            Gl.glEnd();

            //tan
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-Math.PI * num, Math.PI * num, -2, 2); //圖的範圍
            Gl.glViewport(this.simpleOpenGlControl1.Width/3, this.simpleOpenGlControl1.Height/2, this.simpleOpenGlControl1.Width / 3, this.simpleOpenGlControl1.Height / 2);
            Gl.glLineWidth(1.5f);
            Gl.glColor3ub((byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)));
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = -Math.PI * num; x < Math.PI * num; x += 0.005) //每隔0.005取樣一次
            {
                double fx = Math.Tan(x);
                if(Math.Abs(Math.Tan(x)-Math.Tan(x-0.01))>0.1)
                {
                    Gl.glEnd();
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                }
                else
                {
                    Gl.glVertex2d(x, fx); 
                } 
            }
            Gl.glEnd();

            //cot
            Gl.glColor3ub((byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)));
            for (int i = 0; i < Math.Truncate(num); i++)
            {
                Gl.glLoadIdentity();
                Gl.glViewport(this.simpleOpenGlControl1.Size.Width / 3 + this.simpleOpenGlControl1.Size.Width / 3 / Convert.ToInt32(Math.Truncate(num)) * i, 0, this.simpleOpenGlControl1.Size.Width / 3 / Convert.ToInt32(Math.Truncate(num)), this.simpleOpenGlControl1.Size.Height / 2);
                Glu.gluOrtho2D(-Math.PI, Math.PI, -2.0f, 2.0f);
                
                Gl.glLineWidth(1.5f);
                Gl.glBegin(Gl.GL_LINE_STRIP); 
                for (double x = -Math.PI; x < 0; x += 0.005)
                {
                    double fx = 1 / Math.Tan(x);
                    Gl.glVertex2d(x, fx);
                }
                for (double x = 0; x < Math.PI; x += 0.005)
                {
                    double fx = 1 / Math.Tan(x);
                    Gl.glVertex2d(x, fx);
                }
                Gl.glEnd();
            }




            //sec
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-Math.PI * num, Math.PI * num, -2, 2); //圖的範圍
            Gl.glViewport(this.simpleOpenGlControl1.Width*2 / 3, this.simpleOpenGlControl1.Height/2, this.simpleOpenGlControl1.Width / 3, this.simpleOpenGlControl1.Height / 2);
            Gl.glColor3ub((byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)));
            Gl.glLineWidth(1.5f);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = -Math.PI * num; x < Math.PI * num; x += 0.005) //每隔0.005取樣一次
            {
                if (Math.Abs(Math.Tan(x) - Math.Tan(x - 0.01)) > 0.1)
                {
                    Gl.glEnd();
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                }
                else
                {
                    double fx = 1 / Math.Cos(x);
                    Gl.glVertex2d(x, fx);
                }

            }
            Gl.glEnd();



            //csc
            Gl.glColor3ub((byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)), (byte)(ran.Next(0, 255)));
            for (int i = 0; i < Math.Truncate(num); i++)
            {
                Gl.glLoadIdentity();
                Gl.glViewport(this.simpleOpenGlControl1.Size.Width / 3*2 + this.simpleOpenGlControl1.Size.Width / 3 / Convert.ToInt32(Math.Truncate(num)) * i, 0, this.simpleOpenGlControl1.Size.Width / 3 / Convert.ToInt32(Math.Truncate(num)), this.simpleOpenGlControl1.Size.Height / 2);
                Glu.gluOrtho2D(-Math.PI, Math.PI, -2.0f, 2.0f);
                Gl.glLineWidth(1.5f);
                Gl.glBegin(Gl.GL_LINE_STRIP);
                for (double x = -Math.PI; x < 0; x += 0.005)
                {
                    double fx = 1 / Math.Sin(x);
                    Gl.glVertex2d(x, fx);
                }
                for (double x = 0; x < Math.PI; x += 0.005)
                {
                    double fx = 1 / Math.Sin(x);
                    Gl.glVertex2d(x, fx);
                }
                Gl.glEnd();
            }

          
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Gl.glClearColor(1.0f,1.0f, 1.0f, 1.0f);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-Math.PI, Math.PI, -2, 2);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            num -= 0.1;
            label1.Text = num.ToString();
            this.simpleOpenGlControl1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            num += 0.1;
            label1.Text = num.ToString();
            this.simpleOpenGlControl1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.simpleOpenGlControl1.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
