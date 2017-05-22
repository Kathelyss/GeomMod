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
        public Point()
        {

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

    public class Line
    {
        public Point begin, end;
        public Line(Point begin, Point end)
        {
            this.begin = begin;
            this.end = end;
        }
        public override string ToString()
        {
            return "Line: {" + begin.coord_x.ToString() + "; " +
                               begin.coord_y.ToString() + "; " +
                               begin.coord_z.ToString() + "}; " +
                         "{" + end.coord_x.ToString() + "; " +
                               end.coord_y.ToString() + "; " +
                               end.coord_z.ToString() + "}\n";
        }
        public bool IsEqualTo(Line l)
        {
            return ((this.begin.IsEqualTo(l.begin) && this.end.IsEqualTo(l.end)) || (this.begin.IsEqualTo(l.end) && this.end.IsEqualTo(l.begin)));
        }
    }

    public class Polygon
    {
        public Line line1, line2, line3, line4;
        public Polygon(Line l1, Line l2, Line l3, Line l4)
        {
            line1 = l1;
            line2 = l2;
            line3 = l3;
            line4 = l4;
        }
    }

    public class Figure
    {
        public Point center;
        public float side, height; // side for cyl = diameter
        public List<Point> points;
        public List<Line> lines = new List<Line>();
        public List<Polygon> polygons;

        public Figure()
        {
            center = new Point(0, 0, 0);
            side = 0;
            height = 0;
        }

        public Figure(Point center, int side, int height)
        {
            this.center = center;
            this.side = side;
            this.height = height;
        }

        // создание куба (набором точек)
        public List<Point> CubeViaPoints(Point center, float side)
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

        // создание куба (набором линий - рёбер)
        public List<Line> CubeViaLines(Point center, float side)
        {
            List<Line> res = new List<Line>();
            // левое верхнее ребро 0
            res.Add(new Line(new Point(center.coord_x - side / 2, center.coord_y + side, center.coord_z + side / 2),
                             new Point(center.coord_x - side / 2, center.coord_y + side, center.coord_z - side / 2)));
            // заднее верхнее ребро 1
            res.Add(new Line(new Point(center.coord_x - side / 2, center.coord_y + side, center.coord_z - side / 2),
                             new Point(center.coord_x + side / 2, center.coord_y + side, center.coord_z - side / 2)));
            // правое верхнее ребро
            res.Add(new Line(new Point(center.coord_x + side / 2, center.coord_y + side, center.coord_z - side / 2),
                             new Point(center.coord_x + side / 2, center.coord_y + side, center.coord_z + side / 2)));
            // переднее верхнее ребро
            res.Add(new Line(new Point(center.coord_x + side / 2, center.coord_y + side, center.coord_z + side / 2),
                             new Point(center.coord_x - side / 2, center.coord_y + side, center.coord_z + side / 2)));
            // левое переднее ребро
            res.Add(new Line(new Point(center.coord_x - side / 2, center.coord_y + side, center.coord_z + side / 2),
                             new Point(center.coord_x - side / 2, center.coord_y, center.coord_z + side / 2)));
            // левое нижнее ребро
            res.Add(new Line(new Point(center.coord_x - side / 2, center.coord_y, center.coord_z + side / 2),
                             new Point(center.coord_x - side / 2, center.coord_y, center.coord_z - side / 2)));
            // левое заднее ребро
            res.Add(new Line(new Point(center.coord_x - side / 2, center.coord_y, center.coord_z - side / 2),
                             new Point(center.coord_x - side / 2, center.coord_y + side, center.coord_z - side / 2)));
            // нижнее заднее ребро
            res.Add(new Line(new Point(center.coord_x - side / 2, center.coord_y, center.coord_z - side / 2),
                             new Point(center.coord_x + side / 2, center.coord_y, center.coord_z - side / 2)));
            // правое заднее ребро
            res.Add(new Line(new Point(center.coord_x + side / 2, center.coord_y, center.coord_z - side / 2),
                             new Point(center.coord_x + side / 2, center.coord_y + side, center.coord_z - side / 2)));
            // правое нижнее ребро
            res.Add(new Line(new Point(center.coord_x + side / 2, center.coord_y, center.coord_z - side / 2),
                             new Point(center.coord_x + side / 2, center.coord_y, center.coord_z + side / 2)));
            // переднее правое ребро
            res.Add(new Line(new Point(center.coord_x + side / 2, center.coord_y, center.coord_z + side / 2),
                             new Point(center.coord_x + side / 2, center.coord_y + side, center.coord_z + side / 2)));
            // переднее ближнее ребро
            res.Add(new Line(new Point(center.coord_x + side / 2, center.coord_y, center.coord_z + side / 2),
                             new Point(center.coord_x - side / 2, center.coord_y, center.coord_z + side / 2)));
            return res;
        }

        // создание куба (набором полигонов)
        public List<Polygon> CubeViaPolygons(List<Line> lines)
        {
            List<Polygon> res = new List<Polygon>();
            //6 граней
            // верхняя
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
            return res;
        }

        //------------------------------------------------------------------------

        // создание круга (набором точек)
        public List<Point> Circle(Point center, double radius, double slices)
        {
            List<Point> res = new List<Point>();

            double theta = (2 * Math.PI) / slices;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x0 = radius, z0 = 0;

            for (int i = 0; i < slices; i++)
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

        // создание цилиндра (набором точек)
        public List<Point> CylinderViaPoints(Point center, float diameter, float height)
        {
            double slices = 50.0;

            List<Point> res = new List<Point>();
            for (int c = 0; c <= height; c++)
                res.AddRange(Circle(new Point(center.coord_x, center.coord_y + c, center.coord_z), diameter / 2, slices));
            res.Add(new Point(center.coord_x, center.coord_y + height, center.coord_z));

            double theta = (2 * Math.PI) / slices;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = diameter / 2;
            double z = 0;

            for (int i = 0; i < slices; i++)
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

        // создание цилиндра (набором линий - образующих)
        public List<Line> CylinderViaLines(Point center, float diameter, float height)
        {
            double slices = 50.0;

            List<Line> res = new List<Line>();

            double theta = (2 * Math.PI) / slices;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = diameter / 2;
            double z = 0;

            for (int i = 0; i < slices; i++)
            {
                res.Add(new Line(new Point((float)(x + center.coord_x), center.coord_y, (float)(z + center.coord_z)),// точка на окружности в основании
                                        new Point((float)(x + center.coord_x), center.coord_y + height, (float)(z + center.coord_z))));// точка на окружности на вершине
                double tx = -z;
                double ty = x;
                x += tx * tangetial_factor;
                z += ty * tangetial_factor;
                x *= radial_factor;
                z *= radial_factor;
            }

            return res;
        }

        // проверка: находится ли текущая точка дуги внутри грани куба
        private bool PointIsInsideTheCubeFace(Point cubeCenter, Point currentPoint, float cubeSide)
        {
            return ((currentPoint.coord_x <= cubeCenter.coord_x + cubeSide / 2) && 
                    (currentPoint.coord_x >= center.coord_x - cubeSide / 2) && 
                    (currentPoint.coord_z <= cubeCenter.coord_z + cubeSide / 2) && 
                    (currentPoint.coord_z >= cubeCenter.coord_z - cubeSide / 2));
        }

        public bool IntersectionIsPossible(Figure fig2)
        {
            //возможность пересечения фигур по оси
            bool OneDimIntersect(float c1, float c2, float side1, float side2)
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
                List<Point> upperFace = new List<Point>();
                List<Point> lowerFace = new List<Point>();

                float M = this.center.coord_y + this.height - fig2.center.coord_y; // расстояние от центра цилиндра до пересечения с гранью куба (при усл.: центр.Y цилиндра выше или равен центру.Y куба)
                // float K = (fig2.height - fig2.center.coord_y) - M;

                Point lastPointUp = new Point(), lastPointDown = new Point();
                // отрисовка дуги в верхней грани куба
                for (int i = 0; i < fig2.lines.Count; i++)
                    if (PointIsInsideTheCubeFace(this.center, fig2.lines[i].begin, this.side))
                    {
                        if (this.center.coord_y <= fig2.center.coord_y) // центр.Y цилиндра выше или равен центру.Y куба
                        {
                            if (this.height <= fig2.height) // высоты проверяются на случай совпадения центров, но большей высоты куба (чтобы не рисовалась верхняя грань)
                            {
                                lastPointUp = new Point(fig2.lines[i].begin.coord_x, fig2.center.coord_y + M, fig2.lines[i].begin.coord_z);
                                upperFace.Add(lastPointUp);
                                if (this.center.coord_y == fig2.center.coord_y)
                                {
                                    lastPointDown = new Point(fig2.lines[i].begin.coord_x, fig2.center.coord_y, fig2.lines[i].begin.coord_z);
                                    lowerFace.Add(lastPointDown);
                                }
                            }
                            else if (this.height > fig2.height) // а это - чтобы рисовалосо колечко, когда цилиндр входит в куб, но его центр выше
                            {
                                if (fig2.center.coord_y + M <= fig2.center.coord_y + fig2.height)
                                {
                                    lastPointUp = new Point(fig2.lines[i].begin.coord_x, fig2.center.coord_y + M, fig2.lines[i].begin.coord_z);
                                    upperFace.Add(lastPointUp);
                                }
                                if (this.center.coord_y >= fig2.center.coord_y)
                                {
                                    lastPointDown = new Point(fig2.lines[i].begin.coord_x, fig2.center.coord_y, fig2.lines[i].begin.coord_z);
                                    lowerFace.Add(lastPointDown);
                                }
                            }
                        }
                        else // центр.Y цилиндра ниже центра.Y куба
                        {
                            if (fig2.center.coord_y + fig2.height >= this.center.coord_y + this.height) // верхние грани совпадают (цилиндр вставлен в куб снизу) или цилиндр протыкает куб
                            {
                                lastPointUp = new Point(fig2.lines[i].begin.coord_x, this.center.coord_y + this.height, fig2.lines[i].begin.coord_z);
                                upperFace.Add(lastPointUp);
                            }
                                if (fig2.lines[i].end.coord_y >= this.center.coord_y)
                                {
                                    lastPointDown = new Point(fig2.lines[i].begin.coord_x, this.center.coord_y, fig2.lines[i].begin.coord_z);
                                    lowerFace.Add(lastPointDown);
                                }
                        }
                    }
                // upperFace.Add(lastPointUp);
                // upperFace.Add(upperFace[0]);

                // lowerFace.Add(lowerFace[0]);
                // lowerFace.Add(lastPointDown);
                // lowerFace.Add(upperFace[upperFace.Count - 2]);
                lowerFace.Reverse();

                upperFace.AddRange(lowerFace);
                return upperFace;
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
                center = new Point(
                    (int)form.numericUpDownCX1.Value,
                    (int)form.numericUpDownCY1.Value,
                    (int)form.numericUpDownCZ1.Value);
            else
                center = new Point(
                    (int)form.numericUpDownCX2.Value,
                    (int)form.numericUpDownCY2.Value,
                    (int)form.numericUpDownCZ2.Value);

            switch (box.SelectedIndex)
            {
                case 0: // куб
                    {
                        if (box == form.comboBoxFigure1)
                        {
                            side = (int)form.numericUpDownFig1Param1.Value;
                            height = (int)form.numericUpDownFig1Param1.Value;
                        }
                        else if (box == form.comboBoxFigure2)
                        {
                            side = (int)form.numericUpDownFig2Param1.Value;
                            height = (int)form.numericUpDownFig2Param1.Value;
                        }
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (box == form.comboBoxFigure1)
                        {
                            side = (int)form.numericUpDownFig1Param1.Value;
                            height = (int)form.numericUpDownFig1Param2.Value;
                        }
                        else if (box == form.comboBoxFigure2)
                        {
                            side = (int)form.numericUpDownFig2Param1.Value;
                            height = (int)form.numericUpDownFig2Param2.Value;
                        }
                        break;
                    }
            }
        }
    }
}
