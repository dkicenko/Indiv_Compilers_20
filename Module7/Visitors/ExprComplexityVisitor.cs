using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class ExprComplexityVisitor : AutoVisitor
    {
        List<int> l = new List<int>();
        int tekid = -1;
        // список должен содержать сложность каждого выражения, встреченного при обычном порядке обхода AST
        public List<int> getComplexityList()
        {
            return l;
        }

        public override void VisitCycleNode(CycleNode c) {
            tekid++;
            l.Add(0);
            c.Expr.Visit(this);
            c.Stat.Visit(this);
        }
        public override void VisitAssignNode(AssignNode assign)
        {
            tekid++;
            l.Add(0);
            assign.Expr.Visit(this);
        }

        public override void VisitWriteNode(WriteNode w)
        {
            tekid++;
            l.Add(0);
            w.Expr.Visit(this);
        }
        public override void VisitBinOpNode(BinOpNode binop)
        {
            help(binop, tekid);
        }
        private void help(BinOpNode binop, int num)
        {
            if ("ProgramTree.BinOpNode".CompareTo(binop.Right.ToString()) == 0 &&
                "ProgramTree.BinOpNode".CompareTo(binop.Left.ToString()) == 0)
                return;
            l[num] += (binop.Op == '-' || binop.Op == '+') ? 1 : 3;
            if ("ProgramTree.BinOpNode".CompareTo(binop.Right.ToString()) == 0)
                help((BinOpNode)binop.Right, num);
            if ("ProgramTree.BinOpNode".CompareTo((string)binop.Left.ToString()) == 0)
                help((BinOpNode)binop.Left, num);
        }
    }
}
