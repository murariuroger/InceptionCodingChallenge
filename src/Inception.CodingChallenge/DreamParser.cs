namespace Inception.CodingChallenge
{
    internal static class DreamParser
    {
        internal static DreamStatistics Parse(string stream, int wrapFactor)
        {
            var dream = Sleep(new Queue<char>(stream.ToCharArray()), new Dream(), wrapFactor);

            return new()
            {
                SubjectiveDuration = SubjectiveDuration(dream),
                InnerDreamTicks = dream.InnerDreamTicks,
                Description = String.Join(", ", GetDreamLevelDescriptions(dream))
            };
        }

        private static Dream Sleep(Queue<char> stream, Dream dream, int wrapFactor)
        {
            if (stream.Count == 0)
                return dream;

            switch (stream.Dequeue())
            {
                case 'D':
                    if (dream.InnerDream == null)
                    {
                        dream.InnerDream = new Dream
                        {
                            Depth = dream.Depth + 1,
                            OuterDream = dream
                        };
                    }
                    Sleep(stream, dream.InnerDream, wrapFactor);
                    break;
                case 'W':
                    dream.OuterDream.InnerDreamTicks = Math.Ceiling((double)(dream.Ticks + dream.InnerDreamTicks) / wrapFactor);
                    Sleep(stream, dream.OuterDream, wrapFactor);
                    break;
                case 'T':
                    dream.Ticks++;
                    Sleep(stream, dream, wrapFactor);
                    break;
                default:
                    break;
            }

            return dream;
        }

        private static IEnumerable<string> GetDreamLevelDescriptions(Dream dream)
        {
            if (dream == null)
                yield break;

            var noSleep = dream.InnerDreamTicks == 0 && dream.Depth == 0;
            if (noSleep || dream.Depth > 0)
            {
                yield return noSleep
                    ? "none"
                    : $"dream {dream.Depth} - {dream.InnerDreamTicks + dream.Ticks} ticks";
            }

            foreach (var description in GetDreamLevelDescriptions(dream.InnerDream))
            {
                yield return description;
            }
        }

        private static int SubjectiveDuration(Dream dream)
        {
            if (dream == null)
                return 0;

            return dream.Depth == 0
                 ? SubjectiveDuration(dream.InnerDream)
                 : dream.Ticks + SubjectiveDuration(dream.InnerDream);
        }
    }
}
