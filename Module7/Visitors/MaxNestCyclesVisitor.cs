using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class MaxNestCyclesVisitor : AutoVisitor
    {
        public int MaxNest = 0;
        int tekc = 0;
        public override void VisitCycleNode(CycleNode c)
        {
            tekc++;
            if (tekc > MaxNest)
                MaxNest = tekc;
            c.Stat.Visit(this);
            tekc--;
        }
    }
}
