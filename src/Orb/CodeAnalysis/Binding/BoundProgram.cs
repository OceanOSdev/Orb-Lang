using System.Collections.Immutable;
using Orb.CodeAnalysis.Symbols;

namespace Orb.CodeAnalysis.Binding
{
    internal sealed class BoundProgram
    {
        public BoundProgram(ImmutableArray<Diagnostic> diagnostics,
                            ImmutableDictionary<FunctionSymbol, BoundBlockStatement> functions,
                            BoundBlockStatement statement)
        {
            Diagnostics = diagnostics;
            Functions = functions;
            Statement = statement;
        }

        public ImmutableArray<Diagnostic> Diagnostics { get; }
        public ImmutableDictionary<FunctionSymbol, BoundBlockStatement> Functions { get; }
        public BoundBlockStatement Statement { get; }
    }
}