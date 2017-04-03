using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models.Pieces
{
    public class EmptyPiece : Piece
    {
        public EmptyPiece(bool isBlack) : base(isBlack)
        {
        }

        public override bool LegalMove(Board InternalBoard, int initalX, int initialY, int targetX, int targetY)
        {
            throw new NotImplementedException();
        }
    }
}
