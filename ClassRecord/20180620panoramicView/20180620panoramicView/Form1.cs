using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.OpenGl;
using AllView;

namespace _20180620panoramicView
{
    public partial class Form1 : Form
    {
        uint[] texName = new uint[1]; //建立儲存紋理編號的陣列  uint 表示是符號
        double HSIZE = 200.0,VSIZE;
        Camera cam = new Camera();
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            Il.ilInit(); //Devil的初始化
            Ilu.iluInit();
        }
        private void SetViewingVolume()
        {
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width,
                          simpleOpenGlControl1.Size.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect = (double)simpleOpenGlControl1.Size.Width /
                            (double)simpleOpenGlControl1.Size.Height;

            Glu.gluPerspective(45, aspect, 0.1, 1000.0);
        }
        private void MyInit()
        {
            Gl.glClearColor(0.0f,0.0f,0.0f,0.0f);
            Gl.glClearDepth(1.0f);
          
            Gl.glGenTextures(1,texName);
            LoadTexture(@"C:\Users\asus\Desktop\電腦圖學\20180620panoramicView\20180620panoramicView\testimages\YZUALLView.jpg",texName[0]);

            VSIZE = 4.0*2.0 * HSIZE*437.0/4197.0;
            cam.SetPosition(0.0,15.0,0.0);
            cam.SetDirection(0.0, 0.0, -1.0);

            float[] fogColor = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            // 以指數方式計算霧化效果
          /*  Gl.glFogfv(Gl.GL_FOG_COLOR, fogColor);
            Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_EXP);
            Gl.glFogf(Gl.GL_FOG_DENSITY, 0.0075f);
            
            Gl.glEnable(Gl.GL_FOG);*/
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE); //設定色彩材質的設定
            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }
        private void LoadTexture(string filename, uint texture)
        {
            if (Il.ilLoadImage(filename)) //載入影像檔
            {
                int BitsPerPixel = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL); //取得儲存每個像素的位元數
                int Depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH); //取得影像的深度值
                Ilu.iluScale(512, 512, Depth); //將影像大小縮放為2的指數次方
                Ilu.iluFlipImage(); //顛倒影像
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture); //連結紋理物件
                //設定紋理參數
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                //建立紋理物件
                if (BitsPerPixel == 24) Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, 512, 512, 0,
                 Il.ilGetInteger(Il.IL_IMAGE_FORMAT), Il.ilGetInteger(Il.IL_IMAGE_TYPE), Il.ilGetData());
                if (BitsPerPixel == 32) Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, 512, 512, 0,
                 Il.ilGetInteger(Il.IL_IMAGE_FORMAT), Il.ilGetInteger(Il.IL_IMAGE_TYPE), Il.ilGetData());
            }
            else
            {   // 若檔案無法開啟，顯示錯誤訊息
                string message = "Cannot open file " + filename + ".";
                MessageBox.Show(message, "Image file open error!!!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }
        private void CubeEnvironment()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            //第一個牆面
            Gl.glBindTexture(Gl.GL_TEXTURE_2D,texName[0]);
            Gl.glEnable(Gl.GL_TEXTURE_2D); //開啟貼圖功能
            Gl.glColor3ub(255, 255, 255);
            Gl.glBegin(Gl.GL_QUADS);
            
            Gl.glNormal3d(0.0,0.0,1.0); //設定法向量 面向Z軸

            Gl.glTexCoord2d(0.0,0.0);
            Gl.glVertex3d(-HSIZE,0.0,-HSIZE); //要逆時針設點
            
            Gl.glTexCoord2d(0.25, 0.0); //因為式全景圖片，是把圖片切成四片放在每面牆上面，在這裡牆面是他的1/4 圖片座標是0~1 所以是0.25
            Gl.glVertex3d(HSIZE, 0.0, -HSIZE);

            Gl.glTexCoord2d(0.25, 1.0);
            Gl.glVertex3d(HSIZE, VSIZE, -HSIZE);

            Gl.glTexCoord2d(0.0, 1.0);
            Gl.glVertex3d(-HSIZE, VSIZE, -HSIZE);

            //second wall
            Gl.glNormal3d(-1.0, 0.0, 0.0); //設定法向量 面向Z軸
            Gl.glTexCoord2d(0.25, 0.0);
            Gl.glVertex3d(HSIZE, 0.0, -HSIZE); //要逆時針設點

            Gl.glTexCoord2d(0.5, 0.0); 
            Gl.glVertex3d(HSIZE, 0.0, HSIZE);

            Gl.glTexCoord2d(0.5, 1.0);
            Gl.glVertex3d(HSIZE, VSIZE, HSIZE);

            Gl.glTexCoord2d(0.25, 1.0);
            Gl.glVertex3d(HSIZE, VSIZE, -HSIZE);

            //third wall
            Gl.glNormal3d(0.0, 0.0, -1.0); //設定法向量 面向Z軸
            Gl.glTexCoord2d(0.5, 0.0);
            Gl.glVertex3d(HSIZE, 0.0, HSIZE); //要逆時針設點

            Gl.glTexCoord2d(0.75, 0.0);
            Gl.glVertex3d(-HSIZE, 0.0, HSIZE);

            Gl.glTexCoord2d(0.75, 1.0);
            Gl.glVertex3d(-HSIZE, VSIZE, HSIZE);

            Gl.glTexCoord2d(0.5, 1.0);
            Gl.glVertex3d(HSIZE, VSIZE, HSIZE);

            //forth wall
            Gl.glNormal3d(1.0, 0.0, 0.0); //設定法向量 面向Z軸
            Gl.glTexCoord2d(0.75, 0.0);
            Gl.glVertex3d(-HSIZE, 0.0, HSIZE); //要逆時針設點

            Gl.glTexCoord2d(1.0, 0.0);
            Gl.glVertex3d(-HSIZE, 0.0, -HSIZE);

            Gl.glTexCoord2d(1.0, 1.0);
            Gl.glVertex3d(-HSIZE, VSIZE, -HSIZE);

            Gl.glTexCoord2d(0.75, 1.0);
            Gl.glVertex3d(-HSIZE, VSIZE, HSIZE);

            Gl.glEnd();
            Gl.glEnable(Gl.GL_TEXTURE_2D);


            //sky
            Gl.glBegin(Gl.GL_QUADS);           
            Gl.glNormal3d(0.0, -1.0, 0.0); //設定法向量 面向Z軸
            Gl.glColor3ub(193, 222, 253);
            Gl.glVertex3d(-HSIZE, VSIZE, -HSIZE); //要逆時針設點
            Gl.glColor3ub(182,216,254);
            Gl.glVertex3d(HSIZE, VSIZE, -HSIZE);
            Gl.glColor3ub(175,207,246);
            Gl.glVertex3d(HSIZE, VSIZE, HSIZE);
            Gl.glColor3ub(186,216,254);
            Gl.glVertex3d(-HSIZE, VSIZE, HSIZE);
            Gl.glEnd();

            //ground
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(0.0, 1.0, 0.0); //設定法向量 面向Z軸
            Gl.glColor3ub(131,140,57);
            Gl.glVertex3d(-HSIZE, 0.0, -HSIZE); //要逆時針設點
            Gl.glColor3ub(169,168,112);
            Gl.glVertex3d(-HSIZE, 0.0, HSIZE);
            Gl.glColor3ub(182,183,115);
            Gl.glVertex3d(HSIZE, 0.0, HSIZE);
            Gl.glColor3ub(159,161,95);
            Gl.glVertex3d(HSIZE, 0.0, -HSIZE);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            //SetViewingVolume();
            cam.SetViewVolume(45.0,this.simpleOpenGlControl1.Size.Width,this.simpleOpenGlControl1.Size.Height,0.1,1000);
            MyInit();
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            //SetViewingVolume();
            cam.SetViewVolume(45.0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height, 0.1, 1000);
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT|Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);//投影用modelview矩陣
            Gl.glLoadIdentity();
           // Glu.gluLookAt(0.0,0.0,0.0,0.0,0.0,-10.0,0.0,1.0,0.0); //朝Z的副方向看去
            cam.LookAt();
            CubeEnvironment();
        }

        private void simpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.Left:
                    if (e.Control) cam.HSlide(-1.0); //按下ctrl+左鍵 
                    else if (e.Alt) cam.Roll(1.0); //alt+左建 表示滾動1.0度
                    else cam.Pan(1.0); //只有左鍵 如果只是貼上來的話，會有這 按鍵沒有辦法用，因為電腦預設，所以參考第4講義36頁，去改designer.cs裡面的檔案，把主控權拿回來
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.Right:
                    if (e.Control) cam.HSlide(1.0);
                    else if (e.Alt) cam.Roll(-1.0);
                    else cam.Pan(-1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.Up:
                    if (e.Control) cam.VSlide(1.0);
                    else cam.Tilt(1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.Down:
                    if (e.Control) cam.VSlide(-1.0);
                    else cam.Tilt(-1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.PageUp:
                    cam.Slide(5.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.PageDown:
                    cam.Slide(-5.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                default:
                    break;
            }

        }
    }
}
