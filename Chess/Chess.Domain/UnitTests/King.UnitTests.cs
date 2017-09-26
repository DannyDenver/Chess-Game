using Chess.Domain.Models;
using NUnit.Framework;

namespace Chess.Domain.UnitTests
{
    [TestFixture]
    public class KingTests
    {
        private ChessBoard _chessBoard;
        private King _whiteKing;
        private Bishop _blackBishop1;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard(7, 7);

            _whiteKing = new King(_chessBoard, PieceColor.White, new Position(4, 0));
            _blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(6, 2));


            var whitePawn1 = new Pawn(_chessBoard, PieceColor.White, new Position(0, 1), true);
            var whitePawn2 = new Pawn(_chessBoard, PieceColor.White, new Position(1, 1), true);
            var whitePawn3 = new Pawn(_chessBoard, PieceColor.White, new Position(2, 1), true);
            var whitePawn4 = new Pawn(_chessBoard, PieceColor.White, new Position(3, 1), true);

            _chessBoard.AddPiece(_blackBishop1);
            _chessBoard.AddPiece(_whiteKing);

            _chessBoard.AddPiece(whitePawn1);
            _chessBoard.AddPiece(whitePawn2);
            _chessBoard.AddPiece(whitePawn3);
            _chessBoard.AddPiece(whitePawn4);
        }

      
        [Test]
        public void _1_whiteKing_makes_illegal_move_from_x_equals_4_y_equals_0_to_x_equals_3_y_equals_1_whitepawn4_blocking()
        {
            //act 
            _whiteKing.Move(new Position(3,1));

            Assert.That(_whiteKing.Position.XCoordinate, Is.EqualTo(4));
            Assert.That(_whiteKing.Position.YCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void _3_whiteKing_makes_legal_move_from_x_equals_4_y_equals_0_to_x_equals_5_y_equals_1()
        {
            //act 
            _whiteKing.Move(new Position(5, 1));

            Assert.That(_whiteKing.Position.XCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKing.Position.YCoordinate, Is.EqualTo(1));
        }
        [Test]
        public void _4_whiteKing_makes_legal_horizontal_move_from_x_equals_5_y_equals_1_to_x_equals_5_y_equals_0()
        {
            //act 
            _whiteKing.Move(new Position(5, 0));

            Assert.That(_whiteKing.Position.XCoordinate, Is.EqualTo(5));
            Assert.That(_whiteKing.Position.YCoordinate, Is.EqualTo(0));
        }
        [Test]
        public void _4_whiteKing_makes_legal_back_move_from_x_equals_6_y_equals_1_to_x_equals_6_y_equals_0()
        {
            _whiteKing = new King(_chessBoard, PieceColor.White, new Position(6,1));
            //act 
            _whiteKing.Move(new Position(6, 0));

            Assert.That(_whiteKing.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_whiteKing.Position.YCoordinate, Is.EqualTo(0));
        }
    }
}
