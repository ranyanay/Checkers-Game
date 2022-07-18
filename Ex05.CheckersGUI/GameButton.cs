using System.Windows.Forms;

namespace Ex05.CheckersGUI
{
    public class GameButton : Button
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public char RowInChar { get; set; }
        public char ColInChar { get; set; }

        public GameButton(int i_Row, int i_Col)
        {
            Row = i_Row;
            Col = i_Col;
            RowInChar = (char)(i_Row + 97);
            ColInChar = (char)(i_Col + 65);
        }
    }
}
