using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using SimpleScanner;
using SimpleParser;
using SimpleLang.Visitors;

namespace SimpleCompiler
{
    public class SimpleCompilerMain
    {
        public static void Main()
        {
            string FileName = @"..\..\a.txt";
            try
            {
                string Text = File.ReadAllText(FileName);

                Scanner scanner = new Scanner();
                scanner.SetSource(Text, 0);

                Parser parser = new Parser(scanner);

                var b = parser.Parse();
                if (!b)
                    Console.WriteLine("Ошибка");
                else
                {
                    Console.WriteLine("Синтаксическое дерево построено");

                    var acVisitor = new AssignCountVisitor();
                    parser.root.Visit(acVisitor);
                    Console.WriteLine("Количество присваиваний = {0}", acVisitor.Count);
                    Console.WriteLine("-------------------------------");

                    var ppVisitor = new PrettyPrintVisitor();
                    parser.root.Visit(ppVisitor);
                    Console.WriteLine(ppVisitor.Text);
                    Console.WriteLine("-------------------------------");

                    var gcVisitor = new GenCodeVisitor();
                    parser.root.Visit(gcVisitor);
                    gcVisitor.EndProgram();
                    Console.WriteLine("-------------------------------");

                    gcVisitor.RunProgram();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл {0} не найден", FileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e);
            }

            Console.ReadLine();
        }

    }
}
