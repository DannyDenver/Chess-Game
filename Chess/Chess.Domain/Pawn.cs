using System;
using Chess.Domain.Interfaces;
using Chess.Domain.Models;

namespace Chess.Domain
{
    public class Pawn : Piece, IPiece
    {
        private bool _direction; // we are playing by checkers rules... 
        private readonly IChessBoard _chessBoard;
        private bool _firstMove;

        public Pawn(IChessBoard chessboard, PieceColor pieceColor, Position position, bool firstMove) :
            base(pieceColor, position)
        {
            _chessBoard = chessboard;
            _firstMove = firstMove;
            _direction = Convert.ToBoolean(pieceColor);
        }

        public void Move(Position newPosition)
        {
            if (_chessBoard.IsLegalBoardPosition(newPosition, PieceColor) && ValidMove(newPosition)) // use default if at the end
            {
                Position = newPosition; 

                _firstMove = false;

                if (Position.YCoordinate == _chessBoard.MaxBoardHeight || Position.YCoordinate == 0) _direction = !_direction; /// use default move
            }
        }

        private bool ValidMove(Position newPosition)
        {
            //check to see if pawn is going in the right direction
           var rightDirection = (((newPosition.YCoordinate - Position.YCoordinate) > 0) == _direction);

           if (rightDirection)
                {
                //check to see if pawn made normal move and number of positions moved is correct
                if (((Math.Abs(newPosition.YCoordinate - Position.YCoordinate) == 1) ||
                    ((Math.Abs(newPosition.YCoordinate - Position.YCoordinate) == 2) && _firstMove))
                    && (newPosition.XCoordinate == Position.XCoordinate)
                    && _chessBoard.EmptySpace(newPosition))
                    {
                        return true;
                    }
                //check to see if pawn made capture move
                if ((Math.Abs(newPosition.YCoordinate - Position.YCoordinate) == 1) && (Math.Abs(newPosition.XCoordinate - Position.XCoordinate) == 1))
                    {
                        if(_chessBoard.CheckIfCanCapturePiece(newPosition, PieceColor))
                            return true;
                    }
                }
            return false;
        }
    }
}
