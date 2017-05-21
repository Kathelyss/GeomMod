﻿using System;
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

        private void Draw(Figure figure, ComboBox box)
        {
            switch (box.SelectedIndex)
            {
                case 0: // куб
                    {
                        figure.points = figure.Cube(figure.Center, figure.Side);
                        break;
                    }
                case 1: // цилиндр
                    {
                        figure.points = figure.Cylinder(figure.Center, figure.Side, figure.Height);
                        break;
                    }
               /* case 1: // конус
                    {
                        figure.points = figure.Cone(figure.Center, figure.Side, figure.Height);
                        break;
                    }*/
                default:
                    {
                        break;
                    }
            }
            if (figure.points != null)
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
            Gl.glColor3f(0.0f, 0.9f, 0.9f);     // цвет фигуры - голубой
            Draw(figure2, form.comboBoxFigure2);


            if (intersection.Count != 0)
            {
                intersection = figure1.IntersectionWith(figure2);
                Gl.glColor3f(1.0f, 1.0f, 1.0f);
                Gl.glLineWidth(2f);
                Draw(intersection);
                Gl.glLineWidth(0.5f);
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
