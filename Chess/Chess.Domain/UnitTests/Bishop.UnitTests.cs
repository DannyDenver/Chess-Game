using System.Linq;
using Chess.Domain.Models;
using NUnit.Framework;

namespace Chess.Domain.UnitTests
{
    [TestFixture]
    public class BishopTests
    {
        private ChessBoard _chessBoard;
        private Bishop _bishop;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard(7, 7);
            _bishop = new Bishop(_chessBoard, PieceColor.Black, new Position(6, 3));
        }

        [Test]
        public void _01_successfully_add_black_bishops_to_chessboard()
        {
            var blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(2, 7));
            var blackBishop2 = new Bishop(_chessBoard, PieceColor.Black, new Position(5, 7));
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);

            _chessBoard.AddPiece(blackBishop1);
            _chessBoard.AddPiece(blackBishop2);
            _chessBoard.AddPiece(blackPawn1);

            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Bishop"), Is.EqualTo(2));
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn"), Is.EqualTo(1));
        }

        [Test]
        public void
            _01_placing_the_black_bishop_on_X_equals_6_and_Y_equals_3_should_place_the_black_pawn_on_that_place_on_the_board()
        {
            //setup
            var blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(5, 7));

            //act
            _chessBoard.AddPiece(blackBishop1);
            var piece = _chessBoard.Pieces.SingleOrDefault(x => x.GetType().Name == "Bishop");

            //assert
            Assert.That(piece.Position.XCoordinate, Is.EqualTo(5));
            Assert.That(piece.Position.YCoordinate, Is.EqualTo(7));
        }

        [Test]
        public void
            _10_making_an_illegal_move_by_placing_the_black_bishop_on_X_equals_5_and_Y_eqauls_7_and_moving_to_X_equals_7_and_Y_eqauls_7_should_not_move_the_bishop()
        {
            //assemble
            var blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(5, 7));
            _chessBoard.AddPiece(blackBishop1);

            //act
            blackBishop1.Move(new Position(7, 7));

            //assert
            Assert.That(blackBishop1.Position.XCoordinate, Is.EqualTo(5));
            Assert.That(blackBishop1.Position.YCoordinate, Is.EqualTo(7));
        }

        [Test]
        public void
            _11_making_a_legal_move_by_placing_the_black_bishop_on_X_equals_5_and_Y_eqauls_7_and_moving_to_X_equals_2_and_Y_eqauls_4_should_move_the_pawn()
        {
            //assemble
            var blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(5, 7));
            _chessBoard.AddPiece(blackBishop1);

            blackBishop1.Move(new Position(2, 4));
            Assert.That(blackBishop1.Position.XCoordinate, Is.EqualTo(2));
            Assert.That(blackBishop1.Position.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void
            _12_making_a_legal_capture_by_placing_the_black_bishop_on_X_equals_5_and_Y_eqauls_7_and_moving_to_X_equals_2_and_Y_eqauls_4_should_capture_white_pawn_at_X_equals_2_and_Y_eqauls_4_()
        {
            //assemble
            var whitePawn1 = new Pawn(_chessBoard, PieceColor.White, new Position(2, 4), false);
            var blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(5, 7));

            _chessBoard.AddPiece(blackBishop1);
            _chessBoard.AddPiece(whitePawn1);

            //assert before capture
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn" && x.PieceColor == PieceColor.White),
                Is.EqualTo(1));

            blackBishop1.Move(new Position(2, 4));
            Assert.That(blackBishop1.Position.XCoordinate, Is.EqualTo(2));
            Assert.That(blackBishop1.Position.YCoordinate, Is.EqualTo(4));
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn" && x.PieceColor == PieceColor.White),
                Is.EqualTo(0));
        }

        [Test]
        public void
            _13_make_an_illegal_move_by_placing_the_black_bishop_on_X_equals_5_and_Y_eqauls_7_and_moving_to_X_equals_2_and_Y_eqauls_4_should_not_move_with_black_pawn_at_X_equals_2_and_Y_eqauls_4_()
        {
            //assemble
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(2, 4), false);
            var blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(5, 7));

            _chessBoard.AddPiece(blackBishop1);
            _chessBoard.AddPiece(blackPawn1);

            //assert before capture
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn" && x.PieceColor == PieceColor.Black),
                Is.EqualTo(1));

            blackBishop1.Move(new Position(2, 4));
            Assert.That(blackBishop1.Position.XCoordinate, Is.EqualTo(5));
            Assert.That(blackBishop1.Position.YCoordinate, Is.EqualTo(7));
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn" && x.PieceColor == PieceColor.Black),
                Is.EqualTo(1));
        }
    }
}
