using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Orb.CodeAnalysis.Symbols;

namespace Orb.CodeAnalysis.Binding
{
    internal sealed class BoundScope
    {
        private Dictionary<string, Symbol> _symbols;

        public BoundScope Parent { get; }

        public BoundScope(BoundScope parent)
        {
            Parent = parent;
        }

        public bool TryDeclareVariable(VariableSymbol variable) => TryDeclareSymbol(variable);

        public bool TryDeclareFunction(FunctionSymbol function) => TryDeclareSymbol(function);

        private bool TryDeclareSymbol<TSymbol>(TSymbol symbol)
            where TSymbol : Symbol
        {
            if (_symbols == null)
                _symbols = new Dictionary<string, Symbol>();
            else if (_symbols.ContainsKey(symbol.Name))
                return false;
            
            _symbols.Add(symbol.Name, symbol);
            return true;
        }

        public bool TryLookupSymbol(string name, out Symbol symbol)
        {
            if (_symbols != null && _symbols.TryGetValue(name, out symbol))
                return true;
                
            symbol = null;
            return Parent?.TryLookupSymbol(name, out symbol) ?? false;
        }

        public ImmutableArray<VariableSymbol> GetDeclaredVariables() => GetDeclaredSymbols<VariableSymbol>();

        public ImmutableArray<FunctionSymbol> GetDeclaredFunctions() => GetDeclaredSymbols<FunctionSymbol>();

        private ImmutableArray<TSymbol> GetDeclaredSymbols<TSymbol>()
            where TSymbol : Symbol
        {
            if (_symbols == null)
                return ImmutableArray<TSymbol>.Empty;
            
            return _symbols.Values.OfType<TSymbol>().ToImmutableArray();
        }
    }
}