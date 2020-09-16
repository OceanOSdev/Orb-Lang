﻿using System;
using System.IO;
using System.Linq;
using Orb.CodeAnalysis;
using Orb.CodeAnalysis.Syntax;
using Orb.IO;

namespace Orb
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Usage: orbc <source-paths>");
                return;
            }

            if (args.Length > 1)
            {
                Console.Error.WriteLine("Error: only one path supported.");
                return;
            }

            var path = args.Single();

            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"Error: file '{path}' does not exist.");
                return;
            }

            var syntaxTree = SyntaxTree.Load(path);

            var compilation = new Compilation(syntaxTree);
            var result = compilation.Evaluate();

            if (!result.Diagnostics.Any())
            {
                if (result.Value != null)
                    Console.WriteLine(result.Value);
            }
            else
            {
                Console.Error.WriteDiagnostics(result.Diagnostics);
            }
        }
    }
}
