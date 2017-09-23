using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Domain.Interfaces
{
    public interface IPiece
    {
        void Move(MovementType move, int newX, int newY);
        void CurrentPosition();

        int XCoordinate { get; }
        int YCoordinate { get; }
        PieceColor PieceColor { get; }

    }
}
