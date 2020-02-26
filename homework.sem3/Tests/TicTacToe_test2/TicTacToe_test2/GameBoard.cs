using System.Collections.Generic;
using System.ComponentModel;

namespace TicTacToe_test2
{
    public class GameBoard : INotifyPropertyChanged
    {
        /// <summary>
        /// enum for current player
        /// </summary>
        public enum CurrentPlayer
        {
            X = 1,
            O
        }

        /// <summary>
        /// variable to be considered the current progress of the players
        /// </summary>
        private int turn = 1;

        /// <summary>
        /// variable for current player
        /// </summary>
        protected internal CurrentPlayer currentPlayer = CurrentPlayer.X;

        /// <summary>
        /// variable if one of players won the game
        /// </summary>
        private bool hasWon = false;

        /// <summary>
        /// Property to know whether one of players won
        /// </summary>
        public bool HasWon
        {
            get => hasWon;
            set
            {
                hasWon = value;
                NotifyPropertyChanged("HasWon");
            }
        }

        /// <summary>
        /// Dictionary to distinguish buttons on game board
        /// </summary>
        private Dictionary<string, int> board = new Dictionary<string, int>()
            {
                {"TopXLeft",0 },
                {"TopXMiddle",0 },
                {"TopXRight",0 },
                {"CenterXLeft",0 },
                {"CenterXMiddle",0 },
                {"CenterXRight",0 },
                {"BottomXLeft",0 },
                {"BottomXMiddle",0 },
                {"BottomXRight",0 }
            };

        /// <summary>
        /// Method to know if someone won the game
        /// </summary>
        /// <param name="info">Information how player won.</param>
        public void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        /// <summary>
        /// Event about winning
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Calls all methods that check if a game has been won
        /// </summary>
        /// <param name="buttonName">Button that was pressed</param>
        /// <returns>Bool result</returns>
        private bool CheckIfWon(string buttonName)
        {
            if (WonInRow(buttonName))
            {
                return true;
            }
            else if (WonInColumn(buttonName))
            {
                return true;
            }
            else if (WonInDiagonal(buttonName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Checks to see if a player has just won through having three pieces in the tile's row
        private bool WonInRow(string name)
        {
            var row = name.Substring(0, name.IndexOf('X') - 1);

            foreach (var element in board)
            {
                var keyName = element.Key;
                var rowOfElement = keyName.Substring(0, keyName.IndexOf('X') - 1);

                if (rowOfElement == row)
                {
                    if (element.Value != (int)currentPlayer)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //Checks to see if player has just won having three pieces in the tile's column
        private bool WonInColumn(string name)
        {
            var column = name.Substring(name.IndexOf('X') + 1);

            foreach (var element in board)
            {
                var keyName = element.Key;
                var columnOfElement = keyName.Substring(keyName.IndexOf('X') + 1);

                if (columnOfElement == column)
                {
                    if (element.Value != (int)currentPlayer)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //Checks to see if player has just won by having three pieces diagonally
        private bool WonInDiagonal(string name)
        {
            if (name == "TopXLeft" || name == "CenterXMiddle" || name == "BottomXRight")
            {
                if (board["CenterXMiddle"] == (int)currentPlayer && board["BottomXRight"] == (int)currentPlayer && board["TopXLeft"] == (int)currentPlayer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (name == "TopXRight" || name == "CenterXMiddle" || name == "BottomXLeft")
            {
                if (board["CenterXMiddle"] == (int)currentPlayer && board["BottomXLeft"] == (int)currentPlayer && board["TopXRight"] == (int)currentPlayer)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Update the dictionary by changing the value of the selected tile(key) to the players value
        private void UpdateDictionary(string buttonName)
        {
            string tileName = buttonName;

            board[tileName] = (int)currentPlayer;
        }

        //Handles logic of game by updating board and checking win conditions, called on tile click
        public void UpdateBoard(string buttonName)
        {
            UpdateDictionary(buttonName);

            if (turn >= 5)//Earliest turn a player can win
            {
                if (CheckIfWon(buttonName))
                {
                    HasWon = true;
                }
            }

            turn++;

            if (currentPlayer == CurrentPlayer.X)
            {
                currentPlayer = CurrentPlayer.O;
            }

            else if (currentPlayer == CurrentPlayer.O)
            {
                currentPlayer = CurrentPlayer.X;
            }
        }
    }
}
