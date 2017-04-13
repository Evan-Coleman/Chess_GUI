using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_GUI.Models
{
    public class Space
    {
        public Piece Piece { get; set; }

        public Space(Piece piece)
        {
            Piece = piece;
        }
    }
}
