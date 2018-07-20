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

namespace _20180509SolarSystemLight
{
    public partial class Form1 : Form
    {
        double angle1;
        double angle2;
        double angle3;
        const double DEGREE_TO_RAD = 0.01745329;
        
        double rot = 40;
       
        
       
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            Glut.glutInit();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            MyInit();
            SetViewingVolume();
        }
        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);//設定深度初始直

            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f }; //全域環境光的數值
            float[] light0_ambient = new float[] { 0.0f, 0.0f, 0.0f };
            float[] light0_diffuse = new float[] { 0.8f, 0.8f, 0.8f };

            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient); //設定全域環境光
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE); //觀者位於場景內
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE); //只對物體正面進行光影計算

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);


             Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE); //設定色彩材質的設定

            Gl.glEnable(Gl.GL_DEPTH_TEST);//開啟深度測試這個功能
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);


        }
        private void SetViewingVolume()
        {

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect = (double)simpleOpenGlControl1.Size.Width /
                             (double)simpleOpenGlControl1.Size.Height;

           
            Glu.gluPerspective(45, aspect, 10.0, 100.0);

            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width,
                simpleOpenGlControl1.Size.Height);

        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Glu.gluLookAt(0.0, 0.0, 50.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            float[] light0_position = new float[] { 0.0f, 0.0f, 0.0f, 1.0f }; //將光源設於原點(即太陽的位置)
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);

            float[] mat_emission = new float[] { 1.0f, 0.3f, 0.0f }; //let the sum will shine
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, mat_emission);


            //Draw the sun
            Gl.glColor3d(1.0, 1.0, 0.0);
            Glut.glutSolidSphere(4.0, 20, 20);

            //為了不讓太陽的光影響地球與月球 把發光係數調0
            mat_emission[0] = 0.0f;
            mat_emission[1] = 0.0f;
            mat_emission[2] = 0.0f;
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, mat_emission);

            Gl.glEnable(Gl.GL_COLOR_MATERIAL); //打開色彩材質的功能 讓glColor3d的功能出現

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
            Gl.glDisable(Gl.GL_COLOR_MATERIAL); //關掉色彩材質的功能
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle1 += 3;
            angle2 += 1;
            angle3 += 5;
            rot += 4;
            this.simpleOpenGlControl1.Refresh();

        }
    }
}
