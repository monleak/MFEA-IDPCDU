using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.Growing_Path_Algorithm;

namespace MFEA_IDPCDU.basic
{
    public class MFEA_Population
    {
        public List<Individual> individuals; //Danh sách cá thể
        public Individual best; //Cá thể tốt nhất
        public int task;
        public double[] rmp; //Tỉ lệ lai ghép liên tác vụ

        public MFEA_Population(int task)
        {
            this.individuals = new List<Individual>();
            this.task = task;
        }
        public void randomInit()
        {
            this.individuals.Clear();
            for(int i = 0; i < Params.MAX_POP_SIZE; i++)
            {
                Individual indiv = new Individual(task);
                indiv.randomInit();
                individuals.Add(indiv);
            }
            rmp = new double[Params.List_graph.Count];
            Array.Fill(this.rmp, 0.5);
        }
        public void update()
        {
            //Sắp xếp cá thể trong quần thể
            this.individuals.Sort();
            //Chọn cá thể tốt nhất
            if(best == null || best.cost > this.individuals[0].cost)
                this.best = this.individuals[0];
            //Loại bỏ những cá thể tồi
            int plan_pop_size = Params.MAX_POP_SIZE;
            while(this.individuals.Count > plan_pop_size)
            {
                this.individuals.RemoveAt(this.individuals.Count - 1);
            }
        }
    }
}
