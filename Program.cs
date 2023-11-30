///////////////////////////////////////////////////////
// TINFO 200 A, Winter 2023
// UWTacoma SET, Caleb Ghirmai and Ryan Enyeart-Youngblood
// 2023-01-31 - Cs2tic - C# programming project - A graphical Tic-Tac-Toe game
// This program is a simple Tic-Tac-Toe game that allows a human to play against the computer.
// The program randomly decides who gets to go first and assigns their token as "X."
// The computer's playing strategy is random and not based on any logical analysis of the board.

///////////////////////////////////////////////////////////////////////////////
// Change History
// Date ------- Developer ----- Description
// 2023-01-31 - Ryan Enyeart -- Initial creation of solution and pseudocode.
// 2023-01-31 - Caleb Ghirmai - Creation of Form1_Resize method.
// 2023-01-31 - Ryan Enyeart -- Added grid buttons to Form1.
// 2023-01-31 - Ryan Enyeart -- Creation of Square_Click method.
// 2023-01-31 - Caleb Ghirmai - Creation of StartGameBtn_Click method.
// 2023-01-31 - Caleb Ghirmai - Creation of QuitGameBtn_Click method.
// 2023-01-31 - Caleb Ghirmai - Creation of Player class.
// 2023-01-31 - Caleb Ghirmai - Modified Square_Click method to switch between X's and O's.
// 2023-02-02 - Ryan Enyeart -- Creation of CheckForWin method to check for a winner.
// 2023-02-02 - Ryan Enyeart -- Creation of WinnerStatus Property to control game play.
// 2023-02-02 - Ryan Enyeart -- Added instance variables for PC and player tokens.
// 2023-02-02 - Ryan Enyeart -- Creation of PCMove method to control PC's actions.
// 2023-02-03 - Caleb Ghirmai - Added logic in Square_Click and PCMove() to detect a tie game.
// 2023-02-03 - Caleb Ghirmai - Added IsGameOver property to detect a tie or win game.
// 2023-02-03 - Caleb Ghirmai - Added a label to display win/tie statistics for players.
// 2023-02-03 - Caleb Ghirmai - Creation of UpdateLabelText method.
// 2023-02-04 - Caleb Ghirmai - Modified Square_Click method to avoid ArgumentOutOfRangeException.
// 2023-02-04 - Ryan Enyeart -- Set min/max window size for Form1 and made userInterface
//                              multilined to minimize "wasted space."
// 2023-02-04 - Ryan Enyeart -- Creation of PlayerInfo method to start game and lock userInterface.
// 2023-02-04 - Ryan Enyeart -- Modified StartNewGame method to only work if the PLayer's name is known.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
           
        }
    }
}
