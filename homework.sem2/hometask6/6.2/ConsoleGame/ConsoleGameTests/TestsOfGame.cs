using NUnit.Framework;
using ConsoleGame;
using System;

namespace Tests
{
    public class Tests
    {
        /// <summary>
        /// Private class for drawing game for the tests.
        /// </summary>
        private class DrawForTests : IDraw
        {
            /// <summary>
            /// Method for drawing the gamer on the map.
            /// </summary>
            /// <param name="coordinates">current coordinates.</param>
            public void WriteGamer((int, int) coordinates) { }

            /// <summary>
            /// Method for drawing empty space on the map.
            /// </summary>
            /// <param name="previousCoordinates">Previous coordinates of the gamer.</param>
            public void WriteEmptySpace((int, int) previousCoordinates) { }
        }

        [SetUp]
        public void Setup()
        {
            eventLoop = new EventLoop();
            game = new Game(drawForTests);
            drawForTests = new DrawForTests();
            game.ReadFromFile("map.txt");
            eventLoop.rightHandler += game.OnRight;
            eventLoop.leftHandler += game.OnLeft;
            eventLoop.downHandler += game.OnDown;
            eventLoop.upHandler += game.OnUp;
            game.PutGamerOnMap();
        }

        [Test]
        public void BeginCoordinates()
        {
            currCoords = game.CurrentCoords;
            Assert.AreEqual((0, 1), currCoords);
        }

        [Test]
        public void OnRightTest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((0, 2), currCoords);
        }

        [Test]
        public void OnLeftTest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.LeftArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((0, 1), currCoords);
        }

        [Test]
        public void UpTest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.UpArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((0, 1), currCoords);
        }

        [Test]
        public void DownTest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.DownArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((1, 1), currCoords);
        }

        [Test]
        public void ManyTimesRightTest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((0, 7), currCoords);
        }

        [Test]
        public void ManyTimesOnLeftTest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.LeftArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.LeftArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.LeftArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.LeftArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.LeftArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.LeftArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((0, 1), currCoords);
        }

        [Test]
        public void ManyTimesDowntest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.DownArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.DownArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((2, 4), currCoords);
        }

        [Test]
        public void ManyTimesUptest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.DownArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.DownArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.UpArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.UpArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.UpArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.UpArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((0, 4), currCoords);
        }

        [Test]
        public void SquareTest()
        {
            eventLoop.SelectConsoleKey(ConsoleKey.RightArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.DownArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.LeftArrow);
            eventLoop.SelectConsoleKey(ConsoleKey.UpArrow);
            currCoords = game.CurrentCoords;
            Assert.AreEqual((0, 1), currCoords);
        }

        private Game game;
        private (int, int) currCoords;
        private EventLoop eventLoop;
        private DrawForTests drawForTests;
    }
}
