using System.Linq;
using System.Runtime.Remoting;
using Chess.Domain.Models;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Chess.Domain
{
    [TestFixture]
    public class When_creating_a_chess_board
    {
        private ChessBoard _chessBoard;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard(7, 7);
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
            _chessBoard.AddPiece(blackPawn2);

            Assert.That(_chessBoard.Pieces.Count, Is.EqualTo(1));
        }

        [Test]
        public void _014_the_playing_board_should_know_the_correct_number_of_pieces()
        {
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);
            var blackPawn2 = new Pawn(_chessBoard, PieceColor.Black, new Position(1, 6), true);

            _chessBoard.AddPiece(blackPawn1);
            _chessBoard.AddPiece(blackPawn2);

            Assert.That(_chessBoard.Pieces.Count, Is.EqualTo(2));
        }

        [Test]
        public void _015_IsLegalBoardPosition_returns_false()
        {
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);

            _chessBoard.AddPiece(blackPawn1);

            Assert.That(_chessBoard.IsLegalBoardPosition(new Position(0, 6), PieceColor.Black), Is.False);
        }
    }

    [TestFixture]
    public class When_using_a_black_pawn
    {
        private ChessBoard _chessBoard;
        private Pawn _pawn;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard(7, 7);
            _pawn = new Pawn(_chessBoard, PieceColor.Black, new Position(6, 3), false);
        }

        [Test]
        public void
            _01_placing_the_black_pawn_on_X_equals_6_and_Y_equals_3_should_place_the_black_pawn_on_that_place_on_the_board()
        {
            _chessBoard.AddPiece(_pawn);
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void
            _10_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_7_and_Y_eqauls_3_should_not_move_the_pawn()
        {

            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(7, 3));
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void
            _11_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_4_and_Y_eqauls_3_should_not_move_the_pawn()
        {
            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(4, 3));
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void
            _20_making_a_legal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_6_and_Y_eqauls_2_should_move_the_pawn()
        {
            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(6, 2));
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(6));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void
            _21_making_a_legal_move_by_placing_the_black_pawn_on_X_equals_0_and_Y_eqauls_6_and_moving_to_X_equals_0_and_Y_eqauls_4_on_first_move_should_move_the_pawn()
        {
            _pawn = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 6), true);

            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(0, 4));
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(0));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(4));
        }

        [Test]
        public void
            _22_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_0_and_Y_eqauls_5_and_moving_to_X_equals_0_and_Y_eqauls_3_on_2nd_move_should_not_move_the_pawn()
        {
            _pawn = new Pawn(_chessBoard, PieceColor.Black, new Position(0, 5), false);
            var position = _pawn.CurrentPosition();
            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(0, 3));
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(0));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(5));
        }

        [Test]
        public void
            _23_making_a_legal_move_by_placing_the_black_pawn_on_X_equals_3_and_Y_eqauls_1_and_moving_to_X_equals_3_and_Y_eqauls_0_not_first_move_should_move_the_pawn()
        {
            _pawn = new Pawn(_chessBoard, PieceColor.Black, new Position(3, 1), false);
            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(3, 0));
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(3));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(0));
        }

        [Test]
        public void _24_making_a_legal_move_and_change_direction_not_first_move()
        {
            _pawn = new Pawn(_chessBoard, PieceColor.Black, new Position(3, 1), false);
            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(3, 0));
            _pawn.Move(new Position(3, 1));
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(3));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void _25_making_an_illegal_move_and_change_direction_not_first_move_does_not_move()
        {
            _pawn = new Pawn(_chessBoard, PieceColor.Black, new Position(3, 2), false);
            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(3, 3));
            Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(3));
            Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(2));
        }

        [Test]
        public void _26_return_current_data_on_piece_from_abstract_class_Piece()
        {
            _pawn = new Pawn(_chessBoard, PieceColor.Black, new Position(3, 2), false);
            _chessBoard.AddPiece(_pawn);
            _pawn.Move(new Position(3, 3));
            Assert.That("Current X: 3 Current Y: 2 Piece Color: Black Piece: Pawn",
                Is.EqualTo(_pawn.CurrentPosition()));
        }
    }

    [TestFixture]
    public class When_using_a_bishop
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
            var blackPawn1 = new Pawn(_chessBoard, PieceColor.Black, new Position(0,6),true);

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

        //[Test]
        //public void
        //    _11_making_an_illegal_move_by_placing_the_black_pawn_on_X_equals_6_and_Y_eqauls_3_and_moving_to_X_equals_4_and_Y_eqauls_3_should_not_move_the_pawn()
        //{
        //    _chessBoard.AddPiece(_pawn);
        //    _pawn.Move(new Position(4, 3));
        //    Assert.That(_pawn.Position.XCoordinate, Is.EqualTo(6));
        //    Assert.That(_pawn.Position.YCoordinate, Is.EqualTo(3));
        //}

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
            var whitePawn1 = new Pawn(_chessBoard, PieceColor.White, new Position(2,4), false);
            var blackBishop1 = new Bishop(_chessBoard, PieceColor.Black, new Position(5, 7));

            _chessBoard.AddPiece(blackBishop1);
            _chessBoard.AddPiece(whitePawn1);

            //assert before capture
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn" && x.PieceColor == PieceColor.White), Is.EqualTo(1));

            blackBishop1.Move(new Position(2, 4));
            Assert.That(blackBishop1.Position.XCoordinate, Is.EqualTo(2));
            Assert.That(blackBishop1.Position.YCoordinate, Is.EqualTo(4));
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn" && x.PieceColor == PieceColor.White), Is.EqualTo(0));
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
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn" && x.PieceColor == PieceColor.Black), Is.EqualTo(1));

            blackBishop1.Move(new Position(2, 4));
            Assert.That(blackBishop1.Position.XCoordinate, Is.EqualTo(5));
            Assert.That(blackBishop1.Position.YCoordinate, Is.EqualTo(7));
            Assert.That(_chessBoard.Pieces.Count(x => x.GetType().Name == "Pawn" && x.PieceColor == PieceColor.Black), Is.EqualTo(1));
        }
    }

    [TestFixture]
    public class capture_king_ends_game
    {
        private ChessBoard _chessBoard;
        private Bishop _bishop;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard(7, 7);
            _bishop = new Bishop(_chessBoard, PieceColor.Black, new Position(6, 3));
            _chessBoard.AddPiece(_bishop);

        }
    }
