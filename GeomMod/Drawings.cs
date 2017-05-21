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
        Figure figure1 = new Figure();
        Figure figure2 = new Figure();
        List<Point> intersection = new List<Point>();

        bool drawViaPoints = true;
        bool drawViaLines = false;
        bool drawViaPolygons = false;

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

        // отрисовка фигуры по набору точек
        private void Draw(List<Point> points)
        {
            Gl.glBegin(Gl.GL_LINE_LOOP);
            for (int i = 0; i < points.Count; i++)
                Gl.glVertex3d(points[i].coord_x, points[i].coord_y, points[i].coord_z);
            Gl.glEnd();
        }

        // отрисовка фигуры по набору линий
        private void Draw(List<Line> lines)
        {
            Gl.glBegin(Gl.GL_LINES);
            for (int i = 0; i < lines.Count; i++)
            {
                Gl.glVertex3d(lines[i].begin.coord_x, lines[i].begin.coord_y, lines[i].begin.coord_z);
                Gl.glVertex3d(lines[i].end.coord_x, lines[i].end.coord_y, lines[i].end.coord_z);
            }
            Gl.glEnd();
        }

        private void Draw(List<Polygon> polygons)
        {
            Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
            /*
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(polygons[0].line1.begin.coord_x, polygons[0].line1.begin.coord_y, polygons[0].line1.begin.coord_z);
            Gl.glVertex3d(polygons[0].line2.begin.coord_x, polygons[0].line2.begin.coord_y, polygons[0].line2.begin.coord_z);
            Gl.glVertex3d(polygons[0].line3.begin.coord_x, polygons[0].line3.begin.coord_y, polygons[0].line3.begin.coord_z);
            Gl.glVertex3d(polygons[0].line4.begin.coord_x, polygons[0].line4.begin.coord_y, polygons[0].line4.begin.coord_z);
            Gl.glEnd();
            */
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(polygons[1].line1.begin.coord_x, polygons[1].line1.begin.coord_y, polygons[1].line1.begin.coord_z);
            Gl.glVertex3d(polygons[1].line2.begin.coord_x, polygons[1].line2.begin.coord_y, polygons[1].line2.begin.coord_z);
            Gl.glVertex3d(polygons[1].line3.begin.coord_x, polygons[1].line3.begin.coord_y, polygons[1].line3.begin.coord_z);
            Gl.glVertex3d(polygons[1].line4.begin.coord_x, polygons[1].line4.begin.coord_y, polygons[1].line4.begin.coord_z);
            Gl.glEnd();
            /*
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(polygons[2].line1.begin.coord_x, polygons[2].line1.begin.coord_y, polygons[2].line1.begin.coord_z);
            Gl.glVertex3d(polygons[2].line2.begin.coord_x, polygons[2].line2.begin.coord_y, polygons[2].line2.begin.coord_z);
            Gl.glVertex3d(polygons[2].line3.begin.coord_x, polygons[2].line3.begin.coord_y, polygons[2].line3.begin.coord_z);
            Gl.glVertex3d(polygons[2].line4.begin.coord_x, polygons[2].line4.begin.coord_y, polygons[2].line4.begin.coord_z);
            Gl.glEnd();
            /*
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(polygons[0].line1.begin.coord_x, polygons[0].line1.begin.coord_y, polygons[0].line1.begin.coord_z);
            Gl.glVertex3d(polygons[0].line2.begin.coord_x, polygons[0].line2.begin.coord_y, polygons[0].line2.begin.coord_z);
            Gl.glVertex3d(polygons[0].line3.begin.coord_x, polygons[0].line3.begin.coord_y, polygons[0].line3.begin.coord_z);
            Gl.glVertex3d(polygons[0].line4.begin.coord_x, polygons[0].line4.begin.coord_y, polygons[0].line4.begin.coord_z);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(polygons[0].line1.begin.coord_x, polygons[0].line1.begin.coord_y, polygons[0].line1.begin.coord_z);
            Gl.glVertex3d(polygons[0].line2.begin.coord_x, polygons[0].line2.begin.coord_y, polygons[0].line2.begin.coord_z);
            Gl.glVertex3d(polygons[0].line3.begin.coord_x, polygons[0].line3.begin.coord_y, polygons[0].line3.begin.coord_z);
            Gl.glVertex3d(polygons[0].line4.begin.coord_x, polygons[0].line4.begin.coord_y, polygons[0].line4.begin.coord_z);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(polygons[0].line1.begin.coord_x, polygons[0].line1.begin.coord_y, polygons[0].line1.begin.coord_z);
            Gl.glVertex3d(polygons[0].line2.begin.coord_x, polygons[0].line2.begin.coord_y, polygons[0].line2.begin.coord_z);
            Gl.glVertex3d(polygons[0].line3.begin.coord_x, polygons[0].line3.begin.coord_y, polygons[0].line3.begin.coord_z);
            Gl.glVertex3d(polygons[0].line4.begin.coord_x, polygons[0].line4.begin.coord_y, polygons[0].line4.begin.coord_z);
            Gl.glEnd();
            */
            /*
                         res.Add(new Polygon(lines[0], lines[1], lines[2], lines[3]));
            // правая
            res.Add(new Polygon(lines[2], lines[8], lines[9], lines[10]));
            // нижняя
            res.Add(new Polygon(lines[9], lines[7], lines[5], lines[11]));
            // левая
            res.Add(new Polygon(lines[5], lines[6], lines[0], lines[4]));
            // задняя
            res.Add(new Polygon(lines[3], lines[10], lines[11], lines[4]));
            // передняя
            res.Add(new Polygon(lines[1], lines[8], lines[7], lines[6]));
             */
        }

        private void Draw(Figure figure, ComboBox box)
        {
            switch (box.SelectedIndex)
            {
                case 0: // куб
                    {
                        if (drawViaLines)
                            figure.lines = figure.CubeViaLines(figure.center, figure.side);
                        else if (drawViaPoints)
                            figure.points = figure.CubeViaPoints(figure.center, figure.side);
                        else if (drawViaPolygons)
                        {
                            figure.lines = figure.CubeViaLines(figure.center, figure.side);
                            figure.polygons = figure.CubeViaPolygons(figure.lines);
                        }
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (drawViaLines)
                            figure.lines = figure.CylinderViaLines(figure.center, figure.side, figure.height);
                        else if (drawViaPoints)
                        {
                            figure.lines = figure.CylinderViaLines(figure.center, figure.side, figure.height);
                            figure.points = figure.CylinderViaPoints(figure.center, figure.side, figure.height);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (figure.lines != null && drawViaLines)
                Draw(figure.lines);
            else if (figure.points != null && drawViaPoints)
                Draw(figure.points);
            else if (figure.polygons != null && drawViaPolygons)
                Draw(figure.polygons);
        }

        public void DrawScene(MainForm form)
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(0, 0, 0, 1);
            Gl.glLoadIdentity();                // очистка текущей матрицы 
            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта 
            Gl.glPushMatrix();
            // перемещение в зависимости от значений, полученных при перемещении ползунков 

            Gl.glTranslated(form.camPosition[0], form.camPosition[1], form.camPosition[2]);
            Gl.glRotated(form.camRotation[0], 1, 0, 0);
            Gl.glRotated(form.camRotation[1], 0, 1, 0);

            figure1.SetParams(form, form.comboBoxFigure1, 1);
            figure2.SetParams(form, form.comboBoxFigure2, 2);

            DrawAxis();
            Gl.glColor3f(0.9f, 0.0f, 0.9f);     // цвет фигуры - фиолетовый
            Draw(figure1, form.comboBoxFigure1);
            Gl.glColor3f(0.0f, 0.5f, 0.9f);     // цвет фигуры - голубой
            Draw(figure2, form.comboBoxFigure2);


            intersection = figure1.IntersectionWith(figure2);
            if (intersection != null)
            {
                Gl.glColor3f(1.0f, 1.0f, 1.0f);
                Gl.glLineWidth(2f);
                Gl.glEnable(Gl.GL_LINE_STIPPLE);
                Draw(intersection);
                Gl.glLineWidth(0.5f);
                Gl.glDisable(Gl.GL_LINE_STIPPLE);
            }

            Gl.glPopMatrix();                   // возвращаем состояние матрицы             
            Gl.glFlush();                       // завершаем рисование             
            form.simpleOpenGlControl.Invalidate();          // обновляем элемент 

            if (figure1.IntersectionIsPossible(figure2))
                form.textBox1.Text = "YES";
            else
                form.textBox1.Text = "NO";
        }

        public void MoveRotate(MainForm form, double[] sign)
        {
            form.camRotation[0] -= sign[1] * form.camSpeed;
            form.camRotation[1] += sign[0] * form.camSpeed;
            Gl.glTranslated(form.camPosition[0], form.camPosition[1], form.camPosition[2]);
            Gl.glRotated(form.camRotation[0], 1, 0, 0);
            Gl.glRotated(form.camRotation[1], 0, 1, 0);

            DrawScene(form);
        }
    }
}
