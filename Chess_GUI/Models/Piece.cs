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

        // True if piece is black
        private bool _isBlack;

        public abstract bool LegalMove(Board InternalBoard, int initalX, int initialY, int targetX, int targetY);

    }
}
