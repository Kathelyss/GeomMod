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

        //задание вектора - углом
        /*
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
        */

        private void DrawCircle(CenterPoint point, float radius, int slices)
        {
            double theta = (2 * Math.PI) / (double)slices;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = radius; //we start at angle = 0 
            double z = 0;

            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < slices; i++)
            {
                Gl.glVertex3d(x + point.coord_x, point.coord_y, z + point.coord_z);
                double tx = -z;
                double ty = x;

                x += tx * tangetial_factor;
                z += ty * tangetial_factor;

                x *= radial_factor;
                z *= radial_factor;
            }
            Gl.glEnd();
        }

        private void DrawShpere(CenterPoint point, int angle, int radius)
        {
            Gl.glTranslatef(point.coord_x, point.coord_y, point.coord_z);
            Gl.glRotatef(angle, point.coord_x, 0, 0);
            Glut.glutWireSphere(radius, 16, 16);
        }

        /*private void DrawShpere(CenterPoint point, float radius)
        {
            //  for (float i = 0; i <= radius; i++)
            //    DrawCircle(new CenterPoint(point.coord_x, point.coord_y + i, point.coord_z), radius, 32);

            double theta = (2 * Math.PI) / (double)32.0;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = radius; //we start at angle = 0 
            double z = 0;

            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < 32; i++)
            {
                Gl.glVertex3d(x + point.coord_x, point.coord_y, z + point.coord_z); // точка на окружности в основании

                Gl.glBegin(Gl.GL_LINE_LOOP);
                for (int j = 0; j < 16; j++)
                {
                    Gl.glVertex3d(x + point.coord_x, y + point.coord_y, z + point.coord_z); // точка на окружности в основании

                    double tz1 = -z;
                    double ty1 = x;
                    x += tz1 * tangetial_factor;
                    z += ty1 * tangetial_factor;
                    x *= radial_factor;
                    z *= radial_factor;
                }
                Gl.glEnd();
                double tz = -z;
                double ty = x;
                x += tz * tangetial_factor;
                z += ty * tangetial_factor;
                x *= radial_factor;
                z *= radial_factor;
            }
            Gl.glEnd();
        }
        */

        private void DrawCone(CenterPoint point, float radius, int height)
        {
            float tmp_radius = radius;
            for (int i = 0; i <= height; i++)
            {
                DrawCircle(new CenterPoint(point.coord_x, point.coord_y + i, point.coord_z), radius, 32);
                radius = (float)(radius - 0.7);
            }
            radius = tmp_radius;

            double theta = (2 * Math.PI) / (double)32.0;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = radius; //we start at angle = 0 
            double z = 0;

            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < 32.0; i++)
            {
                Gl.glVertex3d(point.coord_x, point.coord_y, point.coord_z); // центр в основании
                Gl.glVertex3d(x + point.coord_x, point.coord_y, z + point.coord_z); // точка на окружности в основании
                Gl.glVertex3d(point.coord_x, point.coord_y + height, point.coord_z); // вершина (центр на вершине конуса)
                Gl.glVertex3d(point.coord_x, point.coord_y, point.coord_z); // центр в основании

                double tx = -z;
                double ty = x;
                x += tx * tangetial_factor;
                z += ty * tangetial_factor;
                x *= radial_factor;
                z *= radial_factor;
            }
            Gl.glEnd();
        }

        private void DrawCylinder(CenterPoint point, float radius, int height)
        {
            for (float i = 0; i <= height; i++)
                DrawCircle(new CenterPoint(point.coord_x, point.coord_y + i, point.coord_z), radius, 32);

            double theta = (2 * Math.PI) / (double)32.0;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = radius; //we start at angle = 0 
            double z = 0;

            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < 32; i++)
            {
                Gl.glVertex3d(point.coord_x, point.coord_y, point.coord_z); // центр в основании
                Gl.glVertex3d(x + point.coord_x, point.coord_y, z + point.coord_z); // точка на окружности в основании
                Gl.glVertex3d(x + point.coord_x, point.coord_y + height, z + point.coord_z); // точка на окружности на вершине
                Gl.glVertex3d(point.coord_x, point.coord_y + height, point.coord_z); // центр на вершине
                Gl.glVertex3d(point.coord_x, point.coord_y, point.coord_z); // центр в основании

                double tx = -z;
                double ty = x;
                x += tx * tangetial_factor;
                z += ty * tangetial_factor;
                x *= radial_factor;
                z *= radial_factor;
            }
            Gl.glEnd();
        }

        private void DrawCube(CenterPoint point, float side)
        {
            float iter = (side / 6);
            // квадраты вдоль левой стенки (вертикальные)
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (float i = 0; (point.coord_x - side / 2 + i) < (point.coord_x + side / 2); i += iter)
            {
                Gl.glVertex3d(point.coord_x - side / 2 + i, point.coord_y, point.coord_z);
                Gl.glVertex3d(point.coord_x - side / 2 + i, point.coord_y, point.coord_z - side / 2);
                Gl.glVertex3d(point.coord_x - side / 2 + i, point.coord_y + side, point.coord_z - side / 2);
                Gl.glVertex3d(point.coord_x - side / 2 + i, point.coord_y + side, point.coord_z + side / 2);
                Gl.glVertex3d(point.coord_x - side / 2 + i, point.coord_y, point.coord_z + side / 2);
                Gl.glVertex3d(point.coord_x - side / 2 + i, point.coord_y, point.coord_z);
            }
            Gl.glEnd();

            //квадраты вдоль передней стенки (вертикальные)
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (float i = 0; (point.coord_z + side / 2 - i) > (point.coord_z - side / 2); i += iter)
            {
                Gl.glVertex3d(point.coord_x, point.coord_y, point.coord_z + side / 2 - i);
                Gl.glVertex3d(point.coord_x + side / 2, point.coord_y, point.coord_z + side / 2 - i);
                Gl.glVertex3d(point.coord_x + side / 2, point.coord_y + side, point.coord_z + side / 2 - i);
                Gl.glVertex3d(point.coord_x - side / 2, point.coord_y + side, point.coord_z + side / 2 - i);
                Gl.glVertex3d(point.coord_x - side / 2, point.coord_y, point.coord_z + side / 2 - i);
                Gl.glVertex3d(point.coord_x, point.coord_y, point.coord_z + side / 2 - i);
            }
            Gl.glEnd();

            // квадраты горизонтальные
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (float i = 0; (point.coord_y + i) < (point.coord_y + side); i += iter)
            {
                Gl.glVertex3d(point.coord_x - side / 2, point.coord_y + i, point.coord_z + side / 2);
                Gl.glVertex3d(point.coord_x + side / 2, point.coord_y + i, point.coord_z + side / 2);
                Gl.glVertex3d(point.coord_x + side / 2, point.coord_y + i, point.coord_z - side / 2);
                Gl.glVertex3d(point.coord_x - side / 2, point.coord_y + i, point.coord_z - side / 2);
                Gl.glVertex3d(point.coord_x - side / 2, point.coord_y + i, point.coord_z + side / 2);
            }
            Gl.glEnd();

            //недостающие стенки 
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex3d(point.coord_x + side / 2, point.coord_y, point.coord_z + side / 2);
            Gl.glVertex3d(point.coord_x + side / 2, point.coord_y, point.coord_z - side / 2);
            Gl.glVertex3d(point.coord_x + side / 2, point.coord_y + side, point.coord_z - side / 2);
            Gl.glVertex3d(point.coord_x + side / 2, point.coord_y + side, point.coord_z + side / 2);
            Gl.glVertex3d(point.coord_x + side / 2, point.coord_y, point.coord_z + side / 2);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex3d(point.coord_x - side / 2, point.coord_y, point.coord_z - side / 2);
            Gl.glVertex3d(point.coord_x + side / 2, point.coord_y, point.coord_z - side / 2);
            Gl.glVertex3d(point.coord_x + side / 2, point.coord_y + side, point.coord_z - side / 2);
            Gl.glVertex3d(point.coord_x - side / 2, point.coord_y + side, point.coord_z - side / 2);
            Gl.glVertex3d(point.coord_x - side / 2, point.coord_y, point.coord_z - side / 2);
            Gl.glEnd();
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
                Gl.glColor3f(0.5f, 0.0f, 0.5f); // фиолетовый
            else
                Gl.glColor3f(0.9f, 0.5f, 0.2f); // оранжевый

            // в зависимости от выбранной фигуры (1 или 2)
            switch (box.SelectedIndex)
            {
                /*case 0: // сфера
                    {
                        if (figureNumber == 1)
                            DrawShpere(figure.Center, -90, figure.Radius);
                        else if (figureNumber == 2)
                            DrawShpere(figure.Center, -360, figure.Radius);
                        break;
                    }*/
                case 1: // цилиндр
                    {
                        if (figureNumber == 1)
                            DrawCylinder(figure.Center, figure.Radius, figure.Height);
                        else if (figureNumber == 2)
                            DrawCylinder(figure.Center, figure.Radius, figure.Height);
                        break;
                    }
                case 2: // куб
                    {
                        if (figureNumber == 1)
                            DrawCube(figure.Center, figure.Radius);
                        else if (figureNumber == 2)
                            DrawCube(figure.Center, figure.Radius);
                        break;
                    }
                case 3: // конус
                    {
                        if (figureNumber == 1)
                            DrawCone(figure.Center, figure.Radius, figure.Height);
                        else if (figureNumber == 2)
                            DrawCone(figure.Center, figure.Radius, figure.Height);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
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

            //DrawCone(new CenterPoint(1, 0, 0), 6, 7);
           // DrawShpere(new CenterPoint(1, 0, 0), 3);

            Gl.glPopMatrix();                   // возвращаем состояние матрицы             
            Gl.glFlush();                       // завершаем рисование             
            form.simpleOpenGlControl.Invalidate();          // обновляем элемент 
        }
    }
}
