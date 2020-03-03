using NUnit.Framework;
using TicTacToe_test2;

namespace TicTacToeTests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
            gameBoard = new GameBoard();
        }

        [Test]
        public void WonInRowTests()
        {
            var firstButton = "TopXLeft";
            var secondButton = "CenterXLeft";
            var thirdButton = "TopXMiddle";
            var fourthButton = "BottomXLeft";
            var fifthButton = "TopXRight";
            gameBoard.UpdateBoard(firstButton);
            gameBoard.UpdateBoard(secondButton);
            gameBoard.UpdateBoard(thirdButton);
            gameBoard.UpdateBoard(fourthButton);
            gameBoard.UpdateBoard(fifthButton);
            Assert.IsTrue(gameBoard.HasWon);
        }

        [Test]
        public void WonInColumn()
        {
            var firstButton = "TopXLeft";
            var secondButton = "TopXMiddle";
            var thirdButton = "CenterXLeft";
            var fourthButton = "TopXRight";
            var fifthButton = "BottomXLeft";
            gameBoard.UpdateBoard(firstButton);
            gameBoard.UpdateBoard(secondButton);
            gameBoard.UpdateBoard(thirdButton);
            gameBoard.UpdateBoard(fourthButton);
            gameBoard.UpdateBoard(fifthButton);
            Assert.IsTrue(gameBoard.HasWon);
        }

        [Test]
        public void WonInDiagonal()
        {
            var firstButton = "TopXLeft";
            var secondButton = "TopXMiddle";
            var thirdButton = "CenterXMiddle";
            var fourthButton = "TopXRight";
            var fifthButton = "BottomXRight";
            gameBoard.UpdateBoard(firstButton);
            gameBoard.UpdateBoard(secondButton);
            gameBoard.UpdateBoard(thirdButton);
            gameBoard.UpdateBoard(fourthButton);
            gameBoard.UpdateBoard(fifthButton);
            Assert.IsTrue(gameBoard.HasWon);
        }

        private GameBoard gameBoard;
    }
}