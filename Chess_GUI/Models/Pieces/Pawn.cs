using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(bool isBlack) : base(isBlack)
        {
            base.Name = isBlack ? base.Pawn[0] : base.Pawn[1];
        }


        public override int LegalMove(List<List<Piece>> internalBoard, int sourceRow, int sourceColumn, int destRow, int destColumn)
        {
            bool isBlack = internalBoard[sourceRow][sourceColumn].IsBlack;
            int win = 0; // if a king get taken will be set to 1
            //catchall errorchecking section
            if (Math.Abs(sourceRow - destRow) > 2)   // fail if trying to move more than 2 spaces
                return 0;
            if (Math.Abs(sourceRow - destRow) == 2)
            {   // fail if trying to move 2 spaces when pawn is not in it's starting position
                if (internalBoard[sourceRow][sourceColumn].IsBlack == true)
                {
                    if (sourceRow != 2)
                        return 0;
                }
                else
                    if (sourceRow != 6)
                    return 0;
            }
            if (Math.Abs(sourceColumn - destColumn) > 1) // fail on moving laterally too far
                return 0;
            if (isBlack == true && destRow < 0)  // fail on moving out of bounds
                return 0;
            if (isBlack == false && destRow > 7)  // ^
                return 0;
            if (Math.Abs(sourceColumn - destColumn) == 1 && Math.Abs(destRow - sourceRow) < 1)    // fail on lateral move with no vertical movement
                return 0;
            if (isBlack == true && destRow - sourceRow < 1)  // fail on moving backwards
                return 0;
            if (isBlack == false && sourceRow - destRow < 1)  // ^
                return 0;
            // makes sure you aren't trying to take your own piece
            if (internalBoard[destRow][destColumn].IsBlack == isBlack)
                return 0;

            //catchall errorchecking section


            if (sourceColumn == destColumn)
            {
                for (int i = sourceRow - 1; i >= destRow; i--)
                {       // catches for white going up, not black going down
                    if (internalBoard[i][sourceColumn].Name != '\0')
                        return 0;
                }
                internalBoard[sourceRow][sourceColumn] = new EmptyPiece(true);
                internalBoard[destRow][destColumn] = new Pawn(isBlack);
            }
            else
            {
                if (internalBoard[destRow][destColumn].Name == '\0')  // fail if trying to attack empty space
                    return 0;
                internalBoard[sourceRow][sourceColumn] = new EmptyPiece(true);
                if (internalBoard[destRow][destColumn].Name == base.King[0] || internalBoard[destRow][destColumn].Name == base.King[1]) // check to see if pawn is taking a king
                    win = 1;
                internalBoard[sourceRow][sourceColumn] = new EmptyPiece(true);
                internalBoard[destRow][destColumn] = new Pawn(isBlack);
                if (win == 1)
                    return 2;
            }

            //            if (destRow == 1 && isBlack == false || destRow == 8 && isBlack == true)
            //            {       // if a pawn gets to the end will promote it
            //                cout << "Your pawn has reached the other side and must be promoted, type the letter for ";
            //                cout << "any piece besides I/i for king and P/p for pawn! (Be mindful of your pieces being either capitol or not)" << endl;
            //                while (1)
            //                {
            //                    getline(cin, piece);
            //                    if (isBlack == false)
            //                        if (piece[0] == 'q' || piece[0] == 'r' || piece[0] == 'b' || piece[0] == 'k')
            //                            correct = 1;
            //                    if (isBlack == true)
            //                        if (piece[0] == 'Q' || piece[0] == 'R' || piece[0] == 'B' || piece[0] == 'K')
            //                            correct = 1;
            //
            //                    if (correct == 1)
            //                    {
            //                        internalBoard[destRow][destColumn] = piece[0];
            //                        break;
            //                    }
            //                    else
            //                        cout << "You entered an invalid choice, try again!";
            //                }
            //                return 1;
            //            }


            return 1;
        }
    }
}
