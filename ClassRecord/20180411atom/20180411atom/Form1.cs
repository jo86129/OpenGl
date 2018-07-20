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



namespace _20180411atom
{
    public partial class Form1 : Form
    {
       double angle1;
       double angle2;
       double angle3;
       const double DEGREE_TO_RAD = 0.01745329;
       double Radius = 70.0, Longitude = -90.0, Latitude = 0.0;
       double rot=40;
       int count = 10;
       double[] xRot =new double[9];
        double[] yRot = new double[9];
        int index = 8;
        public Form1()
        {
            
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            Glut.glutInit();
        }
        private void SetViewingVolume()
        {
           
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
           double aspect = (double)simpleOpenGlControl1.Size.Width /
                            (double)simpleOpenGlControl1.Size.Height;

          //  Glu.gluPerspective(30, aspect, 10.0, 100.0);
           Glu.gluPerspective(45, aspect, 10.0, 100.0);

            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width,
                simpleOpenGlControl1.Size.Height);

        }


        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);//設定深度初始直

        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            SetViewingVolume();
            MyInit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle1 += 3;
            angle2 += 1;
            angle3 += 5;
            rot += 4;
          /*  if(count>0){
                rot +=4;
                count--;
            }
            if (count < 0)
            {
                rot -= 4;
                count++;
            }*/
            this.simpleOpenGlControl1.Refresh();

        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT| Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            //Glu.gluLookAt(0.0, 30.0, 30.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            Glu.gluLookAt(0.0, 0.0, 50.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

          /*  Glu.gluLookAt(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                     * Math.Sin(Longitude * DEGREE_TO_RAD),
              Radius * Math.Sin(Latitude * DEGREE_TO_RAD),
              Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                     * Math.Cos(Longitude * DEGREE_TO_RAD),
              0.0, 0.0, 0.0, 0.0, 1.0, 0.0);*/


            Gl.glColor3d(0.0, 1.0, 0.0);
            Glut.glutSolidSphere(2.0, 20, 20);

            // Draw the first electron
            Gl.glColor3d(0.0, 0.0, 1.0);
            Gl.glPushMatrix();
            Gl.glRotated(angle1, 1.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, 10.0);
            Glut.glutSolidSphere(1.0, 20, 20);
            Gl.glPopMatrix();

            // Draw the second electron
            Gl.glColor3d(1.0, 1.0, 0.0);
            Gl.glPushMatrix();
            Gl.glRotated(angle2, -1.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, 10.0);
            Glut.glutSolidSphere(1.0, 20, 20);
            Gl.glPopMatrix();

            // Draw the third electron
            Gl.glColor3d(0.0, 1.0, 1.0);
            Gl.glPushMatrix();
            Gl.glRotated(angle3, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, 10.0);
            Glut.glutSolidSphere(1.0, 20, 20);
            Gl.glPopMatrix();

           

           /* //太陽系
            Gl.glColor3d(1.0, 1.0, 0.0);
            Glut.glutSolidSphere(4.0, 20, 20);
            // Draw the earth
            Gl.glColor3d(0.0, 0.0, 1.0);
            Gl.glRotated(angle1, 0.0, 1.0, 0.0);
            Gl.glTranslated(20.0, 0.0, 0.0);
            Glut.glutSolidSphere(1.0, 20, 20);

            // Draw the moon
            Gl.glColor3d(0.7, 0.7, 0.6);
            Gl.glRotated(angle2, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, 2.0);
            Glut.glutSolidSphere(0.3, 20, 20);
            */

          /*  double x = 10.0;

            Gl.glRotated(rot, 0.0, 1.0, 0.0);


            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[0], 1, 0, 0);
            Gl.glRotated(yRot[0], 0, 1, 0);
            Glut.glutWireSphere(1.0, 20, 20);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(40.0, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[1], 1, 0, 0);
            Gl.glRotated(yRot[1], 0, 1, 0);
            Glut.glutWireCube(1.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(80.0, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[2], 1, 0, 0);
            Gl.glRotated(yRot[2], 0, 1, 0);
            Glut.glutWireCone(0.5,1.0,20,20);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(120.0, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[3], 1, 0, 0);
            Gl.glRotated(yRot[3], 0, 1, 0);
            Glut.glutWireTorus(0.5, 1.0, 20, 20);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(160.0, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[4], 1, 0, 0);
            Gl.glRotated(yRot[4], 0, 1, 0);
            Glut.glutWireDodecahedron();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(200.0, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[5], 1, 0, 0);
            Gl.glRotated(yRot[5], 0, 1, 0);
            Glut.glutWireOctahedron();
            Gl.glPopMatrix();


            Gl.glPushMatrix();
            Gl.glRotated(240.0, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[6], 1, 0, 0);
            Gl.glRotated(yRot[6], 0, 1, 0);
            Glut.glutWireTetrahedron();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(280.0, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[7], 1, 0, 0);
            Gl.glRotated(yRot[7], 0, 1, 0);
            Glut.glutWireIcosahedron();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(320.0, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, x);
            Gl.glRotated(xRot[8], 1, 0, 0);
            Gl.glRotated(yRot[8], 0, 1, 0);
            Glut.glutWireTeapot(0.5);
            Gl.glPopMatrix();*/


        }

        private void simpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    yRot[index] += 3;
                    Longitude -= 5.0;
                    break;
                case Keys.Right:
                    yRot[index] -= 3;
                    Longitude += 5.0;
                    break;
                case Keys.Up:
                    xRot[index] += 3;
                    Latitude += 5.0;
                   if (Latitude >= 90.0) Latitude = 89.0;
                    break;
                case Keys.Down:
                    xRot[index] -= 3;
                    Latitude -= 5.0;
                    if (Latitude <= -90.0) Latitude = -89.0;
                    break;
                case Keys.PageUp:
                    Radius += 5.0;
                    break;
                case Keys.PageDown:
                    Radius -= 5.0;
                    if (Radius < 10.0) Radius = 10.0;
                    break;
                case Keys.P:
                    //rot += 40.0;
                    index--;
                    if (index < 0) index = 8;
                    count = 10;
                    timer1.Enabled = true;
                    break;
                case Keys.N:
                    //rot -= 40.0;
                    index++;
                    if (index > 8) index = 0;
                    count = -10;
                    timer1.Enabled = true;
                    break;
                default:
                    break;
            }
            this.simpleOpenGlControl1.Refresh();

        }
    }
}
