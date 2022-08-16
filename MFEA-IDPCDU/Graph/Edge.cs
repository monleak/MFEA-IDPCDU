using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFEA_IDPCDU.Graph
{
    public class Edge : IEquatable<Edge> , IComparable<Edge>
    { 
        public int id_source; //id node nguồn
        public int id_destination; //id nút đích
        public double Weight;
        public int domain;

        public int CompareTo(Edge compareEdge)
        {
            // A null value means that this object is greater.
            if (compareEdge == null)
                return 1;
            else
                return this.id_destination.CompareTo(compareEdge.id_destination);
        }
        public bool Equals(Edge other)
        {
            if (other == null) return false;
            return (this.id_destination.Equals(other.id_destination));
        }
    }
}
