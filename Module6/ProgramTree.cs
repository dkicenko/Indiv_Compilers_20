using System.Collections.Generic;

namespace ProgramTree
{
    public enum AssignType { Assign, AssignPlus, AssignMinus, AssignMult, AssignDivide };

    public class Node // базовый класс для всех узлов    
    {
    }

    public class ExprNode : Node // базовый класс для всех выражений
    {
    }

    public class IdNode : ExprNode
    {
        public string Name { get; set; }
        public IdNode(string name) { Name = name; }
    }

    public class IntNumNode : ExprNode
    {
        public int Num { get; set; }
        public IntNumNode(int num) { Num = num; }
    }

    public class StatementNode : Node // базовый класс для всех операторов
    {
    }

    public class AssignNode : StatementNode
    {
        public IdNode Id { get; set; }
        public ExprNode Expr { get; set; }
        public AssignType AssOp { get; set; }
        public AssignNode(IdNode id, ExprNode expr, AssignType assop = AssignType.Assign)
        {
            Id = id;
            Expr = expr;
            AssOp = assop;
        }
    }

    public class CycleNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode Stat { get; set; }
        public CycleNode(ExprNode expr, StatementNode stat)
        {
            Expr = expr;
            Stat = stat;
        }
    }

    public class BlockNode : StatementNode
    {
        public List<StatementNode> StList = new List<StatementNode>();
        public BlockNode(StatementNode stat)
        {
            Add(stat);
        }
        public void Add(StatementNode stat)
        {
            StList.Add(stat);
        }
    }
    public class WhileNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode Stat { get; set; }
        public WhileNode(ExprNode expr, StatementNode stat)
        {
            Expr = expr;
            Stat = stat;
        }
    }
    public class RepeatNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode Stat { get; set; }
        public RepeatNode(ExprNode expr, StatementNode stat)
        {
            Expr = expr;
            Stat = stat;
        }
    }
    public class ForNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode Stat { get; set; }
        public StatementNode Assign { get; set; }
        public ForNode(StatementNode assign, ExprNode expr, StatementNode stat)
        {
            Assign = assign;
            Expr = expr;
            Stat = stat;
        }
    }
    public class WriteNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public WriteNode(ExprNode expr)
        {
            Expr = expr;
        }
    }
    public class IfNode : StatementNode
    {
        public ExprNode Expr { get; set; }
        public StatementNode Then { get; set; }
        public StatementNode Else { get; set; }
        public IfNode(ExprNode expr, StatementNode t, StatementNode e)
        {
            Expr = expr;
            Then = t;
            Else = e;
        }
    }
    public class BinaryNode : ExprNode
    {
        public ExprNode Left;
        public ExprNode Right;
        public char operation;
        public BinaryNode()
        {
            Left = null;
            Right = null;

        }
        public BinaryNode(ExprNode left, ExprNode right, char c)
        {
            Left = left;
            Right = right;
            operation = c;
        }
    }

    public class VarDefNode : StatementNode
    {
        public List<ExprNode> Ids = new List<ExprNode>();
        public VarDefNode(string n, int m)
        {
            Ids.Add(new ArrayNode(n, m));
        }
        public void Add(IdNode id)
        {
            Ids.Add(id);
        }
    }
    public class ArrayNode : ExprNode
    {
        string id;
        int length;
        public ArrayNode(string i, int leng)
        {
            id = i;
            length = leng;
        }
    }
}
