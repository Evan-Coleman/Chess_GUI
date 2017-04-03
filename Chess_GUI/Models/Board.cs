using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Chess_GUI.Annotations;
using Chess_GUI.Models.Pieces;

namespace Chess_GUI.Models
{

    public class Board
    {
        // Unicode characters for White chess pieces
        //public char[] WPiece { get; } = { '♖', '♘', '♗', '♕', '♔', '♗', '♘', '♖', '♙' };

        //        private static Rook rook;
        //        private static Knight knight;
        //        private static Bishop bishop;
        //        private static Queen queen;
        //        private static King king;
        //        private static Pawn pawn;
        //
        //
        //        public Piece[] MPiece = { rook, knight, bishop, queen, king, bishop, knight, rook, pawn };

        // Unicode characters for Black chess pieces
        //public char[] BPiece { get; } = { '♜', '♞', '♝', '♛', '♚', '♝', '♞', '♜', '♟' };

        public List<List<Piece>> MBoard { get; set; }

        public Board()
        {
            MBoard = new List<List<Piece>>();
        }
    }
}
