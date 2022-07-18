using System;

namespace Ex05.Logic
{
    public class Board
    {
        private readonly int r_SizeOfBoard;
        private readonly Solider[,] r_Board;
        private readonly Player r_BlackPlayer;
        private readonly Player r_WhitePlayer;

        public Board(int i_SizeOfBoard, Player i_Player1, Player i_Player2)
        {
            Player curPlayer;
            Solider newSoliderOnBoard;
            eColors playerColor;
            int rowIndexToUpdateMovesForBlackSoldiers = (i_SizeOfBoard / 2) + 1, rowIndexToUpdateMovesForWhiteSoldiers = (i_SizeOfBoard / 2) - 2;

            r_BlackPlayer = i_Player1;
            r_WhitePlayer = i_Player2;
            r_SizeOfBoard = i_SizeOfBoard;
            r_Board = new Solider[i_SizeOfBoard, i_SizeOfBoard];
            for (int i = 0; i < i_SizeOfBoard; i++)
            {
                for (int j = 0; j < i_SizeOfBoard && i != i_SizeOfBoard / 2 && i != (i_SizeOfBoard / 2) - 1; j++)
                {
                    if (i < (i_SizeOfBoard / 2) - 1)
                    {
                        playerColor = eColors.White;
                        curPlayer = r_WhitePlayer;
                    }
                    else
                    {
                        playerColor = eColors.Black;
                        curPlayer = r_BlackPlayer;
                    }

                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 == 1 && j % 2 == 0))
                    {
                        newSoliderOnBoard = new Solider(playerColor, i, j, i_SizeOfBoard);
                        if (newSoliderOnBoard.Row == rowIndexToUpdateMovesForWhiteSoldiers || newSoliderOnBoard.Row == rowIndexToUpdateMovesForBlackSoldiers)
                        {
                            newSoliderOnBoard.UpdateAvailableMoves(r_Board);
                        }

                        curPlayer.Soliders.Add(newSoliderOnBoard);
                        r_Board[i, j] = newSoliderOnBoard;
                    }
                }
            }
        }

        public void MoveSoldier(string i_CurrentMove, ref bool io_IsEatMove, ref Solider io_LastMovingSoldier, ref bool io_TurnedIntoKing)
        {
            int curRow = -1, curCol = -1, moveRow = -1, moveCol = -1;
            Solider movingSolider, eatenSolider;

            InputValidation.parseInputParamsToInt(i_CurrentMove, ref curRow, ref curCol, ref moveRow, ref moveCol);
            movingSolider = r_Board[curRow, curCol];
            if (ReferenceEquals(movingSolider,null))
            {

                return;
            }

            movingSolider.Row = moveRow;
            movingSolider.Col = moveCol;
            r_Board[curRow, curCol] = null;
            r_Board[moveRow, moveCol] = movingSolider;
            io_LastMovingSoldier = movingSolider;
            if (Math.Abs(curRow - moveRow) == 2)
            {
                io_IsEatMove = true;
            }
            else
            {
                io_IsEatMove = false;
            }

            if (io_IsEatMove)
            {
                eatenSolider = r_Board[(moveRow + curRow) / 2, (curCol + moveCol) / 2];
                r_Board[(moveRow + curRow) / 2, (curCol + moveCol) / 2] = null;
                if (movingSolider.Color == eColors.Black)
                {
                    r_WhitePlayer.Soliders.Remove(eatenSolider);
                }
                else
                {
                    r_BlackPlayer.Soliders.Remove(eatenSolider);
                }
            }

            if (((movingSolider.Color == eColors.Black && movingSolider.Row == 0) || (movingSolider.Color == eColors.White && movingSolider.Row == r_SizeOfBoard - 1)) && (!movingSolider.isKing))
            {
                movingSolider.isKing = true;
                io_TurnedIntoKing = true;
            }
            else
            {
                io_TurnedIntoKing = false;
            }
        }

        public void UpdateAllSolidersAvilableMoves()
        {
            foreach (Solider currSolider in r_Board)
            {
                if (currSolider != null)
                {
                    currSolider.UpdateAvailableMoves(r_Board);
                }
            }
        }

        public eGameStatus CheckGameStatus()
        {
            eGameStatus gameStatus = eGameStatus.KeepPlaying;

            if (r_BlackPlayer.NumOfTotalMoves == 0 && r_WhitePlayer.NumOfTotalMoves == 0)
            {
                gameStatus = eGameStatus.GameEndedInADraw;
            }

            if (r_BlackPlayer.NumOfSoldiersLeft == 0 || r_BlackPlayer.NumOfTotalMoves == 0)
            {
                gameStatus = eGameStatus.WhitePlayerWon;
            }

            if (r_WhitePlayer.NumOfSoldiersLeft == 0 || r_WhitePlayer.NumOfTotalMoves == 0)
            {
                gameStatus = eGameStatus.BlackPlayerWon;
            }

            return gameStatus;
        }

        public int Size
        {
            get { return r_SizeOfBoard; }
        }

        public Solider[,] GameBoard
        {
            get { return r_Board; }
        }

    }
}
