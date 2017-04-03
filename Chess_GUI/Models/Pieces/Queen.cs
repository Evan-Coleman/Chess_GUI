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
            base.Name = isBlack ? base.queen[0] : base.queen[1];
        }

        public override bool LegalMove(Board InternalBoard, int initalX, int initialY, int targetX, int targetY)
        {
            throw new NotImplementedException();
        }
    }
}
