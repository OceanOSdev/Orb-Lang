namespace Orb.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        //Statements
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,

        // Expressions
        LiteralExpression,
        VariableExpression,
        AssignmentExpression,
        UnaryExpression,
        BinaryExpression,
    }
}