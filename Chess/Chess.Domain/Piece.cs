using Chess.Domain.Models;

namespace Chess.Domain
{
    public class Piece
    {
        public Position Position { get; protected set; }
        public PieceColor PieceColor { get; }

        public Piece(PieceColor color, Position position)
        {
            PieceColor = color;
            Position = position;
        }

        protected string CurrentPosition()
        {
            return $"Current X: {Position.XCoordinate} Current Y: {Position.YCoordinate} Piece Color: {PieceColor}";
        }
    }
}
