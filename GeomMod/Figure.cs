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

        public List<Point> ConePoints()
        {
            List<Point> res = new List<Point>();

            return res;
        }

        public List<Point> CylinderPoints()
        {
            List<Point> res = new List<Point>();

            return res;
        }

        public List<Point> CubePoints()
        {
            List<Point> res = new List<Point>();

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
