using ExtensionMethodSamples.MyEnumExtensions;
using ExtensionMethodSamples.MyStringExtensions;
using ExtensionMethodSamples.SourceData;
using System.Collections.Generic;
using Xunit;

namespace ExtensionMethodSamples
{
    public class SimpleExamples
    {
        [Fact]
        public void WordCount()
        {
            string sampleString = "The quick brown fox jumped over the lazy dog.";

            int wordCount = sampleString.WordCount();

            Assert.Equal(9, wordCount);
        }

        [Fact]
        public void ExtendingEnums()
        {
            var poorStudentGrade = Grades.F;
            var averageStudentGrade = Grades.C;
            var honorsStudentGrade = Grades.A;

            Assert.False(poorStudentGrade.Passing());
            Assert.True(averageStudentGrade.Passing());
            Assert.True(honorsStudentGrade.Passing());
        }
    }
}
