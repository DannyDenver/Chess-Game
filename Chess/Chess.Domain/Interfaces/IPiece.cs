using Chess.Domain.Models;

namespace Chess.Domain.Interfaces
{
    public interface IPiece
    {
        string CurrentPosition();

        Position Position { get; }
        PieceColor PieceColor { get; }
    }
}
