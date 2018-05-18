using ExtensionMethodSamples.SourceData;

namespace ExtensionMethodSamples.MyEnumExtensions
{
    public static class GradeExtensions
    {
        public static Grades minPassing = Grades.D;
        public static bool Passing(this Grades grade)
        {
            return grade >= minPassing;
        }
    }
}
