using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Chess_GUI.Annotations;

namespace Chess_GUI.Models
{

    public class Board
    {
        public char[] WPiece { get; } = { '♖', '♘', '♗', '♕', '♔', '♗', '♘', '♖', '♙' };
        public char[] BPiece { get; } = { '♜', '♞', '♝', '♛', '♚', '♝', '♞', '♜', '♟' };

        public List<List<char>> MBoard { get; set; }

        public Board()
        {
            MBoard = new List<List<char>>();
        }
    }
}
