using System;
using System.Collections.Generic;

class Parser
{
    private string[] tokens;
    private int index;

    public Parser(string input)
    {
        
        tokens = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        index = 0;
    }

    public void ParseList()
    {
        ParseItem();
        ParseRest();
    }

    public void ParseRest()
    {
        if (index < tokens.Length && tokens[index] == ",")
        {
          
            index++;
            ParseItem();
            ParseRest();
        }
        // Else, it's ε (empty), do nothing
    }

    public void ParseItem()
    {
        if (index < tokens.Length)
        {
            string token = tokens[index];
            if (IsValidItem(token))
            {
                
                Console.WriteLine("Parsed: " + token);
                index++;
            }
            else
            {
                Console.WriteLine("Error: Expected 'id', 'num', or 'string', but found '" + token + "'");
            }
        }
        else
        {
            Console.WriteLine("Error: Unexpected end of input");
        }
    }

    private bool IsValidItem(string token)
    {
        return token == "id" || token == "num" || token == "string";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string input = "id , num , string";
        Parser parser = new Parser(input);

     
        parser.ParseList();
    }
}
