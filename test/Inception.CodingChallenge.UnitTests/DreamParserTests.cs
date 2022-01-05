using FluentAssertions;
using Xunit;

namespace Inception.CodingChallenge.UnitTests
{
    public class DreamParserTests
    {
        [Theory]
        [ClassData(typeof(DreamParserTestData))]
        public void DreamParserReturnsExpectedValues(string dream, int wrapFactor, DreamStatistics dreamStats)
        {
            // Act
            var result = DreamParser.Parse(dream, wrapFactor);

            // Assert
            result.Should().BeEquivalentTo(dreamStats);
        }
    }
}