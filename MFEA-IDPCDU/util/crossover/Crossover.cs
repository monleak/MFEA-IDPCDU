using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.basic;
using MFEA_IDPCDU.Growing_Path_Algorithm;
using MFEA_IDPCDU.util.mutation;

namespace MFEA_IDPCDU.util.crossover
{
    internal class Crossover
    {
        public static int checkIntList(int[] a, int n)
        {
            for(int i=0; i<a.Length; i++)
            {
                if (a[i] == n) return i;
            }
            return -1;
        }
        public static List<Individual> runCrossover(Individual I1, Individual I2)
        {
            List<Individual> Offsprings = new List<Individual>();
            Individual O1 = new Individual(I1.task);
            Individual O2 = new Individual(I1.task);

            int cutPoint1 = Params.random.Next(0, Params.USS_N-1);
            int cutPoint2 = Params.random.Next(0, Params.USS_N-1);
            while(cutPoint2 == cutPoint1) cutPoint2 = Params.random.Next(0, Params.USS_N - 1);
            //Console.WriteLine(cutPoint1 + "|" + cutPoint2);
            if(cutPoint1 > cutPoint2)
            {
                int temp = cutPoint1;
                cutPoint1 = cutPoint2;
                cutPoint2 = temp;
            }
            for(int i = cutPoint1; i <= cutPoint2; i++)
            {
                O2.Priority[i] = I2.Priority[i];
                O1.Priority[i] = I1.Priority[i];
                O2.Out_Edge_Index[i] = I2.Out_Edge_Index[i];
                O1.Out_Edge_Index[i] = I1.Out_Edge_Index[i];
            }
            for(int i = 0; i < cutPoint1;i++)
            {
                if (checkIntList(O2.Priority, I1.Priority[i]) == -1)
                {
                    //Chưa tồn tại
                    O2.Priority[i] = I1.Priority[i];
                }
                else
                {
                    //Đã tồn tại
                    int temp = i;
                    do
                    {
                        temp = checkIntList(O2.Priority, I1.Priority[temp]);
                    } while (checkIntList(O2.Priority, I1.Priority[temp]) != -1);
                    O2.Priority[i] = I1.Priority[temp];
                }

                if (checkIntList(O1.Priority, I2.Priority[i]) == -1)
                {
                    //Chưa tồn tại
                    O1.Priority[i] = I2.Priority[i];
                }
                else
                {
                    //Đã tồn tại
                    int temp = i;
                    do
                    {
                        temp = checkIntList(O1.Priority, I2.Priority[temp]);
                    } while (checkIntList(O1.Priority, I2.Priority[temp]) != -1);
                    O1.Priority[i] = I2.Priority[temp];
                }

                O1.Out_Edge_Index[i] = I2.Out_Edge_Index[i];
                O2.Out_Edge_Index[i] = I1.Out_Edge_Index[i];
            }
            for (int i = cutPoint2+1; i < Params.USS_N; i++)
            {
                if (checkIntList(O2.Priority, I1.Priority[i]) == -1)
                {
                    //Chưa tồn tại
                    O2.Priority[i] = I1.Priority[i];
                }
                else
                {
                    //Đã tồn tại
                    int temp = i;
                    do
                    {
                        temp = checkIntList(O2.Priority, I1.Priority[temp]);
                    } while (checkIntList(O2.Priority, I1.Priority[temp]) != -1);
                    O2.Priority[i] = I1.Priority[temp];
                }

                if (checkIntList(O1.Priority, I2.Priority[i]) == -1)
                {
                    //Chưa tồn tại
                    O1.Priority[i] = I2.Priority[i];
                }
                else
                {
                    //Đã tồn tại
                    int temp = i;
                    do
                    {
                        temp = checkIntList(O1.Priority, I2.Priority[temp]);
                    } while (checkIntList(O1.Priority, I2.Priority[temp]) != -1);
                    O1.Priority[i] = I2.Priority[temp];
                }

                O1.Out_Edge_Index[i] = I2.Out_Edge_Index[i];
                O2.Out_Edge_Index[i] = I1.Out_Edge_Index[i];
            }
            if (Params.random.NextDouble() < Params.R_mutation)
                O1 = mutation.mutation.runMutation(O1);
            if (Params.random.NextDouble() < Params.R_mutation)
                O2 = mutation.mutation.runMutation(O2);

            O1.cost = GPA.calCost(GPA.runGPA(O1.Priority, O1.Out_Edge_Index, O1.task));
            O2.cost = GPA.calCost(GPA.runGPA(O2.Priority, O2.Out_Edge_Index, O2.task));

            Offsprings.Add(O1);
            Offsprings.Add(O2);
            return Offsprings;
        }
    }
}
