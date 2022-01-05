using System.Collections;
using System.Collections.Generic;

namespace Inception.CodingChallenge.UnitTests
{
    public class DreamParserTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] 
            { 
                "TDTTDTTTTTWTW", 
                2, 
                new DreamStatistics 
                { 
                    SubjectiveDuration = 8,
                    InnerDreamTicks = 3,
                    Description = "dream 1 - 6 ticks, dream 2 - 5 ticks"
                } 
            };

            yield return new object[]
            {
                "DTWTDTTTW",
                3,
                new DreamStatistics
                {
                    SubjectiveDuration = 4,
                    InnerDreamTicks = 2,
                    Description = "dream 1 - 4 ticks"
                }
            };

            yield return new object[]
            {
                "DDDTTTTTTTTWWW",
                2,
                new DreamStatistics
                {
                    SubjectiveDuration = 8,
                    InnerDreamTicks = 1,
                    Description = "dream 1 - 2 ticks, dream 2 - 4 ticks, dream 3 - 8 ticks"
                }
            };

            yield return new object[]
            {
                "T",
                2,
                new DreamStatistics
                {
                    SubjectiveDuration = 0,
                    InnerDreamTicks = 0,
                    Description = "none"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
