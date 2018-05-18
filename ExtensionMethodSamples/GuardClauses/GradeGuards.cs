using Ardalis.GuardClauses;
using ExtensionMethodSamples.SourceData;
using System;

namespace ExtensionMethodSamples.GuardClauses
{
    // https://github.com/ardalis/GuardClauses
    public static class GradeGuards
    {
        public static void InvalidGrade(this IGuardClause guardClause, Grades input, string parameterName)
        {
            if (!Enum.IsDefined(typeof(Grades), input))
            {
                throw new InvalidGradeException("Not a valid grade.", parameterName);
            }
        }
    }
}
