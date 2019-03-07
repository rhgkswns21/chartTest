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
using System.Diagnostics;


namespace chartTest
{
    public partial class Form1 : Form
    {

        System.Windows.Forms.Timer timer01 = new System.Windows.Forms.Timer();
        int tick_count01 = 0;

        private static List<string> tempfilePath = null;
        List<string> x_data = new List<string>();
        List<string> y_data = new List<string>();
        List<string> time_data = new List<string>();

        public Form1()
        {
            InitializeComponent();

            timer01.Interval = 100;
            timer01.Tick += new EventHandler(Timer01_tick);
            
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

        private void Start_Click(object sender, EventArgs e)
        {
            //timer01.Start();
            tick_count01 = 0;
            Random rnd1 = new Random();
            Random rnd2 = new Random(rnd1.Next());
            foreach (string time in time_data)
            {
                chart1.Series[0].Points.AddXY(time_data[tick_count01], x_data[tick_count01]);
                chart1.Series[1].Points.AddXY(time_data[tick_count01], y_data[tick_count01]);
                tick_count01++;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            //timer01.Stop();

            List<string> passdata = new List<string>();
            int count_check = 0;
            foreach (TreeNode n in treeView1.Nodes)
            {
                if (n.Checked)
                {
                    Debug.WriteLine(n.Text);
                    passdata.AddRange(GetFileContent(tempfilePath[count_check]));
                    Debug.WriteLine("stopBT data " + passdata[0]);
                }
                count_check++;
            }
        }

        private void Timer01_tick(object sender, EventArgs e)
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random(rnd1.Next());
            chart1.Series[0].Points.AddXY(tick_count01, rnd1.Next(50));
            chart1.Series[1].Points.AddXY(tick_count01++, rnd2.Next(50));
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();

            chart1.Series[0].IsValueShownAsLabel = !chart1.Series[0].IsValueShownAsLabel;
            chart1.Series[1].IsValueShownAsLabel = !chart1.Series[1].IsValueShownAsLabel;
        }

        public List<string> GetFileContent(string file_name)
        {
            x_data.Clear();
            
            foreach (string line in File.ReadLines(file_name, Encoding.UTF8))
            {
                //x_data.Add(line.Substring(10, 7));
                string[] spstring = line.Split(',');
                time_data.Add(spstring[0]);
                x_data.Add(spstring[1]);
                y_data.Add(spstring[2]);
                Debug.WriteLine("Line data  " + line);
                Debug.WriteLine("time data  " + spstring[0]);
                Debug.WriteLine("x data     " + spstring[1]);
                Debug.WriteLine("y data     " + spstring[2]);
            }
            
            return x_data;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            string folder_path = folderBrowserDialog1.SelectedPath;
            Debug.WriteLine("folder_path    " + folder_path);

            List<string> file_list = new List<string>();
                       
            tempfilePath = new List<string>();

            if( dialogResult == DialogResult.OK)
            {
                DirectoryInfo Info = new DirectoryInfo(folder_path);

                if (Info.Exists)
                {
                    DirectoryInfo[] CInfo = Info.GetDirectories("*", SearchOption.AllDirectories);

                    foreach (DirectoryInfo info in CInfo)
                    {
                        Console.WriteLine(info.FullName);

                        TreeNode treeNode01 = new TreeNode();
                        treeNode01.Name = info.Name.ToString();
                        treeNode01.Text = info.Name.ToString();
                        this.treeView1.Nodes.Add(treeNode01);

                        foreach (string file in Directory.GetFiles(info.FullName, "*.csv", SearchOption.AllDirectories))
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            if (fileInfo.Extension == ".csv")
                            {
                                file_list.Add(fileInfo.Name.ToString());
                                tempfilePath.Add(file);

                                Debug.WriteLine(fileInfo.Extension);
                                TreeNode treeNode02 = new TreeNode();
                                treeNode02.Name = fileInfo.Name.ToString();
                                treeNode02.Text = fileInfo.Name.ToString();
                                treeNode01.Nodes.Add(treeNode02);
                            }
                            Debug.WriteLine("file_list  " + file_list);
                            Debug.WriteLine("fileInfo   " + fileInfo.Name.ToString());
                        }
                    }
                }

                //foreach (string file in Directory.GetFiles(folder_path, "*.csv", SearchOption.AllDirectories))
                //{
                //    FileInfo fileInfo = new FileInfo(file);
                //    if (fileInfo.Extension == ".csv")
                //    {
                //        file_list.Add(fileInfo.Name.ToString());
                //        tempfilePath.Add(file);

                    //        Debug.WriteLine(fileInfo.Extension);
                    //        TreeNode treeNode01 = new TreeNode();
                    //        treeNode01.Name = fileInfo.Name.ToString();
                    //        treeNode01.Text = fileInfo.Name.ToString();
                    //        this.treeView1.Nodes.Add(treeNode01);
                    //    }
                    //    Debug.WriteLine("file_list  " + file_list);
                    //    Debug.WriteLine("fileInfo   " + fileInfo.Name.ToString());
                    //}
                }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
        }
    }
}
