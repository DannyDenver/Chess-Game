using System;
using Chess.Domain.Interfaces;

namespace Chess.Domain
{
    public class Pawn : Piece, IPiece
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public PieceColor PieceColor { get; private set; }

        private bool _direction;
        private readonly IChessBoard _chessBoard;
        private bool _firstMove;
       
        public Pawn(IChessBoard chessboard, PieceColor pieceColor, int xCoordinate, int yCoordinate, bool firstMove)
        {
            _chessBoard = chessboard;
            PieceColor = pieceColor;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            _firstMove = firstMove;
            _direction = Convert.ToBoolean(pieceColor);
        }



        public override void Move(MovementType move, int newX, int newY)
        {
            if (ValidMove(move, newX, newY))
            {
                XCoordinate = newX;
                YCoordinate = newY;
                _firstMove = false;
                if (YCoordinate == 7 || YCoordinate == 0) _direction = !_direction;
            }
        }

        private bool ValidMove(MovementType move, int newX, int newY)
        {
            //check to see if Pawn is on board
            var onBoard = _chessBoard.IsLegalBoardPosition(newX, newY);

            //check to see if pawn is going in the right direction
            var rightDirection = (((newY - YCoordinate) > 0) == _direction);

           if (onBoard && rightDirection)
                {
                    //check to see if pawn made normal move
                    if ((move == MovementType.Move) && (newX == XCoordinate))
                    {
                        //check to see if number of positions moved is correct
                        if ((Math.Abs(newY - YCoordinate) == 1) || ((Math.Abs(newY - YCoordinate) == 2) && _firstMove))
                        {
                            return true;
                        }
                    }
                    //check to see if pawn made capture move
                    if ((move == MovementType.Capture) && (newY != YCoordinate) && (newX != XCoordinate))
                    {
                        if ((Math.Abs(newY - YCoordinate) == 1) && (Math.Abs(newX - XCoordinate) == 1))
                        {
                            return true;
                        }
                    }
                }
            return false;
        }



      
    }
}
