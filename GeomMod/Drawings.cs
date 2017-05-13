using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace GeomMod
{   
    public class Drawings
    {
        MainForm Form = new MainForm();

        private void Draw()
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

        //задание вектора - углом
        public void DrawCube(CenterPoint point, int angle, int side)
        {
            Gl.glTranslatef(point.coord_x, point.coord_y, point.coord_z);
            Gl.glRotatef(angle, point.coord_x, 0, 0);
            Glut.glutWireCube(side);
        }

        public void DrawCone(CenterPoint point, int angle, int height, int radius)
        {
            Gl.glTranslatef(point.coord_x, point.coord_y, point.coord_z);
            Gl.glRotatef(angle, point.coord_x, 0, 0);
            Glut.glutWireCone(radius, height, 32, 32);
        }

        public void DrawCylinder(CenterPoint point, int angle, int height, int radius)
        {
            Gl.glTranslatef(point.coord_x, point.coord_y, point.coord_z);
            Gl.glRotatef(angle, point.coord_x, 0, 0);
            Glut.glutWireCylinder(radius, height, 32, 32);
        }

        public void DrawShpere(CenterPoint point, int angle, int radius)
        {
            Gl.glTranslatef(point.coord_x, point.coord_y, point.coord_z);
            Gl.glRotatef(angle, point.coord_x, 0, 0);
            Glut.glutWireSphere(radius, 16, 16);
        }

        public void DrawScene(Tao.Platform.Windows.SimpleOpenGlControl drawingField, ComboBox box1, ComboBox box2)
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();                // очистка текущей матрицы 
            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта 
            Gl.glPushMatrix();
            // перемещение в зависимости от значений, полученных при перемещении ползунков 
            Gl.glTranslated(Form.a, Form.b, Form.c);
            Gl.glRotated(Form.d, Form.os_x, Form.os_y, Form.os_z);  // поворот по установленной оси             
            Gl.glScaled(Form.zoom, Form.zoom, Form.zoom);      // и масштабирование объекта 

            DrawAxis();                         //отрисовка 3D-осей координат            
            DrawFigure(1, box1);                // отрисовка фигур
            DrawFigure(2, box2);

            Gl.glPopMatrix();                   // возвращаем состояние матрицы             
            Gl.glFlush();                       // завершаем рисование             
            drawingField.Invalidate();          // обновляем элемент 
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
            CenterPoint center1 = null;
            CenterPoint center2 = null;
            // установка параметров фигуры (из полей формы)
            Figure.SetParams(box);

            //установка цвета фигуры
            if (figureNumber == 1)
            {
                Gl.glColor3f(0.5f, 0.0f, 0.5f); //
                center1 = new CenterPoint(cx1, cy1, cz1);
            }
            else
            {
                Gl.glColor3f(0.9f, 0.5f, 0.2f); // оранжевый
                center2 = new CenterPoint(cx2 - cx1, cy2 - cy1, cz2 - cz1);
            }
            // в зависимости от выбранной фигуры (1 или 2)
            switch (box.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                // попутно "открываем" нужные поля и лейблы для параметризации
                case 0: // сфера
                    {
                        if (figureNumber == 1)
                        {
                            Form.RevealFields(1, 1, "r", "");
                            DrawShpere(center1, -90, sphereRadius1);
                        }
                        else if (figureNumber == 2)
                        {
                            Form.RevealFields(1, 2, "r", "");
                            DrawShpere(center2, 0, sphereRadius2);
                        }
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (figureNumber == 1)
                        {
                            Form.RevealFields(2, 1, "r", "h");
                            DrawCylinder(center1, -90, cylinderHeight1, cylinderBaseRadius1);
                        }
                        else if (figureNumber == 2)
                        {
                            Form.RevealFields(2, 2, "r", "h");
                            DrawCylinder(center2, 0, cylinderHeight2, cylinderBaseRadius2);
                        }
                        break;
                    }
                case 2: // куб
                    {
                        if (figureNumber == 1)
                        {
                            Form.RevealFields(1, 1, "a", "");
                            DrawCube(center1, -90, cubeSide1);
                        }
                        else if (figureNumber == 2)
                        {
                            Form.RevealFields(1, 2, "a", "");
                            DrawCube(center2, 0, cubeSide2);
                        }
                        break;
                    }
                case 3: // конус
                    {
                        if (figureNumber == 1)
                        {
                            Form.RevealFields(2, 1, "r", "h");
                            DrawCone(center1, -90, coneHeight1, coneBaseRadius1);
                        }
                        else if (figureNumber == 2)
                        {
                            Form.RevealFields(2, 2, "r", "h");
                            DrawCone(center2, 0, coneHeight2, coneBaseRadius2);
                        }
                        break;
                    }
                default:
                    {
                        if (figureNumber == 1)
                            Form.RevealFields(0, 1, "", "");
                        else if (figureNumber == 2)
                            Form.RevealFields(0, 2, "", "");
                        break;
                    }
            }
        }
    }
}
