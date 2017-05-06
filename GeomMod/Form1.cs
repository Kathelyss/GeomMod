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
        double a = 0, b = 0, c = -10, d = 0, zoom = 1; // выбранные оси 
        int os_x = 1, os_y = 0, os_z = 0;
        // здесь 1 - первая фигура, 2 - вторая фигура
        int cubeSide1, sphereRadius1, coneBasemendRadius1, cilinderBaseRadius1, coneHeight1, cilinderHeight1;
        int cubeSide2, sphereRadius2, coneBasemendRadius2, cilinderBaseRadius2, coneHeight2, cilinderHeight2;
        int innerRadius1, outerRadius1, innerRadius2, outerRadius2; // радиусы тора

        //for mouse
        static int old_x, old_y, mousePressed;
        static float X = 0.0f;        // Translate screen to x direction (left or right)
        static float Y = 0.0f;        // Translate screen to y direction (up or down)
        static float Z = 0.0f;        // Translate screen to z direction (zoom in or out)

        bool wireMode = false; // режим сеточной визуализации

        public MainForm()
        {
            InitializeComponent();
            simpleOpenGlControl.MouseWheel += new MouseEventHandler(this.SimpleOpenGlControl_MouseWheel);
            simpleOpenGlControl.MouseDown += new MouseEventHandler(SimpleOpenGlControl_MouseDown);
            simpleOpenGlControl.MouseUp += new MouseEventHandler(SimpleOpenGlControl_MouseUp);
            simpleOpenGlControl.MouseMove += new MouseEventHandler(SimpleOpenGlControl_MouseMove);
            //simpleOpenGlControl.KeyUp += new KeyEventHandler(this.HandleKeyPress);
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
            Glut.glutMouseFunc(new Glut.MouseCallback(ProcessMouseActiveMotion));
            // Set window's to motion callback
            Glut.glutMotionFunc(new Glut.MotionCallback(ProcessMouse));
            // Set window's to mouse motion callback
            Glut.glutMouseWheelFunc(new Glut.MouseWheelCallback(ZoomViaMouseWheel));
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

            // начальная настройка параметров openGL (тест глубины, освещение и первый источник света) 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            // установка оси вращения сцены (ось х)
            comboBoxAxis.SelectedIndex = 0;

            // активация таймера, вызывающего функцию для визуализации 
            RenderTimer.Start();
        }

        // неработающий кусок
        private void SimpleOpenGlControl_MouseWheel(object sender, MouseEventArgs e)
        {
            simpleOpenGlControl.MouseWheel += new MouseEventHandler(this.SimpleOpenGlControl_MouseWheel);
        }
        private void SimpleOpenGlControl_MouseDown(object sender, MouseEventArgs e) { }
        private void SimpleOpenGlControl_MouseUp(object sender, MouseEventArgs e) { }
        private void SimpleOpenGlControl_MouseMove(object sender, MouseEventArgs e) { }
        //


        // переключение сеточного режима из формы
        private void CheckBoxWireMode_CheckedChanged(object sender, EventArgs e)
        {
            wireMode = checkBoxWireMode.Checked;

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


        private void ZoomViaMouseWheel(int wheel, int direction, int x, int y)
        {
            Z += direction;
            labelInfoZ.Text = Z.ToString();
            Glut.glutPostRedisplay();
        }

        // Capture the mouse click event 
        static void ProcessMouseActiveMotion(int button, int state, int x, int y)
        {
            mousePressed = button;          // Capture which mouse button is down
            old_x = x;                      // Capture the x value
            old_y = y;                      // Capture the y value
        }

        // Translate the x,y windows coordinates to OpenGL coordinates
        static void ProcessMouse(int x, int y)
        {
            if ((mousePressed == 0))        // If left mouse button is pressed
            {
                X = (x - old_x) / 15;       // I did divide by 15 to adjust                                             
                Y = -(y - old_y) / 15;      // for a nice translation
            }

            Glut.glutPostRedisplay();
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
            DrawScene(); // вызов функции отрисовки сцены
        }

        //////////////////////////////////////////////////////////////////////////////

        // функция отрисовки сцены
        private void DrawScene()
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

            // устаноыка цвета первой фигуры
            float[] color1 = new float[4] { (float)0.5, (float)0.9, (float)0.2, 1 };
            // отрисовка первой фигуры
            DrawFigure(1, comboBoxFigure1, color1);

            // установка цвета второй фигуры
            float[] color2 = new float[4] { (float)0.9, (float)0.5, (float)0.2, 1 };
            // отрисовка второй фигуры
            DrawFigure(2, comboBoxFigure2, color2);

            // возвращаем состояние матрицы 
            Gl.glPopMatrix();

            // завершаем рисование 
            Gl.glFlush();

            // обновляем элемент 
            simpleOpenGlControl.Invalidate();
        }

        // установка парамептров фигур из полей формы
        private void GetParams()
        {
            //1я фигура
            //куб и сфера
            cubeSide1 = (int)numericUpDownFig1Param1.Value;
            sphereRadius1 = (int)numericUpDownFig1Param1.Value;
            //конус
            coneBasemendRadius1 = (int)numericUpDownFig1Param1.Value;
            coneHeight1 = (int)numericUpDownFig1Param2.Value;
            //цилиндр
            cilinderBaseRadius1 = (int)numericUpDownFig1Param1.Value;
            cilinderHeight1 = (int)numericUpDownFig1Param2.Value;
            //тор
            innerRadius1 = (int)numericUpDownFig1Param1.Value;
            outerRadius1 = (int)numericUpDownFig1Param2.Value;

            //2я фигура
            //куб и сфера
            cubeSide2 = (int)numericUpDownFig2Param1.Value;
            sphereRadius2 = (int)numericUpDownFig2Param1.Value;
            //конус
            coneBasemendRadius2 = (int)numericUpDownFig2Param1.Value;
            coneHeight2 = (int)numericUpDownFig2Param2.Value;
            //цилиндр
            cilinderBaseRadius2 = (int)numericUpDownFig2Param1.Value;
            cilinderHeight2 = (int)numericUpDownFig2Param2.Value;
            //тор            
            innerRadius2 = (int)numericUpDownFig2Param1.Value;
            outerRadius2 = (int)numericUpDownFig2Param2.Value;
        }

        // установка начальных параметров фигур
        private void SetParams(ComboBox box)
        {
            switch (box.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                case 0: // сфера
                    {
                        if (box == comboBoxFigure1)
                            sphereRadius1 = (int)numericUpDownFig1Param1.Value; //2;
                        else if (box == comboBoxFigure2)
                            sphereRadius2 = (int)numericUpDownFig2Param1.Value; //2;
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (box == comboBoxFigure1)
                        {
                            cilinderBaseRadius1 = (int)numericUpDownFig1Param1.Value; //1;
                            cilinderHeight1 = (int)numericUpDownFig1Param2.Value; //2;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            cilinderBaseRadius2 = (int)numericUpDownFig2Param1.Value; //1;
                            cilinderHeight2 = (int)numericUpDownFig2Param2.Value; //2;
                        }
                        break;
                    }
                case 2: // куб
                    {
                        if (box == comboBoxFigure1)
                            cubeSide1 = (int)numericUpDownFig1Param1.Value; //2;
                        else if (box == comboBoxFigure2)
                            cubeSide2 = (int)numericUpDownFig2Param1.Value; //2;
                        break;
                    }
                case 3: // конус
                    {
                        if (box == comboBoxFigure1)
                        {
                            coneBasemendRadius1 = (int)numericUpDownFig1Param1.Value; //2;
                            coneHeight1 = (int)numericUpDownFig1Param2.Value; //3;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            coneBasemendRadius2 = (int)numericUpDownFig2Param1.Value; //2;
                            coneHeight2 = (int)numericUpDownFig2Param2.Value; //3;
                        }
                        break;
                    }
                case 4: // тор
                    {
                        if (box == comboBoxFigure1)
                        {
                            innerRadius1 = (int)numericUpDownFig1Param1.Value; //1;
                            outerRadius1 = (int)numericUpDownFig1Param2.Value; //3;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            innerRadius2 = (int)numericUpDownFig2Param1.Value; //1;
                            outerRadius2 = (int)numericUpDownFig2Param2.Value; //3;
                        }
                        break;
                    }

            }
        }

        /* Cделать поля параметров фигур видимыми и вставить в label их названия
         * Если параметр 1, то делаем видимым только 1 label и 1 numericUpDown
         * иначе - 2 label'a и 2 numericUpDown'a
         */
        private void RevealFields(int prms, Label label1, Label label2, NumericUpDown field1, NumericUpDown field2, string text1, string text2)
        {
            // сфера, куб и все остальные фигуры
            label1.Visible = (prms > 0);
            field1.Visible = (prms > 0);
            // конус, цилиндр, тор
            label2.Visible = (prms > 1);
            field2.Visible = (prms > 1);
            label1.Text = text1;
            label2.Text = text2;
        }

        // отрисовка фигуры
        private void DrawFigure(int figureNumber, ComboBox box, float[] color)
        {
            // устанавливаем параметры (из полей формы)
            SetParams(box);

            //установка цвета объекта
            float[] shininess = new float[1] { 30 };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, color); // цвет объекта
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, color); // отраженный свет
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininess); // степень отраженного света

            // в зависимости от выбранного comboBoxFigure1 или же comboBoxFigure2
            switch (box.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                // попутно "открываем" нужные поля и лейблы для параметризации
                case 0: // сфера
                    {
                        if (box == comboBoxFigure1)
                            RevealFields(1, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "");
                        else if (box == comboBoxFigure2)
                            RevealFields(1, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "r", "");

                        if (figureNumber == 1)
                        {
                            if (wireMode)
                                Glut.glutWireSphere(sphereRadius1, 16, 16); // сеточная сфера 
                            else
                                Glut.glutSolidSphere(sphereRadius1, 16, 16); // полигональная сфера 
                        }
                        else
                        {
                            if (wireMode)
                                Glut.glutWireSphere(sphereRadius2, 16, 16); // сеточная сфера 
                            else
                                Glut.glutSolidSphere(sphereRadius2, 16, 16); // полигональная сфера 
                        }
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (box == comboBoxFigure1)
                            RevealFields(2, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "h");
                        else if (box == comboBoxFigure2)
                            RevealFields(2, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "r", "h");

                        if(figureNumber == 1)
                        {
                            if (wireMode)
                                Glut.glutWireCylinder(cilinderBaseRadius1, cilinderHeight1, 32, 32);
                            else
                                Glut.glutSolidCylinder(cilinderBaseRadius1, cilinderHeight1, 32, 32);
                        }
                        else
                        {
                            if (wireMode)
                                Glut.glutWireCylinder(cilinderBaseRadius2, cilinderHeight2, 32, 32);
                            else
                                Glut.glutSolidCylinder(cilinderBaseRadius2, cilinderHeight2, 32, 32);
                        }
                        break;
                    }
                case 2: // куб
                    {
                        if (box == comboBoxFigure1)
                            RevealFields(1, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "a", "");
                        else if (box == comboBoxFigure2)
                            RevealFields(1, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "a", "");

                        if(figureNumber == 1)
                        {
                            if (wireMode)
                                Glut.glutWireCube(cubeSide1);
                            else
                                Glut.glutSolidCube(cubeSide1);
                        }
                        else
                        {
                            if (wireMode)
                                Glut.glutWireCube(cubeSide2);
                            else
                                Glut.glutSolidCube(cubeSide2);
                        }
                        break;
                    }
                case 3: // конус
                    {
                        if (box == comboBoxFigure1)
                            RevealFields(2, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "h");
                        else if (box == comboBoxFigure2)
                            RevealFields(2, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "r", "h");

                        if(figureNumber == 1)
                        {
                            if (wireMode)
                                Glut.glutWireCone(coneBasemendRadius1, coneHeight1, 32, 32);
                            else
                                Glut.glutSolidCone(coneBasemendRadius1, coneHeight1, 32, 32);
                        }
                        else
                        {
                            if (wireMode)
                                Glut.glutWireCone(coneBasemendRadius2, coneHeight2, 32, 32);
                            else
                                Glut.glutSolidCone(coneBasemendRadius2, coneHeight2, 32, 32);
                        }
                        break;
                    }
                case 4: // тор
                    {
                        if (box == comboBoxFigure1)
                            RevealFields(2, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "r", "R");
                        else if (box == comboBoxFigure2)
                            RevealFields(2, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "r", "R");
                        if (figureNumber == 1)
                        {
                            if (wireMode)
                                Glut.glutWireTorus(innerRadius1, outerRadius1, 32, 32);
                            else
                                Glut.glutSolidTorus(innerRadius1, outerRadius1, 32, 32);
                        }
                        else
                        {
                            if (wireMode)
                                Glut.glutWireTorus(innerRadius2, outerRadius2, 32, 32);
                            else
                                Glut.glutSolidTorus(innerRadius2, outerRadius2, 32, 32);
                        }
                        break;
                    }
                default:
                    {
                        if (box == comboBoxFigure1)
                            RevealFields(0, labelFig1Param1, labelFig1Param2, numericUpDownFig1Param1, numericUpDownFig1Param2, "", "");
                        else if (box == comboBoxFigure2)
                            RevealFields(0, labelFig2Param1, labelFig2Param2, numericUpDownFig2Param1, numericUpDownFig2Param2, "", "");
                        break;
                    }
            }
        }

    }
}