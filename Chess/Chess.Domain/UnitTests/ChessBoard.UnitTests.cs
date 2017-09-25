using System.Linq;
using Chess.Domain.Models;
using NUnit.Framework;

namespace Chess.Domain.UnitTests
{
    [TestFixture]
    public class ChessBoardTests
    {
        private ChessBoard _chessBoard;
        private Bishop _blackBishop1;
        private King _whiteKing;


        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard(7, 7);
            _blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(6, 2));
            _whiteKing = new King(_chessBoard, PieceColor.White, new Position(4, 0));

            _chessBoard.AddPiece(_blackBishop1);
            _chessBoard.AddPiece(_whiteKing);

            var whitePawn1 = new Pawn(_chessBoard, PieceColor.White, new Position(0, 1), true);
            var whitePawn2 = new Pawn(_chessBoard, PieceColor.White, new Position(1, 1), true);
            var whitePawn3 = new Pawn(_chessBoard, PieceColor.White, new Position(2, 1), true);
            var whitePawn4 = new Pawn(_chessBoard, PieceColor.White, new Position(3, 1), true);

            _chessBoard.AddPiece(whitePawn1);
            _chessBoard.AddPiece(whitePawn2);
            _chessBoard.AddPiece(whitePawn3);
            _chessBoard.AddPiece(whitePawn4);
        }

        [Test]
        public void _001_the_playing_board_should_have_a_Max_Board_Width_of_7()
        {
            Assert.That(_chessBoard.MaxBoardWidth, Is.EqualTo(7));
        }

        [Test]
        public void _002_the_playing_board_should_have_a_Max_Board_Height_of_7()
        {
            Assert.That(_chessBoard.MaxBoardHeight, Is.EqualTo(7));
        }

        [Test]
        public void _005_the_playing_board_should_know_that_X_equals_0_and_Y_equals_0_is_a_valid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Position(0, 0), PieceColor.Black);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void _006_the_playing_board_should_know_that_X_equals_5_and_Y_equals_5_is_a_valid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Position(5, 5), PieceColor.Black);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void _010_the_playing_board_should_know_that_X_equals_11_and_Y_equals_5_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Position(11, 5), PieceColor.Black);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void _011_the_playing_board_should_know_that_X_equals_0_and_Y_equals_8_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Position(0, 9), PieceColor.Black);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void _011_the_playing_board_should_know_that_X_equals_11_and_Y_equals_0_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Position(11, 0), PieceColor.Black);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void
            _012_the_playing_board_should_know_that_X_equals_minus_1_and_Y_equals_5_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Position(-1, 5), PieceColor.Black);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void
            _012_the_playing_board_should_know_that_X_equals_5_and_Y_equals_minus_1_is_an_invalid_board_position()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(new Position(5, -1), PieceColor.Black);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void _013_the_playing_board_should_know_two_pieces_of_same_color_cannot_occupy_same_position()
        {
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);
            var blackPawn2 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);

            _chessBoard.AddPiece(blackPawn1);

            var pieceCount = _chessBoard.Pieces.Count();

            _chessBoard.AddPiece(blackPawn2);

            Assert.That(pieceCount, Is.EqualTo(_chessBoard.Pieces.Count()));
        }

        [Test]
        public void _014_the_playing_board_should_know_the_correct_number_of_pieces()
        {
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);
            var blackPawn2 = new Pawn(_chessBoard, PieceColor.Black, new Position(1, 6), true);

            _chessBoard.AddPiece(blackPawn1);
            _chessBoard.AddPiece(blackPawn2);

            Assert.That(_chessBoard.Pieces.Count, Is.EqualTo(8));
        }

        [Test]
        public void _015_IsLegalBoardPosition_returns_false_same_color_piece_in_way()
        {
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);

            _chessBoard.AddPiece(blackPawn1);

            Assert.That(_chessBoard.IsLegalBoardPosition(new Position(0, 6), PieceColor.Black), Is.False);
        }

        [Test]
        public void _016_IsLegalBoardPosition_returns_false_not_onBoard()
        {
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);

            _chessBoard.AddPiece(blackPawn1);

            Assert.That(_chessBoard.IsLegalBoardPosition(new Position(0, 68), PieceColor.Black), Is.False);
        }

        [Test]
        public void
            _017_black_bishop_captures_white_king_all_white_pieces_are_removed()
        {
            Assert.That(_chessBoard.Pieces.Count(x => x.PieceColor == PieceColor.White), Is.EqualTo(5));

            //act
            _blackBishop1.Move(new Position(4, 0));

            Assert.That(_blackBishop1.Position.XCoordinate, Is.EqualTo(4));
            Assert.That(_blackBishop1.Position.YCoordinate, Is.EqualTo(0));

            Assert.That(_chessBoard.Pieces.Count(x => x.PieceColor == PieceColor.White), Is.EqualTo(0));
        }

    }
}