using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA20240212
{
    internal class Nap
    {
        public List<int> orak { get; set; }

        public Nap(string sor)
        {
            var v = sor.Split(';');
            this.orak = new List<int>();
            for (int i = 0; i < v.Count(); i++)
            {
                orak.Add(int.Parse(v[i]));
            }
        }

        public override string ToString()
        {
            return $"{string.Join(" ", orak)}";
        }
    }
}
