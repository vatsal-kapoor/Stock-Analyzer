//Vatsal Kapoor U02294281
using Project3_Stock.Code;
using Project3_Stock.Code.Patterns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project3_Stock
{
    /// <summary>
    ///  Main form for the program
    /// </summary>
    public partial class Form1 : Form
    {
        // Contain data for smartcandlesticks 
        private List<SmartCandleStick> allCandleSticks;

        // BindingList that stores sorted candlescticks that will be displayed after changing dates
        private BindingList<SmartCandleStick> filteredCandleSticks;

        //Creating list that stores patterns
        private Dictionary<string, Recognizer> recognizerPatterns = new Dictionary<string, Recognizer>();

        //Highest total chart value
        private double maxYChart;
        //Lowest total chart value
        private double minYChart;

        //storing maximum and minumim price value from binding list to adjust chart y-axis
        private decimal minimumPrice;
        private decimal maximumPrice;

        /// <summary>
        /// Defining MainForm class instance. 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            PatternsInitialization();
            ComboBoxForPatterns();
        }

        public Form1(string pathToFile) : this()
        {
            ProcessDataFile(pathToFile);
        }

        /// <summary>
        /// Processes the given data file to generate and display a chart.
        /// </summary>
        private void ProcessDataFile(string pathToFile)
        {
            ReadCandlesticksFromFile(pathToFile);
            UpdateDateTimePickersValues();
            FilterCandleSticks();
            ShowTickerAndTimeframe(pathToFile);
            AdjustChartYAxis();
            RefreshChart();
            EnableUpdateButton();
        }



        /// <summary>
        /// Managing the click event for OpenFileButton.
        /// Selecting CSV data via opening it.
        /// </summary>
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            // selecting CSV file via Open File Dialog 
            OpenFileDialog_fileSelector.ShowDialog();
        }

        /// <summary>
        /// Handler for FileOk event for several outputs.
        /// When triggered, read data from CSV file and refresh components of UI.
        /// </summary>
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //obtaining all paths to selected files 
            string[] files = OpenFileDialog_fileSelector.FileNames;
            //iterating over each selected file 
            foreach (string file in files)
            {
                // If the allCandleSticks collection is null, process the data file to load candlestick data
                if (allCandleSticks == null)
                {
                    ProcessDataFile(file);
                }

                // If allCandleSticks is not null, create a new instance of the form with the file data
                // This implies handling multiple files by opening each in a new form
                else
                {
                    Form1 form = new Form1(file);
                    form.Show(); // Display the newly created form
                }

            }

        }

        /// <summary>
        /// Read content of CSV file.
        /// </summary>
        private void ReadCandlesticksFromFile(string pathToFile)
        {
            // Use csv reader class to generate candlestick list from CSV file
            allCandleSticks = CSVReader.ReadCSVFile(pathToFile);
        }

        /// <summary>
        /// Updates the minimum and maximum dates of DateTimePickers based on loaded data.
        /// </summary>
        private void UpdateDateTimePickersValues()
        {

            // Find leftmost candle stick in the loaded data
            SmartCandleStick earliestCandle = allCandleSticks[0];
            // Find rightmost candle stick in the loaded data
            SmartCandleStick latestCandle = allCandleSticks[allCandleSticks.Count - 1];

            // Set value of start date picker to the leftmost candlestik's date
            DateTimePicker_startDateTime.Value = DateTimePicker_startDateTime.MinDate;
            // Set value of start date picker to the leftmost candlestik's date
            DateTimePicker_endDateTime.Value = DateTimePicker_endDateTime.MaxDate;

            // Based on leftmost and righmost candlesticks set minimum and maximum dates for date time pickers  
            DateTimePicker_startDateTime.MinDate = earliestCandle.Date;
            DateTimePicker_endDateTime.MinDate = earliestCandle.Date;
            DateTimePicker_startDateTime.MaxDate = latestCandle.Date;
            DateTimePicker_endDateTime.MaxDate = latestCandle.Date;

        }

        /// <summary>
        /// Sorting candlesticks after updating date range via datetimepickers.
        /// </summary>
        private void FilterCandleSticks()
        {
            // Sorting candlesticks depending on selected date range
            filteredCandleSticks = new BindingList<SmartCandleStick>();

            // Iterating over candlesticks
            // to sort candlesticks that are located in selected datetime range
            // adding secelted candelsticks to filteredCandleSticks list
            foreach (SmartCandleStick cs in allCandleSticks)
            {
                if (cs.Date >= DateTimePicker_startDateTime.Value && cs.Date <= DateTimePicker_endDateTime.Value)
                {
                    filteredCandleSticks.Add(cs);
                }
            }
        }




        /// <summary>
        /// Changing the title and timeframe labels based on the selected file name.
        /// </summary>
        private void ShowTickerAndTimeframe(string pathToFile)
        {
            //Get name filename from file path
            string filename = Path.GetFileNameWithoutExtension(pathToFile);

            string[] values = filename.Split('-');
            //Extracting ticker name and timeframe value for labels
            string ticker = values[0];
            string timeframe = values[1];

           
        }

        /// <summary>
        /// Adjust chart's Y axis by finding minimum and maximum prices withing the selected range
        /// </summary>
        private void AdjustChartYAxis()
        {
            // init min price to leftmost candlestick's low
            minimumPrice = filteredCandleSticks[0].Low;
            // init max price to leftmost candlestick's high
            maximumPrice = filteredCandleSticks[0].High;

            // go over each candles in filtered candle sticks
            foreach (var cs in filteredCandleSticks)
            {
                // if current candle's low is less than minimum, update minimum
                if (cs.Low < minimumPrice)
                    minimumPrice = cs.Low;

                // if current candle's high is larger than maximum, update maximum
                if (cs.High > maximumPrice)
                    maximumPrice = cs.High;
            }

            // Normalized OHLC chart area based on candlesticks' min and max values and +/- 2% of range
            maxYChart = Chart_tickerChart.ChartAreas[0].AxisY.Maximum = Math.Ceiling(Decimal.ToDouble(maximumPrice) * 1.02);
            minYChart = Chart_tickerChart.ChartAreas[0].AxisY.Minimum = Math.Floor(Decimal.ToDouble(minimumPrice) * 0.98);
        }

        /// <summary>
        /// Assigned sorted candlesticks to Chart and DataGridView.
        /// </summary>
        private void RefreshChart()
        {
            // Using BindingSourve for assigning sorted candlesticks to DataGridView and Chart
            BindingSource_candlestickData.DataSource = filteredCandleSticks;
            Chart_tickerChart.DataBind();

            // update annotations
            ShowAnnotations();
        }




        /// <summary>
        /// Populating our dictionary of patterns with given patterns 
        /// Where key is pattern name and value is method to recognize pattern
        /// </summary>
        private void PatternsInitialization()
        {
            recognizerPatterns.Add("Bearish", new Recognize_Bearish());
            recognizerPatterns.Add("Bearish_Harami", new Recognize_Bearish_Harami());
            recognizerPatterns.Add("Bearish_Engulfing", new Recognizer_Bearish_Engulfing());

            recognizerPatterns.Add("Bullish", new Recognize_Bullish());
            recognizerPatterns.Add("Bullish_Harami", new Recognize_Bullish_Harami());
            recognizerPatterns.Add("Bullish_Engulfing", new Recognize_Bullish_Engulfing());

            recognizerPatterns.Add("Doji", new Recognize_Doji());
            recognizerPatterns.Add("Dragonfly_Doji", new Recognize_DragonflyDoji());
            recognizerPatterns.Add("Gravestone_Doji", new Recognize_GravestoneDoji());

            recognizerPatterns.Add("Hammer", new Recognize_Hammer());
            recognizerPatterns.Add("Marubozu", new Recognize_Marubozu());
            recognizerPatterns.Add("Neutral", new Recognize_Neutral());

            recognizerPatterns.Add("Peak", new Recognize_Peak());
            recognizerPatterns.Add("Valley", new Recognize_Valley());


        }


        /// <summary>
        /// Manages the change of startDateTimePicker via ValueChanged event
        /// </summary>
        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // If the earliest date is larger than the latest date, set the latest date to value of earliest date
            if (DateTimePicker_startDateTime.Value > DateTimePicker_endDateTime.Value)
            {
                DateTimePicker_endDateTime.Value = DateTimePicker_startDateTime.Value;
            }

            // Set selected earliest date to be equal to the leftmost value of the endDateTimePicker
            DateTimePicker_endDateTime.MinDate = DateTimePicker_startDateTime.Value;
        }

        /// <summary>
        /// Manages the change of endDateTimePicker via ValueChanged event
        /// </summary>
        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

            // If the latest date is less than the earliest date, set the earliest date to value of latest date
            if (DateTimePicker_endDateTime.Value < DateTimePicker_startDateTime.Value)
            {
                DateTimePicker_startDateTime.Value = DateTimePicker_endDateTime.Value;
            }

            // Set selected latest date to be equal to the rightmost value of the endDateTimePicker

            DateTimePicker_startDateTime.MaxDate = DateTimePicker_endDateTime.Value;
        }

        /// <summary>
        /// Handles the click event of the updateButton control.
        /// Updates filtered candlesticks, chart min and max values, and displays data.
        /// </summary>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // check if there's data to update
            if (filteredCandleSticks != null && filteredCandleSticks.Count > 0)
            {
                // filtered candlesticks
                FilterCandleSticks();
                // adjust chart's y axis
                AdjustChartYAxis();
                // refresh chart
                RefreshChart();
            }
        }

        /// <summary>
        /// Populates the ComboBox with patterns from the first item in a list of filtered candlesticks.
        /// </summary>
        private void ComboBoxForPatterns()
        {
            // Clear existing items from the ComboBox to avoid duplication, and assigning default value
            ComboBox_Patterns.Items.Clear();
            ComboBox_Patterns.Items.Add("Not Selected");
            ComboBox_Patterns.SelectedIndex = 0;

            // Iterate through the patterns dictionary keys in the SmartCandleStick object
            foreach (var pattern in recognizerPatterns.Keys)
            {
                // Add each pattern key as an item in the ComboBox
                ComboBox_Patterns.Items.Add(pattern);
            }
        }
        /// <summary>
        /// Based on user's pattern chooses appropriate SmartCandleSticks
        /// Iterates over all displayed sticks, and calling add annotation for sticks that meet pattern
        /// /// </summary>
        private void ShowAnnotations()
        {
            // Deleting existing  annotations
            Chart_tickerChart.Annotations.Clear();

            //Creating variable that stores pattern chosen by user
            string selectedPattern = (string)ComboBox_Patterns.SelectedItem;
            if (selectedPattern == "Not Selected") return;

            // Obtaining series containing candlesticks
            var seriesCollection = Chart_tickerChart.Series["OHLC"];

            // If the series is empty; in other words; does not contain candlesticks, return nothing
            if (seriesCollection.Points.Count == 0)
                return;

            // To find all smart candlesticks that meet chosen pattern
            // creating a loop that iterates over all displayed candlestick

            for (var i = 0; i < filteredCandleSticks.Count; i++)
            {
                if (recognizerPatterns.TryGetValue(selectedPattern, out Recognizer patternToRecognize) && patternToRecognize != null)
                {
                    //To meet a pattern, first check if such pattern exists in CandleStick as well as check the boolean value associated with a pattern
                    if (patternToRecognize.Recognize(filteredCandleSticks, i)){  
                    
                        // to determine arrow annotation
                        if (patternToRecognize.patternLength == 1)
                        {
                            // get location of candlestick on the chart
                            DataPoint location = seriesCollection.Points[i];
                            // Adding arrow for a particular stick
                            DisplayAnnotation(location);
                        }
                        //other case is for rectangular annotation
                        else
                        {
                            // Skip the first or last candlestick if pattern length is 3 since their value are always true
                            if (i == 0 || (i == filteredCandleSticks.Count - 1 && patternToRecognize.patternLength == 3))
                            {
                                continue;
                            }
                            else
                            {
                                // get location of candlestick on the chart
                                DataPoint location = seriesCollection.Points[i];
                                // Create a rectangle annotation
                                RectangleAnnotation rectangularAnnotation = new RectangleAnnotation();
                                rectangularAnnotation.SetAnchor(location);

                                // Calculate width based on pattern length
                                double width = 90.0 / filteredCandleSticks.Count * patternToRecognize.patternLength;

                                //Initializing variables for maximum and minimum y values
                                double maxY, minY;

                                //case for calculation y-values for patterns with length is equal to 3 
                                if (patternToRecognize.patternLength == 3)    
                                {
                                    maxY = (int)Math.Max(filteredCandleSticks[i].High, Math.Max(filteredCandleSticks[i + 1].High, filteredCandleSticks[i - 1].High));
                                    minY = (int)Math.Min(filteredCandleSticks[i].Low, Math.Min(filteredCandleSticks[i + 1].Low, filteredCandleSticks[i - 1].Low));
                                }
                                //case for calculation y-values for patterns with length is equal to 2
                                else
                                {
                                    maxY = (int)Math.Max(filteredCandleSticks[i].High, filteredCandleSticks[i - 1].High);
                                    minY = (int)Math.Min(filteredCandleSticks[i].Low, filteredCandleSticks[i - 1].Low);
                                    // Adjust the anchor offset for even pattern to align with the previous candlestick
                                    rectangularAnnotation.AnchorOffsetX = (width / patternToRecognize.patternLength / 2 - 0.25) * -1;  
                                }
                                // Scale the height of the rectangle to fit within the chart bounds
                                double height = 35 * (maxY - minY) / (maxYChart - minYChart);
                                // Set the height and width of the rectangle
                                rectangularAnnotation.Width = width;           
                                rectangularAnnotation.Height = height;

                                // Position the rectangle vertically at the highest Y-value among the candlesticks
                                rectangularAnnotation.Y = maxY;

                                // Set the style of the rectangle's perimeter to dashed lines
                                rectangularAnnotation.LineDashStyle = ChartDashStyle.Dash;

                                // Make the interior of the rectangle transparent to reveal the chart beneath
                                rectangularAnnotation.BackColor = Color.Transparent;

                                // Set the width of the rectangle's perimeter
                                rectangularAnnotation.LineWidth = 1;

                                // Add the rectangle annotation to the chart
                                Chart_tickerChart.Annotations.Add(rectangularAnnotation);
                                DisplayAnnotation(location);


                            }

                        }

                    }
                }
            }
        }

        /// <summary>
        /// Adds a visual marker on the chart at a specific data point that satisfies chosen pattern.
        /// </summary>
        private void DisplayAnnotation(DataPoint location)
        {
            // Initializes a new ArrowAnnotation object with specific dimensions and style.
            var arrow = new ArrowAnnotation { ArrowSize = 1, ArrowStyle = ArrowStyle.Simple };
            // Defines the size of the arrow
            arrow.Height = 2;
            arrow.Width = 1;
            // Adjusts the annotation's vertical position to align with the 'low' value of the candlestick (second Y-value).
            arrow.AnchorY = location.YValues[1];
            // Anchors the annotation to a specific data point representing a candlestick on the chart.
            arrow.AnchorDataPoint = location;
            // Ensures the annotation remains visible, even if it overlaps with other chart elements.
            arrow.SmartLabelStyle.IsOverlappedHidden = false;
            // Places the annotation on the chart for visual reference.
            Chart_tickerChart.Annotations.Add(arrow);
        }

    

        /// <summary>
        /// Event handler for combo box value change
        /// </summary>
        private void ComboBox_Patterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAnnotations();
        }
        private void EnableUpdateButton()
        {
            UpdateButton.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label_startDate_Click(object sender, EventArgs e)
        {

        }
    }

}






