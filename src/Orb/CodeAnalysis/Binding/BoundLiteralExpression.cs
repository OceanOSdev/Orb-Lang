using System;
using Orb.CodeAnalysis.Symbols;

namespace Orb.CodeAnalysis.Binding
{
    internal sealed class BoundLiteralExpression : BoundExpression
    {
        public BoundLiteralExpression(object value)
        {
            Value = value;
            if (value is bool)
                Type = TypeSymbol.Bool;
            else if (value is int)
                Type = TypeSymbol.Int;
            else if (value is string)
                Type = TypeSymbol.String;
            else if (value is double)
                Type = TypeSymbol.Double;
            else
                throw new Exception($"Unexpected literal '{value}' of type {value.GetType()}.");
        }

        public override BoundNodeKind Kind => BoundNodeKind.LiteralExpression;
        public override TypeSymbol Type { get; }
        public object Value { get; }

    }
}