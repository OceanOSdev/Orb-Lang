namespace Orb.CodeAnalysis.Text
{
    public sealed class TextLine
    {
        public TextLine(SourceText text, int start, int length, int lengthIncludeingLineBreak)
        {
            Text = text;
            Start = start;
            Length = length;
            LengthIncludeingLineBreak = lengthIncludeingLineBreak;
        }

        public SourceText Text { get; }
        public int Start { get; }
        public int Length { get; }
        public int End => Start + Length;
        public int LengthIncludeingLineBreak { get; }
        public TextSpan Span => new TextSpan(Start, Length);
        public TextSpan SpanIncludingLineBreak => new TextSpan(Start, LengthIncludeingLineBreak);
        public override string ToString() => Text.ToString(Span);
    }
}