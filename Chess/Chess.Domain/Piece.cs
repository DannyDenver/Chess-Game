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
            return $"Current X: {Position.XCoordinate} Current Y: {Position.YCoordinate} Piece Color: {PieceColor} Piece: { GetType().Name}";
        }

        //public virtual void Move(Position newPosition)  /// could set some default move logic here, difference between interface and base class 
        //{
        //    if ((newPosition.XCoordinate != 0) && (newPosition.YCoordinate != 0))
        //    {
        //        Position = newPosition;
        //    }
        //}

    }
}
