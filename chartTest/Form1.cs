using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;


namespace chartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            StreamReader objReader = new StreamReader("c:\\Random.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();

            int i = 0;
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    arrText.Add(sLine);
                    i = Int32.Parse(sLine);
                }
                chart1.Series[0].Points.AddXY(0, i);
            }
            objReader.Close();

        }
        
        private void chart1_mousewheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine(e.Delta);
            if(e.Delta > 0)
            {
                //zoom
                chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;

                int posXStart = (int)(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 2);
                int posXFinish = (int)(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.Y) + (xMax - xMin) / 2);

                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
            }
            else
            {
                //chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;

                int posXStart = (int)(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) * 2);
                int posXFinish = (int)(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.Y) + (xMax - xMin) * 2);

                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
            }
        }
    }
}
