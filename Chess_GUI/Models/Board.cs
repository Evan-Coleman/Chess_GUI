using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class Board : ObservableCollection<List<Space>>
    {


        // Default constructor to initialize the board
        public Board()
        {

            var spaces = new List<Space>
            {
                new Space(new Rook(true)),
                new Space(new Knight(true)),
                new Space(new Bishop(true)),
                new Space(new Queen(true)),
                new Space(new King(true)),
                new Space(new Bishop(true)),
                new Space(new Knight(true)),
                new Space(new Rook(true))
            };


            Add(spaces);

            spaces = new List<Space>
            {
                new Space(new Pawn(true)),
                new Space(new Pawn(true)),
                new Space(new Pawn(true)),
                new Space(new Pawn(true)),
                new Space(new Pawn(true)),
                new Space(new Pawn(true)),
                new Space(new Pawn(true)),
                new Space(new Pawn(true))
            };



            Add(spaces);

            // Making all rows spaces for initial state of board
            for (var i = 0; i < 4; i++)
            {
                spaces = new List<Space>();
                for (int j = 0; j < 8; j++)
                {
                    spaces.Add(new Space(new EmptyPiece(true)));
                }
                Add(spaces);
            }

            spaces = new List<Space>
            {
                new Space(new Pawn(false)),
                new Space(new Pawn(false)),
                new Space(new Pawn(false)),
                new Space(new Pawn(false)),
                new Space(new Pawn(false)),
                new Space(new Pawn(false)),
                new Space(new Pawn(false)),
                new Space(new Pawn(false))
            };


            Add(spaces);

            spaces = new List<Space>
            {
                new Space(new Rook(false)),
                new Space(new Knight(false)),
                new Space(new Bishop(false)),
                new Space(new Queen(false)),
                new Space(new King(false)),
                new Space(new Bishop(false)),
                new Space(new Knight(false)),
                new Space(new Rook(false))
            };


            Add(spaces);
        }
    }
}
