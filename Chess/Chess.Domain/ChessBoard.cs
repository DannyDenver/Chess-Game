using System;
using System.Collections.Generic;
using Chess.Domain.Interfaces;

namespace Chess.Domain
{
    public class ChessBoard : IChessBoard
    {
        internal const int MaxBoardWidth = 7;
        internal const int MaxBoardHeight = 7;
        public List<IPiece> pieces;

        public ChessBoard()
        {
            pieces = new List<IPiece>();
        }
        

        public void AddPiece(IPiece piece)
        {
            if (this.IsLegalBoardPosition(piece.XCoordinate, piece.YCoordinate))
            {
                pieces.Add(piece);
            }
            else
            {
                Console.WriteLine("Piece added to board failed. Position outside of chessboard :( ");
                Console.ReadLine();
            }
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            if((xCoordinate >= 0) && (xCoordinate <= 7) && (yCoordinate >=0) && (yCoordinate <= 7))
            {
                return true;
            }
            return false;
        }

    }
}
