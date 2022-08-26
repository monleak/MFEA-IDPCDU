using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.basic;

namespace MFEA_IDPCDU.util.crossover
{
    internal class Crossover
    {
        public static List<Individual> runCrossover(Individual I1, Individual I2)
        {
            List<Individual> Offsprings = new List<Individual>();

            //int[,] Offspring_Prioority = runPMX_Crossover(I1.Priority, I2.Priority);
            //int[,] Offspring_OutEdgeIndex = runTwoPoint_Crossover(I1.Out_Edge_Index, I2.Out_Edge_Index);

            //Individual O1 = new Individual();
            //Offsprings.Add(O1);
            //Offsprings.Add(O2);
            return Offsprings;
        }
        public static void runPMX_Crossover(ref int[] a1, ref int[] a2)
        {
            if(a1.Length != a2.Length) return;
            int point1 = Params.random.Next(0, a1.Length - 1); //cut point
            int point2 = Params.random.Next(0, a1.Length - 1); //cut point

            int[] p1 = a1; int[] p2 = a2; //Lưu giá trị của cha mẹ
            for(int i = point1; i <= point2; i++) //Tráo đối vị trí giữa 2 điểm cắt
            {
                a2[i] = p1[i];
                a1[i] = p2[i];
            }

            

        }
        public static void runTwoPoint_Crossover(ref int[] a1, ref int[] a2)
        {

        }
    }
}
