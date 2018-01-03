using System;

namespace Demo.Specflow.Exceptions.TypingTest
{
    public class InsufficientTypingSpeedException : Exception
    {
        public InsufficientTypingSpeedException(int expectedSpeed, float actualSpeed) : 
            base($"Typing speed was insufficiently under {expectedSpeed} WPM. Actual typing speed {actualSpeed}")
        { }
    }
}
