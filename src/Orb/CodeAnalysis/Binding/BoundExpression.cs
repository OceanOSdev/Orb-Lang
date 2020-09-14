using Orb.CodeAnalysis.Symbols;

namespace Orb.CodeAnalysis.Binding
{
    internal abstract class BoundExpression : BoundNode
    {
        public abstract TypeSymbol Type { get; }
    }
}