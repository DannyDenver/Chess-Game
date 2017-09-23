using Chess.Domain.Models;

namespace Chess.Domain.Interfaces
{
    public interface IChessBoard
    {
        bool IsLegalBoardPosition(Position position);

        void AddPiece(IPiece pawn);
    }
}
