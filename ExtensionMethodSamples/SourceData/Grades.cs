using System;

namespace ExtensionMethodSamples.SourceData
{
    public enum Grades
    { F = 0, D = 1, C = 2, B = 3, A = 4 };

    public class InvalidGradeException : ArgumentException
    {
        public InvalidGradeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}
