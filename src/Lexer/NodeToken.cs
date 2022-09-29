namespace Zamai.Lexer;

public class NodeToken
{
    public string Value;
    public NodeToken? Left;
    public NodeToken? Right;

    public NodeToken(Token token)
    {
        Value = token.Value.ToString();
    }

    public void AddNeibour(NodeToken node)
    {
        if (AlphabeticalMoreThan(node.Value, Value))
        {
            if (Right is null)
            {
                Right = node;
            }
            else
            {
                Right.AddNeibour(node);
            }
        }
        else
        {
            if (Left is null)
            {
                Left = node;
            }
            else
            {
                Left.AddNeibour(node);
            }
        }
    }

    private bool AlphabeticalMoreThan(string a, string b)
    {
        while (a.Length > 0 && b.Length > 0)
        {
            if (a[0] < b[0])
                return false;
            
            if (a[0] > b[0])
                return true;

            a = a[1..];
            b = b[1..];
        }

        return false;
    }
}