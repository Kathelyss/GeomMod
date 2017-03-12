namespace GeomMod
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_Axis = new System.Windows.Forms.Label();
            this.simpleOpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.label_Object = new System.Windows.Forms.Label();
            this.comboBox_Axis = new System.Windows.Forms.ComboBox();
            this.comboBox_Object = new System.Windows.Forms.ComboBox();
            this.label_X = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.label_Z = new System.Windows.Forms.Label();
            this.trackBar_X = new System.Windows.Forms.TrackBar();
            this.trackBar_Y = new System.Windows.Forms.TrackBar();
            this.trackBar_Z = new System.Windows.Forms.TrackBar();
            this.trackBar_Zoom = new System.Windows.Forms.TrackBar();
            this.trackBar_Angle = new System.Windows.Forms.TrackBar();
            this.label_Zoom = new System.Windows.Forms.Label();
            this.label_Angle = new System.Windows.Forms.Label();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.label_InfoX = new System.Windows.Forms.Label();
            this.label_InfoY = new System.Windows.Forms.Label();
            this.label_InfoZ = new System.Windows.Forms.Label();
            this.label_InfoAngle = new System.Windows.Forms.Label();
            this.label_InfoZoom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Zoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Angle)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Axis
            // 
            this.label_Axis.AutoSize = true;
            this.label_Axis.Location = new System.Drawing.Point(633, 27);
            this.label_Axis.Name = "label_Axis";
            this.label_Axis.Size = new System.Drawing.Size(87, 20);
            this.label_Axis.TabIndex = 0;
            this.label_Axis.Text = "Вращение";
            // 
            // simpleOpenGlControl
            // 
            this.simpleOpenGlControl.AccumBits = ((byte)(0));
            this.simpleOpenGlControl.AutoCheckErrors = false;
            this.simpleOpenGlControl.AutoFinish = false;
            this.simpleOpenGlControl.AutoMakeCurrent = true;
            this.simpleOpenGlControl.AutoSwapBuffers = true;
            this.simpleOpenGlControl.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl.ColorBits = ((byte)(32));
            this.simpleOpenGlControl.DepthBits = ((byte)(16));
            this.simpleOpenGlControl.Location = new System.Drawing.Point(13, 13);
            this.simpleOpenGlControl.Name = "simpleOpenGlControl";
            this.simpleOpenGlControl.Size = new System.Drawing.Size(590, 590);
            this.simpleOpenGlControl.StencilBits = ((byte)(0));
            this.simpleOpenGlControl.TabIndex = 1;
            // 
            // label_Object
            // 
            this.label_Object.AutoSize = true;
            this.label_Object.Location = new System.Drawing.Point(633, 81);
            this.label_Object.Name = "label_Object";
            this.label_Object.Size = new System.Drawing.Size(210, 20);
            this.label_Object.TabIndex = 2;
            this.label_Object.Text = "Объект для визуализации";
            // 
            // comboBox_Axis
            // 
            this.comboBox_Axis.FormattingEnabled = true;
            this.comboBox_Axis.Items.AddRange(new object[] {
            "вдоль оси Х",
            "вдоль оси Y",
            "вдоль оси Z"});
            this.comboBox_Axis.Location = new System.Drawing.Point(637, 50);
            this.comboBox_Axis.Name = "comboBox_Axis";
            this.comboBox_Axis.Size = new System.Drawing.Size(213, 28);
            this.comboBox_Axis.TabIndex = 3;
            this.comboBox_Axis.SelectedIndexChanged += new System.EventHandler(this.comboBox_Axis_SelectedIndexChanged);
            // 
            // comboBox_Object
            // 
            this.comboBox_Object.FormattingEnabled = true;
            this.comboBox_Object.Items.AddRange(new object[] {
            "сфера",
            "цилиндр",
            "куб",
            "конус",
            "тор"});
            this.comboBox_Object.Location = new System.Drawing.Point(637, 104);
            this.comboBox_Object.Name = "comboBox_Object";
            this.comboBox_Object.Size = new System.Drawing.Size(213, 28);
            this.comboBox_Object.TabIndex = 4;
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(633, 164);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(20, 20);
            this.label_X.TabIndex = 5;
            this.label_X.Text = "X";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(690, 164);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(20, 20);
            this.label_Y.TabIndex = 6;
            this.label_Y.Text = "Y";
            // 
            // label_Z
            // 
            this.label_Z.AutoSize = true;
            this.label_Z.Location = new System.Drawing.Point(752, 164);
            this.label_Z.Name = "label_Z";
            this.label_Z.Size = new System.Drawing.Size(19, 20);
            this.label_Z.TabIndex = 7;
            this.label_Z.Text = "Z";
            // 
            // trackBar_X
            // 
            this.trackBar_X.Location = new System.Drawing.Point(637, 209);
            this.trackBar_X.Maximum = 50000;
            this.trackBar_X.Minimum = -50000;
            this.trackBar_X.Name = "trackBar_X";
            this.trackBar_X.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_X.Size = new System.Drawing.Size(69, 394);
            this.trackBar_X.TabIndex = 8;
            this.trackBar_X.Scroll += new System.EventHandler(this.trackBar_X_Scroll);
            // 
            // trackBar_Y
            // 
            this.trackBar_Y.Location = new System.Drawing.Point(694, 209);
            this.trackBar_Y.Maximum = 50000;
            this.trackBar_Y.Minimum = -50000;
            this.trackBar_Y.Name = "trackBar_Y";
            this.trackBar_Y.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Y.Size = new System.Drawing.Size(69, 394);
            this.trackBar_Y.TabIndex = 9;
            this.trackBar_Y.Scroll += new System.EventHandler(this.trackBar_Y_Scroll);
            // 
            // trackBar_Z
            // 
            this.trackBar_Z.Location = new System.Drawing.Point(756, 209);
            this.trackBar_Z.Maximum = 50000;
            this.trackBar_Z.Minimum = -50000;
            this.trackBar_Z.Name = "trackBar_Z";
            this.trackBar_Z.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Z.Size = new System.Drawing.Size(69, 394);
            this.trackBar_Z.TabIndex = 10;
            this.trackBar_Z.Scroll += new System.EventHandler(this.trackBar_Z_Scroll);
            // 
            // trackBar_Zoom
            // 
            this.trackBar_Zoom.Location = new System.Drawing.Point(918, 209);
            this.trackBar_Zoom.Maximum = 5000;
            this.trackBar_Zoom.Minimum = -5000;
            this.trackBar_Zoom.Name = "trackBar_Zoom";
            this.trackBar_Zoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Zoom.Size = new System.Drawing.Size(69, 394);
            this.trackBar_Zoom.TabIndex = 14;
            this.trackBar_Zoom.Scroll += new System.EventHandler(this.trackBar_Zoom_Scroll);
            // 
            // trackBar_Angle
            // 
            this.trackBar_Angle.Location = new System.Drawing.Point(843, 209);
            this.trackBar_Angle.Maximum = 360;
            this.trackBar_Angle.Minimum = -360;
            this.trackBar_Angle.Name = "trackBar_Angle";
            this.trackBar_Angle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_Angle.Size = new System.Drawing.Size(69, 394);
            this.trackBar_Angle.TabIndex = 13;
            this.trackBar_Angle.Scroll += new System.EventHandler(this.trackBar_Angle_Scroll);
            // 
            // label_Zoom
            // 
            this.label_Zoom.AutoSize = true;
            this.label_Zoom.Location = new System.Drawing.Point(914, 164);
            this.label_Zoom.Name = "label_Zoom";
            this.label_Zoom.Size = new System.Drawing.Size(50, 20);
            this.label_Zoom.TabIndex = 12;
            this.label_Zoom.Text = "Zoom";
            // 
            // label_Angle
            // 
            this.label_Angle.AutoSize = true;
            this.label_Angle.Location = new System.Drawing.Point(839, 164);
            this.label_Angle.Name = "label_Angle";
            this.label_Angle.Size = new System.Drawing.Size(50, 20);
            this.label_Angle.TabIndex = 11;
            this.label_Angle.Text = "Angle";
            // 
            // RenderTimer
            // 
            this.RenderTimer.Enabled = true;
            this.RenderTimer.Interval = 30;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // label_InfoX
            // 
            this.label_InfoX.AutoSize = true;
            this.label_InfoX.Location = new System.Drawing.Point(633, 606);
            this.label_InfoX.Name = "label_InfoX";
            this.label_InfoX.Size = new System.Drawing.Size(18, 20);
            this.label_InfoX.TabIndex = 15;
            this.label_InfoX.Text = "0";
            // 
            // label_InfoY
            // 
            this.label_InfoY.AutoSize = true;
            this.label_InfoY.Location = new System.Drawing.Point(688, 606);
            this.label_InfoY.Name = "label_InfoY";
            this.label_InfoY.Size = new System.Drawing.Size(18, 20);
            this.label_InfoY.TabIndex = 16;
            this.label_InfoY.Text = "0";
            // 
            // label_InfoZ
            // 
            this.label_InfoZ.AutoSize = true;
            this.label_InfoZ.Location = new System.Drawing.Point(745, 606);
            this.label_InfoZ.Name = "label_InfoZ";
            this.label_InfoZ.Size = new System.Drawing.Size(18, 20);
            this.label_InfoZ.TabIndex = 17;
            this.label_InfoZ.Text = "0";
            // 
            // label_InfoAngle
            // 
            this.label_InfoAngle.AutoSize = true;
            this.label_InfoAngle.Location = new System.Drawing.Point(839, 606);
            this.label_InfoAngle.Name = "label_InfoAngle";
            this.label_InfoAngle.Size = new System.Drawing.Size(18, 20);
            this.label_InfoAngle.TabIndex = 18;
            this.label_InfoAngle.Text = "0";
            // 
            // label_InfoZoom
            // 
            this.label_InfoZoom.AutoSize = true;
            this.label_InfoZoom.Location = new System.Drawing.Point(914, 606);
            this.label_InfoZoom.Name = "label_InfoZoom";
            this.label_InfoZoom.Size = new System.Drawing.Size(18, 20);
            this.label_InfoZoom.TabIndex = 19;
            this.label_InfoZoom.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 642);
            this.Controls.Add(this.label_InfoZoom);
            this.Controls.Add(this.label_InfoAngle);
            this.Controls.Add(this.label_InfoZ);
            this.Controls.Add(this.label_InfoY);
            this.Controls.Add(this.label_InfoX);
            this.Controls.Add(this.trackBar_Zoom);
            this.Controls.Add(this.trackBar_Angle);
            this.Controls.Add(this.label_Zoom);
            this.Controls.Add(this.label_Angle);
            this.Controls.Add(this.trackBar_Z);
            this.Controls.Add(this.trackBar_Y);
            this.Controls.Add(this.trackBar_X);
            this.Controls.Add(this.label_Z);
            this.Controls.Add(this.label_Y);
            this.Controls.Add(this.label_X);
            this.Controls.Add(this.comboBox_Object);
            this.Controls.Add(this.comboBox_Axis);
            this.Controls.Add(this.label_Object);
            this.Controls.Add(this.simpleOpenGlControl);
            this.Controls.Add(this.label_Axis);
            this.Name = "MainForm";
            this.Text = "Геометрическое моделирование";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Zoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Angle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Axis;
        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl;
        private System.Windows.Forms.Label label_Object;
        private System.Windows.Forms.ComboBox comboBox_Axis;
        private System.Windows.Forms.ComboBox comboBox_Object;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.Label label_Z;
        private System.Windows.Forms.TrackBar trackBar_X;
        private System.Windows.Forms.TrackBar trackBar_Y;
        private System.Windows.Forms.TrackBar trackBar_Z;
        private System.Windows.Forms.TrackBar trackBar_Zoom;
        private System.Windows.Forms.TrackBar trackBar_Angle;
        private System.Windows.Forms.Label label_Zoom;
        private System.Windows.Forms.Label label_Angle;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.Label label_InfoX;
        private System.Windows.Forms.Label label_InfoY;
        private System.Windows.Forms.Label label_InfoZ;
        private System.Windows.Forms.Label label_InfoAngle;
        private System.Windows.Forms.Label label_InfoZoom;
    }
}

