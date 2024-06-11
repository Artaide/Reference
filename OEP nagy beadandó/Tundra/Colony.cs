using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tundra
{
    public abstract class Colony
    {
        public class NullColonyException : Exception { }
        public class DeadColonyException : Exception { }
        public string Nickname { get; }
        public double Specimens { get; protected set; }
        public bool Dead { get; protected set; }
        public Colony(string n, double s)
        {
            Nickname = n;
            Specimens = s;
        }
        public virtual bool IsPredator() { return false; }
        public virtual bool IsPrey() { return false; }
        public virtual void Reproduce(int turn) { }
        public virtual int ReproduceTurn() { return 0; }
        public virtual double NumOffspring() { return 0; }
    }
    
}
