using System;

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

            if (internalBoard[destRow][destColumn].Piece.Name == base.King[0] ||
    internalBoard[destRow][destColumn].Piece.Name == base.King[1])
            {
                TakingKing = true;
            }

            internalBoard[sourceRow][sourceColumn].Piece = new EmptyPiece(true);        // these two actually move the piece
            internalBoard[destRow][destColumn].Piece = new Queen(isBlack);

            // Returns 2 if taking a king, 1 if not
            return TakingKing == true ? 2 : 1;
        }
    }
}
