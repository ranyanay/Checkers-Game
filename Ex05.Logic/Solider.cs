using System.Collections.Generic;
using System.Text;

namespace Ex05.Logic
{
    public class Solider
    {
        public enum eSoliderSigns
        {
            BlackSolider = 'X',
            WhiteSolider = 'O',
            BlackKing = 'Z',
            WhiteKing = 'Q'
        }

        private int m_Row;
        private int m_Col;
        private readonly eColors r_Color;
        private readonly int r_SizeOfBoard;
        private bool m_KingFlag;
        private readonly List<string> r_RegularMoves;
        private readonly List<string> r_EatingMoves;

        public Solider(eColors i_Color, int i_Row, int i_Col, int i_SizeOfBoard)
        {
            m_Col = i_Col;
            m_Row = i_Row;
            m_KingFlag = false;
            r_SizeOfBoard = i_SizeOfBoard;
            r_Color = i_Color;
            r_EatingMoves = new List<string>(2);
            r_RegularMoves = new List<string>(2);
        }

        public void UpdateAvailableMoves(Solider[,] i_BoardMatrix)
        {
            RegularMovesList.Clear();
            EatingMovesList.Clear();
            if (Color == eColors.Black)
            {
                updateBlackSoliderMoves(i_BoardMatrix);
            }
            else // white
            {
                updateWhiteSoliderMoves(i_BoardMatrix);
            }

            if (m_KingFlag)
            {
                updateKingMoves(i_BoardMatrix);
            }
        }

        private void updateWhiteSoliderMoves(Solider[,] i_BoardMatrix)
        {
            bool eatingMove = true;

            // white solider
            if (InputValidation.IsIndexValid(Row + 1, Col + 1, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row + 1, Col + 1], null))
            {
                addMoveToListOfMoves(Row + 1, Col + 1, !eatingMove); //false -> add to regular moves
            }

            if (InputValidation.IsIndexValid(Row + 1, Col - 1, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row + 1, Col - 1], null))
            {
                addMoveToListOfMoves(Row + 1, Col - 1, !eatingMove); //false -> add to regular moves
            }

            //white eating mopves 
            if (InputValidation.IsIndexValid(Row + 2, Col + 2, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row + 2, Col + 2], null))
            {
                if (i_BoardMatrix[Row + 1, Col + 1] != null && i_BoardMatrix[Row + 1, Col + 1].Color != Color)
                {
                    addMoveToListOfMoves(Row + 2, Col + 2, eatingMove); //false -> add to regular moves
                }
            }

            if (InputValidation.IsIndexValid(Row + 2, Col - 2, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row + 2, Col - 2], null))
            {
                if (i_BoardMatrix[Row + 1, Col - 1] != null && i_BoardMatrix[Row + 1, Col - 1].Color != Color)
                {
                    addMoveToListOfMoves(Row + 2, Col - 2, eatingMove); //false -> add to regular moves
                }
            }
        }

        private void updateBlackSoliderMoves(Solider[,] i_BoardMatrix)
        {
            bool eatingMove = true;

            // black - right side
            if (InputValidation.IsIndexValid(Row - 1, Col + 1, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row - 1, Col + 1], null))
            {
                addMoveToListOfMoves(Row - 1, Col + 1, !eatingMove); //false -> add to regular moves
            }

            if (InputValidation.IsIndexValid(Row - 1, Col - 1, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row - 1, Col - 1], null))
            {
                addMoveToListOfMoves(Row - 1, Col - 1, !eatingMove); //false -> add to regular moves
            }

            //black eating mopves 
            if (InputValidation.IsIndexValid(Row - 2, Col + 2, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row - 2, Col + 2], null))
            {
                if (i_BoardMatrix[Row - 1, Col + 1] != null && i_BoardMatrix[Row - 1, Col + 1].Color != Color)
                {
                    addMoveToListOfMoves(Row - 2, Col + 2, eatingMove); //false -> add to regular moves
                }
            }

            if (InputValidation.IsIndexValid(Row - 2, Col - 2, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row - 2, Col - 2], null))
            {
                if (i_BoardMatrix[Row - 1, Col - 1] != null && i_BoardMatrix[Row - 1, Col - 1].Color != Color)
                {
                    addMoveToListOfMoves(Row - 2, Col - 2, eatingMove); //false -> add to regular moves
                }
            }
        }

        private void updateKingMoves(Solider[,] i_BoardMatrix)
        {
            if (Color == eColors.Black) // black king
            {
                updateBlackKingSoliderMoves(i_BoardMatrix);
            }
            else // white king
            {
                updateWhiteKingSoliderMoves(i_BoardMatrix);
            }
        }

        private void updateWhiteKingSoliderMoves(Solider[,] i_BoardMatrix)
        {
            bool eatingMove = true;

            if (InputValidation.IsIndexValid(Row - 1, Col + 1, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row - 1, Col + 1], null))
            {
                addMoveToListOfMoves(Row - 1, Col + 1, !eatingMove); //false -> add to regular moves
            }

            if (InputValidation.IsIndexValid(Row - 1, Col - 1, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row - 1, Col - 1], null))
            {
                addMoveToListOfMoves(Row - 1, Col - 1, !eatingMove); //false -> add to regular moves
            }

            //eating white king moves 
            if (InputValidation.IsIndexValid(Row - 2, Col + 2, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row - 2, Col + 2], null))
            {
                if (InputValidation.IsIndexValid(Row - 1, Col - 1, r_SizeOfBoard) && i_BoardMatrix[Row - 1, Col + 1] != null && i_BoardMatrix[Row - 1, Col + 1].Color != Color)
                {
                    addMoveToListOfMoves(Row - 2, Col + 2, eatingMove); //false -> add to regular moves
                }
            }

            if (InputValidation.IsIndexValid(Row - 2, Col - 2, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row - 2, Col - 2], null))
            {
                if (i_BoardMatrix[Row - 1, Col - 1] != null && i_BoardMatrix[Row - 1, Col - 1].Color != Color)
                {
                    addMoveToListOfMoves(Row - 2, Col - 2, eatingMove); //false -> add to regular moves
                }
            }
        }

        private void updateBlackKingSoliderMoves(Solider[,] i_BoardMatrix)
        {
            bool eatingMove = true;

            if (InputValidation.IsIndexValid(Row + 1, Col + 1, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row + 1, Col + 1], null))
            {
                addMoveToListOfMoves(Row + 1, Col + 1, !eatingMove); //false -> add to regular moves
            }

            if (InputValidation.IsIndexValid(Row + 1, Col - 1, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row + 1, Col - 1], null))
            {
                addMoveToListOfMoves(Row + 1, Col - 1, !eatingMove); //false -> add to regular moves
            }

            //eating black king moves 
            if (InputValidation.IsIndexValid(Row + 2, Col + 2, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row + 2, Col + 2], null))
            {
                if (i_BoardMatrix[Row + 1, Col + 1] != null && i_BoardMatrix[Row + 1, Col + 1].Color != Color)
                {
                    addMoveToListOfMoves(Row + 2, Col + 2, eatingMove); //false -> add to regular moves
                }
            }

            if (InputValidation.IsIndexValid(Row + 2, Col - 2, r_SizeOfBoard) && ReferenceEquals(i_BoardMatrix[Row + 2, Col - 2], null))
            {
                if (i_BoardMatrix[Row + 1, Col - 1] != null && i_BoardMatrix[Row + 1, Col - 1].Color != Color)
                {
                    addMoveToListOfMoves(Row + 2, Col - 2, eatingMove); //false -> add to regular moves
                }
            }
        }

        private void addMoveToListOfMoves(int i_Row, int i_Col, bool i_EatingMove)
        {
            StringBuilder moveName = new StringBuilder();

            moveName.Append((char)(i_Col + 65));
            moveName.Append((char)(i_Row + 97));
            if (i_EatingMove)
            {
                EatingMovesList.Add(moveName.ToString());
            }
            else
            {
                RegularMovesList.Add(moveName.ToString());
            }
        }

        public override string ToString()
        {
            string resultString;

            if (Color == eColors.White)
            {
                if (m_KingFlag)
                {
                    resultString = char.ToString((char)eSoliderSigns.WhiteKing);
                }
                else
                {
                    resultString = char.ToString((char)eSoliderSigns.WhiteSolider);
                }
            }
            else
            {
                if (m_KingFlag)
                {
                    resultString = char.ToString((char)eSoliderSigns.BlackKing);
                }
                else
                {
                    resultString = char.ToString((char)eSoliderSigns.BlackSolider);
                }
            }

            return resultString;
        }

        public List<string> EatingMovesList
        {
            get { return r_EatingMoves; }
        }

        public List<string> RegularMovesList
        {
            get { return r_RegularMoves; }
        }

        public int Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }

        public int Col
        {
            get { return m_Col; }
            set { m_Col = value; }
        }

        public eColors Color
        {
            get { return r_Color; }
        }

        public int NumOfRegularMoves
        {
            get { return r_RegularMoves.Count; }
        }

        public int NumOfEatingMoves
        {
            get { return r_EatingMoves.Count; }
        }

        public bool isKing
        {
            get { return m_KingFlag; }
            set { m_KingFlag = value; }
        }

    }
}
