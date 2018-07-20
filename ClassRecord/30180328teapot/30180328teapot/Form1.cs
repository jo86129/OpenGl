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
namespace _30180328teapot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
        }
        private void SetViewingVolume()
        {
           /* Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-10, 10, -10, 10, -10, 10);*/
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect = (double)simpleOpenGlControl1.Size.Width /
                            (double)simpleOpenGlControl1.Size.Height;

            if (simpleOpenGlControl1.Size.Width > simpleOpenGlControl1.Size.Height)
                Gl.glOrtho(-10.0 * aspect, 10.0 * aspect, -10.0, 10.0, 10.0, 100.0);
            else
                Gl.glOrtho(-10.0, 10.0, -10.0 / aspect, 10.0 / aspect, 10.0, 100.0);
        }
        private void MyInt()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
           
        }
        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            MyInt();
            SetViewingVolume();

        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
         //   Glut.glutWireTeapot(4.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

         /*   Gl.glTranslated(-5.0, -5.0, -40.0);
            Glut.glutWireTeapot(4.0);
            Gl.glLoadIdentity();
            Gl.glTranslated(5.0, 5.0, -60.0);
            Glut.glutWireTeapot(4.0);
            */
            Gl.glTranslated(0.0, 0.0, -90.0);//T3

            Gl.glPushMatrix();
            Gl.glTranslated(8.0, 0.0, 0.0); //T2
            Gl.glRotated(30.0, 0.0, 0.0, 1.0); //R2
            Glut.glutWireTeapot(4.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-8.0, 0.0, 0.0); //T1
            Gl.glRotated(-30.0, 0.0, 0.0, 1.0); //R1
            Glut.glutWireTeapot(4.0);
            Gl.glPopMatrix();

        }
    }
}
