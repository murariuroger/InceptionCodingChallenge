using System;
using System.Collections.Generic;
using System.Text;

namespace InceptionCodingChallenge
{
    public class Dream
    {
        public int Ticks { get; set; }
        public double InnerDreamTicks { get; set; }
        public int Depth = 0;
        public Dream InnerDream { get; set; }

        public Dream OuterDream { get; set; }

        public bool ZeroSleep => InnerDreamTicks == 0 && Depth == 0;
        public string Description => ZeroSleep ? "none" : $"dream {Depth} - {InnerDreamTicks + Ticks} ticks";

    }
}
