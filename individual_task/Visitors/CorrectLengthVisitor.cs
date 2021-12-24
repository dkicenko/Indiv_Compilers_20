using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramTree;

namespace SimpleLang.Visitors
{
    class CorrectLengthVisitor : AutoVisitor
    {

        public Dictionary<string, int> arrays = new Dictionary<string, int>();
        public List<string> ids = new List<string>();
        public int correct;
        public override void VisitAssignNode(AssignNode a)
        {
            correct = 0;
            a.Expr.Visit(this);
            int reallen;
            if (a.Id is SliceNode)
            {
                
                if ((a.Id as SliceNode).Stop == int.MaxValue)
                    (a.Id as SliceNode).Stop = arrays[(a.Id as SliceNode).Name];
                reallen = ((a.Id as SliceNode).Stop - (a.Id as SliceNode).Start)/ (a.Id as SliceNode).Step;
                if (((a.Id as SliceNode).Stop - (a.Id as SliceNode).Start) % (a.Id as SliceNode).Step == 0 && (a.Id as SliceNode).Step != 1)
                    reallen++;
                if (reallen < correct)
                    throw new Exception("Несовпадение размеров массивов");
            }
            if (a.Id is IdNode)
            {
               
                reallen = arrays[(a.Id as IdNode).Name];
                if (reallen < correct)
                    throw new Exception("Несовпадение размеров массивов");
            }
           
        }
        public override void VisitVarDefNode(VarDefNode w)
        {            
            foreach (var v in w.Ids)
            {
                if (v is ArrayNode)
                {
                   
                    arrays[(v as ArrayNode).Name] = (v as ArrayNode).Length;
                }
                if (v is IdNode)
                {
                   
                    ids.Add((v as IdNode).Name);
                }
            }
           
        }
        public override void VisitArrayNode(ArrayNode w)
        {
            correct += w.Length;
        }

        public override void VisitSliceNode(SliceNode w)
        {
            if (w.Stop == int.MaxValue)
                w.Stop = arrays[w.Name];
            correct += (w.Stop - w.Start) / w.Step;
            if ((w.Stop - w.Start) % w.Step != 0 && w.Step != 1)
                correct++;
        }

        public override void VisitIdNode(IdNode w)
        {
            if (arrays.ContainsKey(w.Name))
                correct += arrays[w.Name];
        }

        public override void VisitBinOpNode(BinaryNode binop)
        {
           
            binop.Left.Visit(this);
            binop.Right.Visit(this);
        }
    }
}
