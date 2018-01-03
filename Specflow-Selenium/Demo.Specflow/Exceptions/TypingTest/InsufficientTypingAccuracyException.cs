using System;

namespace Demo.Specflow.Exceptions.TypingTest
{
    public class InsufficientTypingAccuracyException : Exception
    {
        public InsufficientTypingAccuracyException(int expectedAccuracy, float actualAccuracy) : 
            base($"Typing accuracy was insufficiently under {expectedAccuracy}%. Actual accuracy {actualAccuracy}")
        { }
    }
}
