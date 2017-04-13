using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(bool isBlack) : base(isBlack)
        {
            base.Name = isBlack ? base.Queen[0] : base.Queen[1];
        }

        public override int LegalMove(Board internalBoard, int sourceRow, int sourceColumn, int destRow, int destColumn)
        {
            bool isBlack = internalBoard[sourceRow][sourceColumn].Piece.IsBlack;

            //catchall errorchecking section
            if (destRow > 7 || destRow < 0 || sourceColumn > 7 || sourceColumn < 0) // checks for out of bounds
                return 0;
            // makes sure you aren't trying to take your own piece
            if (internalBoard[destRow][destColumn].Piece.IsBlack == isBlack)
                return 0;
            if (sourceRow < destRow && sourceColumn == destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // queen can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow + i][sourceColumn].Piece.Name != '\0')
                        return 0;
                }
            }
            else if (sourceRow > destRow && sourceColumn == destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // queen can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow - i][sourceColumn].Piece.Name != '\0')
                        return 0;
                }

            }
            else if (sourceRow == destRow && sourceColumn > destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // queen can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow][sourceColumn - i].Piece.Name != '\0')
                        return 0;
                }
            }
            else if (sourceRow == destRow && sourceColumn < destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // queen can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow][sourceColumn + i].Piece.Name != '\0')
                        return 0;
                }
            }


            if (sourceRow < destRow && sourceColumn > destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // queen can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow + i][sourceColumn - i].Piece.Name != '\0')
                        return 0;
                }
            }
            else if (sourceRow > destRow && sourceColumn < destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // queen can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow - i][sourceColumn + i].Piece.Name != '\0')
                        return 0;
                }

            }
            else if (sourceRow > destRow && sourceColumn > destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // queen can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow - i][sourceColumn - i].Piece.Name != '\0')
                        return 0;
                }
            }
            else if (sourceRow < destRow && sourceColumn < destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // queen can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow + i][sourceColumn + i].Piece.Name != '\0')
                        return 0;
                }
            }
            //catchall errorchecking section





            if (internalBoard[destRow][destColumn].Piece.Name == base.King[0] || internalBoard[destRow][destColumn].Piece.Name == base.King[1]) // check to see if queen is taking a king
                return 2;
            internalBoard[sourceRow][sourceColumn].Piece = new EmptyPiece(true);        // these two actually move the piece
            internalBoard[destRow][destColumn].Piece = new Queen(isBlack);





            return 1;
        }
    }
}
