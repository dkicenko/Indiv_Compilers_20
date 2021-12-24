using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lexer
{

    public class LexerException : System.Exception
    {
        public LexerException(string msg)
            : base(msg)
        {
        }

    }

    public class Lexer
    {

        protected int position;
        protected char currentCh; // очередной считанный символ
        protected int currentCharValue; // целое значение очередного считанного символа
        protected System.IO.StringReader inputReader;
        protected string inputString;

        public Lexer(string input)
        {
            inputReader = new System.IO.StringReader(input);
            inputString = input;
        }

        public void Error()
        {
            System.Text.StringBuilder o = new System.Text.StringBuilder();
            o.Append(inputString + '\n');
            o.Append(new System.String(' ', position - 1) + "^\n");
            o.AppendFormat("Error in symbol {0}", currentCh);
            throw new LexerException(o.ToString());
        }

        protected void NextCh()
        {
            this.currentCharValue = this.inputReader.Read();
            this.currentCh = (char) currentCharValue;
            this.position += 1;
        }

        public virtual bool Parse()
        {
            return true;
        }
    }

    public class IntLexer : Lexer
    {

        protected System.Text.StringBuilder intString;
        public int parseResult = 0;

        public IntLexer(string input)
            : base(input)
        {
            intString = new System.Text.StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            bool flag = false;
            if (currentCh == '-')
            {
                flag = true;
            }
            else
            if (currentCh != '+')
                if (char.IsDigit(currentCh))
                {
                    parseResult = currentCh - '0';
                }
                else
                {
                    Error();
                }

            NextCh();
            while (char.IsDigit(currentCh))
            {
                parseResult = parseResult*10 + (currentCh - '0');
                NextCh();
            }

            if (flag)
                parseResult = -parseResult;
            if (currentCharValue != -1)
            {
                Error();
            }

            return true;

        }
    }
    
    public class IdentLexer : Lexer
    {
        private string parseResult;
        protected StringBuilder builder;
    
        public string ParseResult
        {
            get { return parseResult; }
        }
    
        public IdentLexer(string input) : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (char.IsLetter(currentCh) || currentCh == '_')
            {
                parseResult += currentCh;
                NextCh();
            }
            else
            {
                Error();
            }
            while(char.IsDigit(currentCh) || char.IsLetter(currentCh) || currentCh == '_')
            {
                parseResult += currentCh;
                NextCh();
            }
            if (currentCharValue != -1)
            {
                Error();
            }
            return true;
            //throw new NotImplementedException();
        }
       
    }

    public class IntNoZeroLexer : IntLexer
    {
        public IntNoZeroLexer(string input)
            : base(input)
        {
        }

        public override bool Parse()
        {
            NextCh();
            bool pol = false;
            if (currentCh == '+')
                pol = true;
            else {
                if (char.IsDigit(currentCh))
                {
                    if (currentCh == '0')
                        Error();
                    pol = true;
                    parseResult = parseResult * 10 + (currentCh - '0');
                }
                else
                {
                    if (currentCh != '-')
                        Error();
                }
            }
            NextCh();
            if (currentCh == '0' && parseResult == 0)
                Error();
            while (char.IsDigit(currentCh))
            {
                parseResult = parseResult*10 + (currentCh - '0');
                NextCh();
            }
            if (currentCharValue != -1)
            {
                Error();
            }
            if (!pol)
                parseResult = -parseResult;
            return true;
            //throw new NotImplementedException();
        }
    }

    public class LetterDigitLexer : Lexer
    {
        protected StringBuilder builder;
        protected string parseResult;

        public string ParseResult
        {
            get { return parseResult; }
        }

        public LetterDigitLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (char.IsLetter(currentCh))
                parseResult += currentCh;
            else
                Error();
            while (true)
            {
                NextCh();
                if (currentCharValue == -1)
                    break;
                if (char.IsDigit(currentCh))
                    parseResult += currentCh;
                else
                    Error();
                NextCh();
                if (currentCharValue == -1)
                    break;
                if (char.IsLetter(currentCh))
                    parseResult += currentCh;
                else
                    Error();
            }
            return true;
            //throw new NotImplementedException();
        }
       
    }

    public class LetterListLexer : Lexer
    {
        protected List<char> parseResult;

        public List<char> ParseResult
        {
            get { return parseResult; }
        }

        public LetterListLexer(string input)
            : base(input)
        {
            parseResult = new List<char>();
        }

        public override bool Parse()
        {
            NextCh();
            if (char.IsLetter(currentCh))
                parseResult.Add(currentCh);
            else
                Error();
            NextCh();
            while (currentCharValue != -1)
            {
                if (currentCh == ',' || currentCh == ';')
                    NextCh();
                else
                    Error();
                if (char.IsLetter(currentCh))
                    parseResult.Add(currentCh);
                else
                    Error();
                NextCh();
            }
            return true;
            //throw new NotImplementedException();
        }
    }

    public class DigitListLexer : Lexer
    {
        protected List<int> parseResult;

        public List<int> ParseResult
        {
            get { return parseResult; }
        }

        public DigitListLexer(string input)
            : base(input)
        {
            parseResult = new List<int>();
        }

        public override bool Parse()
        {
            NextCh();
            if (char.IsDigit(currentCh))
                parseResult.Add(currentCh-'0');
            else
                Error();
            NextCh();
            while (currentCharValue != -1)
            {
                if (char.IsDigit(currentCh))
                    Error();
                while (currentCh == ' ')
                    NextCh();
                if (char.IsDigit(currentCh))
                    parseResult.Add(currentCh-'0');
                else
                    Error();
                NextCh();
            }
            return true;
            //throw new NotImplementedException();
        }
    }

    public class LetterDigitGroupLexer : Lexer
    {
        protected StringBuilder builder;
        protected string parseResult;

        public string ParseResult
        {
            get { return parseResult; }
        }
        
        public LetterDigitGroupLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            int d = 0, c = 0;
            NextCh();
            if (char.IsLetter(currentCh))
            {
                builder.Append(currentCh);
                c++;
                d = 0;
            }
            else
                Error();
            while (true)
            {
                NextCh();
                if (currentCharValue == -1)
                    break;
                if (char.IsDigit(currentCh))
                {
                    builder.Append(currentCh);
                    d++;
                    c = 0;
                }
                else
                {
                    if (char.IsLetter(currentCh))
                    {
                        builder.Append(currentCh);
                        c++;
                        d = 0;
                    }
                    else
                        Error();
                }
                if (d > 2 || c > 2)
                    Error();
            }
            parseResult = builder.ToString();
            return true;
            //throw new NotImplementedException();
        }
       
    }

    public class DoubleLexer : Lexer
    {
        private StringBuilder builder;
        private double parseResult;

        public double ParseResult
        {
            get { return parseResult; }

        }

        public DoubleLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (char.IsDigit(currentCh))
                builder.Append(currentCh);
            else
                Error();
            NextCh();
            while (currentCh != '.')
            {
                if (currentCharValue == -1)
                {
                    string s1 = builder.ToString();
                    parseResult = double.Parse(s1, CultureInfo.InvariantCulture);
                    return true;
                }
                if (char.IsDigit(currentCh))
                    builder.Append(currentCh);
                else
                    Error();
                NextCh();
            }
            builder.Append(currentCh);
            NextCh();
            if (char.IsDigit(currentCh))
                builder.Append(currentCh);
            else
                Error();
            NextCh();
            while (currentCharValue != -1)
            {
                if (char.IsDigit(currentCh))
                    builder.Append(currentCh);
                else
                    Error();
                NextCh();
            }
            string s = builder.ToString();
            parseResult = double.Parse(s, CultureInfo.InvariantCulture);            
            return true;
            //throw new NotImplementedException();
        }
       
    }

    public class StringLexer : Lexer
    {
        private StringBuilder builder;
        private string parseResult;

        public string ParseResult
        {
            get { return parseResult; }

        }

        public StringLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (currentCh == '\'')
                builder.Append(currentCh);
            else
                Error();
            NextCh();
            while (currentCh != '\'')
            {
                if (currentCharValue == -1)
                    Error();
                builder.Append(currentCh);
                NextCh();
            }
            builder.Append(currentCh);
            NextCh();
            if (currentCharValue != -1)
                Error();
            parseResult = builder.ToString();

            return true;
            //throw new NotImplementedException();
        }
    }

    public class CommentLexer : Lexer
    {
        private StringBuilder builder;
        private string parseResult;

        public string ParseResult
        {
            get { return parseResult; }

        }

        public CommentLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
        }

        public override bool Parse()
        {
            NextCh();
            if (currentCh == '/')
                builder.Append(currentCh);
            else
                Error();
            NextCh();
            if (currentCh == '*')
                builder.Append(currentCh);
            else
                Error();
            NextCh();
            while (true)
            {
                if (currentCharValue == -1)
                    Error();
                if (currentCh == '*')
                {
                    builder.Append(currentCh);
                    NextCh();
                    if (currentCh == '/')
                        break;
                }
                else
                {
                    builder.Append(currentCh);
                    NextCh();
                }
            }
            builder.Append(currentCh);
            NextCh();
            if (currentCharValue != -1)
                Error();
            parseResult = builder.ToString();

            return true;
            //throw new NotImplementedException();
        }
    }

    public class IdentChainLexer : Lexer
    {
        private StringBuilder builder;
        private List<string> parseResult;

        public List<string> ParseResult
        {
            get { return parseResult; }

        }

        public IdentChainLexer(string input)
            : base(input)
        {
            builder = new StringBuilder();
            parseResult = new List<string>();
        }

        public override bool Parse()
        {
            foreach (string x in inputString.Split('.')) {
                IdentLexer L = new IdentLexer(x);
                L.Parse();
                parseResult.Add(L.ParseResult);
            }
            return true;
            //throw new NotImplementedException();
        }
    }

    public class Program
    {
        public static void Main()
        {
            string input = "154216";
            IntLexer L1 = new IntLexer(input);
            try
            {
                L1.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            Console.WriteLine(L1.parseResult);
            input = "if5";
            IdentLexer L2 = new IdentLexer(input);
            try
            {
                L2.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            Console.WriteLine(L2.ParseResult);
            input = "-143";
            IntNoZeroLexer L3 = new IntNoZeroLexer(input);
            try
            {
                L3.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            Console.WriteLine(L3.parseResult);
            input = "a4a7";
            LetterDigitLexer L4 = new LetterDigitLexer(input);
            try
            {
                L4.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            Console.WriteLine(L4.ParseResult);
            input = "a,b;c";
            LetterListLexer L5 = new LetterListLexer(input);
            try
            {
                L5.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            string s = "";
            for (int i = 0; i < L5.ParseResult.Count; i++)
                s+= L5.ParseResult[i];
            Console.WriteLine(s);
            input = "4 5  4";
            DigitListLexer L6 = new DigitListLexer(input);
            try
            {
                L6.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            s = "";
            for (int i = 0; i < L6.ParseResult.Count; i++)
               s += (char)L6.ParseResult[i];
            Console.WriteLine(s);

            input = "aa4b44";
            LetterDigitGroupLexer L7 = new LetterDigitGroupLexer(input);
            try
            {
                L7.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            Console.WriteLine(L7.ParseResult);

            input = "123.4";
            DoubleLexer L8 = new DoubleLexer(input);
            try
            {
                L8.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            Console.WriteLine(L8.ParseResult);
            input = "'fgdg45h'";
            StringLexer L9 = new StringLexer(input);
            try
            {
                L9.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            Console.WriteLine(L9.ParseResult);
            input = "/*dfs*3f*/";
            CommentLexer L10 = new CommentLexer(input);
            try
            {
                L10.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            Console.WriteLine(L10.ParseResult);
            input = "f433.g43.gf";
            IdentChainLexer L11 = new IdentChainLexer(input);
            try
            {
                L11.Parse();
            }
            catch (LexerException e)
            {
                System.Console.WriteLine(e.Message);
            }
            s = "";
            foreach (string x in L11.ParseResult)
                Console.WriteLine(x);
        }
    }
}
