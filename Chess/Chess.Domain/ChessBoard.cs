using Chess.Domain.Interfaces;
using Chess.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Domain
{
    public class ChessBoard : IChessBoard
    {
        public int MaxBoardWidth { get; }
        public int MaxBoardHeight { get; }
        public List<IPiece> Pieces { get; }

        public ChessBoard(int maxBoardWidth, int maxBoardHeight)
        {
            Pieces = new List<IPiece>();
            MaxBoardWidth = maxBoardWidth;
            MaxBoardHeight = maxBoardHeight;
        }

        public void AddPiece(IPiece piece)
        {
            if (IsLegalBoardPosition(piece.Position) &&  EmptySpace(piece.Position))
            {
                Pieces.Add(piece);
            }
            else
            {
                Console.WriteLine("Piece added to board failed. Position outside of chessboard :( ");
                Console.ReadLine();
            }
        }

        public void CanMoveToPosition(Position position)
        {
            
        }

        public bool IsLegalBoardPosition(Position position)
        {
            if((position.XCoordinate >= 0) && (position.XCoordinate <= MaxBoardWidth) 
                && (position.YCoordinate >=0) && (position.YCoordinate <= MaxBoardHeight))
            {
                return true;
            }
            return false;
        }

        public bool UnobstructedPosition(Position position, PieceColor pieceColor)
        {
            return !Pieces.Any(x => x.PieceColor == pieceColor 
                                && x.Position == position);
        }

        public void CheckIfCanCapturePiece(Position position, PieceColor pieceColor)
        {
            foreach (var piece in Pieces.Where(x => x.PieceColor != pieceColor))
            {
                if (piece.Position == position)
                {
                    if (piece.GetType().Name == "King")
                    {
                        Pieces.RemoveAll(x => x.PieceColor != pieceColor);
                        Console.WriteLine(pieceColor + " kingdom has won!");
                        Console.ReadLine();
                    }
                    Pieces.Remove(piece);
                    break;
                }
            }
        }


        private bool EmptySpace(Position position)
        {
            return Pieces.All(x => x.Position != position);
        }

    }
}
