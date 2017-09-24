using Chess.Domain.Models;

namespace Chess.Domain.Interfaces
{
    public interface IPiece
    {
        Position Position { get; }
        PieceColor PieceColor { get; }

        void Move(MovementType move, Position newPosition);
    }
}
