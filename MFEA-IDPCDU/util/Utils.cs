using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFEA_IDPCDU.basic;

namespace MFEA_IDPCDU.util
{
    internal class Utils
    {
        public static double cauchy_g(double mu, double gamma)
        {
            return mu + gamma * Math.Tan(Math.PI * (Params.random.NextDouble() - 0.5));
        }

        public static double gauss(double mu, double sigma)
        {
            return mu + sigma * Math.Sqrt(-2.0 * Math.Log(Params.random.NextDouble()))
                    * Math.Sin(2.0 * Math.PI * Params.random.NextDouble());
        }
    }
}
