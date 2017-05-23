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
        public float c_x, c_y, c_z;
        public Point(float x, float y, float z)
        {
            c_x = x;
            c_y = y;
            c_z = z;
        }
        public Point()
        {

        }
        public override string ToString()
        {
            return "{" + c_x.ToString() + "; " + c_y.ToString() + "; " + c_z.ToString() + "}\n";
        }
        public bool IsEqualTo(Point p)
        {
            return this.c_x == p.c_x && this.c_y == p.c_y && this.c_z == p.c_z;
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
            return "Line: {" + begin.c_x.ToString() + "; " +
                               begin.c_y.ToString() + "; " +
                               begin.c_z.ToString() + "}; " +
                         "{" + end.c_x.ToString() + "; " +
                               end.c_y.ToString() + "; " +
                               end.c_z.ToString() + "}\n";
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
                res.Add(new Point(center.c_x - side / 2 + i, center.c_y, center.c_z));
                res.Add(new Point(center.c_x - side / 2 + i, center.c_y, center.c_z - side / 2));
                res.Add(new Point(center.c_x - side / 2 + i, center.c_y + side, center.c_z - side / 2));
                res.Add(new Point(center.c_x - side / 2 + i, center.c_y + side, center.c_z + side / 2));
                res.Add(new Point(center.c_x - side / 2 + i, center.c_y, center.c_z + side / 2));
                res.Add(new Point(center.c_x - side / 2 + i, center.c_y, center.c_z));
            }
            res.Add(new Point(center.c_x - side / 2, center.c_y, center.c_z));
            res.Add(new Point(center.c_x - side / 2, center.c_y, center.c_z + side / 2));
            //квадраты вдоль передней стенки (вертикальные)
            for (float i = 0; i <= side; i++)
            {
                res.Add(new Point(center.c_x, center.c_y, center.c_z + side / 2 - i));
                res.Add(new Point(center.c_x + side / 2, center.c_y, center.c_z + side / 2 - i));
                res.Add(new Point(center.c_x + side / 2, center.c_y + side, center.c_z + side / 2 - i));
                res.Add(new Point(center.c_x - side / 2, center.c_y + side, center.c_z + side / 2 - i));
                res.Add(new Point(center.c_x - side / 2, center.c_y, center.c_z + side / 2 - i));
                res.Add(new Point(center.c_x, center.c_y, center.c_z + side / 2 - i));
            }
            res.Add(new Point(center.c_x, center.c_y, center.c_z + side / 2));

            // квадраты горизонтальные
            for (float i = 0; i <= side; i++)
            {
                res.Add(new Point(center.c_x - side / 2, center.c_y + i, center.c_z + side / 2));
                res.Add(new Point(center.c_x + side / 2, center.c_y + i, center.c_z + side / 2));
                res.Add(new Point(center.c_x + side / 2, center.c_y + i, center.c_z - side / 2));
                res.Add(new Point(center.c_x - side / 2, center.c_y + i, center.c_z - side / 2));
                res.Add(new Point(center.c_x - side / 2, center.c_y + i, center.c_z + side / 2));
            }
            res.Add(new Point(center.c_x - side / 2, center.c_y, center.c_z + side / 2));

            return res;
        }

        // создание куба (набором линий - рёбер)
        public List<Line> CubeViaLines(Point center, float side)
        {
            List<Line> res = new List<Line>();
            // левое верхнее ребро 0
            res.Add(new Line(new Point(center.c_x - side / 2, center.c_y + side, center.c_z + side / 2),
                             new Point(center.c_x - side / 2, center.c_y + side, center.c_z - side / 2)));
            // заднее верхнее ребро 1
            res.Add(new Line(new Point(center.c_x - side / 2, center.c_y + side, center.c_z - side / 2),
                             new Point(center.c_x + side / 2, center.c_y + side, center.c_z - side / 2)));
            // правое верхнее ребро
            res.Add(new Line(new Point(center.c_x + side / 2, center.c_y + side, center.c_z - side / 2),
                             new Point(center.c_x + side / 2, center.c_y + side, center.c_z + side / 2)));
            // переднее верхнее ребро
            res.Add(new Line(new Point(center.c_x + side / 2, center.c_y + side, center.c_z + side / 2),
                             new Point(center.c_x - side / 2, center.c_y + side, center.c_z + side / 2)));
            // левое переднее ребро
            res.Add(new Line(new Point(center.c_x - side / 2, center.c_y + side, center.c_z + side / 2),
                             new Point(center.c_x - side / 2, center.c_y, center.c_z + side / 2)));
            // левое нижнее ребро
            res.Add(new Line(new Point(center.c_x - side / 2, center.c_y, center.c_z + side / 2),
                             new Point(center.c_x - side / 2, center.c_y, center.c_z - side / 2)));
            // левое заднее ребро
            res.Add(new Line(new Point(center.c_x - side / 2, center.c_y, center.c_z - side / 2),
                             new Point(center.c_x - side / 2, center.c_y + side, center.c_z - side / 2)));
            // нижнее заднее ребро
            res.Add(new Line(new Point(center.c_x - side / 2, center.c_y, center.c_z - side / 2),
                             new Point(center.c_x + side / 2, center.c_y, center.c_z - side / 2)));
            // правое заднее ребро
            res.Add(new Line(new Point(center.c_x + side / 2, center.c_y, center.c_z - side / 2),
                             new Point(center.c_x + side / 2, center.c_y + side, center.c_z - side / 2)));
            // правое нижнее ребро
            res.Add(new Line(new Point(center.c_x + side / 2, center.c_y, center.c_z - side / 2),
                             new Point(center.c_x + side / 2, center.c_y, center.c_z + side / 2)));
            // переднее правое ребро
            res.Add(new Line(new Point(center.c_x + side / 2, center.c_y, center.c_z + side / 2),
                             new Point(center.c_x + side / 2, center.c_y + side, center.c_z + side / 2)));
            // переднее ближнее ребро
            res.Add(new Line(new Point(center.c_x + side / 2, center.c_y, center.c_z + side / 2),
                             new Point(center.c_x - side / 2, center.c_y, center.c_z + side / 2)));
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
                res.Add(new Point((float)(x0 + center.c_x), center.c_y, (float)(z0 + center.c_z)));
                double tx = -z0;
                double ty = x0;
                x0 += tx * tangetial_factor;
                z0 += ty * tangetial_factor;
                x0 *= radial_factor;
                z0 *= radial_factor;
            }
            res.Add(new Point((float)(x0 + center.c_x), center.c_y, center.c_z));

            return res;
        }

        // создание цилиндра (набором точек)
        public List<Point> CylinderViaPoints(Point center, float diameter, float height)
        {
            double slices = 50.0;

            List<Point> res = new List<Point>();
            for (int c = 0; c <= height; c++)
                res.AddRange(Circle(new Point(center.c_x, center.c_y + c, center.c_z), diameter / 2, slices));
            res.Add(new Point(center.c_x, center.c_y + height, center.c_z));

            double theta = (2 * Math.PI) / slices;
            double tangetial_factor = Math.Tan(theta);
            double radial_factor = Math.Cos(theta);
            double x = diameter / 2;
            double z = 0;

            for (int i = 0; i < slices; i++)
            {
                res.Add(new Point(center.c_x, center.c_y, center.c_z)); // центр в основании
                res.Add(new Point((float)(x + center.c_x), center.c_y, (float)(z + center.c_z))); // точка на окружности в основании
                res.Add(new Point((float)(x + center.c_x), center.c_y + height, (float)(z + center.c_z)));// точка на окружности на вершине
                res.Add(new Point(center.c_x, center.c_y + height, center.c_z)); // центр на вершине
                res.Add(new Point(center.c_x, center.c_y, center.c_z)); // центр в основании

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
                res.Add(new Line(new Point((float)(x + center.c_x), center.c_y, (float)(z + center.c_z)),// точка на окружности в основании
                                        new Point((float)(x + center.c_x), center.c_y + height, (float)(z + center.c_z))));// точка на окружности на вершине
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
        bool PointIsInsideTheHorizontalCubeFace(Point cubeCenter, Point currentPoint, float cubeSide)
        {
            return ((currentPoint.c_x <= cubeCenter.c_x + cubeSide / 2) &&
                    (currentPoint.c_x >= center.c_x - cubeSide / 2) &&
                    (currentPoint.c_z <= cubeCenter.c_z + cubeSide / 2) &&
                    (currentPoint.c_z >= cubeCenter.c_z - cubeSide / 2));
        }

        public bool IntersectionIsPossible(Figure fig2)
        {
            //возможность пересечения фигур по оси
            bool OneDimIntersect(float c1, float c2, float side1, float side2)
            {
                return (Math.Abs(c2 - c1) <= (side1 + side2));
            }
            return (OneDimIntersect(this.center.c_x, fig2.center.c_x, this.side / 2, fig2.side / 2) &&
                    OneDimIntersect(this.center.c_y + this.height / 2, fig2.center.c_y + fig2.height / 2, this.height / 2, fig2.height / 2) &&
                    OneDimIntersect(this.center.c_z, fig2.center.c_z, this.side / 2, fig2.side / 2));
        }

        bool PointBelongsToVerticalCubeFace(Point p, float x, float y, float z, int mainCoord)
        {
            if (mainCoord == 1 && p.c_x == x)
                return true;
            if (mainCoord == 2 && p.c_y == y)
                return true;
            if (mainCoord == 3 && p.c_z == z)
                return true;

            return false;
        }

        bool HorizontalCubeFaceIsInsideTheCyl(Point cylCenter, float r)
        {
            if (this.side < r * 2)
            {
                Point leftDown = new Point(this.center.c_x - this.side / 2, this.center.c_y, this.center.c_z + this.side / 2);
                Point leftUp = new Point(this.center.c_x - this.side / 2, this.center.c_y, this.center.c_z - this.side / 2);
                Point rightUp = new Point(this.center.c_x + this.side / 2, this.center.c_y, this.center.c_z - this.side / 2);
                Point rightDown = new Point(this.center.c_x + this.side / 2, this.center.c_y, this.center.c_z + this.side / 2);
                if (leftDown.c_x >= cylCenter.c_x - r && leftDown.c_z <= cylCenter.c_z + r && leftUp.c_z >= cylCenter.c_z - r &&
                    rightDown.c_x <= cylCenter.c_x + r && rightDown.c_z <= cylCenter.c_z + r && rightUp.c_z >= cylCenter.c_z - r)
                    return true;
            }
            return false;
        }

        // обработка взаимодействия цилиндра с меньшим кубом
        List<Point> CubeProcessing(Figure cylinder)
        {
            List<Point> upperFace = new List<Point>();
            List<Point> lowerFace = new List<Point>();

            int countOfFaces = 0;
            float height1 = 0.0f, height2 = 0.0f;

            // куб стоит на цилиндре
            if (this.center.c_y == cylinder.center.c_y + cylinder.height)
            {
                countOfFaces = 1;
                height1 = this.center.c_y;
            }
            // цилиндр стоит на кубе
            if (this.center.c_y + this.height == cylinder.center.c_y)
            {
                countOfFaces = 1;
                height1 = cylinder.center.c_y;
            }
            // куб входит в цилиндр сверху
            if (this.center.c_y > cylinder.center.c_y && this.center.c_y + this.height > cylinder.center.c_y + cylinder.height)
            {
                countOfFaces = 1;
                height1 = cylinder.center.c_y + cylinder.height;
            }
            // фигуры касаются верхними гранями
            if (this.center.c_y + this.height == cylinder.center.c_y + cylinder.height)
            {
                // куб касается верхней и нижней граней цилиндра
                if (this.center.c_y == cylinder.center.c_y)
                {
                    countOfFaces = 2;
                    height1 = this.center.c_y + this.height;
                    height2 = this.center.c_y;
                }
                // куб касается только верхней грани цилиндра изнутри
                if (this.center.c_y > cylinder.center.c_y)
                {
                    countOfFaces = 1;
                    height1 = this.center.c_y + this.height;
                }
                
                // куб проходит сквозь нижнюю грань и касается верхней грани цилиндра
                if (this.center.c_y < cylinder.center.c_y)
                {
                    countOfFaces = 2;
                    height1 = this.center.c_y + this.height;
                    height2 = cylinder.center.c_y;
                }
            }
            // фигуры касаются нижними гранями
            if (this.center.c_y == cylinder.center.c_y)
            {
                // куб касается только нижней грани изнутри
                if (this.center.c_y + this.height < cylinder.center.c_y + cylinder.height)
                {
                    countOfFaces = 1;
                    height1 = this.center.c_y;
                }
                // куб стоит на основании цилиндра и выходит из него через верхнюю грань
                if (this.height > cylinder.height)
                {
                    countOfFaces = 2;
                    height1 = cylinder.center.c_y + cylinder.height;
                    height2 = this.center.c_y;
                }
            }
            // куб входит в цилиндр снизу
            if (this.center.c_y < cylinder.center.c_y)
            {
                // куб входит в цилиндр снизу
                if (this.center.c_y + this.height < cylinder.center.c_y + cylinder.height)
                {
                    countOfFaces = 1;
                    height1 = cylinder.center.c_y;
                }
                // куб "протыкает" цилиндр
                if (this.center.c_y + this.height > cylinder.center.c_y + cylinder.height)
                {
                    countOfFaces = 2;
                    height1 = cylinder.center.c_y + cylinder.height;
                    height2 = cylinder.center.c_y;
                }
            }

            // установка высот для точек
            if (countOfFaces == 1)
            {
                upperFace.Add(new Point(this.center.c_x - this.side / 2, height1, this.center.c_z + this.side / 2));
                upperFace.Add(new Point(this.center.c_x - this.side / 2, height1, this.center.c_z - this.side / 2));
                upperFace.Add(new Point(this.center.c_x + this.side / 2, height1, this.center.c_z - this.side / 2));
                upperFace.Add(new Point(this.center.c_x + this.side / 2, height1, this.center.c_z + this.side / 2));
                upperFace.Add(new Point(this.center.c_x - this.side / 2, height1, this.center.c_z + this.side / 2));
            }
            else if (countOfFaces == 2)
            {
                upperFace.Add(new Point(this.center.c_x - this.side / 2, height1, this.center.c_z + this.side / 2));
                upperFace.Add(new Point(this.center.c_x - this.side / 2, height1, this.center.c_z - this.side / 2));
                upperFace.Add(new Point(this.center.c_x + this.side / 2, height1, this.center.c_z - this.side / 2));
                upperFace.Add(new Point(this.center.c_x + this.side / 2, height1, this.center.c_z + this.side / 2));
                //
                upperFace.Add(new Point(this.center.c_x - this.side / 2, height1, this.center.c_z + this.side / 2));
                lowerFace.Add(new Point(this.center.c_x - this.side / 2, height2, this.center.c_z + this.side / 2));
                lowerFace.Add(new Point(this.center.c_x - this.side / 2, height2, this.center.c_z - this.side / 2));
                lowerFace.Add(new Point(this.center.c_x + this.side / 2, height2, this.center.c_z - this.side / 2));
                lowerFace.Add(new Point(this.center.c_x + this.side / 2, height2, this.center.c_z + this.side / 2));
                //
                lowerFace.Add(new Point(this.center.c_x - this.side / 2, height2, this.center.c_z + this.side / 2));
            }

           // lowerFace.Reverse();
            upperFace.AddRange(lowerFace);

            return upperFace;
        }


        public List<Point> CreateIntersection(Figure cylinder)
        {
            if (IntersectionIsPossible(cylinder))
            {
                List<Point> upperFace = new List<Point>();
                List<Point> lowerFace = new List<Point>();
                List<Point> sideFace = new List<Point>();

                float M = this.center.c_y + this.height - cylinder.center.c_y; // расстояние от центра цилиндра до пересечения с гранью куба (при усл.: центр.Y цилиндра выше или равен центру.Y куба)

                // отрисовка дуги в верхней грани куба
                for (int i = 0; i < cylinder.lines.Count; i++)
                {
                    // обработка взаимодействия цилиндра с меньшим кубом
                    if (this.HorizontalCubeFaceIsInsideTheCyl(cylinder.center, cylinder.side / 2))
                        upperFace = this.CubeProcessing(cylinder);
                    else if (PointIsInsideTheHorizontalCubeFace(this.center, cylinder.lines[i].begin, this.side))
                    {
                        if (this.center.c_y <= cylinder.center.c_y) // центр.Y цилиндра выше или равен центру.Y куба
                        {
                            if (this.height <= cylinder.height) // высоты проверяются на случай совпадения центров, но большей высоты куба (чтобы не рисовалась верхняя грань)
                            {
                                upperFace.Add(new Point(cylinder.lines[i].begin.c_x, cylinder.center.c_y + M, cylinder.lines[i].begin.c_z));
                                if (this.center.c_y == cylinder.center.c_y)
                                    lowerFace.Add(new Point(cylinder.lines[i].begin.c_x, cylinder.center.c_y, cylinder.lines[i].begin.c_z));
                            }
                            else if (this.height > cylinder.height) // а это - чтобы рисовалосо колечко, когда цилиндр входит в куб, но его центр выше
                            {
                                if (cylinder.center.c_y + M <= cylinder.center.c_y + cylinder.height)
                                    upperFace.Add(new Point(cylinder.lines[i].begin.c_x, cylinder.center.c_y + M, cylinder.lines[i].begin.c_z));
                                if (this.center.c_y >= cylinder.center.c_y)
                                    lowerFace.Add(new Point(cylinder.lines[i].begin.c_x, cylinder.center.c_y, cylinder.lines[i].begin.c_z));
                            }
                        }
                        else // центр.Y цилиндра ниже центра.Y куба
                        {
                            if (cylinder.center.c_y + cylinder.height >= this.center.c_y + this.height) // верхние грани совпадают (цилиндр вставлен в куб снизу) или цилиндр протыкает куб
                                upperFace.Add(new Point(cylinder.lines[i].begin.c_x, this.center.c_y + this.height, cylinder.lines[i].begin.c_z));
                            if (cylinder.lines[i].end.c_y >= this.center.c_y)
                                lowerFace.Add(new Point(cylinder.lines[i].begin.c_x, this.center.c_y, cylinder.lines[i].begin.c_z));
                        }

                        /*
                        // проверка на касание цилиндром грани куба
                        if (this.height < cylinder.height)
                        {
                            // координата z - this.side / 2
                            if (this.center.c_y == cylinder.center.c_y)
                            {

                            }
                            // координата z + this.side / 2
                            // координата x + this.side / 2
                            // координата x - this.side / 2
                        }
                        else if (this.height > cylinder.height)
                        {
                            if (this.center.c_y == cylinder.center.c_y)
                            {

                            }
                        }
                        else // this.height > cylinder.height
                        {
                            if (this.center.c_y == cylinder.center.c_y)
                            {
                                sideFace.Add(new Point(cylinder.lines[i].begin.c_x, this.center.c_y + this.height, cylinder.lines[i].begin.c_z));
                                sideFace.Add(new Point(cylinder.lines[i].begin.c_x, this.center.c_y, cylinder.lines[i].begin.c_z));
                                sideFace.Add(new Point(cylinder.lines[i].begin.c_x, this.center.c_y + this.height, cylinder.lines[i].begin.c_z)); // вернуться в верхнюю грань
                            }
                        }*/
                    }
                }

                lowerFace.Reverse();
                upperFace.AddRange(sideFace);
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
