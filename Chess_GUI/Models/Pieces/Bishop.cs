using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isBlack) : base(isBlack)
        {
            base.Name = isBlack ? base.Bishop[0] : base.Bishop[1];
        }

        public override int LegalMove(List<List<Piece>> internalBoard, int sourceRow, int sourceColumn, int destRow, int destColumn)
        {
            bool isBlack = internalBoard[sourceRow][sourceColumn].IsBlack;

            //catchall errorchecking section
            if (destRow > 7 || destRow < 0 || sourceColumn > 7 || sourceColumn < 0) // checks for out of bounds
                return 0;
            // makes sure you aren't trying to take your own piece
            if (internalBoard[destRow][destColumn].IsBlack == isBlack)
                return 0;

            if (Math.Abs(sourceRow - destRow) != Math.Abs(sourceColumn - destColumn))   // this checks to see if the move is in valid form
                return 0;
            if (sourceRow < destRow && sourceColumn > destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // bishop can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow + i][sourceColumn - i].Name != '\0')
                        return 0;
                }
            }
            else if (sourceRow > destRow && sourceColumn < destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // bishop can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow - i][sourceColumn + i].Name != '\0')
                        return 0;
                }

            }
            else if (sourceRow > destRow && sourceColumn > destColumn)
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // bishop can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow - i][sourceColumn - i].Name != '\0')
                        return 0;
                }
            }
            else
            {
                for (int i = 1; i < Math.Max(Math.Abs(sourceRow - destRow), Math.Abs(sourceColumn - destColumn)); i++)
                {   // bishop can't move through other pieces to get to it's destination
                    if (internalBoard[sourceRow + i][sourceColumn + i].Name != '\0')
                        return 0;
                }
            }
            //catchall errorchecking section





            if (internalBoard[destRow][destColumn].Name == base.King[0] || internalBoard[destRow][destColumn].Name == base.King[1]) // check to see if bishop is taking a king
                return 2;

            internalBoard[sourceRow][sourceColumn] = new EmptyPiece(true);        // these two actually move the piece
            internalBoard[destRow][destColumn] = new Bishop(isBlack);






            return 1;
        }
    }
}
