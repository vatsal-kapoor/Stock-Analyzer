using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Stock.Code
{
    class Recognize_Peak : Recognizer
    {
        public Recognize_Peak() : base("Peak", 3)
        {
            // Inherited Constructor to initialize patternName and patternLength
        }

        // Overrides abstract method for Neutral pattern recognition.
        public override bool Recognize(BindingList<SmartCandleStick> smartCandleSticks, int index)
        {
            //In case when first candlestick determines pattern, it does not have previous candlestick so its pattern value set to false
            //Second case, when last candlestick determines pattern, it does not have next candlestick so its pattern value set to false
            if (index < 1 || index >= smartCandleSticks.Count - 1)
            {
                //checking if dictionary has pattern. if dictionary does not have pattern, recognizer creates new key value pair and stores it to dictionary
                if (!smartCandleSticks[index].Patterns.ContainsKey(patternName))
                {
                    smartCandleSticks[index].Patterns.Add(patternName, false);
                }
                return false;

            } 

            //represents current candlestick whose pattern is calculated 
            SmartCandleStick currentCandle = smartCandleSticks[index];
            //return value of the pattern if it was already calculated and stored in dictionary
            if (currentCandle.Patterns.TryGetValue(patternName, out bool r))
            {
                return r;
            }
            //To calculate this pattern, it is required to have previous and next candlesticks 
            SmartCandleStick previousCandle = smartCandleSticks[index - 1];
            SmartCandleStick nextCandle = smartCandleSticks[index + 1];
            //Otherwise calculate it, create key value pair that will be added to dictionary
            bool isPeak = previousCandle.High < currentCandle.High &&
                          currentCandle.High > nextCandle.High;

            currentCandle.Patterns.Add(patternName, isPeak);

            return isPeak;
        }
    }

}
