using System.Text;
using Microsoft.VisualBasic;

namespace Zamai.Lexer;

public class Parser
{
    private string _input;
    private Token? _nextToken;
    private Tokenizer _tokenizer;

    public Parser(string input)
    {
        _input = input;
        _tokenizer = new Tokenizer(input);
        _nextToken = _tokenizer.GetNextToken();
    }

    public Dictionary<string,Token> ChainParse()
    {
        var tokens = new Dictionary<string, Token>();
        while (_nextToken != null)
        {
            var hash = Encoding.ASCII.GetBytes(_nextToken.Value.ToString());
            
            while (tokens.ContainsKey(ByteArrayToString(hash)))
                hash = Encoding.ASCII.GetBytes($"{new Random().Next(1000,9999)}");

            tokens.Add(ByteArrayToString(hash),_nextToken);
            _nextToken = _tokenizer.GetNextToken();
        }

        return tokens;
    }
    
    internal NodeToken BinaryTreeParse()
    {
        var token = new NodeToken(_nextToken);
        _nextToken = _tokenizer.GetNextToken();
        while (_nextToken != null)
        {
            token.AddNeibour(new NodeToken(_nextToken));
            _nextToken = _tokenizer.GetNextToken();
        }

        return token;
    }

    public void PrintHashChain(Dictionary<string, Token> tokens)
    {
        foreach (var token in tokens)
        {
            Console.Write($"{token.Key}: {token.Value.Type} - {token.Value.Value}\n");
        }
    }

    public void FindHashChain(string searchToken)
    {
        var tokens = ChainParse();
        PrintHashChain(tokens);
        
        if (tokens.ContainsKey(ByteArrayToString(Encoding.ASCII.GetBytes(searchToken))))
        {
            Console.WriteLine($"Found, {tokens[ByteArrayToString(Encoding.ASCII.GetBytes(searchToken))].Value}, HASH:{ByteArrayToString(Encoding.ASCII.GetBytes(searchToken))}");
            return;
        }
        
        Console.WriteLine("Not found");
    }
    
    public void FindBinaryTree(string searchToken)
    {
        var tokens = BinaryTreeParse();
        PrintBinaryTreeAndSearch(tokens,searchToken);
        
    }
    
    public void PrintBinaryTreeAndSearch(NodeToken tree, string search)
    {
        PrintNodeAndSearch(tree, search);
    }
    
    private void PrintNodeAndSearch(NodeToken nodeToken, string search)
    {
        Console.Write($"{nodeToken.Value} ");
        if (nodeToken.Value == search)
        {
            Console.WriteLine("FOUND");
            return;
        }
        
        if (nodeToken.Left is not null)
        {
            PrintNodeAndSearch(nodeToken.Left, search);
        }

        if (nodeToken.Right is not null)
        {
            PrintNodeAndSearch(nodeToken.Right , search);
        }
    }
    
    static string ByteArrayToString(byte[] arrInput)
    {
        int i;
        StringBuilder sOutput = new StringBuilder(arrInput.Length);
        for (i=0;i < arrInput.Length; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }
}