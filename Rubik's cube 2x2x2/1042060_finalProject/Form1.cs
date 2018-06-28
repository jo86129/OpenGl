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
using System.Collections;

namespace _1042060_finalProject
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180
        double Radius = 15.0, Longitude = 30.0, Latitude = 30.0; //經度 / 緯度
        int[] num=new int[8]; //第幾個方塊  num[0]表示是cube1
        int[] xRot = new int[8];//表示x軸轉多少
        int[] yRot = new int[8];//表示y軸轉多少
        int[] zRot = new int[8];//表示z軸轉多少
       // int index = 0;//表示要第幾個
        int count = 0; //連續轉
        int[] spin = new int[5]; //哪些是要轉的   (x=1 y=2 z=3) 位置 位置 位置 位置
        Stack stack1 = new Stack();
        Stack stack2 = new Stack();
        Stack stack3 = new Stack();
        Stack stack4 = new Stack();
        Stack stack5 = new Stack();
        Stack stack6 = new Stack();
        Stack stack7 = new Stack();
        Stack stack8 = new Stack();
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
            rotate(stack1);
            cube1();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            rotate(stack2);
            cube2();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            rotate(stack3);
            cube3();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            rotate(stack4);
            cube4();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            rotate(stack5);
            cube5();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            rotate(stack6);
            cube6();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            rotate(stack7);
            cube7();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            rotate(stack8);
            cube8();
            Gl.glPopMatrix();

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
        private void rotate(Stack a)
        {
            
           // Stack stack2 = new Stack(a.ToArray());
            //String[] angle = new string[a.Count];
            Object[] angle = a.ToArray();
            a.CopyTo(angle,0);

          
            for (int i = 1; i <= a.Count; i += 2) //第一個數字表示角度 第二個表示軸向
                {
                    if(angle[i].ToString()=="x")
                    {
                        Gl.glRotated(int.Parse(angle[i-1].ToString()), 1.0, 0.0, 0.0);
                    

                    }
                    else if (angle[i].ToString() == "y")
                    {
                        Gl.glRotated(int.Parse(angle[i - 1].ToString()), 0.0, 1.0, 0.0);
                      
                       
                    }
                    else if (angle[i].ToString() == "z")
                    {
                       Gl.glRotated(int.Parse(angle[i - 1].ToString()), 0.0, 0.0, 1.0);
                                          }
                }
        }
        private void pushStack(int num,string axis,int rot)
        {
            if(num==0)
            {
                stack1.Push(axis);
                stack1.Push(rot);
            }
            else if(num==1)
            {
                stack2.Push(axis);
                stack2.Push(rot);
            }
            else if (num == 2)
            {
                stack3.Push(axis);
                stack3.Push(rot);
            }
            else if (num == 3)
            {
                stack4.Push(axis);
                stack4.Push(rot);
            }
            else if (num ==4)
            {
                stack5.Push(axis);
                stack5.Push(rot);
            }
            else if (num == 5)
            {
                stack6.Push(axis);
                stack6.Push(rot);
            }
            else if (num == 6)
            {
                stack7.Push(axis);
                stack7.Push(rot);
            }
            else if (num == 7)
            {
                stack8.Push(axis);
                stack8.Push(rot);
            }
            this.simpleOpenGlControl1.Refresh();
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
                    yRot[i]=-9; //負的是順時針
                    num[i] = 2;
                    spin[1] = i;
                    pushStack(i,"y",yRot[i]);
                    
                }
                else if(num[i]==2)
                {
                    yRot[i] = -9;
                    num[i] = 3;
                    spin[2] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 3)
                {
                    yRot[i] = -9;
                    num[i] = 4;
                    spin[3] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if(num[i]==4)
                {
                    yRot[i] = -9;
                    num[i] = 1;
                    spin[4] = i;
                    pushStack(i, "y", yRot[i]);
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
                            xRot[getNum] = -9;//順時針
                            pushStack(getNum, "x", xRot[getNum]);
                        }
                        else if (spin[0] == 2)
                        {
                            yRot[getNum] = -9;
                            pushStack(getNum, "y", yRot[getNum]);
                        }
                        else if (spin[0] == 3)
                        {
                            zRot[getNum] = -9;
                            pushStack(getNum, "z", zRot[getNum]);
                        }
                        else if (spin[0] == 4)
                        {
                            xRot[getNum] = 9; //逆時針
                            pushStack(getNum, "x", xRot[getNum]);
                        }
                        else if (spin[0] == 5)
                        {
                            yRot[getNum] = 9;
                            pushStack(getNum, "y", yRot[getNum]);
                        }
                        else if (spin[0] == 6)
                        {
                            zRot[getNum] = 9;
                            pushStack(getNum, "z", zRot[getNum]);
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
                    yRot[i] = 9; //逆時針
                    num[i] = 4;
                    spin[1] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 2)
                {
                    yRot[i] = 9;
                    num[i] = 1;
                    spin[2] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 3)
                {
                    yRot[i] = 9;
                    num[i] = 2;
                    spin[3] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 4)
                {
                    yRot[i] = 9;
                    num[i] = 3;
                    spin[4] = i;
                    pushStack(i, "y", yRot[i]);
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
                    yRot[i] = -9; //負的是順時針
                    num[i] = 6;
                    spin[1] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 6)
                {
                    yRot[i] = -9;
                    num[i] = 7;
                    spin[2] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 7)
                {
                    yRot[i] = -9;
                    num[i] = 8;
                    spin[3] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 8)
                {
                    yRot[i] = -9;
                    num[i] = 5;
                    spin[4] = i;
                    pushStack(i, "y", yRot[i]);
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
                    yRot[i] = 9; //逆時針
                    num[i] = 8;
                    spin[1] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 6)
                {
                    yRot[i] = 9;
                    num[i] = 5;
                    spin[2] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 7)
                {
                    yRot[i] = 9;
                    num[i] = 6;
                    spin[3] = i;
                    pushStack(i, "y", yRot[i]);
                }
                else if (num[i] == 8)
                {
                    yRot[i] = 9;
                    num[i] = 7;
                    spin[4] = i;
                    pushStack(i, "y", yRot[i]);
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
                    zRot[i] = -9; //負的是順時針
                    num[i] = 6;
                    spin[1] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 3)
                {
                    zRot[i] = -9;
                    num[i] = 2;
                    spin[2] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 6)
                {
                    zRot[i] = -9;
                    num[i] = 7;
                    spin[3] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 7)
                {
                    zRot[i] = -9;
                    num[i] = 3;
                    spin[4] = i;
                    pushStack(i, "z", zRot[i]);
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
                    zRot[i] = 9; //逆時針
                    num[i] = 3;
                    spin[1] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 3)
                {
                    zRot[i] = 9;
                    num[i] = 7;
                    spin[2] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 6)
                {
                    zRot[i] = 9;
                    num[i] = 2;
                    spin[3] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 7)
                {
                    zRot[i] = 9;
                    num[i] = 6;
                    spin[4] = i;
                    pushStack(i, "z", zRot[i]);
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
                    zRot[i] = -9; //負的順時針  正是逆時針
                    num[i] = 5;
                    spin[1] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 4)
                {
                    zRot[i] = -9;
                    num[i] = 1;
                    spin[2] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 5)
                {
                    zRot[i] = -9;
                    num[i] = 8;
                    spin[3] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 8)
                {
                    zRot[i] = -9;
                    num[i] = 4;
                    spin[4] = i;
                    pushStack(i, "z", zRot[i]);
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
                    zRot[i] = 9; //正是逆時針
                    num[i] = 4;
                    spin[1] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 4)
                {
                    zRot[i] = 9;
                    num[i] = 8;
                    spin[2] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 5)
                {
                    zRot[i] = 9;
                    num[i] = 1;
                    spin[3] = i;
                    pushStack(i, "z", zRot[i]);
                }
                else if (num[i] == 8)
                {
                    zRot[i] = 9;
                    num[i] = 5;
                    spin[4] = i;
                    pushStack(i, "z", zRot[i]);
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void leftClock_Click(object sender, EventArgs e)
        {
            spin[0] = 4; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆  這裡的順逆時針剛好跟其他的相反
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 3)
                {
                    xRot[i] = 9; //負的順時針  正是逆時針  這裡的順逆時針剛好跟其他的相反 所以這裡是正的順時
                    num[i] = 7;
                    spin[1] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] ==4)
                {
                    xRot[i] = 9; 
                    num[i] = 3;
                    spin[2] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 7)
                {
                    xRot[i] = 9; 
                    num[i] = 8;
                    spin[3] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 8)
                {
                    xRot[i] = 9; 
                    num[i] = 4;
                    spin[4] = i;
                    pushStack(i, "x", xRot[i]);
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }

        private void leftAnti_Click(object sender, EventArgs e)
        {
            spin[0] = 1; //spin第一個數字是顯示哪個軸向旋轉 1=X順 2=Y順 3=Z順 4=X逆 5=Y逆 6=Z逆 這裡的順逆時針剛好跟其他的相反
            for (int i = 0; i < 8; i++)
            {
                if (num[i] == 3)
                {
                    xRot[i] = -9; //負的順時針  正是逆時針   這裡的順逆時針剛好跟其他的相反
                    num[i] = 4;
                    spin[1] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 4)
                {
                    xRot[i] = -9;
                    num[i] = 8;
                    spin[2] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 7)
                {
                    xRot[i] = -9;
                    num[i] = 3;
                    spin[3] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 8)
                {
                    xRot[i] = -9;
                    num[i] = 7;
                    spin[4] = i;
                    pushStack(i, "x", xRot[i]);
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
                    xRot[i] = -9; //負的順時針  正是逆時針
                    num[i] = 5;
                    spin[1] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 2)
                {
                    xRot[i] = -9;
                    num[i] = 1;
                    spin[2] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 5)
                {
                    xRot[i] = -9;
                    num[i] = 6;
                    spin[3] = i; 
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 6)
                {
                    xRot[i] = -9;
                    num[i] = 2;
                    spin[4] = i;
                    pushStack(i, "x", xRot[i]);
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
                    xRot[i] = 9; //負的順時針  正是逆時針
                    num[i] = 2;
                    spin[1] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 2)
                {
                    xRot[i] = 9;
                    num[i] = 6;
                    spin[2] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 5)
                {
                    xRot[i] = 9;
                    num[i] = 1;
                    spin[3] = i;
                    pushStack(i, "x", xRot[i]);
                }
                else if (num[i] == 6)
                {
                    xRot[i] = 9;
                    num[i] = 5;
                    spin[4] = i;
                    pushStack(i, "x", xRot[i]);
                }
            }//for end
            count++;
            timer1.Enabled = true;
            this.simpleOpenGlControl1.Refresh();
        }
    }
}
