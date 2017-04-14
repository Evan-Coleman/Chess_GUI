using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media.Animation;
using Chess_GUI.Annotations;
using Chess_GUI.Models;
using Chess_GUI.Models.Pieces;
using Chess_GUI.ViewModels.Commands;

namespace Chess_GUI.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        // A string that gets built from button clicks on the board
        private string _moveText;

        // Will be set to 1 when King is taken
        public int WonGame = 0;

        // Keeps track of who's turn it is
        public bool IsBlacksTurn { get; set; }

        // Not using yet, check
        //public ObservableCollection<Board> MyBoard { get; private set; }

        // Relay command is the general command handler, sets up the MoveCommand
        public RelayCommand MoveCommand { get; private set; }

        // Relay command is the general command handler, sets up the MoveCommand
        public RelayCommand ResetCommand { get; private set; }

        // Is the game board
        public Board Board { get; set; }

        // Move list
        public ObservableCollection<string> MovesList { get; set; }

        public string WhoTurn => IsBlacksTurn ? "Black's turn" : "White's turn";

        // CTOR for the viewmodel
        public BoardViewModel()
        {
            // Game starts with black's move
            IsBlacksTurn = true;

            // Creates a new instance of the model Board


            // The move starts out as an empty string until a button is clicked
            _moveText = "";


            Board = new Board();
            MovesList = new ObservableCollection<string>();

            // Is command sent by the button clicks
            MoveCommand = new RelayCommand(Move, Canexecute);
            ResetCommand = new RelayCommand(Reset, Canexecute);

        }

        public void Reset(object message)
        {
            // Make a new instance of a board which will have everything in default position
            Board = new Board();
            // Need to remove currently selected cell
            _moveText = "";
            // Update GUI with new fresh board
            OnPropertyChanged(nameof(Board));

            // Creates a new movelist for the new game
            MovesList = new ObservableCollection<string>();
            OnPropertyChanged(nameof(MovesList));


            // Game always starts with black first
            IsBlacksTurn = true;
            // Notifies GUI who's turn it is
            OnPropertyChanged(nameof(WhoTurn));
        }

        // Entry point for moves which first validates input, then either passes on to validate move based on piece rules
        // Message is the button text
        public void Move(object message)
        {
            _moveText += (string)message;

            // If moveText is over 4 it is an invalid move, so reset moveText and return
            if (_moveText.Length > 4)
            {
                _moveText = "";
                return;
            }

            if (ValidInputCheck(_moveText))
            {
                // Converts input to valid Column/Row indices
                int sourceRow = 8 - (int)char.GetNumericValue(_moveText[1]);
                int sourceColumn = (int)_moveText[0] - 65;
                int destRow = 8 - (int)char.GetNumericValue(_moveText[3]);
                int destColumn = (int)_moveText[2] - 65;

                // Don't allow player to move other's pieces
                if (IsBlacksTurn == !Board[sourceRow][sourceColumn].Piece.IsBlack)
                {
                    return;
                }

                // Check if move if legal, if so legalMove will be 1, if game is won it will be 2

                int legalMove = Board[sourceRow][sourceColumn].Piece.LegalMove(Board, sourceRow, sourceColumn, destRow, destColumn);


                if (legalMove == 1)
                {
                    // Move the piece to it's new location in the GUI
                    OnPropertyChanged(nameof(Board));
                    // After a valid move, switch who's turn it is
                    IsBlacksTurn = !IsBlacksTurn;
                    // Notifies GUI who's turn it is
                    OnPropertyChanged(nameof(WhoTurn));

                    // Adds move to list and updates it on GUI
                    MovesList.Insert(0, _moveText);
                    OnPropertyChanged(nameof(MovesList));
                }
                // LegalMove is 2 when a king is taken, so winning condition goes here
                if (legalMove == 2)
                {
                    // Unused wongame variable, maybe remove
                    WonGame = 1;
                    // Move the piece to it's new location in the GUI
                    OnPropertyChanged(nameof(Board));

                    // Adds move to list and updates it on GUI
                    MovesList.Insert(0, _moveText);
                    OnPropertyChanged(nameof(MovesList));

                    // Implement winning dialog HERE
                    // Implement winning dialog HERE
                    // Implement winning dialog HERE

                    return;
                }
                // LegalMove is 3 when a pawn makes it to the other side & needs to be promoted
                if (legalMove == 3)
                {
                    // IMPLEMENT PROMOTION HERE
                    // IMPLEMENT PROMOTION HERE
                    // IMPLEMENT PROMOTION HERE

                    // Move the piece to it's new location in the GUI
                    OnPropertyChanged(nameof(Board));

                    IsBlacksTurn = !IsBlacksTurn;
                    // Notifies GUI who's turn it is
                    OnPropertyChanged(nameof(WhoTurn));

                    // Adds move to list and updates it on GUI
                    MovesList.Insert(0, _moveText);
                    OnPropertyChanged(nameof(MovesList));
                }


                // Need to reset moveText for a new move
                _moveText = "";
                return;
            }



        }

        // Greys out selected space on board, and disables the command
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
            // Remenant of when user could enter move by text, keeping for future protection of new UI
            moveText = moveText.ToLower();

            // a valid move will always be 4 chars
            if (moveText.Length != 4)
                return false;

            // can't move to the same spot
            if (moveText[0] == moveText[2] && moveText[1] == moveText[3])
                return false;


            var rgx = new Regex(@"[a-h][1-8][a-h][1-8]$");

            // Checking against pattern of CharIntCharInt (with chars between a-h, and ints between 1-8)
            return rgx.IsMatch(moveText);


        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
