using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomMod
{
    public class CenterPoint
    {
        public float coord_x, coord_y, coord_z;
        public CenterPoint(float x, float y, float z)
        {
            coord_x = x;
            coord_y = y;
            coord_z = z;
        }
    }

    public class Figure
    {
        private CenterPoint center;
        private int radius, height; // radius for cube = side

        public CenterPoint Center { get => center; set => center = value; }
        public int Radius { get => radius; set => radius = value; }
        public int Height { get => height; set => height = value; }

        public Figure()
        {
            Center = new CenterPoint(0, 0, 0);
            Radius = 0;
            Height = 0;
        }
        public Figure(CenterPoint center, int param) // куб, сфера
        {
            Center = center;
            Radius = param;
        }

        public Figure(CenterPoint center, int radius, int height) // конус, цилиндр
        {
            Center = center;
            Radius = radius;
            Height = height;
        }


        // установка параметров фигуры из полей формы
        public void SetParams(MainForm form, ComboBox box, int figureNumber)
        {
            if (figureNumber == 1)
                Center = new CenterPoint(
                    (int)form.numericUpDownCX1.Value, 
                    (int)form.numericUpDownCY1.Value, 
                    (int)form.numericUpDownCZ1.Value);
            else
                Center = new CenterPoint(
                    (int)form.numericUpDownCX2.Value, 
                    (int)form.numericUpDownCY2.Value,  
                    (int)form.numericUpDownCZ2.Value);

            switch (box.SelectedIndex)
            {
                case 0:
                case 2: // сфера, куб
                    {
                        if (box == form.comboBoxFigure1)
                            Radius = (int)form.numericUpDownFig1Param1.Value;
                        else if (box == form.comboBoxFigure2)
                            Radius = (int)form.numericUpDownFig2Param1.Value;
                        break;
                    }
                case 1:
                case 3: // конус, цилиндр
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
