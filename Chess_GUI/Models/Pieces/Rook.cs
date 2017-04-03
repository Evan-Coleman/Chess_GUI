using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Chess_GUI.Models.Pieces
{
    public class Rook : Piece
    {
        public Rook(bool isBlack) : base(isBlack)
        {
        }

        public override bool LegalMove(Board InternalBoard, int initalX, int initialY, int targetX, int targetY)
        {
            throw new NotImplementedException();
        }
    }
}
