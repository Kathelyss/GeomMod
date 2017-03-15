using System;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows; // для работы с элементом управления SimpleOpenGLControl

namespace GeomMod
{
    public partial class MainForm : Form
    {
        // вспомогательные переменные - в них будут храниться обработанные значения, 
        // полученные при перетаскивании ползунков пользователем 
        double a = 0, b = 0, c = -10, d = 0, zoom = 1; // выбранные оси 
        int os_x = 1, os_y = 0, os_z = 0;
        // режим сеточной визуализации 
        bool wireMode = false;

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

            // начальная настройка параметров openGL (тест глубины, освещение и первый источник света) 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            // установка первых элементов в списках combobox 
            comboBoxAxis.SelectedIndex = 0;
            comboBoxFigure1.SelectedIndex = 0;

            // активация таймера, вызывающего функцию для визуализации 
            RenderTimer.Start();
        }

        /* События изменения значений элементов scrollBar
         *  Общий алгоритм:
         *      переводим значение, установившееся в элементе trackBar в необходимый нам формат,
         *      затем подписываем это значение в label элементе под данным ползунком
        */

        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBarX.Value / 1000.0;
            labelInfoX.Text = a.ToString();
        }

        private void trackBarY_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBarY.Value / 1000.0;
            labelInfoY.Text = b.ToString();
        }

        private void trackBarZ_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBarZ.Value / 1000.0;
            labelInfoZ.Text = c.ToString();
        }

        private void trackBarAngle_Scroll(object sender, EventArgs e)
        {
            d = (double)trackBarAngle.Value;
            labelInfoAngle.Text = d.ToString();
        }

        private void comboBoxAxis_SelectedIndexChanged(object sender, EventArgs e)
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

        // сделать поле параметра фигуры видимым и вставить в label его название
        // если у фигуры 1 параметр (сфера, куб)
        private void revealFields(Label label, NumericUpDown field, string text)
        {
            label.Visible = true;
            field.Visible = true;
            label.Text = text;
        }

        // сделать поля параметров фигур видимыми и вставить в label их названия
        // если у фигуры 2 параметра (цилиндр, конус, тор)
        private void revealFields(Label label1, Label label2, NumericUpDown field1, NumericUpDown field2, string text1, string text2)
        {
            label1.Visible = true;
            label2.Visible = true;
            field1.Visible = true;
            field2.Visible = true;
            label1.Text = text1;
            label2.Text = text2;
        }

        // установка начальных параметров фигур
        private void setParams()
        {

        }

        // функция отрисовки 
        private void Draw()
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();

            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта 
            Gl.glPushMatrix();
            // производим перемещение в зависимости от значений, полученных при перемещении ползунков 
            Gl.glTranslated(a, b, c);
            // поворот по установленной оси 
            Gl.glRotated(d, os_x, os_y, os_z);
            // и масштабирование объекта 
            Gl.glScaled(zoom, zoom, zoom);
            
            //установка цвета объекта
            float[] color = new float[4] { (float)0.5, (float)0.9, (float)0.2, 1 }; // собственно, цвет
            float[] shininess = new float[1] { 30 };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, color); // цвет объекта
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, color); // отраженный свет
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininess); // степень отраженного света


            // в зависимости от установленного типа объекта 
            switch (comboBoxFigure1.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                case 0: // сфера
                    {
                        revealFields(labelFig1Param1, numericUpDownFig1Param1, "r");
                        if (wireMode)
                            Glut.glutWireSphere(2, 16, 16); // сеточная сфера 
                        else
                            Glut.glutSolidSphere(2, 16, 16); // полигональная сфера 
                        break;
                    }
                case 1: // цилиндр
                    {
                        revealFields(labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "h");
                        if (wireMode) 
                            Glut.glutWireCylinder(1, 2, 32, 32); 
                        else
                            Glut.glutSolidCylinder(1, 2, 32, 32);
                        break;
                    }
                case 2: // куб
                    {
                        revealFields(labelFig1Param1, numericUpDownFig1Param1, "a");
                        if (wireMode)  
                            Glut.glutWireCube(2); 
                        else
                            Glut.glutSolidCube(2);
                        break;
                    }
                case 3: // конус
                    {
                        revealFields(labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "h");
                        if (wireMode) 
                            Glut.glutWireCone(2, 3, 32, 32); 
                        else
                            Glut.glutSolidCone(2, 3, 32, 32);
                        break;
                    }
                case 4: // тор
                    {
                        revealFields(labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "R");
                        if (wireMode)
                            Glut.glutWireTorus(0.2, 2.2, 32, 32); 
                        else
                            Glut.glutSolidTorus(0.2, 2.2, 32, 32);
                        break;
                    }
            }

            // возвращаем состояние матрицы 
            Gl.glPopMatrix();

            // завершаем рисование 
            Gl.glFlush();

            // обновляем элемент 
            simpleOpenGlControl.Invalidate();
        }

        // обработка отклика таймера 
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw(); // вызов функции отрисовки сцены
        }
    }
}