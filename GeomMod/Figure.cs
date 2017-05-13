using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeomMod
{
    public class CenterPoint
    {
        public int coord_x, coord_y, coord_z;
        public CenterPoint(int x, int y, int z)
        {
            coord_x = x;
            coord_y = y;
            coord_z = z;
        }
    }

    public class Figure
    {
        MainForm Form = new MainForm();

        // здесь 1 - первая фигура, 2 - вторая фигура
        public int cubeSide1, sphereRadius1, coneBaseRadius1, cylinderBaseRadius1, coneHeight1, cylinderHeight1;
        public int cubeSide2, sphereRadius2, coneBaseRadius2, cylinderBaseRadius2, coneHeight2, cylinderHeight2;
        public CenterPoint center1, center2;

        public Figure()
        {

        }

        // получение параметров фигур из полей формы
        public void GetParams()
        {
            //1я фигура
            //куб и сфера
            cubeSide1 = (int)numericUpDownFig1Param1.Value;
            sphereRadius1 = (int)numericUpDownFig1Param1.Value;
            //конус
            coneBaseRadius1 = (int)numericUpDownFig1Param1.Value;
            coneHeight1 = (int)numericUpDownFig1Param2.Value;
            //цилиндр
            cylinderBaseRadius1 = (int)numericUpDownFig1Param1.Value;
            cylinderHeight1 = (int)numericUpDownFig1Param2.Value;

            center1 = new CenterPoint((int)numericUpDownCX1.Value, (int)numericUpDownCY1.Value, (int)numericUpDownCZ1.Value);

            //2я фигура
            //куб и сфера
            cubeSide2 = (int)numericUpDownFig2Param1.Value;
            sphereRadius2 = (int)numericUpDownFig2Param1.Value;
            //конус
            coneBaseRadius2 = (int)numericUpDownFig2Param1.Value;
            coneHeight2 = (int)numericUpDownFig2Param2.Value;
            //цилиндр
            cylinderBaseRadius2 = (int)numericUpDownFig2Param1.Value;
            cylinderHeight2 = (int)numericUpDownFig2Param2.Value;

            center2 = new CenterPoint((int)numericUpDownCX2.Value, (int)numericUpDownCY2.Value, (int)numericUpDownCZ2.Value);
        }

        // установка параметров фигур из полей формы
        public void SetParams(ComboBox box)
        {
            center1 = new CenterPoint((int)numericUpDownCX1.Value, (int)numericUpDownCY1.Value, (int)numericUpDownCZ1.Value);
            center2 = new CenterPoint((int)numericUpDownCX2.Value, (int)numericUpDownCY2.Value, (int)numericUpDownCZ2.Value);

            switch (box.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                case 0: // сфера
                    {
                        if (box == Form.comboBoxFigure1)
                            sphereRadius1 = (int)numericUpDownFig1Param1.Value;
                        else if (box == comboBoxFigure2)
                            sphereRadius2 = (int)numericUpDownFig2Param1.Value;
                        break;
                    }
                case 1: // цилиндр
                    {
                        if (box == comboBoxFigure1)
                        {
                            cylinderBaseRadius1 = (int)numericUpDownFig1Param1.Value;
                            cylinderHeight1 = (int)numericUpDownFig1Param2.Value;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            cylinderBaseRadius2 = (int)numericUpDownFig2Param1.Value;
                            cylinderHeight2 = (int)numericUpDownFig2Param2.Value;
                        }
                        break;
                    }
                case 2: // куб
                    {
                        if (box == comboBoxFigure1)
                            cubeSide1 = (int)numericUpDownFig1Param1.Value;
                        else if (box == comboBoxFigure2)
                            cubeSide2 = (int)numericUpDownFig2Param1.Value;
                        break;
                    }
                case 3: // конус
                    {
                        if (box == comboBoxFigure1)
                        {
                            coneBaseRadius1 = (int)numericUpDownFig1Param1.Value;
                            coneHeight1 = (int)numericUpDownFig1Param2.Value;
                        }
                        else if (box == comboBoxFigure2)
                        {
                            coneBaseRadius2 = (int)numericUpDownFig2Param1.Value;
                            coneHeight2 = (int)numericUpDownFig2Param2.Value;
                        }
                        break;
                    }
            }
        }
    }
}
