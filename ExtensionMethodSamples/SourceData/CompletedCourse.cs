using Ardalis.GuardClauses;
using ExtensionMethodSamples.GuardClauses;

namespace ExtensionMethodSamples.SourceData
{
    public class CompletedCourse
    {
        public CompletedCourse(string courseName, Grades gradeReceived)
        {
            Guard.Against.NullOrWhiteSpace(courseName, nameof(courseName));
            Guard.Against.InvalidGrade(gradeReceived, nameof(gradeReceived));
            CourseName = courseName;
            GradeReceived = gradeReceived;
        }

        public string CourseName { get; }
        public Grades GradeReceived { get; }
    }
}
