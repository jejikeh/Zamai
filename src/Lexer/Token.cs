namespace Zamai.Lexer;

public class Token
{
    internal Specification.TokenType Type { get; set; }
    internal object Value { get; set; }

    public Token(Specification.TokenType tokenType, object value)
    {
        Type = tokenType;
        Value = value;
    }
}