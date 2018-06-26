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

namespace _1042060_finalProject
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180
        double Radius = 15.0, Longitude = 30.0, Latitude = 30.0; //經度 / 緯度
        int[] num=new int[8]; //第幾個方塊
        int[] xRot = new int[8];//表示x軸轉多少
        int[] yRot = new int[8];//表示y軸轉多少
        int[] zRot = new int[8];//表示z軸轉多少
       // int index = 0;//表示要第幾個
        int count = 0; //連續轉
        int[] spin = new int[5]; //哪些是要轉的   (x=1 y=2 z=3) 位置 位置 位置 位置
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            Glut.glutInit();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            setViewVolumne();
            myInit();
        }
        private void setViewVolumne()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            double aspect = (double)this.simpleOpenGlControl1.Size.Width / (double)this.simpleOpenGlControl1.Size.Height;
            Glu.gluPerspective(45, aspect, 0.1, 1000.0);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
        }
        private void myInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);

            Gl.glEnable(Gl.GL_NORMALIZE);//這是正規化 讓法向量都變回當為向量 因為用放大縮小會影響法向量
           // Gl.glEnable(Gl.GL_COLOR_MATERIAL);//開啟色彩材質
            Gl.glEnable(Gl.GL_DEPTH_TEST);//打開深度測試
            for(int i=0;i<8;i++)
            {
                num[i] = i + 1;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            setViewVolumne();
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


            
            Gl.glPushMatrix();
            Gl.glRotated(xRot[0], 1.0, 0.0, 0.0);
            Gl.glRotated(yRot[0], 0.0, 1.0, 0.0);
            Gl.glRotated(zRot[0], 0.0, 0.0, 1.0);
            cube1();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(xRot[1], 1.0, 0.0, 0.0);
            Gl.glRotated(yRot[1], 0.0, 1.0, 0.0);
            Gl.glRotated(zRot[1], 0.0, 0.0, 1.0);
            cube2();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(xRot[2], 1.0, 0.0, 0.0);
            Gl.glRotated(yRot[2], 0.0, 1.0, 0.0);
            Gl.glRotated(zRot[2], 0.0, 0.0, 1.0);
            cube3();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(xRot[3], 1.0, 0.0, 0.0);
            Gl.glRotated(yRot[3], 0.0, 1.0, 0.0);
            Gl.glRotated(zRot[3], 0.0, 0.0, 1.0);
            cube4();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(xRot[4], 1.0, 0.0, 0.0);
            Gl.glRotated(yRot[4], 0.0, 1.0, 0.0);
            Gl.glRotated(zRot[4], 0.0, 0.0, 1.0);
            cube5();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(xRot[5], 1.0, 0.0, 0.0);
            Gl.glRotated(yRot[5], 0.0, 1.0, 0.0);
            Gl.glRotated(zRot[5], 0.0, 0.0, 1.0);
            cube6();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(xRot[6], 1.0, 0.0, 0.0);
            Gl.glRotated(yRot[6], 0.0, 1.0, 0.0);
            Gl.glRotated(zRot[6], 0.0, 0.0, 1.0);
            cube7();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(xRot[7], 1.0, 0.0, 0.0);
            Gl.glRotated(yRot[7], 0.0, 1.0, 0.0);
            Gl.glRotated(zRot[7], 0.0, 0.0, 1.0);
            cube8();
            Gl.glPopMatrix();


            label1.Text = spin.Length.ToString();
            label2.Text = zRot[1].ToString();
            label3.Text = num[0].ToString() + " " + num[1].ToString() + " " + num[2].ToString() + " " + num[3].ToString() + " " + num[4].ToString() + " " + num[5].ToString() + " " + num[6].ToString() + " " + num[7].ToString();

        }
        private void cube()
        {
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(0.0, 1.0, 0.0);
            Gl.glVertex3d(0.0, 0.0, 0.0);
            Gl.glVertex3d(2.0, 0.0, 0.0);
            Gl.glVertex3d(2.0, 0.0, -2.0);
            Gl.glVertex3d(0.0, 0.0, -2.0);
            Gl.glEnd();
        }
       private void cubeAnti()
        {
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glNormal3d(0.0, -1.0, 0.0);
            Gl.glVertex3d(0.0, 0.0, 0.0);
            Gl.glVertex3d(2.0, 0.0, 0.0);
            Gl.glVertex3d(2.0, 0.0, -2.0);
            Gl.glVertex3d(0.0, 0.0, -2.0);
            Gl.glEnd();

        }
        private void cube1()
        {
          /*  Gl.glBegin(Gl.GL_QUADS);
            //上面 右上
            Gl.glNormal3d(0.0, 1.0, 0.0);
            Gl.glVertex3d(0.0,2.0,0.0);
            Gl.glVertex3d(2.0,2.0, 0.0);
            Gl.glVertex3d(2.0, 2.0, -2.0);
            Gl.glVertex3d(0.0, 2.0, -2.0);

            //右邊
            Gl.glNormal3d(1.0, 0.0, 0.0);
            Gl.glVertex3d(2.0, 0.0, 0.0);
            Gl.glVertex3d(2.0, 0.0, -2.0);
            Gl.glVertex3d(2.0, 2.0, -2.0);
            Gl.glVertex3d(2.0, 2.0, 0.0);
           
            //back
            Gl.glNormal3d(0.0, 0.0, -1.0);
            Gl.glVertex3d(0.0, 0.0, -2.0);
            Gl.glVertex3d(2.0, 0.0, -2.0);
            Gl.glVertex3d(2.0, 2.0, -2.0);
            Gl.glVertex3d(0.0, 2.0, -2.0);

            Gl.glEnd();*/

            //上面 右上
            Gl.glColor3ub(255,249,130);//yellow
            Gl.glPushMatrix();
            Gl.glTranslated(0.0,2.0,0.0);
            cube();
            Gl.glPopMatrix();

            //right
            Gl.glColor3ub(185,122,87);//brown
            Gl.glPushMatrix();
            Gl.glTranslated(2.0,0.0,0.0);
            Gl.glRotated(90,0.0,0.0,1.0);
            cube();
            Gl.glPopMatrix();

            //back
            Gl.glColor3ub(200,191,231);//purple
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 0.0, -2.0);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            cube();
            Gl.glPopMatrix();
            
        }
        private void cube2()
        {
          /*  Gl.glBegin(Gl.GL_QUADS);

            //上面 右下
            Gl.glNormal3d(0.0, 1.0, 0.0);
            Gl.glVertex3d(0.0, 2.0, 2.0);
            Gl.glVertex3d(2.0, 2.0, 2.0);
            Gl.glVertex3d(2.0, 2.0, 0.0);
            Gl.glVertex3d(0.0, 2.0, 0.0);

            //右邊
            Gl.glNormal3d(1.0, 0.0, 0.0);
            Gl.glVertex3d(2.0, 0.0, 2.0);
            Gl.glVertex3d(2.0, 0.0, 0.0);
            Gl.glVertex3d(2.0, 2.0, 0.0);
            Gl.glVertex3d(2.0, 2.0, 2.0);

            //前面
            Gl.glNormal3d(0.0, 0.0, 1.0);
            Gl.glVertex3d(0.0, 0.0, 2.0);
            Gl.glVertex3d(2.0, 0.0, 2.0);
            Gl.glVertex3d(2.0, 2.0, 2.0);
            Gl.glVertex3d(0.0, 2.0, 2.0);

            Gl.glEnd();*/

            //上面 右下       
            Gl.glColor3ub(255, 249, 130);//yellow
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 2.0, 2.0);
            cube();
            Gl.glPopMatrix();

            //right
            Gl.glColor3ub(185, 122, 87);//brown
            Gl.glPushMatrix();
            Gl.glTranslated(2.0, 0.0, 2.0);
            Gl.glRotated(90, 0.0, 0.0, 1.0);
            cube();
            Gl.glPopMatrix();

            //front
            Gl.glColor3ub(255,174,201);//pink
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 0.0, 2.0);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            cube();
            Gl.glPopMatrix();

        }
        private void cube3()
        {
           /* Gl.glBegin(Gl.GL_QUADS);

            //上面 左下
            Gl.glNormal3d(0.0, 1.0, 0.0);
            Gl.glVertex3d(-2.0, 2.0, 2.0);
            Gl.glVertex3d(0.0, 2.0, 2.0);
            Gl.glVertex3d(0.0, 2.0, 0.0);
            Gl.glVertex3d(-2.0, 2.0, 0.0);

            //左邊
            Gl.glNormal3d(-1.0, 0.0, 0.0);
            Gl.glVertex3d(-2.0, 0.0, 2.0);
            Gl.glVertex3d(-2.0, 0.0, 0.0);
            Gl.glVertex3d(-2.0, 2.0, 0.0);
            Gl.glVertex3d(-2.0, 2.0, 2.0);

            //前面
            Gl.glNormal3d(0.0, 0.0, 1.0);
            Gl.glVertex3d(-2.0, 0.0, 2.0);
            Gl.glVertex3d(0.0, 0.0, 2.0);
            Gl.glVertex3d(0.0, 2.0, 2.0);
            Gl.glVertex3d(-2.0, 2.0, 2.0);

            Gl.glEnd();*/

            //上面 左下       
            Gl.glColor3ub(255, 249, 130);//yellow
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, 2.0, 2.0);
            cube();
            Gl.glPopMatrix();

            //left
            Gl.glColor3ub(153,217,234);//blue
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, 0.0, 2.0);
            Gl.glRotated(90, 0.0, 0.0, 1.0);
            cube();
            Gl.glPopMatrix();

            //front
            Gl.glColor3ub(255, 174, 201);//pink
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, 0.0, 2.0);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            cube();
            Gl.glPopMatrix();

        }
        private void cube4()
        {
          /*  Gl.glBegin(Gl.GL_QUADS);

            //上面 左上
            Gl.glNormal3d(0.0, 1.0, 0.0);
            Gl.glVertex3d(-2.0, 2.0, 0.0);
            Gl.glVertex3d(0.0, 2.0, 0.0);
            Gl.glVertex3d(0.0, 2.0, -2.0);
            Gl.glVertex3d(-2.0, 2.0, -2.0);

            //左邊
            Gl.glNormal3d(-1.0, 0.0, 0.0);
            Gl.glVertex3d(-2.0, 0.0, 0.0);
            Gl.glVertex3d(-2.0, 0.0, -2.0);
            Gl.glVertex3d(-2.0, 2.0, -2.0);
            Gl.glVertex3d(-2.0, 2.0, 0.0);

            //後面
            Gl.glNormal3d(0.0, 0.0, -1.0);
            Gl.glVertex3d(-2.0, 0.0, -2.0);
            Gl.glVertex3d(0.0, 0.0, -2.0);
            Gl.glVertex3d(0.0, 2.0, -2.0);
            Gl.glVertex3d(-2.0, 2.0, -2.0);

            Gl.glEnd();*/

            //上面 左上
            Gl.glColor3ub(255, 249, 130);//yellow
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, 2.0, 0.0);
            cube();
            Gl.glPopMatrix();

            //left
            Gl.glColor3ub(153, 217, 234);//blue
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, 0.0, 0.0);
            Gl.glRotated(90, 0.0, 0.0, 1.0);
            cube();
            Gl.glPopMatrix();

            //back
            Gl.glColor3ub(200,191,231);//purple
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, 0.0, -2.0);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            cube();
            Gl.glPopMatrix();
        }
        private void cube5()
        {
            //下面 左上
            Gl.glColor3ub(209,82,85);//red
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -2.0, 0.0);
            cubeAnti();
            Gl.glPopMatrix();

            //right
            Gl.glColor3ub(185,122,87);//brown
            Gl.glPushMatrix();
            Gl.glTranslated(2.0, -2.0, 0.0);
            Gl.glRotated(90, 0.0, 0.0, 1.0);
            cubeAnti();
            Gl.glPopMatrix();

            //back
            Gl.glColor3ub(200, 191, 231);//purple
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -2.0, -2.0);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            cubeAnti();
            Gl.glPopMatrix();
        }
        private void cube6()
        {
            //下面 左下
            Gl.glColor3ub(209, 82, 85);//red
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -2.0, 2.0);
            cubeAnti();
            Gl.glPopMatrix();

            //right
            Gl.glColor3ub(185, 122, 87);//brown
            Gl.glPushMatrix();
            Gl.glTranslated(2.0, -2.0, 2.0);
            Gl.glRotated(90, 0.0, 0.0, 1.0);
            cubeAnti();
            Gl.glPopMatrix();

            //front
            Gl.glColor3ub(255,174,201);//pink
            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -2.0, 2.0);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            cube();
            Gl.glPopMatrix();
        }
        private void cube7()
        {
            //下面 右下
            Gl.glColor3ub(209, 82, 85);//red
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, -2.0, 2.0);
            cubeAnti();
            Gl.glPopMatrix();

            //left
            Gl.glColor3ub(153,217,234);//blue
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, -2.0, 2.0);
            Gl.glRotated(90, 0.0, 0.0, 1.0);
            cube();
            Gl.glPopMatrix();

            //front
            Gl.glColor3ub(255, 174, 201);//pink
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, -2.0, 2.0);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            cube();
            Gl.glPopMatrix();
        }
        private void cube8()
        {
            //下面 右上
            Gl.glColor3ub(209, 82, 85);//red
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, -2.0, 0.0);
            cubeAnti();
            Gl.glPopMatrix();

            //left
            Gl.glColor3ub(153,217,234);//blue
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, -2.0, 0.0);
            Gl.glRotated(90, 0.0, 0.0, 1.0);
            cube();
            Gl.glPopMatrix();

            //back
            Gl.glColor3ub(200,191,231);//purple
            Gl.glPushMatrix();
            Gl.glTranslated(-2.0, -2.0, -2.0);
            Gl.glRotated(90, 1.0, 0.0, 0.0);
            cubeAnti();
            Gl.glPopMatrix();
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
                default:
                    break;
            }
            this.simpleOpenGlControl1.Refresh();
        }

        private void upClock_Click(object sender, EventArgs e)
        {
            spin[0] = 2; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8;i++ )
            {
                if(num[i]==1)
                {
                    yRot[i]-=9; //負的是順時針
                    num[i] = 2;
                    spin[1] = i;
                }
                else if(num[i]==2)
                {
                    yRot[i] -= 9;
                    num[i] = 3;
                    spin[2] = i;
                }
                else if (num[i] == 3)
                {
                    yRot[i] -= 9;
                    num[i] = 4;
                    spin[3] = i;
                }
                else if(num[i]==4)
                {
                    yRot[i] -= 9;
                    num[i] = 1;
                    spin[4] = i;    
                }             
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int getNum; //紀錄是哪個位置
            if(count<10 && count>0) //讓他轉十次 剛好90度
            {
                for (int i = 1; i < 5; i++)
                {
                    if(spin.Length>0)
                    {
                        getNum = spin[i]; //取得那些編號要旋轉
                        if (spin[0] == 1)
                        {
                            xRot[getNum] -= 9;//順時針
                        }
                        else if (spin[0] == 2)
                        {
                            yRot[getNum] -= 9;
                        }
                        else if (spin[0] == 3)
                        {
                            zRot[getNum] -= 9;
                        }
                        else if (spin[0] == 4)
                        {
                            xRot[getNum] += 9; //逆時針
                        }
                        else if (spin[0] == 5)
                        {
                            yRot[getNum] += 9;
                        }
                        else if (spin[0] == 6)
                        {
                            zRot[getNum] += 9;
                        }
                    } //if end 
                }//for end
                count++;
            }//if end
            else
            {
                count = 0;
                Array.Clear(spin, 0,5);
                timer1.Enabled = false;
            }
            
            this.simpleOpenGlControl1.Refresh();
        }

        private void upAnti_Click(object sender, EventArgs e)
        {
            spin[0] = 5; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 1)
                {
                    yRot[i] += 9; //逆時針
                    num[i] = 4;
                    spin[1] = i;
                }
                else if (num[i] == 2)
                {
                    yRot[i] += 9;
                    num[i] = 1;
                    spin[2] = i;
                }
                else if (num[i] == 3)
                {
                    yRot[i] += 9;
                    num[i] = 2;
                    spin[3] = i;
                }
                else if (num[i] == 4)
                {
                    yRot[i] += 9;
                    num[i] = 3;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void downClock_Click(object sender, EventArgs e)
        {
            spin[0] = 2; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 5)
                {
                    yRot[i] -= 9; //負的是順時針
                    num[i] = 6;
                    spin[1] = i;
                }
                else if (num[i] == 6)
                {
                    yRot[i] -= 9;
                    num[i] = 7;
                    spin[2] = i;
                }
                else if (num[i] == 7)
                {
                    yRot[i] -= 9;
                    num[i] = 8;
                    spin[3] = i;
                }
                else if (num[i] == 8)
                {
                    yRot[i] -= 9;
                    num[i] = 5;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void downAnti_Click(object sender, EventArgs e)
        {
            spin[0] = 5; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 5)
                {
                    yRot[i] += 9; //逆時針
                    num[i] = 8;
                    spin[1] = i;
                }
                else if (num[i] == 6)
                {
                    yRot[i] += 9;
                    num[i] = 5;
                    spin[2] = i;
                }
                else if (num[i] == 7)
                {
                    yRot[i] += 9;
                    num[i] = 6;
                    spin[3] = i;
                }
                else if (num[i] == 8)
                {
                    yRot[i] += 9;
                    num[i] = 7;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void frontClock_Click(object sender, EventArgs e)
        {
            spin[0] = 3; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順  4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 2)
                {
                    zRot[i] -= 9; //負的是順時針
                    num[i] = 6;
                    spin[1] = i;
                }
                else if (num[i] == 3)
                {
                    zRot[i] -= 9;
                    num[i] = 2;
                    spin[2] = i;
                }
                else if (num[i] == 6)
                {
                    zRot[i] -= 9;
                    num[i] = 7;
                    spin[3] = i;
                }
                else if (num[i] == 7)
                {
                    zRot[i] -= 9;
                    num[i] = 3;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void frontAnti_Click(object sender, EventArgs e)
        {
            spin[0] = 6; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 2)
                {
                    zRot[i] += 9; //逆時針
                    num[i] = 3;
                    spin[1] = i;
                }
                else if (num[i] == 3)
                {
                    zRot[i] += 9;
                    num[i] = 7;
                    spin[2] = i;
                }
                else if (num[i] == 6)
                {
                    zRot[i] += 9;
                    num[i] = 2;
                    spin[3] = i;
                }
                else if (num[i] == 7)
                {
                    zRot[i] += 9;
                    num[i] = 6;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void backClock_Click(object sender, EventArgs e)
        {
            spin[0] = 3; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 1)
                {
                    zRot[i] -= 9; //負的順時針  正是逆時針
                    num[i] = 5;
                    spin[1] = i;
                }
                else if (num[i] == 4)
                {
                    zRot[i] -= 9;
                    num[i] = 1;
                    spin[2] = i;
                }
                else if (num[i] == 5)
                {
                    zRot[i] -= 9;
                    num[i] = 8;
                    spin[3] = i;
                }
                else if (num[i] == 8)
                {
                    zRot[i] -= 9;
                    num[i] = 4;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void backAnti_Click(object sender, EventArgs e)
        {
            spin[0] = 6; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 1)
                {
                    zRot[i] += 9; //正是逆時針
                    num[i] = 4;
                    spin[1] = i;
                }
                else if (num[i] == 4)
                {
                    zRot[i] += 9;
                    num[i] = 8;
                    spin[2] = i;
                }
                else if (num[i] == 5)
                {
                    zRot[i] += 9;
                    num[i] = 1;
                    spin[3] = i;
                }
                else if (num[i] == 8)
                {
                    zRot[i] += 9;
                    num[i] = 5;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void leftClock_Click(object sender, EventArgs e)
        {
            spin[0] = 1; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 3)
                {
                    xRot[i] -= 9; //負的順時針  正是逆時針
                    num[i] = 7;
                    spin[1] = i;
                }
                else if (num[i] ==4)
                {
                    xRot[i] -= 9;
                    num[i] = 3;
                    spin[2] = i;
                }
                else if (num[i] == 7)
                {
                    xRot[i] -= 9;
                    num[i] = 8;
                    spin[3] = i;
                }
                else if (num[i] == 8)
                {
                    xRot[i] -= 9;
                    num[i] = 4;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void leftAnti_Click(object sender, EventArgs e)
        {
            spin[0] = 4; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 3)
                {
                    xRot[i] += 9; //負的順時針  正是逆時針
                    num[i] = 4;
                    spin[1] = i;
                }
                else if (num[i] == 4)
                {
                    xRot[i] += 9;
                    num[i] = 8;
                    spin[2] = i;
                }
                else if (num[i] == 7)
                {
                    xRot[i] += 9;
                    num[i] = 3;
                    spin[3] = i;
                }
                else if (num[i] == 8)
                {
                    xRot[i] += 9;
                    num[i] = 7;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void rightClock_Click(object sender, EventArgs e)
        {
            spin[0] = 1; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 1)
                {
                    xRot[i] -= 9; //負的順時針  正是逆時針
                    num[i] = 5;
                    spin[1] = i;
                }
                else if (num[i] == 2)
                {
                    xRot[i] -= 9;
                    num[i] = 1;
                    spin[2] = i;
                }
                else if (num[i] == 5)
                {
                    xRot[i] -= 9;
                    num[i] = 6;
                    spin[3] = i;
                }
                else if (num[i] == 6)
                {
                    xRot[i] -= 9;
                    num[i] = 2;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void rightAnti_Click(object sender, EventArgs e)
        {
            spin[0] = 4; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 1)
                {
                    xRot[i] += 9; //負的順時針  正是逆時針
                    num[i] = 2;
                    spin[1] = i;
                }
                else if (num[i] == 2)
                {
                    xRot[i] += 9;
                    num[i] = 6;
                    spin[2] = i;
                }
                else if (num[i] == 5)
                {
                    xRot[i] += 9;
                    num[i] = 1;
                    spin[3] = i;
                }
                else if (num[i] == 6)
                {
                    xRot[i] += 9;
                    num[i] = 5;
                    spin[4] = i;
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }
    }
}
