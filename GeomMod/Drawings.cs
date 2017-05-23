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
        List<Point> intersectionUp = new List<Point>();
        List<Point> intersectionDown = new List<Point>();
        List<Point> intersectionSide = new List<Point>();

        bool drawViaPoints = true;
        bool drawViaLines = false;

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
                Gl.glVertex3d(points[i].c_x, points[i].c_y, points[i].c_z);
            Gl.glEnd();
        }

        // отрисовка фигуры по набору линий
        private void Draw(List<Line> lines)
        {
            Gl.glBegin(Gl.GL_LINES);
            for (int i = 0; i < lines.Count; i++)
            {
                Gl.glVertex3d(lines[i].begin.c_x, lines[i].begin.c_y, lines[i].begin.c_z);
                Gl.glVertex3d(lines[i].end.c_x, lines[i].end.c_y, lines[i].end.c_z);
            }
            Gl.glEnd();
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

            if (figure1.IntersectionIsPossible(figure2))
            {
                Intersection res = new Intersection();
                res = figure1.CreateIntersection(figure2);
                Gl.glColor3f(1.0f, 1.0f, 1.0f);
                Gl.glLineWidth(3f);
                Gl.glEnable(Gl.GL_LINE_STIPPLE);
                if (res.upperFace != null && res.upperFace.Count > 0)
                {
                    intersectionUp = res.upperFace;
                    intersectionUp.Add(intersectionUp[0]);
                    Draw(intersectionUp);
                }
                if (res.lowerFace != null && res.lowerFace.Count > 0)
                {
                    intersectionDown = res.lowerFace;
                    intersectionDown.Add(intersectionDown[0]);
                    Draw(intersectionDown);
                }
                if (res.sideFace != null && res.sideFace.Count > 0)
                {
                    intersectionSide = res.sideFace;
                    Draw(intersectionSide);
                }
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
