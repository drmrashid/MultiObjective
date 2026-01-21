using System;
using System.Collections.Generic;
using System.Text;

namespace MultiObjective
{
    class Particle
    {
        private double[] x;
        private double[] f;
        private double[,] range;
        private Function func;
        public Particle(Function function, Random r, double[,] rng)
        {
            func = function;
            x = new double[func.SolutionSpaceDimensions];
            f = new double[func.ObjectiveSpaceDimensions];
            range = rng;
            int sanity = 0;
            do
            {
                for(int i = 0; i < func.SolutionSpaceDimensions; i++)
                    x[i] = rng[i,0] + r.NextDouble() * (rng[i,1] - rng[i,0]);
                //x[1] = rng[1,0] + r.NextDouble() * (rng[1,1] - rng[1,0]);
                //func.Evaluate(x).CopyTo(f,0);
                if (sanity > 100)
                    break;
                if (sanity > 10)
                    range = func.Range;
                sanity++;
            } while (func.Evaluate(x)[0] == Double.PositiveInfinity);

            func.Evaluate(x).CopyTo(f, 0);
            //f[0] = F1();
            //f[1] = F2();
        }
        public Particle(Function function, double[] x2)
        {
            x = x2;
            func = function;
            f = new double[func.ObjectiveSpaceDimensions];
            func.Evaluate(x).CopyTo(f, 0);
            //f[0] = F1();
            //f[1] = F2();
        }
        public double GetObjectiveSpaceDistance(double[] f2)
        {
            double d = 0;
            for (int i = 0; i < func.ObjectiveSpaceDimensions; i++)
                d += (f[i] - f2[i]) * (f[i] - f2[i]);

            //return Math.Sqrt((f[0] - f2[0]) * (f[0] - f2[0]) + (f[1] - f2[1]) * (f[1] - f2[1]));
            return Math.Sqrt(d);
        }
        public double GetDistance(double[] x2)
        {
            double d = 0;
            for (int i = 0; i < func.ObjectiveSpaceDimensions; i++)
                d += (x[i] - x2[i]) * (x[i] - x2[i]);
            //return Math.Sqrt((x[0] - x2[0]) * (x[0] - x2[0]) + (x[1] - x2[1]) * (x[1] - x2[1]));
            return Math.Sqrt(d);
        }
        public bool IsNonDominated(Particle p)
        {
            if (func.Minimization)
            {
                for (int i = 0; i < func.ObjectiveSpaceDimensions; i++)
                    if (f[i] < p.f[i])
                        return true;
            }
            else
            {
                for (int i = 0; i < func.ObjectiveSpaceDimensions; i++)
                    if (f[i] > p.f[i])
                        return true;
            }
            return false;
            //if (f[0] > p.f[0] || f[1] > p.f[1])
            //    return true;
            //else
            //    return false;
        }
        public bool IsNonDominated(List<Particle> p)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (!Equals(p[i]) && !IsNonDominated(p[i]))
                    return false;
            }
            return true;
        }

        public double[] F
        {
            get
            {
                return f;
            }
        }
        public double[] X
        {
            get
            {
                return x;
            }
        }
    }
}
