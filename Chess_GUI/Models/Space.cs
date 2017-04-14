namespace Chess_GUI.Models
{
    public class Space
    {
        public Piece Piece { get; set; }

        public Space(Piece piece)
        {
            Piece = piece;
        }
    }
}
