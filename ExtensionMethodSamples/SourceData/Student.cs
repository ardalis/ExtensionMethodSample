using Ardalis.GuardClauses;
using ExtensionMethodSamples.MyEnumExtensions;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethodSamples.SourceData
{
    // https://github.com/ardalis/ExtensionMethodSample
    public class Student
    {
        public Student(string firstName, string lastName)
        {
            Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
            Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public List<CompletedCourse> CompletedCourses { get; } = new List<CompletedCourse>();

        public bool IsGoodStudent()
        {
            // Log("Calling IsGoodStudent");
            return CompletedCourses.All(c => c.GradeReceived.Passing());
        }
    }
}
