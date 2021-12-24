using System;
using System.IO;
using SimpleScanner;
using ScannerHelper;
using System.Collections.Generic;

namespace  GeneratedLexer
{
    
    public class LexerAddon
    {
        public Scanner myScanner;
        private byte[] inputText = new byte[255];

        public int idCount = 0;
        public int minIdLength = Int32.MaxValue;
        public double avgIdLength = 0;
        public int maxIdLength = 0;
        public int sumInt = 0;
        public double sumDouble = 0.0;
        public List<string> idsInComment = new List<string>();
        public double sumidlen = 0;

        public LexerAddon(string programText)
        {
            
            using (StreamWriter writer = new StreamWriter(new MemoryStream(inputText)))
            {
                writer.Write(programText);
                writer.Flush();
            }
            
            MemoryStream inputStream = new MemoryStream(inputText);
            
            myScanner = new Scanner(inputStream);
        }

        public void Lex()
        {
            // Чтобы вещественные числа распознавались и отображались в формате 3.14 (а не 3,14 как в русской Culture)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            int tok = 0;
            do {
                tok = myScanner.yylex();
                if (tok == (int)Tok.INUM)
                {                    
                    sumInt += myScanner.LexValueInt;
                }
                if (tok == (int)Tok.RNUM)
                {
                    sumDouble += myScanner.LexValueDouble;
                }
                if (tok == (int)Tok.ID)
                {
                    idCount++;
                    sumidlen += myScanner.yytext.Length;
                    if (myScanner.yytext.Length < minIdLength)
                        minIdLength = myScanner.yytext.Length;
                    if (myScanner.yytext.Length > maxIdLength)
                        maxIdLength = myScanner.yytext.Length;
                }
                /*if (tok == (int)Tok.COMMENT)
                {
                    while (tok != (int)Tok.LONGCOMMENT)
                    {
                        tok = myScanner.yylex();
                        if (tok == (int)Tok.ID)
                        {
                            idsInComment.Add(myScanner.yytext);
                        }
                        if (tok == (int)Tok.EOF)
                        {
                            if (idCount != 0)
                                avgIdLength = sumidlen / idCount;
                            break;
                        }
                    }
                }*/
                if (tok == (int)Tok.EOF)
                {
                    foreach (string s in myScanner.ids)
                        idsInComment.Add(s);
                    if (idCount != 0)
                        avgIdLength = sumidlen / idCount;
                    break;
                }
            } while (true);
        }
    }
}

