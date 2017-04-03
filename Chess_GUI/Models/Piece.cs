using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Chess_GUI.ViewModels;

namespace Chess_GUI.Models
{
    public abstract class Piece
    {
        public Piece(Board InternalBoard, int x1, int y1, int x2, int y2)
        {
            _board = InternalBoard;
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
        }

        // Name will contain the piece's unicode character
        public string Name { get; set; }

        // Unicode characters for White chess pieces
        private string WPiece = "♔♕♖♗♘♙";
        // Unicode characters for Black chess pieces
        private string BPiece = "♚♛♜♝♞♟";

        // Used to check if empty space
        private string zero = "\0";

        private string king = "♚♔";
        private string queen = "♛♕";
        private string rook = "♜♖";
        private string bishop = "♝♗";
        private string knight = "♞♘";
        private string pawn = "♟♙";

        // Initial coords
        private int _x1;
        private int _y1;

        // Proposed final coords
        private int _x2;
        private int _y2;

        // Board to be used to check valid moves internally
        private Board _board;

        public abstract bool LegalMove();

    }
}
