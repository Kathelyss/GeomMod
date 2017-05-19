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
            this.simpleOpenGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.labelFigure1 = new System.Windows.Forms.Label();
            this.comboBoxFigure1 = new System.Windows.Forms.ComboBox();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxParametrs = new System.Windows.Forms.GroupBox();
            this.numericUpDownCZ2 = new System.Windows.Forms.NumericUpDown();
            this.labelZ2 = new System.Windows.Forms.Label();
            this.numericUpDownCY2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCX2 = new System.Windows.Forms.NumericUpDown();
            this.labelY2 = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            this.numericUpDownCZ1 = new System.Windows.Forms.NumericUpDown();
            this.labelZ1 = new System.Windows.Forms.Label();
            this.numericUpDownCY1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCX1 = new System.Windows.Forms.NumericUpDown();
            this.labelY1 = new System.Windows.Forms.Label();
            this.labelX1 = new System.Windows.Forms.Label();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxParametrs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCZ2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCZ1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param1)).BeginInit();
            this.SuspendLayout();
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
            this.simpleOpenGlControl.Location = new System.Drawing.Point(215, 23);
            this.simpleOpenGlControl.Name = "simpleOpenGlControl";
            this.simpleOpenGlControl.Size = new System.Drawing.Size(1100, 1100);
            this.simpleOpenGlControl.StencilBits = ((byte)(0));
            this.simpleOpenGlControl.TabIndex = 1;
            this.simpleOpenGlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SimpleOpenGlControl_MouseDown);
            this.simpleOpenGlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SimpleOpenGlControl_MouseMove);
            this.simpleOpenGlControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SimpleOpenGlControl_MouseUp);
            this.simpleOpenGlControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.SimpleOpenGlControl_MouseWheel);
            // 
            // labelFigure1
            // 
            this.labelFigure1.AutoSize = true;
            this.labelFigure1.Location = new System.Drawing.Point(10, 33);
            this.labelFigure1.Name = "labelFigure1";
            this.labelFigure1.Size = new System.Drawing.Size(78, 20);
            this.labelFigure1.TabIndex = 2;
            this.labelFigure1.Text = "Фигура 1";
            // 
            // comboBoxFigure1
            // 
            this.comboBoxFigure1.FormattingEnabled = true;
            this.comboBoxFigure1.Items.AddRange(new object[] {
            "Куб",
            "Конус",
            "Цилиндр"});
            this.comboBoxFigure1.Location = new System.Drawing.Point(14, 56);
            this.comboBoxFigure1.Name = "comboBoxFigure1";
            this.comboBoxFigure1.Size = new System.Drawing.Size(115, 28);
            this.comboBoxFigure1.TabIndex = 4;
            // 
            // RenderTimer
            // 
            this.RenderTimer.Enabled = true;
            this.RenderTimer.Interval = 30;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
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
            this.groupBoxParametrs.Location = new System.Drawing.Point(23, 22);
            this.groupBoxParametrs.Name = "groupBoxParametrs";
            this.groupBoxParametrs.Size = new System.Drawing.Size(178, 934);
            this.groupBoxParametrs.TabIndex = 19;
            this.groupBoxParametrs.TabStop = false;
            this.groupBoxParametrs.Text = "Параметры фигур";
            // 
            // numericUpDownCZ2
            // 
            this.numericUpDownCZ2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCZ2.Location = new System.Drawing.Point(61, 731);
            this.numericUpDownCZ2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownCZ2.Name = "numericUpDownCZ2";
            this.numericUpDownCZ2.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCZ2.TabIndex = 34;
            // 
            // labelZ2
            // 
            this.labelZ2.AutoSize = true;
            this.labelZ2.Location = new System.Drawing.Point(19, 737);
            this.labelZ2.Name = "labelZ2";
            this.labelZ2.Size = new System.Drawing.Size(17, 20);
            this.labelZ2.TabIndex = 33;
            this.labelZ2.Text = "z";
            // 
            // numericUpDownCY2
            // 
            this.numericUpDownCY2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCY2.Location = new System.Drawing.Point(61, 690);
            this.numericUpDownCY2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownCY2.Name = "numericUpDownCY2";
            this.numericUpDownCY2.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCY2.TabIndex = 32;
            // 
            // numericUpDownCX2
            // 
            this.numericUpDownCX2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCX2.Location = new System.Drawing.Point(61, 646);
            this.numericUpDownCX2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownCX2.Name = "numericUpDownCX2";
            this.numericUpDownCX2.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCX2.TabIndex = 31;
            // 
            // labelY2
            // 
            this.labelY2.AutoSize = true;
            this.labelY2.Location = new System.Drawing.Point(19, 696);
            this.labelY2.Name = "labelY2";
            this.labelY2.Size = new System.Drawing.Size(16, 20);
            this.labelY2.TabIndex = 30;
            this.labelY2.Text = "y";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Location = new System.Drawing.Point(19, 652);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(16, 20);
            this.labelX2.TabIndex = 29;
            this.labelX2.Text = "x";
            // 
            // numericUpDownCZ1
            // 
            this.numericUpDownCZ1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCZ1.Location = new System.Drawing.Point(61, 338);
            this.numericUpDownCZ1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownCZ1.Name = "numericUpDownCZ1";
            this.numericUpDownCZ1.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCZ1.TabIndex = 28;
            // 
            // labelZ1
            // 
            this.labelZ1.AutoSize = true;
            this.labelZ1.Location = new System.Drawing.Point(19, 344);
            this.labelZ1.Name = "labelZ1";
            this.labelZ1.Size = new System.Drawing.Size(17, 20);
            this.labelZ1.TabIndex = 27;
            this.labelZ1.Text = "z";
            // 
            // numericUpDownCY1
            // 
            this.numericUpDownCY1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCY1.Location = new System.Drawing.Point(61, 297);
            this.numericUpDownCY1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownCY1.Name = "numericUpDownCY1";
            this.numericUpDownCY1.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCY1.TabIndex = 26;
            // 
            // numericUpDownCX1
            // 
            this.numericUpDownCX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCX1.Location = new System.Drawing.Point(61, 253);
            this.numericUpDownCX1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownCX1.Name = "numericUpDownCX1";
            this.numericUpDownCX1.Size = new System.Drawing.Size(68, 26);
            this.numericUpDownCX1.TabIndex = 25;
            // 
            // labelY1
            // 
            this.labelY1.AutoSize = true;
            this.labelY1.Location = new System.Drawing.Point(19, 303);
            this.labelY1.Name = "labelY1";
            this.labelY1.Size = new System.Drawing.Size(16, 20);
            this.labelY1.TabIndex = 24;
            this.labelY1.Text = "y";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(19, 259);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(16, 20);
            this.labelX1.TabIndex = 23;
            this.labelX1.Text = "x";
            // 
            // numericUpDownFig2Param2
            // 
            this.numericUpDownFig2Param2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFig2Param2.Location = new System.Drawing.Point(61, 528);
            this.numericUpDownFig2Param2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.numericUpDownFig2Param1.Location = new System.Drawing.Point(61, 484);
            this.numericUpDownFig2Param1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.numericUpDownFig1Param2.Location = new System.Drawing.Point(61, 149);
            this.numericUpDownFig1Param2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.numericUpDownFig1Param1.Location = new System.Drawing.Point(61, 105);
            this.numericUpDownFig1Param1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.labelFig2Param2.Location = new System.Drawing.Point(19, 534);
            this.labelFig2Param2.Name = "labelFig2Param2";
            this.labelFig2Param2.Size = new System.Drawing.Size(36, 20);
            this.labelFig2Param2.TabIndex = 12;
            this.labelFig2Param2.Text = "p22";
            this.labelFig2Param2.Visible = false;
            // 
            // labelFig2Param1
            // 
            this.labelFig2Param1.AutoSize = true;
            this.labelFig2Param1.Location = new System.Drawing.Point(19, 490);
            this.labelFig2Param1.Name = "labelFig2Param1";
            this.labelFig2Param1.Size = new System.Drawing.Size(36, 20);
            this.labelFig2Param1.TabIndex = 11;
            this.labelFig2Param1.Text = "p21";
            this.labelFig2Param1.Visible = false;
            // 
            // labelFig1Param2
            // 
            this.labelFig1Param2.AutoSize = true;
            this.labelFig1Param2.Location = new System.Drawing.Point(19, 155);
            this.labelFig1Param2.Name = "labelFig1Param2";
            this.labelFig1Param2.Size = new System.Drawing.Size(36, 20);
            this.labelFig1Param2.TabIndex = 8;
            this.labelFig1Param2.Text = "p12";
            this.labelFig1Param2.Visible = false;
            // 
            // labelFig1Param1
            // 
            this.labelFig1Param1.AutoSize = true;
            this.labelFig1Param1.Location = new System.Drawing.Point(19, 111);
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
            "Куб",
            "Конус",
            "Цилиндр"});
            this.comboBoxFigure2.Location = new System.Drawing.Point(14, 435);
            this.comboBoxFigure2.Name = "comboBoxFigure2";
            this.comboBoxFigure2.Size = new System.Drawing.Size(115, 28);
            this.comboBoxFigure2.TabIndex = 6;
            // 
            // labelFigure2
            // 
            this.labelFigure2.AutoSize = true;
            this.labelFigure2.Location = new System.Drawing.Point(10, 412);
            this.labelFigure2.Name = "labelFigure2";
            this.labelFigure2.Size = new System.Drawing.Size(78, 20);
            this.labelFigure2.TabIndex = 5;
            this.labelFigure2.Text = "Фигура 2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 997);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1333, 1144);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBoxParametrs);
            this.Controls.Add(this.simpleOpenGlControl);
            this.MinimumSize = new System.Drawing.Size(1355, 1200);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Геометрическое моделирование";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxParametrs.ResumeLayout(false);
            this.groupBoxParametrs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCZ2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCZ1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig2Param1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFig1Param1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelFigure1;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.GroupBox groupBoxParametrs;
        private System.Windows.Forms.Label labelFigure2;
        private System.Windows.Forms.Label labelFig2Param2;
        private System.Windows.Forms.Label labelFig2Param1;
        private System.Windows.Forms.Label labelFig1Param2;
        private System.Windows.Forms.Label labelFig1Param1;
        private System.Windows.Forms.Label labelZ2;
        private System.Windows.Forms.Label labelY2;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.Label labelZ1;
        private System.Windows.Forms.Label labelY1;
        private System.Windows.Forms.Label labelX1;
        public System.Windows.Forms.ComboBox comboBoxFigure1;
        public System.Windows.Forms.ComboBox comboBoxFigure2;
        public System.Windows.Forms.NumericUpDown numericUpDownFig2Param2;
        public System.Windows.Forms.NumericUpDown numericUpDownFig2Param1;
        public System.Windows.Forms.NumericUpDown numericUpDownFig1Param2;
        public System.Windows.Forms.NumericUpDown numericUpDownFig1Param1;
        public System.Windows.Forms.NumericUpDown numericUpDownCZ2;
        public System.Windows.Forms.NumericUpDown numericUpDownCY2;
        public System.Windows.Forms.NumericUpDown numericUpDownCX2;
        public System.Windows.Forms.NumericUpDown numericUpDownCZ1;
        public System.Windows.Forms.NumericUpDown numericUpDownCY1;
        public System.Windows.Forms.NumericUpDown numericUpDownCX1;
        public Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl;
        public System.Windows.Forms.TextBox textBox1;
    }
}

