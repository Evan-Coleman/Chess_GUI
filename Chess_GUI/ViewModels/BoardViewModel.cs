using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Chess_GUI.Models;
using Chess_GUI.ViewModels.Commands;

namespace Chess_GUI.ViewModels
{
    internal class BoardViewModel
    {
        private string moveText;
        public BoardViewModel()
        {
            Board = new Board();
            moveText = "";

            MyBoard = new ObservableCollection<Board>()
            {
                Board
    };

            var spaces = new List<char>();
            Board.MBoard = new List<List<char>>();


            for (var i = 0; i < 8; i++)
            {
                spaces.Add(' ');
            }

            for (var i = 0; i < 8; i++)
            {       // sets board to all zeros in order to show an empty board
                Board.MBoard.Add(spaces);
                //spaces.Clear();
                spaces = new List<char>();
                for (var j = 0; j < 8; j++)
                {
                    spaces.Add(' ');
                }
            }

            for (var i = 0; i < 8; i++)
            {
                Board.MBoard[0][i] = Board.BPiece[i]; //
                Board.MBoard[1][i] = Board.BPiece[8];  //	these 4 set the peices
                Board.MBoard[6][i] = Board.WPiece[8];
                Board.MBoard[7][i] = Board.WPiece[i]; //

            }

            MoveCommand = new RelayCommand(Move, Canexecute);
            //MoveCommand = new RelayCommand(Move);

        }

        public ObservableCollection<Board> MyBoard { get; private set; }

        public RelayCommand MoveCommand { get; private set; }

        public Board Board { get; set; }

        public void Move(object message)
        {
            moveText += (string)message;

            if (ValidInputCheck(moveText))
            {
                MessageBox.Show("Valid move"); // replace with piece move validation
                moveText = "";
                return;
            }

            if (moveText.Length >= 4)
            {
                moveText = "";
            }

        }

        public bool Canexecute(object message)
        {
            if (message == null)
            {
                return true;
            }
            else if ((string)message == moveText)
            {
                return false;
            }

            return true;
        }

        // Checks to see if the input is formatted correctly
        public bool ValidInputCheck(string opt)
        {
            opt = opt.ToLower();

            if (opt.Length != 4) // a valid move will always be 4 chars
                return false;

            if (opt[0] == opt[2] && opt[1] == opt[3])   // can't move to the same spot
                return false;

            const string nums = "12345678";
            const string lets = "abcdefgh";
            var j = 0;
            for (var i = 0; i < 8; i++)
            {
                if (opt[0] == lets[i])
                    j++;
                if (opt[2] == lets[i])
                    j++;
                if (opt[1] == nums[i])
                    j++;
                if (opt[3] == nums[i])
                    j++;
            }
            return j == 4;
        }

    }
}
