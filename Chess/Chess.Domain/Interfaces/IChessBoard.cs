using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Domain.Interfaces
{
    public interface IChessBoard
    {
        bool IsLegalBoardPosition(int xCoordinate, int yCoordinate);

        void AddPiece(IPiece pawn);
    }
}
