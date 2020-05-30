using System;

namespace FiresideCore.FireScript.Parsing
{
    public class ParsingException : Exception
    {
        public readonly bool Critical;

        public ParsingException(string msg, bool critical) : base(msg)
        {
            Critical = critical;
        }
    }
}