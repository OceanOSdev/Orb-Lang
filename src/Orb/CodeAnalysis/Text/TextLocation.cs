namespace Orb.CodeAnalysis.Text
{
    public struct TextLocation
    {
        public TextLocation(SourceText text, TextSpan span)
        {
            Text = text;
            Span = span;
        }

        public SourceText Text { get; }
        public TextSpan Span { get; }

        public string FileName => Text.FileName;
        public int StartLine => Text.GetLineIndex(Span.Start);
        public int StartCharacter => Text.GetLineIndex(Span.Start);
        public int EndLine => Text.GetLineIndex(Span.End);
        public int EndCharacter => Span.End - Text.Lines[EndLine].Start;
    }
}