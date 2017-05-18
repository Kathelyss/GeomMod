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
        double[] camRotation = new double[3];
        double[] camPosition = new double[3];
        double camSpeed = 1;

        Figure figure1 = new Figure();
        Figure figure2 = new Figure();


        private void DrawCube(Point point, float side)
        {
            // квадраты вдоль левой стенки (вертикальные)
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (float i = 0; i <= side; i++)
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
            for (float i = 0; i <= side; i++)
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
            for (float i = 0; i <= side; i++)
            {
                Gl.glVertex3d(point.coord_x - side / 2, point.coord_y + i, point.coord_z + side / 2);
                Gl.glVertex3d(point.coord_x + side / 2, point.coord_y + i, point.coord_z + side / 2);
                Gl.glVertex3d(point.coord_x + side / 2, point.coord_y + i, point.coord_z - side / 2);
                Gl.glVertex3d(point.coord_x - side / 2, point.coord_y + i, point.coord_z - side / 2);
                Gl.glVertex3d(point.coord_x - side / 2, point.coord_y + i, point.coord_z + side / 2);
            }
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

        private void Draw(List<Point> points)
        {
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < points.Count; i++)
                Gl.glVertex3d(points[i].coord_x, points[i].coord_y, points[i].coord_z);
            Gl.glEnd();
        }

        private void DrawFigure(Figure figure, ComboBox box)
        {
            switch (box.SelectedIndex)
            {
                case 0: // куб
                    {
                        //DrawFigure(figure)
                        DrawCube(figure.Center, figure.Radius);
                        break;
                    }
                case 1: // конус
                    {
                        Draw(figure.Cone(figure.Center, figure.Radius, figure.Height));
                        break;
                    }
                case 2: // цилиндр
                    {
                        Draw(figure.Cylinder(figure.Center, figure.Radius, figure.Height));
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

            figure1.SetParams(form, form.comboBoxFigure1, 1);
            figure2.SetParams(form, form.comboBoxFigure2, 2);

            DrawAxis();                         //отрисовка осей координат 
            Gl.glColor3f(0.5f, 0.0f, 0.5f);     // цвет фигуры - фиолетовый
            DrawFigure(figure1, form.comboBoxFigure1);// отрисовка фигур
            Gl.glColor3f(0.9f, 0.5f, 0.2f);     // цвет фигуры - оранжевый
            DrawFigure(figure2, form.comboBoxFigure2);

            //DrawFigure(figure1.Cylinder(new Point(0, 0, 0), 2, 3));

            Gl.glPopMatrix();                   // возвращаем состояние матрицы             
            Gl.glFlush();                       // завершаем рисование             
            form.simpleOpenGlControl.Invalidate();          // обновляем элемент 

            if (figure1.IntersectionIsPossible(figure2))
                form.textBox1.Text = "intersection is possible";
            else
                form.textBox1.Text = "NO";
        }

        public void MoveRotate(MainForm form, double[] sign)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            camRotation[0] -= sign[1] * camSpeed;
            camRotation[1] += sign[0] * camSpeed;
            Gl.glTranslated(camPosition[0], camPosition[1], camPosition[2]);
            Gl.glRotated(camRotation[0], 1, 0, 0);
            Gl.glRotated(camRotation[1], 0, 1, 0);

            DrawScene(form);
        }
    }
}
