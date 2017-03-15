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
        // здесь 1 - первая фигура, 2 - вторая фигура
        int r1, r2; // сторона куба / радиус сферы / радиус основания конуса / радиус основания цилиндра
        int h1, h2; // высота конуса / высота цилиндра
        int innerRadius1, outerRadius1, innerRadius2, outerRadius2; // радиусы тора

        bool wireMode = false; // режим сеточной визуализации

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

        // обработка отклика таймера 
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw(); // вызов функции отрисовки сцены
        }

        //////////////////////////////////////////////////////////////////////////////

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

            // отрисовка выбранной фигуры
            drawFigure(comboBoxFigure2);

            // возвращаем состояние матрицы 
            Gl.glPopMatrix();

            // завершаем рисование 
            Gl.glFlush();

            // обновляем элемент 
            simpleOpenGlControl.Invalidate();
        }

        // установка парамептров фигур из полей формы
        private void getParams()
        {
            r1 = (int)numericUpDownFig1Param1.Value;
            r2 = (int)numericUpDownFig2Param1.Value;
            h1 = (int)numericUpDownFig1Param2.Value;
            h2 = (int)numericUpDownFig2Param2.Value;

            innerRadius1 = (int)numericUpDownFig1Param1.Value;
            innerRadius2 = (int)numericUpDownFig2Param1.Value;
            outerRadius1 = (int)numericUpDownFig1Param2.Value;
            outerRadius2 = (int)numericUpDownFig2Param2.Value;
        }

        // установка начальных параметров фигур
        private void setParams(ComboBox box)
        {
            switch (box.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                case 0: // сфера
                    {
                        if (box == comboBoxFigure1)
                            r1 = 2;
                        else if (box == comboBoxFigure2)
                            r2 = 2;
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (box == comboBoxFigure1)
                        {
                            r1 = 1;
                            h1 = 2;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            r2 = 1;
                            h2 = 2;
                        }
                        break;
                    }
                case 2: // куб
                    {
                        if (box == comboBoxFigure1)
                            r1 = 2;
                        else if (box == comboBoxFigure2)
                            r2 = 2;
                        break;
                    }
                case 3: // конус
                    {
                        if (box == comboBoxFigure1)
                        {
                            r1 = 2;
                            h1 = 3;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            r2 = 2;
                            h2 = 3;
                        }
                        break;
                    }
                case 4: // тор
                    {
                        if (box == comboBoxFigure1)
                        {
                            innerRadius1 = 1;
                            outerRadius1 = 3;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            innerRadius2 = 1;
                            outerRadius2 = 3;
                        }
                        break;
                    }
            }
        }

        /* Cделать поля параметров фигур видимыми и вставить в label их названия
         * Если параметр 1, то делаем видимым только 1 label и 1 numericUpDown
         * иначе - 2 label'a и 2 numericUpDown'a
         */
        private void revealFields(int prms, Label label1, Label label2, NumericUpDown field1, NumericUpDown field2, string text1, string text2)
        {
            if (prms == 1) // сфера, куб
            {
                label1.Visible = true;
                field1.Visible = true;

                label2.Visible = false;
                field2.Visible = false;
            }
            else if (prms == 2) // конус, цилиндр, тор
            {
                label1.Visible = true;
                field1.Visible = true;

                label2.Visible = true;
                field2.Visible = true;
            }
            label1.Text = text1;
            label2.Text = text2;
        }

        // отрисовка фигуры
        private void drawFigure(ComboBox box)
        {
            // устанавливаем параметры (из полей формы)
            setParams(box);

            // в зависимости от выбранного comboBoxFigure1 или же comboBoxFigure2
            switch (box.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                case 0: // сфера
                    {
                        if (box == comboBoxFigure1)
                            revealFields(1, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "");
                        else if (box == comboBoxFigure2)
                            revealFields(1, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "r", "");
                        if (wireMode)
                            Glut.glutWireSphere(r1, 16, 16); // сеточная сфера 
                        else
                            Glut.glutSolidSphere(r2, 16, 16); // полигональная сфера 
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (box == comboBoxFigure1)
                            revealFields(2, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "h");
                        else if (box == comboBoxFigure2)
                            revealFields(2, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "r", "h");
                        if (wireMode)
                            Glut.glutWireCylinder(r1, h1, 32, 32);
                        else
                            Glut.glutSolidCylinder(r2, h2, 32, 32);
                        break;
                    }
                case 2: // куб
                    {
                        if (box == comboBoxFigure1)
                            revealFields(1, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "a", "");
                        else if (box == comboBoxFigure2)
                            revealFields(1, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "a", "");
                        if (wireMode)
                            Glut.glutWireCube(r1);
                        else
                            Glut.glutSolidCube(r2);
                        break;
                    }
                case 3: // конус
                    {
                        if (box == comboBoxFigure1)
                            revealFields(2, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "h");
                        else if (box == comboBoxFigure2)
                            revealFields(2, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "r", "h");
                        if (wireMode)
                            Glut.glutWireCone(r1, h1, 32, 32);
                        else
                            Glut.glutSolidCone(r2, h2, 32, 32);
                        break;
                    }
                case 4: // тор
                    {
                        if (box == comboBoxFigure1)
                            revealFields(2, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "R");
                        else if (box == comboBoxFigure2)
                            revealFields(2, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "r", "R");
                        if (wireMode)
                            Glut.glutWireTorus(innerRadius1, outerRadius1, 32, 32);
                        else
                            Glut.glutSolidTorus(innerRadius2, outerRadius2, 32, 32);
                        break;
                    }
            }
        }

    }
}