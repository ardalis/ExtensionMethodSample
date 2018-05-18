using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace ExtensionMethodSamples.SourceData
{
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
    }
}
