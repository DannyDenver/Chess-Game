using System;
using Chess.Domain.Interfaces;
using Chess.Domain.Models;

namespace Chess.Domain
{
    public class Pawn : Piece, IPiece
    {
        private bool _direction;
        private readonly IChessBoard _chessBoard;
        private bool _firstMove;

        public Pawn(IChessBoard chessboard, PieceColor pieceColor, Position position, bool firstMove) :
            base(pieceColor, position)
        {
            _chessBoard = chessboard;
            _firstMove = firstMove;
            _direction = Convert.ToBoolean(pieceColor);
        }

        public void Move(MovementType move, Position newPosition)
        {
            if (ValidMove(move, new Position(newPosition.XCoordinate, newPosition.YCoordinate)))
            {
                base.Position = new Position(newPosition.XCoordinate, newPosition.YCoordinate); ;

                _firstMove = false;

                if (Position.XCoordinate == 7 || Position.XCoordinate == 0) _direction = !_direction;
            }
        }

        public new string CurrentPosition()
        {
            return base.CurrentPosition();
        }

        private bool ValidMove(MovementType move, Position newPosition)
        {
            //check to see if Pawn is on board
            var onBoard = _chessBoard.IsLegalBoardPosition(newPosition);

            //check to see if pawn is going in the right direction
            var rightDirection = (((newPosition.YCoordinate - Position.YCoordinate) > 0) == _direction);

           if (onBoard && rightDirection)
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
