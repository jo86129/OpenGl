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

namespace _1042060_HW1
{
    public partial class Form1 : Form
    {
        byte[] c1 = new byte[7];
        byte[] c2 = new byte[7];
        byte[] c3 = new byte[7];
        int time = 0;
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
        private void getColor(){
            c1[0] = 142; c1[1] = 255; c1[2] = 0; c1[3] = 0; c1[4] = 255; c1[5] = 255; c1[6] = 255;
            c2[0] = 17; c2[1] = 0; c2[2] = 0; c2[3] = 255; c2[4] = 255; c2[5] = 142; c2[6] =0;
            c3[0] = 248; c3[1] = 255; c3[2] = 255; c3[3] = 0; c3[4] = 0; c3[5] = 0; c3[6] = 0;
        }
        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Random rn = new Random(1);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glPointSize(1.0f);
            Gl.glColor3ub(255, 255, 255);
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i < 200; i++)
            {
                Gl.glVertex2i(rn.Next(0, this.simpleOpenGlControl1.Size.Width),
                              rn.Next(0, this.simpleOpenGlControl1.Size.Height));
            }
            Gl.glEnd();

          //  getColor();
            //start to draw the big dipper
            //this is indigo
            Gl.glPointSize(5.0f);
            Gl.glColor3ub(c1[0],c2[0],c3[0]); 
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2i(80,100);
            Gl.glEnd();

            //this is purple
            Gl.glPointSize(5.0f);
            Gl.glColor3ub(c1[1], c2[1], c3[1]);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2i(140, 150);
            Gl.glEnd();

            //this is blue
            Gl.glPointSize(5.0f);
            Gl.glColor3ub(c1[2], c2[2], c3[2]);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2i(180, 160);
            Gl.glEnd();

            //this is green
            Gl.glPointSize(5.0f);
            Gl.glColor3ub(c1[3], c2[3], c3[3]);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2i(240, 180);
            Gl.glEnd();

            //this is yellow
            Gl.glPointSize(5.0f);
            Gl.glColor3ub(c1[4], c2[4], c3[4]);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2i(280, 150);
            Gl.glEnd();

            //this is orange
            Gl.glPointSize(5.0f);
            Gl.glColor3ub(c1[5], c2[5], c3[5]);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2i(360, 220);
            Gl.glEnd();

            //this is red
            Gl.glPointSize(5.0f);
            Gl.glColor3ub(c1[6], c2[6], c3[6]);
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glVertex2i(330, 280);
            Gl.glEnd();
         

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            time++;
            if (time % 2==1)
            {
                for(int i=0;i<7;i++)
                {
                    c1[i] = 0;
                    c2[i] = 0;
                    c3[i] = 0;
                }
               
            }
            else
            {
                getColor();
               
            }
            this.simpleOpenGlControl1.Refresh();
        }
    }
}
