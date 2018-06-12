namespace _1042060_HW4
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.red = new System.Windows.Forms.Button();
            this.green = new System.Windows.Forms.Button();
            this.blue = new System.Windows.Forms.Button();
            this.normal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(0, 0);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(467, 431);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.Load += new System.EventHandler(this.simpleOpenGlControl1_Load);
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            this.simpleOpenGlControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleOpenGlControl1_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(48, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // red
            // 
            this.red.Location = new System.Drawing.Point(480, 97);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(75, 23);
            this.red.TabIndex = 2;
            this.red.Text = "紅";
            this.red.UseVisualStyleBackColor = true;
            this.red.Click += new System.EventHandler(this.red_Click);
            // 
            // green
            // 
            this.green.Location = new System.Drawing.Point(480, 142);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(75, 23);
            this.green.TabIndex = 3;
            this.green.Text = "綠";
            this.green.UseVisualStyleBackColor = true;
            this.green.Click += new System.EventHandler(this.green_Click);
            // 
            // blue
            // 
            this.blue.Location = new System.Drawing.Point(480, 187);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(75, 23);
            this.blue.TabIndex = 4;
            this.blue.Text = "藍";
            this.blue.UseVisualStyleBackColor = true;
            this.blue.Click += new System.EventHandler(this.blue_Click);
            // 
            // normal
            // 
            this.normal.Location = new System.Drawing.Point(480, 228);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(75, 23);
            this.normal.TabIndex = 5;
            this.normal.Text = "白";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.Click += new System.EventHandler(this.normal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 455);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "press X→關燈";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "press Z→依序開燈";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 480);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.normal);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button red;
        private System.Windows.Forms.Button green;
        private System.Windows.Forms.Button blue;
        private System.Windows.Forms.Button normal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

