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
            if (OnBoard(piece.Position) &&  EmptySpace(piece.Position))
            {
                Pieces.Add(piece);
            }
            else
            {
                Console.WriteLine("Piece added to board failed. Position outside of chessboard :( ");
                Console.ReadLine();
            }
        }
        
        public bool IsLegalBoardPosition(Position position, PieceColor pieceColor)
        {
            //check if any of own pieces are in the way
            var freeOfOwnPieces = Pieces.Count == 0 || !Pieces.Any(x => x.PieceColor == pieceColor
                                                                       && x.Position.XCoordinate == position.XCoordinate &&
                                                                       x.Position.YCoordinate == position.YCoordinate); 

            return (freeOfOwnPieces && OnBoard(position));
        }

        public bool CheckIfCanCapturePiece(Position position, PieceColor pieceColor)
        {
            foreach (var piece in Pieces.Where(x => x.PieceColor != pieceColor))
            {
                if ((piece.Position.XCoordinate == position.XCoordinate) &&
                    (piece.Position.YCoordinate == position.YCoordinate))
                {
                    if (piece.GetType().Name == "King")
                    {
                        Pieces.RemoveAll(x => x.PieceColor != pieceColor);
                        Console.WriteLine(pieceColor + " kingdom has won!");
                        Console.ReadLine();
                        return true;
                    }
                    Pieces.Remove(piece);
                    return true;
                }
            }
            return false;
        }


        private bool EmptySpace(Position position)
        {
            return !Pieces.Any(x => x.Position.XCoordinate == position.XCoordinate && x.Position.YCoordinate == position.YCoordinate);
        }

        private bool OnBoard(Position position)
        {
            if ((position.XCoordinate >= 0) && (position.XCoordinate <= MaxBoardWidth)
                && (position.YCoordinate >= 0) && (position.YCoordinate <= MaxBoardHeight))
            {
                return true;
            }
            return false;
        }
    }
}
