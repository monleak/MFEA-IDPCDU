using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.basic;
using MFEA_IDPCDU.util.crossover;
using MFEA_IDPCDU.util.mutation;
using MFEA_IDPCDU.util;

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
                subPop.update();
                pop.Add(subPop);
            }
        }
        public List<Individual> run1()
        {
            List<Individual> output = new List<Individual>(); //Trả về 1 list các cá thể con tốt nhất
            Params.maxEvals = Params.List_graph.Count * Params.MAX_EVALS_PER_TASK;
            int theHe = 0; //Biến đếm thế hệ
            while(Params.countEvals < Params.maxEvals && theHe < 500)
            {
                Console.Write(theHe++ + " "+ Params.countEvals+" | ");
                for(int task = 0;task < Params.List_graph.Count; task++)
                {
                    Console.Write(pop[task].best.cost + " ");
                    List<Individual> offspring = new List<Individual>();
                    foreach (Individual indiv in pop[task].individuals)
                    {
                        int t = Params.random.Next(0, Params.List_graph.Count);
                        if(t == task)
                        {
                            //Lai ghép cùng tác vụ
                            Individual indiv2 = pop[t].individuals[Params.random.Next(0, pop[t].individuals.Count)];
                            while(indiv2.Individual_Id == indiv.Individual_Id)
                            {
                                indiv2 = pop[t].individuals[Params.random.Next(0, pop[t].individuals.Count)];
                            }
                            offspring.AddRange(Crossover.runCrossover(indiv, indiv2));
                        }
                        else
                        {
                            if (Params.random.NextDouble() < Params.rmp)
                            {
                                //Lai ghép khác tác vụ
                                Individual indiv2 = pop[t].individuals[Params.random.Next(0, pop[t].individuals.Count)];
                                while (indiv2.Individual_Id == indiv.Individual_Id)
                                {
                                    indiv2 = pop[t].individuals[Params.random.Next(0, pop[t].individuals.Count)];
                                }
                                offspring.AddRange(Crossover.runCrossover(indiv, indiv2));
                            }
                            else
                            {
                                //Lai ghép cùng tác vụ
                                Individual indiv2 = pop[task].individuals[Params.random.Next(0, pop[task].individuals.Count)];
                                while (indiv2.Individual_Id == indiv.Individual_Id)
                                {
                                    indiv2 = pop[task].individuals[Params.random.Next(0, pop[task].individuals.Count)];
                                }
                                offspring.AddRange(Crossover.runCrossover(indiv, indiv2));
                            }
                        }
                    }
                    pop[task].individuals.AddRange(offspring);
                    pop[task].update();
                }
                Console.Write("\n");
            }

            for(int task = 0; task < Params.List_graph.Count; task++)
            {
                output.Add(pop[task].best);
            }
            return output;
        }
    }
}
