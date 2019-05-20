using System;
namespace Ex02_Othelo
{
    public class InputValidator
    {
        private const int c_BoardSize1 = 6;
        private const int c_BoardSize2 = 8;
        private const int c_SelectOption1 = 1;
        private const int c_SelectOption2 = 2;

        public InputValidator()
        {
        }

        public bool MoveStringIsValidMove(string i_MoveString,  Move o_NextMove)
        {
            return Move.TryParse(i_MoveString,  o_NextMove);
        }

        public bool BoardSizeIsValid(string i_BoardSizeString, out int o_BoardSize)
        {
            bool v_InputIsNumber;
            bool v_InputIsLegalBoardSize;

            v_InputIsNumber = Int32.TryParse(i_BoardSizeString, out o_BoardSize);
            if (v_InputIsNumber)
            {
                v_InputIsLegalBoardSize = o_BoardSize == c_BoardSize1 || o_BoardSize == c_BoardSize2;
            }
            else
            {
                v_InputIsLegalBoardSize = false; 
            }

            return v_InputIsLegalBoardSize;
        }


        public bool GameModeIsValid(string i_GameModeOption, out UI.eModeGame o_GameMode)
        {
            bool v_GameModeIsLegal;
            bool v_InputIsNumber;
            int v_Option;

            o_GameMode = UI.eModeGame.Invalid;

            v_InputIsNumber = Int32.TryParse(i_GameModeOption, out v_Option);
            if (v_InputIsNumber)
            {
                v_GameModeIsLegal = v_Option == c_SelectOption1 || v_Option == c_SelectOption2;
                if (v_GameModeIsLegal)
                {
                    o_GameMode = getModeGameFromNumber(v_Option); 
                }
            }
            else
            {
                v_GameModeIsLegal = false;
            }

            return v_GameModeIsLegal;
        }
        private UI.eModeGame getModeGameFromNumber(int i_SelectedNumber)
        {
            if (i_SelectedNumber == c_SelectOption1)
            {

                return UI.eModeGame.PlayerVsPlayer;
            }
            else
            {
                return UI.eModeGame.PlayerVsComputer;
            }
        }

        public bool MoveIsValid(string i_MoveString, Move o_NextMove)
        {
            o_NextMove = null;
            return Move.TryParse(i_MoveString,  o_NextMove); 
        }

        public bool PlayAgainIsValid(string i_PlayAgainString, out bool o_PlayAgain)
        {
            int userSelectedOption;
            o_PlayAgain = false;

            bool inputIsValid = CheckPlayAgainIsValid(i_PlayAgainString, out userSelectedOption);

            if (inputIsValid)
            {
                o_PlayAgain = userSelectedOption == c_SelectOption1;
            }

            return inputIsValid;
        }

        public bool CheckPlayAgainIsValid(string i_PlayAgainString, out int o_Play)
        {
            bool v_PlayAgainSelectionIsValid;
            bool v_InputIsNumber = Int32.TryParse(i_PlayAgainString, out o_Play);
            if (v_InputIsNumber)
            {
                v_PlayAgainSelectionIsValid = o_Play == c_SelectOption1 || o_Play == c_SelectOption2;
            }
            else
            {
                v_PlayAgainSelectionIsValid = false;
            }

            return v_PlayAgainSelectionIsValid;
        }
    }
}
