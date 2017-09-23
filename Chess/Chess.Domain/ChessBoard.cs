using System;
using System.Collections.Generic;
using Chess.Domain.Interfaces;
using Chess.Domain.Models;

namespace Chess.Domain
{
    public class ChessBoard : IChessBoard
    {
        internal const int MaxBoardWidth = 7;
        internal const int MaxBoardHeight = 7;
        private List<IPiece> _pieces = new List<IPiece>();

        public void AddPiece(IPiece piece)
        {
            if (this.IsLegalBoardPosition(piece.Position))
            {
                _pieces.Add(piece);
            }
            else
            {
                Console.WriteLine("Piece added to board failed. Position outside of chessboard :( ");
                Console.ReadLine();
            }
        }

        public bool IsLegalBoardPosition(Position position)
        {
            if((position.XCoordinate >= 0) && (position.XCoordinate <= 7) && (position.YCoordinate >=0) && (position.YCoordinate <= 7))
            {
                return true;
            }
            return false;
        }

    }
}
