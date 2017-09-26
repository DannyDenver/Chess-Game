using Chess.Domain.Models;
using NUnit.Framework;

namespace Chess.Domain.UnitTests
{
    [TestFixture]
    public class PawnTests
    {
        private ChessBoard _chessBoard;
        private Pawn _pawnBlack1;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard(7, 7);
            _pawnBlack1 = new Pawn(_chessBoard, PieceColor.Black, new Position(6, 3), false);  //possibly pass in array of positions to new up all blackpawns and lower memory usage
            _chessBoard.AddPiece(_pawnBlack1);
        }
        
        [Test]
        public void
            _01_placing_the_black_pawn_on_X_equals_6_and_Y_equals_3_should_place_the_black_pawn_on_that_place_on_the_board()
        {
            _chessBoard.AddPiece(_pawnBlack1);
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void
            _10_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_7_and_Y_eqauls_3_should_not_move_the_pawn()
        {

            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(7, 3));
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void
            _11_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_4_and_Y_eqauls_3_should_not_move_the_pawn()
        {
            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(4, 3));
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void
            _20_making_a_legal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_6_and_Y_eqauls_2_should_move_the_pawn()
        {
            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(6, 2));
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void
            _21_making_a_legal_move_by_placing_the_black_pawn_on_X_equals_0_and_Y_eqauls_6_and_moving_to_X_equals_0_and_Y_eqauls_4_on_first_move_should_move_the_pawn()
        {
            _pawnBlack1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);

            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(0, 4));
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(0));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void
            _22_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_0_and_Y_eqauls_5_and_moving_to_X_equals_0_and_Y_eqauls_3_on_2nd_move_should_not_move_the_pawn()
        {
            _pawnBlack1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 5), false);
            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(0, 3));
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(0));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(5));
        }

        [Test]
        public void
            _23_making_a_legal_move_by_placing_the_black_pawn_on_X_equals_3_and_Y_eqauls_1_and_moving_to_X_equals_3_and_Y_eqauls_0_not_first_move_should_move_the_pawn()
        {
            _pawnBlack1 = new Pawn(_chessBoard, PieceColor.Black, new Position(3, 1), false);
            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(3, 0));
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(3));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void _24_making_a_legal_move_and_change_direction_not_first_move()
        {
            _pawnBlack1 = new Pawn(_chessBoard, PieceColor.Black, new Position(3, 1), false);
            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(3, 0));
            _pawnBlack1.Move(new Position(3, 1));
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(3));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void _25_making_an_illegal_move_and_change_direction_not_first_move_does_not_move()
        {
            _pawnBlack1 = new Pawn(_chessBoard, PieceColor.Black, new Position(3, 2), false);
            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(3, 3));
            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(3));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void _26_return_current_data_on_piece_from_abstract_class_Piece()
        {
            _pawnBlack1 = new Pawn(_chessBoard, PieceColor.Black, new Position(3, 2), false);
            _chessBoard.AddPiece(_pawnBlack1);
            _pawnBlack1.Move(new Position(3, 3));
            Assert.That("Current X: 3 Current Y: 2 Piece Color: Black Piece: Pawn",
                Is.EqualTo(_pawnBlack1.CurrentPosition()));
        }

        [Test]
        public void
            _blackPawn1_makes_illegal_move_from_X_equals_6_Y_equals_3_to_x_equals_6_equals_2_where_white_pawn_occupies_space_does_not_move()
        {
            var _pawnWhite1 = new Pawn(_chessBoard, PieceColor.White, new Position(6, 2), false);

            _chessBoard.AddPiece(_pawnWhite1);
            _pawnBlack1.Move(new Position(6, 2));

            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void
            _blackPawn1_makes_legal_capture_move_from_X_equals_6_Y_equals_3_to_x_equals_5_Y_equals_2_where_white_pawn_occupies_space()
        {
            var pawnWhite1 = new Pawn(_chessBoard, PieceColor.White, new Position(5, 2), false);
            _chessBoard.AddPiece(pawnWhite1);
            var pieceCountBefore = _chessBoard.Pieces.Count;

            _pawnBlack1.Move(new Position(5, 2));

            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(5));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(2));
            Assert.That((pieceCountBefore - 1), Is.EqualTo(_chessBoard.Pieces.Count));
        }

        [Test]
        public void
            _blackPawn1_makes_legal_move_from_X_equals_6_Y_equals_3_to_x_equals_6_equals_2()
        {
            _pawnBlack1.Move(new Position(6, 2));

            Assert.That(_pawnBlack1.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawnBlack1.Position.YCoordinate, Is.EqualTo(2));
        }


    }
}