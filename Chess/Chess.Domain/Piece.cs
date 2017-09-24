using Chess.Domain.Models;

namespace Chess.Domain
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public PieceColor PieceColor { get; }

        protected Piece(PieceColor color, Position position)
        {
            PieceColor = color;
            Position = position;
        }

        public string CurrentPosition()
        {
            return $"Current X: {Position.XCoordinate} Current Y: {Position.YCoordinate} Piece Color: {PieceColor} Piece: {this.GetType().Name}";
        }

        public abstract void Move(MovementType move, Position newPosition);
    }
}
