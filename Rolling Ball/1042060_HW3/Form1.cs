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
using Tao.FreeGlut;

namespace _1042060_HW3
{
    public partial class Form1 : Form
    {
        double cx=0, cy=0, cz=0; //ball's position
        double dx=2, dy=1, dz=3; //ball translate distance
        double rot=3; //rotate angel
        double radius = 1;
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();

            Glut.glutInit();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            setViewingVolumn();
            MyInt();
        }
        private void MyInt()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }
        private void setViewingVolumn()
        {
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width,
              simpleOpenGlControl1.Size.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect = (double)simpleOpenGlControl1.Size.Width /
                            (double)simpleOpenGlControl1.Size.Height;

            Glu.gluPerspective(45, aspect, 0.0, 20.0);
        }
        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
           
            Gl.glMatrixMode(Gl.GL_MODELVIEW); //這個矩陣是用來平移旋轉縮放
            Gl.glLoadIdentity();
            Glu.gluLookAt(0.0,0.0,20.0,0.0,0.0,0.0,0.0,1.0,0.0); //camera location  3-location  3-look at 3-攝影機的方向

            //draw the walls
            Gl.glBegin(Gl.GL_QUADS); //建議逆時針畫
            //Gl.glColor3ub(255, 174, 201);     //pink
            Gl.glColor3ub(239, 228, 176);     //yellow
            Gl.glVertex3d(10.0, 10.0, -10.0);
            Gl.glVertex3d(10.0, 10.0, 10.0);
            Gl.glVertex3d(10.0, -10.0, 10.0);
            Gl.glVertex3d(10.0,-10.0, -10.0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS); //建議逆時針畫
            Gl.glColor3ub(239,228,176);     //yellow
            Gl.glVertex3d(-10.0, 10.0, -10.0);
            Gl.glVertex3d(-10.0, 10.0, 10.0);
            Gl.glVertex3d(-10.0, -10.0, 10.0);
            Gl.glVertex3d(-10.0, -10.0, -10.0);
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS); //建議逆時針畫
            Gl.glColor3ub(153,217,234);     //blue
            Gl.glVertex3d(10.0, 10.0, -10.0);
            Gl.glVertex3d(-10.0, 10.0, -10.0);
            Gl.glVertex3d(-10.0, 10.0, 10.0);
            Gl.glVertex3d(10.0, 10.0, 10.0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS); //建議逆時針畫
            Gl.glColor3ub(153, 217, 234);     //blue
            Gl.glVertex3d(10.0, -10.0, -10.0);
            Gl.glVertex3d(-10.0, -10.0, -10.0);
            Gl.glVertex3d(-10.0, -10.0, 10.0);
            Gl.glVertex3d(10.0, -10.0, 10.0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS); //建議逆時針畫
            Gl.glColor3ub(200,191,231);     //purple
            Gl.glVertex3d(10.0, 10.0, -10.0);
            Gl.glVertex3d(-10.0, 10.0, -10.0);
            Gl.glVertex3d(-10.0, -10.0, -10.0);
            Gl.glVertex3d(10.0, -10.0, -10.0);
            Gl.glEnd();


            //the circle
            Gl.glPushMatrix();
            Gl.glColor3ub(243,95,121);//pink
            Gl.glTranslated(cx,cy,cz);
            Gl.glRotated(rot,1,1,1);
            Glut.glutWireSphere(radius, 20, 20);
            Gl.glPopMatrix();




        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            setViewingVolumn();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cx + radius >= 10 || cx - radius <= -10)
            {
                
                dx = -dx;
            }
            if (cy + radius >= 10 || cy - radius <= -10)
            {
             
                dy = -dy;
            }
            if (cz + radius >= 10 || cz - radius <= -10)
            {
               
                dz = -dz;
            }
            rot += 3;
            cx += dx;
            cy += dy;
            cz += dz;
            this.simpleOpenGlControl1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Interval<=30)
            {

            }
            else
            {
                timer1.Interval -= 30;
                this.simpleOpenGlControl1.Refresh();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Interval += 30;
            this.simpleOpenGlControl1.Refresh();
        }
    }
}
