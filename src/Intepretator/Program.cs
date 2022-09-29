using System.Text;
using Zamai.Lexer;

namespace Zamai.Intepretator;

static class Program
{
    static void Task2()
    {
        var content = File.ReadAllText("../../../sample.zm", Encoding.UTF8);
        var lexer = new Parser(content);

        var userInput = Console.ReadLine();
        lexer.FindHashChain(userInput);
        
        
        
        var content1 = File.ReadAllText("../../../sample.zm", Encoding.UTF8);
        var lexer1 = new Parser(content);

        var userInput1 = Console.ReadLine();
        lexer1.FindBinaryTree(userInput1);
    }
    
    static void Main()
    {
        // Task2();
        
        var content1 = File.ReadAllText("../../../sample.zm", Encoding.UTF8);
        var lexer = new Parser(content1);
        lexer.PrintHashChain(lexer.ChainParse());
    }    
}

