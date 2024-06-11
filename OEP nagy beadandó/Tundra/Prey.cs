using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tundra
{
    public class Prey : Colony
    {
        public double Denom { get; protected set; }
        public Prey(string n, int s) : base(n, s)
        {
            if (s > 4)
                Dead = false;
            else
                Dead = true;
        }
        public override bool IsPrey() { return true; }
        public override void Reproduce(int turn)
        {
            if (!Dead)
            {
                if (turn % ReproduceTurn() == 0)
                    Specimens = Math.Floor(Specimens * NumOffspring());
                if (Specimens >= Limit())
                    Specimens = Remains();
            }
        }
        public virtual double Attacked(SnowyOwl pred) { return 0; }
        public virtual double Attacked(ArcticFox pred) { return 0; }
        public virtual double Attacked(PolarBear pred) { return 0; }
        
        public virtual int Limit() { return 0; }
        public virtual int Remains() { return 0; }
        public virtual string GetDicName()
        {
            return "";
        }
    }
    public class Lemming : Prey
    {
        public Lemming(string n, int s) : base(n, s) { }
        
        public override double NumOffspring() { return 2; }
        public override int ReproduceTurn() { return 2; }
        public override double Attacked(SnowyOwl pred)
        {
            if (pred == null) throw new NullColonyException();
            double hunted = Math.Floor(Specimens * 0.3);
            Specimens -= hunted;
            if (Specimens < 1)
                Dead = true;
            Denom = 2;
            Console.WriteLine($"{Nickname} specimen count reduced to {Specimens}");
            return hunted;
        }
        public override double Attacked(ArcticFox pred)
        {
            if (pred == null) throw new NullColonyException();
            double hunted = Math.Floor(Specimens * 0.05);
            Specimens -= hunted;
            if (Specimens < 1)
                Dead = true;
            Denom = 4;
            Console.WriteLine($"{Nickname} specimen count reduced to {Specimens}");
            return hunted;
        }
        public override double Attacked(PolarBear pred)
        {
            if (pred == null) throw new NullColonyException();
            double hunted = Math.Floor(Specimens * 0.02);
            Specimens -= hunted;
            if (Specimens < 1)
                Dead = true;
            Denom = 20;
            Console.WriteLine($"{Nickname} specimen count reduced to {Specimens}");
            return hunted;
        }
        public override int Limit() { return 200; }
        public override int Remains() { return 30; }
        public override string ToString()
        {
            if (Dead)
                return $"Lemming colony: {Nickname}, specimen count: {Specimens}, dead";
            else
                return $"Lemming colony: {Nickname}, specimen count: {Specimens}, alive";
        }
        public override string GetDicName()
        {
            return "lemming";
        }
    }
    public class ArcticHare : Prey
    {
        public ArcticHare(string n, int s) : base(n, s) { }

        public override double NumOffspring() { return 1.5; }
        public override int ReproduceTurn() { return 2; }
        public override double Attacked(SnowyOwl pred)
        {
            if (pred == null) throw new NullColonyException();
            double hunted = Math.Floor(Specimens * 0.2);
            Specimens -= hunted;
            if (Specimens < 1)
                Dead = true;
            Denom = 1;
            Console.WriteLine($"{Nickname} specimen count reduced to {Specimens}");
            return hunted;
        }
        public override double Attacked(ArcticFox pred)
        {
            if (pred == null) throw new NullColonyException();
            double hunted = Math.Floor(Specimens * 0.35);
            Specimens -= hunted;
            if (Specimens < 1)
                Dead = true;
            Denom = 2;
            Console.WriteLine($"{Nickname} specimen count reduced to {Specimens}");
            return hunted;
        }
        public override double Attacked(PolarBear pred)
        {
            if (pred == null) throw new NullColonyException();
            double hunted = Math.Floor(Specimens * 0.01);
            Specimens -= hunted;
            if (Specimens < 1)
                Dead = true;
            Denom = 10;
            Console.WriteLine($"{Nickname} specimen count reduced to {Specimens}");
            return hunted;
        }
        public override int Limit() { return 100; }
        public override int Remains() { return 20; }
        public override string ToString()
        {
            if (Dead)
                return $"Arctic Hare colony: {Nickname}, specimen count: {Specimens}, dead";
            else
                return $"Arctic Hare colony: {Nickname}, specimen count: {Specimens}, alive";
        }
        public override string GetDicName()
        {
            return "hare";
        }
    }
    public class Moose : Prey
    {
        public Moose(string n, int s) : base(n, s) { }

        public override double NumOffspring() { return 1.2; }
        public override int ReproduceTurn() { return 4; }
        public override double Attacked(SnowyOwl pred)
        {
            Denom = 0;
            Console.WriteLine($"{Nickname} specimen count unchanged");
            return 0;
        }
        public override double Attacked(ArcticFox pred)
        {
            Denom = 0;
            Console.WriteLine($"{Nickname} specimen count unchanged");
            return 0;
        }
        public override double Attacked(PolarBear pred)
        {
            if (pred == null) throw new NullColonyException();
            double hunted = Math.Floor(Specimens * 0.25);
            Specimens -= hunted;
            if (Specimens < 1)
                Dead = true;
            Denom = 0.5;
            Console.WriteLine($"{Nickname} specimen count reduced to {Specimens}");
            return hunted;
        }
        public override int Limit() { return 200; }
        public override int Remains() { return 40; }
        public override string ToString()
        {
            if (Dead)
                return $"Moose colony: {Nickname}, specimen count: {Specimens}, dead";
            else
                return $"Moose colony: {Nickname}, specimen count: {Specimens}, alive";
        }
        public override string GetDicName()
        {
            return "moose";
        }
    }
}
