using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace GeomMod
{
    public partial class MainForm : Form
    {
        public double[] camRotation = new double[3];
        public double[] camPosition = new double[3];
        public double camSpeed = 0.005;
        public double zoomSpeed = 0.01;
        Point mouseClick = new Point(0, 0, 0);
        bool clicked = false;

        Drawings drawings = new Drawings();        


        public MainForm()
        {
            InitializeComponent();
            simpleOpenGlControl.InitializeContexts();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(0, 0, 0, 1);
            // установка порта вывода 
            Gl.glViewport(0, 0, simpleOpenGlControl.Width, simpleOpenGlControl.Height);
            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, simpleOpenGlControl.Width / simpleOpenGlControl.Height, 0.1, 200);

            InitScene();
            comboBoxFigure1.SelectedIndex = 0;
            comboBoxFigure2.SelectedIndex = 1;

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // активация таймера, вызывающего функцию для визуализации 
            RenderTimer.Start();
        }

        private void InitScene()
        {
            camPosition[0] = 0;
            camPosition[1] = 0;
            camPosition[2] = -20;

            camRotation[0] = 20;
            camRotation[1] = -20;
            camRotation[2] = 0;
        }

        // обработка отклика таймера 
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            RevealFields(comboBoxFigure1);
            RevealFields(comboBoxFigure2);
            drawings.DrawScene(this); // вызов функции отрисовки сцены
        }

        private void SimpleOpenGlControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClick.coord_x = e.X;
            mouseClick.coord_y = e.Y;
            clicked = true;
        }

        private void SimpleOpenGlControl_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }

        private void SimpleOpenGlControl_MouseWheel(object sender, MouseEventArgs e)
        {
           camPosition[2] += e.Delta * zoomSpeed;
        }

        private void SimpleOpenGlControl_MouseMove(object sender, MouseEventArgs e)
        {            
            if(clicked) {
                double[] sign = new double[2];
                sign[0] = (e.X - mouseClick.coord_x);
                sign[1] = -(e.Y - mouseClick.coord_y);
                drawings.MoveRotate(this, sign);
            }            
        }      

        /* Cделать поля параметров фигур видимыми и вставить в label их названия
         * Если параметр 1, то делаем видимым только 1 label и 1 numericUpDown
         * иначе - 2 label'a и 2 numericUpDown'a
         */
        public void RevealFields(ComboBox box)
        {
            int prms = 0;
            string text1 = "", text2 = "";
            switch (box.SelectedIndex)
            {
                case 0: // куб
                    {
                        prms = 1;
                        text1 = "a";
                        break;
                    }
                case 1: // цилиндр
                    {
                        prms = 2;
                        text1 = "d";
                        text2 = "h";
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
                // цилиндр
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
                // цилиндр
                labelFig2Param2.Visible = (prms > 1);
                numericUpDownFig2Param2.Visible = (prms > 1);
                labelFig2Param2.Text = text2;
            }
        }
    }
}
