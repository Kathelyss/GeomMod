using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace GeomMod
{
    public partial class MainForm : Form
    {
        // вспомогательные переменные - в них будут храниться обработанные значения, 
        // полученные при перетаскивании ползунков пользователем 
        public static double a = 0, b = 0, c = -10, d = 0, zoom = 1; // выбранные оси 
        public static int os_x = 1, os_y = 0, os_z = 0;
        Drawings drawings = new Drawings();        

        MouseEventArgs mouseClick;

        public MainForm()
        {
            InitializeComponent();
            simpleOpenGlControl.InitializeContexts();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // инициализация библиотеки glut 
            Glut.glutInit();
            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            /////
            // Set window's to Mouse callback
            //Glut.glutMouseFunc(new Glut.MouseCallback(ProcessMouseActiveMotion));
            // Set window's to motion callback
            //Glut.glutMotionFunc(new Glut.MotionCallback(ProcessMouse));
            // Set window's to mouse motion callback
            //Glut.glutMouseWheelFunc(new Glut.MouseWheelCallback(ZoomViaMouseWheel));
            /////


            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(255, 255, 255, 1);
            // установка порта вывода 
            Gl.glViewport(0, 0, simpleOpenGlControl.Width, simpleOpenGlControl.Height);
            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();
            // установка перспективы 
            Glu.gluPerspective(45, (float)simpleOpenGlControl.Width / (float)simpleOpenGlControl.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // установка оси вращения сцены (ось х)
            comboBoxAxis.SelectedIndex = 0;
            // активация таймера, вызывающего функцию для визуализации 
            RenderTimer.Start();
        }

        /* События изменения значений элементов scrollBar
         *  Общий алгоритм:
         *      переводим значение, установившееся в элементе trackBar в необходимый нам формат,
         *      затем подписываем это значение в label элементе под данным ползунком
        */

        private void TrackBarX_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBarX.Value / 1000.0;
            labelInfoX.Text = a.ToString();
        }

        private void TrackBarY_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBarY.Value / 1000.0;
            labelInfoY.Text = b.ToString();
        }

        private void TrackBarZ_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBarZ.Value / 1000.0;
            labelInfoZ.Text = c.ToString();
        }

        private void TrackBarAngle_Scroll(object sender, EventArgs e)
        {
            d = (double)trackBarAngle.Value;
            labelInfoAngle.Text = d.ToString();
        }

        private void ComboBoxAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            // в зависимости от выбранного режима 
            switch (comboBoxAxis.SelectedIndex)
            {
                // устанавливаем необходимую ось (будет использована в функции glRotate**) 
                case 0:
                    {
                        os_x = 1;
                        os_y = 0;
                        os_z = 0;
                        break;
                    }
                case 1:
                    {
                        os_x = 0;
                        os_y = 1;
                        os_z = 0;
                        break;
                    }
                case 2:
                    {
                        os_x = 0;
                        os_y = 0;
                        os_z = 1;
                        break;
                    }
            }
        }


        // обработка отклика таймера 
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            RevealFields(comboBoxFigure1);
            RevealFields(comboBoxFigure2);
            drawings.DrawScene(this); // вызов функции отрисовки сцены
        }


        ////////////////////////////////////////////////////////////////////////////

        // неработающий кусок
        private void SimpleOpenGlControl_MouseClick(object sender, MouseEventArgs e)
        {
            mouseClick = new MouseEventArgs(e.Button, 1, e.X, e.Y, e.Delta);
        }

        private void SimpleOpenGlControl_MouseWheel(object sender, MouseEventArgs e)
        {
           // simpleOpenGlControl.MouseWheel += new MouseEventHandler(this.SimpleOpenGlControl_MouseWheel);
        }
        private void SimpleOpenGlControl_MouseMove(object sender, MouseEventArgs e)
        {/*
            if(mouseClick != null) {
                double[] sign = new double[2];
                sign[0] = (e.X - mouseClick.X);
                sign[1] = -(e.Y - mouseClick.Y);
                drawings.MoveRotate(this, sign);
            }
            */
        }


        ////////////////////////////////////////////////////////////////////////////        

        /* Cделать поля параметров фигур видимыми и вставить в label их названия
         * Если параметр 1, то делаем видимым только 1 label и 1 numericUpDown
         * иначе - 2 label'a и 2 numericUpDown'a
         */
        public void RevealFields(ComboBox box)
        {
            int prms = 0;
            string text1 = "", text2 = "";
            switch (box.SelectedIndex) // "открываем" поля и лейблы для параметризации
            {
                case 0: // сфера
                    {
                        prms = 1;
                        text1 = "r";
                        break;
                    }
                case 1:
                case 3: // цилиндр, конус
                    {
                        prms = 2;
                        text1 = "r";
                        text2 = "h";
                        break;
                    }
                case 2: // куб
                    {
                        prms = 1;
                        text1 = "a";
                        break;
                    }
                default:
                    {
                        prms = 0;
                        break;
                    }
            }

            if (box == comboBoxFigure1)
            {
                // все фигуры
                labelFig1Param1.Visible = (prms > 0);
                numericUpDownFig1Param1.Visible = (prms > 0);
                labelFig1Param1.Text = text1;
                // конус, цилиндр
                labelFig1Param2.Visible = (prms > 1);
                numericUpDownFig1Param2.Visible = (prms > 1);
                labelFig1Param2.Text = text2;
            }
            else
            {
                // все фигуры
                labelFig2Param1.Visible = (prms > 0);
                numericUpDownFig2Param1.Visible = (prms > 0);
                labelFig2Param1.Text = text1;
                // конус, цилиндр
                labelFig2Param2.Visible = (prms > 1);
                numericUpDownFig2Param2.Visible = (prms > 1);
                labelFig2Param2.Text = text2;
            }
        }
    }
}
