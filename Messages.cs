using System;
namespace Ex02_Othelo
{
    public static class GameMessages
    {
        public const string
            Greeting = "Welcome to Othelo Game!",
            GetNameOfPlayer = "Enter Your Name:",
            InvalidPlayerName = "Invalid Name was entered",
            GetEnemyOption = "To play against another player enter 1, to play against computer enter 2..",
            InvalidOptionEntered = "Invalid option was entered.",
            PlayAgain = "Do you want to start another game? Enter 1-Yes, 2-No :",
            InvalidMoveEntered = "Incorrect Move Was Entered!",
            NoValidMovesLeftToPlayer = "{0} - No Valid Moves Left for you :(",
            GameEnded = "Game Over! See you next time!",
            GameQuited = "You choose to quit the game...Goodbye!",
            GameBoardSize = "Enter Board size (6 or 8):",
            NextPlayerToMakeMove = "{0} - it's your turn to make a move",
            GetMove = "Enter your move..",
            WinnerPLayer = "Congradulations {0}! You are the winner !!!",
            GameSummery = "----Game Summery----",
            PlayerGameSummery = "Player {0} Game Score: {1}",
            GameResultTie = "We have a TIE!";

    }
}
