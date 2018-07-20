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
using Example5;
using Show3DModels;
using Tao.DevIl;

namespace _20180523room
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180
        double Radius = 3.0, Longitude = 90.0, Latitude = 0.0; //經度 / 緯度

        Mesh house = new Mesh();
        Obj3DS model = new Obj3DS();

        uint[] texName = new uint[5]; //建立儲存紋理編號的陣列  uint 表示是符號
        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            Glut.glutInit();
            Il.ilInit(); //因為要用到Tao.DevIl
            Ilu.iluInit();
        }
        void SetViewingVolumne()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            double aspect = (double)this.simpleOpenGlControl1.Size.Width / (double)this.simpleOpenGlControl1.Size.Height;
            Glu.gluPerspective(45, aspect, 0.1, 100.0);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
        }
        void MyInit()
        {
            Gl.glClearColor(0.0f,0.0f,0.0f,1.0f);
            Gl.glClearDepth(1.0f);

            float[] global_ambient = new float[] { 0.05f, 0.05f, 0.05f, 1.0f };
            float[] light0_ambient = new float[] { 0.05f, 0.05f, 0.05f, 1.0f };
            float[] light0_diffuse = new float[] { 0.03f, 0.03f, 0.03f, 1.0f };
            float[] light0_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f }; //針對金屬材質高反光

            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            //設定光源
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular);

            float[] light1_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light1_diffuse = new float[] { 0.7f, 0.7f, 0.7f, 1.0f };
            float[] light1_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f }; //針對金屬材質高反光

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);
            //這是衰減的設定  有設定這個就會變成探照燈
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 95.0f); //後面的數字視角度
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_EXPONENT, 10.0f);

            //Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK,Gl.GL_LINE);//把場景變成線框的模式
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);//設定混合計算公式


            Gl.glEnable(Gl.GL_DEPTH_TEST);//打開深度測試
            Gl.glEnable(Gl.GL_LIGHTING);//open 光影
            Gl.glEnable(Gl.GL_LIGHT0); //給一個光
            Gl.glEnable(Gl.GL_LIGHT1); //開啟第二個光
            Gl.glEnable(Gl.GL_NORMALIZE);//這是正規化 讓法向量都變回當為向量 因為用放大縮小會影響法向量
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);//開啟色彩材質


            /*house.ReadFile("C:\\Users\\asus\\Desktop\\電腦圖學\\polygonalmesh\\house.txt"); //這裡的檔案位置裡面的\ 因為在這裡是特殊符號 所以要雙斜線\\
            house.ReadFile("C:\\Users\\asus\\Desktop\\電腦圖學\\polygonalmesh\\jet.txt");
            model.Load("C:\\Users\\asus\\Desktop\\電腦圖學\\book_of_spells20071116222123\\book_of_spells\\book_open.3ds");
            model.CenterAndScaleModel(1.0f);*/

            Gl.glGenTextures(5, texName); //產生紋理物件 如果前面uint設定幾個 這裡的數字就要幾個  這是只要做一次就可以了 
            LoadTexture("C:\\Users\\asus\\Desktop\\電腦圖學\\20180523room\\20180523room\\testimages\\Poster.jpg", texName[0]); //要把副檔名打上去 最好是用絕對路徑 如果執行上沒有錯誤的話就是成功了  後面是放我們的紋理代號
            LoadTexture("C:\\Users\\asus\\Desktop\\電腦圖學\\20180523room\\20180523room\\testimages\\worldmap.jpg", texName[1]);
            LoadTexture("C:\\Users\\asus\\Desktop\\電腦圖學\\20180523room\\20180523room\\testimages\\CocaCola.jpg", texName[2]); 
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            SetViewingVolumne();
            MyInit();
        }
        private void CocaCola(double r,double h, int slices)
        {
            int Slices = 20;
            double dt = 360.0 / Slices;
            double x, z;

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texName[2]);
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (double theta = -180.0; theta <= 180.0 + dt * 0.5; theta += dt)  //180+dt*0.5 是為了部分計算的誤差，有些數值會讓這個圖形少一面
            {
                x = r * Math.Sin(theta * Math.PI / 180.0);
                z = r * Math.Cos(theta * Math.PI / 180.0);
                Gl.glNormal3d(x / r, 0, z / r); //法向量一定要事單位矩陣
                Gl.glTexCoord2d((theta+180.0) / 360.0, 1.0); //要縮放到0-1之間
                Gl.glVertex3d(x, h, z);
                Gl.glTexCoord2d((theta + 180.0) / 360.0, 0.0); //要縮放到0-1之間
                Gl.glVertex3d(x, 0, z);
            }
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
        private void Globe(double r, int Stacks, int Slices)
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D,texName[1]);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            
            double dp = 180.0 / Stacks, dt = 360.0 / Slices;
            double x, y, z;
           // Random rn = new Random(1);
            for (double phi = -(90 - dp); phi < 90 - dp; phi += dp)
            {
                Gl.glBegin(Gl.GL_QUAD_STRIP);
                for (double theta = 0.0; theta <= 360.0 + dt * 0.5; theta += dt)
                {

                    x = r * Math.Cos((phi + dp) * Math.PI / 180.0) * Math.Sin(theta * Math.PI / 180.0); //phi緯度 theta經度
                    y = r * Math.Sin((phi + dp) * Math.PI / 180.0);
                    z = r * Math.Cos((phi + dp) * Math.PI / 180.0) * Math.Cos(theta * Math.PI / 180.0);
                    Gl.glNormal3d(x / r, y / r, z / r);
                   // Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
                    Gl.glTexCoord2d(theta/360,(phi+dp+90)/180); //要縮放到0-1之間
                    Gl.glVertex3d(x, y, z);
                    x = r * Math.Cos(phi * Math.PI / 180.0) * Math.Sin(theta * Math.PI / 180.0);
                    y = r * Math.Sin(phi * Math.PI / 180.0);
                    z = r * Math.Cos(phi * Math.PI / 180.0) * Math.Cos(theta * Math.PI / 180.0);
                    Gl.glNormal3d(x / r, y / r, z / r);
                  //  Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
                    Gl.glTexCoord2d(theta / 360, (phi + 90) / 180); //要縮放到0-1之間
                    Gl.glVertex3d(x, y, z);
                }
                Gl.glEnd();
            }
            
            //北極
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glNormal3d(0.0, 1.0, 0.0);
            Gl.glTexCoord2d(0.5,1.0); //要縮放到0-1之間
            Gl.glVertex3d(0.0, r, 0.0);
            y = r * Math.Sin((90 - dp) * Math.PI / 180.0);
            for (double theta = 0.0; theta <= 360.0 + dt * 0.5; theta += dt)
            {
                x = r * Math.Cos((90 - dp) * Math.PI / 180.0) * Math.Sin(theta * Math.PI / 180.0);
                z = r * Math.Cos((90 - dp) * Math.PI / 180.0) * Math.Cos(theta * Math.PI / 180.0);
                Gl.glNormal3d(x / r, y / r, z / r);
               // Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
                Gl.glTexCoord2d(theta / 360, (90- dp + 90) / 180); //要縮放到0-1之間
                Gl.glVertex3d(x, y, z);
            }
            Gl.glEnd();
            //南極
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glNormal3d(0.0, -1.0, 0.0);
            Gl.glVertex3d(0.0, -r, 0.0);
            y = r * Math.Sin((dp - 90) * Math.PI / 180.0);
            for (double theta = 360.0; theta >= 0 - dt * 0.5; theta -= dt)
            {
                x = r * Math.Cos((dp - 90) * Math.PI / 180.0) * Math.Sin(theta * Math.PI / 180.0);
                z = r * Math.Cos((dp - 90) * Math.PI / 180.0) * Math.Cos(theta * Math.PI / 180.0);
                Gl.glNormal3d(x / r, y / r, z / r);
              //  Gl.glColor3ub((byte)rn.Next(0, 255), (byte)rn.Next(0, 255), (byte)rn.Next(0, 255));
                Gl.glTexCoord2d(theta / 360, (dp-90+90) / 180); //要縮放到0-1之間
                Gl.glVertex3d(x, y, z);
            }
            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);

        }

        private void MySolidCube(double size, int slices) //讓模型切得更細，這樣才會有很多法向量
        {
            double s = 1.0 / slices; //看一個小邊常要多少

            Gl.glPushMatrix();
            Gl.glScaled(size,size,size);
            for(int i=0;i<slices;i++){
                for(int j=0;j<slices;j++)
                {
                    Gl.glPushMatrix();
                    Gl.glTranslated(-0.5+i*s,0.0,-0.5+j*s); //讓他位移到下個位置
                    Gl.glScaled(s,1.0,s); //把它縮放成一個小邊長的大小
                    Gl.glTranslated(0.5,0.0,0.5);
                    Glut.glutSolidCube(1.0);
                    Gl.glPopMatrix();
                }
            }
            Gl.glPopMatrix();
          

        }

        private void room()
        {
            
            Gl.glColor3ub(107,201,224);
             //ground
            Gl.glPushMatrix(); 
            Gl.glTranslated(0.5,0.01,0.5);//把它移到對齊XY軸  Y是0.01是因為前面把它壓扁後厚度為0.02 所以她的一辦事0.01
            Gl.glScaled(1.0,0.02,1.0);//壓扁這個cube 讓他變成一面牆
            //Glut.glutSolidCube(1);
            MySolidCube(1.0, 100);
            Gl.glPopMatrix();


            Gl.glPushMatrix();
            Gl.glRotated(-90.0,1,0,0); //1把它以X軸旋轉90度變成另一面牆
            Gl.glTranslated(0.5, 0.01, 0.5);
            Gl.glScaled(1.0, 0.02, 1.0);
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(90.0, 0, 0, 1.0);//對Z軸旋轉90度
            Gl.glTranslated(0.5, 0.01, 0.5);//把它移到對齊XY軸  Y是0.01是因為前面把它壓扁後厚度為0.02 所以她的一辦事0.01
            Gl.glScaled(1.0, 0.02, 1.0);//壓扁這個cube 讓他變成一面牆
            Glut.glutSolidCube(1);
            Gl.glPopMatrix();

          
        }
        private void table(double topWid,double thickness,double legLength) //讓他可以調整他的大小寬度
        {
            Gl.glColor3ub(102,51,0);

            Gl.glPushMatrix();
            Gl.glScaled(topWid,thickness,topWid);
           // Glut.glutSolidCube(1.0);
            MySolidCube(1.0, 100);
            Gl.glPopMatrix();

            double d = (topWid / 2) * 0.7; //桌腳移動的位置

            Gl.glPushMatrix();
            Gl.glTranslated(d,0.0,d);
            Gl.glTranslated(0.0,-legLength/2,0.0);
            Gl.glScaled(thickness, -legLength, thickness);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(d, 0.0, -d);
            Gl.glTranslated(0.0, -legLength / 2, 0.0);
            Gl.glScaled(thickness, -legLength, thickness);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-d, 0.0, -d);
            Gl.glTranslated(0.0, -legLength / 2, 0.0);
            Gl.glScaled(thickness, -legLength, thickness);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-d, 0.0, d);
            Gl.glTranslated(0.0, -legLength / 2, 0.0);
            Gl.glScaled(thickness, -legLength, thickness);
            Glut.glutSolidCube(1.0);
            Gl.glPopMatrix();
        }
        private void jackPart()
        {
            Gl.glPushMatrix();
            Gl.glScaled(0.2,0.2,1.0);
            Glut.glutSolidSphere(1.0,16,16);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.0,0.0,1.0);
            Glut.glutSolidSphere(0.2,16,16);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 0.0, -1.0);
            Glut.glutSolidSphere(0.2, 16, 16);
            Gl.glPopMatrix();
        }
        private void jack()
        {
            Gl.glColor3ub(226,206,112);
            jackPart();

            Gl.glPushMatrix();
            Gl.glRotated(90.0,1,0,0);
            jackPart();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(90.0, 0, 1, 0);
            jackPart();
            Gl.glPopMatrix();


        }
        private void poster()
        {
            double aspect = 452.0 / 640.0;
            Gl.glBindTexture(Gl.GL_TEXTURE_2D,texName[0]);//告訴電腦 我們要用哪個圖片檔案 後面設定哪個紋理圖片
            Gl.glEnable(Gl.GL_TEXTURE_2D);//開啟平面貼圖的功能 這要成對出現 所以下面要把他disable

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3d(1.0, 1.0, 1.0);
            Gl.glNormal3d(1.0, 0.0, 0.0); //設定法向量的方向 要設在所有定點的前面，表示下面的點都是用這個法向量

            Gl.glTexCoord2d(1.0,0.0);//表示貼圖座標 要放在每個點的前面
            Gl.glVertex3d(0.01, 0.3, 0.2); //因為有深度測試，所以我們的X座標需要加上一些數值，這樣電腦才知道誰比較前面

            Gl.glTexCoord2d(1.0, 1.0);//表示貼圖座標
            Gl.glVertex3d(0.01, 0.8, 0.2);

            Gl.glTexCoord2d(0.0, 1.0);//表示貼圖座標
            Gl.glVertex3d(0.01, 0.8, 0.2+0.5*aspect);

            Gl.glTexCoord2d(0.0, 0.0);//表示貼圖座標
            Gl.glVertex3d(0.01, 0.3, 0.2 + 0.5 * aspect);

            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);//關掉平面貼圖的功能

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

            float[] light0_position = new float[] { 2.0f, 8.0f, 3.0f, 1.0f };//若最後一個值是1 表示光的位置，如果是0的話，表示光的方向
            float[] light1_position = new float[4]; //探照燈的位置
            float[] light1_direction = new float[3]; //探照燈的方向

            //探照燈的方向跟相機是一樣的位置
            light1_position[0]=(float)(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)* Math.Sin(Longitude * DEGREE_TO_RAD));
            light1_position[1]=(float)(Radius * Math.Sin(Latitude * DEGREE_TO_RAD));
            light1_position[2]=(float)(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)* Math.Cos(Longitude * DEGREE_TO_RAD));
            light1_position[3]=1.0f;

            light1_direction[0] = 0.0f - light1_position[0];
            light1_direction[1] = 0.0f - light1_position[1];
            light1_direction[2] = 0.0f - light1_position[2];

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1_position); //燈的位置
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light1_direction); //燈的方向

            room();
            Gl.glPushMatrix();
            Gl.glTranslated(0.6,0.3,0.6);
            table(0.6, 0.02, 0.3);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            
            Gl.glTranslated(0.6,0.4,0.6);
            Gl.glRotated(45.0, 1, 0, 0);
            Gl.glScaled(0.1,0.1,0.1);
            jack();
            Gl.glPopMatrix();

            Gl.glColor3d(1.0,1.0,1.0);
            Gl.glPushMatrix();
            Gl.glTranslated(0.7, 0.4, 0.4);
            Globe(0.1,32,32);
            Gl.glPopMatrix();

            poster();

            Gl.glPushMatrix();
            Gl.glColor3d(1.0,1.0,1.0);
            Gl.glTranslated(0.5,0.3,0.8);
            Gl.glScaled(0.1,0.1,0.1);
            CocaCola(0.3, 1.0, 8);
            Gl.glPopMatrix();


           // Globe(1.0, 32, 32);
          //  house.DrawByOpenGL();
           /* Gl.glPushMatrix();
            Gl.glScaled(0.03,0.03,0.03);
            house.DrawByOpenGL();
            Gl.glPopMatrix();*/
            //model.render();

            //建立混和的透明玻璃
            //這是一面偏綠的玻璃
            Gl.glEnable(Gl.GL_BLEND); //開啟混和 有開就有關
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor4d(0,1.0,0,0.2);
            Gl.glNormal3d(0.0, 0.0, 1.0);//法向量 在Z軸
            Gl.glVertex3d(0.0,1.0,1.0);
            Gl.glVertex3d(0.0, 0.0, 1.0);
            Gl.glVertex3d(1.0, 0.0, 1.0);
            Gl.glVertex3d(1.0, 1.0, 1.0);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_BLEND); //要記得關掉

        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolumne();
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
    }
 }

