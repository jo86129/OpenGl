namespace _1042060_finalProject
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
            this.upClock = new System.Windows.Forms.Button();
            this.upAnti = new System.Windows.Forms.Button();
            this.downClock = new System.Windows.Forms.Button();
            this.downAnti = new System.Windows.Forms.Button();
            this.frontClock = new System.Windows.Forms.Button();
            this.frontAnti = new System.Windows.Forms.Button();
            this.backClock = new System.Windows.Forms.Button();
            this.backAnti = new System.Windows.Forms.Button();
            this.leftClock = new System.Windows.Forms.Button();
            this.leftAnti = new System.Windows.Forms.Button();
            this.rightClock = new System.Windows.Forms.Button();
            this.rightAnti = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(512, 463);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.Load += new System.EventHandler(this.simpleOpenGlControl1_Load);
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            this.simpleOpenGlControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleOpenGlControl1_KeyDown);
            // 
            // upClock
            // 
            this.upClock.Location = new System.Drawing.Point(571, 73);
            this.upClock.Name = "upClock";
            this.upClock.Size = new System.Drawing.Size(66, 37);
            this.upClock.TabIndex = 1;
            this.upClock.Text = "upClock";
            this.upClock.UseVisualStyleBackColor = true;
            this.upClock.Click += new System.EventHandler(this.upClock_Click);
            // 
            // upAnti
            // 
            this.upAnti.Location = new System.Drawing.Point(667, 73);
            this.upAnti.Name = "upAnti";
            this.upAnti.Size = new System.Drawing.Size(67, 37);
            this.upAnti.TabIndex = 2;
            this.upAnti.Text = "upAnti";
            this.upAnti.UseVisualStyleBackColor = true;
            this.upAnti.Click += new System.EventHandler(this.upAnti_Click);
            // 
            // downClock
            // 
            this.downClock.Location = new System.Drawing.Point(571, 138);
            this.downClock.Name = "downClock";
            this.downClock.Size = new System.Drawing.Size(66, 37);
            this.downClock.TabIndex = 3;
            this.downClock.Text = "downClock";
            this.downClock.UseVisualStyleBackColor = true;
            this.downClock.Click += new System.EventHandler(this.downClock_Click);
            // 
            // downAnti
            // 
            this.downAnti.Location = new System.Drawing.Point(667, 138);
            this.downAnti.Name = "downAnti";
            this.downAnti.Size = new System.Drawing.Size(67, 37);
            this.downAnti.TabIndex = 4;
            this.downAnti.Text = "downAnti";
            this.downAnti.UseVisualStyleBackColor = true;
            this.downAnti.Click += new System.EventHandler(this.downAnti_Click);
            // 
            // frontClock
            // 
            this.frontClock.Location = new System.Drawing.Point(571, 198);
            this.frontClock.Name = "frontClock";
            this.frontClock.Size = new System.Drawing.Size(66, 37);
            this.frontClock.TabIndex = 5;
            this.frontClock.Text = "frontClock";
            this.frontClock.UseVisualStyleBackColor = true;
            this.frontClock.Click += new System.EventHandler(this.frontClock_Click);
            // 
            // frontAnti
            // 
            this.frontAnti.Location = new System.Drawing.Point(667, 198);
            this.frontAnti.Name = "frontAnti";
            this.frontAnti.Size = new System.Drawing.Size(67, 37);
            this.frontAnti.TabIndex = 6;
            this.frontAnti.Text = "frontAnti";
            this.frontAnti.UseVisualStyleBackColor = true;
            this.frontAnti.Click += new System.EventHandler(this.frontAnti_Click);
            // 
            // backClock
            // 
            this.backClock.Location = new System.Drawing.Point(571, 258);
            this.backClock.Name = "backClock";
            this.backClock.Size = new System.Drawing.Size(66, 37);
            this.backClock.TabIndex = 7;
            this.backClock.Text = "backClock";
            this.backClock.UseVisualStyleBackColor = true;
            this.backClock.Click += new System.EventHandler(this.backClock_Click);
            // 
            // backAnti
            // 
            this.backAnti.Location = new System.Drawing.Point(667, 258);
            this.backAnti.Name = "backAnti";
            this.backAnti.Size = new System.Drawing.Size(67, 37);
            this.backAnti.TabIndex = 8;
            this.backAnti.Text = "backAnti";
            this.backAnti.UseVisualStyleBackColor = true;
            this.backAnti.Click += new System.EventHandler(this.backAnti_Click);
            // 
            // leftClock
            // 
            this.leftClock.Location = new System.Drawing.Point(571, 323);
            this.leftClock.Name = "leftClock";
            this.leftClock.Size = new System.Drawing.Size(66, 37);
            this.leftClock.TabIndex = 10;
            this.leftClock.Text = "leftClock";
            this.leftClock.UseVisualStyleBackColor = true;
            this.leftClock.Click += new System.EventHandler(this.leftClock_Click);
            // 
            // leftAnti
            // 
            this.leftAnti.Location = new System.Drawing.Point(667, 323);
            this.leftAnti.Name = "leftAnti";
            this.leftAnti.Size = new System.Drawing.Size(67, 37);
            this.leftAnti.TabIndex = 9;
            this.leftAnti.Text = "leftAnti";
            this.leftAnti.UseVisualStyleBackColor = true;
            this.leftAnti.Click += new System.EventHandler(this.leftAnti_Click);
            // 
            // rightClock
            // 
            this.rightClock.Location = new System.Drawing.Point(571, 384);
            this.rightClock.Name = "rightClock";
            this.rightClock.Size = new System.Drawing.Size(66, 37);
            this.rightClock.TabIndex = 11;
            this.rightClock.Text = "rightClock";
            this.rightClock.UseVisualStyleBackColor = true;
            this.rightClock.Click += new System.EventHandler(this.rightClock_Click);
            // 
            // rightAnti
            // 
            this.rightAnti.Location = new System.Drawing.Point(667, 384);
            this.rightAnti.Name = "rightAnti";
            this.rightAnti.Size = new System.Drawing.Size(67, 37);
            this.rightAnti.TabIndex = 12;
            this.rightAnti.Text = "rightAnti";
            this.rightAnti.UseVisualStyleBackColor = true;
            this.rightAnti.Click += new System.EventHandler(this.rightAnti_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 463);
            this.Controls.Add(this.rightAnti);
            this.Controls.Add(this.rightClock);
            this.Controls.Add(this.leftClock);
            this.Controls.Add(this.leftAnti);
            this.Controls.Add(this.backAnti);
            this.Controls.Add(this.backClock);
            this.Controls.Add(this.frontAnti);
            this.Controls.Add(this.frontClock);
            this.Controls.Add(this.downAnti);
            this.Controls.Add(this.downClock);
            this.Controls.Add(this.upAnti);
            this.Controls.Add(this.upClock);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Button upClock;
        private System.Windows.Forms.Button upAnti;
        private System.Windows.Forms.Button downClock;
        private System.Windows.Forms.Button downAnti;
        private System.Windows.Forms.Button frontClock;
        private System.Windows.Forms.Button frontAnti;
        private System.Windows.Forms.Button backClock;
        private System.Windows.Forms.Button backAnti;
        private System.Windows.Forms.Button leftClock;
        private System.Windows.Forms.Button leftAnti;
        private System.Windows.Forms.Button rightClock;
        private System.Windows.Forms.Button rightAnti;
        private System.Windows.Forms.Timer timer1;
    }
}

