using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomMod
{
    public class Point
    {
        public float coord_x, coord_y, coord_z;
        public Point(float x, float y, float z)
        {
            coord_x = x;
            coord_y = y;
            coord_z = z;
        }
    }

    public class Figure
    {
        private Point center;
        private int radius, height; // radius for cube = side

        public Point Center { get => center; set => center = value; }
        public int Radius { get => radius; set => radius = value; }
        public int Height { get => height; set => height = value; }

        public Figure()
        {
            Center = new Point(0, 0, 0);
            Radius = 0;
            Height = 0;
        }
        public Figure(Point center, int param) // куб, сфера
        {
            Center = center;
            Radius = param;
        }

        public Figure(Point center, int radius, int height) // конус, цилиндр
        {
            Center = center;
            Radius = radius;
            Height = height;
        }

        public bool IntersectionIsPossible(Figure fig2)
        {
            float deltaX = this.center.coord_x + this.Radius + fig2.Radius;
            float deltaZ = this.center.coord_z + this.Radius + fig2.Radius;
            float deltaY = this.center.coord_y + this.Height + fig2.Height;
            if (this.center.coord_x == fig2.center.coord_x || this.center.coord_y == fig2.center.coord_y || this.center.coord_z == fig2.center.coord_z)
                return true;
            else
            {
                if (fig2.center.coord_x - deltaX == this.center.coord_x || fig2.center.coord_x - deltaX == -this.center.coord_x)
                    if (fig2.center.coord_z - deltaZ == this.center.coord_z || fig2.center.coord_z - deltaZ == -this.center.coord_z)
                        if (fig2.center.coord_y - deltaY == this.center.coord_y || fig2.center.coord_y - deltaY == -this.center.coord_y)
                            return true;
            }
            return false;
        }

        public List<Point> Cone(Point center, int radius, int height)
        {
            List<Point> res = new List<Point>();

            double theta0 = (2 * Math.PI) / (double)20;
            double tangetial_factor0 = Math.Tan(theta0);
            double radial_factor0 = Math.Cos(theta0);
            double x0 = radius; //we start at angle = 0 
            double z0 = 0;

            for (int i = 0; i < 20; i++)
            {
                res.Add(new Point((float)(x0 + center.coord_x), center.coord_y, (float)(z0 + center.coord_z)));
                double tx = -z0;
                double ty = x0;
                x0 += tx * tangetial_factor0;
                z0 += ty * tangetial_factor0;
                x0 *= radial_factor0;
                z0 *= radial_factor0;
            }
            res.Add(new Point((float)(radius + center.coord_x), center.coord_y, center.coord_z));

            double theta = (2 * Math.PI) / (double)20.0;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = radius; //we start at angle = 0 
            double z = 0;

            for (int i = 0; i < 20.0; i++)
            {
                res.Add(new Point(center.coord_x, center.coord_y, center.coord_z)); // центр в основании
                res.Add(new Point((float)(x + center.coord_x), center.coord_y, (float)(z + center.coord_z))); // точка на окружности в основании
                res.Add(new Point(center.coord_x, center.coord_y + height, center.coord_z)); // вершина (центр на вершине конуса)
                res.Add(new Point(center.coord_x, center.coord_y, center.coord_z)); // центр в основании

                double tx = -z;
                double ty = x;
                x += tx * tangetial_factor;
                z += ty * tangetial_factor;
                x *= radial_factor;
                z *= radial_factor;
            }

            return res;
        }

        public List<Point> Cylinder(Point center, int radius, int height)
        {
            List<Point> res = new List<Point>();
            double theta0 = (2 * Math.PI) / (double)20;
            double tangetial_factor0 = Math.Tan(theta0);
            double radial_factor0 = Math.Cos(theta0);
            double x0 = radius; //we start at angle = 0 
            double z0 = 0;

            for (int c = 0; c <= height; c++)
            {
                for (int i = 0; i < 20; i++)
                {
                    res.Add(new Point((float)(x0 + center.coord_x), center.coord_y + c, (float)(z0 + center.coord_z)));
                    double tx = -z0;
                    double ty = x0;
                    x0 += tx * tangetial_factor0;
                    z0 += ty * tangetial_factor0;
                    x0 *= radial_factor0;
                    z0 *= radial_factor0;
                }
                res.Add(new Point((float)(radius + center.coord_x), center.coord_y + c, center.coord_z));
            }
            res.Add(new Point(center.coord_x, center.coord_y + height, center.coord_z));

            double theta = (2 * Math.PI) / (double)20.0;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = radius; //we start at angle = 0 
            double z = 0;

            for (int i = 0; i < 20.0; i++)
            {
                res.Add(new Point(center.coord_x, center.coord_y, center.coord_z)); // центр в основании
                res.Add(new Point((float)(x + center.coord_x), center.coord_y, (float)(z + center.coord_z))); // точка на окружности в основании
                res.Add(new Point((float)(x + center.coord_x), center.coord_y + height, (float)(z + center.coord_z)));// точка на окружности на вершине
                res.Add(new Point(center.coord_x, center.coord_y + height, center.coord_z)); // центр на вершине
                res.Add(new Point(center.coord_x, center.coord_y, center.coord_z)); // центр в основании

                double tx = -z;
                double ty = x;
                x += tx * tangetial_factor;
                z += ty * tangetial_factor;
                x *= radial_factor;
                z *= radial_factor;
            }

            return res;
        }

        public List<Point> Cube(Point center, int side)
        {
            List<Point> res = new List<Point>();

            // квадраты вдоль левой стенки (вертикальные)
            for (float i = 0; i <= side; i++)
            {
                res.Add(new Point(center.coord_x - side / 2 + i, center.coord_y, center.coord_z));
                res.Add(new Point(center.coord_x - side / 2 + i, center.coord_y, center.coord_z - side / 2));
                res.Add(new Point(center.coord_x - side / 2 + i, center.coord_y + side, center.coord_z - side / 2));
                res.Add(new Point(center.coord_x - side / 2 + i, center.coord_y + side, center.coord_z + side / 2));
                res.Add(new Point(center.coord_x - side / 2 + i, center.coord_y, center.coord_z + side / 2));
                res.Add(new Point(center.coord_x - side / 2 + i, center.coord_y, center.coord_z));
            }
            res.Add(new Point(center.coord_x - side / 2, center.coord_y, center.coord_z));
            res.Add(new Point(center.coord_x - side / 2, center.coord_y, center.coord_z + side / 2));
            //квадраты вдоль передней стенки (вертикальные)
            for (float i = 0; i <= side; i++)
            {
                res.Add(new Point(center.coord_x, center.coord_y, center.coord_z + side / 2 - i));
                res.Add(new Point(center.coord_x + side / 2, center.coord_y, center.coord_z + side / 2 - i));
                res.Add(new Point(center.coord_x + side / 2, center.coord_y + side, center.coord_z + side / 2 - i));
                res.Add(new Point(center.coord_x - side / 2, center.coord_y + side, center.coord_z + side / 2 - i));
                res.Add(new Point(center.coord_x - side / 2, center.coord_y, center.coord_z + side / 2 - i));
                res.Add(new Point(center.coord_x, center.coord_y, center.coord_z + side / 2 - i));
            }
            res.Add(new Point(center.coord_x, center.coord_y, center.coord_z + side / 2));

            // квадраты горизонтальные
            for (float i = 0; i <= side; i++)
            {
                res.Add(new Point(center.coord_x - side / 2, center.coord_y + i, center.coord_z + side / 2));
                res.Add(new Point(center.coord_x + side / 2, center.coord_y + i, center.coord_z + side / 2));
                res.Add(new Point(center.coord_x + side / 2, center.coord_y + i, center.coord_z - side / 2));
                res.Add(new Point(center.coord_x - side / 2, center.coord_y + i, center.coord_z - side / 2));
                res.Add(new Point(center.coord_x - side / 2, center.coord_y + i, center.coord_z + side / 2));
            }
            res.Add(new Point(center.coord_x - side / 2, center.coord_y, center.coord_z + side / 2));

            return res;
        }

        // установка параметров фигуры из полей формы
        public void SetParams(MainForm form, ComboBox box, int figureNumber)
        {
            if (figureNumber == 1)
                Center = new Point(
                    (int)form.numericUpDownCX1.Value,
                    (int)form.numericUpDownCY1.Value,
                    (int)form.numericUpDownCZ1.Value);
            else
                Center = new Point(
                    (int)form.numericUpDownCX2.Value,
                    (int)form.numericUpDownCY2.Value,
                    (int)form.numericUpDownCZ2.Value);

            switch (box.SelectedIndex)
            {
                case 0: // куб
                    {
                        if (box == form.comboBoxFigure1)
                        {
                            Radius = (int)form.numericUpDownFig1Param1.Value;
                            Height = (int)form.numericUpDownFig1Param1.Value;
                        }
                        else if (box == form.comboBoxFigure2)
                        {
                            Radius = (int)form.numericUpDownFig2Param1.Value;
                            Height = (int)form.numericUpDownFig2Param1.Value;
                        }
                        break;
                    }
                case 1:
                case 2: // конус, цилиндр
                    {
                        if (box == form.comboBoxFigure1)
                        {
                            Radius = (int)form.numericUpDownFig1Param1.Value;
                            Height = (int)form.numericUpDownFig1Param2.Value;
                        }
                        else if (box == form.comboBoxFigure2)
                        {
                            Radius = (int)form.numericUpDownFig2Param1.Value;
                            Height = (int)form.numericUpDownFig2Param2.Value;
                        }
                        break;
                    }
            }
        }
    }
}
