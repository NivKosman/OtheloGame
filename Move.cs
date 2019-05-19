using System;
namespace Ex02_Othelo
{
    public class Move
    {
        public static int s_Width;
        public static int s_Height;
        private const int c_IndexOfCharacter = 0;
        private const int c_IndexOfNumber = 1;
        private readonly int m_Row;
        private readonly int m_Col;
        bool m_Quite;
        const int k_LengthOfMoveStr = 2;
        const int k_LengthOfQuitStr = 1;



        public Move(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }

        public Move(bool i_IsQuit)
        {
            m_Quite = i_IsQuit;
        }

        public static bool TryParse(string i_MoveString, out Move o_Move)
        {
            o_Move = null;
            if (i_MoveString == null)
            {
                return false;
            }

            bool v_InputIsValid = checkMoveStringIsValidMove(i_MoveString, ref o_Move);

            return v_InputIsValid;

        }

        private static bool checkMoveStringIsValidMove(string i_InputMoveStr,
                                                         ref Move io_Move)
        {
            bool v_LengthIsValid;
            bool v_StringIsValidMove = false;

            v_LengthIsValid = checkMoveStringLengthIsValid(i_InputMoveStr);
            if (v_LengthIsValid == true)
            {
                v_StringIsValidMove = checkMoveStringIsLegal(i_InputMoveStr, io_Move);
            }

            return v_StringIsValidMove;
        }

        private static bool checkMoveStringLengthIsValid(string i_InputMoveStr)
        {
            bool v_QuitLength = i_InputMoveStr.Length == k_LengthOfQuitStr;
            bool v_MoveLength = i_InputMoveStr.Length == k_LengthOfMoveStr;

            return v_QuitLength || v_MoveLength;
        }

        private static bool checkMoveStringIsLegal(string i_InputMoveStr,  Move io_Move)
        {
            bool v_MoveIsCharAndIndexInRange = false;
            bool v_MoveIsQuit = textIsQuit(i_InputMoveStr);

            if (v_MoveIsQuit == true)
            {
                io_Move = new Move(v_MoveIsQuit);
            }
            else
            {
                v_MoveIsCharAndIndexInRange = CharAndNumInValidRange(i_InputMoveStr, io_Move);
            }

            return v_MoveIsQuit || v_MoveIsCharAndIndexInRange;
        }

        private static bool CharAndNumInValidRange(string i_InputMoveStr, Move io_Move)
        {
            char v_FirstChar = i_InputMoveStr[c_IndexOfCharacter];
            char v_SecondChar = i_InputMoveStr[c_IndexOfNumber];

            int v_Row = 0;
            int v_Col = 0;

            bool v_FirstCharInBoardAbcRange = charInAbcRange(v_FirstChar, ref v_Col);
            bool v_SeconfCharInBoardNumRange = charInNumRange(v_SecondChar, ref v_Row);
            bool v_BothCharsInRange = v_FirstCharInBoardAbcRange && v_SeconfCharInBoardNumRange;

            if (v_BothCharsInRange == true)
            {
                io_Move = new Move(v_Row, v_Col);
            }
            return v_BothCharsInRange;
        }

        private static bool charInAbcRange(char i_CharToCheck, ref int i_ColumnLetter)
        {
            i_CharToCheck = Char.ToUpper(i_CharToCheck);
            bool v_CharInRange = i_CharToCheck >= 'A' && i_CharToCheck < ('A' + s_Width);
            if (v_CharInRange)
            {
                i_ColumnLetter = i_CharToCheck - 'A' + 1;
            }

            return v_CharInRange;
        }


        private static bool charInNumRange(char i_CharToCheck, ref int i_Number)
        {
            if (char.IsDigit(i_CharToCheck))
            {
                i_Number = int.Parse(i_CharToCheck.ToString());
                return numberInBoardRange(i_Number);
            }

            return false;
        }

        private static bool numberInBoardRange(int i_NumToCheck)
        {
            return i_NumToCheck > 0 && i_NumToCheck <= s_Height;
        }

        private static bool textIsQuit(string i_Input)
        {
            return i_Input.Equals("Q");
        }

        public int Row
        {
            get { return m_Row; }
            //set { m_Row = value; }
        }

        public int Col
        {
            get { return m_Col; }
            //set { m_Col = value; }
        }

        public bool IsQuitMove()
        {
            return m_Quite;
        }

    }
}