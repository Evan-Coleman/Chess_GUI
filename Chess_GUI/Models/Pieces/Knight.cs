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

        public override bool LegalMove(Board InternalBoard, int initalX, int initialY, int targetX, int targetY)
        {
            throw new NotImplementedException();
        }

        public bool ValidMove(List<List<Piece>> board, int X1, int Y1, int X2, int Y2)
        {
            bool isBlack = board[X1][Y1]._isBlack;

            //catchall errorchecking section
            if (X2 > 8 || X2 < 1 || Y1 > 8 || Y1 < 1)   // checks for out of bounds
                return false;
            for (int i = 0; i < 6; i++)
            { // makes sure you aren't trying to take your own piece
                if (board[X2][Y2]._isBlack && isBlack == true || !board[X2][Y2]._isBlack && isBlack == false) // FIX THIS MAYBE WRONG
                    return false;
            }
            if (Math.Abs(X1 - X2) == 2 && Math.Abs(Y1 - Y2) != 1 || Math.Abs(Y1 - Y2) == 2 && Math.Abs(X1 - X2) != 1)   // this checks to see if the move is in valid form
                return false;
            //catchall errorchecking section





            if (board[X2][Y2].Name == base.knight[0] || board[X2][Y2].Name == base.knight[1])   // check to see if knight is taking a king
                                                                                                //return 2;                                // NOTE! FIX THIS!

                board[X1][Y1] = new EmptyPiece(true);        // these two actually move the piece
            board[X2][Y2] = new Knight(isBlack);






            return true;
        }
    }
}
