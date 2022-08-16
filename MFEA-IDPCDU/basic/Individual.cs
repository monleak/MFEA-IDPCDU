using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MFEA_IDPCDU.Graph;

namespace MFEA_IDPCDU.basic
{
    internal class Individual
    {
        private static int counter = 0;

        MFEA_IDPCDU.Graph.Graph graph;
        int Individual_Id;
        int[] Priority;
        int[] Out_Edge_Index;

        public Individual(Graph.Graph new_graph)
        {
            this.Individual_Id = Individual.counter++;
            this.Priority = new int[new_graph.N];
            this.Out_Edge_Index = new int[new_graph.N];
            this.graph = new_graph;
        }

        public void randomInit()
        {
            for(int i=0;i< this.graph.N; i++)
            {
                //Tạo 1 mảng {1,2,3,...,N}
                this.Priority[i] = i + 1;
            }
            Random random = new Random(Params.SEED_RANDOM);
            for(int i=0;i< this.graph.N; i++)
            {   
                //Hoán vị mảng vừa tạo N lần
                int temp1 = random.Next(1, this.graph.N);
                int temp2 = random.Next(1, this.graph.N);
                int temp = this.Priority[temp1];
                this.Priority[temp1] = this.Priority[temp2];
                this.Priority[temp2] = temp;
            }

            for (int i = 0; i < this.graph.N; i++)
            {
                int max_Out_Edge = 0;
                int count_Out_Edge = 0;
                int old_ID = -1;
                for(int j =0;j< this.graph.Nodes[i].Out_Edge.Count; j++)
                {
                    if(old_ID == -1 || this.graph.Nodes[i].Out_Edge[j].id_destination == old_ID)
                    {
                        if(old_ID == -1 ) old_ID = this.graph.Nodes[i].Out_Edge[j].id_destination;
                        count_Out_Edge++;
                    }
                    else
                    {
                        old_ID = this.graph.Nodes[i].Out_Edge[j].id_destination;
                        if (max_Out_Edge < count_Out_Edge) max_Out_Edge = count_Out_Edge;
                        count_Out_Edge = 1; // = 0  sau đó tăng 1 đơn vị
                    }
                }
                // = random trong khoảng từ 1 đến max out edge
                if (max_Out_Edge == 0) 
                    this.Out_Edge_Index[i] = -1;
                else 
                    this.Out_Edge_Index[i] = random.Next(1, max_Out_Edge);
            }
        }
    }
}
