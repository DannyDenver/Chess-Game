using Chess.Domain.Interfaces;
using Chess.Domain.Models;

namespace Chess.Domain
{
    public class King : Piece, IPiece
    {
        private IChessBoard _chessBoard { get; }

        public override void Move(Position newPosition)
        {
            throw new System.NotImplementedException();
        }

        public King(IChessBoard chessBoard, PieceColor color, Position position) : base(color, position)
        {
            _chessBoard = chessBoard;
        }
    }
}
