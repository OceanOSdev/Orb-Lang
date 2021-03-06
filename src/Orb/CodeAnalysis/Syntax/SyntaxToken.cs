using Orb.CodeAnalysis.Text;

namespace Orb.CodeAnalysis.Syntax
{
    public sealed class SyntaxToken : SyntaxNode
    {
        public override SyntaxKind Kind { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }
        public bool IsMissing => Text == null;
        public override TextSpan Span => new TextSpan(Position, Text?.Length ?? 0);

        public SyntaxToken(SyntaxTree syntaxTree,
                           SyntaxKind kind, 
                           int position, 
                           string text, 
                           object value)
            : base(syntaxTree)
        {
            Kind = kind;
            Position = position;
            Text = text;
            Value = value;
        }
    }
}