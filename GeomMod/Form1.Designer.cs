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
            this.labelAxis = new System.Windows.Forms.Label();
            this.simpleOpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.labelFigure1 = new System.Windows.Forms.Label();
            this.comboBoxAxis = new System.Windows.Forms.ComboBox();
            this.comboBoxObject = new System.Windows.Forms.ComboBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelZ = new System.Windows.Forms.Label();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarZ = new System.Windows.Forms.TrackBar();
            this.trackBarAngle = new System.Windows.Forms.TrackBar();
            this.labelAngle = new System.Windows.Forms.Label();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.labelInfoX = new System.Windows.Forms.Label();
            this.labelInfoY = new System.Windows.Forms.Label();
            this.labelInfoZ = new System.Windows.Forms.Label();
            this.labelInfoAngle = new System.Windows.Forms.Label();
            this.groupBoxParametrs = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelFigure2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).BeginInit();
            this.groupBoxParametrs.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAxis
            // 
            this.labelAxis.AutoSize = true;
            this.labelAxis.Location = new System.Drawing.Point(1159, 11);
            this.labelAxis.Name = "labelAxis";
            this.labelAxis.Size = new System.Drawing.Size(137, 20);
            this.labelAxis.TabIndex = 0;
            this.labelAxis.Text = "Вращение сцены";
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
            this.simpleOpenGlControl.Location = new System.Drawing.Point(555, 11);
            this.simpleOpenGlControl.Name = "simpleOpenGlControl";
            this.simpleOpenGlControl.Size = new System.Drawing.Size(590, 590);
            this.simpleOpenGlControl.StencilBits = ((byte)(0));
            this.simpleOpenGlControl.TabIndex = 1;
            // 
            // labelFigure1
            // 
            this.labelFigure1.AutoSize = true;
            this.labelFigure1.Location = new System.Drawing.Point(6, 37);
            this.labelFigure1.Name = "labelFigure1";
            this.labelFigure1.Size = new System.Drawing.Size(210, 20);
            this.labelFigure1.TabIndex = 2;
            this.labelFigure1.Text = "Объект для визуализации";
            // 
            // comboBoxAxis
            // 
            this.comboBoxAxis.FormattingEnabled = true;
            this.comboBoxAxis.Items.AddRange(new object[] {
            "вокруг оси Х",
            "вокруг оси Y",
            "вокруг оси Z"});
            this.comboBoxAxis.Location = new System.Drawing.Point(1163, 34);
            this.comboBoxAxis.Name = "comboBoxAxis";
            this.comboBoxAxis.Size = new System.Drawing.Size(133, 28);
            this.comboBoxAxis.TabIndex = 3;
            this.comboBoxAxis.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxis_SelectedIndexChanged);
            // 
            // comboBoxObject
            // 
            this.comboBoxObject.FormattingEnabled = true;
            this.comboBoxObject.Items.AddRange(new object[] {
            "сфера",
            "цилиндр",
            "куб",
            "конус",
            "тор"});
            this.comboBoxObject.Location = new System.Drawing.Point(10, 60);
            this.comboBoxObject.Name = "comboBoxObject";
            this.comboBoxObject.Size = new System.Drawing.Size(213, 28);
            this.comboBoxObject.TabIndex = 4;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(1125, 605);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(20, 20);
            this.labelX.TabIndex = 5;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(454, 12);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(20, 20);
            this.labelY.TabIndex = 6;
            this.labelY.Text = "Y";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(1164, 74);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(74, 20);
            this.labelZ.TabIndex = 7;
            this.labelZ.Text = "Z (Zoom)";
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(555, 628);
            this.trackBarX.Maximum = 50000;
            this.trackBarX.Minimum = -50000;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(590, 69);
            this.trackBarX.TabIndex = 8;
            this.trackBarX.Scroll += new System.EventHandler(this.trackBarX_Scroll);
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(480, 12);
            this.trackBarY.Maximum = 50000;
            this.trackBarY.Minimum = -50000;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarY.Size = new System.Drawing.Size(69, 590);
            this.trackBarY.TabIndex = 9;
            this.trackBarY.Scroll += new System.EventHandler(this.trackBarY_Scroll);
            // 
            // trackBarZ
            // 
            this.trackBarZ.Location = new System.Drawing.Point(1171, 97);
            this.trackBarZ.Maximum = 50000;
            this.trackBarZ.Minimum = -50000;
            this.trackBarZ.Name = "trackBarZ";
            this.trackBarZ.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarZ.Size = new System.Drawing.Size(69, 490);
            this.trackBarZ.TabIndex = 10;
            this.trackBarZ.Scroll += new System.EventHandler(this.trackBarZ_Scroll);
            // 
            // trackBarAngle
            // 
            this.trackBarAngle.Location = new System.Drawing.Point(1247, 97);
            this.trackBarAngle.Maximum = 360;
            this.trackBarAngle.Minimum = -360;
            this.trackBarAngle.Name = "trackBarAngle";
            this.trackBarAngle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAngle.Size = new System.Drawing.Size(69, 490);
            this.trackBarAngle.TabIndex = 13;
            this.trackBarAngle.Scroll += new System.EventHandler(this.trackBarAngle_Scroll);
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Location = new System.Drawing.Point(1244, 74);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(50, 20);
            this.labelAngle.TabIndex = 11;
            this.labelAngle.Text = "Angle";
            // 
            // RenderTimer
            // 
            this.RenderTimer.Enabled = true;
            this.RenderTimer.Interval = 30;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // labelInfoX
            // 
            this.labelInfoX.AutoSize = true;
            this.labelInfoX.Location = new System.Drawing.Point(839, 668);
            this.labelInfoX.Name = "labelInfoX";
            this.labelInfoX.Size = new System.Drawing.Size(18, 20);
            this.labelInfoX.TabIndex = 15;
            this.labelInfoX.Text = "0";
            // 
            // labelInfoY
            // 
            this.labelInfoY.AutoSize = true;
            this.labelInfoY.Location = new System.Drawing.Point(486, 605);
            this.labelInfoY.Name = "labelInfoY";
            this.labelInfoY.Size = new System.Drawing.Size(18, 20);
            this.labelInfoY.TabIndex = 16;
            this.labelInfoY.Text = "0";
            // 
            // labelInfoZ
            // 
            this.labelInfoZ.AutoSize = true;
            this.labelInfoZ.Location = new System.Drawing.Point(1177, 590);
            this.labelInfoZ.Name = "labelInfoZ";
            this.labelInfoZ.Size = new System.Drawing.Size(18, 20);
            this.labelInfoZ.TabIndex = 17;
            this.labelInfoZ.Text = "0";
            // 
            // labelInfoAngle
            // 
            this.labelInfoAngle.AutoSize = true;
            this.labelInfoAngle.Location = new System.Drawing.Point(1254, 590);
            this.labelInfoAngle.Name = "labelInfoAngle";
            this.labelInfoAngle.Size = new System.Drawing.Size(18, 20);
            this.labelInfoAngle.TabIndex = 18;
            this.labelInfoAngle.Text = "0";
            // 
            // groupBoxParametrs
            // 
            this.groupBoxParametrs.Controls.Add(this.comboBox1);
            this.groupBoxParametrs.Controls.Add(this.labelFigure2);
            this.groupBoxParametrs.Controls.Add(this.comboBoxObject);
            this.groupBoxParametrs.Controls.Add(this.labelFigure1);
            this.groupBoxParametrs.Location = new System.Drawing.Point(12, 12);
            this.groupBoxParametrs.Name = "groupBoxParametrs";
            this.groupBoxParametrs.Size = new System.Drawing.Size(425, 676);
            this.groupBoxParametrs.TabIndex = 19;
            this.groupBoxParametrs.TabStop = false;
            this.groupBoxParametrs.Text = "Параметры фигур";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "сфера",
            "цилиндр",
            "куб",
            "конус",
            "тор"});
            this.comboBox1.Location = new System.Drawing.Point(10, 249);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 28);
            this.comboBox1.TabIndex = 6;
            // 
            // labelFigure2
            // 
            this.labelFigure2.AutoSize = true;
            this.labelFigure2.Location = new System.Drawing.Point(6, 226);
            this.labelFigure2.Name = "labelFigure2";
            this.labelFigure2.Size = new System.Drawing.Size(210, 20);
            this.labelFigure2.TabIndex = 5;
            this.labelFigure2.Text = "Объект для визуализации";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 708);
            this.Controls.Add(this.groupBoxParametrs);
            this.Controls.Add(this.labelInfoAngle);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelInfoZ);
            this.Controls.Add(this.labelInfoY);
            this.Controls.Add(this.labelInfoX);
            this.Controls.Add(this.trackBarAngle);
            this.Controls.Add(this.labelAngle);
            this.Controls.Add(this.trackBarZ);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.labelZ);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.comboBoxAxis);
            this.Controls.Add(this.simpleOpenGlControl);
            this.Controls.Add(this.labelAxis);
            this.Name = "MainForm";
            this.Text = "Геометрическое моделирование";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).EndInit();
            this.groupBoxParametrs.ResumeLayout(false);
            this.groupBoxParametrs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAxis;
        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl;
        private System.Windows.Forms.Label labelFigure1;
        private System.Windows.Forms.ComboBox comboBoxAxis;
        private System.Windows.Forms.ComboBox comboBoxObject;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarZ;
        private System.Windows.Forms.TrackBar trackBarAngle;
        private System.Windows.Forms.Label labelAngle;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.Label labelInfoX;
        private System.Windows.Forms.Label labelInfoY;
        private System.Windows.Forms.Label labelInfoZ;
        private System.Windows.Forms.Label labelInfoAngle;
        private System.Windows.Forms.GroupBox groupBoxParametrs;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelFigure2;
    }
}

