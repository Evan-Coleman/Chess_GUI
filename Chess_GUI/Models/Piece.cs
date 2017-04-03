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
        protected Piece(bool isBlack)
        {
            _isBlack = isBlack;
        }

        // Name will contain the piece's unicode character
        public char Name { get; set; }

        // Unicode characters for White chess pieces
        public string WPiece = "♔♕♖♗♘♙";
        // Unicode characters for Black chess pieces
        public string BPiece = "♚♛♜♝♞♟";

        // Used to check if empty space
        public string zero = "\0";

        public string king = "♚♔";
        public string queen = "♛♕";
        public string rook = "♜♖";
        public string bishop = "♝♗";
        public string knight = "♞♘";
        public string pawn = "♟♙";

        // True if piece is black
        public bool _isBlack;

        public abstract bool LegalMove(Board InternalBoard, int initalX, int initialY, int targetX, int targetY);

    }
}
