using System;
using System.Collections.Generic;
using System.Text;
using SimpleLexer;
namespace SimpleLangParser
{
    public class ParserException : System.Exception
    {
        public ParserException(string msg)
            : base(msg)
        {
        }

    }

    public class Parser
    {
        private SimpleLexer.Lexer l;

        public Parser(SimpleLexer.Lexer lexer)
        {
            l = lexer;
        }

        public void Progr()
        {
            Block();
        }
        public void Expr()
        {
            T();
            A();
        }
        public void T()
        {
            M();
            B();
        }
        public void A()
        {
            if (l.LexKind == Tok.PLUS || l.LexKind == Tok.MINUS)
            {
                l.NextLexem();
                T();
                A();
            }
        }
        public void B()
        {
            if (l.LexKind == Tok.MULT || l.LexKind == Tok.DIVISION)
            {
                l.NextLexem();
                M();
                B();
            }            
        }
        public void M()
        {
            if (l.LexKind == Tok.LEFT_BRACKET)
            {
                l.NextLexem();
                Expr();
                if (l.LexKind != Tok.RIGHT_BRACKET)
                    SyntaxError("right bracket expected");
                l.NextLexem();
            }
            else if (l.LexKind == Tok.ID || l.LexKind == Tok.INUM)
            {
                l.NextLexem();
            }
        }

        public void Assign() 
        {
            l.NextLexem();  // пропуск id
            if (l.LexKind == Tok.ASSIGN)
            {
                l.NextLexem();
            }
            else {
                SyntaxError(":= expected");
            }
            Expr();
        }

        public void StatementList() 
        {
            Statement();
            while (l.LexKind == Tok.SEMICOLON)
            {
                l.NextLexem();
                Statement();
            }
        }

        public void Statement() 
        {
            switch (l.LexKind)
            {
                case Tok.BEGIN:
                    {
                        Block(); 
                        break;
                    }
                case Tok.CYCLE:
                    {
                        Cycle(); 
                        break;
                    }
                case Tok.ID:
                    {
                        Assign();
                        break;
                    }
                case Tok.WHILE:
                    {
                        l.NextLexem();
                        Expr();
                        if (l.LexKind == Tok.DO)
                        {
                            l.NextLexem();
                            StatementList();
                        }
                        else
                            SyntaxError("do expected");
                        break;
                    }
                case Tok.FOR:
                    {
                        l.NextLexem();
                        if (l.LexKind != Tok.ID)
                            SyntaxError("id expected");
                        l.NextLexem();
                        if (l.LexKind != Tok.ASSIGN)
                            SyntaxError("assign expected");
                        l.NextLexem();
                        Expr();
                        if (l.LexKind != Tok.TO)
                            SyntaxError("to expected");
                        l.NextLexem();
                        Expr();
                        if (l.LexKind != Tok.DO)
                            SyntaxError("do expected");
                        l.NextLexem();
                        Statement();
                        break;
                    }
                case Tok.END:
                    {
                        l.NextLexem();
                        StatementList();
                        break;
                    }
                case Tok.IF:
                    {
                        l.NextLexem();
                        Expr();
                        if (l.LexKind != Tok.THEN)
                            SyntaxError("then expected");
                        l.NextLexem();
                        Statement();
                        if (l.LexKind == Tok.ELSE)
                        {
                            l.NextLexem();
                            Statement();
                        }
                        break;
                    }
                default:
                    {
                        SyntaxError("Operator expected");
                        break;
                    }
            }
        }

        public void Block() 
        {
            l.NextLexem();    // пропуск begin
            StatementList();
            if (l.LexKind == Tok.END)
            {
                l.NextLexem();
            }
            else
            {
                SyntaxError("end expected");
            }

        }

        public void Cycle() 
        {
            l.NextLexem();  // пропуск cycle
            Expr();
            Statement();
        }

        public void SyntaxError(string message) 
        {
            var errorMessage = "Syntax error in line " + l.LexRow.ToString() + ":\n";
            errorMessage += l.FinishCurrentLine() + "\n";
            errorMessage += new String(' ', l.LexCol - 1) + "^\n";
            if (message != "")
            {
                errorMessage += message;
            }
            throw new ParserException(errorMessage);
        }
   
    }
}
