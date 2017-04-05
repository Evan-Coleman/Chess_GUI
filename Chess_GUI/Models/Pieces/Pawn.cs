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
            base.Name = isBlack ? base.pawn[0] : base.pawn[1];
        }


        public override bool LegalMove(List<List<Piece>> InternalBoard, int initalX, int initialY, int targetX, int targetY)
        {
            throw new NotImplementedException();
        }
    }
}
