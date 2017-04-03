using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models.Pieces
{
    public class Rook : Piece
    {
        public bool ValidMove()
        {
            int whichKnight = 0;
            if (board[X1][Y1] == knight[1]) // whichKnight will be 1 if knight is little k (white)
                whichKnight = 1;

            //catchall errorchecking section
            if (X2 > 8 || X2 < 1 || Y1 > 8 || Y1 < 1)   // checks for out of bounds
                return 0;
            for (int i = 0; i < 6; i++)
            { // makes sure you aren't trying to take your own piece
                if (board[X2][Y2] == whitePiece[i] && whichKnight == 1 || board[X2][Y2] == blackPiece[i] && whichKnight == 0)
                    return 0;
            }
            if (abs(X1 - X2) == 2 && abs(Y1 - Y2) != 1 || abs(Y1 - Y2) == 2 && abs(X1 - X2) != 1)   // this checks to see if the move is in valid form
                return 0;
            //catchall errorchecking section





            if (board[X2][Y2] == 'i' || board[X2][Y2] == 'I')   // check to see if knight is taking a king
                return 2;

            board[X1][Y1] = zero[0];        // these two actually move the piece
            board[X2][Y2] = knight[whichKnight];






            return 1;
        }
    }
}
