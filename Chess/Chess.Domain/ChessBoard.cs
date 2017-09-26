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
        public List<IPiece> Pieces { get; } //change to array? faster, but harder to manage

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
                //Console.ReadLine();
            }
        }
        
        public bool IsLegalBoardPosition(Position position, PieceColor pieceColor)
        {
            //check if any of own pieces are in the way
            var freeOfOwnPieces = Pieces.Count == 0 || EmptySpace(position, pieceColor);

            return (freeOfOwnPieces && OnBoard(position));
        }

        public bool CheckIfCanCapturePiece(Position position, PieceColor pieceColor)
        {
            var opposingPieces = Pieces.Where(x => x.PieceColor != pieceColor);

            foreach (var piece in opposingPieces)
            {
                if(EqualPositions(piece.Position, position))
                {
                    if (piece.GetType().Name == "King")
                    {
                        return EndGame(pieceColor);
                    }
                    Pieces.Remove(piece);

                    return true;
                }
            }
            return false;
        }

        public bool EmptySpace(Position position, PieceColor? pieceColor = null)
        {
            var pieces = Pieces.Where(x => EqualPositions(x.Position, position));

            if (pieceColor != null)
            {
                return pieces.All(x => x.PieceColor != pieceColor);
            }

            return !(pieces.Any());
        }

        private bool OnBoard(Position position)
        {
            if (position.XCoordinate >= 0 && position.XCoordinate <= MaxBoardWidth
                && position.YCoordinate >= 0 && position.YCoordinate <= MaxBoardHeight)
            {
                return true;
            }
            return false;
        }

        private bool EqualPositions(Position positionOne, Position positionTwo)
        {
            if(positionOne.XCoordinate == positionTwo.XCoordinate &&
                positionOne.YCoordinate == positionTwo.YCoordinate)
                {
                    return true;
                }
            return false;
        }

        private bool EndGame(PieceColor pieceColor)
        {
            Pieces.RemoveAll(x => x.PieceColor != pieceColor); 
            Console.WriteLine(pieceColor + " kingdom has won!");
            //Console.ReadLine(); messes with unit tests
            return true;
        }


    }
}
