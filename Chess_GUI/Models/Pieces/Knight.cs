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
            base.Name = isBlack ? base.knight[0] : base.knight[1];
        }

        public override bool LegalMove(List<List<Piece>> board, int sourceX, int sourceY, int destX, int destY)
        {
            bool isBlack = board[sourceX][sourceY].IsBlack;

            //catchall errorchecking section
            if (destX > 8 || destX < 1 || sourceY > 8 || sourceY < 1)   // checks for out of bounds
                return false;

            // makes sure you aren't trying to take your own piece
            for (int i = 0; i < 6; i++)
            {
                if (board[destX][destY].IsBlack && isBlack == true || !board[destX][destY].IsBlack && isBlack == false) // FIX THIS MAYBE WRONG
                    return false;
            }
            if (Math.Abs(sourceX - destX) == 2 && Math.Abs(sourceY - destY) != 1 || Math.Abs(sourceY - destY) == 2 && Math.Abs(sourceX - destX) != 1)   // this checks to see if the move is in valid form
                return false;

            //catchall errorchecking section
            if (board[destX][destY].Name == base.knight[0] || board[destX][destY].Name == base.knight[1])   // check to see if knight is taking a king
                                                                                                            //return 2;                                // NOTE! FIX THIS!

                board[sourceX][sourceY] = new EmptyPiece(true);        // these two actually move the piece
            board[destX][destY] = new Knight(isBlack);






            return true;
        }
    }
}
