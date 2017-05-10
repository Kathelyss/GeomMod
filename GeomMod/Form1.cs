﻿using System;
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
        int cubeSide1, sphereRadius1, coneBaseRadius1, cylinderBaseRadius1, coneHeight1, cylinderHeight1;
        int cubeSide2, sphereRadius2, coneBaseRadius2, cylinderBaseRadius2, coneHeight2, cylinderHeight2;
        int cx1, cx2, cy1, cy2, cz1, cz2;
        int currAngle;

        //for mouse
        static int old_x, old_y, mousePressed;
        static float X = 0.0f;        // Translate screen to x direction (left or right)
        static float Y = 0.0f;        // Translate screen to y direction (up or down)
        static float Z = 0.0f;        // Translate screen to z direction (zoom in or out)

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
            DrawScene(); // вызов функции отрисовки сцены
        }


        ////////////////////////////////////////////////////////////////////////////

        // неработающий кусок
        private void SimpleOpenGlControl_MouseWheel(object sender, MouseEventArgs e)
        {
            simpleOpenGlControl.MouseWheel += new MouseEventHandler(this.SimpleOpenGlControl_MouseWheel);
        }
        private void SimpleOpenGlControl_MouseDown(object sender, MouseEventArgs e) { }
        private void SimpleOpenGlControl_MouseUp(object sender, MouseEventArgs e) { }
        private void SimpleOpenGlControl_MouseMove(object sender, MouseEventArgs e) { }

        ////////////////////////////////////////////////////////////////////////////

        // отрисовка сцены
        private void DrawScene()
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            // очистка текущей матрицы 
            Gl.glLoadIdentity();
            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта 
            Gl.glPushMatrix();
            // производим перемещение в зависимости от значений, полученных при перемещении ползунков 
            Gl.glTranslated(a, b, c);
            // поворот по установленной оси 
            Gl.glRotated(d, os_x, os_y, os_z);
            // и масштабирование объекта 
            Gl.glScaled(zoom, zoom, zoom);

            //отрисовка 3D-осей координат
            DrawAxis();

            // отрисовка фигур
            DrawFigure(1, comboBoxFigure1);
            DrawFigure(2, comboBoxFigure2);

            // возвращаем состояние матрицы 
            Gl.glPopMatrix();
            // завершаем рисование 
            Gl.glFlush();
            // обновляем элемент 
            simpleOpenGlControl.Invalidate();
        }

        // отрисовка осей координат
        private void DrawAxis()
        {
            // отрисовка положительных частей осей координат
            Gl.glBegin(Gl.GL_LINES);

            Gl.glColor3f(0.0f, 1.0f, 0.0f); // зеленый цвет оси Х
            Gl.glVertex3f(0, 0, 0);
            Gl.glVertex3f(100, 0, 0);

            Gl.glColor3f(0.0f, 0.0f, 1.0f); // синий цвет оси Y
            Gl.glVertex3f(0, 0, 0);
            Gl.glVertex3f(0, 100, 0);

            Gl.glColor3f(1.0f, 0.0f, 0.0f); // красный цвет оси Z
            Gl.glVertex3f(0, 0, 0);
            Gl.glVertex3f(0, 0, 100);

            Gl.glEnd();

            // пунктир для отрицательных частей осей координат
            Gl.glEnable(Gl.GL_LINE_STIPPLE); // активизируем пунктирный режим
            Gl.glLineStipple(1, 0x00FF);     // тип пунктира осей

            Gl.glBegin(Gl.GL_LINES);

            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-100, 0, 0);
            Gl.glVertex3f(0, 0, 0);

            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(0, 0, 0);
            Gl.glVertex3f(0, -100, 0);

            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0, 0, 0);
            Gl.glVertex3f(0, 0, -100);

            Gl.glEnd();

            Gl.glDisable(Gl.GL_LINE_STIPPLE);
        }

        // отрисовка фигуры        
        private void DrawFigure(int figureNumber, ComboBox box)
        {
            // установка параметров фигуры (из полей формы)
            SetParams(box);

            //установка цвета фигуры
            if (figureNumber == 1)
                Gl.glColor3f(0.5f, 0.0f, 0.5f); //
            else
                Gl.glColor3f(0.9f, 0.5f, 0.2f); // оранжевый

            // в зависимости от выбранной фигуры (1 или 2)
            switch (box.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                // попутно "открываем" нужные поля и лейблы для параметризации
                case 0: // сфера
                    {
                        if (box == comboBoxFigure1)
                        {
                            RevealFields(1, 1, "r", "");
                            Glut.glutWireSphere(sphereRadius1, 16, 16); // сеточная сфера 
                        }
                        else if (box == comboBoxFigure2)
                        {
                            RevealFields(1, 2, "r", "");
                            Glut.glutWireSphere(sphereRadius2, 16, 16); // сеточная сфера 
                        }
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (box == comboBoxFigure1)
                        {
                            RevealFields(2, 1, "r", "h");
                            DrawCylinder(cx1, cy1, cz1, cylinderHeight1, cylinderBaseRadius1);
                        }
                        else if (box == comboBoxFigure2)
                        {
                            RevealFields(2, 2, "r", "h");
                            DrawCylinder(cx2, cy2, cz2, cylinderHeight2, cylinderBaseRadius2);
                        }
                        break;
                    }
                case 2: // куб
                    {
                        if (box == comboBoxFigure1)
                        {
                            RevealFields(1, 1, "a", "");
                            DrawCube(cx1, cy1, cz1, cubeSide1);
                        }
                        else if (box == comboBoxFigure2)
                        {
                            RevealFields(1, 2, "a", "");
                            DrawCube(cx2, cy2, cz2, cubeSide2);
                        }
                        break;
                    }
                case 3: // конус
                    {
                        if (box == comboBoxFigure1)
                        {
                            RevealFields(2, 1, "r", "h");                            
                            DrawCone(cx1, cy1, cz1, coneHeight1, coneBaseRadius1);
                        }
                        else if (box == comboBoxFigure2)
                        {
                            RevealFields(2, 2, "r", "h");
                            DrawCone(cx2, cy2, cz2, coneHeight2, coneBaseRadius2);
                        }
                        break;
                    }
                default:
                    {
                        if (box == comboBoxFigure1)
                            RevealFields(0, 1, "", "");
                        else if (box == comboBoxFigure2)
                            RevealFields(0, 2, "", "");
                        break;
                    }
            }
        }

    
        // получение параметров фигур из полей формы
        private void GetParams()
        {
            //1я фигура
            //куб и сфера
            cubeSide1 = (int)numericUpDownFig1Param1.Value;
            sphereRadius1 = (int)numericUpDownFig1Param1.Value;
            //конус
            coneBaseRadius1 = (int)numericUpDownFig1Param1.Value;
            coneHeight1 = (int)numericUpDownFig1Param2.Value;
            //цилиндр
            cylinderBaseRadius1 = (int)numericUpDownFig1Param1.Value;
            cylinderHeight1 = (int)numericUpDownFig1Param2.Value;

            cx1 = (int)numericUpDownCX1.Value;
            cy1 = (int)numericUpDownCY1.Value;
            cz1 = (int)numericUpDownCZ1.Value;

            //2я фигура
            //куб и сфера
            cubeSide2 = (int)numericUpDownFig2Param1.Value;
            sphereRadius2 = (int)numericUpDownFig2Param1.Value;
            //конус
            coneBaseRadius2 = (int)numericUpDownFig2Param1.Value;
            coneHeight2 = (int)numericUpDownFig2Param2.Value;
            //цилиндр
            cylinderBaseRadius2 = (int)numericUpDownFig2Param1.Value;
            cylinderHeight2 = (int)numericUpDownFig2Param2.Value;

            cx2 = (int)numericUpDownCX2.Value;
            cy2 = (int)numericUpDownCY2.Value;
            cz2 = (int)numericUpDownCZ2.Value;
        }

        // установка параметров фигур из полей формы
        private void SetParams(ComboBox box)
        {
            cx1 = (int)numericUpDownCX1.Value;
            cy1 = (int)numericUpDownCY1.Value;
            cz1 = (int)numericUpDownCZ1.Value;
            cx2 = (int)numericUpDownCX2.Value;
            cy2 = (int)numericUpDownCY2.Value;
            cz2 = (int)numericUpDownCZ2.Value;

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
                            cylinderBaseRadius1 = (int)numericUpDownFig1Param1.Value; //1;
                            cylinderHeight1 = (int)numericUpDownFig1Param2.Value; //2;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            cylinderBaseRadius2 = (int)numericUpDownFig2Param1.Value; //1;
                            cylinderHeight2 = (int)numericUpDownFig2Param2.Value; //2;
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
                            coneBaseRadius1 = (int)numericUpDownFig1Param1.Value; //2;
                            coneHeight1 = (int)numericUpDownFig1Param2.Value; //3;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            coneBaseRadius2 = (int)numericUpDownFig2Param1.Value; //2;
                            coneHeight2 = (int)numericUpDownFig2Param2.Value; //3;
                        }
                        break;
                    }
            }
        }

        /* Cделать поля параметров фигур видимыми и вставить в label их названия
         * Если параметр 1, то делаем видимым только 1 label и 1 numericUpDown
         * иначе - 2 label'a и 2 numericUpDown'a
         */
        private void RevealFields(int prms, int figNum, string text1, string text2)
        {
            if (figNum == 1)
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


        private void Drawings()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();   // It is important to push the Matrix before calling glRotatef and glTranslatef
            /*  
              Gl.glRotatef(rotX, 1.0f, 0.0f, 0.0f);            // Rotate on x
              Gl.glRotatef(rotY, 0.0f, 1.0f, 0.0f);            // Rotate on y
              Gl.glRotatef(rotZ, 0.0f, 0.0f, 1.0f);            // Rotate on z

              if (rotation) // If F2 is pressed update x,y,z for rotation of the cube
              {
                  rotX += 0.2f;
                  rotY += 0.2f;
                  rotZ += 0.2f;
              }
            Gl.glTranslatef(X, Y, Z); // Translates the screen left or right, up or down or zoom in zoom out
            */
        }

        //задание вектора - углом!
        private void DrawCube(int x, int y, int z, int side)
        {
            Gl.glTranslatef(x, y, z);
            Gl.glRotatef(-90, x, 0, 0);
            Glut.glutWireCube(side);
        }

        private void DrawCone(int x, int y, int z, int height, int radius)
        {
            Gl.glTranslatef(x, y, z);
            Gl.glRotatef(-90, x, 0, 0);
            Glut.glutWireCone(radius, height, 32, 32);
        }

        private void DrawCylinder(int x, int y, int z, int height, int radius)
        {
            Gl.glTranslatef(x, y, z);
            Gl.glRotatef(-90, x, 0, 0);
            Glut.glutWireCylinder(radius, height, 32, 32);
        }
    }
}