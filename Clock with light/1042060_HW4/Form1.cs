using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace _1042060_HW4
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180
        double Radius = 30.0, Longitude = -90.0, Latitude = 0.0;
        bool MainLightOn = true,lightOneOn=false,lightTwoOn=false,lightThreeOn=false,lightFourOn=false;
       
       
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            Glut.glutInit();
        }
        private void setViewVolumne()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            double aspect = (double)simpleOpenGlControl1.Size.Width /
                             (double)simpleOpenGlControl1.Size.Height;

            Glu.gluPerspective(45, aspect, 0.1, 100.0);

            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width,
                simpleOpenGlControl1.Size.Height);
        }
        private void myInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);//設定深度初始直

            float[] global_ambient = new float[] { 0.05f, 0.05f, 0.05f, 1.0f };


            float[] light0_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0_diffuse = new float[] { 0.7f, 0.7f, 0.7f, 1.0f };
            float[] light0_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

           
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular);

            float[] light1_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light1_diffuse = new float[] { 0.7f, 0.7f, 0.7f, 1.0f };
            float[] light1_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);    

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light1_specular);


            //這是衰減的設定  有設定這個就會變成探照燈
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 10.0f); //後面的數字視角度
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_EXPONENT, 10.0f);

            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_CUTOFF, 10.0f); //後面的數字視角度
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_EXPONENT, 10.0f);

            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_CUTOFF, 10.0f); //後面的數字視角度
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_EXPONENT, 10.0f);

            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_CUTOFF, 10.0f); //後面的數字視角度
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_EXPONENT, 10.0f);

            Gl.glColorMaterial(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE);
         //   Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);//開啟色彩材質
            Gl.glEnable(Gl.GL_DEPTH_TEST);//開啟深度測試這個功能
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_NORMALIZE);
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            setViewVolumne();
            myInit();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

        
            Glu.gluLookAt(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                    * Math.Sin(Longitude * DEGREE_TO_RAD),
             Radius * Math.Sin(Latitude * DEGREE_TO_RAD),
             Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                    * Math.Cos(Longitude * DEGREE_TO_RAD),
             0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            float[] light1_position = new float[] { -1.0f, 4.7f, 4.2f, 1.0f };//光的位置設在原點
            float[] light1_direction = new float[3] {0.0f,-1.0f,0.0f};//光的方向設定他是往下照

           
            float[] light2_position = new float[] { -1.0f, 4.7f, -4.2f, 1.0f };//光的位置設在原點
            float[] light3_position = new float[] { -1.0f, -4.7f, 4.2f, 1.0f };//光的位置設在原點

            float[] light3_direction = new float[3] { 0.0f, 1.0f, 0.0f };//光的方向設定他是往上照

            float[] light4_position = new float[] { -1.0f, -4.7f, -4.2f, 1.0f };//光的位置設在原點
            
            
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1_position);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light1_direction);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light2_position);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, light1_direction);
           
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_POSITION, light3_position);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPOT_DIRECTION, light3_direction);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_POSITION, light4_position);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPOT_DIRECTION, light3_direction);





            //clock外框
            Gl.glColor3ub(145,200,255);
            Gl.glPushMatrix();
            Gl.glRotated(90, 0.0, 1.0, 0.0);
            Glut.glutSolidTorus(1, 8, 100, 100);
            Gl.glPopMatrix();

            //clock中間
            Gl.glColor3ub(255, 255,162);
            Gl.glPushMatrix();
            Gl.glScaled(0.15,1.0,1.0);
            Glut.glutSolidSphere(7.5,15,15);
            Gl.glPopMatrix();

            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
           
          
            //分針
            Gl.glColor3ub(102,51,0);
            Gl.glPushMatrix();
            Gl.glRotated(minute * 6, 1.0, 0.0, 0.0);
            Gl.glTranslated(-1.5,2.5,0.0);
            Gl.glScaled(0.15,6.0,0.3);
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

            //時針
            Gl.glColor3ub(74,37, 0);
            Gl.glPushMatrix();
            Gl.glRotated((float)(hour+minute/60.0)*30.0, 1.0, 0.0, 0.0);
            Gl.glTranslated(-1.3, 1.4, 0.0);
            Gl.glScaled(0.15, 3.6, 0.3);
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

            //秒針
            Gl.glColor3ub(0, 0, 0);
            Gl.glPushMatrix();
            Gl.glRotated(second*6,1.0,0.0,0.0);
            Gl.glTranslated(-1.7, 2.5, 0.0);
            Gl.glScaled(0.15, 6.0, 0.2);
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

             Gl.glColor3ub(153,197,22);
            Gl.glPushMatrix();
            allDegree();
            Gl.glPopMatrix();

            label1.Text = hour + ":" + minute+":"+second;

        }
        private void degree(double wid, double height)
        {

            Gl.glPushMatrix();
            Gl.glScaled(0.15, wid,height);
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

        }
        private void allDegree()
        {
            Gl.glPushMatrix();
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(30,1.0,0.0,0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(60, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(120, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(150, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(180, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(210, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(240, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(270, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(300, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(330, 1.0, 0.0, 0.0);
            Gl.glTranslated(-0.7, 0.0, -6.2);
            degree(0.2, 1.2);
            Gl.glPopMatrix();


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            setViewVolumne();
        }

        private void simpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Longitude += 5.0;
                    break;
                case Keys.Right:
                    Longitude -= 5.0;
                    break;
                case Keys.Up:
                    Latitude -= 5.0;
                    if (Latitude >= 90.0) Latitude = 89.0;
                    break;
                case Keys.Down:
                    Latitude += 5.0;
                    if (Latitude <= -90.0) Latitude = -89.0;
                    break;
                case Keys.PageUp:
                    Radius += 1.0;
                    break;
                case Keys.PageDown:
                    Radius -= 1.0;
                    if (Radius < 2.0) Radius = 2.0;
                    break;
                case Keys.Z:
                    if(MainLightOn)
                    {
                        lightOneOn = false;
                        lightTwoOn = false;
                        lightThreeOn = false;
                        lightFourOn = false;
                        Gl.glEnable(Gl.GL_LIGHT0);
                        Gl.glDisable(Gl.GL_LIGHT1);
                        Gl.glDisable(Gl.GL_LIGHT2);
                        Gl.glDisable(Gl.GL_LIGHT3);
                        Gl.glDisable(Gl.GL_LIGHT4);

                    }
                    else
                    {
                        if(!lightOneOn)
                        {
                            lightOneOn = true;
                            Gl.glEnable(Gl.GL_LIGHT1);
                        }
                        else if (lightOneOn&&!lightTwoOn&&!lightThreeOn&&!lightFourOn)
                        {
                            lightTwoOn = true;
                           
                            Gl.glEnable(Gl.GL_LIGHT2);
                        }
                        else if (lightOneOn && lightTwoOn&&!lightThreeOn&&!lightFourOn)
                        {
                            lightThreeOn = true;
                            Gl.glEnable(Gl.GL_LIGHT3);
                        }
                        else if (lightOneOn && lightTwoOn && lightThreeOn && !lightFourOn)
                        {
                            lightFourOn = true;
                            Gl.glEnable(Gl.GL_LIGHT4);
                        }
                        else if (lightOneOn && lightTwoOn && lightThreeOn&&lightFourOn)
                        {
                            MainLightOn = true;
                            lightOneOn = false;
                            lightTwoOn = false;
                            lightThreeOn = false;
                            lightFourOn = false;
                            Gl.glEnable(Gl.GL_LIGHT0);
                            Gl.glDisable(Gl.GL_LIGHT1);
                            Gl.glDisable(Gl.GL_LIGHT2);
                            Gl.glDisable(Gl.GL_LIGHT3);
                            Gl.glDisable(Gl.GL_LIGHT4);
                        }
                    }
                    break;
                case Keys.X:
                        MainLightOn = false;
                        lightOneOn = false;
                        lightTwoOn = false;
                        lightThreeOn = false;
                        lightFourOn = false;
                       
                        Gl.glDisable(Gl.GL_LIGHT1);
                        Gl.glDisable(Gl.GL_LIGHT2);
                        Gl.glDisable(Gl.GL_LIGHT3);
                        Gl.glDisable(Gl.GL_LIGHT4);
                        Gl.glDisable(Gl.GL_LIGHT0);
                    break;
                default:
                    break;
            }
            this.simpleOpenGlControl1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.simpleOpenGlControl1.Refresh();
        }

        private void red_Click(object sender, EventArgs e)
        {
            float[] light1_ambient = new float[] { 0.2f, 0.0f, 0.0f, 1.0f };
            float[] light1_diffuse = new float[] { 0.7f, 0.0f, 0.0f, 1.0f };
            float[] light1_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light1_specular);

            this.simpleOpenGlControl1.Refresh();
        }

        private void green_Click(object sender, EventArgs e)
        {
            float[] light1_ambient = new float[] { 0.0f, 0.2f, 0.0f, 1.0f };
            float[] light1_diffuse = new float[] { 0.0f, 0.7f, 0.0f, 1.0f };
            float[] light1_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light1_specular);
            this.simpleOpenGlControl1.Refresh();
        }

        private void blue_Click(object sender, EventArgs e)
        {
            float[] light1_ambient = new float[] { 0.0f, 0.0f, 0.2f, 1.0f };
            float[] light1_diffuse = new float[] { 0.0f, 0.0f, 0.7f, 1.0f };
            float[] light1_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light1_specular);
            this.simpleOpenGlControl1.Refresh();
        }

        private void normal_Click(object sender, EventArgs e)
        {
            float[] light1_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light1_diffuse = new float[] { 0.7f, 0.7f, 0.7f, 1.0f };
            float[] light1_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light1_specular);
            this.simpleOpenGlControl1.Refresh();
        }

    }
}
