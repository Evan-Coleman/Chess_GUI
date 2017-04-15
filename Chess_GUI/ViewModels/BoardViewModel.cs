using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Chess_GUI.Annotations;
using Chess_GUI.Models;
using Chess_GUI.Models.Pieces;
using Chess_GUI.ViewModels.Commands;

namespace Chess_GUI.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {

        #region PROPERTIES
        // Will be set to 1 if game is in a winning state
        public int WonGame { get; set; }

        // Keeps track of who's turn it is
        public bool IsBlacksTurn { get; set; }

        // Relay command is the general command handler, sets up the Move Command
        public RelayCommand MoveCommand { get; private set; }

        // Relay command is the general command handler, sets up the Reset Game Command
        public RelayCommand ResetCommand { get; private set; }

        // Relay command is the general command handler, sets up the Reset Move Text Command
        public RelayCommand ResetMoveTextCommand { get; set; }

        // Relay command is the general command handler, sets up the Promote Command
        public RelayCommand PromoteCommand { get; set; }

        // Is the game board
        public Board Board { get; set; }

        // Move list
        public ObservableCollection<string> MovesList { get; set; }

        // Property GUI uses to display who's turn it currently is
        public string WhoTurn => IsBlacksTurn ? "Black's turn" : "White's turn";

        // A string that gets built from button clicks on the board
        public string MoveText { get; set; }

        // Changes visibility of main window when promoting
        public string Visibility { get; set; }

        // Changes visibility of promote dialog
        public string VisibilityPromote { get; set; }

        // Piece to promote to
        public string PromoteToPiece { get; set; }

        // Row of piece to promote
        public int PromoteRow { get; set; }

        // Column of piece to promote
        public int PromoteColumn { get; set; }
        #endregion

        #region CONSTRUCTOR
        // CTOR for the viewmodel
        public BoardViewModel()
        {
            // Game starts with black's move
            IsBlacksTurn = true;

            // Board should be visible initially
            Visibility = "Visible";
            // Promote dialog should be hidden initially
            VisibilityPromote = "Collapsed";

            // Creates a new instance of the model Board


            // The move starts out as an empty string until a button is clicked
            MoveText = "";


            Board = new Board();
            MovesList = new ObservableCollection<string>();

            // Is command sent by the button clicks
            MoveCommand = new RelayCommand(Move, Canexecute);
            ResetCommand = new RelayCommand(Reset, Canexecute);
            ResetMoveTextCommand = new RelayCommand(ResetMoveText, Canexecute);
            PromoteCommand = new RelayCommand(Promote, Canexecute);

        }
        #endregion


        #region METHODS
        // Entry point for moves which first validates input, then either passes on to validate move based on piece rules
        // Message is the button text
        public void Move(object message)
        {
            MoveText += (string)message;
            OnPropertyChanged(nameof(MoveText));

            // If moveText is over 4 it is an invalid move, so reset moveText and return
            if (MoveText.Length > 4)
            {
                MoveText = "";
                OnPropertyChanged(nameof(MoveText));
                return;
            }

            // Don't allow player to move other's pieces or select empty spots
            if (IsBlacksTurn ==
                !Board[8 - (int)char.GetNumericValue(MoveText[1])][(int)MoveText[0] - 65].Piece.IsBlack ||
                Board[8 - (int)char.GetNumericValue(MoveText[1])][(int)MoveText[0] - 65].Piece.Name == '\0')
            {
                MoveText = "";
                OnPropertyChanged(nameof(MoveText));
                return;
            }

            if (ValidInputCheck(MoveText))
            {
                // Converts input to valid Column/Row indices
                int sourceRow = 8 - (int)char.GetNumericValue(MoveText[1]);
                int sourceColumn = (int)MoveText[0] - 65;
                int destRow = 8 - (int)char.GetNumericValue(MoveText[3]);
                int destColumn = (int)MoveText[2] - 65;

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
                    MovesList.Insert(0, MoveText);
                    OnPropertyChanged(nameof(MovesList));
                    ResetMoveText("");
                }
                // LegalMove is 2 when a king is taken, so winning condition goes here
                if (legalMove == 2)
                {
                    // Unused wongame variable, maybe remove
                    WonGame = 1;
                    // Move the piece to it's new location in the GUI
                    OnPropertyChanged(nameof(Board));

                    // Adds move to list and updates it on GUI
                    MovesList.Insert(0, MoveText);
                    OnPropertyChanged(nameof(MovesList));

                    // Implement winning dialog HERE
                    // Implement winning dialog HERE
                    // Implement winning dialog HERE
                    MessageBox.Show("WINNER!");


                    ResetMoveText("");
                }
                // LegalMove is 3 when a pawn makes it to the other side & needs to be promoted
                if (legalMove == 3)
                {
                    PromoteRow = destRow;
                    PromoteColumn = destColumn;
                    // IMPLEMENT PROMOTION HERE
                    // IMPLEMENT PROMOTION HERE
                    // IMPLEMENT PROMOTION HERE
                    PromotePiece();

                    // Move the piece to it's new location in the GUI
                    OnPropertyChanged(nameof(Board));

                    IsBlacksTurn = !IsBlacksTurn;
                    // Notifies GUI who's turn it is
                    OnPropertyChanged(nameof(WhoTurn));

                    // Adds move to list and updates it on GUI
                    MovesList.Insert(0, MoveText);
                    OnPropertyChanged(nameof(MovesList));

                    ResetMoveText("");
                }


            }

            if (MoveText.Length > 2)
            {
                MoveText = MoveText.Remove(2);
                OnPropertyChanged(nameof(MoveText));
            }

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

        // Resets the game
        public void Reset(object message)
        {
            // Make a new instance of a board which will have everything in default position
            Board = new Board();
            // Need to remove currently selected cell
            MoveText = "";
            OnPropertyChanged(nameof(MoveText));
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

        // Will reset the movetext
        public void ResetMoveText(object message)
        {
            MoveText = (string)message;
            OnPropertyChanged(nameof(MoveText));
            return;
        }

        // Greys out selected space on board, and disables the command
        public bool Canexecute(object message)
        {
            if (message == null)
            {
                return true;
            }
            else if ((string)message == MoveText)
            {
                return false;
            }

            return true;
        }

        public void PromotePiece()
        {
            Visibility = "Collapsed";
            OnPropertyChanged(nameof(Visibility));
            VisibilityPromote = "Visible";
            OnPropertyChanged(nameof(VisibilityPromote));
        }

        public void Promote(object message)
        {
            if (PromoteColumn == -1 || PromoteRow == -1)
            {
                return;
            }
            PromoteToPiece = (string)message;


            if ((string)message == "Queen")
            {
                Board[PromoteRow][PromoteColumn].Piece = new Queen(Board[PromoteRow][PromoteColumn].Piece.IsBlack);
            }
            else if ((string)message == "Rook")
            {
                Board[PromoteRow][PromoteColumn].Piece = new Rook(Board[PromoteRow][PromoteColumn].Piece.IsBlack);
            }
            else if ((string)message == "Bishop")
            {
                Board[PromoteRow][PromoteColumn].Piece = new Bishop(Board[PromoteRow][PromoteColumn].Piece.IsBlack);
            }
            else if ((string)message == "Knight")
            {
                Board[PromoteRow][PromoteColumn].Piece = new Knight(Board[PromoteRow][PromoteColumn].Piece.IsBlack);
            }

            PromoteRow = -1;
            PromoteColumn = -1;
            OnPropertyChanged(nameof(Board));
            Visibility = "Visible";
            OnPropertyChanged(nameof(Visibility));
            VisibilityPromote = "Collapsed";
            OnPropertyChanged(nameof(VisibilityPromote));
        }
        #endregion

        #region EVENTS
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
