using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Chess_GUI.Models;
using Chess_GUI.Models.Pieces;
using Chess_GUI.ViewModels.Commands;

namespace Chess_GUI.ViewModels
{
    public class BoardViewModel
    {
        // A string that gets built from button clicks on the board
        private string _moveText;

        public BoardViewModel()
        {
            Board = new Board();
            _moveText = "";

            // Not used yet, remove if never used
            MyBoard = new ObservableCollection<Board>()
            {
                Board
    };

            // spaces is the row of the board
            var spaces = new List<Piece>();

            // Initializes a new board to be populated
            Board.MBoard = new List<List<Piece>>();

            // Making all rows spaces for initial state of board
            for (var i = 0; i < 8; i++)
            {
                spaces.Add(new EmptyPiece());
            }

            for (var i = 0; i < 8; i++)
            {       // sets board to all spaces in order to show an empty board
                Board.MBoard.Add(spaces);
                //spaces.Clear();
                spaces = new List<Piece>();
                for (var j = 0; j < 8; j++)
                {
                    spaces.Add(new EmptyPiece());
                }
            }

            // Places pieces on the board
            for (var i = 0; i < 8; i++)
            {
                Board.MBoard[0][i] = Board.BPiece[i]; //
                Board.MBoard[1][i] = Board.BPiece[8];  //	these 4 set the peices
                Board.MBoard[6][i] = Board.WPiece[8];
                Board.MBoard[7][i] = Board.WPiece[i]; //

            }

            // Is command sent by the button clicks
            MoveCommand = new RelayCommand(Move, Canexecute);

        }

        // Not using yet, check
        public ObservableCollection<Board> MyBoard { get; private set; }

        public RelayCommand MoveCommand { get; private set; }

        public Board Board { get; set; }


        // Entry point for moves which first validates input, then either passes on to validate move based on piece rules
        public void Move(object message)
        {
            _moveText += (string)message;

            if (ValidInputCheck(_moveText))
            {
                // replace with piece move validation
                _moveText = "";
                return;
            }

            if (_moveText.Length >= 4)
            {
                _moveText = "";
            }

        }

        // Greys out selected space on board
        public bool Canexecute(object message)
        {
            if (message == null)
            {
                return true;
            }
            else if ((string)message == _moveText)
            {
                return false;
            }

            return true;
        }

        // Checks to see if the input is formatted correctly
        public bool ValidInputCheck(string moveText)
        {
            moveText = moveText.ToLower();

            if (moveText.Length != 4) // a valid move will always be 4 chars
                return false;

            if (moveText[0] == moveText[2] && moveText[1] == moveText[3])   // can't move to the same spot
                return false;

            const string nums = "12345678"; // a valid move will always contain these numbers
            const string lets = "abcdefgh"; // a valid move will always contain these letters
            var j = 0;
            for (var i = 0; i < 8; i++)
            {
                if (moveText[0] == lets[i])
                    j++;
                if (moveText[2] == lets[i])
                    j++;
                if (moveText[1] == nums[i])
                    j++;
                if (moveText[3] == nums[i])
                    j++;
            }
            return j == 4;
        }

    }
}
