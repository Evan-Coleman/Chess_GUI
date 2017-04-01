using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Chess_GUI.Annotations;

namespace Chess_GUI.Models
{

    public class Board : INotifyPropertyChanged
    {
        private List<List<char>> _mBoard;
        private readonly char[] _wPiece = { '♖', '♘', '♗', '♕', '♔', '♗', '♘', '♖', '♙' };
        private readonly char[] _bPiece = { '♜', '♞', '♝', '♛', '♚', '♝', '♞', '♜', '♟' };

        public List<List<char>> MBoard
        {
            get
            {
                return _mBoard;
            }
            set
            {
                MBoard = value;
                OnPropertyChanged(nameof(MBoard));
            }
        }

        public Board()
        {
            var spaces = new List<char>();
            _mBoard = new List<List<char>>();

            for (var i = 0; i < 8; i++)
            {
                spaces.Add(' ');
            }

            for (int i = 0; i < 8; i++)
            {       // sets board to all zeros in order to show an empty board
                _mBoard.Add(spaces);
                //spaces.Clear();
                spaces = new List<char>();
                for (var j = 0; j < 8; j++)
                {
                    spaces.Add(' ');
                }
            }

            for (var i = 0; i < 8; i++)
            {
                _mBoard[0][i] = _bPiece[i]; //
                _mBoard[1][i] = _bPiece[8];  //	these 4 set the peices
                _mBoard[6][i] = _wPiece[8];
                _mBoard[7][i] = _wPiece[i]; //

            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
