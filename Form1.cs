using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        // Constants
        private const int TotalNumSquares = 9;

        // Instance variables that hold information
        // about two players in Tic-Tac-Toe

        // Determines if the computer is next
        // and should randomly select a square
        private bool computerIsNext = false;

        // Statistics for games between the player
        // and computer
        private int totalNumTies = 0;
        private int totalPlayerWins = 0;
        private int totalComputerWins = 0;


        // Instance variables
        // "X" for one player and
        // "O" for the other player
        private string playerToken;
        private string pcToken;
        // keyCount to control the PlayerInfo method
        private int keyCount = 0;
        // Dictates whether the game can startd
        private bool isPlayerKnown = false;

        // Properties
        // Player name
        public string PlayerName { get; private set; }
        // Determines if the game is over
        // by a TIE or victory.
        public bool IsGameOver { get; private set; } = true;
        // Used to determine the number of squares that
        // have been clicked
        public int NumSquaresClicked { get; private set; } = 0;


        public Form1()
        {
            InitializeComponent();
            // Prompts player for their name to trigger their input.
            // Hitting enter with input starts the game.
            if (isPlayerKnown == false)
            {
                userInterface.Text = "Type your name here" +
                    " and press enter to play.";
            }
        }



        // This method accepts player input until they hit the enter key,
        // at which point it saves their input as the player's name.
        // This step must be completed before the player can play.
        private void PlayerInfo(object sender, KeyPressEventArgs e)
        {
            // Clears userInterface for first keystroke only
            if (keyCount == 0)
            {
                userInterface.Text = string.Empty;
                keyCount++;
            }
            // Assigns player's name based on their input,
            // Then locks the userinterface and starts the game.
            if (isPlayerKnown == false && e.KeyChar == (char)Keys.Return)
            {
                PlayerName = userInterface.Text == string.Empty ? "Player 1" : userInterface.Text;
                userInterface.ReadOnly = true;
                isPlayerKnown = true;
                StartGame();
            }
        }

        // This method begins a new game, tracking wins, losses, and ties 
        // if it is not the first game since the program was opened.
        private void StartGame()
        {
            if (isPlayerKnown == true)
            {
                // Clear the game board and text box
                button1.Text = button2.Text = button3.Text = button4.Text
                    = button5.Text = button6.Text = button7.Text = button8.Text
                    = button9.Text = userInterface.Text = string.Empty;

                // updates game stats
                UpdateLabelText();

                // Reset game status to not over
                IsGameOver = false;

                // Reset NumSquaresClicked
                NumSquaresClicked = 0;

                // Determine which player to go first
                Random random = new Random();
                var randomChoice = random.Next(0, 2);

                // Computer goes first
                if (randomChoice == 0)
                {
                    pcToken = "X";
                    playerToken = "O";
                    computerIsNext = true;
                    PCMove();
                    userInterface.Text = $"{PlayerName}, choose your square ({playerToken})!";
                }

                // Player goes first
                else
                {
                    // Display text that prompts the player to
                    // place an X on the board.
                    playerToken = "X";
                    pcToken = "O";
                    computerIsNext = false;
                    userInterface.Text = $"{PlayerName}, choose your square ({playerToken})!";
                }
            }
        }


        // This method clears the current game board and textbox
        // then begins initializing a new game
        private void StartGameBtn_Click(object sender, EventArgs e) => StartGame();

        // This method terminates the program.
        private void QuitGameBtn_Click(object sender, EventArgs e) => System.Windows.Forms.Application.Exit();

        // This method redisplays the win/tie statics with new
        // information
        private void UpdateLabelText()
        {
            // Update statistics label
            statsLabel.Text = $"{PlayerName}: {totalPlayerWins}/ \t PC:" +
                $" {totalComputerWins}\t/ Tie: {totalNumTies}";
        }

        // This method creates either an X or an O to the button being clicked
        // depending on which token was last placed, placing X's after O's and
        // O's after X's.
        private void Square_Click(object sender, EventArgs e)
        {
            if (IsGameOver == false && computerIsNext == false)
            {
                // Adds the player's token to an empty square
                if (((Button)sender).Text == string.Empty)
                {
                    ((Button)sender).Text = playerToken;
                    NumSquaresClicked++; // Increment num squares clicked

                    if (CheckForWin(playerToken))
                    {
                        userInterface.Text = $"You won, {PlayerName}!";
                        totalPlayerWins++;
                        UpdateLabelText();
                        IsGameOver = true; // Game is over since Player 1 won
                    }

                    // Logic to determine a TIE game
                    // At this point Player 1 has not won
                    else if (IsGameOver == false &&
                        NumSquaresClicked == TotalNumSquares)
                    {
                        userInterface.Text = $"TIE!";
                        totalNumTies++;
                        UpdateLabelText();
                        IsGameOver = true; // Game is over since it is a TIE game
                    }

                    else
                    {
                        // Normal case - switch back to PC's turn
                        computerIsNext = true;
                        PCMove();
                    }
                }
            }
        }

        // This method dictates the PC's pseudo random moves
        private void PCMove()
        {
            if (IsGameOver == false && computerIsNext == true)
            {
                Random rdm = new Random();
                List<int> openSquares = new List<int>(); // Creates a local list to track available squares
                List<string> temp = new List<string> {
                    button1.Text, button2.Text, button3.Text ,
                    button4.Text, button5.Text, button6.Text ,
                    button7.Text, button8.Text, button9.Text };

                // Seaches for empty squares in the temp list and adds their index to the openSquares list
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i] == string.Empty)
                    {
                        openSquares.Add(i);
                    }
                }
                // Chooses a random index from the openSquares list
                int pc = rdm.Next(0, openSquares.Count);

                // Uses the openSquares list to choose a random empty square
                switch (openSquares[pc])
                {
                    case 0:
                        button1.Text = pcToken;
                        break;
                    case 1:
                        button2.Text = pcToken;
                        break;
                    case 2:
                        button3.Text = pcToken;
                        break;
                    case 3:
                        button4.Text = pcToken;
                        break;
                    case 4:
                        button5.Text = pcToken;
                        break;
                    case 5:
                        button6.Text = pcToken;
                        break;
                    case 6:
                        button7.Text = pcToken;
                        break;
                    case 7:
                        button8.Text = pcToken;
                        break;
                    case 8:
                        button9.Text = pcToken;
                        break;
                    default:
                        break;
                }

                NumSquaresClicked++;

                // Check for win or tie game
                if (CheckForWin(pcToken))
                {
                    userInterface.Text = $"PC has won!";
                    totalComputerWins++;
                    UpdateLabelText();
                    IsGameOver = true;
                }

                // Determines if a TIE game
                else if (IsGameOver == false &&
                    NumSquaresClicked == TotalNumSquares)
                {
                    userInterface.Text = $"TIE!";
                    totalNumTies++;
                    UpdateLabelText();
                    IsGameOver = true;
                }

                // Normal case - switch back to Player 1
                else
                {
                    computerIsNext = false;
                }
            }
        }

        // This method checks for the winning conditions and returns true if there is a winner
        private bool CheckForWin(string token)
        {
            // Checks for horizontal win
            if ((token == button1.Text && token == button2.Text && token == button3.Text) ||
                (token == button4.Text && token == button5.Text && token == button6.Text) ||
                (token == button7.Text && token == button8.Text && token == button9.Text) ||
                // Checks for vertical win
                (token == button1.Text && token == button4.Text && token == button7.Text) ||
                (token == button2.Text && token == button5.Text && token == button8.Text) ||
                (token == button3.Text && token == button6.Text && token == button9.Text) ||
                // Checks for diagonal win
                (token == button1.Text && token == button5.Text && token == button9.Text) ||
                (token == button3.Text && token == button5.Text && token == button7.Text)) {

                return true;
            }
            return false;
        }

        // This method provides the length and width of the grid buttons 
        // based on the smallest dimension of Form1 to ensure buttons are
        // perfectly square.
        private int Form1_Resize(object sender, EventArgs e)
        {
            // variables
            var gridSize = 0;

            if (ClientSize.Width < ClientSize.Height)
            {
                gridSize = ClientSize.Width;
            }
            else
            {
                gridSize = ClientSize.Height;
            }
            return gridSize;
        }
    }
}
