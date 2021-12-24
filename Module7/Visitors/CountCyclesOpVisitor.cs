using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class CountCyclesOpVisitor : AutoVisitor
    {
        int countcycles = 0;
        int countop = 0;
        int tekc = 0;
        public int MidCount()
        {
            return (countop == 0) ? 0 : countop / countcycles;
        }
        public override void VisitCycleNode(CycleNode c)
        {
            tekc++;
            countcycles++;
            c.Stat.Visit(this);
            tekc--;
        }
        public override void VisitAssignNode(AssignNode assign)
        {
            if (tekc != 0)
                countop++;
        }

        public override void VisitWriteNode(WriteNode w)
        {
            if (tekc != 0)
                countop++;
        }
    }
}
