using System.Collections.Generic;

namespace Ex05.Logic
{
    public class Player
    {
        private readonly string r_Name;
        private readonly List<Solider> r_Soliders;
        private int m_NumOfSoldiersLeft;
        private int m_Score;
        public eColors Color { get; }

        public Player(string i_Name, int i_SizeOfBoard, eColors i_Color)
        {
            r_Name = i_Name;
            r_Soliders = new List<Solider>(10);
            m_NumOfSoldiersLeft = (i_SizeOfBoard / 2) * ((i_SizeOfBoard / 2) - 1);
            Color = i_Color;
            m_Score = 0;
        }

        public List<Solider> WhichSolidersCanEat()
        {
            List<Solider> canEatSoliders = new List<Solider>(5);

            foreach (Solider solider in r_Soliders)
            {
                if (solider.EatingMovesList.Count > 0)
                {
                    canEatSoliders.Add(solider);
                }
            }

            return canEatSoliders;
        }

        public List<Solider> WhichSolidersCanMove()
        {
            List<Solider> canMoveSoliders = new List<Solider>(5);

            foreach (Solider solider in r_Soliders)
            {
                if (solider.RegularMovesList.Count > 0 || solider.EatingMovesList.Count > 0)
                {
                    canMoveSoliders.Add(solider);
                }
            }

            return canMoveSoliders;
        }

        public int NumOfTotalEatingMoves
        {
            get
            {
                int countNumOfTotalEatingMoves = 0;

                foreach (Solider solider in r_Soliders)
                {
                    countNumOfTotalEatingMoves += solider.NumOfEatingMoves;
                }

                return countNumOfTotalEatingMoves;
            }
        }

        public string Name
        {
            get { return r_Name; }
        }

        public int NumOfTotalMoves
        {
            get
            {
                int countNumOfTotalMoves = NumOfTotalEatingMoves;

                foreach (Solider solider in r_Soliders)
                {
                    countNumOfTotalMoves += solider.NumOfRegularMoves;
                }

                return countNumOfTotalMoves;
            }
        }

        public int NumOfSoldiersLeft
        {
            get { return m_NumOfSoldiersLeft; }
            set { m_NumOfSoldiersLeft = value; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public List<Solider> Soliders
        {
            get { return r_Soliders; }
        }
    }
}
