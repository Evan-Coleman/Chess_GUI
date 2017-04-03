# Chess_GUI
Adding a WPF MVVM UI to my old chess game.

Upcoming design choices:
Old chess game wasn't designed with OOP in mind, so when I inport the logic I'll need to remedy that.

Design (Tenative, 1st iteration):
Board - WPieces, BPieces, MBoard
	(1) BoardViewModel - Board
					(*) Views
	(*) Space - Name
			(*) Piece - Text, LegalMove()
					(*) Pawn
					(*) Rook
					(*) Knight
					(*) Biship
					(*) King
					(*) Queen



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
[]      Implement move list
[1/2]   Add reset button (Added, but not functional yet)
[]      Add turn checking && prevent player from moving opponents pieces
[]      Implement win dialog

WISHLIST (in ascending order of difficulty):
[]		Make the GUI pretty (better color scheme)
[]      Check chess rules for something I missed
[]      Add play vs computer
[]      Add play vs friend on network