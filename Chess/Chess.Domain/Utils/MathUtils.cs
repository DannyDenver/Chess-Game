using System;
using Chess.Domain.Models;

namespace Chess.Domain.Utils
{
    public static class MathUtils
    {
        public static int DistanceBetweenPositions(int positionOne, int positionTwo)
        {
            return Math.Abs(positionOne - positionTwo);
        }
    }
}
