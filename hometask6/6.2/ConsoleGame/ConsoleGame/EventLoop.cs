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
        private ArrowHandler leftHandler;

        /// <summary>
        /// Variable for right handler.
        /// </summary>
        private ArrowHandler rightHandler;

        /// <summary>
        /// Variable for up handler.
        /// </summary>
        private ArrowHandler upHandler;

        /// <summary>
        /// Variable for down handler.
        /// </summary>
        private ArrowHandler downHandler;

        /// <summary>
        /// Method to add a method to the delegate by pressing the left key.
        /// </summary>
        /// <param name="left">Method for describing left button click.</param>
        public void RegisterLeftHandler(ArrowHandler left)
        {
            leftHandler += left;
        }

        /// <summary>
        /// Method to add a method to the delegate by pressing the right key.
        /// </summary>
        /// <param name="right">Method for describing right button click.</param>
        public void RegisterRightHandler(ArrowHandler right)
        {
            rightHandler += right;
        }

        /// <summary>
        /// Method to add a method to the delegate by pressing the up key.
        /// </summary>
        /// <param name="up">Method for describing up button click.</param>
        public void RegisterUpHandler(ArrowHandler up)
        {
            upHandler += up;
        }

        /// <summary>
        /// Method to add a method to the delegate by pressing the down key.
        /// </summary>
        /// <param name="down">Method for describing down button click.</param>
        public void RegisterDownHandler(ArrowHandler down)
        {
            downHandler += down;
        }

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