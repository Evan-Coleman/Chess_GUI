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
            IsBlack = isBlack;
        }

        // Name will contain the piece's unicode character
        public char Name { get; set; }

        // Unicode characters for White chess pieces
        protected string WPiece = "♔♕♖♗♘♙";
        // Unicode characters for Black chess pieces
        protected string BPiece = "♚♛♜♝♞♟";

        // Used to check if empty space
        protected string zero = "\0";

        protected string king = "♚♔";
        protected string queen = "♛♕";
        protected string rook = "♜♖";
        protected string bishop = "♝♗";
        protected string knight = "♞♘";
        protected string pawn = "♟♙";

        // True if piece is black
        internal bool IsBlack;

        public abstract bool LegalMove(List<List<Piece>> internalBoard, int initalX, int initialY, int targetX, int targetY);

    }
}
