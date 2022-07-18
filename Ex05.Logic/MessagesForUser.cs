using System.Windows.Forms;

namespace Ex05.Logic
{
    public class MessagesForUser
    {
        public static string s_EmptySquareMove = "You cant choose a square without a solider.";
        public static string s_GoodByeMsg = "Bye Bye, see you next time.";
        public static string s_MovingEnemySolider = "You can't move your enemy solider.";
        public static string s_FormFiledsAreEmpty = "You must enter a valid names for the players.";

        public static void JumpAMsg(string i_Msg)
        {
            MessageBox.Show(i_Msg);
        }

        public static void JumpErrorMsg(string i_Msg)
        {
            MessageBox.Show(i_Msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static string MsgInputMoveIsInvlaid(eMistakeIndicator i_MistakeTypeIndicator, Solider i_SnoozeYouLoseSolider)
        {
            string msgToUser = string.Empty;

            if (i_MistakeTypeIndicator == eMistakeIndicator.IlegalMove)
            {
                msgToUser = string.Format(@"The move you have tried to make is ilegal. Please try again.");
            }
            else if (i_MistakeTypeIndicator == eMistakeIndicator.YouSnoozeYouLose)
            {
                msgToUser = string.Format(@"You snooze you lose! 
Now you must move with the solider positioned in: '{0}{1}' on the game board. ", (char)(i_SnoozeYouLoseSolider.Col + 65), (char)(i_SnoozeYouLoseSolider.Row + 97));
            }

            return msgToUser;
        }
    }
}
