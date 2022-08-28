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
                MFEA_Population subPop = new MFEA_Population(i);
                subPop.randomInit();
                pop.Add(subPop);
            }
        }
        public List<Individual> run1()
        {
            List<Individual> output = new List<Individual>(); //Trả về 1 list các cá thể con tốt nhất
            Params.maxEvals = Params.List_graph.Count * Params.MAX_EVALS_PER_TASK;
            while(Params.countEvals < Params.maxEvals)
            {
                for(int task = 0;task < Params.List_graph.Count; task++)
                {
                    List<Individual> offspring = new List<Individual>();
                    foreach (Individual indiv in pop[task].individuals)
                    {
                        int t = Params.random.Next(0, Params.List_graph.Count);
                        if(t == task)
                        {
                            //Lai ghép cùng tác vụ
                        }
                        else
                        {
                            //Lai ghép khác tác vụ
                        }
                    }
                }
               
            }
            return output;
        }
    }
}
