using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MFEA_IDPCDU.Graph;

namespace MFEA_IDPCDU.basic
{
    public class Individual
    {
        private static int counter = 0;

        public int Individual_Id;
        public int[] Priority;
        public int[] Out_Edge_Index;

        public Individual()
        {
            this.Individual_Id = Individual.counter++;
            this.Priority = new int[Params.USS_N];
            this.Out_Edge_Index = new int[Params.USS_N];
        }

        public void randomInit()
        {
            for(int i=0;i< Params.USS_N; i++)
            {
                //Tạo 1 mảng {1,2,3,...,N}
                this.Priority[i] = i + 1;
            }
            for(int i=0;i< Params.USS_N; i++)
            {   
                //Hoán vị mảng vừa tạo N lần
                int temp1 = Params.random.Next(0, Params.USS_N-1);
                int temp2 = Params.random.Next(0, Params.USS_N-1);
                int temp = this.Priority[temp1];
                this.Priority[temp1] = this.Priority[temp2];
                this.Priority[temp2] = temp;
            }

            for (int i = 0; i < Params.USS_N; i++)
            {
                // = random trong khoảng từ 1 đến max out edge
                if (Params.USS_S[i] == 0) 
                    this.Out_Edge_Index[i] = -1;
                else 
                    this.Out_Edge_Index[i] = Params.random.Next(1, Params.USS_S[i]);
            }
        }
    }
}
