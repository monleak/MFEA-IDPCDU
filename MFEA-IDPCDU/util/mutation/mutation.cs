using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.basic;

namespace MFEA_IDPCDU.util.mutation
{
    internal class mutation
    {
        public static Individual runMutation(Individual a)
        {
            int i = Params.random.Next(0,Params.USS_N-1);
            int j = Params.random.Next(0,Params.USS_N-1);
            while(i==j) j = Params.random.Next(0,Params.USS_N-1);

            int temp = a.Priority[i];
            a.Priority[i] = a.Priority[j];
            a.Priority[j] = temp;
            a.Out_Edge_Index[i] = Params.random.Next(1, Params.USS_S[i]);

            return a;
        }
    }
}
