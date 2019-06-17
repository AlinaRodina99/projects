using System;

namespace ConsoleGame
{
    /// <summary>
    /// Delegate for methods of moving of the gamer.
    /// </summary>
    public delegate void ArrowHandler();

    /// <summary>
    /// Class for the event loop.
    /// </summary>
    public class EventLoop
    {
        /// <summary>
        /// Variable for left handler.
        /// </summary>
        public event ArrowHandler leftHandler;

        /// <summary>
        /// Variable for right handler.
        /// </summary>
        public event ArrowHandler rightHandler;

        /// <summary>
        /// Variable for up handler.
        /// </summary>
        public event ArrowHandler upHandler;

        /// <summary>
        /// Variable for down handler.
        /// </summary>
        public event ArrowHandler downHandler;

        /// <summary>
        /// Method to select button.
        /// </summary>
        /// <param name="key">Button that was pressed.</param>
        public void SelectConsoleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    rightHandler?.Invoke();
                    break;
                case ConsoleKey.LeftArrow:
                    leftHandler?.Invoke();
                    break;
                case ConsoleKey.DownArrow:
                    downHandler?.Invoke();
                    break;
                case ConsoleKey.UpArrow:
                    upHandler?.Invoke();
                    break;
            }
        }

        /// <summary>
        /// Method for all moves of the gamer.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                SelectConsoleKey(key.Key);
            }
        }
    }
}