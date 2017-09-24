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

        public override void Move(MovementType move, Position newPosition)
        {
            if (ValidMove(move, newPosition) 
                &&  _chessBoard.UnobstructedPosition(newPosition, PieceColor)
                && _chessBoard.IsLegalBoardPosition(newPosition))
            {
                
                Position = newPosition; ;

                _firstMove = false;

                if (Position.YCoordinate ==  _chessBoard.MaxBoardHeight || Position.YCoordinate == 0) _direction = !_direction;
            }
        }

        private bool ValidMove(MovementType move, Position newPosition)
        {

            //check to see if pawn is going in the right direction
            var rightDirection = (((newPosition.YCoordinate - Position.YCoordinate) > 0) == _direction);

           if (rightDirection)
                {
                    //check to see if pawn made normal move
                    if ((move == MovementType.Move) && (newPosition.XCoordinate == Position.XCoordinate))
                    {
                        //check to see if number of positions moved is correct
                        if ((Math.Abs(newPosition.YCoordinate - Position.YCoordinate) == 1) || ((Math.Abs(newPosition.YCoordinate - Position.YCoordinate) == 2) && _firstMove))
                        {
                            return true;
                        }
                    }
                    //check to see if pawn made capture move
                    if ((move == MovementType.Capture) && (newPosition.YCoordinate != Position.YCoordinate) && (newPosition.XCoordinate != Position.XCoordinate))
                    {
                        if ((Math.Abs(newPosition.YCoordinate - Position.YCoordinate) == 1) && (Math.Abs(newPosition.XCoordinate - Position.XCoordinate) == 1))
                        {
                            return true;
                        }
                    }
                }
            return false;
        }
    }
}
