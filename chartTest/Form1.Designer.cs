namespace chartTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.drawBT = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.Clear_BT = new System.Windows.Forms.Button();
            this.CreatImage_BT = new System.Windows.Forms.Button();
            this.textbox_width = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Hour_BT = new System.Windows.Forms.Button();
            this.Day_BT = new System.Windows.Forms.Button();
            this.Month_BT = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_interval = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(203, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "X Data";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Y Data";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(930, 462);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chart1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1136, 518);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.drawBT);
            this.flowLayoutPanel1.Controls.Add(this.LoadButton);
            this.flowLayoutPanel1.Controls.Add(this.Clear_BT);
            this.flowLayoutPanel1.Controls.Add(this.CreatImage_BT);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textbox_width);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.textbox_interval);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(203, 471);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(930, 44);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // drawBT
            // 
            this.drawBT.AutoSize = true;
            this.drawBT.Location = new System.Drawing.Point(3, 3);
            this.drawBT.Name = "drawBT";
            this.drawBT.Size = new System.Drawing.Size(106, 31);
            this.drawBT.TabIndex = 3;
            this.drawBT.Text = "Draw";
            this.drawBT.UseVisualStyleBackColor = true;
            this.drawBT.Click += new System.EventHandler(this.Draw_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.AutoSize = true;
            this.LoadButton.Location = new System.Drawing.Point(115, 3);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(106, 31);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // Clear_BT
            // 
            this.Clear_BT.AutoSize = true;
            this.Clear_BT.Location = new System.Drawing.Point(227, 3);
            this.Clear_BT.Name = "Clear_BT";
            this.Clear_BT.Size = new System.Drawing.Size(106, 31);
            this.Clear_BT.TabIndex = 5;
            this.Clear_BT.Text = "ZoomClear";
            this.Clear_BT.UseVisualStyleBackColor = true;
            this.Clear_BT.Click += new System.EventHandler(this.Clear_BT_Click);
            // 
            // CreatImage_BT
            // 
            this.CreatImage_BT.AutoSize = true;
            this.CreatImage_BT.Location = new System.Drawing.Point(339, 3);
            this.CreatImage_BT.Name = "CreatImage_BT";
            this.CreatImage_BT.Size = new System.Drawing.Size(106, 31);
            this.CreatImage_BT.TabIndex = 6;
            this.CreatImage_BT.Text = "ScreenShot";
            this.CreatImage_BT.UseVisualStyleBackColor = true;
            this.CreatImage_BT.Click += new System.EventHandler(this.CreatImage_BT_Click);
            // 
            // textbox_width
            // 
            this.textbox_width.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textbox_width.Location = new System.Drawing.Point(490, 9);
            this.textbox_width.Name = "textbox_width";
            this.textbox_width.Size = new System.Drawing.Size(100, 19);
            this.textbox_width.TabIndex = 7;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(194, 462);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.Hour_BT);
            this.flowLayoutPanel2.Controls.Add(this.Day_BT);
            this.flowLayoutPanel2.Controls.Add(this.Month_BT);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 471);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(194, 44);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // Hour_BT
            // 
            this.Hour_BT.AutoSize = true;
            this.Hour_BT.Location = new System.Drawing.Point(3, 3);
            this.Hour_BT.Name = "Hour_BT";
            this.Hour_BT.Size = new System.Drawing.Size(55, 41);
            this.Hour_BT.TabIndex = 0;
            this.Hour_BT.Text = "H";
            this.Hour_BT.UseVisualStyleBackColor = true;
            this.Hour_BT.Click += new System.EventHandler(this.Hour_BT_Click);
            // 
            // Day_BT
            // 
            this.Day_BT.AutoSize = true;
            this.Day_BT.Location = new System.Drawing.Point(64, 3);
            this.Day_BT.Name = "Day_BT";
            this.Day_BT.Size = new System.Drawing.Size(55, 41);
            this.Day_BT.TabIndex = 1;
            this.Day_BT.Text = "D";
            this.Day_BT.UseVisualStyleBackColor = true;
            this.Day_BT.Click += new System.EventHandler(this.Day_BT_Click);
            // 
            // Month_BT
            // 
            this.Month_BT.AutoSize = true;
            this.Month_BT.Location = new System.Drawing.Point(125, 3);
            this.Month_BT.Name = "Month_BT";
            this.Month_BT.Size = new System.Drawing.Size(55, 41);
            this.Month_BT.TabIndex = 2;
            this.Month_BT.Text = "M";
            this.Month_BT.UseVisualStyleBackColor = true;
            this.Month_BT.Click += new System.EventHandler(this.Month_BT_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(596, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chart_Interval";
            // 
            // textbox_interval
            // 
            this.textbox_interval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textbox_interval.Location = new System.Drawing.Point(677, 9);
            this.textbox_interval.Name = "textbox_interval";
            this.textbox_interval.Size = new System.Drawing.Size(100, 19);
            this.textbox_interval.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 518);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button drawBT;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button Hour_BT;
        private System.Windows.Forms.Button Day_BT;
        private System.Windows.Forms.Button Month_BT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Clear_BT;
        private System.Windows.Forms.Button CreatImage_BT;
        private System.Windows.Forms.TextBox textbox_width;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_interval;
    }
}

