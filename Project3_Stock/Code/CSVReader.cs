using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Project3_Stock.Code
{
    /// <summary>
    /// Supplies functions for retrieving data from a CSV file.
    /// </summary>
    public static class CSVReader
    {
        /// <summary>
        /// Extracts data from a CSV file and presents it as a collection of CandleStick instances.
        /// </summary>
        public static List<SmartCandleStick> ReadCSVFile(string filename)
        {
            // Prepare a list to store candlestick objects
            var candleSticks = new List<SmartCandleStick>(1024);

            // Try-catch block to manage potential errors
            try
            {
                // Access the file using a stream reader
                using (StreamReader reader = new StreamReader(filename))
                {
                    // Read each line of the file
                    reader.ReadLine();

                    // Iterate until reaching the end of the file
                    while (!reader.EndOfStream)
                    {
                        // Read each row of file
                        string row = reader.ReadLine();

                        // Avoid processing rows containing "null" values
                        if (!row.Contains("null"))
                        {
                            // Split the row string into an array of data
                            string[] data = row.Split(',');

                            // Create a new SmartCandleStick instance using the data and add it to the list
                            SmartCandleStick newCandle = new SmartCandleStick(data);
                            candleSticks.Add(newCandle);
                        }
                    }
                }
            }
            //  Catch an exeption
            catch
            {
                return candleSticks;
            }

            return candleSticks;
        }
    }
}
