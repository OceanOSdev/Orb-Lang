namespace Orb.CodeAnalysis.Binding
{
    internal sealed class BoundDoWhileStatement : BoundStatement
    {
        public BoundDoWhileStatement(BoundStatement body, BoundExpression condition)
        {
            Body = body;
            Condition = condition;
        }
        public override BoundNodeKind Kind => BoundNodeKind.DoWhileStatement;

        public BoundStatement Body { get; }
        public BoundExpression Condition { get; }
    }
    internal sealed class BoundWhileStatement : BoundStatement
    {
        public BoundWhileStatement(BoundExpression condition, BoundStatement body)
        {
            Condition = condition;
            Body = body;
        }

        public override BoundNodeKind Kind => BoundNodeKind.WhileStatement;
        public BoundExpression Condition { get; }
        public BoundStatement Body { get; }
    }
}