using System;


namespace Project3_Stock.Code
{
    /// <summary>
    ///Class definition for representing a candlestick.
    /// </summary>
    public class CandleStick
    {
        public DateTime Date { get; set; } //  Date and time of the candlestick
        public decimal Open { get; set; } // Opening price of the candlestick
        public decimal Close { get; set; } // Closing price of the candlestick
        public decimal High { get; set; } // Highest price reached by the candlestick
        public decimal Low { get; set; } // Lowest price reached by the candlestick
        public long Volume { get; set; } // Volume of the candlestick

        /// <summary>
        /// Initializes a new instance of the CandleStick class with provided data.
        /// </summary>
        public CandleStick(string[] data)
        {
            // Ensure the input array contains 7 values, else consider the file invalid
            if (data.Length == 7)
            {
                Date = DateTime.Parse(data[0]); // Parse and assign the first element of data to Date
                Open = decimal.Parse(data[1]); //Parse and assign the second element of data to Open
                High = decimal.Parse(data[2]); // Parse and assign the third element of data to High
                Low = decimal.Parse(data[3]); ///Parse and assign the fourth element of data to Low
                Close = decimal.Parse(data[4]); // Parse and assign the fifth element of data to Close
                Volume = long.Parse(data[6]); // Parse and assign the seventh element of data to Volume
                //data[5] was skipped because it contains adjusted volume
            }
            // Throw an exception if there are not enough values
            else
            {
                throw new Exception("Input values array should have at least 7 elements.");
            }
        }
    }
}
