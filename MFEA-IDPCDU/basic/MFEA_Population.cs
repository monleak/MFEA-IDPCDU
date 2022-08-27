using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.Growing_Path_Algorithm;

namespace MFEA_IDPCDU.basic
{
    internal class MFEA_Population
    {
        List<Individual> individuals; //Danh sách cá thể
        Individual best; //Cá thể tốt nhất
        int task;

        public MFEA_Population()
        {
            individuals = new List<Individual>();
            best = new Individual();
        }
        public void randomInit()
        {
            this.individuals.Clear();
            for(int i = 0; i < Params.sizePop; i++)
            {
                Individual indiv = new Individual();
                indiv.randomInit();
                indiv.cost = GPA.calCost(GPA.runGPA(indiv, task));
                individuals.Add(indiv);
            }
        }
    }
}
