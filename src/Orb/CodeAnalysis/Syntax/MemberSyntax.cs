namespace Orb.CodeAnalysis.Syntax
{
    // This represents what ever you can put in a file
    // TODO: maybe rename this to CompilationUnitMemberSyntax
    public abstract class MemberSyntax : SyntaxNode
    {
        protected MemberSyntax(SyntaxTree syntaxTree)
            : base(syntaxTree)
        {

        }
    }
}