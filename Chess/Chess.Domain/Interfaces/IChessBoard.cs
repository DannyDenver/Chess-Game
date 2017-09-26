using Chess.Domain.Models;

namespace Chess.Domain.Interfaces
{
    public interface IChessBoard
    {
        void AddPiece(IPiece pawn);
        bool IsLegalBoardPosition(Position position, PieceColor pieceColor);
        bool CheckIfCanCapturePiece(Position position, PieceColor pieceColor);
        int MaxBoardWidth { get; }
        int MaxBoardHeight { get; }
        bool EmptySpace(Position position, PieceColor? color = null);
    }
}
