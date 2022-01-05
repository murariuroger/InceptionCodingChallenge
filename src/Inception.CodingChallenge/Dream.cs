namespace Inception.CodingChallenge
{
    internal class Dream
    {
        public int Depth = 0;
        public int Ticks { get; set; }
        public double InnerDreamTicks { get; set; }
        public Dream InnerDream { get; set; }

        public Dream OuterDream { get; set; }
    }
}
