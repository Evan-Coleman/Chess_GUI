﻿using System;
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

        // Will be set to 1 when King is taken
        public int WonGame = 0;

        // Keeps track of who's turn it is
        public bool IsBlacksTurn { get; set; }

        // Not using yet, check
        //public ObservableCollection<Board> MyBoard { get; private set; }

        // Relay command is the general command handler, sets up the MoveCommand
        public RelayCommand MoveCommand { get; private set; }

        // Is the game board
        public Board Board { get; set; }

        // CTOR for the viewmodel
        public BoardViewModel()
        {
            // Game starts with black's move
            IsBlacksTurn = true;

            // Creates a new instance of the model Board
            Board = new Board();

            // The move starts out as an empty string until a button is clicked
            _moveText = "";

            //            // Not used yet, remove if never used
            //            MyBoard = new ObservableCollection<Board>()
            //            {
            //                Board
            //    };

            // spaces is the row of the board
            var spaces = new List<Piece>();

            // Initializes a new board to be populated
            Board.MBoard = new List<List<Piece>>();

            // Making all rows spaces for initial state of board
            for (var i = 0; i < 8; i++)
            {
                spaces.Add(new EmptyPiece(true));
            }

            for (var i = 0; i < 8; i++)
            {       // sets board to all spaces in order to show an empty board
                Board.MBoard.Add(spaces);
                spaces = new List<Piece>();
                for (var j = 0; j < 8; j++)
                {
                    spaces.Add(new EmptyPiece(true));
                }
            }

            #region Board Init
            // Black pieces
            Board.MBoard[0][0] = new Rook(true);
            Board.MBoard[0][1] = new Knight(true);
            Board.MBoard[0][2] = new Bishop(true);
            Board.MBoard[0][3] = new Queen(true);
            Board.MBoard[0][4] = new King(true);
            Board.MBoard[0][5] = new Bishop(true);
            Board.MBoard[0][6] = new Knight(true);
            Board.MBoard[0][7] = new Rook(true);

            Board.MBoard[1][0] = new Pawn(true);
            Board.MBoard[1][1] = new Pawn(true);
            Board.MBoard[1][2] = new Pawn(true);
            Board.MBoard[1][3] = new Pawn(true);
            Board.MBoard[1][4] = new Pawn(true);
            Board.MBoard[1][5] = new Pawn(true);
            Board.MBoard[1][6] = new Pawn(true);
            Board.MBoard[1][7] = new Pawn(true);

            // White pieces
            Board.MBoard[6][0] = new Pawn(false);
            Board.MBoard[6][1] = new Pawn(false);
            Board.MBoard[6][2] = new Pawn(false);
            Board.MBoard[6][3] = new Pawn(false);
            Board.MBoard[6][4] = new Pawn(false);
            Board.MBoard[6][5] = new Pawn(false);
            Board.MBoard[6][6] = new Pawn(false);
            Board.MBoard[6][7] = new Pawn(false);

            Board.MBoard[7][0] = new Rook(false);
            Board.MBoard[7][1] = new Knight(false);
            Board.MBoard[7][2] = new Bishop(false);
            Board.MBoard[7][3] = new Queen(false);
            Board.MBoard[7][4] = new King(false);
            Board.MBoard[7][5] = new Bishop(false);
            Board.MBoard[7][6] = new Knight(false);
            Board.MBoard[7][7] = new Rook(false);
            #endregion

            // Is command sent by the button clicks
            MoveCommand = new RelayCommand(Move, Canexecute);

        }




        // Entry point for moves which first validates input, then either passes on to validate move based on piece rules
        // Message is the button text
        public void Move(object message)
        {
            _moveText += (string)message;


            if (ValidInputCheck(_moveText))
            {
                // Converts input to valid Column/Row indices
                int sourceColumn = (int)_moveText[0] - 65;
                int sourceRow = 8 - (int)char.GetNumericValue(_moveText[1]);
                int destColumn = _moveText[2] - 65;
                int destRow = 8 - (int)char.GetNumericValue(_moveText[3]);

                // Check if move if legal, if so legalMove will be 1, if game is won it will be 2
                int legalMove = Board.MBoard[sourceRow][sourceColumn].LegalMove(Board.MBoard, sourceRow, sourceColumn, destRow, destColumn);


                if (legalMove == 1)
                {
                    // Move the piece to it's new location
                    //Board.MBoard[destRow][destColumn] = Board.MBoard[sourceRow][sourceColumn];
                    // After a valid move, switch who's turn it is
                    IsBlacksTurn = IsBlacksTurn != true;
                }
                // LegalMove is 2 when a king is taken, so winning condition goes here
                if (legalMove == 2)
                {
                    WonGame = 1;
                    // Implement winning dialog
                    return;
                }


                // Need to reset moveText for a new move
                _moveText = "";
                return;
            }

            // If moveText is over 4 it is an invalid move, so reset moveText
            if (_moveText.Length >= 4)
            {
                _moveText = "";
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

            // a valid move will always contain these numbers
            const string nums = "12345678";

            // a valid move will always contain these letters
            const string lets = "abcdefgh";

            // J is the counter of valid input
            var j = 0;

            // Checks to see if correct input is in the correct form (char,int,char,int)
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

            // A valid move will have 4 valid inputs
            return j == 4;
        }

    }
}
