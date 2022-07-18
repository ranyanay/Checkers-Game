using Ex05.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.CheckersGUI
{
    public partial class CheckersBoardForm : Form
    {
        private Dictionary<String, GameButton> m_Buttons = null;
        private static int m_ClickedButtonsCounter = 0;
        private GameButton m_FirstClickedBtn = null;
        private GameButton i_SecondClickedBtn = null;
        private eGameStatus m_GameStatus = eGameStatus.KeepPlaying;
        private int m_NumOfMoves = 0;
        private bool m_PlayingInARow = false;
        private bool m_TurnedIntoKing = false;
        private string m_CurPlayerName;
        private readonly SetupForm r_SetupForm;
        private readonly Size r_ImageSize = new Size(35, 35);

        public SetupForm SetupForm
        {
            get { return r_SetupForm; }
        }

        public CheckersBoardForm(ref Board io_GameBoard, ref Player io_BlackPlayer, ref Player io_WhitePlayer)
        {
            string blackPlayerName, whitePlayerName;
            int sizeOfBoard;

            r_SetupForm = new SetupForm();
            r_SetupForm.ShowDialog();
            while (r_SetupForm.DialogResult != DialogResult.OK && r_SetupForm.DialogResult != DialogResult.Cancel)
            {
                r_SetupForm.ShowDialog();
            }

            if (r_SetupForm.DialogResult == DialogResult.OK)
            {
                blackPlayerName = r_SetupForm.Player1Name;
                whitePlayerName = r_SetupForm.Player2Name;
                sizeOfBoard = r_SetupForm.BoardSize;
                io_BlackPlayer = new Player(blackPlayerName, sizeOfBoard, eColors.Black);
                io_WhitePlayer = new Player(whitePlayerName, sizeOfBoard, eColors.White);
                io_GameBoard = new Board(sizeOfBoard, io_BlackPlayer, io_WhitePlayer);
                InitializeComponent();
                createCheckersBoard(io_GameBoard.Size, io_BlackPlayer.Name, io_WhitePlayer.Name);
            }
        }

        private void createCheckersBoard(int i_Size, string i_Player1Name, string i_Player2Name)
        {
            int formWidth = 55 + i_Size * 40;
            int formHeight = i_Size * 40 + 90;
            int curHorizontalPosition;
            int curVerticalPosition = 0;
            GameButton newButton;
            m_Buttons = new Dictionary<String, GameButton>();
            Bitmap image = null;

            m_CurPlayerName = i_Player1Name;
            Size = new Size(formWidth, formHeight);
            LabelPlayer1.Text = i_Player1Name;
            LabelPlayer2.Text = i_Player2Name;
            LabelPlayer1.Left = (int)(formWidth * 0.2);
            LabelPlayer2.Left = (int)(formWidth * 0.55);
            LabelPlayer1Points.Left = LabelPlayer1.Left + LabelPlayer1.Width + 2;
            LabelPlayer2Points.Left = LabelPlayer2.Left + LabelPlayer2.Width + 2;
            for (int i = 0; i < i_Size; i++)
            {
                curHorizontalPosition = 20;
                curVerticalPosition += 40;
                for (int j = 0; j < i_Size; j++)
                {
                    newButton = new GameButton(i, j);
                    newButton.Name = getPositionStr(i, j);
                    newButton.Click += Buttons_Click;
                    m_Buttons.Add(newButton.Name, newButton);
                    Controls.Add(newButton);
                    if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                    {
                        newButton.Enabled = false;
                        newButton.BackColor = Color.Black;
                        newButton.FlatStyle = FlatStyle.Flat;
                        newButton.FlatAppearance.BorderSize = 0;
                    }
                    else
                    {
                        newButton.Enabled = true;
                        newButton.BackColor = Color.White;
                        if (i < (i_Size / 2) - 1)
                        {
                            image = Properties.Resources.whitechecker;
                            newButton.Tag = char.ToString((char)Solider.eSoliderSigns.WhiteSolider);

                        }
                        else if (i > (i_Size / 2))
                        {
                            image = Properties.Resources.blackchecker;
                            newButton.Tag = char.ToString((char)Solider.eSoliderSigns.BlackSolider);

                        }

                        if (i < (i_Size / 2) - 1 || i > (i_Size / 2))
                        {
                            newButton.Image = new Bitmap(image, r_ImageSize);
                            newButton.BackgroundImageLayout = ImageLayout.Stretch;
                            newButton.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                    }

                    newButton.Size = new Size(40, 40);
                    newButton.Left = curHorizontalPosition;
                    newButton.Top = curVerticalPosition;
                    curHorizontalPosition += 40;
                }
            }
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            m_ClickedButtonsCounter++;
            if (m_ClickedButtonsCounter == 1)
            {
                m_FirstClickedBtn = (GameButton)sender;
                getCurrentPlayerName();
                checkFirstClick();
            }
            else if (m_ClickedButtonsCounter == 2)
            {
                i_SecondClickedBtn = (GameButton)sender;
                checkSecondClick();
            }
        }

        private void checkSecondClick()
        {
            if (ReferenceEquals(m_FirstClickedBtn, this.i_SecondClickedBtn))
            {
                this.i_SecondClickedBtn.BackColor = Color.White;
                m_ClickedButtonsCounter = 0;
            }
            else
            {
                makeAturn(m_CurPlayerName, ref m_PlayingInARow, ref m_TurnedIntoKing, ref m_GameStatus, m_FirstClickedBtn, i_SecondClickedBtn);
                if (LabelPlayer2.Text.Equals("[Computer]"))
                {
                    while (m_NumOfMoves % 2 != 0 && m_GameStatus == eGameStatus.KeepPlaying)
                    {
                        makeAturn(LabelPlayer2.Text, ref m_PlayingInARow, ref m_TurnedIntoKing, ref m_GameStatus);
                    }
                }

                if (m_GameStatus != eGameStatus.KeepPlaying)
                {
                    GameManagement.UpdatePoints(m_GameStatus);
                    LabelPlayer1Points.Text = ": " + GameManagement.BlackPlayer.Score.ToString();
                    LabelPlayer2Points.Text = ": " + GameManagement.WhitePlayer.Score.ToString();
                    if (!askPlayerIfHeWantToKeeoPlaying(m_GameStatus))
                    {
                        MessagesForUser.JumpAMsg(MessagesForUser.s_GoodByeMsg);
                        Close();
                    }

                    intiliazeBoard();
                    GameManagement.GameBoard = new Board(GameManagement.GameBoard.Size, GameManagement.BlackPlayer, GameManagement.WhitePlayer);
                    GameManagement.GameBoard.UpdateAllSolidersAvilableMoves();
                    repaint(GameManagement.GameBoard);
                }

                m_ClickedButtonsCounter = 0;
                m_FirstClickedBtn.BackColor = Color.White;
            }
        }

        private void checkFirstClick()
        {
            if (m_FirstClickedBtn.Tag.Equals(""))
            {
                MessagesForUser.JumpAMsg(MessagesForUser.s_EmptySquareMove);
                m_ClickedButtonsCounter = 0;
            }
            else if (LabelPlayer2.Text.Equals("[Computer]") && (m_FirstClickedBtn.Tag.Equals("O") || m_FirstClickedBtn.Tag.Equals("Q")))
            {
                MessagesForUser.JumpErrorMsg(MessagesForUser.s_MovingEnemySolider);
                m_ClickedButtonsCounter = 0;
            }
            else if ((LabelPlayer2.Text.Equals(m_CurPlayerName) && (m_FirstClickedBtn.Tag.Equals("Z") || m_FirstClickedBtn.Tag.Equals("X"))) || (LabelPlayer1.Text.Equals(m_CurPlayerName) && (m_FirstClickedBtn.Tag.Equals("O") || m_FirstClickedBtn.Tag.Equals("Q"))))
            {
                MessagesForUser.JumpErrorMsg(MessagesForUser.s_MovingEnemySolider);
                m_ClickedButtonsCounter = 0;
            }
            else
            {
                m_FirstClickedBtn.BackColor = Color.FromArgb(100, 95, 158, 160);
            }
        }

        private void getCurrentPlayerName()
        {
            if (!LabelPlayer2.Text.Equals("[Computer]"))
            {
                if (m_NumOfMoves % 2 == 0)
                {
                    m_CurPlayerName = LabelPlayer1.Text;
                }
                else
                {
                    m_CurPlayerName = LabelPlayer2.Text;
                }
            }
            else
            {
                m_CurPlayerName = LabelPlayer1.Text;
            }
        }

        private void intiliazeBoard()
        {
            m_ClickedButtonsCounter = 0;
            m_GameStatus = eGameStatus.KeepPlaying;
            m_NumOfMoves = 0;
            m_PlayingInARow = false;
            m_TurnedIntoKing = false;
            m_CurPlayerName = GameManagement.BlackPlayer.Name;
        }

        private void makeAturn(string i_CurPlayerName,
            ref bool io_PlayingInARow,
            ref bool io_TurnedIntoKing,
            ref eGameStatus io_GameStatus,
            GameButton i_FirstClickedBtn = null,
            GameButton i_SecondClickedBtn = null)
        {
            if (GameManagement.playerMakeMove(i_CurPlayerName, ref io_PlayingInARow, ref io_TurnedIntoKing, ref io_GameStatus, i_FirstClickedBtn, i_SecondClickedBtn))
            {
                if (!io_PlayingInARow) m_NumOfMoves += 1;
                repaint(GameManagement.GameBoard);
            }
        }

        private static bool askPlayerIfHeWantToKeeoPlaying(eGameStatus i_GameStatus)
        {
            string msgOnTheBox = string.Empty;

            switch (i_GameStatus)
            {
                case eGameStatus.BlackPlayerWon:
                    msgOnTheBox = string.Format(@"{0} Won!
Another round?", GameManagement.BlackPlayer.Name);
                    break;
                case eGameStatus.WhitePlayerWon:
                    msgOnTheBox = string.Format(@"{0} Won!
Another round?", GameManagement.WhitePlayer.Name);
                    break;
                case eGameStatus.GameEndedInADraw:
                    msgOnTheBox = string.Format(@"Tie!
Another round?");
                    break;
            }

            return MessageBox.Show(msgOnTheBox, "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void repaint(Board i_GameBoard)
        {
            string pos;
            Solider curSolider;
            Bitmap image;

            for (int i = 0; i < i_GameBoard.Size; i++)
            {
                for (int j = 0; j < i_GameBoard.Size; j++)
                {
                    pos = getPositionStr(i, j);
                    m_Buttons[pos].Tag = "";
                    curSolider = i_GameBoard.GameBoard[i, j];
                    if (curSolider != null)
                    {
                        if (curSolider.Color == eColors.Black)
                        {
                            if (curSolider.isKing)
                            {
                                image = Properties.Resources.blackKingchecker;
                            }
                            else
                            {
                                image = Properties.Resources.blackchecker;
                            }
                        }
                        else
                        {
                            if (curSolider.isKing)
                            {
                                image = Properties.Resources.whiteKingchecker;
                            }
                            else
                            {
                                image = Properties.Resources.whitechecker;
                            }
                        }

                        m_Buttons[pos].Image = new Bitmap(image, r_ImageSize);
                        m_Buttons[pos].BackgroundImageLayout = ImageLayout.Stretch;
                        m_Buttons[pos].ImageAlign = ContentAlignment.MiddleCenter;
                        m_Buttons[pos].Tag = curSolider.ToString();
                    }
                    else
                    {
                        m_Buttons[pos].Image = null;
                    }
                }
            }
        }

        private static string getPositionStr(int i_Row, int i_Col)
        {
            string row = i_Row.ToString();
            string col = i_Col.ToString();

            return row + col;
        }
    }
}
