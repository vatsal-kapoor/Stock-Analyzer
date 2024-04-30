using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Stock.Code.Patterns
{
    class Recognizer_Bearish_Engulfing : Recognizer
    {
        public Recognizer_Bearish_Engulfing() : base("Bearish_Engulfing", 2)
        { 
            // Inherited Constructor to initialize patternName and patternLength
        }

        public override bool Recognize(BindingList<SmartCandleStick> smartCandleSticks, int index)
        {
            //In case when first candlestick determines pattern, it does not have previous candlestick so its pattern value set to false
            if (index < patternLength - 1)
            {
                //checking if dictionary has pattern. if dictionary does not have pattern, recognizer creates new key value pair and stores it to dictionary

                if (!smartCandleSticks[index].Patterns.ContainsKey(patternName))
                {
                    smartCandleSticks[index].Patterns.Add(patternName, false);
                }
                return false;
            }
            //variable that represents current candle stick
            SmartCandleStick currentCandle = smartCandleSticks[index];
            //return value of the pattern if it was already calculated and stored in dictionary
            if (currentCandle.Patterns.TryGetValue(patternName, out bool r))
            {
                return r;
            }
            SmartCandleStick previousCandle = smartCandleSticks[index - 1];
            // To calculate this pattern, it is required to have current and previous candlesticks. Hence, previous candlestick was initialized
            //Otherwise calculate it, create key value pair that will be added to dictionary
            bool result = currentCandle.Open > currentCandle.Close &&
                                    previousCandle.Close > previousCandle.Open &&
                                    currentCandle.Close < currentCandle.Open &&
                                    currentCandle.Open > previousCandle.Close;
            currentCandle.Patterns.Add(patternName, result);
            return result;

        }
    }
}
