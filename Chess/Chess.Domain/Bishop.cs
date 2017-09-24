using Chess.Domain.Interfaces;
using Chess.Domain.Models;
using System;

namespace Chess.Domain
{
    public class Bishop : Piece, IPiece
    {
        private readonly IChessBoard _chessBoard;

        public Bishop(IChessBoard chessBoard, PieceColor color, Position position) : base(color, position)
        {
            _chessBoard = chessBoard;
            
        }
        
        public override void Move(MovementType move, Position newPosition)
        {
            if (ValidMove(newPosition) && _chessBoard.UnobstructedPosition(newPosition, PieceColor))
            {
                Position = newPosition;
            }
        }

        private bool ValidMove(Position newPosition)
        {
            var onBoard = _chessBoard.IsLegalBoardPosition(newPosition);

            if (onBoard)
            {
                if ((Math.Abs(newPosition.XCoordinate - Position.XCoordinate) ==
                     Math.Abs(newPosition.YCoordinate - Position.YCoordinate)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
