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
        Figure figure = new Figure();

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

        public void DrawScene(MainForm form)
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();                // очистка текущей матрицы 
            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта 
            Gl.glPushMatrix();
            // перемещение в зависимости от значений, полученных при перемещении ползунков 
            Gl.glTranslated(MainForm.a, MainForm.b, MainForm.c);
            Gl.glRotated(MainForm.d, MainForm.os_x, MainForm.os_y, MainForm.os_z);  // поворот по установленной оси             
            Gl.glScaled(MainForm.zoom, MainForm.zoom, MainForm.zoom);      // и масштабирование объекта 

            DrawAxis();                         //отрисовка 3D-осей координат            
            DrawFigure(form, form.comboBoxFigure1, 1);// отрисовка фигур
            DrawFigure(form, form.comboBoxFigure2, 2);

            Gl.glPopMatrix();                   // возвращаем состояние матрицы             
            Gl.glFlush();                       // завершаем рисование             
            form.simpleOpenGlControl.Invalidate();          // обновляем элемент 
        }

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
       
        private void DrawFigure(MainForm form, ComboBox box, int figureNumber)
        {            
            // установка параметров фигуры (из полей формы)
            figure.SetParams(form, box, figureNumber);

            //установка цвета фигуры
            if (figureNumber == 1)
                Gl.glColor3f(0.5f, 0.0f, 0.5f); //
            else
                Gl.glColor3f(0.9f, 0.5f, 0.2f); // оранжевый

            // в зависимости от выбранной фигуры (1 или 2)
            switch (box.SelectedIndex)
            {
                case 0: // сфера
                    {
                        if (figureNumber == 1)
                            DrawShpere(figure.Center, -90, figure.Radius);
                        else if (figureNumber == 2)
                            DrawShpere(figure.Center, 0, figure.Radius);
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (figureNumber == 1)
                            DrawCylinder(figure.Center, -90, figure.Height, figure.Radius);
                        else if (figureNumber == 2)
                            DrawCylinder(figure.Center, 0, figure.Height, figure.Radius);
                        break;
                    }
                case 2: // куб
                    {
                        if (figureNumber == 1)
                            DrawCube(figure.Center, -90, figure.Radius);
                        else if (figureNumber == 2)
                            DrawCube(figure.Center, 0, figure.Radius);
                        break;
                    }
                case 3: // конус
                    {
                        if (figureNumber == 1)
                            DrawCone(figure.Center, -90, figure.Height, figure.Radius);
                        else if (figureNumber == 2)
                            DrawCone(figure.Center, 0, figure.Height, figure.Radius);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
