namespace Zamai.Lexer;

internal class Tokenizer
{
    private int _cursor;
    private string _input;

    public Tokenizer(string input)
    {
        _input = input;
        _cursor = 0;
    }

    public Token? GetNextToken()
    {
        if (_cursor == _input.Length)
            return null;

        var str = _input[_cursor..];
        foreach(var expressionRule in Specification.RegularExpressionRules)
        {
            var matched = expressionRule.Key.Match(str);
            if (matched.Success)
            {
                _cursor += matched.Value.Length;
                if (expressionRule.Value == null)
                    return GetNextToken();
                
                return new Token((Specification.TokenType)expressionRule.Value, matched.Value);
            }
        }
        
        return null;
    }
}