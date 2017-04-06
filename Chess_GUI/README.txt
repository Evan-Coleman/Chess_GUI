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
-Added a prop IsBlacksTurn, sets to true, so black always start, will need to add checking color into input validation
-Board does not update on a piece being moved


Legalmove refactors for tomorrow:
	LegalMove signature
	Which(x) to isBlack
	Take your own piece code chunk to work with the bool isBlack
	before return if move if successful put
		new EmptyPiece in source coords
		new (x) in dest coords
	return bools (research why return 2 on king though... might need to do something about that)




TODO:
[x]     Implement ICommand interface
[x]     Wire up a button to test commands
[x]     Wire up all buttons to use the move command
[]      Remove Click event from xaml && main window code !-Holding off to do this incase I need them-!
[x]     Implement way to highlight currently selected piece
[x]     Add a move string to Move command which will attempt a move when Length==4
[x]		Add button to undo selection
[1/6]   Migrate piece move logic to new project (Knight done -- TESTING NEEDED)
[x]   Refactor piece logic (Piece works, need to do the rest)
[]      Implement promotion dialog && check promotion logic against chess rules
[]		Implement INotifyPropertyChanged interface
[]      Implement move list
[1/2]   Add reset button (Added, but not functional yet)
[]      Add turn checking && prevent player from moving opponents pieces
[]      Implement win dialog

WISHLIST (in ascending order of difficulty):
[]		Make the GUI pretty (better color scheme)
[]      Check chess rules for something I missed
[]      Add play vs computer
[]      Add play vs friend on network