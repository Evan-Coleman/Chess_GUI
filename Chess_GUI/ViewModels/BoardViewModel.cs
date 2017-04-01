using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess_GUI.Models;

namespace Chess_GUI.ViewModels
{
    internal class BoardViewModel
    {

        public BoardViewModel()
        {
            Board = new Board();
        }

        public Board Board { get; set; }

        //public BoardViewModel BoardViewModel { get; set; }



        // Checks to see if the input is formatted correctly
        public int ValidInputCheck(string opt)
        {

            if (opt[1] == opt[3] && opt[2] == opt[4])   // can't move to the same spot
                return 0;

            const string m = "m";
            const string nums = "12345678";
            const string lets = "abcdefgh";
            var j = 0;
            if (opt.Length != 5) // a valid move will always be 5 chars
                return 0;
            if (opt[0] != m[0])
                return 0;
            for (var i = 0; i < 8; i++)
            {
                if (opt[1] == lets[i])
                    j++;
                if (opt[3] == lets[i])
                    j++;
                if (opt[2] == nums[i])
                    j++;
                if (opt[4] == nums[i])
                    j++;
            }
            return j != 4 ? 0 : 1;
        }

    }
}
