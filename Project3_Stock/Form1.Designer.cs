namespace Project3_Stock
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Chart_tickerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.OpenFileDialog_fileSelector = new System.Windows.Forms.OpenFileDialog();
            this.Button_openFile = new System.Windows.Forms.Button();
            this.DateTimePicker_startDateTime = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker_endDateTime = new System.Windows.Forms.DateTimePicker();
            this.Label_startDate = new System.Windows.Forms.Label();
            this.Label_endDate = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ComboBox_Patterns = new System.Windows.Forms.ComboBox();
            this.BindingSource_candlestickData = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_tickerChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource_candlestickData)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart_tickerChart
            // 
            this.Chart_tickerChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "AreaOHLC";
            chartArea4.AxisY.LabelStyle.Interval = 0D;
            chartArea4.Name = "AreaVolume";
            this.Chart_tickerChart.ChartAreas.Add(chartArea3);
            this.Chart_tickerChart.ChartAreas.Add(chartArea4);
            this.Chart_tickerChart.DataSource = this.BindingSource_candlestickData;
            this.Chart_tickerChart.Location = new System.Drawing.Point(9, 66);
            this.Chart_tickerChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Chart_tickerChart.Name = "Chart_tickerChart";
            series3.ChartArea = "AreaOHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.CustomProperties = "PriceDownColor=Red, PriceUpColor=LimeGreen, PointWidth=0.9";
            series3.IsVisibleInLegend = false;
            series3.IsXValueIndexed = true;
            series3.Name = "OHLC";
            series3.XValueMember = "Date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueMembers = "High, Low, Open, Close";
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "AreaVolume";
            series4.CustomProperties = "PointWidth=0.9";
            series4.IsVisibleInLegend = false;
            series4.IsXValueIndexed = true;
            series4.Name = "Volume";
            series4.XValueMember = "Date";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValueMembers = "Volume";
            series4.YValuesPerPoint = 4;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            this.Chart_tickerChart.Series.Add(series3);
            this.Chart_tickerChart.Series.Add(series4);
            this.Chart_tickerChart.Size = new System.Drawing.Size(522, 451);
            this.Chart_tickerChart.TabIndex = 0;
            this.Chart_tickerChart.Text = "Chart";
            this.Chart_tickerChart.UseWaitCursor = true;
            // 
            // OpenFileDialog_fileSelector
            // 
            this.OpenFileDialog_fileSelector.FileName = "openFileDialog";
            this.OpenFileDialog_fileSelector.Filter = "All Stock files|*.csv|Daily Stocks|*-Day.csv|Weekly Stocks|*-Week.csv|Monthly Sto" +
    "cks|*-Month.csv";
            this.OpenFileDialog_fileSelector.Multiselect = true;
            this.OpenFileDialog_fileSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // Button_openFile
            // 
            this.Button_openFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_openFile.Location = new System.Drawing.Point(625, 466);
            this.Button_openFile.Name = "Button_openFile";
            this.Button_openFile.Size = new System.Drawing.Size(86, 37);
            this.Button_openFile.TabIndex = 3;
            this.Button_openFile.Text = "Open File";
            this.Button_openFile.UseVisualStyleBackColor = true;
            this.Button_openFile.UseWaitCursor = true;
            this.Button_openFile.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // DateTimePicker_startDateTime
            // 
            this.DateTimePicker_startDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DateTimePicker_startDateTime.CustomFormat = "MM/dd/yyyy h:mm tt\t";
            this.DateTimePicker_startDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_startDateTime.Location = new System.Drawing.Point(639, 302);
            this.DateTimePicker_startDateTime.Name = "DateTimePicker_startDateTime";
            this.DateTimePicker_startDateTime.Size = new System.Drawing.Size(145, 20);
            this.DateTimePicker_startDateTime.TabIndex = 5;
            this.DateTimePicker_startDateTime.UseWaitCursor = true;
            this.DateTimePicker_startDateTime.Value = new System.DateTime(2024, 2, 19, 23, 20, 0, 0);
            this.DateTimePicker_startDateTime.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
            // 
            // DateTimePicker_endDateTime
            // 
            this.DateTimePicker_endDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DateTimePicker_endDateTime.CustomFormat = "MM/dd/yyyy h:mm tt\t";
            this.DateTimePicker_endDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_endDateTime.Location = new System.Drawing.Point(639, 373);
            this.DateTimePicker_endDateTime.Name = "DateTimePicker_endDateTime";
            this.DateTimePicker_endDateTime.Size = new System.Drawing.Size(145, 20);
            this.DateTimePicker_endDateTime.TabIndex = 6;
            this.DateTimePicker_endDateTime.UseWaitCursor = true;
            this.DateTimePicker_endDateTime.ValueChanged += new System.EventHandler(this.EndDateTimePicker_ValueChanged);
            // 
            // Label_startDate
            // 
            this.Label_startDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_startDate.AutoSize = true;
            this.Label_startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_startDate.Location = new System.Drawing.Point(551, 302);
            this.Label_startDate.Name = "Label_startDate";
            this.Label_startDate.Size = new System.Drawing.Size(69, 16);
            this.Label_startDate.TabIndex = 7;
            this.Label_startDate.Text = "Start Date:";
            this.Label_startDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_startDate.UseWaitCursor = true;
            this.Label_startDate.Click += new System.EventHandler(this.Label_startDate_Click);
            // 
            // Label_endDate
            // 
            this.Label_endDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_endDate.AutoSize = true;
            this.Label_endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_endDate.Location = new System.Drawing.Point(554, 373);
            this.Label_endDate.Name = "Label_endDate";
            this.Label_endDate.Size = new System.Drawing.Size(66, 16);
            this.Label_endDate.TabIndex = 8;
            this.Label_endDate.Text = "End Date:";
            this.Label_endDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_endDate.UseWaitCursor = true;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpdateButton.Location = new System.Drawing.Point(753, 466);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(87, 37);
            this.UpdateButton.TabIndex = 9;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.UseWaitCursor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ComboBox_Patterns
            // 
            this.ComboBox_Patterns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboBox_Patterns.FormattingEnabled = true;
            this.ComboBox_Patterns.Location = new System.Drawing.Point(639, 421);
            this.ComboBox_Patterns.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComboBox_Patterns.Name = "ComboBox_Patterns";
            this.ComboBox_Patterns.Size = new System.Drawing.Size(183, 21);
            this.ComboBox_Patterns.TabIndex = 11;
            this.ComboBox_Patterns.UseWaitCursor = true;
            this.ComboBox_Patterns.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Patterns_SelectedIndexChanged);
            // 
            // BindingSource_candlestickData
            // 
            this.BindingSource_candlestickData.DataSource = typeof(Project3_Stock.Code.CandleStick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 696);
            this.Controls.Add(this.ComboBox_Patterns);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.Label_endDate);
            this.Controls.Add(this.Label_startDate);
            this.Controls.Add(this.DateTimePicker_endDateTime);
            this.Controls.Add(this.DateTimePicker_startDateTime);
            this.Controls.Add(this.Button_openFile);
            this.Controls.Add(this.Chart_tickerChart);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project3_Stock";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_tickerChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource_candlestickData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_tickerChart;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_fileSelector;
        private System.Windows.Forms.BindingSource BindingSource_candlestickData;
        private System.Windows.Forms.Button Button_openFile;
        private System.Windows.Forms.DateTimePicker DateTimePicker_startDateTime;
        private System.Windows.Forms.DateTimePicker DateTimePicker_endDateTime;
        private System.Windows.Forms.Label Label_startDate;
        private System.Windows.Forms.Label Label_endDate;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ComboBox ComboBox_Patterns;
    }
}

