using System;

namespace Ex05.Logic
{
    public class InputValidation
    {
        public static bool CheckMoveValidation(string i_CurrentMove,
            Board i_GameBoard,
            Player i_CurrentPlayer,
            ref bool io_YouSnoozeULose,
            ref Solider io_ChosenSoliderWhenMoveIsInvalid,
            out eMistakeIndicator o_MistakeTypeIndicator,
            bool i_PlayingInARow = false,
            Solider i_LastMovingSoldier = null)
        {
            int curRow = -1, curCol = -1, moveRow = -1, moveCol = -1;
            bool inputIsValid = false;
            Solider movingSoldier;
            o_MistakeTypeIndicator = eMistakeIndicator.IlegalMove;

            if (checkIfMoveFormatIsValid(i_CurrentMove))
            {
                parseInputParamsToInt(i_CurrentMove, ref curRow, ref curCol, ref moveRow, ref moveCol);
                if (IsIndexValid(curRow, curCol, i_GameBoard.Size) && (IsIndexValid(moveRow, moveRow, i_GameBoard.Size)))
                {
                    movingSoldier = i_GameBoard.GameBoard[curRow, curCol];
                    if (!io_YouSnoozeULose)
                    {
                        io_ChosenSoliderWhenMoveIsInvalid = movingSoldier;
                    }

                    if (checkIfMoveIsLegal(movingSoldier, i_LastMovingSoldier, i_CurrentMove, i_PlayingInARow, i_CurrentPlayer, ref io_YouSnoozeULose,
                        ref io_ChosenSoliderWhenMoveIsInvalid))
                    {
                        inputIsValid = true;
                    }
                    else
                    {
                        o_MistakeTypeIndicator = eMistakeIndicator.IlegalMove;
                        if (io_YouSnoozeULose && !ReferenceEquals(io_ChosenSoliderWhenMoveIsInvalid, movingSoldier))
                        {
                            o_MistakeTypeIndicator = eMistakeIndicator.YouSnoozeYouLose;
                        }
                    }
                }
            }

            return inputIsValid;
        }

        public static bool checkIfMoveIsLegal(Solider i_MovingSolider,
            Solider i_LastMovingSoldier,
            string i_CurrentMove,
            bool i_PlayingInARow,
            Player i_CurrentPlayer,
            ref bool io_YouSnoozeULose,
            ref Solider io_ChosenSoliderWhenMoveIsInvalid)
        {
            string moveDest;
            bool inputIsValid = false;

            if (i_MovingSolider != null && i_MovingSolider.Color == i_CurrentPlayer.Color && ReferenceEquals(i_MovingSolider, io_ChosenSoliderWhenMoveIsInvalid))
            {
                moveDest = i_CurrentMove.Substring(3, 2);
                if (i_PlayingInARow)
                {
                    if (i_LastMovingSoldier.Equals(i_MovingSolider) && i_MovingSolider.EatingMovesList.Contains(moveDest))
                    {
                        inputIsValid = true;
                    }
                }
                else
                {
                    if (i_MovingSolider.RegularMovesList.Contains(moveDest) && i_CurrentPlayer.NumOfTotalEatingMoves == 0)
                    {
                        inputIsValid = true;
                    }
                    else if (i_MovingSolider.EatingMovesList.Contains(moveDest))
                    {
                        inputIsValid = true;
                    }
                }
            }

            if (!ReferenceEquals(i_MovingSolider, null) && !inputIsValid && (i_MovingSolider.RegularMovesList.Count > 0 || i_MovingSolider.EatingMovesList.Count > 0)
                && i_CurrentPlayer.NumOfTotalEatingMoves == 0 && i_CurrentPlayer.Color == i_MovingSolider.Color)
            {
                io_YouSnoozeULose = true;
            }
            else
            {
                io_YouSnoozeULose = false;
            }

            return inputIsValid;
        }

        private static bool checkIfMoveFormatIsValid(string i_CurrentMove)
        {
            bool inputIsValid = false;

            if (i_CurrentMove.Length == 5 && i_CurrentMove[2].Equals('>') && !Char.IsLower(i_CurrentMove[0]) &&
               Char.IsLower(i_CurrentMove[1]) && !Char.IsLower(i_CurrentMove[3]) && Char.IsLower(i_CurrentMove[4]))
            {
                inputIsValid = true;
            }

            return inputIsValid;
        }

        public static bool IsIndexValid(int i_CurRow, int i_CurCol, int i_SizeOfBoard)
        {
            bool isIndexInBounds = true;

            if (i_CurRow < 0 || i_CurRow >= i_SizeOfBoard || i_CurCol < 0 || i_CurCol >= i_SizeOfBoard)
            {
                isIndexInBounds = false;
            }

            return isIndexInBounds;
        }

        internal static void parseInputParamsToInt(string i_CurrentMove, ref int io_CurRow, ref int io_CurCol, ref int io_MoveRow, ref int io_MoveCol)
        {
            io_CurCol = i_CurrentMove[0] - 65;
            io_CurRow = i_CurrentMove[1] - 97;
            io_MoveCol = i_CurrentMove[3] - 65;
            io_MoveRow = i_CurrentMove[4] - 97;
        }
    }
}
