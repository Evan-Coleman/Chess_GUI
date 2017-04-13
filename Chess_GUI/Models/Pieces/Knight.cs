using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models.Pieces
{
    public class Knight : Piece
    {
        public Knight(bool isBlack) : base(isBlack)
        {
            base.Name = isBlack ? base.Knight[0] : base.Knight[1];
        }

        public override int LegalMove(Board internalBoard, int sourceRow, int sourceColumn, int destRow, int destColumn)
        {
            bool isBlack = internalBoard[sourceRow][sourceColumn].Piece.IsBlack;

            //catchall errorchecking section
            if (destRow > 7 || destRow < 0 || sourceColumn > 7 || sourceColumn < 0)   // checks for out of bounds
                return 0;

            // makes sure you aren't trying to take your own piece
            if (internalBoard[destRow][destColumn].Piece.IsBlack == isBlack && internalBoard[destRow][destColumn].Piece.Name != '\0') // FIX THIS MAYBE WRONG
                return 0;

            if (Math.Abs(sourceRow - destRow) == 2 && Math.Abs(sourceColumn - destColumn) != 1 || Math.Abs(sourceColumn - destColumn) == 2 && Math.Abs(sourceRow - destRow) != 1)   // this checks to see if the move is in valid form
                return 0;

            //catchall errorchecking section
            if (internalBoard[destRow][destColumn].Piece.Name == base.King[0] || internalBoard[destRow][destColumn].Piece.Name == base.King[1]) // check to see if knight is taking a king
            {
                return 2;
            } // reutnrs 2 on king take and game win

            internalBoard[sourceRow][sourceColumn].Piece = new EmptyPiece(true);        // these two actually move the piece
            internalBoard[destRow][destColumn].Piece = new Knight(isBlack);






            return 1;
        }
    }
}
