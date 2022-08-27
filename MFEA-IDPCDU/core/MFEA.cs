using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.basic;

namespace MFEA_IDPCDU.core
{
    internal class MFEA
    {
        List<MFEA_Population> pop;

        public MFEA()
        {
            pop = new List<MFEA_Population>();
            for(int i = 0; i < Params.List_graph.Count; i++)
            {
                MFEA_Population subPop = new MFEA_Population();
                subPop.randomInit();
                pop.Add(subPop);
            }
        }
        public List<Individual> run1()
        {
            List<Individual> output = new List<Individual>(); //Trả về 1 list các cá thể con tốt nhất

            return output;
        }
    }
}
