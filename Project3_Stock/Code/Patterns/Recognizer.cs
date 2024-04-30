using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Stock.Code
{
    /// <summary>
    /// Defines an abstract class serving as a blueprint for Recognizer classes.
    /// All classes inheriting from this abstract class must implement a constructor
    /// that takes a pattern name and its length, as well as a method to recognize
    /// a specific pattern.
    /// </summary>


    abstract class Recognizer
    {
        // Represents the name of the pattern, used as a key in a dictionary to access the pattern's value or recognition method.
        public string patternName;
        // Represents the length of the pattern, used in the recognition method to handle edge cases.
        public int patternLength;

        // Constructor that initializes patternName and patternLength.
        public Recognizer(string patternName, int patternLength) 
        {
            this.patternName = patternName;
            this.patternLength = patternLength;
        }
        // Method to determine if a pattern is recognized within a list of SmartCandleSticks.
        public abstract bool Recognize(BindingList<SmartCandleStick> smartCandleSticks, int index);
       

    }


}
