using System;
using System.IO;
using Orb.CodeAnalysis.Syntax;
using Orb.IO;

namespace Orb.CodeAnalysis.Symbols
{
    internal static class SymbolPrinter
    {
        public static void WriteTo(Symbol symbol, TextWriter writer)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.Function:
                    WriteFunctionTo((FunctionSymbol)symbol, writer);
                    break;
                case SymbolKind.GlobalVariable:
                    WriteGlobalVariableTo((GlobalVariableSymbol)symbol, writer);
                    break;
                case SymbolKind.LocalVariable:
                    WriteLocalVariableTo((LocalVariableSymbol)symbol, writer);
                    break;
                case SymbolKind.Parameter:
                    WriteParameterTo((ParameterSymbol)symbol, writer);
                    break;
                case SymbolKind.Type:
                    WriteTypeTo((TypeSymbol)symbol, writer);
                    break;
                default:
                    throw new Exception($"Unexpected symbol: {symbol.Kind}");
            }
        }

        private static void WriteFunctionTo(FunctionSymbol symbol, TextWriter writer)
        {
            writer.WriteKeyword(SyntaxKind.FunctionKeyword);
            writer.WriteSpace();
            writer.WriteIdentifier(symbol.Name);
            writer.WritePunctuation(SyntaxKind.OpenParenthesisToken);

            var isFirst = true;
            foreach (var parameter in symbol.Parameters)
            {
                if (isFirst)
                    isFirst = false;
                else
                {
                    writer.WritePunctuation(SyntaxKind.CommaToken);
                    writer.WriteSpace();
                }
                    
                
                parameter.WriteTo(writer);
            }

            writer.WritePunctuation(SyntaxKind.CloseParenthesisToken);

            if (symbol.Type != TypeSymbol.Void)
            {
                writer.WritePunctuation(SyntaxKind.ColonToken);
                writer.WriteSpace();
                symbol.Type.WriteTo(writer);
            }
        }

        private static void WriteGlobalVariableTo(GlobalVariableSymbol symbol, TextWriter writer)
        {
            writer.WriteKeyword(symbol.IsReadOnly ? SyntaxKind.LetKeyword : SyntaxKind.VarKeyword);
            writer.WriteSpace();
            writer.WriteIdentifier(symbol.Name);
            writer.WritePunctuation(SyntaxKind.ColonToken);
            writer.WriteSpace();
            symbol.Type.WriteTo(writer);
        }

        private static void WriteLocalVariableTo(LocalVariableSymbol symbol, TextWriter writer)
        {
            writer.WriteKeyword(symbol.IsReadOnly ? SyntaxKind.LetKeyword : SyntaxKind.VarKeyword);
            writer.WriteSpace();
            writer.WriteIdentifier(symbol.Name);
            writer.WritePunctuation(SyntaxKind.ColonToken);
            writer.WriteSpace();
            symbol.Type.WriteTo(writer);
        }

        private static void WriteParameterTo(ParameterSymbol symbol, TextWriter writer)
        {
            writer.WriteIdentifier(symbol.Name);
            writer.WritePunctuation(SyntaxKind.ColonToken);
            writer.WriteSpace();
            symbol.Type.WriteTo(writer);
        }

        private static void WriteTypeTo(TypeSymbol symbol, TextWriter writer)
        {
            writer.WriteIdentifier(symbol.Name);
        }
    }
}