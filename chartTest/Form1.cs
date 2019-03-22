using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Media;

namespace chartTest
{
    public partial class Form1 : Form
    {
        int tick_count01 = 0;

        private static Dictionary<string, string> filePathDic = new Dictionary<string, string>();
        List<string> x_data = new List<string>();
        List<string> y_data = new List<string>();
        List<string> time_hour = new List<string>();
        List<string> time_day = new List<string>();
        List<string> time_month = new List<string>();
        List<string> time_year = new List<string>();
        List<DateTime> time_date = new List<DateTime>();
        
        static List<decimal> dec_data = new List<decimal>();
        static List<long> lon_data = new List<long>();

        //DataPoint<long, decimal> Data = new DataPoint<long, decimal>(lon_data[0], dec_data[0]);
        //DataPoint<int, int> ddd = new DataPoint<int, int>();

        int draw_state = 0;

        public Form1()
        {
            InitializeComponent();

            this.chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            this.chart1.ChartAreas[0].CursorX.AutoScroll = true;
            this.chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            this.chart1.ChartAreas[1].AxisX.ScaleView.Zoomable = true;
            this.chart1.ChartAreas[1].CursorX.AutoScroll = true;
            this.chart1.ChartAreas[1].CursorX.IsUserSelectionEnabled = true;
            
            textbox_width.Text = "5000";
            textbox_interval.Text = "5";
        }

        private void chart1_mousewheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                //zoom
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

        //Draw button click event.
        private void Draw_Click(object sender, EventArgs e)
        {
            DrawDataClear();

            List<string> passdata = new List<string>();

            var list = new List<TreeNode>();
            LookupChecks(treeView1.Nodes, list);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    passdata.AddRange(GetFileContent(filePathDic[list[i].Name]));
                }
            }
            
            foreach (string time in time_hour)
            {
                //Draw Hour Data
                if(draw_state == 0)
                {
                    chart1.Series[0].Points.AddXY(time_month[tick_count01] + "月\r\n" + time_day[tick_count01] + "日\r\n" + time_date[tick_count01].Hour + "時", x_data[tick_count01]);
                    chart1.Series[1].Points.AddXY(time_month[tick_count01] + "月\r\n" + time_day[tick_count01] + "日\r\n" + time_date[tick_count01].Hour + "時", y_data[tick_count01]);
                }
                //Darw Day Data
                else if(draw_state == 1)
                {
                    chart1.Series[0].Points.AddXY(time_day[tick_count01], x_data[tick_count01]);
                    chart1.Series[1].Points.AddXY(time_hour[tick_count01], y_data[tick_count01]);
                }
                //Draw Month Data
                else if(draw_state == 2)
                {
                    chart1.Series[0].Points.AddXY(time_month[tick_count01], x_data[tick_count01]);
                    chart1.Series[1].Points.AddXY(time_month[tick_count01], y_data[tick_count01]);
                }

                tick_count01++;
            }
            
        }

        //Load Button Click event.
        private void LoadButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            //get select folder path
            string folder_path = folderBrowserDialog1.SelectedPath;
            
            if (dialogResult == DialogResult.OK)
            {
                this.treeView1.Nodes.Clear();
                filePathDic.Clear();

                DirectoryInfo Info = new DirectoryInfo(folder_path);

                TreeNode treeNode00 = new TreeNode();
                treeNode00.Name = Info.Name;
                treeNode00.Text = Info.Name;
                this.treeView1.Nodes.Add(treeNode00);

                DirectoryInfo[] CInfo = Info.GetDirectories("*", SearchOption.AllDirectories);
                
                if(CInfo.Length > 0)
                {
                    foreach (DirectoryInfo info in CInfo)
                    {
                        TreeNode treeNode01 = new TreeNode();
                        treeNode01.Name = info.Name.ToString();
                        treeNode01.Text = info.Name.ToString();
                        treeNode00.Nodes.Add(treeNode01);

                        FileNodeAdd(treeNode01, info);
                    }
                }
                else
                {
                    FileNodeAdd(treeNode00, Info);
                }
            }
        }
        
        //csv file data get
        public List<string> GetFileContent(string file_name)
        {
            foreach (string line in File.ReadLines(file_name, Encoding.UTF8))
            {
                string[] spstring = line.Split(',');
                time_hour.Add(spstring[0]);
                x_data.Add(spstring[1]);
                y_data.Add(spstring[2]);

                dec_data.Add(Convert.ToDecimal(spstring[1]));

                string[] spstring00 = file_name.Split(Path.DirectorySeparatorChar);
                string[] spstring01 = spstring00[spstring00.Count() - 1].Split('.');
                string[] spstring02 = spstring01[0].Split('_');

                time_year.Add(spstring02[1].Substring(0,4));
                time_month.Add(spstring02[1].Substring(4,2));
                time_day.Add(spstring02[1].Substring(6));
                time_date.Add(DateTime.Parse(spstring02[1].Substring(0,4) + "-" + spstring02[1].Substring(4, 2) + "-" + spstring02[1].Substring(6) + " " + spstring[0]));
            }

            return x_data;
        }

        //treeview add node
        private void FileNodeAdd(TreeNode tn, DirectoryInfo info)
        {
            foreach (string file in Directory.GetFiles(info.FullName, "*.csv", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Extension == ".csv")
                {
                    filePathDic.Add(fileInfo.Name.ToString(),file);
                    TreeNode treeNode02 = new TreeNode();
                    treeNode02.Name = fileInfo.Name.ToString();
                    treeNode02.Text = fileInfo.Name.ToString();
                    tn.Nodes.Add(treeNode02);
                }
            }
        }

        //treeView checkBox Live Check
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeView1.AfterCheck -= treeView1_AfterCheck;
            ChildNodeChecking(e.Node);
            ParentNodeChecking(e.Node);
            treeView1.AfterCheck += treeView1_AfterCheck;
        }
        public void ParentNodeChecking(TreeNode selectNode)
        {
            TreeNode t = selectNode.Parent;
            if (t != null)
            {
                t.Checked = true;
                foreach (TreeNode tn in t.Nodes)
                {
                    if (!tn.Checked)
                    {
                        t.Checked = false;
                        break;
                    }
                }
                ParentNodeChecking(t);
            }
        }
        private void ChildNodeChecking(TreeNode selectNode)
        {
            foreach (TreeNode tn in selectNode.Nodes)
            {
                tn.Checked = selectNode.Checked;
                ChildNodeChecking(tn);
            }
            return;
        }

        //treeview check Node Check
        void LookupChecks(TreeNodeCollection nodes, List<TreeNode> list)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                    list.Add(node);
                LookupChecks(node.Nodes, list);
            }
        }
        
        void DrawDataClear()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            x_data.Clear();
            y_data.Clear();
            tick_count01 = 0;
            time_day.Clear();
            time_date.Clear();
            time_hour.Clear();
            time_month.Clear();
            time_year.Clear();
        }

        private void Hour_BT_Click(object sender, EventArgs e)
        {
            draw_state = 0;
        }

        private void Day_BT_Click(object sender, EventArgs e)
        {
            draw_state = 1;
        }

        private void Month_BT_Click(object sender, EventArgs e)
        {
            draw_state = 2;
        }

        private void Clear_BT_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart1.ChartAreas[1].AxisX.ScaleView.ZoomReset(0);
        }

        private void CreatImage_BT_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart1.Width = Convert.ToInt16(textbox_width.Text);
            chart1.Height = 1500;
            chart1.ChartAreas[0].AxisX.Interval = Convert.ToInt16(textbox_interval.Text);
            chart1.Series[0].BorderWidth = 2;

            //C: \Users\ko\Desktop\data\image
            chart1.SaveImage(@"C://Users//ko/Desktop/data/image/myChart.png", ChartImageFormat.Png);

            chart1.ChartAreas[0].AxisX.Interval = 0;
            chart1.Series[0].BorderWidth = 1;
            chart1.Visible = true;
        }

        void fitOneDimensionalData(List<string> source_data)
        {
            List<string> trend_source_data = new List<string>();
            for (var i = source_data.Count; i-- > 0;)
                trend_source_data[i] = source_data[i];

            List<string> regression_data = fitData(trend_source_data);
            List<string> trend_line_data = new List<string>();
            for (var i = regression_data.Count; i-- > 0;)
                trend_line_data[i] = regression_data[i];

            return trend_line_data;
        }

        void fitData(List<string> data)
        {

            List<string> ret = new List<string>;
            var res = 0;
            var x = 0;
            var y = 0;
            var ypred = 0;
            List<string> xdata = new List<string>();
            List<string> ydata = new List<string>();

            for (int i = 0; i < data.Count; i++)
            {
                xdata.Add(data[i]);
            }

            for (var i = 0; i < xdata.Count; i++)
            {
                res = ret[0] * x[i] + ret[1];
                ypred.push([x[i], res]);
            }

            return { data: ypred, slope: ret[0], intercept: ret[1], y: function(x) {
                return (this.slope * x) + this.intercept;
                },
            x: function(y) 
                {
                    return (y - this.intercept) / this.slope;
                }
            };
    }

        public decimal Slope { get; private set; }
        public decimal Intercept { get; private set; }
    }
}