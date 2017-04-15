# Chess_GUI
Adding a WPF MVVM UI to my old chess game.

Design (Tenative, 2nd iteration):
Board - WPieces, BPieces, MBoard
	(1) BoardViewModel - Board
		(*) Views
(*) Piece - Text, LegalMove()
	(*) Pawn
	(*) Rook
	(*) Knight
	(*) Biship
	(*) King
	(*) Queen

Notes:
-Possibly add new model/viewmodel to handle gameplay
-BoardViewModel:126 column might not be consistant.. pay attention to it


TODO:
[x]     Implement ICommand interface
[x]     Wire up a button to test commands
[x]     Wire up all buttons to use the move command
[x]     Remove Click event from xaml && main window code
[x]     Implement way to highlight currently selected piece
[x]     Add a move string to Move command which will attempt a move when Length==4
[x]		Add button to undo selection
[x]		Migrate piece move logic to new project 
[x]		Refactor piece logic
[x]		Implement INotifyPropertyChanged interface
[x]     Implement move list
[x]		Add reset button
[x]     Add turn checking && prevent player from moving opponents pieces
[x]      Implement win dialog
[x]      Implement promotion dialog

WISHLIST (in ascending order of difficulty):
[x]		Make the GUI pretty (better color scheme)
[]		Check promotion logic against chess rules
[]      Check chess rules for something I missed
[]      Add play vs computer
[]      Add play vs friend on network