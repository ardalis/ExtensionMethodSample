using System;
using Xunit;
using static System.Math;
using static Xunit.Assert;
using static System.Console;

namespace ExtensionMethodSamples
{
    public class UsingStaticExmples
    {
        [Fact]
        public void Mathing()
        {
            var result = Sqrt(4);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Asserting()
        {
            var result = 2 + 2;

            Equal(4, result);
        }


        [Fact]
        public void Consoling()
        {
            Console.WriteLine("Something");

            WriteLine("Something else");
        }
    }
}
