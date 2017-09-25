using System;
using Chess.Domain.Interfaces;
using Chess.Domain.Models;

namespace Chess.Domain
{
    public class King : Piece, IPiece
    {
        private IChessBoard _chessBoard { get; }

        public override void Move(Position newPosition)
        {
            if (_chessBoard.IsLegalBoardPosition(newPosition, PieceColor) && ValidMove(newPosition))
            {
                Position = newPosition;
            }
        }

        public King(IChessBoard chessBoard, PieceColor color, Position position) : base(color, position)
        {
            _chessBoard = chessBoard;
        }

        private bool ValidMove(Position newPosition)
        {
            //valid move one position over vertically or horizontally 
            if (((Math.Abs(newPosition.YCoordinate - Position.YCoordinate) == 1) && (newPosition.XCoordinate == Position.XCoordinate)) ||
                ((Math.Abs(newPosition.XCoordinate - Position.XCoordinate) == 1) && (newPosition.YCoordinate == Position.YCoordinate)))
            {
                return true;
            }

            //valid move 1 vertical and 1 horizontal
            if ((Math.Abs(newPosition.YCoordinate - Position.YCoordinate) == 1) && (Math.Abs(newPosition.XCoordinate - Position.XCoordinate) == 1))
            {
                return true;
            }

            return false;

        }
    }
}
