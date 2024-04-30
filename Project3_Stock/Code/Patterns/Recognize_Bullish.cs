﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Stock.Code
{
    class Recognize_Bullish : Recognizer
    {
        public Recognize_Bullish() : base("Bullsih", 1)
        {
            // Inherited Constructor to initialize patternName and patternLength
        }

        // Overrides abstract method for Bullish pattern recognition.
        public override bool Recognize(BindingList<SmartCandleStick> smartCandleSticks, int index)
        {
            //scs represents current candlestick
            SmartCandleStick scs = smartCandleSticks[index];
            //return value of the pattern if it was already calculated and stored in dictionary
            if (scs.Patterns.TryGetValue(patternName, out bool r))
            {
                return r;
            }
            //Otherwise calculate it, create key value pair that will be added to dictionary
            bool result = scs.Close > scs.Open;
            scs.Patterns.Add(patternName, result);
            return result;
        }

    }
}

