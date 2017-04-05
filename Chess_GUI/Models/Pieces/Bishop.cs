using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isBlack) : base(isBlack)
        {
            base.Name = isBlack ? base.Bishop[0] : base.Bishop[1];
        }

        public override int LegalMove(List<List<Piece>> internalBoard, int initalRow, int initialColumn, int targetRow, int targetColumn)
        {
            throw new NotImplementedException();
        }
    }
}
