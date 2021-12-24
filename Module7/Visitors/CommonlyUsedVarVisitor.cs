using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgramTree;

namespace SimpleLang.Visitors
{
    public class CommonlyUsedVarVisitor : AutoVisitor
    {
        private Dictionary<string,int> d = new Dictionary<string,int>();
        public string mostCommonlyUsedVar()
        {
            string result = "";
            int max = 0;
            foreach (var x in d.Keys)
            {
                if (d[x] > max)
                {
                    result = x;
                    max = d[x];
                }
            }
            return result;
        }
        public override void VisitIdNode(IdNode id) {
            if (!d.ContainsKey(id.Name))
                d.Add(id.Name, 0);
            d[id.Name]++;
        }
    }
}
