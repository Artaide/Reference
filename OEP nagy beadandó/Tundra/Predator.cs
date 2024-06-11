using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tundra
{
    public abstract class Predator : Colony
    {
        public Predator(string n, int s) : base(n, s)
        {
            if (s > 4)
                Dead = false;
            else
                Dead = true;
        }
        public override bool IsPredator() { return true; }
        public virtual void Attack(Prey prey) { }
        public override void Reproduce(int turn)
        {
            if (!Dead)
            {
                if (turn % ReproduceTurn() == 0)
                    Specimens += Math.Floor(Specimens / 4) * NumOffspring();
            }
        }
        public virtual string GetDicName()
        {
            return "";
        }
    }
    public class SnowyOwl : Predator
    {
        public SnowyOwl(string n, int s) : base(n, s) { }
        public override int ReproduceTurn() { return 3; }
        public override double NumOffspring() { return 2; }
        public override void Attack(Prey prey)
        {
            if (!Dead)
            {
                double hunted = prey.Attacked(this);
                if (hunted / prey.Denom < Specimens && Specimens > prey.Denom)
                    Specimens = prey.Denom;
                if (hunted == 0 && prey.Denom == 0)
                    Specimens = 0;
                if (Specimens < 4)
                    Dead = true;
                Console.WriteLine($"Hunted {hunted} prey specimens\n");
            }
            
        }
        public override string ToString()
        {
            if (Dead)
                return $"Snowy Owl colony: {Nickname}, specimen count: {Specimens}, dead";
            else
                return $"Snowy Owl colony: {Nickname}, specimen count: {Specimens}, alive";
        }
        public override string GetDicName()
        {
            return "owl";
        }
    }
    public class ArcticFox : Predator
    {
        public ArcticFox(string n, int s) : base(n, s) { }
        public override int ReproduceTurn() { return 3; }
        public override double NumOffspring() { return 3; }
        public override void Attack(Prey prey)
        {
            if (!Dead)
            {
                double hunted = prey.Attacked(this);
                if (hunted / prey.Denom < Specimens && Specimens > prey.Denom)
                    Specimens = prey.Denom;
                if (hunted == 0 && prey.Denom == 0)
                    Specimens = 0;
                if (Specimens < 4)
                    Dead = true;
                Console.WriteLine($"Hunted {hunted} prey specimens\n");
            }
        }
        public override string ToString()
        {
            if (Dead)
                return $"Arctic Fox colony: {Nickname}, specimen count: {Specimens}, dead";
            else
                return $"Arctic Fox colony: {Nickname}, specimen count: {Specimens}, alive";
        }
        public override string GetDicName()
        {
            return "fox";
        }
    }
    public class PolarBear : Predator
    {
        public PolarBear(string n, int s) : base(n, s) { }
        public override int ReproduceTurn() { return 8; }
        public override double NumOffspring() { return 1; }
        public override void Attack(Prey prey)
        {
            if (!Dead)
            {
                double hunted = prey.Attacked(this);
                if (hunted / prey.Denom < Specimens && Specimens > prey.Denom)
                    Specimens = prey.Denom;
                if (Specimens < 4)
                    Dead = true;
                Console.WriteLine($"Hunted {hunted} prey specimens\n");
            }
        }
        public override string ToString()
        {
            if (Dead)
                return $"Polar Bear colony: {Nickname}, specimen count: {Specimens}, dead";
            else
                return $"Polar Bear colony: {Nickname}, specimen count: {Specimens}, alive";
        }
        public override string GetDicName()
        {
            return "bear";
        }
    }
}
