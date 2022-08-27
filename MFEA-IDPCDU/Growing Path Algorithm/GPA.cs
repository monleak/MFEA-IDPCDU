using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.Graph;
using MFEA_IDPCDU.basic;

namespace MFEA_IDPCDU.Growing_Path_Algorithm
{
    public class GPA
    {
        public static Boolean checkListInt(List<int> H,int n)
        {
            //Kiểm tra int có tồn tại trong list hay chưa
            for(int i = 0; i < H.Count; i++)
            {
                if(n == H[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static List<Edge> runGPA(Individual individual, int task)
        {
            //Decode từ không gian chung về không gian riêng để tìm đường đi
            //Mỗi task có 1 đồ thị riêng nằm trong Params.List_graph
            int[] Priority = new int[Params.List_graph[task].N];
            int[] Out_Edge_Index = new int[Params.List_graph[task].N];
            int dem = 0;
            for(int i=0;i< individual.Priority.Length; i++)
            {
                if (individual.Priority[i] <= Params.List_graph[task].N)
                {
                    Priority[dem] = individual.Priority[i];
                    Out_Edge_Index[dem] = individual.Out_Edge_Index[i];
                    dem++;
                }
            }

            List<int> H = new List<int>(); //Set of domains that path p has left
            int d = -1; //The domain that the path p is visiting
            int[] c = new int[Params.List_graph[task].N]; //c(v) is cost of path from s to v
            c[Params.List_graph[task].Node_s-1] = 0; //index = ID -1
            c[Params.List_graph[task].Node_t -1] = int.MaxValue;
            int curr = Params.List_graph[task].Node_s;
            Boolean[] visited = new Boolean[Params.List_graph[task].N];
            for(int i = 0; i < Params.List_graph[task].N; i++)
            {
                visited[i] = false;
            }
            List<Edge> p = new List<Edge>();

            do
            {
                visited[curr - 1] = true;

                List<Edge> Adj_curr = new List<Edge>(); //list các cạnh nối node hiện tại với các node khác sao cho các miền của cạnh không thuộc H
                List<int> Out_Node = new List<int>();
                for(int i = 0; i < Params.List_graph[task].Nodes[curr-1].Out_Edge.Count; i++)
                {
                    if(checkListInt(H, Params.List_graph[task].Nodes[curr - 1].Out_Edge[i].domain) == false)
                    {
                        Adj_curr.Add(Params.List_graph[task].Nodes[curr - 1].Out_Edge[i]);
                        Out_Node.Add(Params.List_graph[task].Nodes[curr - 1].Out_Edge[i].id_destination);
                    }
                }
                if (Adj_curr.Count == 0)
                {
                    p.Clear();
                    break;
                }
                int v = -1; //id node kế tiếp
                int max_Priority = -1;
                for (int i = 0; i < Priority.Length; i++)
                {
                    if (max_Priority < Priority[i] && visited[i] == false && checkListInt(Out_Node,i+1))
                    {
                        //Tìm node có độ ưu tiên cao nhất và có cạnh nối với curr thuộc Adj_curr
                        // Node chưa từng được thăm
                        max_Priority = Priority[i];
                        v = i+1;
                    }
                }
                if (v == -1)
                {
                    p.Clear();
                    break;
                }

                List<Edge> E_curr_v = new List<Edge>(); //List cạnh từ curr đến v (thuộc Adj_curr)
                for(int i=0; i < Adj_curr.Count; i++)
                {
                    if(Adj_curr[i].id_destination == v)
                    {
                        E_curr_v.Add(Adj_curr[i]);
                    }
                }
                int k = Out_Edge_Index[v - 1] % E_curr_v.Count;
                p.Add(E_curr_v[k]);
                int d2 = E_curr_v[k].domain;
                if(d != -1 && d2 != d)
                {
                    H.Add(d);
                }
                d = d2;
                c[v - 1] = c[curr - 1] + E_curr_v[k].Weight;
                curr = v;
            } while (curr != Params.List_graph[task].Node_t);

            return p;
        }
        public static int calCost(List<Edge> a)
        {
            int sum = 0;
            if (a.Count == 0) return int.MaxValue;

            for(int i = 0; i < a.Count; i++)
            {
                sum += a[i].Weight;
            }
            return sum;
        }
    }
}
