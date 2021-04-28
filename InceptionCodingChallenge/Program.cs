using System;
using System.Collections.Generic;
using System.Linq;

namespace InceptionCodingChallenge
{
    class Program
    {
        public static Dream Sleep(Queue<char> stream, Dream dream, int wrapFactor)
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

        public static int SubjectiveDuration(Dream dream)
        {
            if (dream == null)
                return 0;

           return dream.Depth == 0 
                ? SubjectiveDuration(dream.InnerDream) 
                : dream.Ticks + SubjectiveDuration(dream.InnerDream);
        }
        
        public static IEnumerable<string> DreamLevelDescriptions(Dream dream)
        {
            if (dream == null)
                yield break;

            if (dream.ZeroSleep || dream.Depth > 0)
            {
                yield return dream.InnerDream != null 
                    ? dream.Description + ", " 
                    : dream.Description + "\n\n";
            }

            foreach (var description in DreamLevelDescriptions(dream.InnerDream))
            {
                yield return description;
            }
        }

        public static void Dreaming(string stream, int wrapFactor)
        {
            var dream = Sleep(new Queue<char>(stream.ToCharArray()), new Dream(), wrapFactor);

            Console.WriteLine(SubjectiveDuration(dream));
            Console.WriteLine(dream.InnerDreamTicks);

            foreach (var description in DreamLevelDescriptions(dream))
            {
                Console.Write(description);
            }
        }

        static void Main(string[] args)
        {
            Dreaming("TDTTDTTTTTWTW", 2);
            Dreaming("T", 2);
            Dreaming("DTWTDTTTW", 3);
            Dreaming("DDDTTTTTTTTWWW", 2);
        }
    }
}
