using System;

namespace Chess_GUI.Models.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isBlack) : base(isBlack)
        {
            base.Name = isBlack ? base.Bishop[0] : base.Bishop[1];
        }

        public override int LegalMove(Board internalBoard, int sourceRow, int sourceColumn, int destRow, int destColumn)
        {
            bool isBlack = internalBoard[sourceRow][sourceColumn].Piece.IsBlack;

            //catchall errorchecking section
            if (destRow > 7 || destRow < 0 || sourceColumn > 7 || sourceColumn < 0) // checks for out of bounds
                return 0;
            // makes sure you aren't trying to take your own piece
            if (internalBoard[destRow][destColumn].Piece.IsBlack == isBlack && internalBoard[destRow][destColumn].Piece.Name != '\0')
                return 0;

            if (Math.Abs(sourceRow - destRow) != Math.Abs(sourceColumn - destColumn))   // this checks to see if the move is in valid form
                return 0;
            if (sourceRow < destRow && sourceColumn > destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // bishop can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow + i][sourceColumn - i].Piece.Name != '\0')
                        return 0;
                }
            }
            else if (sourceRow > destRow && sourceColumn < destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // bishop can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow - i][sourceColumn + i].Piece.Name != '\0')
                        return 0;
                }

            }
            else if (sourceRow > destRow && sourceColumn > destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // bishop can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow - i][sourceColumn - i].Piece.Name != '\0')
                        return 0;
                }
            }
            else
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // bishop can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow + i][sourceColumn + i].Piece.Name != '\0')
                        return 0;
                }
            }
            //catchall errorchecking section

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
