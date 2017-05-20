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
        public override string ToString()
        {
            return "{" + coord_x.ToString() + "; " + coord_y.ToString() + "; " + coord_z.ToString() + "}\n";
        }
        public bool IsEqualTo(Point p)
        {
            return this.coord_x == p.coord_x && this.coord_y == p.coord_y && this.coord_z == p.coord_z;
        }
    }

    public class Figure
    {
        private Point center;
        private int side, height; // side for cyl = diameter
        public List<Point> points;

        public Point Center { get => center; set => center = value; }
        public int Radius { get => side; set => side = value; }
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



        public List<Point> Circle(Point center, double radius)
        {
            List<Point> res = new List<Point>();

            double theta = (2 * Math.PI) / (double)20;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x0 = radius, z0 = 0;

            for (int i = 0; i < 20; i++)
            {
                res.Add(new Point((float)(x0 + center.coord_x), center.coord_y, (float)(z0 + center.coord_z)));
                double tx = -z0;
                double ty = x0;
                x0 += tx * tangetial_factor;
                z0 += ty * tangetial_factor;
                x0 *= radial_factor;
                z0 *= radial_factor;
            }
            res.Add(new Point((float)(x0 + center.coord_x), center.coord_y, center.coord_z));

            return res;
        }

        public List<Point> Cone(Point center, int radius, int height)
        {
            List<Point> res = new List<Point>();

            double tg = height / (float)radius; // поиск прилежащего (к углу) катета прямоуг. треуг-ка через tg угла
            for (int c = 0; c <= height; c++)
                res.AddRange(Circle(new Point(center.coord_x, center.coord_y + c, center.coord_z), (radius - c / tg)));
            res.Add(new Point(center.coord_x, center.coord_y + height, center.coord_z));

            double theta = (2 * Math.PI) / (double)20.0;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = radius;
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

        public List<Point> Cylinder(Point center, float diameter, int height)
        {
            List<Point> res = new List<Point>();
            for (int c = 0; c <= height; c++)
                res.AddRange(Circle(new Point(center.coord_x, center.coord_y + c, center.coord_z), diameter / 2));
            res.Add(new Point(center.coord_x, center.coord_y + height, center.coord_z));

            double theta = (2 * Math.PI) / (double)20.0;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = diameter / 2;
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

        public List<Point> Cube(Point center, float side)
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

        public bool IntersectionIsPossible(Figure fig2)
        {
            //возможность пересечения фигур по оси Х
            bool OneDimIntersect(float c1, float c2, int side1, int side2)
            {
                return (Math.Abs(c2 - c1) <= (side1 + side2));
            }
            return (OneDimIntersect(this.center.coord_x, fig2.center.coord_x, this.side / 2, fig2.side / 2) &&
                    OneDimIntersect(this.center.coord_y + this.height / 2, fig2.center.coord_y + fig2.height / 2, this.height / 2, fig2.height / 2) &&
                    OneDimIntersect(this.center.coord_z, fig2.center.coord_z, this.side / 2, fig2.side / 2));
        }

        public List<Point> IntersectionWith(Figure fig2)
        {
            if (IntersectionIsPossible(fig2))
            {
                List<Point> res = new List<Point>();
                for (int i = 0; i < this.points.Count; i++)
                    for (int j = 0; j < fig2.points.Count; j++)
                        if (this.points[i].IsEqualTo(fig2.points[j]))
                            res.Add(this.points[i]);
                return res;
            }
            return null;
        }

        public string ListToString(List<Point> list)
        {
            string res = "";
            for (int i = 0; i < list.Count; i++)
            {
                res += list[i].ToString();
            }
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
