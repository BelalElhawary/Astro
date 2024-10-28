namespace Astro.Core
{
    public sealed class Instructions
    {
        public const byte Ret = 0;
        public const byte Mov = 1;
        public const byte Add = 2;
        public const byte Sub = 3;
        public const byte Mul = 4;
        public const byte Div = 5;
        public const byte Concat = 6;
        public const byte Print = 7;
        public const byte Cop = 8;

    }
}