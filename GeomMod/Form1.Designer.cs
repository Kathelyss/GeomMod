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
            this.numericUpDownFig2Param2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFig2Param1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFig1Param2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFig1Param1 = new System.Windows.Forms.NumericUpDown();
            this.labelFig2Param2 = new System.Windows.Forms.Label();
            this.labelFig2Param1 = new System.Windows.Forms.Label();
            this.labelFig1Param2 = new System.Windows.Forms.Label();
            this.labelFig1Param1 = new System.Windows.Forms.Label();
            this.comboBoxFigure2 = new System.Windows.Forms.ComboBox();
            this.labelFigure2 = new System.Windows.Forms.Label();
            this.numericUpDownFig2Param3 = new System.Windows.Forms.NumericUpDown();
            this.labelFig2Param3 = new System.Windows.Forms.Label();
            this.numericUpDownFig1Param3 = new System.Windows.Forms.NumericUpDown();
            this.labelFig1Param3 = new System.Windows.Forms.Label();
            this.numericUpDownCZ1 = new System.Windows.Forms.NumericUpDown();
            this.labelZ1 = new System.Windows.Forms.Label();
            this.numericUpDownCY1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCX1 = new System.Windows.Forms.NumericUpDown();
            this.labelY1 = new System.Windows.Forms.Label();
            this.labelX1 = new System.Windows.Forms.Label();
            this.numericUpDownCZ2 = new System.Windows.Forms.NumericUpDown();
            this.labelZ2 = new System.Windows.Forms.Label();
            this.numericUpDownCY2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCX2 = new System.Windows.Forms.NumericUpDown();
            this.labelY2 = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).BeginInit();
            this.groupBoxParametrs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCZ1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCZ2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCX2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAxis
            // 
            this.labelAxis.AutoSize = true;
            this.labelAxis.Location = new System.Drawing.Point(11, 76);
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
            this.simpleOpenGlControl.BackColor = System.Drawing.Color.White;
            this.simpleOpenGlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.simpleOpenGlControl.ColorBits = ((byte)(32));
            this.simpleOpenGlControl.DepthBits = ((byte)(16));
            this.simpleOpenGlControl.Location = new System.Drawing.Point(332, 33);
            this.simpleOpenGlControl.Name = "simpleOpenGlControl";
            this.simpleOpenGlControl.Size = new System.Drawing.Size(1000, 1000);
            this.simpleOpenGlControl.StencilBits = ((byte)(0));
            this.simpleOpenGlControl.TabIndex = 1;
            this.simpleOpenGlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SimpleOpenGlControl_MouseDown);
            this.simpleOpenGlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SimpleOpenGlControl_MouseMove);
            this.simpleOpenGlControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SimpleOpenGlControl_MouseUp);
            // 
            // labelFigure1
            // 
            this.labelFigure1.AutoSize = true;
            this.labelFigure1.Location = new System.Drawing.Point(11, 177);
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
            this.comboBoxAxis.Location = new System.Drawing.Point(15, 99);
            this.comboBoxAxis.Name = "comboBoxAxis";
            this.comboBoxAxis.Size = new System.Drawing.Size(145, 28);
            this.comboBoxAxis.TabIndex = 3;
            this.comboBoxAxis.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAxis_SelectedIndexChanged);
            // 
            // comboBoxFigure1
            // 
            this.comboBoxFigure1.FormattingEnabled = true;
            this.comboBoxFigure1.Items.AddRange(new object[] {
            "Сфера",
            "Цилиндр",
            "Куб",
            "Конус",
            "Параллелепипед"});
            this.comboBoxFigure1.Location = new System.Drawing.Point(15, 200);
            this.comboBoxFigure1.Name = "comboBoxFigure1";
            this.comboBoxFigure1.Size = new System.Drawing.Size(115, 28);
            this.comboBoxFigure1.TabIndex = 4;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.labelX.Location = new System.Drawing.Point(1313, 1036);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(20, 20);
            this.labelX.TabIndex = 5;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.ForeColor = System.Drawing.Color.Blue;
            this.labelY.Location = new System.Drawing.Point(223, 23);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(20, 20);
            this.labelY.TabIndex = 6;
            this.labelY.Text = "Y";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.ForeColor = System.Drawing.Color.Red;
            this.labelZ.Location = new System.Drawing.Point(1343, 23);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(74, 20);
            this.labelZ.TabIndex = 7;
            this.labelZ.Text = "Z (Zoom)";
            // 
            // trackBarX
            // 
            this.trackBarX.BackColor = System.Drawing.Color.White;
            this.trackBarX.Location = new System.Drawing.Point(324, 1059);
            this.trackBarX.Maximum = 50000;
            this.trackBarX.Minimum = -50000;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(1009, 69);
            this.trackBarX.TabIndex = 8;
            this.trackBarX.Scroll += new System.EventHandler(this.TrackBarX_Scroll);
            // 
            // trackBarY
            // 
            this.trackBarY.BackColor = System.Drawing.Color.White;
            this.trackBarY.Location = new System.Drawing.Point(249, 33);
            this.trackBarY.Maximum = 50000;
            this.trackBarY.Minimum = -50000;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarY.Size = new System.Drawing.Size(69, 1000);
            this.trackBarY.TabIndex = 9;
            this.trackBarY.Scroll += new System.EventHandler(this.TrackBarY_Scroll);
            // 
            // trackBarZ
            // 
            this.trackBarZ.BackColor = System.Drawing.Color.White;
            this.trackBarZ.Location = new System.Drawing.Point(1351, 58);
            this.trackBarZ.Maximum = 50000;
            this.trackBarZ.Minimum = -50000;
            this.trackBarZ.Name = "trackBarZ";
            this.trackBarZ.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarZ.Size = new System.Drawing.Size(69, 975);
            this.trackBarZ.TabIndex = 10;
            this.trackBarZ.Scroll += new System.EventHandler(this.TrackBarZ_Scroll);
            // 
            // trackBarAngle
            // 
            this.trackBarAngle.Location = new System.Drawing.Point(1427, 58);
            this.trackBarAngle.Maximum = 360;
            this.trackBarAngle.Minimum = -360;
            this.trackBarAngle.Name = "trackBarAngle";
            this.trackBarAngle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAngle.Size = new System.Drawing.Size(69, 975);
            this.trackBarAngle.TabIndex = 13;
            this.trackBarAngle.Scroll += new System.EventHandler(this.TrackBarAngle_Scroll);
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Location = new System.Drawing.Point(1423, 23);
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
            this.labelInfoX.Location = new System.Drawing.Point(820, 1108);
            this.labelInfoX.Name = "labelInfoX";
            this.labelInfoX.Size = new System.Drawing.Size(18, 20);
            this.labelInfoX.TabIndex = 15;
            this.labelInfoX.Text = "0";
            // 
            // labelInfoY
            // 
            this.labelInfoY.AutoSize = true;
            this.labelInfoY.Location = new System.Drawing.Point(258, 1036);
            this.labelInfoY.Name = "labelInfoY";
            this.labelInfoY.Size = new System.Drawing.Size(18, 20);
            this.labelInfoY.TabIndex = 16;
            this.labelInfoY.Text = "0";
            // 
            // labelInfoZ
            // 
            this.labelInfoZ.AutoSize = true;
            this.labelInfoZ.Location = new System.Drawing.Point(1367, 1059);
            this.labelInfoZ.Name = "labelInfoZ";
            this.labelInfoZ.Size = new System.Drawing.Size(18, 20);
            this.labelInfoZ.TabIndex = 17;
            this.labelInfoZ.Text = "0";
            // 
            // labelInfoAngle
            // 
            this.labelInfoAngle.AutoSize = true;
            this.labelInfoAngle.Location = new System.Drawing.Point(1444, 1059);
            this.labelInfoAngle.Name = "labelInfoAngle";
            this.labelInfoAngle.Size = new System.Drawing.Size(18, 20);
            this.labelInfoAngle.TabIndex = 18;
            this.labelInfoAngle.Text = "0";
            // 
            // groupBoxParametrs
            // 
            this.groupBoxParametrs.Controls.Add(this.numericUpDownCZ2);
            this.groupBoxParametrs.Controls.Add(this.labelZ2);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownCY2);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownCX2);
            this.groupBoxParametrs.Controls.Add(this.labelY2);
            this.groupBoxParametrs.Controls.Add(this.labelX2);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownCZ1);
            this.groupBoxParametrs.Controls.Add(this.labelZ1);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownCY1);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownCX1);
            this.groupBoxParametrs.Controls.Add(this.labelY1);
            this.groupBoxParametrs.Controls.Add(this.labelX1);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownFig1Param3);
            this.groupBoxParametrs.Controls.Add(this.labelFig1Param3);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownFig2Param3);
            this.groupBoxParametrs.Controls.Add(this.labelFig2Param3);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownFig2Param2);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownFig2Param1);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownFig1Param2);
            this.groupBoxParametrs.Controls.Add(this.numericUpDownFig1Param1);
            this.groupBoxParametrs.Controls.Add(this.labelFig2Param2);
            this.groupBoxParametrs.Controls.Add(this.labelFig2Param1);
            this.groupBoxParametrs.Controls.Add(this.labelFig1Param2);
            this.groupBoxParametrs.Controls.Add(this.labelFig1Param1);
            this.groupBoxParametrs.Controls.Add(this.comboBoxFigure2);
            this.groupBoxParametrs.Controls.Add(this.labelFigure2);
            this.groupBoxParametrs.Controls.Add(this.comboBoxFigure1);
            this.groupBoxParametrs.Controls.Add(this.labelFigure1);
            this.groupBoxParametrs.Controls.Add(this.comboBoxAxis);
            this.groupBoxParametrs.Controls.Add(this.labelAxis);
            this.groupBoxParametrs.Location = new System.Drawing.Point(23, 22);
            this.groupBoxParametrs.Name = "groupBoxParametrs";
            this.groupBoxParametrs.Size = new System.Drawing.Size(186, 934);
            this.groupBoxParametrs.TabIndex = 19;
            this.groupBoxParametrs.TabStop = false;
            this.groupBoxParametrs.Text = "Параметры фигур";
            // 
            // numericUpDownFig2Param2
            // 
            this.numericUpDownFig2Param2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFig2Param2.Location = new System.Drawing.Point(62, 672);
            this.numericUpDownFig2Param2.Name = "numericUpDownFig2Param2";
            this.numericUpDownFig2Param2.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownFig2Param2.TabIndex = 18;
            this.numericUpDownFig2Param2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownFig2Param2.Visible = false;
            // 
            // numericUpDownFig2Param1
            // 
            this.numericUpDownFig2Param1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFig2Param1.Location = new System.Drawing.Point(62, 628);
            this.numericUpDownFig2Param1.Name = "numericUpDownFig2Param1";
            this.numericUpDownFig2Param1.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownFig2Param1.TabIndex = 17;
            this.numericUpDownFig2Param1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownFig2Param1.Visible = false;
            // 
            // numericUpDownFig1Param2
            // 
            this.numericUpDownFig1Param2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFig1Param2.Location = new System.Drawing.Point(62, 293);
            this.numericUpDownFig1Param2.Name = "numericUpDownFig1Param2";
            this.numericUpDownFig1Param2.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownFig1Param2.TabIndex = 16;
            this.numericUpDownFig1Param2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownFig1Param2.Visible = false;
            // 
            // numericUpDownFig1Param1
            // 
            this.numericUpDownFig1Param1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFig1Param1.Location = new System.Drawing.Point(62, 249);
            this.numericUpDownFig1Param1.Name = "numericUpDownFig1Param1";
            this.numericUpDownFig1Param1.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownFig1Param1.TabIndex = 15;
            this.numericUpDownFig1Param1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownFig1Param1.Visible = false;
            // 
            // labelFig2Param2
            // 
            this.labelFig2Param2.AutoSize = true;
            this.labelFig2Param2.Location = new System.Drawing.Point(20, 678);
            this.labelFig2Param2.Name = "labelFig2Param2";
            this.labelFig2Param2.Size = new System.Drawing.Size(36, 20);
            this.labelFig2Param2.TabIndex = 12;
            this.labelFig2Param2.Text = "p22";
            this.labelFig2Param2.Visible = false;
            // 
            // labelFig2Param1
            // 
            this.labelFig2Param1.AutoSize = true;
            this.labelFig2Param1.Location = new System.Drawing.Point(20, 634);
            this.labelFig2Param1.Name = "labelFig2Param1";
            this.labelFig2Param1.Size = new System.Drawing.Size(36, 20);
            this.labelFig2Param1.TabIndex = 11;
            this.labelFig2Param1.Text = "p21";
            this.labelFig2Param1.Visible = false;
            // 
            // labelFig1Param2
            // 
            this.labelFig1Param2.AutoSize = true;
            this.labelFig1Param2.Location = new System.Drawing.Point(20, 299);
            this.labelFig1Param2.Name = "labelFig1Param2";
            this.labelFig1Param2.Size = new System.Drawing.Size(36, 20);
            this.labelFig1Param2.TabIndex = 8;
            this.labelFig1Param2.Text = "p12";
            this.labelFig1Param2.Visible = false;
            // 
            // labelFig1Param1
            // 
            this.labelFig1Param1.AutoSize = true;
            this.labelFig1Param1.Location = new System.Drawing.Point(20, 255);
            this.labelFig1Param1.Name = "labelFig1Param1";
            this.labelFig1Param1.Size = new System.Drawing.Size(36, 20);
            this.labelFig1Param1.TabIndex = 7;
            this.labelFig1Param1.Text = "p11";
            this.labelFig1Param1.Visible = false;
            // 
            // comboBoxFigure2
            // 
            this.comboBoxFigure2.FormattingEnabled = true;
            this.comboBoxFigure2.Items.AddRange(new object[] {
            "Сфера",
            "Цилиндр",
            "Куб",
            "Конус",
            "Параллелепипед"});
            this.comboBoxFigure2.Location = new System.Drawing.Point(15, 579);
            this.comboBoxFigure2.Name = "comboBoxFigure2";
            this.comboBoxFigure2.Size = new System.Drawing.Size(115, 28);
            this.comboBoxFigure2.TabIndex = 6;
            // 
            // labelFigure2
            // 
            this.labelFigure2.AutoSize = true;
            this.labelFigure2.Location = new System.Drawing.Point(11, 556);
            this.labelFigure2.Name = "labelFigure2";
            this.labelFigure2.Size = new System.Drawing.Size(78, 20);
            this.labelFigure2.TabIndex = 5;
            this.labelFigure2.Text = "Фигура 2";
            // 
            // numericUpDownFig2Param3
            // 
            this.numericUpDownFig2Param3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFig2Param3.Location = new System.Drawing.Point(62, 713);
            this.numericUpDownFig2Param3.Name = "numericUpDownFig2Param3";
            this.numericUpDownFig2Param3.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownFig2Param3.TabIndex = 20;
            this.numericUpDownFig2Param3.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownFig2Param3.Visible = false;
            // 
            // labelFig2Param3
            // 
            this.labelFig2Param3.AutoSize = true;
            this.labelFig2Param3.Location = new System.Drawing.Point(20, 719);
            this.labelFig2Param3.Name = "labelFig2Param3";
            this.labelFig2Param3.Size = new System.Drawing.Size(36, 20);
            this.labelFig2Param3.TabIndex = 19;
            this.labelFig2Param3.Text = "p23";
            this.labelFig2Param3.Visible = false;
            // 
            // numericUpDownFig1Param3
            // 
            this.numericUpDownFig1Param3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFig1Param3.Location = new System.Drawing.Point(62, 334);
            this.numericUpDownFig1Param3.Name = "numericUpDownFig1Param3";
            this.numericUpDownFig1Param3.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownFig1Param3.TabIndex = 22;
            this.numericUpDownFig1Param3.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownFig1Param3.Visible = false;
            // 
            // labelFig1Param3
            // 
            this.labelFig1Param3.AutoSize = true;
            this.labelFig1Param3.Location = new System.Drawing.Point(20, 340);
            this.labelFig1Param3.Name = "labelFig1Param3";
            this.labelFig1Param3.Size = new System.Drawing.Size(36, 20);
            this.labelFig1Param3.TabIndex = 21;
            this.labelFig1Param3.Text = "p13";
            this.labelFig1Param3.Visible = false;
            // 
            // numericUpDownCZ1
            // 
            this.numericUpDownCZ1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCZ1.Location = new System.Drawing.Point(62, 482);
            this.numericUpDownCZ1.Name = "numericUpDownCZ1";
            this.numericUpDownCZ1.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCZ1.TabIndex = 28;
            // 
            // labelZ1
            // 
            this.labelZ1.AutoSize = true;
            this.labelZ1.Location = new System.Drawing.Point(20, 488);
            this.labelZ1.Name = "labelZ1";
            this.labelZ1.Size = new System.Drawing.Size(17, 20);
            this.labelZ1.TabIndex = 27;
            this.labelZ1.Text = "z";
            // 
            // numericUpDownCY1
            // 
            this.numericUpDownCY1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCY1.Location = new System.Drawing.Point(62, 441);
            this.numericUpDownCY1.Name = "numericUpDownCY1";
            this.numericUpDownCY1.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCY1.TabIndex = 26;
            // 
            // numericUpDownCX1
            // 
            this.numericUpDownCX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCX1.Location = new System.Drawing.Point(62, 397);
            this.numericUpDownCX1.Name = "numericUpDownCX1";
            this.numericUpDownCX1.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCX1.TabIndex = 25;
            // 
            // labelY1
            // 
            this.labelY1.AutoSize = true;
            this.labelY1.Location = new System.Drawing.Point(20, 447);
            this.labelY1.Name = "labelY1";
            this.labelY1.Size = new System.Drawing.Size(16, 20);
            this.labelY1.TabIndex = 24;
            this.labelY1.Text = "y";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(20, 403);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(16, 20);
            this.labelX1.TabIndex = 23;
            this.labelX1.Text = "x";
            // 
            // numericUpDownCZ2
            // 
            this.numericUpDownCZ2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCZ2.Location = new System.Drawing.Point(62, 875);
            this.numericUpDownCZ2.Name = "numericUpDownCZ2";
            this.numericUpDownCZ2.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCZ2.TabIndex = 34;
            // 
            // labelZ2
            // 
            this.labelZ2.AutoSize = true;
            this.labelZ2.Location = new System.Drawing.Point(20, 881);
            this.labelZ2.Name = "labelZ2";
            this.labelZ2.Size = new System.Drawing.Size(17, 20);
            this.labelZ2.TabIndex = 33;
            this.labelZ2.Text = "z";
            // 
            // numericUpDownCY2
            // 
            this.numericUpDownCY2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCY2.Location = new System.Drawing.Point(62, 834);
            this.numericUpDownCY2.Name = "numericUpDownCY2";
            this.numericUpDownCY2.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCY2.TabIndex = 32;
            // 
            // numericUpDownCX2
            // 
            this.numericUpDownCX2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCX2.Location = new System.Drawing.Point(62, 790);
            this.numericUpDownCX2.Name = "numericUpDownCX2";
            this.numericUpDownCX2.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCX2.TabIndex = 31;
            // 
            // labelY2
            // 
            this.labelY2.AutoSize = true;
            this.labelY2.Location = new System.Drawing.Point(20, 840);
            this.labelY2.Name = "labelY2";
            this.labelY2.Size = new System.Drawing.Size(16, 20);
            this.labelY2.TabIndex = 30;
            this.labelY2.Text = "y";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Location = new System.Drawing.Point(20, 796);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(16, 20);
            this.labelX2.TabIndex = 29;
            this.labelX2.Text = "x";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1508, 1144);
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
            this.Controls.Add(this.simpleOpenGlControl);
            this.MinimumSize = new System.Drawing.Size(1530, 1200);
            this.Name = "MainForm";
            this.Text = "Геометрическое моделирование";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).EndInit();
            this.groupBoxParametrs.ResumeLayout(false);
            this.groupBoxParametrs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCZ1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCZ2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCX2)).EndInit();
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
        private System.Windows.Forms.Label labelFig2Param2;
        private System.Windows.Forms.Label labelFig2Param1;
        private System.Windows.Forms.Label labelFig1Param2;
        private System.Windows.Forms.Label labelFig1Param1;
        private System.Windows.Forms.NumericUpDown numericUpDownFig2Param2;
        private System.Windows.Forms.NumericUpDown numericUpDownFig2Param1;
        private System.Windows.Forms.NumericUpDown numericUpDownFig1Param2;
        private System.Windows.Forms.NumericUpDown numericUpDownFig1Param1;
        private System.Windows.Forms.NumericUpDown numericUpDownFig1Param3;
        private System.Windows.Forms.Label labelFig1Param3;
        private System.Windows.Forms.NumericUpDown numericUpDownFig2Param3;
        private System.Windows.Forms.Label labelFig2Param3;
        private System.Windows.Forms.NumericUpDown numericUpDownCZ2;
        private System.Windows.Forms.Label labelZ2;
        private System.Windows.Forms.NumericUpDown numericUpDownCY2;
        private System.Windows.Forms.NumericUpDown numericUpDownCX2;
        private System.Windows.Forms.Label labelY2;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.NumericUpDown numericUpDownCZ1;
        private System.Windows.Forms.Label labelZ1;
        private System.Windows.Forms.NumericUpDown numericUpDownCY1;
        private System.Windows.Forms.NumericUpDown numericUpDownCX1;
        private System.Windows.Forms.Label labelY1;
        private System.Windows.Forms.Label labelX1;
    }
}

