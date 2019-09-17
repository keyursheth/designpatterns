using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns
{
    public class AdapterPattern
    {
        public static void Main()
        {
            RoundHole roundHole = new RoundHole();
            RoundPeg roundPeg = new RoundPeg();
            roundPeg.Radius = 7;

            SquarePeg squarePeg = new SquarePeg();
            squarePeg.Width = 9;
            PegAdapter pegAdapter = new PegAdapter(squarePeg);

            Console.WriteLine("Round Peg fits hole ? : " + roundHole.Fits(roundPeg));
            Console.WriteLine("Square Peg fits hole ? : " + roundHole.Fits(pegAdapter));

            Console.ReadLine();
        }
    }

    public class RoundHole
    {
        private const int radius = 7;

        public bool Fits(RoundPeg roundPeg)
        {
            return roundPeg.Radius <= radius;
        }
    }

    public class RoundPeg
    {
        public int Radius { get; set; }
    }

    public class SquarePeg
    {
        public int Width { get; set; }
    }

    public class PegAdapter : RoundPeg
    {
        SquarePeg _squarePeg;

        public PegAdapter(SquarePeg squarePeg)
        {
            _squarePeg = squarePeg;
            Radius = GetRadius();
        }

        public int GetRadius()
        {
            return _squarePeg.Width - 1;
        }
    }
}
