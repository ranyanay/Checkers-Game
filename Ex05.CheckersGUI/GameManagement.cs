using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.CheckersGUI
{
    public static class GameManagement
    {
        private static Board s_GameBoard;
        private static Player s_BlackPlayer, s_WhitePlayer;
        private static Solider s_LastMovingSolider;

        public static void RunGame()
        {
            CheckersBoardForm checkersBoardGui = new CheckersBoardForm(ref s_GameBoard, ref s_BlackPlayer, ref s_WhitePlayer);
            if (checkersBoardGui.SetupForm.DialogResult == DialogResult.OK)
            {
                checkersBoardGui.ShowDialog();
            }
        }

        public static bool playerMakeMove(string i_CurPlayerName,
            ref bool io_IsEatingMove,
            ref bool io_TurnedIntoKing,
            ref eGameStatus io_GameCurrentStatus,
            GameButton i_SourceBtn = null,
            GameButton i_TargetBtn = null)
        {
            Player curPlayer;
            bool youSnoozeULose = false, moveIsValid = true;
            Solider chosenMovingSolider = null;
            eMistakeIndicator mistakeTypeIndicator;
            string curMove;

            if (i_CurPlayerName.Equals(s_BlackPlayer.Name))
            {
                curPlayer = s_BlackPlayer;
            }
            else
            {
                curPlayer = s_WhitePlayer;
            }

            if (i_CurPlayerName.Equals("[Computer]") && curPlayer.NumOfTotalMoves > 0)
            {
                getRandomMoveFromComputer(curPlayer, out curMove);
            }
            else
            {
                curMove = parseUserMove( i_SourceBtn, i_TargetBtn);
            }

            if (!InputValidation.CheckMoveValidation(curMove, s_GameBoard,
                curPlayer, ref youSnoozeULose, ref chosenMovingSolider, out mistakeTypeIndicator, io_IsEatingMove, s_LastMovingSolider) && !curPlayer.Name.Equals("[Computer]"))
            {
                MessagesForUser.JumpErrorMsg(MessagesForUser.MsgInputMoveIsInvlaid(mistakeTypeIndicator, chosenMovingSolider));
                moveIsValid = false;
            }
            else
            {
                s_GameBoard.MoveSoldier(curMove, ref io_IsEatingMove, ref s_LastMovingSolider, ref io_TurnedIntoKing);
                s_GameBoard.UpdateAllSolidersAvilableMoves();
                io_GameCurrentStatus = s_GameBoard.CheckGameStatus();
                if (io_IsEatingMove && s_LastMovingSolider.NumOfEatingMoves == 0)
                {
                    io_IsEatingMove = false;
                }
            }

            return moveIsValid;
        }

        private static string parseUserMove(GameButton i_SourceBtn, GameButton i_TargetBtn)
        {
            StringBuilder curMove = new StringBuilder();

            curMove.Append(i_SourceBtn.ColInChar);
            curMove.Append(i_SourceBtn.RowInChar);
            curMove.Append('>');
            curMove.Append(i_TargetBtn.ColInChar);
            curMove.Append(i_TargetBtn.RowInChar);

            return curMove.ToString();
        }

        private static void getRandomMoveFromComputer(Player i_CurrPlayingPlayer, out string o_CurrentInputMove)
        {
            List<Solider> canMoveSoliders;
            int randomSolider, randomMoveIndex;
            string randomMove;
            StringBuilder CurrSoliderPositionInString = new StringBuilder();
            Random random = new Random();

            if (i_CurrPlayingPlayer.NumOfTotalEatingMoves > 0)
            {
                canMoveSoliders = i_CurrPlayingPlayer.WhichSolidersCanEat();
                randomSolider = random.Next(canMoveSoliders.Count - 1);
                randomMoveIndex = random.Next(canMoveSoliders[randomSolider].EatingMovesList.Count);
                randomMove = canMoveSoliders[randomSolider].EatingMovesList[randomMoveIndex];
            }
            else
            {
                canMoveSoliders = i_CurrPlayingPlayer.WhichSolidersCanMove();
                randomSolider = random.Next(canMoveSoliders.Count - 1);
                randomMoveIndex = random.Next(canMoveSoliders[randomSolider].RegularMovesList.Count);
                randomMove = canMoveSoliders[randomSolider].RegularMovesList[randomMoveIndex];
            }

            CurrSoliderPositionInString.Append((char)(canMoveSoliders[randomSolider].Col + 65));
            CurrSoliderPositionInString.Append((char)(canMoveSoliders[randomSolider].Row + 97));
            CurrSoliderPositionInString.Append('>');
            CurrSoliderPositionInString.Append(randomMove);
            o_CurrentInputMove = CurrSoliderPositionInString.ToString();
        }

        internal static void UpdatePoints(eGameStatus i_GameStatus)
        {
            int blackPlayerPoints = 0, whitePlayerPoints = 0;
            Player winningPlayer = getWinningPlayer(i_GameStatus);

            foreach (Solider aliveSolider in BlackPlayer.Soliders)
            {
                if (aliveSolider.isKing)
                {
                    blackPlayerPoints += 4;
                }
                else
                {
                    blackPlayerPoints++;
                }
            }

            foreach (Solider aliveSolider in WhitePlayer.Soliders)
            {
                if (aliveSolider.isKing)
                {
                    whitePlayerPoints += 4;
                }
                else
                {
                    whitePlayerPoints++;
                }
            }

            if (!ReferenceEquals(winningPlayer, null))
            {
                winningPlayer.Score += Math.Abs(blackPlayerPoints - whitePlayerPoints);
            }
        }

        private static Player getWinningPlayer(eGameStatus i_GameStatus)
        {
            Player winningPlayer = null;

            switch (i_GameStatus)
            {
                case eGameStatus.BlackPlayerWon:
                    winningPlayer = BlackPlayer;
                    break;
                case eGameStatus.WhitePlayerWon:
                    winningPlayer = WhitePlayer;
                    break;
            }

            return winningPlayer;
        }

        internal static Board GameBoard
        {
            get { return s_GameBoard; }
            set { s_GameBoard = value; }
        }
        public static Player BlackPlayer
        {
            get { return s_BlackPlayer; }
        }

        public static Player WhitePlayer
        {
            get { return s_WhitePlayer; }
        }

    }
}
