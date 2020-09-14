using System.Collections.Generic;

namespace Orb.CodeAnalysis.Text
{
    public class TextSpanComparer : IComparer<TextSpan>
    {
        public int Compare(TextSpan x, TextSpan y)
        {
            int startCmp = x.Start - y.Start;
            if (startCmp == 0)
                return x.Length - y.Length;
            return startCmp;
        }
    }
}