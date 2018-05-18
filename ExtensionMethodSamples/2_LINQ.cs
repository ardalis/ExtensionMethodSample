using ExtensionMethodSamples.MyEnumExtensions;
using ExtensionMethodSamples.SourceData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ExtensionMethodSamples
{
    public class LinqExamples
    {
        private List<Student> _studentData = new List<Student>();

        public LinqExamples()
        {
            PopulateData();
        }

        [Fact]
        public void OrderBy()
        {
            int[] ints = { 10, 45, 15, 39, 21, 26 };
            int[] result = ints.OrderBy(g => g).ToArray();
            var sb = new StringBuilder();
            foreach (var i in result)
            {
                sb.Append(i + " ");
            }
            var stringResult = sb.ToString().Trim();

            Assert.Equal("10 15 21 26 39 45", stringResult);
        }

        [Fact]
        public void Count()
        {
            int totalStudents = _studentData.Count();

            Assert.Equal(2, totalStudents);
        }

        [Fact]
        public void CountWithFilter()
        {
            int totalStudents = _studentData.Count(s => s.FirstName == "Steve");
            int count = 0;
            foreach (var s in _studentData)
            {
                if(s.FirstName=="Steve")
                {
                    count++;
                }
            }

            Assert.Equal(1, totalStudents);
            Assert.Equal(1, count);
        }

        [Fact]
        public void FirstAndLast()
        {
            Student firstStudent = _studentData.First();
            Student lastStudent = _studentData.Last();

            Assert.Equal("Steve", firstStudent.FirstName);
            Assert.Equal("Bob", lastStudent.FirstName);
        }

        [Fact]
        public void FirstWithFilter()
        {
            Student firstBobStudent = _studentData.First(s => s.FirstName == "Bob");
            var last = _studentData.Last(s => s.FirstName == "Bob");

            // this blows up
            //var jeff = _studentData.First(s => s.FirstName == "Jeff");

            Assert.Equal("Bob", firstBobStudent.FirstName);
            Assert.Equal("Bob", last.FirstName);
        }

        [Fact]
        public void FirstOrDefault()
        {
            Student firstBobStudent = _studentData.FirstOrDefault(s => s.FirstName == "Bob");
            Student firstMichelleStudent = _studentData.FirstOrDefault(s => s.FirstName == "Michelle");

            Assert.Equal("Bob", firstBobStudent.FirstName);
            Assert.Null(firstMichelleStudent);
        }

        [Fact]
        public void Select()
        {
            var names = _studentData.Select(s => s.FirstName + " " + s.LastName);

            Assert.Contains("Steve Smith", names);
            Assert.Contains("Bob Jones", names);
        }

        [Fact]
        public void SelectManyAndCount()
        {
            var totalCoursesCount = _studentData
                .SelectMany(s => s.CompletedCourses)
                .Count();

            Assert.Equal(7, totalCoursesCount);
        }

        [Fact]
        public void Where()
        {
            var allCourses = _studentData.SelectMany(s => s.CompletedCourses);

            var failedCourses = allCourses.Where(c => !c.GradeReceived.Passing());

            var failedMathCourses = failedCourses.Where(c => c.CourseName == "Calculus");

            var result = _studentData
                            .SelectMany(s => s.CompletedCourses)
                            .Where(c => !c.GradeReceived.Passing())
                            .Where(c => c.CourseName == "Calculus");

            Assert.Equal("Calculus", failedCourses.First().CourseName);
        }


        private void PopulateData()
        {
            var steve = new Student("Steve", "Smith");
            steve.CompletedCourses.Add(new CompletedCourse("Calculus", Grades.A));
            steve.CompletedCourses.Add(new CompletedCourse("History", Grades.A));
            steve.CompletedCourses.Add(new CompletedCourse("Physics", Grades.A));
            _studentData.Add(steve);

            var bob = new Student("Bob", "Jones");
            bob.CompletedCourses.Add(new CompletedCourse("Calculus", Grades.F));
            bob.CompletedCourses.Add(new CompletedCourse("English", Grades.A));
            bob.CompletedCourses.Add(new CompletedCourse("History", Grades.B));
            bob.CompletedCourses.Add(new CompletedCourse("Biology", Grades.A));
            _studentData.Add(bob);
        }
    }
}
