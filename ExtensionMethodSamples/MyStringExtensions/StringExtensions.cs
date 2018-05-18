using System;

namespace ExtensionMethodSamples.MyStringExtensions
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods

    // Extensions must be defined in a static class
    public static class MyExtensions
    {
        // Extension method must be static
        // Extension method must have its first argument preceded with 'this' modifier; type defines type extended
        public static int WordCount(this String sourceString)
        {
            return sourceString.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
