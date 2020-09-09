﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Orb.CodeAnalysis.Text;

namespace Orb.CodeAnalysis.Syntax
{
    public sealed class SyntaxTree
    {
        public SourceText Text { get; }
        public ImmutableArray<Diagnostic> Diagnostics { get; }
        public CompilationUnitSyntax Root { get; }

        private SyntaxTree(SourceText text)
        {
            var parser = new Parser(text);
            var root =  parser.ParseCompilationUnit();
            var diagnostics = parser.Diagnostics.ToImmutableArray();

            Root = root;
            Text = text;
            Diagnostics = diagnostics;
        }

        public static SyntaxTree Parse(string text)
        {
            var sourceText = SourceText.From(text);
            return Parse(sourceText);
        }

        public static SyntaxTree Parse(SourceText text)
        {
            return new SyntaxTree(text);
        }

        public static IEnumerable<SyntaxToken> ParseTokens(string text)
        {
            var sourceText = SourceText.From(text);
            return ParseTokens(sourceText);
        }

        public static IEnumerable<SyntaxToken> ParseTokens(SourceText text)
        {
            var lexer = new Lexer(text);
            while (true)
            {
                var token = lexer.Lex();
                if (token.Kind == SyntaxKind.EndOfFileToken)
                    break;

                yield return token;
            }
        }
    }
}