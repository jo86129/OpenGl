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

namespace _20180509light
{
    public partial class Form1 : Form
    {
        double angle1;
        double angle2;
        double angle3;
        const double DEGREE_TO_RAD = 0.01745329;      
        double rot = 40;       
        double[] xRot = new double[9];
        double[] yRot = new double[9];
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            Glut.glutInit();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            SetViewingVolume();
            MyInit();
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


        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);//設定深度初始直

            
            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f }; //全域環境光的數值
            float[] light0_ambient = new float[] { 0.2f, 0.2f, 0.0f }; //偏黃色的環境光
            float[] light0_diffuse = new float[] { 0.7f, 0.7f, 0.0f }; //偏黃色的散射光
            float[] light0_specular = new float[] { 0.9f, 0.9f, 0.0f }; //偏黃色的鏡射光



            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient); //設定全域環境光
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE); //觀者位於場景內
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE); //只對物體正面進行光影計算


           // 原子系統的光
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular);

            


            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE); //設定色彩材質的設定

            Gl.glEnable(Gl.GL_DEPTH_TEST);//開啟深度測試這個功能
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
           
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Glu.gluLookAt(0.0, 0.0, 50.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

         

            float[] mat_ambient = new float[] { 0.0f, 0.1f, 0.0f, 1.0f }; //偏綠色材質
            float[] mat_diffuse = new float[] { 0.0f, 0.7f, 0.0f, 1.0f }; //偏綠色材質
            float[] mat_specular = new float[] { 0.9f, 0.9f, 0.9f, 1.0f };
            float mat_shininess = 32.0f; //閃亮係數的數值

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat_ambient); //設定材質的環境光反射係數
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat_diffuse); //設定材質的散射光反射係數
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat_specular); //設定材質的鏡射光反射係數
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, mat_shininess); //設定材質的閃亮係數



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
            Gl.glEnable(Gl.GL_COLOR_MATERIAL); //打開色彩材質的功能 讓glColor3d的功能出現
            Gl.glColor3d(1.0, 0.0, 1.0);
            Gl.glPushMatrix();
            Gl.glRotated(angle3, 0.0, 1.0, 0.0);
            Gl.glTranslated(0.0, 0.0, 10.0);
            Glut.glutSolidSphere(1.0, 20, 20);
            Gl.glPopMatrix();
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
