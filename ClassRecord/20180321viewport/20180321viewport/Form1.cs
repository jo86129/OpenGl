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
namespace _20180321viewport
{
    public partial class Form1 : Form
    {
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
          //  Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);
            Glu.gluOrtho2D(0.0f,4.0 , -1.0f,1.0 );
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
          /*  Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = 0.0; x < 4.0; x += 0.005) //每隔0.005取樣一次
            {
                double fx = Math.Exp(-x) * Math.Cos(2.0 * Math.PI * x);
                Gl.glVertex2d(x, fx);
            }
            Gl.glEnd();*/
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, 4.0, -1.0, 1.0); //正常圖形
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width / 2, simpleOpenGlControl1.Size.Height / 2);
            //繪製函數f(x)的圖形
             Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = 0.0; x < 4.0; x += 0.005) //每隔0.005取樣一次
            {
                double fx = Math.Exp(-x) * Math.Cos(2.0 * Math.PI * x);
                Gl.glVertex2d(x, fx);
            }
            Gl.glEnd();


            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, 4.0, 1.0, -1.0); //上下顛倒
            Gl.glViewport(simpleOpenGlControl1.Size.Width / 2, 0, simpleOpenGlControl1.Size.Width / 2, simpleOpenGlControl1.Size.Height / 2);
            //繪製函數f(x)的圖形
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = 0.0; x < 4.0; x += 0.005) //每隔0.005取樣一次
            {
                double fx = Math.Exp(-x) * Math.Cos(2.0 * Math.PI * x);
                Gl.glVertex2d(x, fx);
            }
            Gl.glEnd();



            Gl.glLoadIdentity();
            Glu.gluOrtho2D(4.0, 0.0, -1.0, 1.0); //左右顛倒
            Gl.glViewport(0, simpleOpenGlControl1.Size.Height / 2, simpleOpenGlControl1.Size.Width / 2, simpleOpenGlControl1.Size.Height / 2);
            //繪製函數f(x)的圖形
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = 0.0; x < 4.0; x += 0.005) //每隔0.005取樣一次
            {
                double fx = Math.Exp(-x) * Math.Cos(2.0 * Math.PI * x);
                Gl.glVertex2d(x, fx);
            }
            Gl.glEnd();



            Gl.glLoadIdentity();
            Glu.gluOrtho2D(4.0, 0.0, 1.0, -1.0); //上下左右都顛倒
            Gl.glViewport(this.simpleOpenGlControl1.Size.Width / 2, simpleOpenGlControl1.Size.Height / 2, simpleOpenGlControl1.Size.Width / 2, simpleOpenGlControl1.Size.Height / 2);
            //繪製函數f(x)的圖形
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (double x = 0.0; x < 4.0; x += 0.005) //每隔0.005取樣一次
            {
                double fx = Math.Exp(-x) * Math.Cos(2.0 * Math.PI * x);
                Gl.glVertex2d(x, fx);
            }
            Gl.glEnd();




        }
    }
}
