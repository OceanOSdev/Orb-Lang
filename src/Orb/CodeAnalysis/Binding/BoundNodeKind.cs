namespace Orb.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        //Statements
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement,
        DoWhileStatement,
        ForStatement,
        GotoStatement,
        ConditionalGotoStatement,
        LabelStatement,

        // Expressions
        LiteralExpression,
        VariableExpression,
        AssignmentExpression,
        UnaryExpression,
        BinaryExpression,
        ErrorExpression,
        CallExpression,
        ConversionExpression,
    }
}