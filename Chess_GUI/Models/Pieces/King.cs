using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models.Pieces
{
    public class King : Piece
    {
        public King(bool isBlack) : base(isBlack)
        {
        }

        public override bool LegalMove(Board InternalBoard, int initalX, int initialY, int targetX, int targetY)
        {
            throw new NotImplementedException();
        }
    }
}
