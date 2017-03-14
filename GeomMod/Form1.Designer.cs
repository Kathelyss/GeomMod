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
            this.comboBoxFigure1 = new System.Windows.Forms.ComboBox();
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
            this.comboBoxFigure2 = new System.Windows.Forms.ComboBox();
            this.labelFigure2 = new System.Windows.Forms.Label();
            this.labelFig1Param1 = new System.Windows.Forms.Label();
            this.labelFig1Param2 = new System.Windows.Forms.Label();
            this.textBoxFig1Param1 = new System.Windows.Forms.TextBox();
            this.textBoxFig1Param2 = new System.Windows.Forms.TextBox();
            this.textBoxFig2Param2 = new System.Windows.Forms.TextBox();
            this.textBoxFig2Param1 = new System.Windows.Forms.TextBox();
            this.labelFig2Param2 = new System.Windows.Forms.Label();
            this.labelFig2Param1 = new System.Windows.Forms.Label();
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
            this.labelAxis.Location = new System.Drawing.Point(1030, 12);
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
            this.simpleOpenGlControl.Location = new System.Drawing.Point(426, 12);
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
            this.labelFigure1.Size = new System.Drawing.Size(78, 20);
            this.labelFigure1.TabIndex = 2;
            this.labelFigure1.Text = "Фигура 1";
            // 
            // comboBoxAxis
            // 
            this.comboBoxAxis.FormattingEnabled = true;
            this.comboBoxAxis.Items.AddRange(new object[] {
            "вокруг оси Х",
            "вокруг оси Y",
            "вокруг оси Z"});
            this.comboBoxAxis.Location = new System.Drawing.Point(1034, 35);
            this.comboBoxAxis.Name = "comboBoxAxis";
            this.comboBoxAxis.Size = new System.Drawing.Size(133, 28);
            this.comboBoxAxis.TabIndex = 3;
            this.comboBoxAxis.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxis_SelectedIndexChanged);
            // 
            // comboBoxFigure1
            // 
            this.comboBoxFigure1.FormattingEnabled = true;
            this.comboBoxFigure1.Items.AddRange(new object[] {
            "Сфера",
            "Цилиндр",
            "Куб",
            "Конус",
            "Тор"});
            this.comboBoxFigure1.Location = new System.Drawing.Point(10, 60);
            this.comboBoxFigure1.Name = "comboBoxFigure1";
            this.comboBoxFigure1.Size = new System.Drawing.Size(213, 28);
            this.comboBoxFigure1.TabIndex = 4;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(996, 606);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(20, 20);
            this.labelX.TabIndex = 5;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(325, 13);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(20, 20);
            this.labelY.TabIndex = 6;
            this.labelY.Text = "Y";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(1035, 75);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(74, 20);
            this.labelZ.TabIndex = 7;
            this.labelZ.Text = "Z (Zoom)";
            // 
            // trackBarX
            // 
            this.trackBarX.Location = new System.Drawing.Point(426, 629);
            this.trackBarX.Maximum = 50000;
            this.trackBarX.Minimum = -50000;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(590, 69);
            this.trackBarX.TabIndex = 8;
            this.trackBarX.Scroll += new System.EventHandler(this.trackBarX_Scroll);
            // 
            // trackBarY
            // 
            this.trackBarY.Location = new System.Drawing.Point(351, 13);
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
            this.trackBarZ.Location = new System.Drawing.Point(1042, 98);
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
            this.trackBarAngle.Location = new System.Drawing.Point(1118, 98);
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
            this.labelAngle.Location = new System.Drawing.Point(1115, 75);
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
            this.labelInfoX.Location = new System.Drawing.Point(710, 669);
            this.labelInfoX.Name = "labelInfoX";
            this.labelInfoX.Size = new System.Drawing.Size(18, 20);
            this.labelInfoX.TabIndex = 15;
            this.labelInfoX.Text = "0";
            // 
            // labelInfoY
            // 
            this.labelInfoY.AutoSize = true;
            this.labelInfoY.Location = new System.Drawing.Point(357, 606);
            this.labelInfoY.Name = "labelInfoY";
            this.labelInfoY.Size = new System.Drawing.Size(18, 20);
            this.labelInfoY.TabIndex = 16;
            this.labelInfoY.Text = "0";
            // 
            // labelInfoZ
            // 
            this.labelInfoZ.AutoSize = true;
            this.labelInfoZ.Location = new System.Drawing.Point(1048, 591);
            this.labelInfoZ.Name = "labelInfoZ";
            this.labelInfoZ.Size = new System.Drawing.Size(18, 20);
            this.labelInfoZ.TabIndex = 17;
            this.labelInfoZ.Text = "0";
            // 
            // labelInfoAngle
            // 
            this.labelInfoAngle.AutoSize = true;
            this.labelInfoAngle.Location = new System.Drawing.Point(1125, 591);
            this.labelInfoAngle.Name = "labelInfoAngle";
            this.labelInfoAngle.Size = new System.Drawing.Size(18, 20);
            this.labelInfoAngle.TabIndex = 18;
            this.labelInfoAngle.Text = "0";
            // 
            // groupBoxParametrs
            // 
            this.groupBoxParametrs.Controls.Add(this.textBoxFig2Param2);
            this.groupBoxParametrs.Controls.Add(this.textBoxFig2Param1);
            this.groupBoxParametrs.Controls.Add(this.labelFig2Param2);
            this.groupBoxParametrs.Controls.Add(this.labelFig2Param1);
            this.groupBoxParametrs.Controls.Add(this.textBoxFig1Param2);
            this.groupBoxParametrs.Controls.Add(this.textBoxFig1Param1);
            this.groupBoxParametrs.Controls.Add(this.labelFig1Param2);
            this.groupBoxParametrs.Controls.Add(this.labelFig1Param1);
            this.groupBoxParametrs.Controls.Add(this.comboBoxFigure2);
            this.groupBoxParametrs.Controls.Add(this.labelFigure2);
            this.groupBoxParametrs.Controls.Add(this.comboBoxFigure1);
            this.groupBoxParametrs.Controls.Add(this.labelFigure1);
            this.groupBoxParametrs.Location = new System.Drawing.Point(12, 12);
            this.groupBoxParametrs.Name = "groupBoxParametrs";
            this.groupBoxParametrs.Size = new System.Drawing.Size(275, 676);
            this.groupBoxParametrs.TabIndex = 19;
            this.groupBoxParametrs.TabStop = false;
            this.groupBoxParametrs.Text = "Параметры фигур";
            // 
            // comboBoxFigure2
            // 
            this.comboBoxFigure2.FormattingEnabled = true;
            this.comboBoxFigure2.Items.AddRange(new object[] {
            "Сфера",
            "Цилиндр",
            "Куб",
            "Конус",
            "Тор"});
            this.comboBoxFigure2.Location = new System.Drawing.Point(10, 355);
            this.comboBoxFigure2.Name = "comboBoxFigure2";
            this.comboBoxFigure2.Size = new System.Drawing.Size(213, 28);
            this.comboBoxFigure2.TabIndex = 6;
            // 
            // labelFigure2
            // 
            this.labelFigure2.AutoSize = true;
            this.labelFigure2.Location = new System.Drawing.Point(6, 332);
            this.labelFigure2.Name = "labelFigure2";
            this.labelFigure2.Size = new System.Drawing.Size(78, 20);
            this.labelFigure2.TabIndex = 5;
            this.labelFigure2.Text = "Фигура 2";
            // 
            // labelFig1Param1
            // 
            this.labelFig1Param1.AutoSize = true;
            this.labelFig1Param1.Location = new System.Drawing.Point(6, 102);
            this.labelFig1Param1.Name = "labelFig1Param1";
            this.labelFig1Param1.Size = new System.Drawing.Size(51, 20);
            this.labelFig1Param1.TabIndex = 7;
            this.labelFig1Param1.Text = "label1";
            this.labelFig1Param1.Visible = false;
            // 
            // labelFig1Param2
            // 
            this.labelFig1Param2.AutoSize = true;
            this.labelFig1Param2.Location = new System.Drawing.Point(119, 102);
            this.labelFig1Param2.Name = "labelFig1Param2";
            this.labelFig1Param2.Size = new System.Drawing.Size(51, 20);
            this.labelFig1Param2.TabIndex = 8;
            this.labelFig1Param2.Text = "label2";
            this.labelFig1Param2.Visible = false;
            // 
            // textBoxFig1Param1
            // 
            this.textBoxFig1Param1.Location = new System.Drawing.Point(10, 134);
            this.textBoxFig1Param1.Name = "textBoxFig1Param1";
            this.textBoxFig1Param1.Size = new System.Drawing.Size(100, 26);
            this.textBoxFig1Param1.TabIndex = 9;
            this.textBoxFig1Param1.Visible = false;
            // 
            // textBoxFig1Param2
            // 
            this.textBoxFig1Param2.Location = new System.Drawing.Point(123, 134);
            this.textBoxFig1Param2.Name = "textBoxFig1Param2";
            this.textBoxFig1Param2.Size = new System.Drawing.Size(100, 26);
            this.textBoxFig1Param2.TabIndex = 10;
            this.textBoxFig1Param2.Visible = false;
            // 
            // textBoxFig2Param2
            // 
            this.textBoxFig2Param2.Location = new System.Drawing.Point(123, 438);
            this.textBoxFig2Param2.Name = "textBoxFig2Param2";
            this.textBoxFig2Param2.Size = new System.Drawing.Size(100, 26);
            this.textBoxFig2Param2.TabIndex = 14;
            this.textBoxFig2Param2.Visible = false;
            // 
            // textBoxFig2Param1
            // 
            this.textBoxFig2Param1.Location = new System.Drawing.Point(10, 438);
            this.textBoxFig2Param1.Name = "textBoxFig2Param1";
            this.textBoxFig2Param1.Size = new System.Drawing.Size(100, 26);
            this.textBoxFig2Param1.TabIndex = 13;
            this.textBoxFig2Param1.Visible = false;
            // 
            // labelFig2Param2
            // 
            this.labelFig2Param2.AutoSize = true;
            this.labelFig2Param2.Location = new System.Drawing.Point(119, 406);
            this.labelFig2Param2.Name = "labelFig2Param2";
            this.labelFig2Param2.Size = new System.Drawing.Size(51, 20);
            this.labelFig2Param2.TabIndex = 12;
            this.labelFig2Param2.Text = "label3";
            this.labelFig2Param2.Visible = false;
            // 
            // labelFig2Param1
            // 
            this.labelFig2Param1.AutoSize = true;
            this.labelFig2Param1.Location = new System.Drawing.Point(6, 406);
            this.labelFig2Param1.Name = "labelFig2Param1";
            this.labelFig2Param1.Size = new System.Drawing.Size(51, 20);
            this.labelFig2Param1.TabIndex = 11;
            this.labelFig2Param1.Text = "label4";
            this.labelFig2Param1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1230, 708);
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
        private System.Windows.Forms.ComboBox comboBoxFigure1;
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
        private System.Windows.Forms.ComboBox comboBoxFigure2;
        private System.Windows.Forms.Label labelFigure2;
        private System.Windows.Forms.TextBox textBoxFig2Param2;
        private System.Windows.Forms.TextBox textBoxFig2Param1;
        private System.Windows.Forms.Label labelFig2Param2;
        private System.Windows.Forms.Label labelFig2Param1;
        private System.Windows.Forms.TextBox textBoxFig1Param2;
        private System.Windows.Forms.TextBox textBoxFig1Param1;
        private System.Windows.Forms.Label labelFig1Param2;
        private System.Windows.Forms.Label labelFig1Param1;
    }
}

