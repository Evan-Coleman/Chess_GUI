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
            base.Name = isBlack ? base.Rook[0] : base.Rook[1];
        }

        public override int LegalMove(List<List<Piece>> internalBoard, int initalRow, int initialColumn, int targetRow, int targetColumn)
        {
            throw new NotImplementedException();
        }
    }
}
