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
            base.Name = isBlack ? base.King[0] : base.King[1];
        }

        public override int LegalMove(List<List<Piece>> internalBoard, int initalRow, int initialColumn, int targetRow, int targetColumn)
        {
            throw new NotImplementedException();
        }
    }
}
