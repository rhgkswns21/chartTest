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
        int tick_count01 = 0;

        private static Dictionary<string, string> filePathDic = new Dictionary<string, string>();
        List<string> x_data = new List<string>();
        List<string> y_data = new List<string>();
        List<string> time_hour = new List<string>();
        List<string> time_day = new List<string>();
        List<string> time_month = new List<string>();
        List<string> time_year = new List<string>();

        public Form1()
        {
            InitializeComponent();            
        }

        private void chart1_mousewheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0)
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

        //start button click event.
        private void Draw_Click(object sender, EventArgs e)
        {
            time_hour.Clear();
            x_data.Clear();
            y_data.Clear();
            tick_count01 = 0;

            List<string> passdata = new List<string>();

            var list = new List<TreeNode>();
            LookupChecks(treeView1.Nodes, list);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.IndexOf(".csv", StringComparison.OrdinalIgnoreCase) >= 0)
                    passdata.AddRange(GetFileContent(filePathDic[list[i].Name]));
            }

            foreach (string time in time_hour)
            {
                //chart1.Series[0].Points.AddY(x_data[tick_count01]);
                //chart1.Series[1].Points.AddY(y_data[tick_count01]);

                chart1.Series[0].Points.AddXY(time_day[tick_count01], x_data[tick_count01]);
                chart1.Series[1].Points.AddXY(time_month[tick_count01], y_data[tick_count01]);

                tick_count01++;
            }
        }

        //stop button click event
        private void Clear_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
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
        
        //chart1_click_event.
        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
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

                string[] spstring00 = file_name.Split(Path.DirectorySeparatorChar);
                string[] spstring01 = spstring00[spstring00.Count() - 1].Split('.');
                string[] spstring02 = spstring01[0].Split('_');
                
                time_year.Add(spstring02[1].Substring(0,4));
                time_month.Add(spstring02[1].Substring(4,2));
                time_day.Add(spstring02[1].Substring(6));
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

        private void TestButton_Click(object sender, EventArgs e)
        {
        }
    }
}
