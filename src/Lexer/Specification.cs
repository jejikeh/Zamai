using System.Text.RegularExpressions;

namespace Zamai.Lexer;

public class Specification
{
    public enum TokenType
    {
        Number,
        String,
        Body,
        If,
        Else,
        Expression,
        Function,
        Identifier,
        For,
        Do
    }

    internal static readonly Dictionary<Regex, TokenType?> RegularExpressionRules = new Dictionary<Regex, TokenType?>
    {
        // white spaces
        {new Regex(@"^\s+"), null},
        // single line comments  :
        // {new Regex(@"^\:.*"), null}, error, if multiline then anyways detect 
        // multiple line comments  :: ::
        {new Regex(@"^\:\:[\s\S]*?\:\:", RegexOptions.Multiline), null},
        // digits
        {new Regex(@"^\d+"), TokenType.Number},
        // Commas "
        {new Regex(@"^""[^""]*""", RegexOptions.Multiline), TokenType.String},
        // Commas '
        {new Regex(@"^'[^']*'", RegexOptions.Multiline), TokenType.String},
        {new Regex(@"^\([^""]*\)", RegexOptions.Multiline), TokenType.Expression},
        {new Regex(@"^if", RegexOptions.Multiline), TokenType.If},
        {new Regex(@"^for", RegexOptions.Multiline), TokenType.For},
        {new Regex(@"^do", RegexOptions.Multiline), TokenType.Do},
        {new Regex(@"^{[\s\S]*}", RegexOptions.Multiline), TokenType.Body},
        {new Regex(@"^else", RegexOptions.Multiline), TokenType.Else},
        {new Regex(@"^fn", RegexOptions.Multiline), TokenType.Function},
        {new Regex(@"^[\w]*", RegexOptions.Multiline), TokenType.Identifier}
    };
}