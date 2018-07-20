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

namespace _20180516pick3dLight
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329;
        double Radius = 70.0, Longitude = -90.0, Latitude = 0.0;
        double rot = 40;
        int count = 10;
        double[] xRot = new double[9];
        double[] yRot = new double[9];
        int index = 8;
        float light0_rot = 0;
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

              Glu.gluPerspective(30, aspect, 10.0, 100.0);

            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width,
                simpleOpenGlControl1.Size.Height);

        }


        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);//設定深度初始直

            //light
            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0_diffuse = new float[] { 0.6f, 0.6f, 0.6f, 1.0f };
            float[] light0_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular);


            Gl.glShadeModel(Gl.GL_FLAT); //讓他變成一片一片的


            Gl.glEnable(Gl.GL_DEPTH_TEST);//開啟深度測試這個功能
            Gl.glEnable(Gl.GL_LIGHTING);
           Gl.glEnable(Gl.GL_LIGHT0);



        }
        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            MyInit();
            SetViewingVolume();
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

           // Glu.gluLookAt(0.0, 30.0, 30.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            Glu.gluLookAt(0.0, 45.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0);

            float[] mat_ambient = new float[3];
            float[] mat_diffuse = new float[3];
            float[] mat_specular = new float[3];
            float mat_shininess;

            float[] light0_position = new float[4] { 0.0f, 0.0f, 0.0f, 1.0f };
             float[] light0_direction = new float[] { 0.0f, 0.0f, -1.0f };

          /* 製作一個中心球 會發亮
           * Gl.glPushMatrix();
            Gl.glRotated(light0_rot,0,1,0); //依照Y軸旋轉
            Gl.glTranslated(0.0, 0.0, 7.5);
            Gl.glDisable(Gl.GL_LIGHTING); //讓這個球不售光影計算 所以把光影計算關閉
            Gl.glColor3ub(253, 200, 0);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            Glut.glutSolidSphere(0.3,16,16);
            Gl.glEnable(Gl.GL_LIGHTING); //打開光影計算
            Gl.glPopMatrix();*/


            //探照燈
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glPushMatrix();
            Gl.glRotated(light0_rot, 0.0, 1.0, 0.0);  //let the flashlight rotate
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPOT_DIRECTION, light0_direction);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, (float)(Math.Atan(0.3) * 180.0 / Math.PI));
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_EXPONENT, 10.0f);
            Gl.glColor3ub(255, 0, 0);
            Gl.glTranslated(0.0, 0.0, -1.0);
            Glut.glutSolidCone(0.3, 1.0, 10, 10);
            Gl.glColor3ub(255, 255, 0);
            Gl.glScaled(1.0, 1.0, 0.01);
            Gl.glDisable(Gl.GL_LIGHTING);
            Glut.glutSolidSphere(0.3, 10, 10);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);

          
            double x = 10.0;

            Gl.glRotated(rot, 0.0, 1.0, 0.0);


              // Brass 黃銅
              mat_ambient[0] = 0.329412f;
              mat_ambient[1] = 0.223529f;
              mat_ambient[2] = 0.027451f;
              Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat_ambient);
              mat_diffuse[0] = 0.780392f;
              mat_diffuse[1] = 0.568627f;
              mat_diffuse[2] = 0.113725f;
              Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat_diffuse);
              mat_specular[0] = 0.780392f;
              mat_specular[1] = 0.568627f;
              mat_specular[2] = 0.113725f;
              Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat_specular);
              mat_shininess = 27.8974f;
              Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, mat_shininess);


              Gl.glEnable(Gl.GL_COLOR_MATERIAL); //打開色彩材質的功能 讓glColor3d的功能出現
              Random rn = new Random(1);
              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[0], 1, 0, 0);
              Gl.glRotated(yRot[0], 0, 1, 0);
              Glut.glutSolidSphere(1.0, 20, 20);
              Gl.glPopMatrix();

              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glRotated(40.0, 0.0, 1.0, 0.0);
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[1], 1, 0, 0);
              Gl.glRotated(yRot[1], 0, 1, 0);
              Glut.glutSolidCube(1.0);
              Gl.glPopMatrix();

              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glRotated(80.0, 0.0, 1.0, 0.0);
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[2], 1, 0, 0);
              Gl.glRotated(yRot[2], 0, 1, 0);
              Glut.glutSolidCone(0.5, 1.0, 20, 20);
              Gl.glPopMatrix();

              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glRotated(120.0, 0.0, 1.0, 0.0);
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[3], 1, 0, 0);
              Gl.glRotated(yRot[3], 0, 1, 0);
              Glut.glutSolidTorus(0.5, 1.0, 20, 20);
              Gl.glPopMatrix();

              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glRotated(160.0, 0.0, 1.0, 0.0);
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[4], 1, 0, 0);
              Gl.glRotated(yRot[4], 0, 1, 0);
              Glut.glutSolidDodecahedron();
              Gl.glPopMatrix();

              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glRotated(200.0, 0.0, 1.0, 0.0);
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[5], 1, 0, 0);
              Gl.glRotated(yRot[5], 0, 1, 0);
              Glut.glutSolidOctahedron();
              Gl.glPopMatrix();

              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glRotated(240.0, 0.0, 1.0, 0.0);
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[6], 1, 0, 0);
              Gl.glRotated(yRot[6], 0, 1, 0);
              Glut.glutSolidTetrahedron();
              Gl.glPopMatrix();

              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glRotated(280.0, 0.0, 1.0, 0.0);
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[7], 1, 0, 0);
              Gl.glRotated(yRot[7], 0, 1, 0);
              Glut.glutSolidIcosahedron();
              Gl.glPopMatrix();


              Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
              Gl.glPushMatrix();
              Gl.glRotated(320.0, 0.0, 1.0, 0.0);
              Gl.glTranslated(0.0, 0.0, x);
              Gl.glRotated(xRot[8], 1, 0, 0);
              Gl.glRotated(yRot[8], 0, 1, 0);
              Gl.glFrontFace(Gl.GL_CW); //所有圖形裡面 只有茶壺是順時針法則，其他的都是逆時針法則
              Glut.glutSolidTeapot(0.5);
              Gl.glFrontFace(Gl.GL_CCW); //要把他的狀態改回逆時針法則，不改會影響到其他物件
              Gl.glPopMatrix();
              Gl.glDisable(Gl.GL_COLOR_MATERIAL); //關掉色彩材質的功能

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
                    index--;
                    if (index < 0) index = 8;
                    count = 10;
                    timer1.Enabled = true;
                    break;
                case Keys.N:
                    index++;
                    if (index > 8) index = 0;
                    count = -10;
                    timer1.Enabled = true;
                    break;
                case Keys.L:
                    light0_rot += 4;
                 
                    break;
                default:
                    break;
            }
            this.simpleOpenGlControl1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
              if(count>0){
                  rot +=4;
                  count--;
                 
              }
              if (count < 0)
              {
                  rot -= 4;
                  count++;
                  
              }
         
            this.simpleOpenGlControl1.Refresh();
        }
    }
}
